// Decompiled with JetBrains decompiler
// Type: Tasks.OtaCheckTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using OtaControl.PhoneReader;
using Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Utils;

namespace Tasks
{
  public class OtaCheckTask
  {
    private BackgroundWorker worker;
    private OtaCheckTask.OnOtaCheckPhoneDelegate otaPhoneDelegate;
    private OtaCheckTask.OnOtaCheckImagesDelegate otaImagesDelegate;
    private OtaCheckTask.OnOtaCheckCompletedDelegate taskCompletedDelegate;
    private bool checking;
    private Dictionary<string, object> taskParams;

    public bool IsBusy => this.worker.IsBusy || this.checking;

    public OtaCheckTask(
      OtaCheckTask.OnOtaCheckPhoneDelegate otaPhoneDelegate,
      OtaCheckTask.OnOtaCheckImagesDelegate otaImagesDelegate,
      OtaCheckTask.OnOtaCheckCompletedDelegate taskCompletedDelegate)
    {
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = true;
      this.worker.WorkerReportsProgress = true;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
      this.otaPhoneDelegate = otaPhoneDelegate;
      this.otaImagesDelegate = otaImagesDelegate;
      this.taskCompletedDelegate = taskCompletedDelegate;
    }

    public void StartFullTask(string sessionId, string deviceId)
    {
      this.checking = true;
      this.taskParams = new Dictionary<string, object>();
      this.taskParams.Add("SessionId", (object) sessionId);
      this.taskParams.Add("DeviceId", (object) deviceId);
      this.worker.RunWorkerAsync((object) this.taskParams);
    }

    public void StartCheckServerTask(string sessionId, string deviceId, OtaItem otaPhone)
    {
      this.checking = true;
      this.taskParams = new Dictionary<string, object>();
      this.taskParams.Add("SessionId", (object) sessionId);
      this.taskParams.Add("DeviceId", (object) deviceId);
      this.taskParams.Add("OtaPhone", (object) otaPhone);
      this.worker.RunWorkerAsync((object) this.taskParams);
    }

    public void CancelTask()
    {
      CLogs.E("OTA Check request is canceled.");
      if (!this.worker.IsBusy)
        return;
      this.worker.CancelAsync();
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
      object obj1;
      dictionary.TryGetValue("SessionId", out obj1);
      object obj2;
      dictionary.TryGetValue("DeviceId", out obj2);
      object userState;
      dictionary.TryGetValue("OtaPhone", out userState);
      Sessions.Lock((string) obj1);
      try
      {
        CLogs.B("Start OTA check request, login account: " + OtaParam.Instance.Account.Username);
        if (userState == null)
        {
          CLogs.I("Query device information from USB.");
          userState = (object) new OtaPhoneItem(new PhoneInformation().GetPhoneInformation((string) obj1, (string) obj2));
          this.worker.ReportProgress(0, userState);
          if (this.worker.CancellationPending)
          {
            CLogs.E("OTA check request had been canceled.");
            e.Result = (object) 1223L;
            return;
          }
        }
        if (((OtaItem) userState).OtaUpdateAvailable)
        {
          CLogs.I("Query image list from server, device: " + ((OtaItem) userState).ToLogString());
          OtaItemList otaItemList = this.QueryImages((string) obj1, (OtaPhoneItem) userState);
          this.worker.ReportProgress(1, (object) otaItemList);
          if (this.worker.CancellationPending)
          {
            CLogs.E("OTA check request had been canceled.");
            e.Result = (object) 1223L;
            return;
          }
          CLogs.I("Query image list is success, image list: " + otaItemList.ToLogString());
        }
        else
        {
          CLogs.W("OTA feature is not supported.");
          this.worker.ReportProgress(1, (object) new OtaItemList());
          if (this.worker.CancellationPending)
          {
            CLogs.E("OTA check request had been canceled.");
            e.Result = (object) 1223L;
            return;
          }
        }
        CLogs.I("OTA check request is success.");
        e.Result = (object) 0L;
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
        Sessions.Unlock((string) obj1);
      }
    }

    private OtaItemList QueryImages(string sessionId, OtaPhoneItem phone)
    {
      OtaItemList otaItemList = new OtaItemList();
      OtaAccount account = OtaParam.Instance.Account;
      ParallelTasks<ImageRequest> parallelTasks = new ParallelTasks<ImageRequest>(sessionId);
      account.ForEachRight((OtaAccount.RightAction) ((right, webService) =>
      {
        ImageRequest request = new ImageRequest(phone.FullItem, right, webService, !phone.IsRootStatus && phone.DeltaUpdateAvailable);
        parallelTasks.QueueRequest(request, request.DoneEvent, new WaitCallback(request.ThreadPoolCallback));
      }));
      parallelTasks.WaitAllRequests();
      foreach (ImageRequest request in parallelTasks.Requests)
      {
        if (request.Result == 0L)
          otaItemList.Add(request.WebService, request.Images);
      }
      if (account.LatestVersionListed)
        otaItemList.ReserveLastestVersion((OtaItem) phone);
      return otaItemList;
    }

    private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      try
      {
        if (this.worker.CancellationPending)
          return;
        object obj;
        this.taskParams.TryGetValue("SessionId", out obj);
        switch (e.ProgressPercentage)
        {
          case 0:
            this.otaPhoneDelegate((string) obj, (OtaPhoneItem) e.UserState);
            break;
          case 1:
            this.otaImagesDelegate((string) obj, (OtaItemList) e.UserState);
            break;
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        this.checking = false;
        object obj;
        this.taskParams.TryGetValue("SessionId", out obj);
        this.taskCompletedDelegate((string) obj, (long) e.Result);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private enum ProgressUserState
    {
      CHECK_PHONE,
      CHECK_IMAGE,
    }

    public delegate void OnOtaCheckPhoneDelegate(string sessionId, OtaPhoneItem otaPhone);

    public delegate void OnOtaCheckImagesDelegate(string sessionId, OtaItemList otaImages);

    public delegate void OnOtaCheckCompletedDelegate(string sessionId, long result);
  }
}
