// Decompiled with JetBrains decompiler
// Type: Utils.STSLicense
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Utils
{
  internal class STSLicense
  {
    private static bool EnableRoot;
    private static bool RewriteIMEI;

    public static void setLicenses(JArray licenseJasonArray)
    {
      STSLicense.resetAllAs(false);
      foreach (JToken licenseJason in (IEnumerable<JToken>) licenseJasonArray)
      {
        string str = (string) licenseJason;
        if (str == "EnableRoot")
          STSLicense.EnableRoot = true;
        else if (str == "RewriteIMEI")
          STSLicense.RewriteIMEI = true;
      }
      STSLicense.setLicensesInCpp(STSLicense.EnableRoot, STSLicense.RewriteIMEI);
    }

    public static bool isEnableRoot() => STSLicense.EnableRoot;

    public static bool isRewriteIMEI() => STSLicense.RewriteIMEI;

    public static void resetAllAs(bool bool_value)
    {
      STSLicense.EnableRoot = bool_value;
      STSLicense.RewriteIMEI = bool_value;
      STSLicense.setLicensesInCpp(STSLicense.EnableRoot, STSLicense.RewriteIMEI);
    }

    [DllImport("MobileFlashDll.dll", EntryPoint = "setLicenses")]
    private static extern void setLicensesInCpp(bool enableRoot, bool rewriteIMEI);
  }
}
