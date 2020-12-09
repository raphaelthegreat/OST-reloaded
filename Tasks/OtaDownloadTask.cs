// Decompiled with JetBrains decompiler
// Type: Tasks.OtaDownloadTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using OtaControl.OtaImageCache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Utils;

namespace Tasks
{
  internal class OtaDownloadTask
  {
    private BackgroundWorker worker;
    private OtaDownloadTask.OnOtaDownloadTaskCompletedDelegate taskCompletedDelegate;
    private bool downloading;
    private Dictionary<string, object> taskParams;

    public bool IsBusy => this.worker.IsBusy || this.downloading;

    public OtaDownloadTask(
      OtaDownloadTask.OnOtaDownloadTaskCompletedDelegate taskCompletedDelegate)
    {
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.WorkerReportsProgress = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
      this.taskCompletedDelegate = taskCompletedDelegate;
    }

    public void StartTask(string sessionId, OtaItem item, Progress progress)
    {
      this.downloading = true;
      this.taskParams = new Dictionary<string, object>();
      this.taskParams.Add("SessionId", (object) sessionId);
      this.taskParams.Add("OtaItem", (object) item);
      this.taskParams.Add("Progress", (object) progress);
      this.worker.RunWorkerAsync((object) this.taskParams);
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
      object obj1;
      dictionary.TryGetValue("SessionId", out obj1);
      object obj2;
      dictionary.TryGetValue("OtaItem", out obj2);
      object obj3;
      dictionary.TryGetValue("Progress", out obj3);
      Sessions.Lock((string) obj1, 20000);
      try
      {
        CLogs.B("Start OTA download request.");
        OtaCache otaCache = OtaCache.Instance.SetProgress((Progress) obj3);
        e.Result = (object) otaCache.LoadCacheImage((OtaItem) obj2);
        CLogs.I("OTA download request is success.");
      }
      catch (CException ex)
      {
        e.Result = (object) ex.CResult;
        ((Progress) obj3).SetDetailMessage(ex.Message);
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      catch (Exception ex)
      {
        e.Result = (object) 1064L;
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        CLogs.NewLine();
        CLogs.NewLine();
        Sessions.Unlock((string) obj1);
      }
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        this.downloading = false;
        object obj1;
        this.taskParams.TryGetValue("SessionId", out obj1);
        object obj2;
        this.taskParams.TryGetValue("OtaItem", out obj2);
        if (e.Result is OtaFile)
          this.taskCompletedDelegate((string) obj1, 0L, (OtaItem) obj2, (OtaFile) e.Result);
        else
          this.taskCompletedDelegate((string) obj1, (long) e.Result, (OtaItem) obj2, (OtaFile) null);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    public delegate void OnOtaDownloadTaskCompletedDelegate(
      string sessionId,
      long result,
      OtaItem otaItem,
      OtaFile otaFile);
  }
}
