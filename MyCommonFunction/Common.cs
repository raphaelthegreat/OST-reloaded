// Decompiled with JetBrains decompiler
// Type: MyCommonFunction.Common
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using Utils;

namespace MyCommonFunction
{
    internal class Common
    {
        public static bool HasCommandLineArgs(string tag)
        {
            foreach (string commandLineArg in Environment.GetCommandLineArgs())
            {
                if (commandLineArg.Equals(tag))
                    return true;
            }
            return false;
        }

        public static string GetCommandLineArgs(string tag)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            for (int index = 0; index < commandLineArgs.Length; ++index)
            {
                if (commandLineArgs[index].Equals(tag) && index < commandLineArgs.Length - 1)
                    return commandLineArgs[index + 1];
            }
            return string.Empty;
        }

        public static bool LaunchConsole(string path, string arguments, ref string msgout)
        {
            CLogs.I("Launch console \"{0}\"...", (object)path);
            bool flag = true;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (!File.Exists(path))
            {
                flag = false;
                CLogs.E("The console path not found: {0}", (object)path);
            }
            if (flag)
            {
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = Path.GetDirectoryName(path);
                startInfo.FileName = path;
                startInfo.Arguments = arguments;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                startInfo.Verb = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator) ? "open" : "runas";
            }
            Process process = new Process();
            if (flag)
                process = Process.Start(startInfo);
            if (flag)
                msgout = process.StandardOutput.ReadToEnd();
            if (flag)
                process.WaitForExit();
            if (flag)
                CLogs.I("Console message: " + msgout);
            if (flag)
            {
                flag = process.ExitCode == 0;
                CLogs.I("Console exit code: 0x{0:X}", (object)process.ExitCode);
            }
            CLogs.I("Console result: {0}", flag ? (object)"Pass" : (object)"Fail");
            return flag;
        }

        public static void KillProcess(string processName)
        {
            CLogs.I("Kill process: {0}", (object)processName);
            try
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                    process.Kill();
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
            }
        }
    }
}
