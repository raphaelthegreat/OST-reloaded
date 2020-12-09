// Decompiled with JetBrains decompiler
// Type: MyResources.LoginService.Login
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

namespace MyResources.LoginService
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [WebServiceBinding(Name = "LoginSoap", Namespace = "http://fihtdc.com/")]
  [XmlInclude(typeof (DictionaryEntry[]))]
  [GeneratedCode("System.Web.Services", "2.0.50727.3053")]
  public class Login : SoapHttpClientProtocol
  {
    private SendOrPostCallback PingOperationCompleted;
    private SendOrPostCallback GetPasswordSeedOperationCompleted;
    private SendOrPostCallback SetAccountOperationCompleted;
    private SendOrPostCallback GetServiceURLOperationCompleted;
    private SendOrPostCallback GetServiceGroupOperationCompleted;
    private SendOrPostCallback GetMinToolVerOperationCompleted;
    private SendOrPostCallback GetAccessRightOperationCompleted;
    private SendOrPostCallback GetOutAccessRightOperationCompleted;
    private SendOrPostCallback AccountRegisterOperationCompleted;
    private SendOrPostCallback ServicesRegisterOperationCompleted;
    private SendOrPostCallback QueryProfileOperationCompleted;
    private SendOrPostCallback ModifyProfileOperationCompleted;
    private SendOrPostCallback SendMailToSelfOperationCompleted;
    private SendOrPostCallback SendPasswordToMailOperationCompleted;
    private SendOrPostCallback SendActivateToMailOperationCompleted;
    private SendOrPostCallback CheckAccountAvailabilityOperationCompleted;
    private SendOrPostCallback IsActivatedOperationCompleted;
    private SendOrPostCallback IsActivatedWithUserIDOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public Login()
    {
      this.Url = Settings.Default.MyResources_LoginService_Login;
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

    public event GetPasswordSeedCompletedEventHandler GetPasswordSeedCompleted;

    public event SetAccountCompletedEventHandler SetAccountCompleted;

    public event GetServiceURLCompletedEventHandler GetServiceURLCompleted;

    public event GetServiceGroupCompletedEventHandler GetServiceGroupCompleted;

    public event GetMinToolVerCompletedEventHandler GetMinToolVerCompleted;

    public event GetAccessRightCompletedEventHandler GetAccessRightCompleted;

    public event GetOutAccessRightCompletedEventHandler GetOutAccessRightCompleted;

    public event AccountRegisterCompletedEventHandler AccountRegisterCompleted;

    public event ServicesRegisterCompletedEventHandler ServicesRegisterCompleted;

    public event QueryProfileCompletedEventHandler QueryProfileCompleted;

    public event ModifyProfileCompletedEventHandler ModifyProfileCompleted;

    public event SendMailToSelfCompletedEventHandler SendMailToSelfCompleted;

    public event SendPasswordToMailCompletedEventHandler SendPasswordToMailCompleted;

    public event SendActivateToMailCompletedEventHandler SendActivateToMailCompleted;

    public event CheckAccountAvailabilityCompletedEventHandler CheckAccountAvailabilityCompleted;

    public event IsActivatedCompletedEventHandler IsActivatedCompleted;

    public event IsActivatedWithUserIDCompletedEventHandler IsActivatedWithUserIDCompleted;

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

    [SoapDocumentMethod("http://fihtdc.com/GetPasswordSeed", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString GetPasswordSeed() => (ReturnEntryOfString) this.Invoke(nameof (GetPasswordSeed), new object[0])[0];

    public void GetPasswordSeedAsync() => this.GetPasswordSeedAsync((object) null);

    public void GetPasswordSeedAsync(object userState)
    {
      if (this.GetPasswordSeedOperationCompleted == null)
        this.GetPasswordSeedOperationCompleted = new SendOrPostCallback(this.OnGetPasswordSeedOperationCompleted);
      this.InvokeAsync("GetPasswordSeed", new object[0], this.GetPasswordSeedOperationCompleted, userState);
    }

    private void OnGetPasswordSeedOperationCompleted(object arg)
    {
      if (this.GetPasswordSeedCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetPasswordSeedCompleted((object) this, new GetPasswordSeedCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/SetAccount", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry SetAccount(string strUserID, string strPassword) => (ReturnEntry) this.Invoke(nameof (SetAccount), new object[2]
    {
      (object) strUserID,
      (object) strPassword
    })[0];

    public void SetAccountAsync(string strUserID, string strPassword) => this.SetAccountAsync(strUserID, strPassword, (object) null);

    public void SetAccountAsync(string strUserID, string strPassword, object userState)
    {
      if (this.SetAccountOperationCompleted == null)
        this.SetAccountOperationCompleted = new SendOrPostCallback(this.OnSetAccountOperationCompleted);
      this.InvokeAsync("SetAccount", new object[2]
      {
        (object) strUserID,
        (object) strPassword
      }, this.SetAccountOperationCompleted, userState);
    }

    private void OnSetAccountOperationCompleted(object arg)
    {
      if (this.SetAccountCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SetAccountCompleted((object) this, new SetAccountCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetServiceURL", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry GetServiceURL() => (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (GetServiceURL), new object[0])[0];

    public void GetServiceURLAsync() => this.GetServiceURLAsync((object) null);

    public void GetServiceURLAsync(object userState)
    {
      if (this.GetServiceURLOperationCompleted == null)
        this.GetServiceURLOperationCompleted = new SendOrPostCallback(this.OnGetServiceURLOperationCompleted);
      this.InvokeAsync("GetServiceURL", new object[0], this.GetServiceURLOperationCompleted, userState);
    }

    private void OnGetServiceURLOperationCompleted(object arg)
    {
      if (this.GetServiceURLCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetServiceURLCompleted((object) this, new GetServiceURLCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetServiceGroup", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry GetServiceGroup(
      string[] ServiceGroups)
    {
      return (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (GetServiceGroup), new object[1]
      {
        (object) ServiceGroups
      })[0];
    }

    public void GetServiceGroupAsync(string[] ServiceGroups) => this.GetServiceGroupAsync(ServiceGroups, (object) null);

    public void GetServiceGroupAsync(string[] ServiceGroups, object userState)
    {
      if (this.GetServiceGroupOperationCompleted == null)
        this.GetServiceGroupOperationCompleted = new SendOrPostCallback(this.OnGetServiceGroupOperationCompleted);
      this.InvokeAsync("GetServiceGroup", new object[1]
      {
        (object) ServiceGroups
      }, this.GetServiceGroupOperationCompleted, userState);
    }

    private void OnGetServiceGroupOperationCompleted(object arg)
    {
      if (this.GetServiceGroupCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetServiceGroupCompleted((object) this, new GetServiceGroupCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetMinToolVer", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfString GetMinToolVer(string strID) => (ReturnEntryOfString) this.Invoke(nameof (GetMinToolVer), new object[1]
    {
      (object) strID
    })[0];

    public void GetMinToolVerAsync(string strID) => this.GetMinToolVerAsync(strID, (object) null);

    public void GetMinToolVerAsync(string strID, object userState)
    {
      if (this.GetMinToolVerOperationCompleted == null)
        this.GetMinToolVerOperationCompleted = new SendOrPostCallback(this.OnGetMinToolVerOperationCompleted);
      this.InvokeAsync("GetMinToolVer", new object[1]
      {
        (object) strID
      }, this.GetMinToolVerOperationCompleted, userState);
    }

    private void OnGetMinToolVerOperationCompleted(object arg)
    {
      if (this.GetMinToolVerCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetMinToolVerCompleted((object) this, new GetMinToolVerCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetAccessRight", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfString GetAccessRight() => (ReturnEntryOfArrayOfString) this.Invoke(nameof (GetAccessRight), new object[0])[0];

    public void GetAccessRightAsync() => this.GetAccessRightAsync((object) null);

    public void GetAccessRightAsync(object userState)
    {
      if (this.GetAccessRightOperationCompleted == null)
        this.GetAccessRightOperationCompleted = new SendOrPostCallback(this.OnGetAccessRightOperationCompleted);
      this.InvokeAsync("GetAccessRight", new object[0], this.GetAccessRightOperationCompleted, userState);
    }

    private void OnGetAccessRightOperationCompleted(object arg)
    {
      if (this.GetAccessRightCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetAccessRightCompleted((object) this, new GetAccessRightCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/GetOutAccessRight", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry GetOutAccessRight() => (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (GetOutAccessRight), new object[0])[0];

    public void GetOutAccessRightAsync() => this.GetOutAccessRightAsync((object) null);

    public void GetOutAccessRightAsync(object userState)
    {
      if (this.GetOutAccessRightOperationCompleted == null)
        this.GetOutAccessRightOperationCompleted = new SendOrPostCallback(this.OnGetOutAccessRightOperationCompleted);
      this.InvokeAsync("GetOutAccessRight", new object[0], this.GetOutAccessRightOperationCompleted, userState);
    }

    private void OnGetOutAccessRightOperationCompleted(object arg)
    {
      if (this.GetOutAccessRightCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetOutAccessRightCompleted((object) this, new GetOutAccessRightCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/AccountRegister", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry AccountRegister(
      string userID,
      string password,
      [XmlArrayItem(IsNullable = false)] DictionaryEntry[] AdditionalProperties)
    {
      return (ReturnEntry) this.Invoke(nameof (AccountRegister), new object[3]
      {
        (object) userID,
        (object) password,
        (object) AdditionalProperties
      })[0];
    }

    public void AccountRegisterAsync(
      string userID,
      string password,
      DictionaryEntry[] AdditionalProperties)
    {
      this.AccountRegisterAsync(userID, password, AdditionalProperties, (object) null);
    }

    public void AccountRegisterAsync(
      string userID,
      string password,
      DictionaryEntry[] AdditionalProperties,
      object userState)
    {
      if (this.AccountRegisterOperationCompleted == null)
        this.AccountRegisterOperationCompleted = new SendOrPostCallback(this.OnAccountRegisterOperationCompleted);
      this.InvokeAsync("AccountRegister", new object[3]
      {
        (object) userID,
        (object) password,
        (object) AdditionalProperties
      }, this.AccountRegisterOperationCompleted, userState);
    }

    private void OnAccountRegisterOperationCompleted(object arg)
    {
      if (this.AccountRegisterCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AccountRegisterCompleted((object) this, new AccountRegisterCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/ServicesRegister", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry ServicesRegister(string ServiceName) => (ReturnEntry) this.Invoke(nameof (ServicesRegister), new object[1]
    {
      (object) ServiceName
    })[0];

    public void ServicesRegisterAsync(string ServiceName) => this.ServicesRegisterAsync(ServiceName, (object) null);

    public void ServicesRegisterAsync(string ServiceName, object userState)
    {
      if (this.ServicesRegisterOperationCompleted == null)
        this.ServicesRegisterOperationCompleted = new SendOrPostCallback(this.OnServicesRegisterOperationCompleted);
      this.InvokeAsync("ServicesRegister", new object[1]
      {
        (object) ServiceName
      }, this.ServicesRegisterOperationCompleted, userState);
    }

    private void OnServicesRegisterOperationCompleted(object arg)
    {
      if (this.ServicesRegisterCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.ServicesRegisterCompleted((object) this, new ServicesRegisterCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/QueryProfile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntryOfArrayOfDictionaryEntry QueryProfile(
      string[] objSelectFields)
    {
      return (ReturnEntryOfArrayOfDictionaryEntry) this.Invoke(nameof (QueryProfile), new object[1]
      {
        (object) objSelectFields
      })[0];
    }

    public void QueryProfileAsync(string[] objSelectFields) => this.QueryProfileAsync(objSelectFields, (object) null);

    public void QueryProfileAsync(string[] objSelectFields, object userState)
    {
      if (this.QueryProfileOperationCompleted == null)
        this.QueryProfileOperationCompleted = new SendOrPostCallback(this.OnQueryProfileOperationCompleted);
      this.InvokeAsync("QueryProfile", new object[1]
      {
        (object) objSelectFields
      }, this.QueryProfileOperationCompleted, userState);
    }

    private void OnQueryProfileOperationCompleted(object arg)
    {
      if (this.QueryProfileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.QueryProfileCompleted((object) this, new QueryProfileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/ModifyProfile", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry ModifyProfile([XmlArrayItem(IsNullable = false)] DictionaryEntry[] objFields) => (ReturnEntry) this.Invoke(nameof (ModifyProfile), new object[1]
    {
      (object) objFields
    })[0];

    public void ModifyProfileAsync(DictionaryEntry[] objFields) => this.ModifyProfileAsync(objFields, (object) null);

    public void ModifyProfileAsync(DictionaryEntry[] objFields, object userState)
    {
      if (this.ModifyProfileOperationCompleted == null)
        this.ModifyProfileOperationCompleted = new SendOrPostCallback(this.OnModifyProfileOperationCompleted);
      this.InvokeAsync("ModifyProfile", new object[1]
      {
        (object) objFields
      }, this.ModifyProfileOperationCompleted, userState);
    }

    private void OnModifyProfileOperationCompleted(object arg)
    {
      if (this.ModifyProfileCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.ModifyProfileCompleted((object) this, new ModifyProfileCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/SendMailToSelf", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry SendMailToSelf(string strSubject, string strBody) => (ReturnEntry) this.Invoke(nameof (SendMailToSelf), new object[2]
    {
      (object) strSubject,
      (object) strBody
    })[0];

    public void SendMailToSelfAsync(string strSubject, string strBody) => this.SendMailToSelfAsync(strSubject, strBody, (object) null);

    public void SendMailToSelfAsync(string strSubject, string strBody, object userState)
    {
      if (this.SendMailToSelfOperationCompleted == null)
        this.SendMailToSelfOperationCompleted = new SendOrPostCallback(this.OnSendMailToSelfOperationCompleted);
      this.InvokeAsync("SendMailToSelf", new object[2]
      {
        (object) strSubject,
        (object) strBody
      }, this.SendMailToSelfOperationCompleted, userState);
    }

    private void OnSendMailToSelfOperationCompleted(object arg)
    {
      if (this.SendMailToSelfCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SendMailToSelfCompleted((object) this, new SendMailToSelfCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/SendPasswordToMail", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry SendPasswordToMail(
      string strUserID,
      string strEMail,
      string strSubject,
      string strPreBody,
      string strPostBody)
    {
      return (ReturnEntry) this.Invoke(nameof (SendPasswordToMail), new object[5]
      {
        (object) strUserID,
        (object) strEMail,
        (object) strSubject,
        (object) strPreBody,
        (object) strPostBody
      })[0];
    }

    public void SendPasswordToMailAsync(
      string strUserID,
      string strEMail,
      string strSubject,
      string strPreBody,
      string strPostBody)
    {
      this.SendPasswordToMailAsync(strUserID, strEMail, strSubject, strPreBody, strPostBody, (object) null);
    }

    public void SendPasswordToMailAsync(
      string strUserID,
      string strEMail,
      string strSubject,
      string strPreBody,
      string strPostBody,
      object userState)
    {
      if (this.SendPasswordToMailOperationCompleted == null)
        this.SendPasswordToMailOperationCompleted = new SendOrPostCallback(this.OnSendPasswordToMailOperationCompleted);
      this.InvokeAsync("SendPasswordToMail", new object[5]
      {
        (object) strUserID,
        (object) strEMail,
        (object) strSubject,
        (object) strPreBody,
        (object) strPostBody
      }, this.SendPasswordToMailOperationCompleted, userState);
    }

    private void OnSendPasswordToMailOperationCompleted(object arg)
    {
      if (this.SendPasswordToMailCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SendPasswordToMailCompleted((object) this, new SendPasswordToMailCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/SendActivateToMail", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry SendActivateToMail(
      string strSubject,
      string strPreBody,
      string strPostBody)
    {
      return (ReturnEntry) this.Invoke(nameof (SendActivateToMail), new object[3]
      {
        (object) strSubject,
        (object) strPreBody,
        (object) strPostBody
      })[0];
    }

    public void SendActivateToMailAsync(string strSubject, string strPreBody, string strPostBody) => this.SendActivateToMailAsync(strSubject, strPreBody, strPostBody, (object) null);

    public void SendActivateToMailAsync(
      string strSubject,
      string strPreBody,
      string strPostBody,
      object userState)
    {
      if (this.SendActivateToMailOperationCompleted == null)
        this.SendActivateToMailOperationCompleted = new SendOrPostCallback(this.OnSendActivateToMailOperationCompleted);
      this.InvokeAsync("SendActivateToMail", new object[3]
      {
        (object) strSubject,
        (object) strPreBody,
        (object) strPostBody
      }, this.SendActivateToMailOperationCompleted, userState);
    }

    private void OnSendActivateToMailOperationCompleted(object arg)
    {
      if (this.SendActivateToMailCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SendActivateToMailCompleted((object) this, new SendActivateToMailCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/CheckAccountAvailability", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry CheckAccountAvailability(string strUserID) => (ReturnEntry) this.Invoke(nameof (CheckAccountAvailability), new object[1]
    {
      (object) strUserID
    })[0];

    public void CheckAccountAvailabilityAsync(string strUserID) => this.CheckAccountAvailabilityAsync(strUserID, (object) null);

    public void CheckAccountAvailabilityAsync(string strUserID, object userState)
    {
      if (this.CheckAccountAvailabilityOperationCompleted == null)
        this.CheckAccountAvailabilityOperationCompleted = new SendOrPostCallback(this.OnCheckAccountAvailabilityOperationCompleted);
      this.InvokeAsync("CheckAccountAvailability", new object[1]
      {
        (object) strUserID
      }, this.CheckAccountAvailabilityOperationCompleted, userState);
    }

    private void OnCheckAccountAvailabilityOperationCompleted(object arg)
    {
      if (this.CheckAccountAvailabilityCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.CheckAccountAvailabilityCompleted((object) this, new CheckAccountAvailabilityCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/IsActivated", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry IsActivated() => (ReturnEntry) this.Invoke(nameof (IsActivated), new object[0])[0];

    public void IsActivatedAsync() => this.IsActivatedAsync((object) null);

    public void IsActivatedAsync(object userState)
    {
      if (this.IsActivatedOperationCompleted == null)
        this.IsActivatedOperationCompleted = new SendOrPostCallback(this.OnIsActivatedOperationCompleted);
      this.InvokeAsync("IsActivated", new object[0], this.IsActivatedOperationCompleted, userState);
    }

    private void OnIsActivatedOperationCompleted(object arg)
    {
      if (this.IsActivatedCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.IsActivatedCompleted((object) this, new IsActivatedCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://fihtdc.com/IsActivatedWithUserID", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://fihtdc.com/", ResponseNamespace = "http://fihtdc.com/", Use = SoapBindingUse.Literal)]
    public ReturnEntry IsActivatedWithUserID(string strUserID) => (ReturnEntry) this.Invoke(nameof (IsActivatedWithUserID), new object[1]
    {
      (object) strUserID
    })[0];

    public void IsActivatedWithUserIDAsync(string strUserID) => this.IsActivatedWithUserIDAsync(strUserID, (object) null);

    public void IsActivatedWithUserIDAsync(string strUserID, object userState)
    {
      if (this.IsActivatedWithUserIDOperationCompleted == null)
        this.IsActivatedWithUserIDOperationCompleted = new SendOrPostCallback(this.OnIsActivatedWithUserIDOperationCompleted);
      this.InvokeAsync("IsActivatedWithUserID", new object[1]
      {
        (object) strUserID
      }, this.IsActivatedWithUserIDOperationCompleted, userState);
    }

    private void OnIsActivatedWithUserIDOperationCompleted(object arg)
    {
      if (this.IsActivatedWithUserIDCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.IsActivatedWithUserIDCompleted((object) this, new IsActivatedWithUserIDCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
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
