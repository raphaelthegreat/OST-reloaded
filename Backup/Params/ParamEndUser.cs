// Decompiled with JetBrains decompiler
// Type: Params.ParamEndUser
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Params
{
  internal class ParamEndUser : ToolParam
  {
    public ParamEndUser() => this.optionFilter = new OptionFilter(false, false, true, true, true, false, false, true, true, true, (ToolParam) this);

    public override void EnableBackupOption()
    {
    }
  }
}
