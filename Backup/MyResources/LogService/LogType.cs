// Decompiled with JetBrains decompiler
// Type: MyResources.LogService.LogType
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MyResources.LogService
{
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [XmlType(Namespace = "http://fihtdc.com/")]
  [Serializable]
  public enum LogType
  {
    OTA,
    Feedback,
    UserInfo,
    OTACheck,
    UserDevice,
    UnlockBoot,
    App,
    DMC,
  }
}
