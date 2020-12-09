// Decompiled with JetBrains decompiler
// Type: Deployment.DeployCaches.DeployFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Utils;

namespace Deployment.DeployCaches
{
  public class DeployFile
  {
    private Dictionary<string, string> instance;

    public Dictionary<string, string> Instance => this.instance;

    private DeployFile() => this.instance = new Dictionary<string, string>();

    public bool IsMsiFile => this.Get("Type").Equals("Msi");

    public bool IsDeployFile => this.Get("Type").Equals("Deploy");

    public string Name => this.Get(nameof (Name));

    public string Publisher => this.Get(nameof (Publisher));

    public string DisplayName => this.Get(nameof (DisplayName));

    public string DisplayVersion => this.Get(nameof (DisplayVersion));

    public long Size => !this.Contain(nameof (Size)) ? 0L : long.Parse(this.Get(nameof (Size)));

    public string Checksum => this.Get(nameof (Checksum));

    public bool Downloaded => this.Get(nameof (Downloaded)).Equals("True");

    public bool IsUpdateRequired => !this.IsMsiFile || this.IsMsiUpdateRequired();

    private bool IsMsiUpdateRequired()
    {
      foreach (string subKeyName in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + subKeyName);
        string str1 = registryKey.GetValue("DisplayName") as string;
        string str2 = registryKey.GetValue("Publisher") as string;
        string str3 = registryKey.GetValue("DisplayVersion") as string;
        if (str1 != null && str2 != null && (str3 != null && str1.Equals(this.DisplayName)) && str2.Equals(this.Publisher))
          return str3.CompareTo(this.DisplayVersion) < 0;
      }
      return true;
    }

    public static DeployFile Parse(XmlElement element)
    {
      DeployFile deployFile = new DeployFile();
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) element.Attributes)
        deployFile.Set(attribute.Name, attribute.Value);
      return deployFile;
    }

    public DeployFile FindFile(string folder)
    {
      string path = Path.Combine(folder, this.Name);
      if (File.Exists(path) && new Md5Ex().ComputeFileHash(path).Equals(this.Checksum))
        this.Set("Downloaded", "True");
      return this;
    }

    private DeployFile Set(string key, string value)
    {
      if (!string.IsNullOrEmpty(value))
        this.instance[key] = value;
      else if (this.instance.ContainsKey(key))
        this.instance.Remove(key);
      return this;
    }

    private bool Contain(string key) => this.instance.ContainsKey(key);

    private string Get(string key) => !this.instance.ContainsKey(key) ? string.Empty : this.instance[key];
  }
}
