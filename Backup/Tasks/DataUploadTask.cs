// Decompiled with JetBrains decompiler
// Type: Tasks.DataUploadTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using DataCollection.DataFileCache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Utils;

namespace Tasks
{
  internal class DataUploadTask
  {
    private BackgroundWorker worker;
    private DataUploadTask.OnTaskCompletedDelegate taskCompletedDelegate;
    private Dictionary<string, object> taskParams;

    public DataUploadTask(DataUploadTask.OnTaskCompletedDelegate newDelegate)
    {
      this.taskCompletedDelegate = newDelegate;
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.WorkerReportsProgress = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
    }

    public void StartTask(CollectionFile file)
    {
      this.taskParams = new Dictionary<string, object>();
      this.taskParams.Add("CollectionFile", (object) file);
      this.worker.RunWorkerAsync((object) this.taskParams);
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      string empty = string.Empty;
      Sessions.AddChildThread(empty);
      object obj;
      (e.Argument as Dictionary<string, object>).TryGetValue("CollectionFile", out obj);
      try
      {
        if (obj == null)
          return;
        using (DataCollection.AprHttpUpload.AprHttpUpload aprHttpUpload = new DataCollection.AprHttpUpload.AprHttpUpload((CollectionFile) obj))
          aprHttpUpload.UploadFile();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        Sessions.RemoveChildThread(empty);
      }
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        if (this.taskCompletedDelegate == null)
          return;
        object obj;
        this.taskParams.TryGetValue("CollectionFile", out obj);
        this.taskCompletedDelegate((CollectionFile) obj);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    public delegate void OnTaskCompletedDelegate(CollectionFile file);
  }
}
