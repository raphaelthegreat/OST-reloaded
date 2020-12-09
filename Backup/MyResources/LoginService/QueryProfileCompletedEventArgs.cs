// Decompiled with JetBrains decompiler
// Type: MyResources.LoginService.QueryProfileCompletedEventArgs
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace MyResources.LoginService
{
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  public class QueryProfileCompletedEventArgs : AsyncCompletedEventArgs
  {
    private object[] results;

    internal QueryProfileCompletedEventArgs(
      object[] results,
      Exception exception,
      bool cancelled,
      object userState)
      : base(exception, cancelled, userState)
    {
      this.results = results;
    }

    public ReturnEntryOfArrayOfDictionaryEntry Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (ReturnEntryOfArrayOfDictionaryEntry) this.results[0];
      }
    }
  }
}
