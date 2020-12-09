// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.OtaStream
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.FileHandlerService;
using System;
using System.IO;
using System.Net;
using Utils;

namespace MyResources.OtaHandlerService
{
  internal class OtaStream : IDisposable
  {
    private string id;
    private bool isDelta;
    private long fileOffset;
    private FileHandler serviceFileHandler;
    private HttpWebRequest httpRequest;
    private WebResponse httpResponse;
    private Stream httpResponseStream;
    private long length;

    public Stream ResponseStream => this.httpResponseStream;

    public long Length => this.length;

    public OtaStream(string id, bool isDelta, long fileOffset, FileHandler serviceFileHandler)
    {
      this.id = id;
      this.isDelta = isDelta;
      this.fileOffset = fileOffset;
      this.serviceFileHandler = serviceFileHandler;
      this.length = 0L;
    }

    public OtaStream SendHttpRequest()
    {
      try
      {
        string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" + "<soap:Body>" + "<GetFile xmlns=\"http://fihtdc.com/\">" + "<objFileType>" + (this.isDelta ? "SWUpdate" : "SWNb0") + "</objFileType>" + "<strFileID>" + this.id + "</strFileID>" + "<lOffset>" + this.fileOffset.ToString() + "</lOffset>" + "</GetFile>" + "</soap:Body>" + "</soap:Envelope>";
        this.httpRequest = (HttpWebRequest) WebRequest.Create(this.serviceFileHandler.Url);
        this.httpRequest.Method = "POST";
        this.httpRequest.ContentType = "text/xml; charset=utf-8";
        this.httpRequest.ContentLength = (long) str.Length;
        this.httpRequest.Headers.Add("SOAPAction", "http://fihtdc.com/GetFile");
        this.httpRequest.CookieContainer = this.serviceFileHandler.CookieContainer;
        this.httpRequest.KeepAlive = false;
        this.httpRequest.Timeout = this.serviceFileHandler.Timeout;
        this.httpRequest.UserAgent = this.serviceFileHandler.UserAgent;
        this.httpRequest.ProtocolVersion = HttpVersion.Version10;
        this.httpRequest.AllowAutoRedirect = true;
        this.httpRequest.Credentials = this.serviceFileHandler.Credentials;
        this.httpRequest.Proxy = this.serviceFileHandler.Proxy;
        this.httpRequest.Proxy.Credentials = this.serviceFileHandler.Proxy.Credentials;
        StreamWriter streamWriter = new StreamWriter(this.httpRequest.GetRequestStream());
        streamWriter.Write(str);
        streamWriter.Close();
        this.httpResponse = this.httpRequest.GetResponse();
        this.length = this.httpResponse.ContentLength;
        this.httpResponseStream = this.httpResponse.GetResponseStream();
        if (this.httpResponse.Headers["Content-Disposition"] == null)
          throw new CException(1066L, "No 'Content-Disposition' in HTTP response header.");
        return this;
      }
      catch (Exception ex)
      {
        this.Dispose();
        throw ex;
      }
    }

    public void Dispose()
    {
      if (this.httpResponseStream != null)
      {
        try
        {
          this.httpResponseStream.Close();
          this.httpResponse.Close();
        }
        catch
        {
        }
      }
      this.httpResponseStream = (Stream) null;
      this.httpResponse = (WebResponse) null;
      this.httpRequest = (HttpWebRequest) null;
    }
  }
}
