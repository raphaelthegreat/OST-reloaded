// Decompiled with JetBrains decompiler
// Type: Utils.UserPermissionGroup
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Utils
{
    public enum UserPermissionGroup
    {
        NONE = -1, // 0xFFFFFFFF
        FLASH_OPTION = 0,
        FORCE_OPTION = 1,
        USER_IMG_SWITCH = 2,
        PHONE_KEY_INFO = 3,
        RD_SIM_LOCK = 4,
        NOKIA_SIM_LOCK_SWAP = 5,
        ONLINE_REWRITE_IMEI_VIA_GEMS = 6,
        USER_STS_LICENSE = 7,
        EVW_UNLOCKING_OPTION = 8,
    }
}
