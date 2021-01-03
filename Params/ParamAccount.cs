// Decompiled with JetBrains decompiler
// Type: Params.ParamAccount
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Params
{
    internal class ParamAccount : ToolParam
    {
        public ParamAccount() => this.optionFilter = new OptionFilter(true, false, true, true, true, true, true, true, true, true, (ToolParam)this);

        public override bool UpdateCounter => true;
    }
}
