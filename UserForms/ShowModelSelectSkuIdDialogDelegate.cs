// Decompiled with JetBrains decompiler
// Type: UserForms.ShowModelSelectSkuIdDialogDelegate
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace UserForms
{
    public delegate bool ShowModelSelectSkuIdDialogDelegate(
    string sessionId,
    string information,
    string defaultSKUID,
    out int choiceId,
    ref SKUId skuId);
}
