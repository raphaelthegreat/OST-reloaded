// Decompiled with JetBrains decompiler
// Type: Utils.CLogs
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Utils
{
  internal class CLogs
  {
    private static CLogs instance;

    private CLogs(string appName, string logPath)
    {
      CLogs.SetLogAppName(appName);
      CLogs.SetLogFolderPath(Path.GetDirectoryName(logPath));
      CLogs.CreateLogFile(Path.GetFileName(logPath));
    }

    public static void CreateInstance(string appName, string logPath)
    {
      if (CLogs.instance == null)
        CLogs.instance = new CLogs(appName, logPath);
      double num = (double) CLogs.GetAvailableFreeSpace_Disk_C() / 1024.0 / 1024.0;
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage("--------------------------------------------------");
      CLogs.LogMessage(string.Format("User privilege: {0}", (object) CLogs.getUserPrivilege()));
      CLogs.LogMessage(string.Format("Available free space of C for the user: {0} MB", (object) string.Format("{0:N2}", (object) num)));
    }

    public static void W(string format, params object[] args)
    {
      string str = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      CLogs.LogWarning(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
    }

    public static void E(string format, params object[] args)
    {
      string str = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      CLogs.LogError(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
    }

    [Conditional("LOG_DEBUG")]
    public static void D(string format, params object[] args)
    {
      string str = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
    }

    public static void I(string format, params object[] args)
    {
      string str = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
    }

    public static void I_encrypted(string format, params object[] args)
    {
      string str = RsaCrypt.EncryptLog(args.Length == 0 ? format : string.Format(format, args));
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
    }

    public static void B(string format, params object[] args)
    {
      string message = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage("--------------------------------------------------");
      CLogs.LogMessage(message);
    }

    public static void Broadcast(string format, params object[] args)
    {
      string str = args.Length == 0 ? format : string.Format(format, args);
      if (CLogs.instance == null)
        return;
      try
      {
        CLogs.LogBroadcast(string.Format("{0} ({1})", (object) str, (object) CLogs.WhoCalledMe()));
      }
      catch (SEHException ex)
      {
        CLogs.LogMessage("(LogBroadcast() threw SEHException and it was not handled.\n" + ex.Message.ToString());
      }
      catch (Exception ex)
      {
        CLogs.LogMessage("(LogBroadcast() threw a unknown exception and it was not handled.\n" + ex.Message.ToString());
      }
    }

    public static void NewLine()
    {
      if (CLogs.instance == null)
        return;
      CLogs.LogMessage("");
    }

    private static string WhoCalledMe()
    {
      MethodBase method = new StackTrace().GetFrame(2).GetMethod();
      return string.Format("{0}.{1}", (object) method.DeclaringType.Name, (object) method.Name);
    }

    private static string getUserPrivilege()
    {
      string str = "";
      using (WindowsIdentity current = WindowsIdentity.GetCurrent())
      {
        WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
        str = !windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.User) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.AccountOperator) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.BackupOperator) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.Guest) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.PowerUser) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.PrintOperator) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.Replicator) ? (!windowsPrincipal.IsInRole(WindowsBuiltInRole.SystemOperator) ? "Unknown" : "SystemOperator") : "Replicator") : "PrintOperator") : "PowerUser") : "Guest") : "BackupOperator") : "AccountOperator") : "User") : "Administrator";
      }
      return str;
    }

    private static long GetAvailableFreeSpace_Disk_C()
    {
      foreach (DriveInfo drive in DriveInfo.GetDrives())
      {
        if (drive.IsReady && drive.Name.Contains("C:"))
          return drive.TotalFreeSpace;
      }
      return 0;
    }

    [DllImport("DataLogDll.dll")]
    private static extern void SetLogAppName(string appName);

    [DllImport("DataLogDll.dll")]
    private static extern void SetLogFolderPath(string folderPath);

    [DllImport("DataLogDll.dll")]
    private static extern bool CreateLogFile(string fileName);

    [DllImport("DataLogDll.dll")]
    private static extern void LogMessage(string message);

    [DllImport("DataLogDll.dll")]
    private static extern void LogWarning(string message);

    [DllImport("DataLogDll.dll")]
    private static extern void LogError(string message);

    [DllImport("DataLogDll.dll")]
    private static extern void LogBroadcast(string message);
  }
}
