// Decompiled with JetBrains decompiler
// Type: DataCollection.DataFileCache.LogQueue
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Params;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace DataCollection.DataFileCache
{
  internal class LogQueue
  {
    private static LogQueue instance;
    private int maxUploadFiles;
    private string queueFolder;
    private List<CollectionFile> queueFiles;

    private LogQueue()
    {
      this.maxUploadFiles = 10;
      this.queueFiles = new List<CollectionFile>();
      this.queueFolder = Path.Combine(ToolParam.Instance.GetDataFolder(), "LogCache");
      Directory.CreateDirectory(this.queueFolder);
      foreach (string file in Directory.GetFiles(this.queueFolder, "*.ini"))
        this.queueFiles.Add(new CollectionFile(file));
    }

    public static LogQueue Instance
    {
      get
      {
        if (LogQueue.instance == null)
          LogQueue.instance = new LogQueue();
        return LogQueue.instance;
      }
    }

    public void RefershQueue() => this.AddNonQueuedFiles();

    private void AddNonQueuedFiles()
    {
      foreach (string file in Directory.GetFiles(this.queueFolder, "*.ini"))
      {
        if (!this.ContainQueueFile(file))
          this.queueFiles.Add(new CollectionFile(file));
      }
    }

    private bool ContainQueueFile(string filePath)
    {
      foreach (CollectionFile queueFile in this.queueFiles)
      {
        if (queueFile.FilePath.Equals(filePath))
          return true;
      }
      return false;
    }

    public void Remove(CollectionFile file)
    {
      File.Delete(file.FilePath);
      this.queueFiles.Remove(file);
    }

    public void Requeue(CollectionFile file)
    {
      file.MarkRunableEx();
      this.queueFiles.Remove(file);
      this.queueFiles.Add(file);
    }

    private bool CompletedFiles(CollectionFile x) => x.RunCompleted;

    public bool Available
    {
      get
      {
        int num = 0;
        foreach (CollectionFile queueFile in this.queueFiles)
        {
          if (queueFile.Runable)
            ++num;
        }
        return num > 0 && this.queueFiles.Count - num < this.maxUploadFiles;
      }
    }

    public CollectionFile GetAvailableFile()
    {
      foreach (CollectionFile queueFile in this.queueFiles)
      {
        if (queueFile.Runable)
          return queueFile.MarkRunning();
      }
      throw new CException(232L, "No available collection file.");
    }
  }
}
