// Decompiled with JetBrains decompiler
// Type: Params.OtaParamRD
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using System.Collections.Generic;

namespace Params
{
  internal class OtaParamRD : OtaParam
  {
    public OtaParamRD()
    {
      string group = "@LR";
      this.account = new OtaAccount(new OtaData().Set("OGP", group).Set("SGP", group).Set("EL", "N"), group, new List<OtaData>()
      {
        new OtaData().Set("FileHandler", "http://tpe-ota.fihtdc.com/weekly/filehandler.asmx").Set("Login", "http://tpe-ota.fihtdc.com/weekly/login.asmx").Set("SWImage", "http://tpe-ota.fihtdc.com/weekly/swimage.asmx")
      });
    }

    public override bool UserLoginRequired => false;

    public override string LoginUrl => string.Empty;
  }
}
