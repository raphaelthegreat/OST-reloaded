// Decompiled with JetBrains decompiler
// Type: DataCollection.DataFileCache.CollectionFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.IO;

namespace DataCollection.DataFileCache
{
  public class CollectionFile
  {
    private RunState state;
    private string filePath;
    private string fileName;
    private string sourceId;
    private string sourceType;

    public RunState State => this.state;

    public string FilePath => this.filePath;

    public string FileName => this.fileName;

    public string SourceId
    {
      get => this.sourceId;
      set => this.sourceId = value;
    }

    public string SourceType => this.sourceType;

    public CollectionFile(string filePath)
    {
      this.state = RunState.IDLE;
      this.filePath = filePath;
      this.sourceType = Path.GetFileName(Path.GetDirectoryName(filePath));
      string fileName = Path.GetFileName(filePath);
      this.fileName = fileName.StartsWith("ID") ? fileName.Substring(fileName.IndexOf('_') + 1) : fileName;
      this.sourceId = fileName.StartsWith("ID") ? fileName.Substring("ID".Length, fileName.IndexOf('_') - "ID".Length) : string.Empty;
    }

    public bool Runable => this.state == RunState.IDLE;

    public bool RunCompleted => this.state > RunState.RUN;

    public bool Done => this.state == RunState.DONE;

    public bool Suspended => this.state == RunState.SUSPEND;

    public CollectionFile MarkDone()
    {
      this.state = RunState.DONE;
      return this;
    }

    public CollectionFile MarkSuspend()
    {
      this.state = RunState.SUSPEND;
      return this;
    }

    public CollectionFile MarkAbort()
    {
      this.state = RunState.ABORT;
      return this;
    }

    public CollectionFile MarkRunning()
    {
      this.state = RunState.RUN;
      return this;
    }

    public CollectionFile MarkRunable()
    {
      if (this.state == RunState.SUSPEND)
      {
        this.RenameFileWithSourceId();
      }
      else
      {
        this.RenameFileWithoutSourceId();
        this.sourceId = string.Empty;
      }
      this.state = RunState.IDLE;
      return this;
    }

    public CollectionFile MarkRunableEx()
    {
      this.state = RunState.IDLE;
      return this;
    }

    private void RenameFileWithSourceId()
    {
      string fileName = Path.GetFileName(this.filePath);
      if (fileName.StartsWith("ID"))
        return;
      string destFileName = Path.Combine(Path.GetDirectoryName(this.filePath), string.Format("ID{0}_{1}", (object) this.sourceId, (object) fileName));
      File.Move(this.filePath, destFileName);
      this.filePath = destFileName;
    }

    private void RenameFileWithoutSourceId()
    {
      string fileName = Path.GetFileName(this.filePath);
      if (!fileName.StartsWith("ID"))
        return;
      string destFileName = Path.Combine(Path.GetDirectoryName(this.filePath), fileName.Substring(fileName.IndexOf('_') + 1));
      File.Move(this.filePath, destFileName);
      this.filePath = destFileName;
    }

    public override string ToString() => !string.IsNullOrEmpty(this.fileName) ? string.Format("({0}: {1})", (object) this.sourceType, (object) this.fileName) : base.ToString();
  }
}
