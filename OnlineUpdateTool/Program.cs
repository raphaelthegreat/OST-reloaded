// Decompiled with JetBrains decompiler
// Type: OnlineUpdateTool.Program
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Deployment.DeployCaches;
using MainForms;
using MyCommonFunction;
using MyResources.Properties;
using Params;
using System;
using System.Windows.Forms;
using UserForms;
using Utils;

namespace OnlineUpdateTool
{
  internal static class Program
  {
    private static MutexLock deployMutex = new MutexLock("Tool Deploy Program");
    private static MutexLock programMutex = new MutexLock(Settings.Default.DisplayName + " Program");

    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Control.CheckForIllegalCrossThreadCalls = false;
      if (Program.programMutex.OpenExisting())
        return;
      ToolParam.Instance.Initialization();
      Sessions.Start();
      try
      {
        if (!Program.programMutex.Create(true))
          CLogs.E(string.Format("Create program mutex '{0}' fails", (object) Program.programMutex.Name));
        else if (Program.deployMutex.OpenExisting() && !Program.deployMutex.WaitExit(5000))
        {
          CLogs.W(string.Format("Wait deploy mutex '{0}' fails during 5 seconds", (object) Program.deployMutex.Name));
        }
        else
        {
          DeployCache instance = DeployCache.Instance;
          if (!Program.IsLaunchedFromDeployer && instance.IsDownloaded)
          {
            if (instance.IsDeployRequired)
            {
              CLogs.I("Launch deployer and exit itself.");
              Launcher.LaunchProcess(instance.DeploymentPath);
              return;
            }
            instance.ClearCacheFiles();
          }
          if (OtaParam.Instance.UserLoginRequired && !UserInterAction.DoLoginRequest())
            return;
          Form1 form1 = new Form1();
          form1.SetCommToken(OtaParam.Instance.Account.CommToken);
          Application.Run((Form) form1.EnableDataCollection());
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        Program.programMutex.Release();
      }
    }

    private static bool IsLaunchedFromDeployer
    {
      get
      {
        string commandLineArgs = Common.GetCommandLineArgs("-launch");
        return !string.IsNullOrEmpty(commandLineArgs) && commandLineArgs.Equals("deployer");
      }
    }
  }
}
