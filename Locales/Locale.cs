// Decompiled with JetBrains decompiler
// Type: Locales.Locale
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Microsoft.Win32;
using System;
using System.Globalization;
using Utils;

namespace Locales
{
    internal class Locale
    {
        private static Locale instance;
        private string regionName;
        private Profile profile;

        protected Locale(string regionName, string localeFile)
        {
            this.regionName = regionName;
            this.profile = new Profile(localeFile);
        }

        public static Locale Instance
        {
            get
            {
                if (Locale.instance == null)
                    Locale.instance = Locale.CreateLocale();
                return Locale.instance;
            }
        }

        private static Locale CreateLocale()
        {
            string firstFile = PathEx.ReverseFindFirstFile(PathEx.GetModulePath(), "*.locale", 2);
            return !string.IsNullOrEmpty(firstFile) ? new Locale(Locale.GetRegionName(), firstFile) : (Locale)new LocaleNull();
        }

        public virtual string LoadText(string localeId)
        {
            string str = this.LoadText(localeId, this.regionName);
            return str.Equals(localeId) ? this.LoadText(localeId, "en") : str;
        }

        public virtual string LoadCombinedText(string localeId)
        {
            string[] strArray = localeId.Split(';');
            string str1 = "";
            string str2 = Environment.NewLine + Environment.NewLine;
            foreach (string localeId1 in strArray)
                str1 = str1 + this.LoadText(localeId1) + str2;
            return str1.TrimEnd(str2.ToCharArray());
        }

        public virtual string LoadCombinedTextWithCatalogue(string localeId)
        {
            string[] strArray = localeId.Split(';');
            string str1 = "";
            string str2 = Environment.NewLine + Environment.NewLine;
            int num = 1;
            foreach (string localeId1 in strArray)
            {
                string str3 = this.LoadText(localeId1);
                if (!string.IsNullOrEmpty(str3))
                    str1 += string.Format("{0}. {1}{2}", (object)num++, (object)str3, (object)str2);
            }
            return str1.TrimEnd(str2.ToCharArray());
        }

        private string LoadText(string localeId, string regionName) => this.profile.ReadString(regionName, localeId, localeId);

        private static string GetRegionName()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\International");
            if (registryKey != null)
            {
                string s = registryKey.GetValue(nameof(Locale), (object)"") as string;
                if (!string.IsNullOrEmpty(s))
                {
                    CultureInfo cultureInfo = new CultureInfo(int.Parse(s, NumberStyles.AllowHexSpecifier));
                    if (cultureInfo != null)
                    {
                        string lower = cultureInfo.Name.ToLower();
                        if (lower.Equals("zh-cn"))
                            return "zh-cn";
                        string[] strArray = lower.Split('-');
                        return strArray.Length <= 0 ? "" : strArray[0];
                    }
                }
                registryKey.Close();
            }
            return "";
        }
    }
}
