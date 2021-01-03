// Decompiled with JetBrains decompiler
// Type: Utils.STSPermission
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Utils
{
    internal class STSPermission
    {
        private static bool ImeiWrite;
        private static bool MeidWrite;
        private static bool CustomizedFunction;

        public static void setPermissions(JArray permissionJArray)
        {
            STSPermission.resetAllAs(false);
            foreach (JToken jtoken in (IEnumerable<JToken>)permissionJArray)
            {
                string str = (string)jtoken;
                if (str == "ImeiWrite")
                    STSPermission.ImeiWrite = true;
                else if (str == "MeidWrite")
                    STSPermission.MeidWrite = true;
                else if (str == "CustomizedFunction")
                    STSPermission.CustomizedFunction = true;
            }
            STSPermission.setPermissionsInCpp(STSPermission.ImeiWrite, STSPermission.MeidWrite, STSPermission.CustomizedFunction);
        }

        public static bool isImeiWrite() => STSPermission.ImeiWrite;

        public static bool isMeidWrite() => STSPermission.MeidWrite;

        public static bool isCustomizedFunction() => STSPermission.CustomizedFunction;

        public static void resetAllAs(bool bool_value)
        {
            STSPermission.ImeiWrite = bool_value;
            STSPermission.MeidWrite = bool_value;
            STSPermission.CustomizedFunction = bool_value;
            STSPermission.setPermissionsInCpp(STSPermission.ImeiWrite, STSPermission.MeidWrite, STSPermission.CustomizedFunction);
        }

        [DllImport("MobileFlashDll.dll", EntryPoint = "setPermissions")]
        private static extern void setPermissionsInCpp(
          bool imei_write,
          bool meid_write,
          bool customized_function);
    }
}
