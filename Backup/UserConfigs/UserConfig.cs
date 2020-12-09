// Decompiled with JetBrains decompiler
// Type: UserConfigs.UserConfig
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.Properties;
using Params;
using System;
using System.IO;
using Utils;

namespace UserConfigs
{
  internal class UserConfig
  {
    private static UserConfig instance;
    private Profile config;
    private string section;

    protected UserConfig()
    {
      ToolParam instance = ToolParam.Instance;
      this.config = new Profile(Path.Combine(instance.GetUserTempFolder(nameof (UserConfig)), "user_config.ini"));
      this.section = Settings.Default.SutProject + instance.ToolUserTitle;
    }

    public static UserConfig Instance
    {
      get
      {
        if (UserConfig.instance == null)
          UserConfig.instance = new UserConfig();
        return UserConfig.instance;
      }
    }

    public string LoginAccount
    {
      set => this.config.WriteString(this.section, "Account", value);
      get => this.config.ReadString(this.section, "Account");
    }

    public string LoginMacAddress
    {
      set => this.config.WriteString(this.section, "MacAddress", value);
      get => this.config.ReadString(this.section, "MacAddress");
    }

    public string LoginPassword
    {
      set => this.config.WriteString(this.section, "Password", this.EncrypText(value));
      get => RsaCrypt.DecryptString(this.config.ReadString(this.section, "Password"));
    }

    public string LoginDomain
    {
      set => this.config.WriteString(this.section, "Domain", value);
      get => this.config.ReadString(this.section, "Domain");
    }

    public string AuthUsername
    {
      set => this.config.WriteString(this.section, nameof (AuthUsername), value);
      get => this.config.ReadString(this.section, nameof (AuthUsername));
    }

    public string AuthPassword
    {
      set => this.config.WriteString(this.section, nameof (AuthPassword), this.EncrypText(value));
      get => this.DecrypText(this.config.ReadString(this.section, nameof (AuthPassword)));
    }

    public string AuthDomain
    {
      set => this.config.WriteString(this.section, nameof (AuthDomain), value);
      get => this.config.ReadString(this.section, nameof (AuthDomain));
    }

    public string ProxyAuthUsername
    {
      set => this.config.WriteString(this.section, nameof (ProxyAuthUsername), value);
      get => this.config.ReadString(this.section, "AuthUsername");
    }

    public string ProxyAuthPassword
    {
      set => this.config.WriteString(this.section, nameof (ProxyAuthPassword), this.EncrypText(value));
      get => this.DecrypText(this.config.ReadString(this.section, "AuthPassword"));
    }

    public string ProxyAuthDomain
    {
      set => this.config.WriteString(this.section, nameof (ProxyAuthDomain), value);
      get => this.config.ReadString(this.section, "AuthDomain");
    }

    public string SerialNumber
    {
      set => this.config.WriteString(this.section, "SN", value);
      get => this.config.ReadString(this.section, "SN");
    }

    public string InitFirmwareDir
    {
      set => this.config.WriteString(this.section, nameof (InitFirmwareDir), value);
      get => this.config.ReadString(this.section, nameof (InitFirmwareDir));
    }

    public string InitSimPersoDir
    {
      set => this.config.WriteString(this.section, nameof (InitSimPersoDir), value);
      get => this.config.ReadString(this.section, nameof (InitSimPersoDir));
    }

    private string EncrypText(string input)
    {
      try
      {
        return RsaCrypt.EncryptString(input);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return string.Empty;
      }
    }

    private string DecrypText(string input)
    {
      try
      {
        return RsaCrypt.DecryptString(input);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        return string.Empty;
      }
    }
  }
}
