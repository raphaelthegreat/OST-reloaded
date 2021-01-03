// Decompiled with JetBrains decompiler
// Type: Utils.Profile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Runtime.InteropServices;
using System.Text;

namespace Utils
{
    internal class Profile
    {
        private string profile;

        public Profile(string profile) => this.profile = profile;

        public string ReadString(string section, string key) => this.ReadProfileString(section, key, "");

        public string ReadString(string section, string key, string defValue) => this.ReadProfileString(section, key, defValue);

        public bool WriteString(string section, string key, string text) => Profile.WritePrivateProfileString(section, key, text, this.profile);

        private string ReadProfileString(string section, string key, string defValue)
        {
            StringBuilder result = new StringBuilder(500);
            int privateProfileString = (int)Profile.GetPrivateProfileString(section, key, defValue, result, (uint)result.Capacity, this.profile);
            return result.ToString();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern uint GetPrivateProfileString(
          string section,
          string key,
          string defaultText,
          StringBuilder result,
          uint resultSize,
          string profile);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(
          string section,
          string key,
          string text,
          string profile);
    }
}
