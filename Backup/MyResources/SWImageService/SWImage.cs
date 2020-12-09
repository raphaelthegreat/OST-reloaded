// Decompiled with JetBrains decompiler
// Type: MyResources.SWImageService.SWImage
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

namespace MyResources.SWImageService
{
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  [WebServiceBinding(Name = "SWImageSoap", Namespace = "http://fihtdc.com/")]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  public class SWImage : SoapHttpClientProtocol
  {
    private SendOrPostCallback PingOperationCompleted;
    private SendOrPostCallback InsertImageConditionOperationCompleted;
    private SendOrPostCallback DeleteImageConditionOperationCompleted;
    private SendOrPostCallback QueryImageDataOperationCompleted;
    private SendOrPostCallback QueryUpdateDataOperationCompleted;
    private SendOrPostCallback AddImageDataOperationCompleted;
    private SendOrPostCallback AddUpdateDataOperationCompleted;
    private SendOrPostCallback EditImageDataOperationCompleted;
    private SendOrPostCallback EditUpdateDataOperationCompleted;
    private SendOrPostCallback DeleteImageDataOperationCompleted;
    private SendOrPostCallback DeleteUpdateDataOperationCompleted;
    private SendOrPostCallback UpdateImageDescTranslationOperationCompleted;
    private SendOrPostCallback QueryLatestImageOperationCompleted;
    private SendOrPostCallback QueryLatestImageActionOperationCompleted;
    private SendOrPostCallback QueryImageActionsOperationCompleted;
    private SendOrPostCallback QueryAllImageActionOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public SWImage()
    {
      this.Url = Settings.Default.MyResources_SWImageService_SWImage;
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

    public event InsertImageConditionCompletedEventHandler InsertImageConditionCompleted;

    public event DeleteImageConditionCompletedEventHandler DeleteImageConditionCompleted;

    public event QueryImageDataCompletedEventHandler QueryImageDataCompleted;

    public event QueryUpdateDataCompletedEventHandler QueryUpdateDataCompleted;

    public event AddImageDataCompletedEventHandler AddImageDataCompleted;

    public event AddUpdateDataCompletedEventHandler AddUpdateDataCompleted;

    public event EditImageDataCompletedEventHandler EditImageDataCompleted;

    public event EditUpdateDataCompletedEventHandler EditUpdateDataCompleted;

    public event DeleteImageDataCompletedEventHandler DeleteImageDataCompleted;

    public event DeleteUpdateDataCompletedEventHandler DeleteUpdateDataCompleted;

    public event UpdateImageDescTranslationCompletedEventHandler UpdateImageDescTranslationCompleted;

    public event QueryLatestImageCompletedEventHandler QueryLatestImageCompleted;

    public event QueryLatestImageActionCompletedEventHandler QueryLatestImageActionCompleted;

    public event QueryImageActionsCompletedEventHandler QueryImageActionsCompleted;

    public event QueryAllImageActionCompletedEventHandler QueryAllImageActionCompleted;

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

    [SoapDocumentMethod("http://fihtdc.com/InsertImageCondition", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString InsertImageCondition(
      string strProject,
      string strGroupName,
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields)
    {
      return (ReturnEntryOfString) this.Invoke(nameof (InsertImageCondition), new object[3]
      {
        (object) strProject,
        (object) strGroupName,
        (object) objFields
      })[0];
    }

    public void InsertImageConditionAsync(
      string strProject,
      string strGroupName,
      DictionaryEntry[] objFields)
    {
      this.InsertImageConditionAsync(strProject, strGroupName, objFields, (object) null);
    }

    public void InsertImageConditionAsync(
      string strProject,
      string strGroupName,
      DictionaryEntry[] objFields,
      object userState)
    {
      if (this.InsertImageConditionOperationCompleted == null)
        this.InsertImageConditionOperationCompleted = new SendOrPostCallback(this.OnInsertImageConditionOperationCompleted);
      this.InvokeAsync("InsertImageCondition", new object[3]
      {
        (object) strProject,
        (object) strGroupName,
        (object) objFields
      }, this.InsertImageConditionOperationCompleted, userState);
    }

    private void OnInsertImageConditionOperationCompleted(object arg)
    {
      if (this.InsertImageConditionCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertImageConditionCompleted((object) this, new InsertImageConditionCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/DeleteImageCondition", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry DeleteImageCondition(string strImageID) => (ReturnEntry) this.Invoke(nameof (DeleteImageCondition), new object[1]
    {
      (object) strImageID
    })[0];

    public void DeleteImageConditionAsync(string strImageID) => this.DeleteImageConditionAsync(strImageID, (object) null);

    public void DeleteImageConditionAsync(string strImageID, object userState)
    {
      if (this.DeleteImageConditionOperationCompleted == null)
        this.DeleteImageConditionOperationCompleted = new SendOrPostCallback(this.OnDeleteImageConditionOperationCompleted);
      this.InvokeAsync("DeleteImageCondition", new object[1]
      {
        (object) strImageID
      }, this.DeleteImageConditionOperationCompleted, userState);
    }

    private void OnDeleteImageConditionOperationCompleted(object arg)
    {
      if (this.DeleteImageConditionCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.DeleteImageConditionCompleted((object) this, new DeleteImageConditionCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryImageData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfArrayOfDictionaryEntry QueryImageData(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy)
    {
      return (ReturnEntryOfArrayOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryImageData), new object[4]
      {
        (object) objSelectFields,
        (object) strConditions,
        (object) iSelectCount,
        (object) strOrderBy
      })[0];
    }

    public void QueryImageDataAsync(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy)
    {
      this.QueryImageDataAsync(objSelectFields, strConditions, iSelectCount, strOrderBy, (object) null);
    }

    public void QueryImageDataAsync(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy,
      object userState)
    {
      if (this.QueryImageDataOperationCompleted == null)
        this.QueryImageDataOperationCompleted = new SendOrPostCallback(this.OnQueryImageDataOperationCompleted);
      this.InvokeAsync("QueryImageData", new object[4]
      {
        (object) objSelectFields,
        (object) strConditions,
        (object) iSelectCount,
        (object) strOrderBy
      }, this.QueryImageDataOperationCompleted, userState);
    }

    private void OnQueryImageDataOperationCompleted(object arg)
    {
      if (this.QueryImageDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryImageDataCompleted((object) this, new QueryImageDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryUpdateData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfArrayOfDictionaryEntry QueryUpdateData(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy)
    {
      return (ReturnEntryOfArrayOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryUpdateData), new object[4]
      {
        (object) objSelectFields,
        (object) strConditions,
        (object) iSelectCount,
        (object) strOrderBy
      })[0];
    }

    public void QueryUpdateDataAsync(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy)
    {
      this.QueryUpdateDataAsync(objSelectFields, strConditions, iSelectCount, strOrderBy, (object) null);
    }

    public void QueryUpdateDataAsync(
      string[] objSelectFields,
      string strConditions,
      int iSelectCount,
      string strOrderBy,
      object userState)
    {
      if (this.QueryUpdateDataOperationCompleted == null)
        this.QueryUpdateDataOperationCompleted = new SendOrPostCallback(this.OnQueryUpdateDataOperationCompleted);
      this.InvokeAsync("QueryUpdateData", new object[4]
      {
        (object) objSelectFields,
        (object) strConditions,
        (object) iSelectCount,
        (object) strOrderBy
      }, this.QueryUpdateDataOperationCompleted, userState);
    }

    private void OnQueryUpdateDataOperationCompleted(object arg)
    {
      if (this.QueryUpdateDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryUpdateDataCompleted((object) this, new QueryUpdateDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/AddImageData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString AddImageData([XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields) => (ReturnEntryOfString) this.Invoke(nameof (AddImageData), new object[1]
    {
      (object) objFields
    })[0];

    public void AddImageDataAsync(DictionaryEntry[] objFields) => this.AddImageDataAsync(objFields, (object) null);

    public void AddImageDataAsync(DictionaryEntry[] objFields, object userState)
    {
      if (this.AddImageDataOperationCompleted == null)
        this.AddImageDataOperationCompleted = new SendOrPostCallback(this.OnAddImageDataOperationCompleted);
      this.InvokeAsync("AddImageData", new object[1]
      {
        (object) objFields
      }, this.AddImageDataOperationCompleted, userState);
    }

    private void OnAddImageDataOperationCompleted(object arg)
    {
      if (this.AddImageDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddImageDataCompleted((object) this, new AddImageDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/AddUpdateData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString AddUpdateData([XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields) => (ReturnEntryOfString) this.Invoke(nameof (AddUpdateData), new object[1]
    {
      (object) objFields
    })[0];

    public void AddUpdateDataAsync(DictionaryEntry[] objFields) => this.AddUpdateDataAsync(objFields, (object) null);

    public void AddUpdateDataAsync(DictionaryEntry[] objFields, object userState)
    {
      if (this.AddUpdateDataOperationCompleted == null)
        this.AddUpdateDataOperationCompleted = new SendOrPostCallback(this.OnAddUpdateDataOperationCompleted);
      this.InvokeAsync("AddUpdateData", new object[1]
      {
        (object) objFields
      }, this.AddUpdateDataOperationCompleted, userState);
    }

    private void OnAddUpdateDataOperationCompleted(object arg)
    {
      if (this.AddUpdateDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddUpdateDataCompleted((object) this, new AddUpdateDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/EditImageData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry EditImageData(string strID, [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields) => (ReturnEntry) this.Invoke(nameof (EditImageData), new object[2]
    {
      (object) strID,
      (object) objFields
    })[0];

    public void EditImageDataAsync(string strID, DictionaryEntry[] objFields) => this.EditImageDataAsync(strID, objFields, (object) null);

    public void EditImageDataAsync(string strID, DictionaryEntry[] objFields, object userState)
    {
      if (this.EditImageDataOperationCompleted == null)
        this.EditImageDataOperationCompleted = new SendOrPostCallback(this.OnEditImageDataOperationCompleted);
      this.InvokeAsync("EditImageData", new object[2]
      {
        (object) strID,
        (object) objFields
      }, this.EditImageDataOperationCompleted, userState);
    }

    private void OnEditImageDataOperationCompleted(object arg)
    {
      if (this.EditImageDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.EditImageDataCompleted((object) this, new EditImageDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/EditUpdateData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry EditUpdateData(string strID, [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields) => (ReturnEntry) this.Invoke(nameof (EditUpdateData), new object[2]
    {
      (object) strID,
      (object) objFields
    })[0];

    public void EditUpdateDataAsync(string strID, DictionaryEntry[] objFields) => this.EditUpdateDataAsync(strID, objFields, (object) null);

    public void EditUpdateDataAsync(string strID, DictionaryEntry[] objFields, object userState)
    {
      if (this.EditUpdateDataOperationCompleted == null)
        this.EditUpdateDataOperationCompleted = new SendOrPostCallback(this.OnEditUpdateDataOperationCompleted);
      this.InvokeAsync("EditUpdateData", new object[2]
      {
        (object) strID,
        (object) objFields
      }, this.EditUpdateDataOperationCompleted, userState);
    }

    private void OnEditUpdateDataOperationCompleted(object arg)
    {
      if (this.EditUpdateDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.EditUpdateDataCompleted((object) this, new EditUpdateDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/DeleteImageData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry DeleteImageData(string strID) => (ReturnEntry) this.Invoke(nameof (DeleteImageData), new object[1]
    {
      (object) strID
    })[0];

    public void DeleteImageDataAsync(string strID) => this.DeleteImageDataAsync(strID, (object) null);

    public void DeleteImageDataAsync(string strID, object userState)
    {
      if (this.DeleteImageDataOperationCompleted == null)
        this.DeleteImageDataOperationCompleted = new SendOrPostCallback(this.OnDeleteImageDataOperationCompleted);
      this.InvokeAsync("DeleteImageData", new object[1]
      {
        (object) strID
      }, this.DeleteImageDataOperationCompleted, userState);
    }

    private void OnDeleteImageDataOperationCompleted(object arg)
    {
      if (this.DeleteImageDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.DeleteImageDataCompleted((object) this, new DeleteImageDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/DeleteUpdateData", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry DeleteUpdateData(string strID) => (ReturnEntry) this.Invoke(nameof (DeleteUpdateData), new object[1]
    {
      (object) strID
    })[0];

    public void DeleteUpdateDataAsync(string strID) => this.DeleteUpdateDataAsync(strID, (object) null);

    public void DeleteUpdateDataAsync(string strID, object userState)
    {
      if (this.DeleteUpdateDataOperationCompleted == null)
        this.DeleteUpdateDataOperationCompleted = new SendOrPostCallback(this.OnDeleteUpdateDataOperationCompleted);
      this.InvokeAsync("DeleteUpdateData", new object[1]
      {
        (object) strID
      }, this.DeleteUpdateDataOperationCompleted, userState);
    }

    private void OnDeleteUpdateDataOperationCompleted(object arg)
    {
      if (this.DeleteUpdateDataCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.DeleteUpdateDataCompleted((object) this, new DeleteUpdateDataCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/UpdateImageDescTranslation", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry UpdateImageDescTranslation(
      string strID,
      string strLocate,
      string strDescription)
    {
      return (ReturnEntry) this.Invoke(nameof (UpdateImageDescTranslation), new object[3]
      {
        (object) strID,
        (object) strLocate,
        (object) strDescription
      })[0];
    }

    public void UpdateImageDescTranslationAsync(
      string strID,
      string strLocate,
      string strDescription)
    {
      this.UpdateImageDescTranslationAsync(strID, strLocate, strDescription, (object) null);
    }

    public void UpdateImageDescTranslationAsync(
      string strID,
      string strLocate,
      string strDescription,
      object userState)
    {
      if (this.UpdateImageDescTranslationOperationCompleted == null)
        this.UpdateImageDescTranslationOperationCompleted = new SendOrPostCallback(this.OnUpdateImageDescTranslationOperationCompleted);
      this.InvokeAsync("UpdateImageDescTranslation", new object[3]
      {
        (object) strID,
        (object) strLocate,
        (object) strDescription
      }, this.UpdateImageDescTranslationOperationCompleted, userState);
    }

    private void OnUpdateImageDescTranslationOperationCompleted(object arg)
    {
      if (this.UpdateImageDescTranslationCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UpdateImageDescTranslationCompleted((object) this, new UpdateImageDescTranslationCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryLatestImage", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfInt64 QueryLatestImage([XmlArrayItem(IsNullable = false)] DictionaryEntry[] objConditions) => (ReturnEntryOfInt64) this.Invoke(nameof (QueryLatestImage), new object[1]
    {
      (object) objConditions
    })[0];

    public void QueryLatestImageAsync(DictionaryEntry[] objConditions) => this.QueryLatestImageAsync(objConditions, (object) null);

    public void QueryLatestImageAsync(DictionaryEntry[] objConditions, object userState)
    {
      if (this.QueryLatestImageOperationCompleted == null)
        this.QueryLatestImageOperationCompleted = new SendOrPostCallback(this.OnQueryLatestImageOperationCompleted);
      this.InvokeAsync("QueryLatestImage", new object[1]
      {
        (object) objConditions
      }, this.QueryLatestImageOperationCompleted, userState);
    }

    private void OnQueryLatestImageOperationCompleted(object arg)
    {
      if (this.QueryLatestImageCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryLatestImageCompleted((object) this, new QueryLatestImageCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryLatestImageAction", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry QueryLatestImageAction(
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objConditions)
    {
      return (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryLatestImageAction), new object[1]
      {
        (object) objConditions
      })[0];
    }

    public void QueryLatestImageActionAsync(DictionaryEntry[] objConditions) => this.QueryLatestImageActionAsync(objConditions, (object) null);

    public void QueryLatestImageActionAsync(DictionaryEntry[] objConditions, object userState)
    {
      if (this.QueryLatestImageActionOperationCompleted == null)
        this.QueryLatestImageActionOperationCompleted = new SendOrPostCallback(this.OnQueryLatestImageActionOperationCompleted);
      this.InvokeAsync("QueryLatestImageAction", new object[1]
      {
        (object) objConditions
      }, this.QueryLatestImageActionOperationCompleted, userState);
    }

    private void OnQueryLatestImageActionOperationCompleted(object arg)
    {
      if (this.QueryLatestImageActionCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryLatestImageActionCompleted((object) this, new QueryLatestImageActionCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryImageActions", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry QueryImageActions(
      string strID,
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objConditions)
    {
      return (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryImageActions), new object[2]
      {
        (object) strID,
        (object) objConditions
      })[0];
    }

    public void QueryImageActionsAsync(string strID, DictionaryEntry[] objConditions) => this.QueryImageActionsAsync(strID, objConditions, (object) null);

    public void QueryImageActionsAsync(
      string strID,
      DictionaryEntry[] objConditions,
      object userState)
    {
      if (this.QueryImageActionsOperationCompleted == null)
        this.QueryImageActionsOperationCompleted = new SendOrPostCallback(this.OnQueryImageActionsOperationCompleted);
      this.InvokeAsync("QueryImageActions", new object[2]
      {
        (object) strID,
        (object) objConditions
      }, this.QueryImageActionsOperationCompleted, userState);
    }

    private void OnQueryImageActionsOperationCompleted(object arg)
    {
      if (this.QueryImageActionsCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryImageActionsCompleted((object) this, new QueryImageActionsCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryAllImageAction", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfArrayOfDictionaryEntry QueryAllImageAction(
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] objConditions)
    {
      return (ReturnEntryOfArrayOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryAllImageAction), new object[1]
      {
        (object) objConditions
      })[0];
    }

    public void QueryAllImageActionAsync(DictionaryEntry[] objConditions) => this.QueryAllImageActionAsync(objConditions, (object) null);

    public void QueryAllImageActionAsync(DictionaryEntry[] objConditions, object userState)
    {
      if (this.QueryAllImageActionOperationCompleted == null)
        this.QueryAllImageActionOperationCompleted = new SendOrPostCallback(this.OnQueryAllImageActionOperationCompleted);
      this.InvokeAsync("QueryAllImageAction", new object[1]
      {
        (object) objConditions
      }, this.QueryAllImageActionOperationCompleted, userState);
    }

    private void OnQueryAllImageActionOperationCompleted(object arg)
    {
      if (this.QueryAllImageActionCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryAllImageActionCompleted((object) this, new QueryAllImageActionCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
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
