// Decompiled with JetBrains decompiler
// Type: MyResources.FileHandlerService.FileType
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MyResources.FileHandlerService
{
  [XmlType(Namespace = "http://fihtdc.com/")]
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [Serializable]
  public enum FileType
  {
    SWImage,
    SWUpdate,
    Temp,
    Theme,
    Wallpaper,
    App,
    PhotoSticker,
    PreloadApp,
    Feedback,
    SWNb0,
  }
}
