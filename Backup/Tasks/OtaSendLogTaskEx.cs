// Decompiled with JetBrains decompiler
// Type: Tasks.OtaSendLogTaskEx
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using DataCollection.DataFileCache;
using MyResources.OtaHandlerService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Utils;

namespace Tasks
{
  internal class OtaSendLogTaskEx
  {
    private BackgroundWorker worker;
    private OtaSendLogTaskEx.OnOtaSendLogTaskCompletedDelegate taskCompletedDelegate;
    private Dictionary<string, object> taskParams;

    public OtaSendLogTaskEx(
      OtaSendLogTaskEx.OnOtaSendLogTaskCompletedDelegate taskCompletedDelegate)
    {
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.WorkerReportsProgress = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
      this.taskCompletedDelegate = taskCompletedDelegate;
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
        CLogs.B("Start OTA Send Log request.");
        if (obj == null)
          return;
        OtaHandler otaHandler = new OtaHandler();
        Profile profile = new Profile(((CollectionFile) obj).FilePath);
        string[] strArray1 = profile.ReadString("LogReport", "Information", "").Trim().Split(',');
        string[] strArray2 = profile.ReadString("LogReport", "Server", "").Trim().Split(',');
        string str = profile.ReadString("LogReport", "Account", "Downloader1").Trim();
        string password = string.Compare(str, "Downloader1") == 0 ? "Downloader1" : RsaCrypt.DecryptString(profile.ReadString("LogReport", "Password", "").Trim());
        e.Result = (object) otaHandler.SetLoginUrl(strArray2[0]).Login(str, password).SetLogUrl(strArray2[1]).SendUpdateReport(strArray1[0], strArray1[1], strArray1[2], strArray1[3], strArray1[4], (long) int.Parse(strArray1[5]), strArray1[6], strArray1[7].Equals("True"));
        if ((long) e.Result == 0L)
          ((CollectionFile) obj).MarkDone();
        else
          ((CollectionFile) obj).MarkAbort();
      }
      catch (CException ex)
      {
        e.Result = (object) ex.CResult;
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
        Sessions.Unlock(empty);
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

    public delegate void OnOtaSendLogTaskCompletedDelegate(CollectionFile file);
  }
}
