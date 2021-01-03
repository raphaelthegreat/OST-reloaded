// Decompiled with JetBrains decompiler
// Type: Products.ProductQ6
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Collections.Specialized;

namespace Products
{
    internal class ProductQ6 : ProductFastboot
    {
        public override long StartUpdate(
          string sessionId,
          string imagePath,
          string deviceId,
          int option)
        {
            ++this.runCount;
            return (long)Product.EmergencyUpdateSoftware(sessionId, this.GetUserOptions(option));
        }

        public override bool HasUserOption(ProductOptions option) => option == ProductOptions.NATIVE_UPDATE_PROCESS && this.toolParam.Option.NativeUpdate || option == ProductOptions.NATIVE_ERASE_UPDATE_PROCESS && this.toolParam.Option.EraseUserData && this.toolParam.Option.NativeUpdate || (option == ProductOptions.UNLOCK_SCREEN_LOCK && this.toolParam.Option.UnlockScreenLock || option == ProductOptions.COLLECT_APR_LOG && this.toolParam.Option.CollectAprLog);

        public override uint GetUserOptions(int option)
        {
            BitVector32 bitVector32 = new BitVector32(0);
            int mask = BitVector32.CreateMask();
            bitVector32[mask] = this.IsDownloadOption(option, ProductOptions.NATIVE_ERASE_UPDATE_PROCESS);
            return (uint)bitVector32.Data;
        }
    }
}
