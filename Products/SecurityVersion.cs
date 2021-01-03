// Decompiled with JetBrains decompiler
// Type: Products.SecurityVersion
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Products
{
    internal enum SecurityVersion
    {
        NONE = 0,
        AUTH_SECURITY_V1 = 1,
        AUTH_HALF = 2,
        AUTH_SECURITY_V2 = 4,
        AUTH_SECURITY_V3 = 8,
        AUTH_REQUIRED_MASK = 13, // 0x0000000D
    }
}
