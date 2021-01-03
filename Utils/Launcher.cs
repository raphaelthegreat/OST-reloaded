// Decompiled with JetBrains decompiler
// Type: Utils.Launcher
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace Utils
{
    internal class Launcher
    {
        public static void LaunchProcess(string path) => Launcher.LaunchProcess(path, string.Empty);

        public static void LaunchProcess(string path, string arguments) => Process.Start(new ProcessStartInfo()
        {
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(path),
            FileName = path,
            Arguments = arguments,
            Verb = Launcher.IsAdmin() ? "open" : "runas"
        });

        private static bool IsAdmin() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}
