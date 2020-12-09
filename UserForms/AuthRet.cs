// Decompiled with JetBrains decompiler
// Type: UserForms.AuthRet
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.InteropServices;

namespace UserForms
{
  [Serializable]
  [StructLayout(LayoutKind.Sequential, Size = 128)]
  public struct AuthRet
  {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
    public byte[] bufSignature;
    [MarshalAs(UnmanagedType.I4)]
    public int bufSize;
  }
}
