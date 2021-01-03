// Decompiled with JetBrains decompiler
// Type: MyResources.Properties.Settings
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MyResources.Properties
{
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    [CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

        public static Settings Default => Settings.defaultInstance;

        [DefaultSettingValue("98")]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public int SutLevel => (int)this[nameof(SutLevel)];

        [DebuggerNonUserCode]
        [DefaultSettingValue("OST")]
        [ApplicationScopedSetting]
        public string SutProject => (string)this[nameof(SutProject)];

        [DefaultSettingValue("")]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public string Company => (string)this[nameof(Company)];

        [ApplicationScopedSetting]
        [DefaultSettingValue("OSTLA")]
        [DebuggerNonUserCode]
        public string ProductName => (string)this[nameof(ProductName)];

        [DebuggerNonUserCode]
        [DefaultSettingValue("OST LA")]
        [ApplicationScopedSetting]
        public string DisplayName => (string)this[nameof(DisplayName)];

        [ApplicationScopedSetting]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/FileHandler.asmx")]
        [DebuggerNonUserCode]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string MyResources_FileHandlerService_FileHandler => (string)this[nameof(MyResources_FileHandlerService_FileHandler)];

        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/Login.asmx")]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public string MyResources_LoginService_Login => (string)this[nameof(MyResources_LoginService_Login)];

        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/SWImage.asmx")]
        [ApplicationScopedSetting]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        [DebuggerNonUserCode]
        public string MyResources_SWImageService_SWImage => (string)this[nameof(MyResources_SWImageService_SWImage)];

        [ApplicationScopedSetting]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/Log.asmx")]
        [DebuggerNonUserCode]
        public string MyResources_LogService_Log => (string)this[nameof(MyResources_LogService_Log)];

        [DebuggerNonUserCode]
        [ApplicationScopedSetting]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/FileHandler.asmx")]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string OnlineUpdateTool_FileHandlerService_FileHandler => (string)this[nameof(OnlineUpdateTool_FileHandlerService_FileHandler)];

        [DebuggerNonUserCode]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/Login.asmx")]
        [ApplicationScopedSetting]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string OnlineUpdateTool_LoginService_Login => (string)this[nameof(OnlineUpdateTool_LoginService_Login)];

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/SWImage.asmx")]
        public string OnlineUpdateTool_SWImageService_SWImage => (string)this[nameof(OnlineUpdateTool_SWImageService_SWImage)];

        [DebuggerNonUserCode]
        [ApplicationScopedSetting]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        [DefaultSettingValue("http://tpe-ota.fihtdc.com/Demo/Log.asmx")]
        public string OnlineUpdateTool_LogService_Log => (string)this[nameof(OnlineUpdateTool_LogService_Log)];
    }
}
