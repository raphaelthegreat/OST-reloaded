// Decompiled with JetBrains decompiler
// Type: UserForms.UserInterAction
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using ImageControl.ImageLoader;
using Locales;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OtaControl;
using OtaControl.PhoneReader;
using Params;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UserConfigs;
using Utils;

namespace UserForms
{
  internal class UserInterAction
  {
    private static string commToken = "";
    private static bool multiSessions = false;
    private static bool cacheEnabled = false;
    private static Dictionary<int, int> caches = new Dictionary<int, int>();
    private static IWin32Window owner;
    private static object thisLock = new object();

    public static string CommToken
    {
      set
      {
        UserInterAction.commToken = value;
        UserInterAction.commToken = value;
      }
    }

    public static bool MultiSessions
    {
      set
      {
        UserInterAction.multiSessions = value;
        UserInterAction.cacheEnabled = value;
      }
    }

    public static IWin32Window Owner
    {
      set => UserInterAction.owner = value;
    }

    public static bool AcquireAuthentication(string jsonQuery, ref AuthRet authRet)
    {
      CLogs.B("Start authentication...");
      string empty = string.Empty;
      byte[] bufSig = new byte[1024];
      int bufSigSize = 0;
      string str;
      try
      {
        JObject jobject = JObject.Parse(jsonQuery);
        if (string.IsNullOrEmpty(jobject["secVersion"].ToString()))
        {
          CLogs.E("Security version for AcquireAuthentication is null or empty!");
          return false;
        }
        str = jobject["secVersion"].ToString();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return false;
      }
      if (UserInterAction.commToken.Length == 0)
      {
        CLogs.E("Empty communication token!");
        return false;
      }
      if (!(Convert.ToInt32(str) > 4 ? ServerInfo.queryEncodedSignatureSec0x8(jsonQuery, ref UserInterAction.commToken, ref bufSig, ref bufSigSize) : ServerInfo.queryEncodedSignatureSec0x4(jsonQuery, ref UserInterAction.commToken, ref bufSig, ref bufSigSize)))
      {
        CLogs.E("Query signature fail!");
        return false;
      }
      authRet.bufSize = bufSigSize;
      Buffer.BlockCopy((Array) bufSig, 0, (Array) authRet.bufSignature, 0, authRet.bufSize);
      return true;
    }

    public static DialogResult ShowWarningDialog(string message)
    {
      lock (UserInterAction.thisLock)
        return new FormUserWarning()
        {
          Title = Locale.Instance.LoadCombinedText("TITLE_WARNING"),
          Message = message,
          ButtonCaseId = FormUserWarning.ButtonCaseID.OK
        }.ShowDialog(UserInterAction.owner);
    }

    public static bool ShowWarningDialog(string sessionId, int caseId, out int choiceId)
    {
      bool flag = true;
      lock (UserInterAction.thisLock)
      {
        if (UserInterAction.cacheEnabled && UserInterAction.caches.ContainsKey(caseId))
        {
          choiceId = UserInterAction.caches[caseId];
        }
        else
        {
          FormUserWarning formUserWarning = new FormUserWarning();
          formUserWarning.Title = Locale.Instance.LoadCombinedText("TITLE_WARNING");
          if (UserInterAction.multiSessions)
            formUserWarning.Title += string.Format(" ({0})", (object) sessionId);
          formUserWarning.Message = Locale.Instance.LoadCombinedText(UserInterAction.GetWarningLocaleId((WarningCaseID) caseId));
          formUserWarning.ButtonCaseId = UserInterAction.GetWarningButtonCaseID((WarningCaseID) caseId);
          formUserWarning.CacheEnabled = UserInterAction.cacheEnabled;
          switch (formUserWarning.ShowDialog(UserInterAction.owner))
          {
            case DialogResult.OK:
              choiceId = 4;
              if (UserInterAction.cacheEnabled)
              {
                if (formUserWarning.CacheApplied)
                {
                  UserInterAction.caches[caseId] = choiceId;
                  break;
                }
                break;
              }
              break;
            case DialogResult.Cancel:
              choiceId = 1;
              if (UserInterAction.cacheEnabled)
              {
                if (formUserWarning.CacheApplied)
                {
                  UserInterAction.caches[caseId] = choiceId;
                  break;
                }
                break;
              }
              break;
            default:
              choiceId = 0;
              flag = false;
              break;
          }
        }
      }
      return flag;
    }

    private static string GetWarningLocaleId(WarningCaseID caseId)
    {
      switch (caseId)
      {
        case WarningCaseID.sutinfoNotEquals:
          return "USER_MODEL_NOT_MATCH_MSG_1";
        case WarningCaseID.sutinfoImageEmpty:
          return "USER_MODEL_NOT_MATCH_MSG_2";
        case WarningCaseID.sutinfoPhoneEmpty:
          return "USER_MODEL_NOT_MATCH_MSG_3";
        case WarningCaseID.rebootDeviceManually:
          return "USERMSG_REBOOT_DEVICE_MANUALLY";
        case WarningCaseID.rootDevice:
          return "USERMSG_DEVICE_ALREADY_ROOT";
        case WarningCaseID.nonSupportDownloadExtraModem:
          return "USERMSG_NON_SUPPORT_DOWNLOAD_EXTRA_MODEM";
        case WarningCaseID.nonSupportOneImage:
          return "USERMSG_NON_SUPPORT_ONE_IMAGE";
        case WarningCaseID.connectExternalUsbHub:
          return "USERMSG_CONNECT_EXTERNAL_USB_HUB";
        case WarningCaseID.eraseUserData:
          return "USERMSG_ERASE_USER_DATA";
        case WarningCaseID.eraseFrp:
          return "USERMSG_ERASE_FRP_DISCLAIMER";
        case WarningCaseID.imeiReadOnly:
          return "USERMSG_IMEI_READ_ONLY";
        case WarningCaseID.collectAprFailAlert:
          return "USERMSG_COLLECT_APR_FAIL_ALERT";
        default:
          return string.Empty;
      }
    }

    private static FormUserWarning.ButtonCaseID GetWarningButtonCaseID(
      WarningCaseID caseId)
    {
      switch (caseId)
      {
        case WarningCaseID.sutinfoNotEquals:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.sutinfoImageEmpty:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.sutinfoPhoneEmpty:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.rebootDeviceManually:
          return FormUserWarning.ButtonCaseID.OK;
        case WarningCaseID.rootDevice:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.nonSupportDownloadExtraModem:
          return FormUserWarning.ButtonCaseID.OK;
        case WarningCaseID.nonSupportOneImage:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.connectExternalUsbHub:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.eraseUserData:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        case WarningCaseID.eraseFrp:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
        default:
          return FormUserWarning.ButtonCaseID.OK_CANCEL;
      }
    }

    public static bool ShowEnterSpcDialog(string sessionId, out int choiceId, ref SpcData data)
    {
      bool flag = true;
      lock (UserInterAction.thisLock)
      {
        FormUserEnterSpc formUserEnterSpc = new FormUserEnterSpc();
        formUserEnterSpc.MessageLocaleId = "USER_ENTER_SPC_MSG";
        formUserEnterSpc.Spc = data.spc;
        DialogResult dialogResult = formUserEnterSpc.ShowDialog(UserInterAction.owner);
        switch (dialogResult)
        {
          case DialogResult.OK:
            choiceId = 4;
            break;
          case DialogResult.Cancel:
            choiceId = 1;
            break;
          default:
            choiceId = 0;
            flag = false;
            break;
        }
        data.spc = dialogResult == DialogResult.OK ? formUserEnterSpc.Spc : "";
      }
      return flag;
    }

    public static bool ShowReEnterSpcDialog(string sessionId, out int choiceId, ref SpcData data)
    {
      bool flag = true;
      lock (UserInterAction.thisLock)
      {
        FormUserEnterSpc formUserEnterSpc = new FormUserEnterSpc();
        formUserEnterSpc.MessageLocaleId = "USER_REENTER_SPC_MSG";
        formUserEnterSpc.Spc = data.spc;
        DialogResult dialogResult = formUserEnterSpc.ShowDialog(UserInterAction.owner);
        switch (dialogResult)
        {
          case DialogResult.OK:
            choiceId = 4;
            break;
          case DialogResult.Cancel:
            choiceId = 1;
            break;
          default:
            choiceId = 0;
            flag = false;
            break;
        }
        data.spc = dialogResult == DialogResult.OK ? formUserEnterSpc.Spc : "";
      }
      return flag;
    }

    public static bool ShowModelWarningDialog(
      string sessionId,
      string phoneModel,
      string imageModel,
      out int choiceId)
    {
      bool flag = true;
      int key = 4;
      lock (UserInterAction.thisLock)
      {
        if (UserInterAction.cacheEnabled && UserInterAction.caches.ContainsKey(key))
        {
          choiceId = UserInterAction.caches[key];
        }
        else
        {
          FormUserModelWarning userModelWarning = new FormUserModelWarning(phoneModel, imageModel);
          userModelWarning.Title = Locale.Instance.LoadCombinedText("TITLE_WARNING");
          if (UserInterAction.multiSessions)
            userModelWarning.Title += string.Format(" ({0})", (object) sessionId);
          userModelWarning.CacheEnabled = UserInterAction.cacheEnabled;
          switch (userModelWarning.ShowDialog(UserInterAction.owner))
          {
            case DialogResult.OK:
              choiceId = 4;
              if (UserInterAction.cacheEnabled)
              {
                if (userModelWarning.CacheApplied)
                {
                  UserInterAction.caches[key] = choiceId;
                  break;
                }
                break;
              }
              break;
            case DialogResult.Cancel:
              choiceId = 1;
              if (UserInterAction.cacheEnabled)
              {
                if (userModelWarning.CacheApplied)
                {
                  UserInterAction.caches[key] = choiceId;
                  break;
                }
                break;
              }
              break;
            default:
              choiceId = 0;
              flag = false;
              break;
          }
        }
      }
      return flag;
    }

    public static bool ShowModelSelectSkuIdDialog(
      string sessionId,
      string infomation,
      string defaultSKUID,
      out int choiceId,
      ref SKUId skuId)
    {
      bool flag = true;
      lock (UserInterAction.thisLock)
      {
        FormUserSwitchSkuId formUserSwitchSkuId = new FormUserSwitchSkuId();
        formUserSwitchSkuId.Title = Locale.Instance.LoadCombinedText("TITLE_WARNING");
        if (UserInterAction.multiSessions)
          formUserSwitchSkuId.Title += string.Format(" ({0})", (object) sessionId);
        formUserSwitchSkuId.Message = infomation;
        formUserSwitchSkuId.DefaultSKUID = defaultSKUID;
        formUserSwitchSkuId.ButtonCaseId = FormUserSwitchSkuId.ButtonCaseID.OK;
        DialogResult dialogResult = formUserSwitchSkuId.ShowDialog(UserInterAction.owner);
        switch (dialogResult)
        {
          case DialogResult.OK:
            choiceId = 4;
            break;
          case DialogResult.Cancel:
            choiceId = 1;
            break;
          case DialogResult.Ignore:
            choiceId = 3;
            break;
          default:
            choiceId = 0;
            flag = false;
            break;
        }
        skuId.skuId = dialogResult == DialogResult.OK ? formUserSwitchSkuId.SkuId : "";
      }
      return flag;
    }

    public static bool DoReportServiceResult(string jsonTestResult)
    {
      bool flag = true;
      CLogs.I("Report Service Result");
      if (!ServerInfo.ReportServiceResult(jsonTestResult))
      {
        CLogs.E("Report service result fail!");
        return false;
      }
      CLogs.I("Do ReportServiceResult succeed.");
      return flag;
    }

    public static bool QueryServerSimUnlockCode(string productid, ref StringRet unlockCode)
    {
      string empty = string.Empty;
      if (!ServerInfo.QueryServerSimUnlockCode(productid, ref empty))
      {
        CLogs.E("Query SIM unlock code from server failed!");
        return false;
      }
      unlockCode.response = empty;
      return true;
    }

    public static bool DeleteServerSimUnlockCode(string productid)
    {
      if (ServerInfo.DeleteServerSimUnlockCode(productid))
        return true;
      CLogs.E("Delete SIM unlock code in server failed!");
      return false;
    }

    [DllImport("MobileFlashDll.dll")]
    private static extern int checkFastbootAlive(string sessionId, string deviceId);

    public static bool CompareSutinfo(string phoneInformation, string imageInformation)
    {
      bool flag = false;
      lock (UserInterAction.thisLock)
      {
        try
        {
          OtaAccount account = OtaParam.Instance.Account;
          OtaData phone = OtaData.Parse(JsonConvert.DeserializeObject<PhoneInformationEntity>(phoneInformation.ToString()));
          OtaData image = new OtaData(ImageData.Parse(JsonConvert.DeserializeObject<ImageInformationEntity>(imageInformation.ToString())));
          CLogs.I("Compare device and image information, login account: " + account.Username);
          flag = account.Rights.Exists((Predicate<OtaRight>) (right => right.Compare(phone, image)));
        }
        catch (Exception ex)
        {
          CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        }
      }
      return flag;
    }

    public static bool DoLoginRequest()
    {
      UserConfig instance = UserConfig.Instance;
      FormUserLogin formUserLogin = new FormUserLogin(instance.LoginAccount, instance.LoginDomain);
      if (formUserLogin.ShowDialog() != DialogResult.OK)
        return false;
      instance.LoginAccount = formUserLogin.Account;
      instance.LoginPassword = formUserLogin.Password;
      instance.LoginDomain = formUserLogin.Domain;
      try
      {
        instance.LoginMacAddress = new NetworkInformation().EnumPhysicalAddress().GetPhysicalAddressByIndex(0);
      }
      catch (Exception ex)
      {
      }
      OtaParam.Instance.Account.SetUsername(formUserLogin.Account);
      OtaParam.Instance.Account.SetPassword(formUserLogin.Password);
      OtaParam.Instance.Account.SetCommToken(formUserLogin.CommToken);
      ToolParam.Instance.UpdateArgumentUserPermission();
      CLogs.I("Login request is success with account: " + formUserLogin.Account);
      return true;
    }

    public static bool DoCredentialReqeust(
      ref string username,
      ref string password,
      ref string domain)
    {
      FormUserAuth formUserAuth = new FormUserAuth(username, domain);
      if (formUserAuth.ShowDialog(UserInterAction.owner) != DialogResult.OK)
        return false;
      username = formUserAuth.Username;
      password = formUserAuth.Password;
      domain = formUserAuth.Domain;
      return true;
    }
  }
}
