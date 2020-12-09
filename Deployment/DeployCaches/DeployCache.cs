// Decompiled with JetBrains decompiler
// Type: Deployment.DeployCaches.DeployCache
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Params;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Utils;

namespace Deployment.DeployCaches
{
  internal class DeployCache
  {
    private static DeployCache instance;
    private string cacheFolder;
    private DeploymentFile deploymentFile;
    private ApplicationFile applicationFile;

    public string CacheFolder => this.cacheFolder;

    public string DeploymentName => Assembly.GetExecutingAssembly().GetName().Name + ".deployment";

    public string DeploymentPath => this.applicationFile.DeployerPath;

    private DeployCache()
    {
      this.cacheFolder = ToolParam.Instance.GetUserProjectFolder(nameof (DeployCache));
      DeployCacheConfig.CreateInstance(ToolParam.Instance.GetUserTempFolder(nameof (DeployCache)));
      if (!System.IO.File.Exists(Path.Combine(this.cacheFolder, this.DeploymentName)))
        return;
      this.deploymentFile = DeploymentFile.LoadFile(Path.Combine(this.cacheFolder, this.DeploymentName));
      if (!System.IO.File.Exists(Path.Combine(this.cacheFolder, this.deploymentFile.ApplicationName)))
        return;
      this.applicationFile = ApplicationFile.LoadFile(Path.Combine(this.cacheFolder, this.deploymentFile.ApplicationName));
    }

    public static DeployCache Instance
    {
      get
      {
        if (DeployCache.instance == null)
          DeployCache.instance = new DeployCache();
        return DeployCache.instance;
      }
    }

    public bool IsDownloaded => this.deploymentFile != null && this.applicationFile != null && this.applicationFile.GetFiles().TrueForAll((Predicate<DeployFile>) (file => file.Downloaded));

    public bool IsDeployRequired => this.deploymentFile != null && this.applicationFile != null && (this.deploymentFile.DisplayVersion.CompareTo(ToolParam.Instance.ToolVersion) > 0 && !string.IsNullOrEmpty(this.applicationFile.DeployerPath)) && System.IO.File.Exists(this.applicationFile.DeployerPath);

    public long DownloadFiles() => this.LoadDeploymentFile();

    private long LoadDeploymentFile()
    {
      CLogs.I("Connect to deployment server, host: " + DeployCacheConfig.Instance.Host);
      DeploymentFile deploymentFile = DeploymentFile.LoadStream(this.DownloadTextStream(this.DeploymentName));
      if (deploymentFile.DisplayVersion.CompareTo(ToolParam.Instance.ToolVersion) <= 0)
      {
        CLogs.I(string.Format("No newer depolyment version was found, server: {0}, tool: {1}", (object) deploymentFile.DisplayVersion, (object) ToolParam.Instance.ToolVersion));
        return 0;
      }
      if (this.deploymentFile != null && deploymentFile.DisplayVersion.CompareTo(this.deploymentFile.DisplayVersion) == 0 && this.IsDownloaded)
      {
        CLogs.I(string.Format("Newer depolyment version was downloaded, server: {0}, tool: {1}", (object) deploymentFile.DisplayVersion, (object) ToolParam.Instance.ToolVersion));
        return 0;
      }
      if (this.deploymentFile != null && deploymentFile.DisplayVersion.CompareTo(this.deploymentFile.DisplayVersion) != 0)
        this.ClearCacheFiles();
      if (this.deploymentFile == null)
        this.deploymentFile = deploymentFile.SaveFile(Path.Combine(this.cacheFolder, this.DeploymentName));
      return this.LoadApplicationFile();
    }

    private long LoadApplicationFile()
    {
      if (this.applicationFile == null)
      {
        ApplicationFile applicationFile = ApplicationFile.LoadStream(this.DownloadTextStream(this.deploymentFile.ApplicationName));
        foreach (DeployFile file in applicationFile.GetFiles())
        {
          if (!file.IsUpdateRequired)
            applicationFile.RemoveFile(file.Name);
        }
        this.applicationFile = applicationFile.SaveFile(Path.Combine(this.cacheFolder, this.deploymentFile.ApplicationName));
      }
      return this.LoadDeployFiles();
    }

    private long LoadDeployFiles()
    {
      foreach (DeployFile file in this.applicationFile.GetFiles())
      {
        if (!file.Downloaded)
          this.DownloadFileStream(file);
      }
      return 0;
    }

    public void ClearCacheFiles()
    {
      Directory.Delete(this.cacheFolder, true);
      Directory.CreateDirectory(this.cacheFolder);
      this.deploymentFile = (DeploymentFile) null;
      this.applicationFile = (ApplicationFile) null;
    }

    private string DownloadTextStream(string file)
    {
      Stream stream = (Stream) null;
      HttpWebResponse httpWebResponse = (HttpWebResponse) null;
      try
      {
        CLogs.I(string.Format("Start downloading '{0}'", (object) Path.GetFileName(file)));
        httpWebResponse = (HttpWebResponse) this.GetHttpRequest(Path.Combine(DeployCacheConfig.Instance.WebSite, file + ".deploy").Replace("\\", "/")).GetResponse();
        stream = httpWebResponse.GetResponseStream();
        using (TextReader textReader = (TextReader) new StreamReader(stream, Encoding.ASCII))
          return textReader.ReadToEnd();
      }
      finally
      {
        stream?.Close();
        httpWebResponse?.Close();
      }
    }

    private void DownloadFileStream(DeployFile file)
    {
      Stream source = (Stream) null;
      HttpWebResponse httpWebResponse = (HttpWebResponse) null;
      try
      {
        CLogs.I(string.Format("Start downloading '{0}'", (object) Path.GetFileName(file.Name)));
        httpWebResponse = (HttpWebResponse) this.GetHttpRequest(Path.Combine(Path.Combine(DeployCacheConfig.Instance.WebSite, this.deploymentFile.ApplicationFolder), file.Name + ".deploy").Replace("\\", "/")).GetResponse();
        source = httpWebResponse.GetResponseStream();
        string path = Path.Combine(Path.Combine(this.cacheFolder, this.deploymentFile.ApplicationFolder), file.Name);
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
        using (FileStream fileStream = System.IO.File.Create(path))
          this.CopyStream(source, file.Size, (Stream) fileStream, (HashAlgorithm) cryptoServiceProvider);
        if (!file.Checksum.Equals(BitConverter.ToString(cryptoServiceProvider.Hash).Replace("-", "")))
        {
          System.IO.File.Delete(path);
          throw new Exception(string.Format("Compare '{0}' checksum fails", (object) Path.GetFileName(file.Name)));
        }
      }
      finally
      {
        source?.Close();
        httpWebResponse?.Close();
      }
    }

    private HttpWebRequest GetHttpRequest(string url)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.PreAuthenticate = true;
      httpWebRequest.AllowAutoRedirect = true;
      httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
      httpWebRequest.Proxy = WebRequest.GetSystemWebProxy();
      httpWebRequest.Proxy.Credentials = (ICredentials) CredentialCache.DefaultNetworkCredentials;
      return httpWebRequest;
    }

    private void CopyStream(
      Stream source,
      long sourceSize,
      Stream destination,
      HashAlgorithm hasher)
    {
      int count = 1024;
      byte[] numArray = new byte[count];
      long num1 = 0;
      long num2 = sourceSize;
      long num3 = 0;
      long num4 = 2097152;
      int num5;
      for (; num1 < num2; num1 += (long) num5)
      {
        if (num1 >= num3)
        {
          num3 += num4;
          CLogs.I(string.Format("Downloading notification ({0:d} / {1:d} KB)", (object) (num1 / 1024L), (object) ((num2 - 1L) / 1024L + 1L)));
        }
        num5 = source.Read(numArray, 0, count);
        destination.Write(numArray, 0, num5);
        hasher.TransformBlock(numArray, 0, num5, (byte[]) null, 0);
      }
      hasher.TransformFinalBlock(new byte[0], 0, 0);
      CLogs.I(string.Format("Downloading notification ({0:d} / {1:d} KB)", (object) ((num1 - 1L) / 1024L + 1L), (object) ((num2 - 1L) / 1024L + 1L)));
    }
  }
}
