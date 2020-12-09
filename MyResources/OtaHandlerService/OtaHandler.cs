// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.OtaHandler
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.FileHandlerService;
using MyResources.LoginService;
using MyResources.LogService;
using MyResources.SWImageService;
using OtaControl;
using System;
using System.Collections.Generic;
using System.Net;
using UserConfigs;
using UserForms;
using Utils;

namespace MyResources.OtaHandlerService
{
  internal class OtaHandler
  {
    private static NetworkCredential proxyCredential;
    private static CredentialCache cache;
    private static bool disable100Continue;
    private CookieContainer cookieContainer;
    private LoginServiceEx serviceLogin;
    private SWImageServiceEx serviceSWImage;
    private FileHandlerServiceEx serviceFileHandler;
    private LogServiceEx serviceLog;

    public List<OtaData> QueryDeltaImages(OtaData selector, bool enableOnly)
    {
      try
      {
        List<OtaData> otaDataList = new List<OtaData>();
        otaDataList.Add(this.SelectDeltaImages(selector, enableOnly));
        otaDataList.RemoveAll(new Predicate<OtaData>(this.BasicDeltaFilter));
        return otaDataList;
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("Query delta image is failed, selctor: {0}, enabledOnly: {1}, service: {2}, message: {3}", (object) selector, (object) enableOnly, (object) this.serviceSWImage.Url, (object) ex.Message) + ex.StackTrace);
        throw ex;
      }
    }

    private bool BasicDeltaFilter(OtaData x)
    {
      string[] strArray = new string[5]
      {
        "InternalModel",
        "ImageID",
        "Version",
        "SubVersion",
        "Platform"
      };
      foreach (string key in strArray)
      {
        if (string.IsNullOrEmpty(x.Get(key)))
          return true;
      }
      return false;
    }

    private OtaData SelectDeltaImages(OtaData selector, bool enableOnly)
    {
      string str = this.QueryNewImageId(selector, enableOnly);
      if (string.IsNullOrEmpty(str))
        return new OtaData();
      string currentImageId = this.GetCurrentImageId(selector, enableOnly);
      if (string.IsNullOrEmpty(currentImageId))
        return new OtaData();
      string newDeltaImageId = this.QueryNewDeltaImageId(currentImageId, str);
      if (string.IsNullOrEmpty(newDeltaImageId))
        return new OtaData();
      long num = selector.Contain("StorageSize") ? long.Parse(selector.Get("StorageSize")) : 0L;
      return this.QueryDeltaSize(newDeltaImageId) >= num ? new OtaData() : this.SelectOtaImages(str).Set("ID", newDeltaImageId).Set("Delta", "True");
    }

    private string GetCurrentImageId(OtaData selector, bool enableOnly)
    {
      ReturnEntryOfArrayOfArrayOfDictionaryEntry ofDictionaryEntry = this.serviceSWImage.QueryImageData(new string[1]
      {
        "ID"
      }, this.GetDeltaCurrentCondition(selector, enableOnly), -1, "");
      if (ofDictionaryEntry.Status != MyResources.SWImageService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'QueryImageData' is failed, selector: {0}, enableOnly: {1}, service: {2}, error: {3}", (object) selector.ToString(), (object) enableOnly, (object) this.serviceSWImage.Url, (object) ofDictionaryEntry.Status.ToString()));
      return ofDictionaryEntry.Value.Length != 1 ? string.Empty : new SwImageEntry(ofDictionaryEntry.Value[0]).ToOtaData().Get("ID");
    }

    private string GetDeltaCurrentCondition(OtaData selector, bool enableOnly)
    {
      string str = string.Format("InternalModel = '{0}' AND ImageID = '{1}' AND Version = '{2}' AND SubVersion = '{3}' AND (CDAVersion = '' OR CDAVersion = '{4}')", (object) selector.Get("InternalModel"), (object) selector.Get("ImageID"), (object) selector.Get("Version"), (object) selector.Get("SubVersion"), (object) selector.Get("CDAVersion"));
      if (enableOnly)
        str += " AND Enabled = 1";
      return str;
    }

    private string QueryNewImageId(OtaData selector, bool enableOnly)
    {
      MyResources.SWImageService.ReturnEntryOfArrayOfDictionaryEntry ofDictionaryEntry = this.serviceSWImage.QueryLatestImageAction(this.GetDeltaNewEntries(selector, enableOnly));
      if (ofDictionaryEntry.Status != MyResources.SWImageService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'QueryLatestImageAction' is failed, selector: {0}, enableOnly: {1}, service: {2}, error: {3}", (object) selector.ToString(), (object) enableOnly, (object) this.serviceSWImage.Url, (object) ofDictionaryEntry.Status.ToString()));
      return new SwImageEntry(ofDictionaryEntry.Value).ToOtaData().Get("id").Equals("-1") ? string.Empty : new SwImageEntry(ofDictionaryEntry.Value).ToOtaData().Get("id");
    }

    private MyResources.SWImageService.DictionaryEntry[] GetDeltaNewEntries(
      OtaData selector,
      bool enableOnly)
    {
      SwImageEntry swImageEntry = new SwImageEntry(selector);
      if (enableOnly)
        swImageEntry.Add("Enabled", (object) 1);
      return swImageEntry.Instance;
    }

    private string QueryNewDeltaImageId(string currentImageId, string newImageId)
    {
      ReturnEntryOfArrayOfArrayOfDictionaryEntry ofDictionaryEntry = this.serviceSWImage.QueryUpdateData(new string[1]
      {
        "ID"
      }, "PreVersion = " + currentImageId + " AND NextVersion = " + newImageId, -1, "");
      if (ofDictionaryEntry.Status != MyResources.SWImageService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'QueryUpdateData' is failed, current image ID: {0}, new image ID: {1}, service: {2}, error: {3}", (object) currentImageId, (object) newImageId, (object) this.serviceSWImage.Url, (object) ofDictionaryEntry.Status.ToString()));
      return ofDictionaryEntry.Value.Length != 1 ? string.Empty : new SwImageEntry(ofDictionaryEntry.Value[0]).ToOtaData().Get("ID");
    }

    private long QueryDeltaSize(string newDeltaImageId)
    {
      MyResources.FileHandlerService.ReturnEntryOfArrayOfDictionaryEntry fileInfo = this.serviceFileHandler.GetFileInfo(FileType.SWUpdate, newDeltaImageId);
      if (fileInfo.Status != MyResources.FileHandlerService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'GetFileInfo' is failed, new detla ID: {0}, service: {1}, error: {2}", (object) newDeltaImageId, (object) this.serviceFileHandler.Url, (object) fileInfo.Status.ToString()));
      return long.Parse(new FileHandlerEntry(fileInfo.Value).ToOtaData().Get("Length")) != 0L ? long.Parse(new FileHandlerEntry(fileInfo.Value).ToOtaData().Get("Length")) : throw new CException(1066L, string.Format("Get zero detla image size, new detla id: {0}, service: {1}", (object) newDeltaImageId, (object) this.serviceFileHandler.Url));
    }

    public long SendUpdateReport(
      string deviceId,
      string internalModel,
      string imageId,
      string fromVersion,
      string toVersion,
      long errCode,
      string statge,
      bool localimage)
    {
      MyResources.LogService.DictionaryEntry[] objData = new MyResources.LogService.DictionaryEntry[11];
      objData[0] = new MyResources.LogService.DictionaryEntry();
      objData[0].Key = (object) "DeviceID";
      objData[0].Value = (object) deviceId;
      objData[1] = new MyResources.LogService.DictionaryEntry();
      objData[1].Key = (object) "InternalModel";
      objData[1].Value = (object) internalModel;
      objData[2] = new MyResources.LogService.DictionaryEntry();
      objData[2].Key = (object) "ImageID";
      objData[2].Value = (object) imageId;
      objData[3] = new MyResources.LogService.DictionaryEntry();
      objData[3].Key = (object) "FromVersion";
      objData[3].Value = (object) fromVersion;
      objData[4] = new MyResources.LogService.DictionaryEntry();
      objData[4].Key = (object) "ToVersion";
      objData[4].Value = (object) toVersion;
      objData[5] = new MyResources.LogService.DictionaryEntry();
      objData[5].Key = (object) "CurrentVersion";
      objData[5].Value = errCode == 0L ? (object) toVersion : (object) fromVersion;
      objData[6] = new MyResources.LogService.DictionaryEntry();
      objData[6].Key = (object) "ErrCode";
      objData[6].Value = (object) (int) errCode;
      objData[7] = new MyResources.LogService.DictionaryEntry();
      objData[7].Key = (object) "ErrMessage";
      objData[7].Value = errCode == 0L ? (object) "success" : (object) "fail";
      objData[8] = new MyResources.LogService.DictionaryEntry();
      objData[8].Key = (object) "Stage";
      objData[8].Value = (object) statge;
      objData[9] = new MyResources.LogService.DictionaryEntry();
      objData[9].Key = (object) "DataSource";
      objData[9].Value = localimage ? (object) "OUT_LocalImage" : (object) "OUT_OnlineImage";
      return (long) this.serviceLog.ReportLog(LogType.OTA, (MyResources.LogService.DictionaryEntry[]) null, objData, false).Status;
    }

    public static NetworkCredential ProxyCredential => OtaHandler.proxyCredential == null ? CredentialCache.DefaultNetworkCredentials : OtaHandler.proxyCredential;

    public static ICredentials Credential => OtaHandler.cache == null ? CredentialCache.DefaultCredentials : (ICredentials) OtaHandler.cache;

    public static bool Disable100Continue => OtaHandler.disable100Continue;

    public bool HandleWebException(WebException ex)
    {
      if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response is HttpWebResponse)
        return this.HandleHttpError(ex.Response as HttpWebResponse);
      CLogs.E("Catch unhandled web exception - " + ex.Message + ex.StackTrace);
      return false;
    }

    private bool HandleHttpError(HttpWebResponse response)
    {
      switch (response.StatusCode)
      {
        case HttpStatusCode.Unauthorized:
          return this.HandleUnauthorized(response);
        case HttpStatusCode.ProxyAuthenticationRequired:
          return this.HandleProxyAuthenticationRequired(response);
        case HttpStatusCode.ExpectationFailed:
          return this.Handle100Continue();
        default:
          CLogs.E("Catch unhandled http exception - " + string.Format("status: {0}, description: {1}, host: {2}", (object) response.StatusCode, (object) response.StatusDescription, (object) response.ResponseUri.Host));
          return false;
      }
    }

    private bool HandleUnauthorized(HttpWebResponse response)
    {
      CLogs.I("Handle http exception: www authentication is required from " + response.ResponseUri.Host);
      string str1 = response.Headers[HttpResponseHeader.WwwAuthenticate];
      if (string.IsNullOrEmpty(str1))
      {
        CLogs.W("Catch www authenticate type fails, use default.");
        str1 = "Basic";
      }
      else
        CLogs.I("WWW authenticate types: " + str1);
      UserConfig instance = UserConfig.Instance;
      string authUsername = instance.AuthUsername;
      string empty = string.Empty;
      string authDomain = instance.AuthDomain;
      instance.AuthUsername = authUsername;
      instance.AuthPassword = empty;
      instance.AuthDomain = authDomain;
      if (OtaHandler.cache == null)
        OtaHandler.cache = new CredentialCache();
      string str2 = str1;
      char[] chArray = new char[1]{ ',' };
      foreach (string authType in str2.Split(chArray))
      {
        OtaHandler.cache.Remove(response.ResponseUri, authType);
        OtaHandler.cache.Add(response.ResponseUri, authType, new NetworkCredential(authUsername, empty, authDomain));
      }
      return true;
    }

    private bool HandleProxyAuthenticationRequired(HttpWebResponse response)
    {
      CLogs.I("Handle http exception: proxy authentication is required from " + response.ResponseUri.Host);
      UserConfig instance = UserConfig.Instance;
      string proxyAuthUsername = instance.ProxyAuthUsername;
      string empty = string.Empty;
      string proxyAuthDomain = instance.ProxyAuthDomain;
      instance.ProxyAuthUsername = proxyAuthUsername;
      instance.ProxyAuthPassword = empty;
      instance.ProxyAuthDomain = proxyAuthDomain;
      OtaHandler.proxyCredential = new NetworkCredential(proxyAuthUsername, empty, proxyAuthDomain);
      return true;
    }

    public bool Handle100Continue()
    {
      if (OtaHandler.disable100Continue)
        return false;
      CLogs.I("Handle http exception: disable 100 continue.");
      OtaHandler.disable100Continue = true;
      return true;
    }

    public List<OtaData> QueryOtaImages(OtaData selector)
    {
      try
      {
        this.serviceSWImage.AddHeader("IgnoreMaxVersion", "true");
        List<OtaData> otaDataList = this.SelectOtaImages(selector);
        otaDataList.RemoveAll(new Predicate<OtaData>(this.BasicOtaFilter));
        return otaDataList;
      }
      catch (Exception ex)
      {
        CLogs.E(string.Format("Query nb0 image is failed, selctor: {0}, service: {1}, message: {2}", (object) selector, (object) this.serviceSWImage.Url, (object) ex.Message) + ex.StackTrace);
        throw ex;
      }
      finally
      {
        this.serviceSWImage.ClearHeader();
      }
    }

    private bool BasicOtaFilter(OtaData x)
    {
      string[] strArray = new string[5]
      {
        "InternalModel",
        "ImageID",
        "Version",
        "SubVersion",
        "Platform"
      };
      foreach (string key in strArray)
      {
        if (string.IsNullOrEmpty(x.Get(key)))
          return true;
      }
      return false;
    }

    private List<OtaData> SelectOtaImages(OtaData selector)
    {
      ReturnEntryOfArrayOfArrayOfDictionaryEntry ofDictionaryEntry = this.serviceSWImage.QueryAllImageAction(this.GetNb0Entries(selector));
      return ofDictionaryEntry.Status == MyResources.SWImageService.ErrorCode.Success ? this.SelectOtaImages(new SwImageEntries(ofDictionaryEntry.Value).ToOtaDatas("id")) : throw new CException(1066L, string.Format("Call 'QueryAllImageAction' is failed, selector: {0}, service: {1}, error: {2}", (object) selector.ToString(), (object) this.serviceSWImage.Url, (object) ofDictionaryEntry.Status.ToString()));
    }

    private MyResources.SWImageService.DictionaryEntry[] GetNb0Entries(
      OtaData selector)
    {
      OtaData from = selector.SubData(new string[6]
      {
        "InternalModel",
        "Version",
        "SubVersion",
        "MCC",
        "MNC",
        "SKUID"
      });
      from.Set("DeviceID", selector.Contain("DeviceID") ? selector.Get("DeviceID") : selector.Get("SerialNumber"));
      return new SwImageEntry(from).Instance;
    }

    private List<OtaData> SelectOtaImages(List<OtaData> imageIds)
    {
      List<OtaData> otaDataList = new List<OtaData>();
      foreach (OtaData imageId in imageIds)
        otaDataList.Add(this.SelectOtaImages(imageId.Get("id")));
      return otaDataList;
    }

    private OtaData SelectOtaImages(string id)
    {
      try
      {
        ReturnEntryOfArrayOfArrayOfDictionaryEntry ofDictionaryEntry = this.serviceSWImage.QueryImageData(new string[14]
        {
          "ID",
          "Platform",
          "ImageID",
          "Version",
          "SubVersion",
          "ChannelID",
          "OperatorID",
          "InternalModel",
          "ExternalModel",
          "ExternalVersion",
          "Official",
          "Service",
          "MP",
          "CDAVersion"
        }, string.Format("ID = {0}", (object) id), -1, "");
        if (ofDictionaryEntry.Status != MyResources.SWImageService.ErrorCode.Success)
          throw new CException(1066L, string.Format("Call 'QueryImageData' is failed, id: {0}, service: {1}, error: {2}", (object) id, (object) this.serviceSWImage.Url, (object) ofDictionaryEntry.Status.ToString()));
        if (ofDictionaryEntry.Value.Length != 1)
          throw new CException(1066L, string.Format("Get non-single 'QueryImageData' result, id: {0}, service: {1}", (object) id, (object) this.serviceSWImage.Url));
        return new SwImageEntry(ofDictionaryEntry.Value[0]).ToOtaData();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return new OtaData().Set("ID", id);
      }
    }

    public OtaHandler()
    {
      this.serviceLogin = new LoginServiceEx();
      this.serviceSWImage = new SWImageServiceEx();
      this.serviceFileHandler = new FileHandlerServiceEx();
      this.serviceLog = new LogServiceEx();
      this.serviceLogin.PreAuthenticate = true;
      this.serviceLogin.AllowAutoRedirect = true;
      this.serviceLogin.Credentials = OtaHandler.Credential;
      this.serviceLogin.Proxy = WebRequest.GetSystemWebProxy();
      this.serviceLogin.Proxy.Credentials = (ICredentials) OtaHandler.proxyCredential;
      this.serviceSWImage.PreAuthenticate = true;
      this.serviceSWImage.AllowAutoRedirect = true;
      this.serviceSWImage.Credentials = OtaHandler.Credential;
      this.serviceSWImage.Proxy = WebRequest.GetSystemWebProxy();
      this.serviceSWImage.Proxy.Credentials = (ICredentials) OtaHandler.proxyCredential;
      this.serviceFileHandler.PreAuthenticate = true;
      this.serviceFileHandler.AllowAutoRedirect = true;
      this.serviceFileHandler.Credentials = OtaHandler.Credential;
      this.serviceFileHandler.Proxy = WebRequest.GetSystemWebProxy();
      this.serviceFileHandler.Proxy.Credentials = (ICredentials) OtaHandler.proxyCredential;
      this.serviceLog.PreAuthenticate = true;
      this.serviceLog.AllowAutoRedirect = true;
      this.serviceLog.Credentials = OtaHandler.Credential;
      this.serviceLog.Proxy = WebRequest.GetSystemWebProxy();
      this.serviceLog.Proxy.Credentials = (ICredentials) OtaHandler.proxyCredential;
      this.cookieContainer = new CookieContainer();
      this.serviceLogin.CookieContainer = this.cookieContainer;
      this.serviceSWImage.CookieContainer = this.cookieContainer;
      this.serviceFileHandler.CookieContainer = this.cookieContainer;
      this.serviceLog.CookieContainer = this.cookieContainer;
      this.serviceLogin.Disable100Continue = OtaHandler.disable100Continue;
      this.serviceSWImage.Disable100Continue = OtaHandler.disable100Continue;
      this.serviceFileHandler.Disable100Continue = OtaHandler.disable100Continue;
      this.serviceLog.Disable100Continue = OtaHandler.disable100Continue;
    }

    internal OtaHandler SetUrl(OtaService services)
    {
      this.serviceLogin.Url = services.Login;
      this.serviceSWImage.Url = services.SWImage;
      this.serviceFileHandler.Url = services.FileHandler;
      this.serviceLog.Url = services.Log;
      return this;
    }

    internal OtaHandler SetLoginUrl(string url)
    {
      this.serviceLogin.Url = url;
      return this;
    }

    internal OtaHandler SetLogUrl(string url)
    {
      this.serviceLog.Url = url;
      return this;
    }

    public double Ping(int timeout)
    {
      int timeout1 = this.serviceFileHandler.Timeout;
      this.serviceFileHandler.Timeout = timeout;
      TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
      try
      {
        this.serviceFileHandler.Ping();
        return (new TimeSpan(DateTime.Now.Ticks) - timeSpan).TotalMilliseconds;
      }
      finally
      {
        this.serviceFileHandler.Timeout = timeout1;
      }
    }

    public List<OtaData> QueryToolRights()
    {
      CLogs.I("Query service rights, service: " + new Uri(this.serviceLogin.Url).Host);
      return this.GetOutRights();
    }

    public List<OtaData> QueryServices(string group)
    {
      CLogs.I("Query service group, service: " + new Uri(this.serviceLogin.Url).Host);
      List<string> redirectedUrls;
      List<OtaData> services = this.LoginAsDownloader().GetServices(group, out redirectedUrls);
      foreach (string url in redirectedUrls)
        services.AddRange((IEnumerable<OtaData>) this.SetLoginUrl(url).QueryServices(group));
      return services;
    }

    internal OtaHandler Login(string account, string password)
    {
      MyResources.LoginService.ReturnEntry returnEntry = this.serviceLogin.SetAccount(account, password);
      if (returnEntry.Status != MyResources.LoginService.ErrorCode.Success)
        throw new CException(1069L, string.Format("Call 'SetAccount' is failed, service: {0}, error: {1}", (object) this.serviceLogin.Url, (object) returnEntry.Status.ToString()));
      return this;
    }

    private List<OtaData> GetOutRights()
    {
      MyResources.LoginService.ReturnEntryOfArrayOfDictionaryEntry outAccessRight = this.serviceLogin.GetOutAccessRight();
      return outAccessRight.Status == MyResources.LoginService.ErrorCode.Success ? new LoginEntries(outAccessRight.Value).ToOtaDataList() : throw new CException(1066L, string.Format("Call 'GetOutAccessRight' is failed, service: {0}, error: {1}" + this.serviceLogin.Url, (object) outAccessRight.Status.ToString()));
    }

    private List<OtaData> GetServices(string group, out List<string> redirectedUrls)
    {
      MyResources.LoginService.ReturnEntryOfArrayOfDictionaryEntry serviceGroup = this.serviceLogin.GetServiceGroup(new string[1]
      {
        group
      });
      if (serviceGroup.Status != MyResources.LoginService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'GetServiceGroup' is failed, group: {0}, service: {1}, error: {2}", (object) group, (object) this.serviceLogin.Url, (object) serviceGroup.Status.ToString()));
      return new LoginServiceEntries(serviceGroup.Value).ToWebServices(this.serviceLogin.Url, out redirectedUrls);
    }

    public OtaStream GetOtaStream(string id, bool isDelta, long offset)
    {
      CLogs.I(string.Format("Query image stream, id: {0}, isDelta: {1}, offset:{2}, service: {3}", (object) id, (object) isDelta, (object) offset, (object) this.serviceFileHandler.Url));
      return this.GetStream(id, isDelta, offset);
    }

    internal OtaHandler LoginAsDownloader()
    {
      MyResources.LoginService.ReturnEntry returnEntry = this.serviceLogin.SetAccount("Downloader1", "Downloader1");
      if (returnEntry.Status != MyResources.LoginService.ErrorCode.Success)
        throw new CException(1069L, string.Format("Call 'SetAccount' is failed, service: {0}, error: {1}", (object) this.serviceLogin.Url, (object) returnEntry.Status.ToString()));
      ReturnEntryOfArrayOfString accessRight = this.serviceLogin.GetAccessRight();
      if (accessRight.Status != MyResources.LoginService.ErrorCode.Success)
        throw new CException(1066L, string.Format("Call 'GetAccessRight' is failed, service: {0}, error: {1}", (object) this.serviceLogin.Url, (object) accessRight.Status.ToString()));
      if (!new List<string>((IEnumerable<string>) accessRight.Value).Contains("DLImage"))
        throw new CException(1066L, string.Format("Account does not have corrrect access right, service: {0}", (object) this.serviceLogin.Url));
      return this;
    }

    private OtaStream GetStream(string id, bool isDelta, long offset) => new OtaStream(id, isDelta, offset, (FileHandler) this.serviceFileHandler).SendHttpRequest();
  }
}
