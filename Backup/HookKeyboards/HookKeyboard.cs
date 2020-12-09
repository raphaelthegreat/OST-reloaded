// Decompiled with JetBrains decompiler
// Type: HookKeyboards.HookKeyboard
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookKeyboards
{
  internal class HookKeyboard
  {
    private static IntPtr handle = IntPtr.Zero;
    private static HookKeyboard.LowLevelKeyboardProc keyboardProc = (HookKeyboard.LowLevelKeyboardProc) null;
    private static Control[] exceptControls = (Control[]) null;

    public static void EnableHookKeysToChangeTabPages(Control[] controls)
    {
      HookKeyboard.exceptControls = controls;
      HookKeyboard.keyboardProc = new HookKeyboard.LowLevelKeyboardProc(HookKeyboard.CaptureKey);
      HookKeyboard.handle = HookKeyboard.SetWindowsHookEx(13, HookKeyboard.keyboardProc, HookKeyboard.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0U);
    }

    public static void DisableHookKeys()
    {
      IntPtr handle = HookKeyboard.handle;
      HookKeyboard.UnhookWindowsHookEx(HookKeyboard.handle);
    }

    private static IntPtr CaptureKey(int code, IntPtr wp, IntPtr lp)
    {
      if (code >= 0 && HookKeyboard.GetFocus() != IntPtr.Zero && !HookKeyboard.MatchExceptionControls())
      {
        HookKeyboard.KBDLLHOOKSTRUCT structure = (HookKeyboard.KBDLLHOOKSTRUCT) Marshal.PtrToStructure(lp, typeof (HookKeyboard.KBDLLHOOKSTRUCT));
        if (structure.key == Keys.Left || structure.key == Keys.Right || (structure.key == Keys.Next || structure.key == Keys.Prior))
          return (IntPtr) 1;
      }
      return HookKeyboard.CallNextHookEx(HookKeyboard.handle, code, wp, lp);
    }

    private static bool MatchExceptionControls()
    {
      foreach (Control exceptControl in HookKeyboard.exceptControls)
      {
        if (exceptControl.Focused)
          return true;
      }
      return false;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(
      int id,
      HookKeyboard.LowLevelKeyboardProc callback,
      IntPtr module,
      uint threadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool UnhookWindowsHookEx(IntPtr hook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wp, IntPtr lp);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string name);

    [DllImport("user32.dll")]
    private static extern IntPtr GetFocus();

    private struct KBDLLHOOKSTRUCT
    {
      public Keys key;
      public int scanCode;
      public int flags;
      public int time;
      public IntPtr extra;
    }

    private delegate IntPtr LowLevelKeyboardProc(int code, IntPtr wp, IntPtr lp);
  }
}
