// Decompiled with JetBrains decompiler
// Type: Products.ProductFastboot
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Products
{
    internal class ProductFastboot : Product
    {
        public override long StartUpdate(
          string sessionId,
          string imagePath,
          string deviceId,
          int option)
        {
            ++this.runCount;
            return (long)Product.UpdateSoftware(sessionId, deviceId, this.GetUserOptions(option));
        }

        public override bool HasUserOption(ProductOptions option) => option == ProductOptions.NONE || option == ProductOptions.ERASE_USER_DATA && this.HasEraseUserDataOption && this.toolParam.Option.EraseUserData || (option == ProductOptions.UNLOCK_SCREEN_LOCK && this.toolParam.Option.UnlockScreenLock || option == ProductOptions.COLLECT_APR_LOG && this.toolParam.Option.CollectAprLog);
    }
}
