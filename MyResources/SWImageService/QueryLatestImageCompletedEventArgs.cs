// Decompiled with JetBrains decompiler
// Type: MyResources.SWImageService.QueryLatestImageCompletedEventArgs
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace MyResources.SWImageService
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  public class QueryLatestImageCompletedEventArgs : AsyncCompletedEventArgs
  {
    private object[] results;

    internal QueryLatestImageCompletedEventArgs(
      object[] results,
      Exception exception,
      bool cancelled,
      object userState)
      : base(exception, cancelled, userState)
    {
      this.results = results;
    }

    public ReturnEntryOfInt64 Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (ReturnEntryOfInt64) this.results[0];
      }
    }
  }
}
