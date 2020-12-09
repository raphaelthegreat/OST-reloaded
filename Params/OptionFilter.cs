// Decompiled with JetBrains decompiler
// Type: Params.OptionFilter
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Specialized;
using System.Globalization;
using Utils;

namespace Params
{
  internal class OptionFilter
  {
    private bool backup;
    private bool eraseFlash;
    private bool eraseUserData;
    private bool nativeUpdate;
    private bool nativeFormatAndUpdate;
    private bool eraseBoxData;
    private bool eraseFrp;
    private bool unlockScreenLock;
    private bool collectAprLog;
    private bool switchCustomerSKUID;
    private bool doEraseUserData;
    private bool doSkipPidData;
    private bool doEmergecyDownload;
    private bool doEraseBoxData;
    private bool doSwitchCustomerSKUID;
    private bool doEraseFrp;
    private bool doCollectAprLog;

    public OptionFilter(
      bool backup,
      bool eraseFlash,
      bool eraseUserData,
      bool nativeUpdate,
      bool nativeFormatAndUpdate,
      bool eraseBoxData,
      bool switchCustomerSKUID,
      bool eraseFrp,
      bool unlokcScreenLock,
      bool collectAprLog,
      ToolParam toolParam)
    {
      this.backup = backup;
      this.eraseFlash = eraseFlash;
      this.eraseUserData = eraseUserData;
      this.nativeUpdate = nativeUpdate;
      this.nativeFormatAndUpdate = nativeFormatAndUpdate;
      this.eraseBoxData = eraseBoxData;
      this.switchCustomerSKUID = switchCustomerSKUID;
      this.eraseFrp = eraseFrp;
      this.unlockScreenLock = unlokcScreenLock;
      this.collectAprLog = collectAprLog;
      this.SetDoOptions(this.LoadDoOptions(toolParam.Config));
    }

    private int LoadDoOptions(Profile profile)
    {
      try
      {
        NumberStyles style = NumberStyles.Integer;
        string s = profile.ReadString("Option", "DoOption", "0");
        if (s.ToLower().StartsWith("0x"))
        {
          style = NumberStyles.HexNumber;
          s = s.Substring(2);
        }
        return int.Parse(s, style);
      }
      catch (Exception ex)
      {
      }
      return 0;
    }

    private void SetDoOptions(int value)
    {
      BitVector32 bitVector32 = new BitVector32(value);
      int mask1 = BitVector32.CreateMask();
      int mask2 = BitVector32.CreateMask(mask1);
      int mask3 = BitVector32.CreateMask(mask2);
      int mask4 = BitVector32.CreateMask(mask3);
      int mask5 = BitVector32.CreateMask(mask4);
      int mask6 = BitVector32.CreateMask(mask5);
      this.doEraseUserData = bitVector32[mask1];
      this.doSkipPidData = bitVector32[mask2];
      this.doEmergecyDownload = bitVector32[mask3];
      this.doEraseBoxData = bitVector32[mask4];
      this.doSwitchCustomerSKUID = bitVector32[mask5];
      this.doCollectAprLog = bitVector32[mask6];
    }

    public virtual bool Backup
    {
      set => this.backup = value;
      get => this.backup;
    }

    public virtual bool EraseFlash => this.eraseFlash;

    public virtual bool EraseUserData => this.eraseUserData;

    public virtual bool NativeUpdate => this.nativeUpdate;

    public virtual bool NativeFormatAndUpdate
    {
      set => this.nativeFormatAndUpdate = value;
      get => this.nativeFormatAndUpdate;
    }

    public virtual bool EraseBoxData => this.eraseBoxData;

    public virtual bool EraseFrp => this.eraseFrp;

    public virtual bool UnlockScreenLock => this.unlockScreenLock;

    public virtual bool CollectAprLog => this.collectAprLog;

    public virtual bool SwitchCustomerSKUID => this.switchCustomerSKUID;

    public virtual bool DoEraseUserData => this.doEraseUserData;

    public virtual bool DoSkipPidData => this.doSkipPidData;

    public virtual bool DoEmergecyDownload => this.doEmergecyDownload;

    public virtual bool DoEraseBoxData => this.doEraseBoxData;

    public virtual bool DoSwitchCustomerSKUID => this.doSwitchCustomerSKUID;

    public virtual bool DoEraseFrp => this.doEraseFrp;

    public virtual bool DoCollectAprLog => this.doCollectAprLog;
  }
}
