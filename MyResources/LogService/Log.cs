// Decompiled with JetBrains decompiler
// Type: MyResources.LogService.Log
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace MyResources.LogService
{
  [WebServiceBinding(Name = "LogSoap", Namespace = "http://fihtdc.com/")]
  [XmlInclude(typeof (DictionaryEntry[]))]
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class Log : SoapHttpClientProtocol
  {
    private SendOrPostCallback PingOperationCompleted;
    private SendOrPostCallback WriteLogMessageOperationCompleted;
    private SendOrPostCallback UploadLogFileOperationCompleted;
    private SendOrPostCallback GetLogFileOperationCompleted;
    private SendOrPostCallback UploadCavisDataOperationCompleted;
    private SendOrPostCallback QueryCaivsDataOperationCompleted;
    private SendOrPostCallback ReportLogOperationCompleted;
    private SendOrPostCallback GetServerTimeOperationCompleted;
    private SendOrPostCallback GetSQLServerTimeOperationCompleted;
    private SendOrPostCallback GetReportFileOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public Log()
    {
      this.Url = Settings.Default.MyResources_LogService_Log;
      if (this.IsLocalFileSystemWebService(this.Url))
      {
        this.UseDefaultCredentials = true;
        this.useDefaultCredentialsSetExplicitly = false;
      }
      else
        this.useDefaultCredentialsSetExplicitly = true;
    }

    public new string Url
    {
      get => base.Url;
      set
      {
        if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
          base.UseDefaultCredentials = false;
        base.Url = value;
      }
    }

    public new bool UseDefaultCredentials
    {
      get => base.UseDefaultCredentials;
      set
      {
        base.UseDefaultCredentials = value;
        this.useDefaultCredentialsSetExplicitly = true;
      }
    }

    public event PingCompletedEventHandler PingCompleted;

    public event WriteLogMessageCompletedEventHandler WriteLogMessageCompleted;

    public event UploadLogFileCompletedEventHandler UploadLogFileCompleted;

    public event GetLogFileCompletedEventHandler GetLogFileCompleted;

    public event UploadCavisDataCompletedEventHandler UploadCavisDataCompleted;

    public event QueryCaivsDataCompletedEventHandler QueryCaivsDataCompleted;

    public event ReportLogCompletedEventHandler ReportLogCompleted;

    public event GetServerTimeCompletedEventHandler GetServerTimeCompleted;

    public event GetSQLServerTimeCompletedEventHandler GetSQLServerTimeCompleted;

    public event GetReportFileCompletedEventHandler GetReportFileCompleted;

    [SoapDocumentMethod("http://fihtdc.com/Ping", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public void Ping() => this.Invoke(nameof (Ping), new object[0]);

    public void PingAsync() => this.PingAsync((object) null);

    public void PingAsync(object userState)
    {
      if (this.PingOperationCompleted == null)
        this.PingOperationCompleted = new SendOrPostCallback(this.OnPingOperationCompleted);
      this.InvokeAsync("Ping", new object[0], this.PingOperationCompleted, userState);
    }

    private void OnPingOperationCompleted(object arg)
    {
      if (this.PingCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.PingCompleted((object) this, new AsyncCompletedEventArgs(completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/WriteLogMessage", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString WriteLogMessage(
      LogFilter objFilter,
      LogLevel objLogLevel,
      string strFileName,
      string strMessage)
    {
      return (ReturnEntryOfString) this.Invoke(nameof (WriteLogMessage), new object[4]
      {
        (object) objFilter,
        (object) objLogLevel,
        (object) strFileName,
        (object) strMessage
      })[0];
    }

    public void WriteLogMessageAsync(
      LogFilter objFilter,
      LogLevel objLogLevel,
      string strFileName,
      string strMessage)
    {
      this.WriteLogMessageAsync(objFilter, objLogLevel, strFileName, strMessage, (object) null);
    }

    public void WriteLogMessageAsync(
      LogFilter objFilter,
      LogLevel objLogLevel,
      string strFileName,
      string strMessage,
      object userState)
    {
      if (this.WriteLogMessageOperationCompleted == null)
        this.WriteLogMessageOperationCompleted = new SendOrPostCallback(this.OnWriteLogMessageOperationCompleted);
      this.InvokeAsync("WriteLogMessage", new object[4]
      {
        (object) objFilter,
        (object) objLogLevel,
        (object) strFileName,
        (object) strMessage
      }, this.WriteLogMessageOperationCompleted, userState);
    }

    private void OnWriteLogMessageOperationCompleted(object arg)
    {
      if (this.WriteLogMessageCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.WriteLogMessageCompleted((object) this, new WriteLogMessageCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/UploadLogFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString UploadLogFile(
      LogFilter objFilter,
      LogLevel objLogLevel,
      [XmlElement(DataType = "base64Binary")] byte[] byData,
      long lOffset,
      long lDataSize)
    {
      return (ReturnEntryOfString) this.Invoke(nameof (UploadLogFile), new object[5]
      {
        (object) objFilter,
        (object) objLogLevel,
        (object) byData,
        (object) lOffset,
        (object) lDataSize
      })[0];
    }

    public void UploadLogFileAsync(
      LogFilter objFilter,
      LogLevel objLogLevel,
      byte[] byData,
      long lOffset,
      long lDataSize)
    {
      this.UploadLogFileAsync(objFilter, objLogLevel, byData, lOffset, lDataSize, (object) null);
    }

    public void UploadLogFileAsync(
      LogFilter objFilter,
      LogLevel objLogLevel,
      byte[] byData,
      long lOffset,
      long lDataSize,
      object userState)
    {
      if (this.UploadLogFileOperationCompleted == null)
        this.UploadLogFileOperationCompleted = new SendOrPostCallback(this.OnUploadLogFileOperationCompleted);
      this.InvokeAsync("UploadLogFile", new object[5]
      {
        (object) objFilter,
        (object) objLogLevel,
        (object) byData,
        (object) lOffset,
        (object) lDataSize
      }, this.UploadLogFileOperationCompleted, userState);
    }

    private void OnUploadLogFileOperationCompleted(object arg)
    {
      if (this.UploadLogFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UploadLogFileCompleted((object) this, new UploadLogFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetLogFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry GetLogFile(
      LogLevel objLogLevel,
      string strFileName,
      long lOffset)
    {
      return (ReturnEntry) this.Invoke(nameof (GetLogFile), new object[3]
      {
        (object) objLogLevel,
        (object) strFileName,
        (object) lOffset
      })[0];
    }

    public void GetLogFileAsync(LogLevel objLogLevel, string strFileName, long lOffset) => this.GetLogFileAsync(objLogLevel, strFileName, lOffset, (object) null);

    public void GetLogFileAsync(
      LogLevel objLogLevel,
      string strFileName,
      long lOffset,
      object userState)
    {
      if (this.GetLogFileOperationCompleted == null)
        this.GetLogFileOperationCompleted = new SendOrPostCallback(this.OnGetLogFileOperationCompleted);
      this.InvokeAsync("GetLogFile", new object[3]
      {
        (object) objLogLevel,
        (object) strFileName,
        (object) lOffset
      }, this.GetLogFileOperationCompleted, userState);
    }

    private void OnGetLogFileOperationCompleted(object arg)
    {
      if (this.GetLogFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetLogFileCompleted((object) this, new GetLogFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/UploadCavisData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString UploadCavisData(string strCavisData) => (ReturnEntryOfString) this.Invoke(nameof (UploadCavisData), new object[1]
    {
      (object) strCavisData
    })[0];

    public void UploadCavisDataAsync(string strCavisData) => this.UploadCavisDataAsync(strCavisData, (object) null);

    public void UploadCavisDataAsync(string strCavisData, object userState)
    {
      if (this.UploadCavisDataOperationCompleted == null)
        this.UploadCavisDataOperationCompleted = new SendOrPostCallback(this.OnUploadCavisDataOperationCompleted);
      this.InvokeAsync("UploadCavisData", new object[1]
      {
        (object) strCavisData
      }, this.UploadCavisDataOperationCompleted, userState);
    }

    private void OnUploadCavisDataOperationCompleted(object arg)
    {
      if (this.UploadCavisDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UploadCavisDataCompleted((object) this, new UploadCavisDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryCaivsData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString QueryCaivsData(
      string strStartDate,
      string strEndDate)
    {
      return (ReturnEntryOfString) this.Invoke(nameof (QueryCaivsData), new object[2]
      {
        (object) strStartDate,
        (object) strEndDate
      })[0];
    }

    public void QueryCaivsDataAsync(string strStartDate, string strEndDate) => this.QueryCaivsDataAsync(strStartDate, strEndDate, (object) null);

    public void QueryCaivsDataAsync(string strStartDate, string strEndDate, object userState)
    {
      if (this.QueryCaivsDataOperationCompleted == null)
        this.QueryCaivsDataOperationCompleted = new SendOrPostCallback(this.OnQueryCaivsDataOperationCompleted);
      this.InvokeAsync("QueryCaivsData", new object[2]
      {
        (object) strStartDate,
        (object) strEndDate
      }, this.QueryCaivsDataOperationCompleted, userState);
    }

    private void OnQueryCaivsDataOperationCompleted(object arg)
    {
      if (this.QueryCaivsDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryCaivsDataCompleted((object) this, new QueryCaivsDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/ReportLog", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry ReportLog(
      LogType objType,
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objID,
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objData,
      bool blReplace)
    {
      return (ReturnEntry) this.Invoke(nameof (ReportLog), new object[4]
      {
        (object) objType,
        (object) objID,
        (object) objData,
        (object) blReplace
      })[0];
    }

    public void ReportLogAsync(
      LogType objType,
      DictionaryEntry[] objID,
      DictionaryEntry[] objData,
      bool blReplace)
    {
      this.ReportLogAsync(objType, objID, objData, blReplace, (object) null);
    }

    public void ReportLogAsync(
      LogType objType,
      DictionaryEntry[] objID,
      DictionaryEntry[] objData,
      bool blReplace,
      object userState)
    {
      if (this.ReportLogOperationCompleted == null)
        this.ReportLogOperationCompleted = new SendOrPostCallback(this.OnReportLogOperationCompleted);
      this.InvokeAsync("ReportLog", new object[4]
      {
        (object) objType,
        (object) objID,
        (object) objData,
        (object) blReplace
      }, this.ReportLogOperationCompleted, userState);
    }

    private void OnReportLogOperationCompleted(object arg)
    {
      if (this.ReportLogCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.ReportLogCompleted((object) this, new ReportLogCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetServerTime", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString GetServerTime() => (ReturnEntryOfString) this.Invoke(nameof (GetServerTime), new object[0])[0];

    public void GetServerTimeAsync() => this.GetServerTimeAsync((object) null);

    public void GetServerTimeAsync(object userState)
    {
      if (this.GetServerTimeOperationCompleted == null)
        this.GetServerTimeOperationCompleted = new SendOrPostCallback(this.OnGetServerTimeOperationCompleted);
      this.InvokeAsync("GetServerTime", new object[0], this.GetServerTimeOperationCompleted, userState);
    }

    private void OnGetServerTimeOperationCompleted(object arg)
    {
      if (this.GetServerTimeCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetServerTimeCompleted((object) this, new GetServerTimeCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetSQLServerTime", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString GetSQLServerTime() => (ReturnEntryOfString) this.Invoke(nameof (GetSQLServerTime), new object[0])[0];

    public void GetSQLServerTimeAsync() => this.GetSQLServerTimeAsync((object) null);

    public void GetSQLServerTimeAsync(object userState)
    {
      if (this.GetSQLServerTimeOperationCompleted == null)
        this.GetSQLServerTimeOperationCompleted = new SendOrPostCallback(this.OnGetSQLServerTimeOperationCompleted);
      this.InvokeAsync("GetSQLServerTime", new object[0], this.GetSQLServerTimeOperationCompleted, userState);
    }

    private void OnGetSQLServerTimeOperationCompleted(object arg)
    {
      if (this.GetSQLServerTimeCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetSQLServerTimeCompleted((object) this, new GetSQLServerTimeCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetReportFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry GetReportFile(
      string strTempFile,
      string[] strStoredProcedureName,
      string[] strTargetSheet,
      string[] strAdditionalFilter)
    {
      return (ReturnEntry) this.Invoke(nameof (GetReportFile), new object[4]
      {
        (object) strTempFile,
        (object) strStoredProcedureName,
        (object) strTargetSheet,
        (object) strAdditionalFilter
      })[0];
    }

    public void GetReportFileAsync(
      string strTempFile,
      string[] strStoredProcedureName,
      string[] strTargetSheet,
      string[] strAdditionalFilter)
    {
      this.GetReportFileAsync(strTempFile, strStoredProcedureName, strTargetSheet, strAdditionalFilter, (object) null);
    }

    public void GetReportFileAsync(
      string strTempFile,
      string[] strStoredProcedureName,
      string[] strTargetSheet,
      string[] strAdditionalFilter,
      object userState)
    {
      if (this.GetReportFileOperationCompleted == null)
        this.GetReportFileOperationCompleted = new SendOrPostCallback(this.OnGetReportFileOperationCompleted);
      this.InvokeAsync("GetReportFile", new object[4]
      {
        (object) strTempFile,
        (object) strStoredProcedureName,
        (object) strTargetSheet,
        (object) strAdditionalFilter
      }, this.GetReportFileOperationCompleted, userState);
    }

    private void OnGetReportFileOperationCompleted(object arg)
    {
      if (this.GetReportFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetReportFileCompleted((object) this, new GetReportFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    public new void CancelAsync(object userState) => base.CancelAsync(userState);

    private bool IsLocalFileSystemWebService(string url)
    {
      if (url == null || url == string.Empty)
        return false;
      Uri uri = new Uri(url);
      return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
    }
  }
}
