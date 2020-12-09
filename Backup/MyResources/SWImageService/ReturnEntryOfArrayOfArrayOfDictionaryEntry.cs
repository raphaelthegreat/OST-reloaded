// Decompiled with JetBrains decompiler
// Type: MyResources.SWImageService.ReturnEntryOfArrayOfArrayOfDictionaryEntry
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
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [XmlType(Namespace = "http://fihtdc.com/")]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [Serializable]
  public class ReturnEntryOfArrayOfArrayOfDictionaryEntry : ReturnEntry
  {
    private DictionaryEntry[][] valueField;

    [XmlArrayItem("ArrayOfDictionaryEntry")]
    [XmlArrayItem(IsNullable = false, NestingLevel = 1)]
    public DictionaryEntry[][] Value
    {
      get => this.valueField;
      set => this.valueField = value;
    }
  }
}
