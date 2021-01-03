// Decompiled with JetBrains decompiler
// Type: Utils.Md5Ex
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.IO;
using System.Security.Cryptography;

namespace Utils
{
    public class Md5Ex
    {
        public string ComputeFileHash(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash((Stream)fileStream)).Replace("-", "");
        }
    }
}
