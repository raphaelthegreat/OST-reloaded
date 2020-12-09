// Decompiled with JetBrains decompiler
// Type: MyResources.LoginService.ReturnEntryOfString
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MyResources.LoginService
{
  [DesignerCategory("code")]
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [XmlType(Namespace = "http://fihtdc.com/")]
  [DebuggerStepThrough]
  [Serializable]
  public class ReturnEntryOfString : ReturnEntry
  {
    private string valueField;

    public string Value
    {
      get => this.valueField;
      set => this.valueField = value;
    }
  }
}
