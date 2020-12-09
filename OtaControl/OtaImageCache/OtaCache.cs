// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaImageCache.OtaCache
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.OtaHandlerService;
using Params;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Utils;

namespace OtaControl.OtaImageCache
{
  internal class OtaCache
  {
    private static OtaCache instance;
    private string cacheFolder;
    private List<OtaFile> cacheFiles;
    private long maxCacheDays;
    private Progress progress;

    private OtaCache()
    {
      this.cacheFiles = new List<OtaFile>();
      this.cacheFolder = Path.Combine(ToolParam.Instance.GetDataFolder(), nameof (OtaCache));
      Directory.CreateDirectory(this.cacheFolder);
      this.maxCacheDays = 45L;
      OtaCacheConfig.CreateInstance(this.cacheFolder);
      this.ReloadCacheImages(Directory.GetFiles(this.cacheFolder));
    }

    public static OtaCache Instance
    {
      get
      {
        if (OtaCache.instance == null)
          OtaCache.instance = new OtaCache();
        return OtaCache.instance;
      }
    }

    public OtaCache SetProgress(Progress progress)
    {
      this.progress = progress;
      return this;
    }

    private void ReloadCacheImages(string[] files)
    {
      try
      {
        foreach (string file in files)
        {
          if (!Path.GetExtension(file).Equals(".ini"))
          {
            if ((long) DateTime.Now.Subtract(new FileInfo(file).LastWriteTime).Days > this.maxCacheDays)
            {
              System.IO.File.Delete(file);
            }
            else
            {
              OtaFile otaFile = OtaFile.LoadFile(file);
              if (otaFile == null)
                System.IO.File.Delete(file);
              else
                this.cacheFiles.Add(otaFile);
            }
          }
        }
        this.cacheFiles.Sort(new Comparison<OtaFile>(OtaFile.CompareByModifiedDate));
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    public OtaFile LoadCacheImage(OtaItem item)
    {
      CLogs.I("Load image from cache pool, image: " + item.ToLogString());
      List<OtaFile> serverFiles = this.GetServerFiles(item);
      this.cacheFiles.Sort(new Comparison<OtaFile>(OtaFile.CompareByModifiedDate));
      OtaFile cacheFile = this.FindCacheFile(serverFiles);
      if (cacheFile != null)
      {
        if (cacheFile.Completed)
        {
          CLogs.I("Find cached image, image: " + cacheFile.ToLogString());
          return cacheFile;
        }
        CLogs.I("Find ongoing-cached image, image: " + cacheFile.ToLogString());
        return this.DownloadCacheImage(cacheFile, 3);
      }
      CLogs.I("No cached image is found, just create new one.");
      return this.DownloadCacheImage(this.FindServerFile(serverFiles), 3);
    }

    private List<OtaFile> GetServerFiles(OtaItem item)
    {
      List<OtaFile> otaFileList = new List<OtaFile>();
      foreach (OtaItemData itemData in item.ItemDatas)
        otaFileList.Add(OtaFile.NewOtaFile(itemData.ID, itemData.IsDelta, itemData.WebService));
      return otaFileList;
    }

    private OtaFile FindCacheFile(List<OtaFile> serverFiles)
    {
      List<OtaFile> all1 = this.cacheFiles.FindAll((Predicate<OtaFile>) (file => serverFiles.Contains(file)));
      if (all1.Count > 0)
      {
        List<OtaFile> all2 = all1.FindAll((Predicate<OtaFile>) (file => file.Completed));
        if (all2.Count > 0)
          return all2[0];
        List<OtaFile> all3 = all1.FindAll((Predicate<OtaFile>) (file => file.Ongoing && file.IsDelta));
        if (all3.Count > 0)
          return this.SelectFileBySpeed(all3);
        List<OtaFile> all4 = all1.FindAll((Predicate<OtaFile>) (file => file.Ongoing && !file.IsDelta));
        if (all4.Count > 0)
          return this.SelectFileBySpeed(all4);
      }
      return (OtaFile) null;
    }

    private OtaFile FindServerFile(List<OtaFile> serverFiles)
    {
      List<OtaFile> all = serverFiles.FindAll((Predicate<OtaFile>) (file => file.IsDelta));
      return all.Count > 0 ? this.FindServerFile(all, true) : this.FindServerFile(serverFiles.FindAll((Predicate<OtaFile>) (file => !file.IsDelta)), false);
    }

    private OtaFile FindServerFile(List<OtaFile> serverFiles, bool isDelta)
    {
      OtaFile otaFile = this.SelectFileBySpeed(serverFiles);
      List<OtaFile> all = this.cacheFiles.FindAll((Predicate<OtaFile>) (file => serverFiles.Contains(file)));
      if (all.Contains(otaFile))
        return all[all.IndexOf(otaFile)];
      this.cacheFiles.Add(OtaFile.CreateFile(otaFile.ID, isDelta, otaFile.WebService, this.cacheFolder));
      return this.cacheFiles[this.cacheFiles.Count - 1];
    }

    private OtaFile SelectFileBySpeed(List<OtaFile> files)
    {
      if (files.Count == 1)
        return files[0];
      WaitHandle[] waitHandles = new WaitHandle[files.Count];
      for (int index = 0; index < files.Count; ++index)
      {
        waitHandles[index] = (WaitHandle) new AutoResetEvent(false);
        ThreadPool.QueueUserWorkItem(new WaitCallback(this.ExecutePing), (object) new Dictionary<string, object>()
        {
          ["WaitHandle"] = (object) waitHandles[index],
          ["OtaFile"] = (object) files[index]
        });
      }
      return files[WaitHandle.WaitAny(waitHandles)];
    }

    private void ExecutePing(object state)
    {
      Dictionary<string, object> dictionary = state as Dictionary<string, object>;
      object obj1;
      dictionary.TryGetValue("WaitHandle", out obj1);
      object obj2;
      dictionary.TryGetValue("OtaFile", out obj2);
      int timeout = 10000;
      TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
      try
      {
        new OtaHandler().SetUrl(((OtaFile) obj2).WebService).Ping(timeout);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        int totalMilliseconds = (int) (new TimeSpan(DateTime.Now.Ticks) - timeSpan).TotalMilliseconds;
        if (timeout > totalMilliseconds)
          Thread.Sleep(timeout - totalMilliseconds);
      }
      ((EventWaitHandle) obj1).Set();
    }

    private OtaFile DownloadCacheImage(OtaFile otaFile, int retry)
    {
      try
      {
        CLogs.I("Download image from server, image: " + otaFile.ToLogString());
        return this.DownloadCacheImageIns(otaFile);
      }
      catch (WebException ex)
      {
        if (new OtaHandler().HandleWebException(ex))
        {
          Thread.Sleep(100);
          CLogs.W("Dwonlaod image from server fails, handle web exception and then re-download image again.");
          return this.DownloadCacheImage(otaFile, retry);
        }
        if (retry-- <= 0)
          throw new CException(1064L, "Dwonlaod image from server fails, message: " + ex.Message);
        Thread.Sleep(100);
        CLogs.W("Dwonlaod image from server fails, handle unhandled web exception and then re-download image again.");
        return this.DownloadCacheImage(otaFile, --retry);
      }
    }

    private OtaFile DownloadCacheImageIns(OtaFile otaFile)
    {
      using (FileStream fileStream = this.GetFileStream(otaFile.FilePath))
      {
        this.progress.SetMessage("Connecting to remote server...");
        using (OtaStream otaStream = new OtaHandler().SetUrl(otaFile.WebService).LoginAsDownloader().GetOtaStream(otaFile.ID, otaFile.IsDelta, fileStream.Length))
        {
          this.progress.SetMessage("Downloading image file from remote server...");
          long requiredSpace = fileStream.Length + otaStream.Length;
          this.progress.RefreshPositionCount(otaStream.Length + requiredSpace);
          this.CleanDiskSpace(otaFile, requiredSpace);
          this.CopyStream(otaStream, fileStream);
        }
      }
      this.progress.SetMessage("Validating image files...");
      return otaFile.SetProgress(this.progress).MarkCompleted();
    }

    private FileStream GetFileStream(string filePath)
    {
      if (!System.IO.File.Exists(filePath))
        return new FileStream(filePath, FileMode.Create);
      FileStream fileStream = System.IO.File.OpenWrite(filePath);
      fileStream.Seek(0L, SeekOrigin.End);
      return fileStream;
    }

    private void CleanDiskSpace(OtaFile current, long requiredSpace)
    {
      string pathRoot = Path.GetPathRoot(this.cacheFolder);
      while (this.cacheFiles.Count > OtaParam.Instance.MaxCacheImages || requiredSpace * 4L > new DriveInfo(pathRoot).AvailableFreeSpace)
      {
        OtaFile not = this.FindNot(current);
        if (not == null)
          break;
        System.IO.File.Delete(not.FilePath);
        this.cacheFiles.Remove(not);
      }
    }

    private OtaFile FindNot(OtaFile current)
    {
      foreach (OtaFile cacheFile in this.cacheFiles)
      {
        if (cacheFile != current)
          return cacheFile;
      }
      return (OtaFile) null;
    }

    private void CopyStream(OtaStream otaStream, FileStream fileStream)
    {
      int count1 = 1024;
      byte[] buffer = new byte[count1];
      long num1 = 0;
      long length = otaStream.Length;
      long num2 = 0;
      long num3 = (long) ((double) ((length - num1) / (long) count1) * 0.05);
      Stream responseStream = otaStream.ResponseStream;
      while (num1 < length)
      {
        if (num2++ % num3 == 0L)
          CLogs.I(string.Format("OTA downloading notification ({0:d} / {1:d} KB)", (object) (num1 / 1024L), (object) ((length - 1L) / 1024L + 1L)));
        int count2 = responseStream.Read(buffer, 0, count1);
        fileStream.Write(buffer, 0, count2);
        num1 += (long) count2;
        this.progress.OffsetPosition((long) count2);
      }
      CLogs.I(string.Format("OTA downloading notification ({0:d} / {1:d} KB)", (object) ((num1 - 1L) / 1024L + 1L), (object) ((length - 1L) / 1024L + 1L)));
    }
  }
}
