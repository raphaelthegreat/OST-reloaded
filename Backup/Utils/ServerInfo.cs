// Decompiled with JetBrains decompiler
// Type: Utils.ServerInfo
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json.Linq;
using Params;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UserConfigs;
using UserForms;

namespace Utils
{
  internal class ServerInfo
  {
    private static string mLoginToken = "";
    private static string mRequestId = Guid.NewGuid().ToString();
    private static string mSessionId = ServerInfo.newSessionId();
    private static string sServerIP = "sts.c2dms.com";
    private static string sServerPort = "";
    private static bool useSSL = true;

    private static string newSessionId()
    {
      string newId = Guid.NewGuid().ToString();
      ServerInfo.setSessionIdInCpp(newId);
      return newId;
    }

    public static void refreshSessionId() => ServerInfo.mSessionId = ServerInfo.newSessionId();

    [DllImport("MobileFlashDll.dll", EntryPoint = "setSessionId")]
    private static extern void setSessionIdInCpp(string newId);

    public static byte[] StrToByteArray(string str)
    {
      str = str.ToUpper();
      Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
      for (int index = 0; index <= (int) byte.MaxValue; ++index)
        dictionary.Add(index.ToString("X2"), (byte) index);
      List<byte> byteList = new List<byte>();
      for (int startIndex = 0; startIndex < str.Length; startIndex += 2)
        byteList.Add(dictionary[str.Substring(startIndex, 2)]);
      return byteList.ToArray();
    }

    private static string getServerUrl(ServerInfo.WEB_API requestOption)
    {
      string str1 = ServerInfo.useSSL ? "HTTPS" : "HTTP";
      string str2 = "";
      switch (requestOption)
      {
        case ServerInfo.WEB_API.CHECK_CONNECTION:
          str2 = "api/v1/Log/Ping";
          break;
        case ServerInfo.WEB_API.LOGIN:
          str2 = "api/v1/Auth/Login";
          break;
        case ServerInfo.WEB_API.GET_SIGNATURE:
          str2 = "api/v1/RsaCrypt/GetSignature";
          break;
        case ServerInfo.WEB_API.GET_PERMISSION:
          str2 = "api/v1/Auth/GetPermission";
          break;
        case ServerInfo.WEB_API.REPORT_SERVICE_RESULT:
          str2 = "api/v1/Log/ReportServiceResult";
          break;
        case ServerInfo.WEB_API.QUERY_SIM_UNLOCK_CODE:
          str2 = "api/v1/SimUnlock/GetUnlockCode";
          break;
        case ServerInfo.WEB_API.DEL_SIM_UNLOCK_CODE:
          str2 = "api/v1/SimUnlock/DisableUnlockCode";
          break;
      }
      string str3;
      if (ServerInfo.sServerPort.Length > 0)
        str3 = string.Format("{0}://{1}:{2}/{3}", (object) str1, (object) ServerInfo.sServerIP, (object) ServerInfo.sServerPort, (object) str2);
      else
        str3 = string.Format("{0}://{1}/{2}", (object) str1, (object) ServerInfo.sServerIP, (object) str2);
      return str3;
    }

    private static void dumpWebResponse(webResponseObject responseObj)
    {
      CLogs.I("[RESPONSE STATUS] " + responseObj.status);
      CLogs.I_encrypted("[RESPONSE MESSAGE] " + responseObj.message);
      if (responseObj.result == null)
        return;
      CLogs.I_encrypted("[RESPONSE RESULT COUNT] " + (object) responseObj.result.Count);
      foreach (string key in responseObj.result.Keys)
      {
        string str = string.Format("{0}", responseObj.result[key]);
        CLogs.I_encrypted("[RESPONSE RESULT] " + key + ": " + str);
      }
    }

    private static bool checkConnection()
    {
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.CHECK_CONNECTION);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("GET", serverUrl, "", (Dictionary<string, string>) null, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status != "Ok")
        flag = false;
      if (!flag)
      {
        int num = (int) MessageBox.Show("1. Check whether PC can connect external web site.\n2. Disable local proxy settings.\n3. Use mobile network via phone.", "Connection Error");
      }
      return flag;
    }

    public static bool login(
      string account,
      string password,
      string domain,
      ref string commToken,
      ref string errSvrStatus,
      ref string errSvrMsg)
    {
      CLogs.I("[LOGIN] START --------------------------------------------");
      if (!ServerInfo.checkConnection())
      {
        errSvrStatus = "ConnectFailed";
        return false;
      }
      string physicalAddressString = new NetworkInformation().EnumPhysicalAddress().GetAllPhysicalAddressString();
      if (physicalAddressString.Length == 0)
      {
        CLogs.E("Empty mac address information!");
        return false;
      }
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.LOGIN);
      string str = ServerInfo.Base64Encode(password);
      string paramJsonStr = "{" + string.Format("\"account\":\"{0}\",\"password\":\"{1}\",\"domain\":\"{2}\"", (object) account, (object) str, (object) domain) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
      dicRequestHeaders.Add("X-HWID", physicalAddressString);
      CLogs.I_encrypted("X-HWID: {0}", (object) physicalAddressString);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag)
      {
        if (webResponse.status != "Ok" || webResponse.result["token"] == null || ((string) webResponse.result["token"]).Length == 0)
        {
          flag = false;
        }
        else
        {
          commToken = webResponse.result["token"].ToString();
          ServerInfo.mLoginToken = commToken;
        }
      }
      OstOption.ResetOptions();
      if (flag)
      {
        if (domain.Length > 0 || account == "OutTest")
        {
          OstOption.EnableAllOptions();
          OstOption.removeRevokedOption();
          STSPermission.resetAllAs(true);
        }
        else if (webResponse.result["functions"] != null)
        {
          JArray permissionJArray = JArray.Parse(webResponse.result["functions"].ToString());
          foreach (JToken jtoken in (IEnumerable<JToken>) permissionJArray)
            OstOption.SetOption((string) jtoken, true);
          OstOption.removeRevokedOption();
          STSPermission.setPermissions(permissionJArray);
        }
        try
        {
          if (webResponse.result["licenses"] != null)
            STSLicense.setLicenses(JArray.Parse(webResponse.result["licenses"].ToString()));
        }
        catch (Exception ex)
        {
          CLogs.W("Find nothing for License!");
        }
      }
      if (!flag)
      {
        errSvrStatus = webResponse.status;
        errSvrMsg = webResponse.message;
      }
      CLogs.I("LOGIN END   --------------------------------------------");
      return flag;
    }

    public static bool queryEncodedSignatureSec0x8(
      string jsonQuery,
      ref string commToken,
      ref byte[] bufSig,
      ref int bufSigSize)
    {
      CLogs.I("[QUERY SIGNATURE] START ----------------------------------");
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string mSessionId = ServerInfo.mSessionId;
      string strA;
      string str1;
      string str2;
      string str3;
      try
      {
        JObject jobject = JObject.Parse(jsonQuery);
        if (jobject["serviceType"] == null || jobject["brandCode"] == null || (jobject["digestToSign"] == null || jobject["psn"] == null))
          return false;
        strA = jobject["serviceType"].ToString();
        str1 = jobject["brandCode"].ToString();
        str2 = jobject["digestToSign"].ToString();
        str3 = jobject["psn"].ToString();
        if (jobject["imei"] != null)
        {
          if (jobject["imei"].ToString() != string.Empty)
            empty5 = jobject["imei"].ToString();
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return false;
      }
      if (string.Compare(strA, "EnableRoot") != 0 && string.Compare(strA, "ChangeBootloader") != 0 && string.Compare(strA, "RewriteIMEI") != 0)
      {
        CLogs.E("Auth query service type not supported: {0}", (object) strA);
        return false;
      }
      CLogs.I_encrypted("Server query service type: {0}", (object) strA);
      if (!ServerInfo.checkConnection())
        return false;
      string base64String;
      try
      {
        base64String = Convert.ToBase64String(ServerInfo.StrToByteArray(str2.Replace("\r", "").Replace("\n", "")));
        CLogs.I_encrypted(string.Format("UID-Base64: {0}", (object) base64String));
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("(MESSAGE: Convert UID to base64 fail! {0}", (object) ex.Message));
        return false;
      }
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.GET_PERMISSION);
      string paramJsonStr = "{\"hashAlgorithm\":\"SHA1\"," + string.Format("\"digest\":\"{0}\",", (object) base64String) + string.Format("\"brand\":\"{0}\",", (object) str1) + string.Format("\"serviceType\":\"{0}\",", (object) strA) + string.Format("\"session\":\"{0}\",", (object) ServerInfo.mSessionId) + string.Format("\"psn\":\"{0}\"", (object) str3) + (empty5 == string.Empty ? "" : string.Format(",\"imei\":\"{0}\",", (object) empty5)) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("Authorization", commToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status.Contains("AuthTokenOverdue"))
      {
        CLogs.I("Server connection is timeout and re-login again...");
        UserConfig instance = UserConfig.Instance;
        FormUserLogin formUserLogin = new FormUserLogin(instance.LoginAccount, instance.LoginDomain);
        if (formUserLogin.StartLogin(instance.LoginAccount, instance.LoginPassword, instance.LoginDomain))
        {
          instance.LoginAccount = formUserLogin.Account;
          instance.LoginPassword = formUserLogin.Password;
          instance.LoginDomain = formUserLogin.Domain;
          OtaParam.Instance.Account.SetUsername(formUserLogin.Account);
          OtaParam.Instance.Account.SetPassword(formUserLogin.Password);
          OtaParam.Instance.Account.SetCommToken(formUserLogin.CommToken);
          ToolParam.Instance.UpdateArgumentUserPermission();
          CLogs.I_encrypted("Login request is success with account: " + formUserLogin.Account);
          CLogs.I_encrypted(string.Format("Communication token is changed from \"{0}\" to \"{1}\" ", (object) commToken, (object) formUserLogin.CommToken));
          commToken = formUserLogin.CommToken;
          dicRequestHeaders.Clear();
          dicRequestHeaders.Add("Authorization", commToken);
          CLogs.I("Query signature again...");
          flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
          ServerInfo.dumpWebResponse(webResponse);
        }
        else
        {
          CLogs.E("Server connection timeout and user cancels login dialog!");
          flag = false;
        }
      }
      if (flag)
      {
        if (webResponse.status == "Ok" && webResponse.result["signature"] != null)
        {
          string s = webResponse.result["signature"].ToString();
          try
          {
            bufSig = Convert.FromBase64String(s);
            bufSigSize = bufSig.Length;
          }
          catch (Exception ex)
          {
            CLogs.E(string.Format("Create signature fail! {0}", (object) ex.Message));
            return false;
          }
        }
        else
          flag = false;
      }
      CLogs.I("[QUERY SIGNATURE] END   ----------------------------------");
      return flag;
    }

    public static bool queryEncodedSignatureSec0x4(
      string jsonQuery,
      ref string commToken,
      ref byte[] bufSig,
      ref int bufSigSize)
    {
      CLogs.I("[QUERY SIGNATURE] START ----------------------------------");
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string strA;
      string str1;
      string str2;
      try
      {
        JObject jobject = JObject.Parse(jsonQuery);
        if (jobject["serviceType"] == null || jobject["projectCode"] == null || jobject["digestToSign"] == null)
          return false;
        strA = jobject["serviceType"].ToString();
        str1 = jobject["projectCode"].ToString();
        str2 = jobject["digestToSign"].ToString();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return false;
      }
      if (string.Compare(strA, "EnableRoot") != 0 && string.Compare(strA, "ChangeBootloader") != 0)
      {
        CLogs.E("Auth query service type not supported: {0}", (object) strA);
        return false;
      }
      CLogs.I_encrypted("Server query service type: {0}", (object) strA);
      if (!ServerInfo.checkConnection())
        return false;
      string base64String;
      try
      {
        base64String = Convert.ToBase64String(ServerInfo.StrToByteArray(str2.Replace("\r", "").Replace("\n", "")));
        CLogs.I_encrypted(string.Format("UID-Base64: {0}", (object) base64String));
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("(MESSAGE: Convert UID to base64 fail! {0}", (object) ex.Message));
        return false;
      }
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.GET_SIGNATURE);
      string paramJsonStr = "{" + string.Format("\"hashAlgorithm\":\"SHA1\",\"digest\":\"{0}\",\"project\":\"{1}\", \"serviceType\":\"{2}\"", (object) base64String, (object) str1, (object) strA) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("Authorization", commToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status.Contains("AuthTokenOverdue"))
      {
        CLogs.I("Server connection is timeout and re-login again...");
        UserConfig instance = UserConfig.Instance;
        FormUserLogin formUserLogin = new FormUserLogin(instance.LoginAccount, instance.LoginDomain);
        if (formUserLogin.StartLogin(instance.LoginAccount, instance.LoginPassword, instance.LoginDomain))
        {
          instance.LoginAccount = formUserLogin.Account;
          instance.LoginPassword = formUserLogin.Password;
          instance.LoginDomain = formUserLogin.Domain;
          OtaParam.Instance.Account.SetUsername(formUserLogin.Account);
          OtaParam.Instance.Account.SetPassword(formUserLogin.Password);
          OtaParam.Instance.Account.SetCommToken(formUserLogin.CommToken);
          ToolParam.Instance.UpdateArgumentUserPermission();
          CLogs.I_encrypted("Login request is success with account: " + formUserLogin.Account);
          CLogs.I_encrypted(string.Format("Communication token is changed from \"{0}\" to \"{1}\" ", (object) commToken, (object) formUserLogin.CommToken));
          commToken = formUserLogin.CommToken;
          dicRequestHeaders.Clear();
          dicRequestHeaders.Add("Authorization", commToken);
          CLogs.I("Query signature again...");
          flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
          ServerInfo.dumpWebResponse(webResponse);
        }
        else
        {
          CLogs.E("Server connection timeout and user cancels login dialog!");
          flag = false;
        }
      }
      if (flag)
      {
        if (webResponse.status == "Ok" && webResponse.result["signature"] != null)
        {
          string s = webResponse.result["signature"].ToString();
          try
          {
            bufSig = Convert.FromBase64String(s);
            bufSigSize = bufSig.Length;
          }
          catch (Exception ex)
          {
            CLogs.E(string.Format("Create signature fail! {0}", (object) ex.Message));
            return false;
          }
        }
        else
          flag = false;
      }
      CLogs.I("[QUERY SIGNATURE] END   ----------------------------------");
      return flag;
    }

    public static bool queryEncodedSignature(
      string queryServiceType,
      ref string commToken,
      string deviceUID,
      string projectCode,
      ref byte[] bufSig,
      ref int bufSigSize)
    {
      CLogs.I("[QUERY SIGNATURE] START ----------------------------------");
      if (string.Compare(queryServiceType, "EnableRoot") != 0 && string.Compare(queryServiceType, "ChangeBootloader") != 0 && string.Compare(queryServiceType, "RewriteIMEI") != 0)
      {
        CLogs.E("Auth query service type no supported: {0}", (object) queryServiceType);
        return false;
      }
      if (string.Compare(queryServiceType, "EnableRoot") == 0)
        queryServiceType = "EnableRoot";
      if (string.Compare(queryServiceType, "ChangeBootloader") == 0)
        queryServiceType = "ChangeBootloader";
      if (string.Compare(queryServiceType, "RewriteIMEI") == 0)
        queryServiceType = "RewriteIMEI";
      CLogs.I_encrypted("Server query service type: {0}", (object) queryServiceType);
      if (!ServerInfo.checkConnection())
        return false;
      string base64String;
      try
      {
        deviceUID = deviceUID.Replace("\r", "");
        deviceUID = deviceUID.Replace("\n", "");
        base64String = Convert.ToBase64String(ServerInfo.StrToByteArray(deviceUID));
        CLogs.I_encrypted(string.Format("UID-Base64: {0}", (object) base64String));
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("(MESSAGE: Convert UID to base64 fail! {0}", (object) ex.Message));
        return false;
      }
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.GET_SIGNATURE);
      string paramJsonStr = "{" + string.Format("\"hashAlgorithm\":\"SHA1\",\"digest\":\"{0}\",\"project\":\"{1}\", \"serviceType\":\"{2}\"", (object) base64String, (object) projectCode, (object) queryServiceType) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("Authorization", commToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status.Contains("AuthTokenOverdue"))
      {
        CLogs.I("Server connection is timeout and re-login again...");
        UserConfig instance = UserConfig.Instance;
        FormUserLogin formUserLogin = new FormUserLogin(instance.LoginAccount, instance.LoginDomain);
        if (formUserLogin.StartLogin(instance.LoginAccount, instance.LoginPassword, instance.LoginDomain))
        {
          instance.LoginAccount = formUserLogin.Account;
          instance.LoginPassword = formUserLogin.Password;
          instance.LoginDomain = formUserLogin.Domain;
          OtaParam.Instance.Account.SetUsername(formUserLogin.Account);
          OtaParam.Instance.Account.SetPassword(formUserLogin.Password);
          OtaParam.Instance.Account.SetCommToken(formUserLogin.CommToken);
          ToolParam.Instance.UpdateArgumentUserPermission();
          CLogs.I_encrypted("Login request is success with account: " + formUserLogin.Account);
          CLogs.I_encrypted(string.Format("Communication token is changed from \"{0}\" to \"{1}\" ", (object) commToken, (object) formUserLogin.CommToken));
          commToken = formUserLogin.CommToken;
          dicRequestHeaders.Clear();
          dicRequestHeaders.Add("Authorization", commToken);
          CLogs.I("Query signature again...");
          flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
          ServerInfo.dumpWebResponse(webResponse);
        }
        else
        {
          CLogs.E("Server connection timeout and user cancels login dialog!");
          flag = false;
        }
      }
      if (flag)
      {
        if (webResponse.status == "Ok" && webResponse.result["signature"] != null)
        {
          string s = webResponse.result["signature"].ToString();
          try
          {
            bufSig = Convert.FromBase64String(s);
            bufSigSize = bufSig.Length;
          }
          catch (Exception ex)
          {
            CLogs.E(string.Format("Create signature fail! {0}", (object) ex.Message));
            return false;
          }
        }
        else
          flag = false;
      }
      CLogs.I("[QUERY SIGNATURE] END   ----------------------------------");
      return flag;
    }

    public static string Base64Encode(string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

    public static string Base64Decode(string base64EncodedData) => Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));

    public static bool ReportServiceResult(string jsonTestResult)
    {
      CLogs.I("[REPORT SERVICE RESULT] START --------------------------------------------");
      if (!ServerInfo.checkConnection())
        return false;
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.REPORT_SERVICE_RESULT);
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
      dicRequestHeaders.Add("Authorization", ServerInfo.mLoginToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, jsonTestResult, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && (webResponse.status != "Ok" || webResponse.message != "Success"))
      {
        ServerInfo.mSessionId = ServerInfo.newSessionId();
        return false;
      }
      CLogs.I("REPORT SERVICE RESULT END   --------------------------------------------");
      ServerInfo.refreshSessionId();
      return true;
    }

    public static bool QueryServerSimUnlockCode(string productid, ref string unlockCode)
    {
      CLogs.I("[QueryServerSimUnlockCode] START --------------------------------------------");
      if (!ServerInfo.checkConnection())
        return false;
      Guid.NewGuid().ToString();
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.QUERY_SIM_UNLOCK_CODE);
      string paramJsonStr = "{" + string.Format("\"productId\":\"{0}\"", (object) productid) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
      dicRequestHeaders.Add("Authorization", ServerInfo.mLoginToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status.Contains("AuthTokenOverdue"))
      {
        if (flag)
          flag = ServerInfo.UserRelogin();
        if (flag)
        {
          dicRequestHeaders.Clear();
          dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
          dicRequestHeaders.Add("Authorization", ServerInfo.mLoginToken);
          flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
          ServerInfo.dumpWebResponse(webResponse);
        }
      }
      if (flag && (webResponse.status != "Ok" || webResponse.message != "Success"))
        flag = false;
      if (flag)
      {
        if (webResponse.result[nameof (unlockCode)] == null)
        {
          flag = false;
          CLogs.E("SIM unlock code queried from server is null.");
        }
        else
          unlockCode = webResponse.result[nameof (unlockCode)].ToString();
      }
      CLogs.I("[QueryServerSimUnlockCode] END --------------------------------------------");
      return flag;
    }

    public static bool DeleteServerSimUnlockCode(string productid)
    {
      CLogs.I("[DeleteServerSimUnlockCode] START --------------------------------------------");
      if (!ServerInfo.checkConnection())
        return false;
      Guid.NewGuid().ToString();
      string serverUrl = ServerInfo.getServerUrl(ServerInfo.WEB_API.DEL_SIM_UNLOCK_CODE);
      string paramJsonStr = "{" + string.Format("\"productId\":\"{0}\"", (object) productid) + "}";
      Dictionary<string, string> dicRequestHeaders = new Dictionary<string, string>();
      dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
      dicRequestHeaders.Add("Authorization", ServerInfo.mLoginToken);
      HttpUtil httpUtil = new HttpUtil();
      webResponseObject webResponse = new webResponseObject();
      bool flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      ServerInfo.dumpWebResponse(webResponse);
      if (flag && webResponse.status.Contains("AuthTokenOverdue"))
      {
        if (flag)
          flag = ServerInfo.UserRelogin();
        if (flag)
        {
          dicRequestHeaders.Clear();
          dicRequestHeaders.Add("X-Request-ID", ServerInfo.mRequestId);
          dicRequestHeaders.Add("Authorization", ServerInfo.mLoginToken);
          flag = httpUtil.DoWebRequest("POST", serverUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
          ServerInfo.dumpWebResponse(webResponse);
        }
      }
      if (flag && (webResponse.status != "Ok" || webResponse.message != "Success"))
        flag = false;
      CLogs.I("[DeleteServerSimUnlockCode] END --------------------------------------------");
      return flag;
    }

    private static bool UserRelogin()
    {
      bool flag = true;
      CLogs.I("Server connection is timeout and re-login again...");
      UserConfig instance = UserConfig.Instance;
      FormUserLogin formUserLogin = new FormUserLogin(instance.LoginAccount, instance.LoginDomain);
      if (formUserLogin.StartLogin(instance.LoginAccount, instance.LoginPassword, instance.LoginDomain))
      {
        instance.LoginAccount = formUserLogin.Account;
        instance.LoginPassword = formUserLogin.Password;
        instance.LoginDomain = formUserLogin.Domain;
        OtaParam.Instance.Account.SetUsername(formUserLogin.Account);
        OtaParam.Instance.Account.SetPassword(formUserLogin.Password);
        OtaParam.Instance.Account.SetCommToken(formUserLogin.CommToken);
        ToolParam.Instance.UpdateArgumentUserPermission();
        CLogs.I("Login request is success with account: " + formUserLogin.Account);
        CLogs.I(string.Format("Communication token is changed from \"{0}\" to \"{1}\" ", (object) ServerInfo.mLoginToken, (object) formUserLogin.CommToken));
        ServerInfo.mLoginToken = formUserLogin.CommToken;
      }
      else
      {
        CLogs.E("Server connection timeout and user cancels login dialog!");
        flag = false;
      }
      return flag;
    }

    public enum WEB_API
    {
      CHECK_CONNECTION = 1,
      LOGIN = 2,
      GET_SIGNATURE = 3,
      GET_PERMISSION = 4,
      REPORT_SERVICE_RESULT = 5,
      QUERY_SIM_UNLOCK_CODE = 6,
      DEL_SIM_UNLOCK_CODE = 7,
    }
  }
}
