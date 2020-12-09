// Decompiled with JetBrains decompiler
// Type: Utils.OstOption
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Products;
using System.Collections.Generic;

namespace Utils
{
  internal class OstOption
  {
    private static Dictionary<string, Permission> m_OstOptionDic = new Dictionary<string, Permission>();

    private static Dictionary<string, UserPermissionGroup> mUserPermissionGroupMapping => new Dictionary<string, UserPermissionGroup>()
    {
      {
        "NormalDownload",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "EmergencyDownload",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "ClearUserData",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "EraseBoxData",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "SwitchSkuid",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "UfsProvision",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "EraseFrp",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "UnlockScreenLock",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "BackupNv",
        UserPermissionGroup.FLASH_OPTION
      },
      {
        "ImeiRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "ImeiWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "MeidRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "MeidWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "WifiAddrRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "WifiAddrWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "BtAddrRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "BtAddrWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "PsnRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "PsnWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "WallpaperIDRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "WallpaperIDWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "BatteryInfoRead",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "BatteryInfoWrite",
        UserPermissionGroup.PHONE_KEY_INFO
      },
      {
        "AllowDiffProject",
        UserPermissionGroup.USER_IMG_SWITCH
      },
      {
        "AllowDiffSwModel",
        UserPermissionGroup.USER_IMG_SWITCH
      },
      {
        "AllowDiffChannel",
        UserPermissionGroup.USER_IMG_SWITCH
      },
      {
        "SimLock",
        UserPermissionGroup.RD_SIM_LOCK
      },
      {
        "SimUnlock",
        UserPermissionGroup.RD_SIM_LOCK
      },
      {
        "NokiaSimLockSwap",
        UserPermissionGroup.NOKIA_SIM_LOCK_SWAP
      },
      {
        "OnlineImeiResetViaGems",
        UserPermissionGroup.ONLINE_REWRITE_IMEI_VIA_GEMS
      }
    };

    public static void ResetOptions()
    {
      OstOption.m_OstOptionDic.Clear();
      foreach (string key in OstOption.mUserPermissionGroupMapping.Keys)
        OstOption.m_OstOptionDic.Add(key, new Permission(OstOption.mUserPermissionGroupMapping[key], false));
    }

    public static void EnableAllOptions()
    {
      OstOption.m_OstOptionDic.Clear();
      foreach (string key in OstOption.mUserPermissionGroupMapping.Keys)
      {
        if (OstOption.mUserPermissionGroupMapping[key] != UserPermissionGroup.FORCE_OPTION && OstOption.mUserPermissionGroupMapping[key] != UserPermissionGroup.EVW_UNLOCKING_OPTION)
          OstOption.m_OstOptionDic.Add(key, new Permission(OstOption.mUserPermissionGroupMapping[key], true));
      }
    }

    public static void SetOptionList(Dictionary<string, bool> optionDic)
    {
      foreach (string key in optionDic.Keys)
      {
        if (OstOption.m_OstOptionDic[key] == null)
          CLogs.E("Error the permission key is not in the permission list: {0}", (object) key);
        else
          OstOption.m_OstOptionDic[key].Enable = optionDic[key];
      }
    }

    public static void SetOption(string key, bool value)
    {
      if (!OstOption.m_OstOptionDic.ContainsKey(key))
        CLogs.E("Error the permission key is not in the permission list: {0}", (object) key);
      else
        OstOption.m_OstOptionDic[key].Enable = value;
    }

    public static bool HasOption(string option) => OstOption.m_OstOptionDic.ContainsKey(option) && OstOption.m_OstOptionDic[option].Enable;

    public static bool HasPhoneInfoOptionGroupBasic()
    {
      if (Product.sharedProduct != null && Product.sharedProduct.ImgSecurityVersion >= 8U && !STSLicense.isEnableRoot())
        return false;
      foreach (string key in OstOption.m_OstOptionDic.Keys)
      {
        if (OstOption.m_OstOptionDic[key].Group == UserPermissionGroup.PHONE_KEY_INFO && OstOption.m_OstOptionDic[key].Enable)
          return true;
      }
      return false;
    }

    public static bool HasPhoneInfoOptionGroupSimLock()
    {
      //if (Product.sharedProduct.ImgSecurityVersion >= 8U && !STSLicense.isEnableRoot())
       // return false;
      foreach (string key in OstOption.m_OstOptionDic.Keys)
      {
        if (OstOption.m_OstOptionDic[key].Group == UserPermissionGroup.RD_SIM_LOCK && OstOption.m_OstOptionDic[key].Enable)
          return true;
      }
      return false;
    }

    public static bool HasPhoneInfoOptionGroupNokiaSimSwap() => false;

    public static bool hasPhoneInfoOptionGroupImeiReset()
    {
      if (!STSLicense.isEnableRoot() || !STSLicense.isRewriteIMEI())
        return false;
      foreach (string key in OstOption.m_OstOptionDic.Keys)
      {
        if (OstOption.m_OstOptionDic[key].Group == UserPermissionGroup.ONLINE_REWRITE_IMEI_VIA_GEMS && OstOption.m_OstOptionDic[key].Enable)
          return true;
      }
      return false;
    }

    public static bool HasPhoneInfoOption() => OstOption.HasPhoneInfoOptionGroupBasic() || OstOption.HasPhoneInfoOptionGroupSimLock() || (OstOption.HasPhoneInfoOptionGroupNokiaSimSwap() || OstOption.hasPhoneInfoOptionGroupImeiReset());

    public static uint GetUserImgSwitchPermission()
    {
      if (!STSLicense.isEnableRoot())
        return 0;
      uint num1 = OstOption.HasOption("AllowDiffProject") ? 1U : 0U;
      uint num2 = OstOption.HasOption("AllowDiffChannel") ? 2U : 0U;
      uint num3 = OstOption.HasOption("AllowDiffSwModel") ? 4U : 0U;
      return num1 + num3 + num2;
    }

    public static void removeRevokedOption()
    {
      if (!OstOption.m_OstOptionDic.ContainsKey("UnlockScreenLock"))
        return;
      OstOption.m_OstOptionDic.Remove("UnlockScreenLock");
    }
  }
}
