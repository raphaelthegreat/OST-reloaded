// Decompiled with JetBrains decompiler
// Type: MyResources.FileHandlerService.FileHandler
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

namespace MyResources.FileHandlerService
{
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  [XmlInclude(typeof (DictionaryEntry[]))]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [WebServiceBinding(Name = "FileHandlerSoap", Namespace = "http://fihtdc.com/")]
  public class FileHandler : SoapHttpClientProtocol
  {
    private SendOrPostCallback PingOperationCompleted;
    private SendOrPostCallback GetFileChecksumOperationCompleted;
    private SendOrPostCallback GetFileInfoOperationCompleted;
    private SendOrPostCallback GetFileOperationCompleted;
    private SendOrPostCallback UploadFileOperationCompleted;
    private SendOrPostCallback DeleteFileOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public FileHandler()
    {
      this.Url = Settings.Default.MyResources_FileHandlerService_FileHandler;
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

    public event GetFileChecksumCompletedEventHandler GetFileChecksumCompleted;

    public event GetFileInfoCompletedEventHandler GetFileInfoCompleted;

    public event GetFileCompletedEventHandler GetFileCompleted;

    public event UploadFileCompletedEventHandler UploadFileCompleted;

    public event DeleteFileCompletedEventHandler DeleteFileCompleted;

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

    [SoapDocumentMethod("http://fihtdc.com/GetFileChecksum", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString GetFileChecksum(
      FileType objFileType,
      string strFileID,
      long lOffset)
    {
      return (ReturnEntryOfString) this.Invoke(nameof (GetFileChecksum), new object[3]
      {
        (object) objFileType,
        (object) strFileID,
        (object) lOffset
      })[0];
    }

    public void GetFileChecksumAsync(FileType objFileType, string strFileID, long lOffset) => this.GetFileChecksumAsync(objFileType, strFileID, lOffset, (object) null);

    public void GetFileChecksumAsync(
      FileType objFileType,
      string strFileID,
      long lOffset,
      object userState)
    {
      if (this.GetFileChecksumOperationCompleted == null)
        this.GetFileChecksumOperationCompleted = new SendOrPostCallback(this.OnGetFileChecksumOperationCompleted);
      this.InvokeAsync("GetFileChecksum", new object[3]
      {
        (object) objFileType,
        (object) strFileID,
        (object) lOffset
      }, this.GetFileChecksumOperationCompleted, userState);
    }

    private void OnGetFileChecksumOperationCompleted(object arg)
    {
      if (this.GetFileChecksumCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetFileChecksumCompleted((object) this, new GetFileChecksumCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetFileInfo", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry GetFileInfo(
      FileType objFileType,
      string strFileID)
    {
      return (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (GetFileInfo), new object[2]
      {
        (object) objFileType,
        (object) strFileID
      })[0];
    }

    public void GetFileInfoAsync(FileType objFileType, string strFileID) => this.GetFileInfoAsync(objFileType, strFileID, (object) null);

    public void GetFileInfoAsync(FileType objFileType, string strFileID, object userState)
    {
      if (this.GetFileInfoOperationCompleted == null)
        this.GetFileInfoOperationCompleted = new SendOrPostCallback(this.OnGetFileInfoOperationCompleted);
      this.InvokeAsync("GetFileInfo", new object[2]
      {
        (object) objFileType,
        (object) strFileID
      }, this.GetFileInfoOperationCompleted, userState);
    }

    private void OnGetFileInfoOperationCompleted(object arg)
    {
      if (this.GetFileInfoCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetFileInfoCompleted((object) this, new GetFileInfoCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry GetFile(FileType objFileType, string strFileID, long lOffset) => (ReturnEntry) this.Invoke(nameof (GetFile), new object[3]
    {
      (object) objFileType,
      (object) strFileID,
      (object) lOffset
    })[0];

    public void GetFileAsync(FileType objFileType, string strFileID, long lOffset) => this.GetFileAsync(objFileType, strFileID, lOffset, (object) null);

    public void GetFileAsync(
      FileType objFileType,
      string strFileID,
      long lOffset,
      object userState)
    {
      if (this.GetFileOperationCompleted == null)
        this.GetFileOperationCompleted = new SendOrPostCallback(this.OnGetFileOperationCompleted);
      this.InvokeAsync("GetFile", new object[3]
      {
        (object) objFileType,
        (object) strFileID,
        (object) lOffset
      }, this.GetFileOperationCompleted, userState);
    }

    private void OnGetFileOperationCompleted(object arg)
    {
      if (this.GetFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetFileCompleted((object) this, new GetFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/UploadFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry UploadFile(
      FileType objFileType,
      string strFileID,
      [XmlElement(DataType = "base64Binary")] byte[] byData,
      long lOffset,
      long lDataSize)
    {
      return (ReturnEntry) this.Invoke(nameof (UploadFile), new object[5]
      {
        (object) objFileType,
        (object) strFileID,
        (object) byData,
        (object) lOffset,
        (object) lDataSize
      })[0];
    }

    public void UploadFileAsync(
      FileType objFileType,
      string strFileID,
      byte[] byData,
      long lOffset,
      long lDataSize)
    {
      this.UploadFileAsync(objFileType, strFileID, byData, lOffset, lDataSize, (object) null);
    }

    public void UploadFileAsync(
      FileType objFileType,
      string strFileID,
      byte[] byData,
      long lOffset,
      long lDataSize,
      object userState)
    {
      if (this.UploadFileOperationCompleted == null)
        this.UploadFileOperationCompleted = new SendOrPostCallback(this.OnUploadFileOperationCompleted);
      this.InvokeAsync("UploadFile", new object[5]
      {
        (object) objFileType,
        (object) strFileID,
        (object) byData,
        (object) lOffset,
        (object) lDataSize
      }, this.UploadFileOperationCompleted, userState);
    }

    private void OnUploadFileOperationCompleted(object arg)
    {
      if (this.UploadFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UploadFileCompleted((object) this, new UploadFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/DeleteFile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry DeleteFile(FileType objFileType, string strFileID) => (ReturnEntry) this.Invoke(nameof (DeleteFile), new object[2]
    {
      (object) objFileType,
      (object) strFileID
    })[0];

    public void DeleteFileAsync(FileType objFileType, string strFileID) => this.DeleteFileAsync(objFileType, strFileID, (object) null);

    public void DeleteFileAsync(FileType objFileType, string strFileID, object userState)
    {
      if (this.DeleteFileOperationCompleted == null)
        this.DeleteFileOperationCompleted = new SendOrPostCallback(this.OnDeleteFileOperationCompleted);
      this.InvokeAsync("DeleteFile", new object[2]
      {
        (object) objFileType,
        (object) strFileID
      }, this.DeleteFileOperationCompleted, userState);
    }

    private void OnDeleteFileOperationCompleted(object arg)
    {
      if (this.DeleteFileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.DeleteFileCompleted((object) this, new DeleteFileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
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
