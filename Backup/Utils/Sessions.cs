// Decompiled with JetBrains decompiler
// Type: Utils.Sessions
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Utils
{
  internal class Sessions
  {
    private static bool started;

    public static void Start()
    {
      if (Sessions.started)
        return;
      Sessions.started = true;
      Sessions.BeginSessions();
    }

    public static void Stop()
    {
      Sessions.started = false;
      Sessions.EndSessions();
    }

    public static void Restart()
    {
      Sessions.Stop();
      Sessions.Start();
    }

    public static bool Lock(string sessionId) => Sessions.started && Sessions.LockSession(sessionId);

    public static bool Lock(string sessionId, int timeout)
    {
      TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
      while (!Sessions.Lock(sessionId))
      {
        Thread.Sleep(100);
        if ((new TimeSpan(DateTime.Now.Ticks) - timeSpan).TotalMilliseconds >= (double) timeout)
          return false;
      }
      return true;
    }

    public static void Unlock(string sessionId)
    {
      if (!Sessions.started)
        return;
      Sessions.UnlockSession(sessionId);
    }

    public static bool AddChildThread(string sessionId) => Sessions.started && Sessions.AddChildSession(sessionId);

    public static void RemoveChildThread(string sessionId)
    {
      if (!Sessions.started)
        return;
      Sessions.RemoveChildSession(sessionId);
    }

    [DllImport("MobileFlashDll.dll")]
    private static extern void BeginSessions();

    [DllImport("MobileFlashDll.dll")]
    private static extern void EndSessions();

    [DllImport("MobileFlashDll.dll")]
    private static extern bool LockSession(string sessionId);

    [DllImport("MobileFlashDll.dll")]
    private static extern void UnlockSession(string sessionId);

    [DllImport("MobileFlashDll.dll")]
    private static extern bool AddChildSession(string sessionId);

    [DllImport("MobileFlashDll.dll")]
    private static extern void RemoveChildSession(string sessionId);
  }
}
