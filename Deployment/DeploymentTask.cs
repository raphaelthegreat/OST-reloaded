// Decompiled with JetBrains decompiler
// Type: Deployment.DeploymentTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Deployment.DeployCaches;
using System;
using System.ComponentModel;
using Utils;

namespace Deployment
{
  internal class DeploymentTask
  {
    private BackgroundWorker worker;
    private DeploymentTask.OnTaskCompletedDelegate taskCompletedDelegate;

    public bool IsBusy => this.worker.IsBusy;

    public DeploymentTask(DeploymentTask.OnTaskCompletedDelegate tcDelegate)
    {
      this.taskCompletedDelegate = tcDelegate;
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
    }

    public void StartTask() => this.worker.RunWorkerAsync();

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      string empty = string.Empty;
      Sessions.AddChildThread(empty);
      try
      {
        e.Result = (object) DeployCache.Instance.DownloadFiles();
      }
      catch (CException ex)
      {
        e.Result = (object) ex.CResult;
        CLogs.W("Catch exception - " + ex.Message + ex.StackTrace);
      }
      catch (Exception ex)
      {
        e.Result = (object) 1064L;
        CLogs.W("Catch exception - " + ex.Message + ex.StackTrace);
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
        this.taskCompletedDelegate((long) e.Result);
      }
      catch (Exception ex)
      {
      }
    }

    public delegate void OnTaskCompletedDelegate(long result);
  }
}
