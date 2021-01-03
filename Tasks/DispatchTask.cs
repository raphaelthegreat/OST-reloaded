// Decompiled with JetBrains decompiler
// Type: Tasks.DispatchTask
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using Utils;

namespace Tasks
{
    internal class DispatchTask
    {
        private BackgroundWorker worker;
        private DispatchTask.OnTaskCompletedDelegate taskCompletedDelegate;
        private Dictionary<string, object> taskParams = new Dictionary<string, object>();
        private Dictionary<string, object> outParams = new Dictionary<string, object>();

        public bool IsBusy => this.worker.IsBusy;

        public DispatchTask(DispatchTask.OnTaskCompletedDelegate newDelegate)
        {
            this.taskCompletedDelegate = newDelegate;
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = false;
            this.worker.WorkerReportsProgress = false;
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
        }

        public void StartTask_StartUpdate(
          string sessionId,
          Product product,
          string imagePath,
          string deviceId,
          int option)
        {
            this.worker.DoWork += new DoWorkEventHandler(this.DoWork_StartUpdate);
            this.taskParams = new Dictionary<string, object>();
            this.taskParams.Add("SessionId", (object)sessionId);
            this.taskParams.Add("Product", (object)product);
            this.taskParams.Add("ImagePath", (object)imagePath);
            this.taskParams.Add("DeviceId", (object)deviceId);
            this.taskParams.Add("ProductOptions", (object)option);
            this.worker.RunWorkerAsync((object)this.taskParams);
        }

        private void DoWork_StartUpdate(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
            object obj1;
            dictionary.TryGetValue("SessionId", out obj1);
            object obj2;
            dictionary.TryGetValue("Product", out obj2);
            object obj3;
            dictionary.TryGetValue("ImagePath", out obj3);
            object obj4;
            dictionary.TryGetValue("DeviceId", out obj4);
            object obj5;
            dictionary.TryGetValue("ProductOptions", out obj5);
            Sessions.Lock((string)obj1, 20000);
            try
            {
                CLogs.B("Start update request.");
                if (obj1 != null && obj2 != null && (obj3 != null && obj4 != null) && obj5 != null)
                    e.Result = (object)((Product)obj2).StartUpdate((string)obj1, (string)obj3, (string)obj4, (int)obj5);
                if ((long)e.Result == 0L)
                    CLogs.I("Update request is success.");
                this.outParams.Add("SessionId", obj1);
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                e.Result = (object)1064L;
            }
            finally
            {
                CLogs.NewLine();
                CLogs.NewLine();
                Sessions.Unlock((string)obj1);
            }
        }

        public void StartTask_SwitchPhoneEditMode(string sessionId, string deviceId)
        {
            this.worker.DoWork += new DoWorkEventHandler(this.DoWork_SwitchPhoneEditMode);
            this.taskParams = new Dictionary<string, object>();
            this.taskParams.Add("SessionId", (object)sessionId);
            this.taskParams.Add("DeviceId", (object)deviceId);
            this.worker.RunWorkerAsync((object)this.taskParams);
        }

        private void DoWork_SwitchPhoneEditMode(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
            object obj1;
            dictionary.TryGetValue("SessionId", out obj1);
            object obj2;
            dictionary.TryGetValue("DeviceId", out obj2);
            Sessions.Lock((string)obj1, 20000);
            try
            {
                CLogs.B("Start SwitchPhoneEditMode request.");
                if (obj1 != null && obj2 != null)
                    e.Result = (object)(long)DispatchTask.SwitchPhoneDataEditMode((string)obj1, (string)obj2);
                if ((long)e.Result == 0L)
                    CLogs.I("SwitchPhoneEditMode request is success.");
                this.outParams.Add("SessionId", obj1);
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                e.Result = (object)1064L;
            }
            finally
            {
                CLogs.NewLine();
                CLogs.NewLine();
                Sessions.Unlock((string)obj1);
            }
        }

        public void StartTask_ExecFtmApiFuncion(
          string sessionId,
          string deviceId,
          int funcType,
          string input)
        {
            this.worker.DoWork += new DoWorkEventHandler(this.DoWork_ExecFtmApiFuncion);
            this.taskParams = new Dictionary<string, object>();
            this.taskParams.Add("SessionId", (object)sessionId);
            this.taskParams.Add("DeviceId", (object)deviceId);
            this.taskParams.Add("FuncType", (object)funcType);
            this.taskParams.Add("Input", (object)input);
            this.worker.RunWorkerAsync((object)this.taskParams);
        }

        private void DoWork_ExecFtmApiFuncion(object sender, DoWorkEventArgs e)
        {
            string empty = string.Empty;
            Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
            object obj1;
            dictionary.TryGetValue("SessionId", out obj1);
            object obj2;
            dictionary.TryGetValue("DeviceId", out obj2);
            object obj3;
            dictionary.TryGetValue("FuncType", out obj3);
            object obj4;
            dictionary.TryGetValue("Input", out obj4);
            Sessions.Lock((string)obj1, 20000);
            try
            {
                CLogs.B("Start ExecFtmApiFuncion request.");
                this.outParams.Add("SessionId", obj1);
                e.Result = (object)(long)this.ExecFtmApiFuncion((string)obj1, (string)obj2, (int)obj3, (string)obj4, ref empty);
                if ((long)e.Result == 0L)
                    CLogs.I("ExecFtmApiFuncion request is success.");
                this.outParams.Add("Output", (object)empty);
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                e.Result = (object)1064L;
            }
            finally
            {
                CLogs.NewLine();
                CLogs.NewLine();
                Sessions.Unlock((string)obj1);
            }
        }

        public void StartTask_ExecSimLockFunction(
          string sessionId,
          string deviceId,
          int funcType,
          string unlockCode,
          string simpersoFilename,
          string simpersoFileContent)
        {
            this.worker.DoWork += new DoWorkEventHandler(this.DoWork_ExecSimLockFunction);
            this.taskParams = new Dictionary<string, object>();
            this.taskParams.Add("SessionId", (object)sessionId);
            this.taskParams.Add("DeviceId", (object)deviceId);
            this.taskParams.Add("FuncType", (object)funcType);
            this.taskParams.Add("UnlockCode", (object)unlockCode);
            this.taskParams.Add("SimpersoFilename", (object)simpersoFilename);
            this.taskParams.Add("SimpersoFileContent", (object)simpersoFileContent);
            this.worker.RunWorkerAsync((object)this.taskParams);
        }

        private void DoWork_ExecSimLockFunction(object sender, DoWorkEventArgs e)
        {
            int simLockStatus = -1;
            Dictionary<string, object> dictionary = e.Argument as Dictionary<string, object>;
            object obj1;
            dictionary.TryGetValue("SessionId", out obj1);
            object obj2;
            dictionary.TryGetValue("DeviceId", out obj2);
            object obj3;
            dictionary.TryGetValue("FuncType", out obj3);
            object obj4;
            dictionary.TryGetValue("UnlockCode", out obj4);
            object obj5;
            dictionary.TryGetValue("SimpersoFilename", out obj5);
            object obj6;
            dictionary.TryGetValue("SimpersoFileContent", out obj6);
            Sessions.Lock((string)obj1, 20000);
            try
            {
                CLogs.B("Start ExecSimLockFunction request.");
                this.outParams["SessionId"] = obj1;
                this.outParams["FuncType"] = obj3;
                this.outParams["SimLockStatus"] = (object)simLockStatus.ToString();
                e.Result = (object)(long)DispatchTask.ExecSimLockFunction((string)obj1, (string)obj2, (int)obj3, (string)obj4, (string)obj5, (string)obj6, ref simLockStatus);
                if ((long)e.Result == 0L)
                    CLogs.I("ExecSimLockFunction request is success.");
                this.outParams["SimLockStatus"] = (object)simLockStatus.ToString();
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                e.Result = (object)1064L;
            }
            finally
            {
                CLogs.NewLine();
                CLogs.NewLine();
                Sessions.Unlock((string)obj1);
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.taskCompletedDelegate == null)
                    return;
                object obj;
                if (!this.outParams.TryGetValue("SessionId", out obj) && this.taskParams.TryGetValue("SessionId", out obj) && obj != null)
                    this.outParams.Add("SessionId", obj);
                this.taskCompletedDelegate((long)e.Result, this.outParams);
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
            }
        }

        private int ExecFtmApiFuncion(
          string sessionId,
          string devinceId,
          int funcType,
          string input,
          ref string output)
        {
            StringBuilder output1 = new StringBuilder(1024);
            int num = DispatchTask.ExecFtmApiFuncion(sessionId, devinceId, funcType, input, output1, 1024);
            output = output1.ToString();
            return num;
        }

        [DllImport("MobileFlashDll.dll")]
        private static extern int SwitchPhoneDataEditMode(string sessionId, string deviceId);

        [DllImport("MobileFlashDll.dll")]
        private static extern int ExecSimLockFunction(
          string sessionId,
          string deviceId,
          int funcType,
          string unlockCode,
          string simpersoFilename,
          string simpersoFileContent,
          ref int simLockStatus);

        [DllImport("MobileFlashDll.dll")]
        private static extern int ExecFtmApiFuncion(
          string sessionId,
          string deviceId,
          int funcType,
          string input,
          StringBuilder output,
          int outputsize);

        public delegate void OnTaskCompletedDelegate(long result, Dictionary<string, object> outParams);
    }
}
