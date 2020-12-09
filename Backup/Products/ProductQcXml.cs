// Decompiled with JetBrains decompiler
// Type: Products.ProductQcXml
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Products
{
  internal class ProductQcXml : Product
  {
    public override long StartUpdate(
      string sessionId,
      string imagePath,
      string deviceId,
      int option)
    {
      ++this.runCount;
      return (long) Product.RestoreSettings(sessionId, deviceId, 0U);
    }

    public override bool HasUserOption(ProductOptions option) => false;
  }
}
