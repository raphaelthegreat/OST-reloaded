// Decompiled with JetBrains decompiler
// Type: Utils.HttpUtil
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading;
using UserConfigs;
using UserForms;

namespace Utils
{
  internal class HttpUtil
  {
    private static bool disable100Continue;
    private CredentialCache cache;
    private NetworkCredential proxyCredential;

    public HttpUtil()
    {
      this.cache = (CredentialCache) null;
      this.proxyCredential = (NetworkCredential) null;
      HttpUtil.disable100Continue = false;
    }

    public bool DoWebRequest(
      string webMethod,
      string sUrl,
      string paramJsonStr,
      Dictionary<string, string> dicRequestHeaders,
      ref webResponseObject webResponse)
    {
      CLogs.I_encrypted(string.Format("[REQUEST METHOD] {0}", (object) webMethod));
      CLogs.I_encrypted(string.Format("[REQUEST URL] {0}", (object) sUrl));
      if (paramJsonStr.Contains("password"))
      {
        string[] strArray = paramJsonStr.Split(',');
        CLogs.I_encrypted(string.Format("[REQUEST PARAMETER] {0}, {1}", (object) strArray[0], (object) strArray[2]));
      }
      else if (paramJsonStr.Contains("SimUnlockCode"))
        CLogs.I_encrypted(string.Format("[REQUEST PARAMETER] {0}", (object) RsaCrypt.EncryptLog(paramJsonStr)));
      else
        CLogs.I_encrypted(string.Format("[REQUEST PARAMETER] {0}", (object) paramJsonStr));
      try
      {
        HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(sUrl)) as HttpWebRequest;
        httpWebRequest.Method = webMethod;
        httpWebRequest.ProtocolVersion = HttpVersion.Version10;
        httpWebRequest.KeepAlive = true;
        httpWebRequest.ContentType = "application/json; charset=utf-8";
        httpWebRequest.ProtocolVersion = HttpVersion.Version11;
        httpWebRequest.AllowAutoRedirect = true;
        httpWebRequest.PreAuthenticate = true;
        httpWebRequest.CookieContainer = new CookieContainer();
        httpWebRequest.ServicePoint.Expect100Continue = !HttpUtil.disable100Continue;
        if (dicRequestHeaders != null && dicRequestHeaders.Count > 0)
        {
          WebHeaderCollection headers = httpWebRequest.Headers;
          foreach (string key in dicRequestHeaders.Keys)
          {
            switch (key)
            {
              case "Authorization":
              case "X-HWID":
                headers.Set(key, dicRequestHeaders[key]);
                continue;
              default:
                continue;
            }
          }
        }
        if (this.cache != null)
          httpWebRequest.Credentials = (ICredentials) this.cache;
        else
          httpWebRequest.Credentials = (ICredentials) CredentialCache.DefaultNetworkCredentials;
        httpWebRequest.Proxy = WebRequest.GetSystemWebProxy();
        if (this.proxyCredential != null)
          httpWebRequest.Proxy.Credentials = (ICredentials) this.proxyCredential;
        else
          httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
        if (webMethod == "POST")
        {
          using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
          {
            streamWriter.Write(paramJsonStr);
            streamWriter.Flush();
          }
        }
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string header in (NameObjectCollectionBase) response.Headers)
          dictionary.Add(header, response.Headers[header]);
        CLogs.I_encrypted("[RESPONSE HEADER] {0}", (object) JsonConvert.SerializeObject((object) dictionary, Formatting.Indented).Replace(Environment.NewLine, ""));
        if (response.StatusCode != HttpStatusCode.OK)
          throw new Exception("Get failed HTTP status: " + response.StatusCode.ToString());
        string jsonString = "";
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
          jsonString = streamReader.ReadToEnd();
        webResponse.loadJsonString(jsonString);
      }
      catch (WebException ex)
      {
        CLogs.E(ex.Message);
        if (!this.HandleWebException(ex))
          return false;
        Thread.Sleep(100);
        CLogs.W("Query rights from server fails and then retry again.");
        return this.DoWebRequest(webMethod, sUrl, paramJsonStr, dicRequestHeaders, ref webResponse);
      }
      return true;
    }

    private bool HandleWebException(WebException ex)
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
      if (this.cache == null)
        this.cache = new CredentialCache();
      string str2 = str1;
      char[] chArray = new char[1]{ ',' };
      foreach (string authType in str2.Split(chArray))
      {
        this.cache.Remove(response.ResponseUri, authType);
        this.cache.Add(response.ResponseUri, authType, new NetworkCredential(authUsername, empty, authDomain));
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
      this.proxyCredential = new NetworkCredential(proxyAuthUsername, empty, proxyAuthDomain);
      return true;
    }

    public bool Handle100Continue()
    {
      if (HttpUtil.disable100Continue)
        return false;
      CLogs.I("Handle http exception: disable 100 continue.");
      HttpUtil.disable100Continue = true;
      return true;
    }
  }
}
