// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.FileHandlerServiceEx
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.FileHandlerService;
using System;
using System.Collections.Specialized;
using System.Net;

namespace MyResources.OtaHandlerService
{
  public class FileHandlerServiceEx : FileHandler
  {
    private bool disable100Continue;
    private NameValueCollection headers = new NameValueCollection();

    public bool Disable100Continue
    {
      set => this.disable100Continue = value;
    }

    public void ClearHeader() => this.headers.Clear();

    public void AddHeader(string name, string value) => this.headers.Add(name, value);

    protected override WebRequest GetWebRequest(Uri uri)
    {
      HttpWebRequest webRequest = (HttpWebRequest) base.GetWebRequest(uri);
      if (this.disable100Continue)
        webRequest.ServicePoint.Expect100Continue = false;
      if (this.headers.Count > 0)
        webRequest.Headers.Add(this.headers);
      return (WebRequest) webRequest;
    }
  }
}
