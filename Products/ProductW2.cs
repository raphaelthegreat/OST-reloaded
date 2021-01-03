// Decompiled with JetBrains decompiler
// Type: Products.ProductW2
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Products
{
    internal class ProductW2 : ProductFastboot
    {
        public override long StartUpdate(
          string sessionId,
          string imagePath,
          string deviceId,
          int option)
        {
            ++this.runCount;
            return this.IsDownloadOption(option, ProductOptions.NATIVE_UPDATE_PROCESS) || this.toolParam.Option.DoEmergecyDownload ? (long)Product.EmergencyUpdateSoftware(sessionId, this.GetUserOptions(option)) : (long)Product.UpdateSoftware(sessionId, deviceId, this.GetUserOptions(option));
        }

        public override bool HasUserOption(ProductOptions option) => option == ProductOptions.NONE || option == ProductOptions.NATIVE_UPDATE_PROCESS && this.toolParam.Option.NativeUpdate || (option == ProductOptions.UNLOCK_SCREEN_LOCK && this.toolParam.Option.UnlockScreenLock || option == ProductOptions.COLLECT_APR_LOG && this.toolParam.Option.CollectAprLog);

        public override uint GetUserOptions(int option) => 0;
    }
}
