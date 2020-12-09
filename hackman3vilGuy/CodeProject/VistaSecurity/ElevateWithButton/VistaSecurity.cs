// Decompiled with JetBrains decompiler
// Type: hackman3vilGuy.CodeProject.VistaSecurity.ElevateWithButton.VistaSecurity
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace hackman3vilGuy.CodeProject.VistaSecurity.ElevateWithButton
{
  public static class VistaSecurity
  {
    internal static bool IsAdmin() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

    internal static void RestartElevated()
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.UseShellExecute = true;
      startInfo.WorkingDirectory = Environment.CurrentDirectory;
      startInfo.FileName = Application.ExecutablePath;
      startInfo.Verb = "runas";
      try
      {
        Process.Start(startInfo);
        Application.Exit();
      }
      catch (Exception ex)
      {
      }
    }
  }
}
