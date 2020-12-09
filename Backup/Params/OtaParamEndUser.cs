// Decompiled with JetBrains decompiler
// Type: Params.OtaParamEndUser
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;

namespace Params
{
  internal class OtaParamEndUser : OtaParam
  {
    public OtaParamEndUser() => this.account = new OtaAccount();

    public override int MaxCacheImages => 1;

    public override bool UserLoginRequired => true;

    public override string LoginUrl => "http://tpe-ota.fihtdc.com/login.asmx";
  }
}
