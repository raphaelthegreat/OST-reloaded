// Decompiled with JetBrains decompiler
// Type: UserForms.SKUId
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.InteropServices;

namespace UserForms
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 128)]
    public struct SKUId
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string skuId;
    }
}
