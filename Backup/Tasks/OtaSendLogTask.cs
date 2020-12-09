// Decompiled with JetBrains decompiler
// Type: Tasks.OtaSendLogTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.OtaHandlerService;
using OtaControl.OtaImageCache;
using Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Utils;

namespace Tasks
{
  internal class OtaSendLogTask
  {
    private BackgroundWorker worker;
    private OtaSendLogTask.OnOtaSendLogTaskCompletedDelegate taskCompletedDelegate;
    private Dictionary<string, object> taskParams;

    public OtaSendLogTask(
      OtaSendLogTask.OnOtaSendLogTaskCompletedDelegate taskCompletedDelegate)
    {
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.WorkerReportsProgress = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
      this.taskCompletedDelegate = taskCompletedDelegate;
    }

    public void StartTask(
      string sessionId,
      OtaFile otaFile,
      string deviceId,
      string internalModel,
      string imageId,
      string fromVersion,
      string toVersion,
      long errCode,
      string statge,
      bool localImage)
    {
      this.taskParams = new Dictionary<string, object>();
      this.taskParams.Add("SessionId", (object) sessionId);
      this.taskParams.Add("OtaFile", (object) otaFile);
      this.taskParams.Add("DevcieId", (object) deviceId);
      this.taskParams.Add("InternalModel", (object) internalModel);
      this.taskParams.Add("ImageId", (object) imageId);
      this.taskParams.Add("FromVersion", (object) fromVersion);
      this.taskParams.Add("ToVersion", (object) toVersion);
      this.taskParams.Add("ErrCode", (object) errCode);
      this.taskParams.Add("Statge", (object) statge);
      this.taskParams.Add("LocalImage", (object) localImage);
      this.worker.RunWorkerAsync((object) this.taskParams);
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
      object obj1;
      dictionary.TryGetValue("SessionId", out obj1);
      object obj2;
      dictionary.TryGetValue("OtaFile", out obj2);
      object obj3;
      dictionary.TryGetValue("DevcieId", out obj3);
      object obj4;
      dictionary.TryGetValue("InternalModel", out obj4);
      object obj5;
      dictionary.TryGetValue("ImageId", out obj5);
      object obj6;
      dictionary.TryGetValue("FromVersion", out obj6);
      object obj7;
      dictionary.TryGetValue("ToVersion", out obj7);
      object obj8;
      dictionary.TryGetValue("ErrCode", out obj8);
      object obj9;
      dictionary.TryGetValue("Statge", out obj9);
      object obj10;
      dictionary.TryGetValue("LocalImage", out obj10);
      Sessions.Lock((string) obj1, 20000);
      string account = OtaParam.Instance.Account.Username == null ? "Downloader1" : OtaParam.Instance.Account.Username;
      string password = OtaParam.Instance.Account.Password == null ? "Downloader1" : OtaParam.Instance.Account.Password;
      try
      {
        CLogs.B("Start OTA Send Log request.");
        OtaHandler otaHandler = new OtaHandler();
        e.Result = !(bool) obj10 ? (object) otaHandler.SetLoginUrl(((OtaFile) obj2).WebService.Login).Login(account, password).SetLogUrl(((OtaFile) obj2).WebService.Log).SendUpdateReport((string) obj3, (string) obj4, (string) obj5, (string) obj6, (string) obj7, (long) obj8, (string) obj9, (bool) obj10) : (object) otaHandler.SetLoginUrl("http://www.c2dms.com/login.asmx").Login(account, password).SetLogUrl("http://www.c2dms.com/log.asmx").SendUpdateReport((string) obj3, (string) obj4, (string) obj5, (string) obj6, (string) obj7, (long) obj8, (string) obj9, (bool) obj10);
        if ((long) e.Result != 0L)
          return;
        CLogs.I("OTA Send Log request is success.");
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
        if ((long) e.Result != 0L)
        {
          CLogs.E("OTA Send Log request is fail.");
          this.WriteLogCache(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", (object) (string) obj3, (object) (string) obj4, (object) (string) obj5, (object) (string) obj6, (object) (string) obj7, (object) obj8.ToString(), (object) (string) obj9, (object) obj10.ToString()), (bool) obj10 ? string.Format("{0},{1}", (object) "http://www.c2dms.com/login.asmx", (object) "http://www.c2dms.com/log.asmx") : string.Format("{0},{1}", (object) ((OtaFile) obj2).WebService.Login, (object) ((OtaFile) obj2).WebService.Log), OtaParam.Instance.Account.Username, OtaParam.Instance.Account.Password);
        }
        CLogs.NewLine();
        CLogs.NewLine();
        Sessions.Unlock((string) obj1);
      }
    }

    private void WriteLogCache(string information, string server, string account, string password)
    {
      string str1 = Path.Combine(ToolParam.Instance.GetDataFolder(), "LogCache");
      Directory.CreateDirectory(str1);
      string str2 = Path.Combine(str1, string.Format("LogCache_{0}", (object) ToolParam.Instance.LaunchTime));
      Profile profile = new Profile(str2);
      profile.WriteString("LogReport", "Information", information);
      profile.WriteString("LogReport", "Server", server);
      if (account != null)
        profile.WriteString("LogReport", "Account", account);
      if (password != null)
        profile.WriteString("LogReport", "Password", RsaCrypt.EncryptString(password));
      File.Copy(str2, string.Format("{0}.ini", (object) str2), true);
      File.Delete(str2);
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        object obj;
        this.taskParams.TryGetValue("SessionId", out obj);
        this.taskCompletedDelegate((string) obj, (long) e.Result);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    public delegate void OnOtaSendLogTaskCompletedDelegate(string sessionId, long result);
  }
}
