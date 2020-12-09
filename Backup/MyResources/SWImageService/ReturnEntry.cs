// Decompiled with JetBrains decompiler
// Type: MyResources.SWImageService.ReturnEntry
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MyResources.SWImageService
{
  [XmlInclude(typeof (ReturnEntryOfInt64))]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://fihtdc.com/")]
  [DebuggerStepThrough]
  [XmlInclude(typeof (ReturnEntryOfArrayOfDictionaryEntry))]
  [XmlInclude(typeof (ReturnEntryOfArrayOfArrayOfDictionaryEntry))]
  [XmlInclude(typeof (ReturnEntryOfString))]
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [Serializable]
  public class ReturnEntry
  {
    private ErrorCode statusField;

    public ErrorCode Status
    {
      get => this.statusField;
      set => this.statusField = value;
    }
  }
}
