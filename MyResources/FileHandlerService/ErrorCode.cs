// Decompiled with JetBrains decompiler
// Type: MyResources.FileHandlerService.ErrorCode
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MyResources.FileHandlerService
{
  [GeneratedCode("System.Xml", "2.0.50727.3654")]
  [XmlType(Namespace = "http://fihtdc.com/")]
  [Serializable]
  public enum ErrorCode
  {
    Success,
    UnknownFail,
    CheckAccountFail,
    WithoutLogin,
    GetServiceURLFail,
    GetAccessRightFail,
    GetImageDataFail,
    FileNotExist,
    AccessFileFail,
    BadParameter,
    DBCommandFail,
    NoDataMatch,
    NotPusher,
    NotListener,
    PushIDNotSupport,
    ClientTypeNotSupport,
    UpgradeFail,
    CreateAccountFail,
    AccountExist,
    ServiceNotExist,
    ServiceAlreadyRegistered,
    ServiceRegistrationFail,
    DataExist,
    NonActivated,
    WithoutGroupName,
    ConditionExist,
  }
}
