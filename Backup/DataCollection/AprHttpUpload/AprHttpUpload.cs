// Decompiled with JetBrains decompiler
// Type: DataCollection.AprHttpUpload.AprHttpUpload
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using DataCollection.DataFileCache;
using MyResources.OtaHandlerService;
using System;
using System.IO;
using System.Net;
using System.Text;
using Utils;

namespace DataCollection.AprHttpUpload
{
  internal class AprHttpUpload : IDisposable
  {
    private CollectionFile file;
    private HttpWebRequest webRequest;
    private static string url = "http://apr.c2dms.com/aprlog/fileup.php";
    private static string boundary = "*****";

    public AprHttpUpload(CollectionFile file) => this.file = file;

    public DataCollection.AprHttpUpload.AprHttpUpload UploadFile()
    {
      AprStatus aprStatus = AprStatus.INIT;
      try
      {
        aprStatus = AprStatus.UPLOAD;
        this.Connect().Upload().GetHttpResponse().Dispose();
        aprStatus = AprStatus.DONE;
        return this;
      }
      finally
      {
        switch (aprStatus)
        {
          case AprStatus.UPLOAD:
            if (!string.IsNullOrEmpty(this.file.SourceId))
            {
              this.file.MarkSuspend();
              break;
            }
            goto default;
          case AprStatus.DONE:
            this.file.MarkDone();
            break;
          default:
            this.file.MarkAbort();
            break;
        }
      }
    }

    private DataCollection.AprHttpUpload.AprHttpUpload Connect()
    {
      this.webRequest = (HttpWebRequest) WebRequest.Create(DataCollection.AprHttpUpload.AprHttpUpload.url);
      this.webRequest.ContentType = string.Format("multipart/form-data; boundary={0}", (object) DataCollection.AprHttpUpload.AprHttpUpload.boundary);
      this.webRequest.Method = "POST";
      this.webRequest.ProtocolVersion = HttpVersion.Version10;
      this.webRequest.Timeout = 120000;
      this.webRequest.KeepAlive = true;
      this.webRequest.ServicePoint.Expect100Continue = OtaHandler.Disable100Continue;
      this.webRequest.Credentials = OtaHandler.Credential;
      this.webRequest.Proxy = WebRequest.GetSystemWebProxy();
      this.webRequest.Proxy.Credentials = (ICredentials) OtaHandler.ProxyCredential;
      return this;
    }

    private DataCollection.AprHttpUpload.AprHttpUpload Upload()
    {
      using (Stream requestStream = this.webRequest.GetRequestStream())
      {
        byte[] httpBoundary = this.GetHttpBoundary();
        requestStream.Write(httpBoundary, 0, httpBoundary.Length);
        byte[] httpHeader = this.GetHttpHeader();
        requestStream.Write(httpHeader, 0, httpHeader.Length);
        using (FileStream fileStream = new FileStream(this.file.FilePath, FileMode.Open, FileAccess.Read))
        {
          byte[] buffer = new byte[4096];
          int count;
          while ((count = fileStream.Read(buffer, 0, buffer.Length)) != 0)
          {
            requestStream.Write(buffer, 0, count);
            requestStream.Flush();
          }
          fileStream.Close();
        }
        byte[] httpTrailerBoundary = this.GetHttpTrailerBoundary();
        requestStream.Write(httpTrailerBoundary, 0, httpTrailerBoundary.Length);
        requestStream.Flush();
        requestStream.Close();
      }
      return this;
    }

    private byte[] GetHttpHeader() => Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"uploadedfile\";filename=\"{0}\"\r\n\r\n", (object) this.file.FileName));

    private byte[] GetHttpBoundary() => Encoding.ASCII.GetBytes(string.Format("\r\n--{0}\r\n", (object) DataCollection.AprHttpUpload.AprHttpUpload.boundary));

    private byte[] GetHttpTrailerBoundary() => Encoding.ASCII.GetBytes(string.Format("\r\n--{0}--\r\n", (object) DataCollection.AprHttpUpload.AprHttpUpload.boundary));

    private DataCollection.AprHttpUpload.AprHttpUpload GetHttpResponse()
    {
      WebResponse webResponse = (WebResponse) null;
      try
      {
        webResponse = this.webRequest.GetResponse();
        Stream responseStream = webResponse.GetResponseStream();
        new StreamReader(responseStream).Close();
        responseStream.Close();
        return this;
      }
      catch (WebException ex)
      {
        if (ex.Status != WebExceptionStatus.ProtocolError || !(ex.Response is HttpWebResponse) || ((HttpWebResponse) ex.Response).StatusCode != HttpStatusCode.Conflict)
          throw new CException(1616L, "Get unexpected upload response, excetion: " + ex.ToString());
        CLogs.W(string.Format("{0} is ever uploaded and then delete it.", (object) this.file.FilePath));
        System.IO.File.Delete(this.file.FilePath);
        return this;
      }
      catch (Exception ex)
      {
        throw new CException(1616L, "Get unexpected upload response, excetion: " + ex.ToString());
      }
      finally
      {
        webResponse?.Close();
      }
    }

    public void Dispose()
    {
      try
      {
      }
      finally
      {
        this.webRequest = (HttpWebRequest) null;
      }
    }
  }
}
