// Decompiled with JetBrains decompiler
// Type: Params.ToolParam
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyCommonFunction;
using MyResources.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Utils;

namespace Params
{
  internal class ToolParam
  {
    private static ToolParam instance;
    protected string toolFolder;
    private Profile config;
    private Profile custom;
    private string launchTime;
    protected string bundledImage;
    private bool autoTest;
    private int autoTestCount;
    private Profile autoTestProfile;
    public bool optionVisible;
    protected OptionFilter optionFilter;

    protected ToolParam()
    {
      this.toolFolder = Path.GetDirectoryName(Application.ExecutablePath);
      this.config = new Profile(Path.Combine(this.toolFolder, "config.ini"));
      this.custom = new Profile(Path.Combine(this.toolFolder, "custom.ini"));
      this.launchTime = DateTime.Now.ToString("yyyyMMddHHmmss", (IFormatProvider) DateTimeFormatInfo.InvariantInfo);
    }

    public static ToolParam Instance
    {
      get
      {
        if (ToolParam.instance == null)
        {
          switch (ToolParam.ToolUser)
          {
            case ToolParam.User.Customer:
              ToolParam.instance = (ToolParam) new ParamCustomer();
              break;
            case ToolParam.User.CustomerExtension:
              ToolParam.instance = (ToolParam) new ParamCustomerExtension();
              break;
            case ToolParam.User.Operator:
              ToolParam.instance = (ToolParam) new ParamOperator();
              break;
            case ToolParam.User.Account:
              ToolParam.instance = (ToolParam) new ParamAccount();
              break;
            case ToolParam.User.RD:
              ToolParam.instance = (ToolParam) new ParamRD();
              break;
            default:
              ToolParam.instance = (ToolParam) new ParamEndUser();
              break;
          }
        }
        return ToolParam.instance;
      }
    }

    public void Initialization()
    {
      CLogs.CreateInstance(string.Format("{0} V{1}", (object) Settings.Default.ProductName, (object) this.ToolVersion), Path.Combine(this.GetDataFolder(), string.Format("LOG_{0}.txt", (object) this.launchTime)));
      this.LoadCommandLineArgs();
      if (!this.config.ReadString("SUT", "Single").ToLower().Equals("true"))
        this.SearchBundledImage();
      ToolParam.SetArgumentInt(241, (int) ToolParam.ToolUser);
      ToolParam.SetArgumentInt(242, this.BundledImageExist ? 1 : 0);
      ToolParam.SetArgumentString(241, this.launchTime);
      ToolParam.SetArgumentString(242, this.GetUserTempFolder("Data"));
      ToolParam.SetArgumentString(243, this.GetUserTempFolder("DataCache"));
    }

    private void LoadCommandLineArgs()
    {
      if (Common.HasCommandLineArgs("-auto") && !string.IsNullOrEmpty(Common.GetCommandLineArgs("-firmware")))
      {
        this.autoTest = true;
        this.autoTestCount = 1;
        this.bundledImage = Common.GetCommandLineArgs("-firmware");
      }
      else if (!string.IsNullOrEmpty(Common.GetCommandLineArgs("-firmware")))
      {
        this.autoTest = false;
        this.autoTestCount = 1;
        this.bundledImage = Common.GetCommandLineArgs("-firmware");
      }
      else
      {
        this.autoTest = false;
        this.autoTestCount = 1;
        this.bundledImage = this.config.ReadString("SUT", "Firmware");
      }
    }

    private void SearchBundledImage()
    {
      if (File.Exists(Path.GetFullPath(this.bundledImage)))
        this.bundledImage = Path.GetFullPath(this.bundledImage);
      else if (File.Exists(Path.Combine(this.toolFolder, this.bundledImage)))
        this.bundledImage = Path.GetFullPath(Path.Combine(this.toolFolder, this.bundledImage));
      if (string.IsNullOrEmpty(this.bundledImage) || !Path.GetExtension(this.bundledImage).ToLower().Equals(".zip"))
        return;
      this.bundledImage = this.RedirectZipImage(this.bundledImage, "*_NV.xml");
    }

    private string RedirectZipImage(string zipFile, string pattern)
    {
      if (!File.Exists(zipFile))
        return string.Empty;
      string str = Path.Combine(Path.GetTempPath(), this.launchTime);
      Directory.CreateDirectory(str);
      ZipUtil.UnZipFiles(zipFile, str);
      return Path.Combine(str, PathEx.ReverseFindFirstFile(str, pattern, 1));
    }

    public string GetDataFolder()
    {
      string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
      string sutProject = Settings.Default.SutProject;
      string path1 = Path.Combine(pathRoot, string.Format("LogData\\{0}", (object) sutProject));
      Directory.CreateDirectory(path1);
      if (this.AccessTest(path1))
        return path1;
      string path2 = Path.Combine(Path.GetTempPath(), string.Format("LogData\\{0}", (object) sutProject));
      Directory.CreateDirectory(path2);
      return path2;
    }

    public string GetUserTempFolder(string folderName)
    {
      string path = Path.Combine(this.GetDataFolder(), folderName);
      Directory.CreateDirectory(path);
      return path;
    }

    public string GetUserProjectFolder(string folderName) => this.GetUserTempFolder(Path.Combine(folderName, Settings.Default.ProductName));

    private bool AccessTest(string path)
    {
      FileStream fileStream = File.Create(Path.Combine(path, "test.txt"));
      if (fileStream == null)
        return false;
      fileStream.Close();
      File.Delete(Path.Combine(path, "test.txt"));
      return true;
    }

    public string ToolFolder => this.toolFolder;

    public Profile Config => this.config;

    public string LaunchTime => this.launchTime;

    public string BundledImage => this.bundledImage;

    public bool BundledImageExist => !string.IsNullOrEmpty(this.bundledImage);

    public string ToolVersion
    {
      get
      {
        string format = this.custom.ReadString("SUT", "VersionFmt");
        if (string.IsNullOrEmpty(format))
          return string.Empty;
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        return string.Format(format, (object) version.Major, (object) version.Minor, (object) version.Build);
      }
    }

    public static ToolParam.User ToolUser => (ToolParam.User) Settings.Default.SutLevel;

    public string ToolUserTitle
    {
      get
      {
        switch (ToolParam.ToolUser)
        {
          case ToolParam.User.Customer:
            return "L2";
          case ToolParam.User.CustomerExtension:
            return "L2.1";
          case ToolParam.User.Operator:
            return "L3";
          case ToolParam.User.Account:
            return "LA";
          case ToolParam.User.RD:
            return "LR";
          default:
            return "L1";
        }
      }
    }

    public bool AutoTest
    {
      get => this.autoTest;
      set => this.autoTest = value;
    }

    public int AutoTestInterval => Convert.ToInt32(this.autoTestProfile.ReadString("SUT", nameof (AutoTestInterval), "30000"));

    public int DecreaseAutoTestCount() => --this.autoTestCount;

    public int AutoTestCount => this.autoTestCount;

    public int AutoTestDevices => Convert.ToInt32(this.autoTestProfile.ReadString("SUT", nameof (AutoTestDevices), "1"));

    public Profile AutoTestProfile => this.autoTestProfile == null ? this.config : this.autoTestProfile;

    public bool OptionVisible => this.optionVisible || !this.autoTest;

    public void ConfigAutoTest(string profile)
    {
      this.autoTest = true;
      this.autoTestProfile = new Profile(profile);
      this.autoTestCount = Convert.ToInt32(this.autoTestProfile.ReadString("SUT", "AutoTestCount", "100000"));
      this.optionVisible = false;
    }

    public virtual bool UpdateCounter => false;

    public virtual string MainImageFilter => "image files (*.mlf; *.nb0)|*.mlf;*.nb0";

    public OptionFilter Option => this.optionFilter;

    public virtual void EnableBackupOption() => this.optionFilter.Backup = true;

    public virtual void EnableNativeFormatAndUpdateOption() => this.optionFilter.NativeFormatAndUpdate = true;

    public void UpdateArgumentUserPermission() => ToolParam.SetArgumentInt(244, (int) OstOption.GetUserImgSwitchPermission());

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetArgumentInt(int argument, int value);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetArgumentString(int argument, string value);

    public enum User
    {
      EndUser = 1,
      Customer = 2,
      CustomerExtension = 3,
      Operator = 4,
      Account = 98, // 0x00000062
      RD = 99, // 0x00000063
    }
  }
}
