// Decompiled with JetBrains decompiler
// Type: Tasks.ImageRequest
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.OtaHandlerService;
using OtaControl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Utils;

namespace Tasks
{
  public class ImageRequest
  {
    private OtaData phone;
    private OtaRight right;
    private bool deltaIncluded;
    private ManualResetEvent doneEvent;
    private OtaService webService;
    private List<OtaData> images;
    private long result;
    private static object thisLock = new object();

    public ManualResetEvent DoneEvent => this.doneEvent;

    public OtaService WebService => this.webService;

    public List<OtaData> Images => this.images;

    public long Result => this.result;

    public ImageRequest(OtaData phone, OtaRight right, OtaService webService, bool deltaIncluded)
    {
      this.phone = phone;
      this.right = right;
      this.webService = webService;
      this.deltaIncluded = deltaIncluded;
      this.doneEvent = new ManualResetEvent(false);
      this.images = new List<OtaData>();
      this.result = 0L;
    }

    private OtaHandler DoApartmentLogin()
    {
      lock (ImageRequest.thisLock)
      {
        try
        {
          return this.DoLogin();
        }
        catch (CException ex)
        {
          this.result = ex.CResult;
          CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        }
        catch (Exception ex)
        {
          this.result = 1064L;
          CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        }
      }
      return (OtaHandler) null;
    }

    private OtaHandler DoLogin()
    {
      try
      {
        return this.DoLoginIns();
      }
      catch (WebException ex)
      {
        if (!new OtaHandler().HandleWebException(ex))
          throw ex;
        Thread.Sleep(100);
        CLogs.W("Connect to remote server fails and then retry again.");
        return this.DoLogin();
      }
    }

    private OtaHandler DoLoginIns() => new OtaHandler().SetUrl(this.webService).LoginAsDownloader();

    public void ThreadPoolCallback(object state)
    {
      this.DoImageRequest();
      this.doneEvent.Set();
    }

    public void DoImageRequest()
    {
      TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
      try
      {
        CLogs.I("Query OTA images, service: " + new Uri(this.webService.SWImage).Host);
        OtaHandler otaHandler = this.DoApartmentLogin();
        if (otaHandler == null)
          return;
        this.images.AddRange((IEnumerable<OtaData>) this.right.Apply(this.phone, otaHandler.QueryOtaImages(this.phone)));
      }
      catch (CException ex)
      {
        this.result = ex.CResult;
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      catch (Exception ex)
      {
        this.result = 1064L;
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        this.webService.Timeout = (new TimeSpan(DateTime.Now.Ticks) - timeSpan).TotalMilliseconds;
      }
    }
  }
}
