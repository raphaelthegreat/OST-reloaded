// Decompiled with JetBrains decompiler
// Type: MainForms.Form_PhoneKeyInfo
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MyCommonFunction;
using Newtonsoft.Json;
using OnlineUpdateTool.MainForms;
using OtaControl;
using OtaControl.PhoneReader;
using Params;
using Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Tasks;
using UserConfigs;
using Utils;

namespace MainForms
{
    public class Form_PhoneKeyInfo : Form
    {
        private const string servermode = "release";
        private const string logmode = "normal";
        private string sessionID;
        private string deviceID;
        private string selectedPhoneKeyType;
        private string lablePhoneKeyRead;
        private string lablePhoneKeyWrite;
        private string toolUserTitle;
        private Process sample = new Process();
        private ToolParam toolParam = ToolParam.Instance;
        private GemsQueryDeviceInfo mInfoReturnedDevice;
        private GemsQueryDeviceInfo mInfoNewDevice;
        private string newline = Environment.NewLine;
        private string psn = string.Empty;
        private string currentImei1 = string.Empty;
        private string currentImei2 = string.Empty;
        private string currentMeid = string.Empty;
        private string factoryCode = "OST";
        private string newImei1 = string.Empty;
        private string newImei2 = string.Empty;
        private string newMeid = string.Empty;
        private NewImeiResult newImeiResult;
        private AckImeiStatusResult ackImeiStatusResult;
        private IContainer components;
        private Label labelPhoneKeyWriteTitle;
        private Button btnPhoneKeyWrite;
        private Button btnPhoneKeyRead;
        private Label labelPhoneKeyReadTitle;
        private Label labelPhoneInfoStatus;
        private GroupBox grpBoxPhoneKeyType;
        private RadioButton rdoBtnIMEI;
        private RadioButton rdoBtnPSN;
        private RadioButton rdoBtnMEID;
        private RadioButton rdoBtnBTAddr;
        private RadioButton rdoBtnBT2Addr;
        private RadioButton rdoBtnBatteryInfo;
        private RadioButton rdoBtnWiFiAddr;
        private Button btnContinue;
        private Button btnFinish;
        private TextBox textBoxPhoneKeyWriteValue;
        private RadioButton rdoBtnIMEI2;
        private TabControl tabControl_PhoneKey;
        private TabPage tabPage_PhoneKey;
        private TabPage tabPage_SimLock;
        private Label labelSimLockStatusHeader;
        private Label labelSimLockStatusValue;
        private Label labelSimLockUnlockCodeHeader;
        private Button btnUnlockSIM;
        private Button btnLockSIM;
        private TextBox textBoxUnlockCodeValue;
        private RadioButton rdoBtnMEID2;
        private RadioButton rdoBtnWallPaperID;
        private Label labelSimPersoFileHeader;
        private TextBox textBoxSimPersoFile;
        private Button btnSelectSimPersoFile;
        private Button btnGetSimLockStatus;
        private TabPage tabPage_NokiaSimLockSwap;
        private GroupBox groupBox_NokiaSimSwapStep1;
        private TextBox textBox_NokiaSimSwapReturnDeviceSn;
        private Label label_NokiaSimSwapStep1Msg1;
        private GroupBox groupBox_NokiaSimSwapStep2;
        private Button button_NokiaSimSwapLockNewDevice;
        private TextBox textBox_NokiaSimSwapNewDeviceSN;
        private Label label_NokiaSimSwapStep2Msg1;
        private Button btn_NokiaSimSwapReturnedDeviceQuery;
        private Label label_NokiaSimSwap_NewDeviceLockStatus;
        private Label label_NokiaSimSwap_ReturnedDeviceLockStatus;
        private Label label_NokiaSimSwap_NewDeviceLockGuid;
        private Label label_NokiaSimSwap_ReturnedDeviceLockGuid;
        private TextBox textBoxPhoneKeyReadValue;
        private TabPage tabPage_GemsImeiReset;
        private Button btn_GemsImeiReset;
        private RichTextBox textBox_GemsImeiReset;

        public Form_PhoneKeyInfo(string sessionID, string deviceID, string toolUserTitle)
        {
            this.InitializeComponent();
            this.sessionID = sessionID;
            this.deviceID = deviceID;
            this.toolUserTitle = toolUserTitle;
            if (this.toolUserTitle == "L1")
            {
                this.labelPhoneKeyWriteTitle.Enabled = false;
                this.textBoxPhoneKeyWriteValue.Enabled = false;
                this.btnPhoneKeyWrite.Enabled = false;
            }
            this.lablePhoneKeyRead = Locale.Instance.LoadText("LABEL_PHONE_KEY_READ");
            this.lablePhoneKeyWrite = Locale.Instance.LoadText("LABEL_PHONE_KEY_WRITE");
            this.Text = Locale.Instance.LoadText("BTN_PHONE_KEY_INFO");
            this.grpBoxPhoneKeyType.Text = Locale.Instance.LoadText(this.grpBoxPhoneKeyType.Text);
            this.btnPhoneKeyRead.Text = Locale.Instance.LoadText(this.btnPhoneKeyRead.Text);
            this.btnPhoneKeyWrite.Text = Locale.Instance.LoadText(this.btnPhoneKeyWrite.Text);
            this.btnContinue.Text = Locale.Instance.LoadText(this.btnContinue.Text);
            this.btnFinish.Text = Locale.Instance.LoadText(this.btnFinish.Text);
            this.selectedPhoneKeyType = "PSN";
            this.labelPhoneKeyReadTitle.Text = string.Format("{0} PSN:", (object)this.lablePhoneKeyRead);
            this.labelPhoneKeyWriteTitle.Text = string.Format("{0} PSN:", (object)this.lablePhoneKeyWrite);
            this.labelPhoneInfoStatus.Text = "Selected PSN";
            this.FormClosing += new FormClosingEventHandler(this.Form_PhoneKeyInfo_FormClosing);
        }

        private void Form_PhoneKeyInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes || this.DialogResult == DialogResult.No)
                return;
            this.DialogResult = DialogResult.Yes;
        }

        private void InitControlsByUserPermission()
        {
            if (!OstOption.HasPhoneInfoOption())
            {
                this.tabControl_PhoneKey.Visible = false;
            }
            else
            {
                if (!OstOption.HasPhoneInfoOptionGroupBasic())
                    this.tabControl_PhoneKey.TabPages.Remove(this.tabPage_PhoneKey);
                this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = false;
                this.labelSimLockUnlockCodeHeader.Visible = this.textBoxUnlockCodeValue.Visible = this.btnUnlockSIM.Visible = false;
                this.labelSimPersoFileHeader.Visible = this.textBoxSimPersoFile.Visible = this.btnSelectSimPersoFile.Visible = this.btnLockSIM.Visible = false;
                if (!OstOption.HasPhoneInfoOptionGroupSimLock())
                    this.tabControl_PhoneKey.TabPages.Remove(this.tabPage_SimLock);
                if (OstOption.HasOption("SimUnlock"))
                {
                    if (Product.sharedProduct.ImgSecurityVersion >= 8U)
                    {
                        if (STSLicense.isEnableRoot())
                        {
                            this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = true;
                            this.labelSimLockUnlockCodeHeader.Visible = this.textBoxUnlockCodeValue.Visible = this.btnUnlockSIM.Visible = true;
                        }
                        else
                        {
                            this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = false;
                            this.labelSimLockUnlockCodeHeader.Visible = this.textBoxUnlockCodeValue.Visible = this.btnUnlockSIM.Visible = false;
                        }
                    }
                    else
                    {
                        this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = true;
                        this.labelSimLockUnlockCodeHeader.Visible = this.textBoxUnlockCodeValue.Visible = this.btnUnlockSIM.Visible = true;
                    }
                }
                if (OstOption.HasOption("SimLock"))
                {
                    if (Product.sharedProduct.ImgSecurityVersion >= 8U)
                    {
                        if (STSLicense.isEnableRoot())
                        {
                            this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = true;
                            this.labelSimPersoFileHeader.Visible = this.textBoxSimPersoFile.Visible = this.btnSelectSimPersoFile.Visible = this.btnLockSIM.Visible = true;
                        }
                        else
                        {
                            this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = false;
                            this.labelSimPersoFileHeader.Visible = this.textBoxSimPersoFile.Visible = this.btnSelectSimPersoFile.Visible = this.btnLockSIM.Visible = false;
                        }
                    }
                    else
                    {
                        this.labelSimLockStatusHeader.Visible = this.labelSimLockStatusValue.Visible = this.btnGetSimLockStatus.Visible = true;
                        this.labelSimPersoFileHeader.Visible = this.textBoxSimPersoFile.Visible = this.btnSelectSimPersoFile.Visible = this.btnLockSIM.Visible = true;
                    }
                }
                if (!OstOption.HasPhoneInfoOptionGroupNokiaSimSwap())
                    this.tabControl_PhoneKey.TabPages.Remove(this.tabPage_NokiaSimLockSwap);
                if (OstOption.hasPhoneInfoOptionGroupImeiReset())
                    return;
                this.tabControl_PhoneKey.TabPages.Remove(this.tabPage_GemsImeiReset);
            }
        }

        private void Form_PhoneInfo_Load(object sender, EventArgs e)
        {
            this.rdoBtnPSN.Checked = true;
            this.textBoxPhoneKeyReadValue.Text = "";
            this.textBoxPhoneKeyWriteValue.Text = "";
            this.labelPhoneInfoStatus.Text = "";
            this.InitControlsByUserPermission();
            this.DisplayButton();
        }

        private void DisableButton()
        {
            this.btnPhoneKeyRead.Enabled = false;
            this.btnPhoneKeyWrite.Enabled = false;
            this.grpBoxPhoneKeyType.Enabled = false;
            this.textBoxPhoneKeyReadValue.Enabled = false;
            this.textBoxPhoneKeyWriteValue.Enabled = false;
            this.btnContinue.Enabled = false;
            this.btnFinish.Enabled = false;
            this.btnGetSimLockStatus.Enabled = false;
            this.btnUnlockSIM.Enabled = false;
            this.btnLockSIM.Enabled = false;
            this.btnSelectSimPersoFile.Enabled = false;
            this.textBoxSimPersoFile.Enabled = false;
            this.btn_GemsImeiReset.Enabled = false;
        }

        private void DisplayButton()
        {
            this.btnPhoneKeyRead.Enabled = true;
            this.btnPhoneKeyWrite.Enabled = true;
            this.grpBoxPhoneKeyType.Enabled = true;
            this.textBoxPhoneKeyReadValue.Enabled = true;
            this.textBoxPhoneKeyWriteValue.Enabled = true;
            this.btnContinue.Enabled = true;
            this.btnFinish.Enabled = true;
            this.btnGetSimLockStatus.Enabled = true;
            this.btnUnlockSIM.Enabled = true;
            this.btnLockSIM.Enabled = true;
            this.btnSelectSimPersoFile.Enabled = true;
            this.textBoxSimPersoFile.Enabled = true;
            this.btn_GemsImeiReset.Enabled = true;
        }

        private void rdoBtnPhoneKeyInfo_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxPhoneKeyReadValue.Text = "";
            this.textBoxPhoneKeyWriteValue.Text = "";
            this.selectedPhoneKeyType = ((Control)sender).Text;
            this.labelPhoneKeyReadTitle.Text = string.Format("{0} {1}:", (object)this.lablePhoneKeyRead, (object)this.selectedPhoneKeyType);
            this.labelPhoneKeyWriteTitle.Text = string.Format("{0} {1}:", (object)this.lablePhoneKeyWrite, (object)this.selectedPhoneKeyType);
            this.labelPhoneInfoStatus.Text = string.Format("Selected {0}", (object)this.selectedPhoneKeyType);
            if (this.selectedPhoneKeyType == "PSN")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("PsnRead");
                this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("PsnWrite");
            }
            else if (this.selectedPhoneKeyType == "IMEI" || this.selectedPhoneKeyType == "IMEI2")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("ImeiRead");
                if (Product.sharedProduct.ImgSecurityVersion >= 8U)
                {
                    if (STSLicense.isRewriteIMEI())
                        this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("ImeiWrite");
                    else
                        this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = false;
                }
                else
                    this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("ImeiWrite");
            }
            else if (this.selectedPhoneKeyType == "MEID" || this.selectedPhoneKeyType == "MEID2")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("MeidRead");
                if (Product.sharedProduct.ImgSecurityVersion >= 8U)
                {
                    if (STSLicense.isRewriteIMEI())
                        this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("MeidWrite");
                    else
                        this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = false;
                }
                else
                    this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("MeidWrite");
            }
            else if (this.selectedPhoneKeyType == "BT ADDR" || this.selectedPhoneKeyType == "BT2 Addr")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("BtAddrRead");
                this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("BtAddrWrite");
            }
            else if (this.selectedPhoneKeyType.ToUpper() == "WIFI ADDR")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("WifiAddrRead");
                this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("WifiAddrWrite");
            }
            else if (this.selectedPhoneKeyType.ToUpper() == "WALLPAPER ID")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("WallpaperIDRead");
                this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("WallpaperIDWrite");
            }
            else if (this.selectedPhoneKeyType.ToUpper() == "BATTERY INFO")
            {
                this.labelPhoneKeyReadTitle.Visible = this.textBoxPhoneKeyReadValue.Visible = this.btnPhoneKeyRead.Visible = OstOption.HasOption("BatteryInfoRead");
                this.labelPhoneKeyWriteTitle.Visible = this.textBoxPhoneKeyWriteValue.Visible = this.btnPhoneKeyWrite.Visible = OstOption.HasOption("BatteryInfoWrite");
            }
            this.Refresh();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("NokiaSIMLock").Length > 0)
                this.sample.Kill();
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnPhoneKeyRead_Click(object sender, EventArgs e)
        {
            this.ShowProgressMessage("Read {0}...", (object)this.selectedPhoneKeyType);
            this.textBoxPhoneKeyReadValue.Text = "";
            this.Refresh();
            FtmApiFunction ftmApiFunction = FtmApiFunction.GetProductID;
            switch (this.selectedPhoneKeyType)
            {
                case "PSN":
                    ftmApiFunction = FtmApiFunction.GetProductID;
                    break;
                case "IMEI":
                    ftmApiFunction = FtmApiFunction.GetIMEI;
                    break;
                case "IMEI2":
                    ftmApiFunction = FtmApiFunction.GetIMEI2;
                    break;
                case "MEID":
                    ftmApiFunction = FtmApiFunction.GetMEID;
                    break;
                case "MEID2":
                    ftmApiFunction = FtmApiFunction.GetMEID2;
                    break;
                case "WiFi Addr":
                    ftmApiFunction = FtmApiFunction.GetWifiAddr;
                    break;
                case "BT Addr":
                    ftmApiFunction = FtmApiFunction.GetBtAddr;
                    break;
                case "BT2 Addr":
                    ftmApiFunction = FtmApiFunction.GetBt2Addr;
                    break;
                case "WallPaper ID":
                    ftmApiFunction = FtmApiFunction.GetWallpaperID;
                    break;
                case "Battery Info":
                    ftmApiFunction = FtmApiFunction.GetBatteryInfo;
                    break;
            }
            try
            {
                CLogs.B("Start ExecFtmApiFuncion...");
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.ExecFtmApiFuncRead_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, (int)ftmApiFunction, "");
                this.DisableButton();
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                this.ShowProgressErrorMessage("Read {0} fail! Get exception!", (object)this.selectedPhoneKeyType);
                this.DisplayButton();
            }
        }

        private void ExecFtmApiFuncRead_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            switch (result)
            {
                case 0:
                    if (str == string.Empty)
                    {
                        this.ShowProgressErrorMessage("Read {0} fail! No FTM response", (object)this.selectedPhoneKeyType);
                        break;
                    }
                    this.ShowProgressMessage("Read {0} succeed.", (object)this.selectedPhoneKeyType);
                    this.textBoxPhoneKeyReadValue.Text = str;
                    break;
                case 1646:
                    this.ShowProgressErrorMessage("There is no second SIM.", (object)this.selectedPhoneKeyType);
                    this.textBoxPhoneKeyReadValue.Text = "There is no second SIM.";
                    break;
                default:
                    this.ShowProgressErrorMessage("Read {0} fail!", (object)this.selectedPhoneKeyType);
                    break;
            }
            this.DisplayButton();
        }

        private void btnPhoneKeyWrite_Click(object sender, EventArgs e)
        {
            if (this.textBoxPhoneKeyWriteValue.Text.Length == 0)
            {
                this.ShowProgressErrorMessage("Please enter {0}!", (object)this.selectedPhoneKeyType);
            }
            else
            {
                this.ShowProgressMessage("Write {0}...", (object)this.selectedPhoneKeyType);
                bool flag = true;
                FtmApiFunction ftmApiFunction = FtmApiFunction.GetProductID;
                string text = this.textBoxPhoneKeyWriteValue.Text;
                this.Refresh();
                switch (this.selectedPhoneKeyType)
                {
                    case "PSN":
                        ftmApiFunction = FtmApiFunction.SetProductID;
                        break;
                    case "IMEI":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetIMEI;
                        break;
                    case "IMEI2":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetIMEI2;
                        break;
                    case "MEID":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetMEID;
                        break;
                    case "MEID2":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetMEID2;
                        break;
                    case "WiFi Addr":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetWifiAddr;
                        break;
                    case "BT Addr":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetBtAddr;
                        break;
                    case "BT2 Addr":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetBt2Addr;
                        break;
                    case "WallPaper ID":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetWallpaperId;
                        break;
                    case "Battery Info":
                        if (!this.CheckValue())
                        {
                            flag = false;
                            break;
                        }
                        ftmApiFunction = FtmApiFunction.SetBatteryInfo;
                        break;
                }
                if (!flag)
                    return;
                try
                {
                    CLogs.B("Start  ExecFtmApiFuncion...");
                    DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.ExecFtmApiFuncWrite_OnTaskCompleted));
                    Sessions.Restart();
                    dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, (int)ftmApiFunction, text);
                    this.DisableButton();
                }
                catch (Exception ex)
                {
                    CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                    this.ShowProgressErrorMessage("Read {0} fail! Get exception!", (object)this.selectedPhoneKeyType);
                    this.DisplayButton();
                }
            }
        }

        private void ExecFtmApiFuncWrite_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            switch (result)
            {
                case 0:
                    this.ShowProgressMessage("Write {0} succeed.", (object)this.selectedPhoneKeyType);
                    break;
                case 1646:
                    this.ShowProgressErrorMessage("There is no second SIM.", (object)this.selectedPhoneKeyType);
                    this.textBoxPhoneKeyWriteValue.Text = "There is no second SIM.";
                    break;
                default:
                    this.ShowProgressErrorMessage("Write {0} fail!", (object)this.selectedPhoneKeyType);
                    break;
            }
            this.DisplayButton();
        }

        private bool CheckValue()
        {
            bool flag = true;
            string text = this.textBoxPhoneKeyWriteValue.Text;
            switch (this.selectedPhoneKeyType)
            {
                case "IMEI":
                case "IMEI2":
                    if (text.Length != 15 && text.Length != 17)
                    {
                        flag = false;
                        this.ShowErrorMessage(string.Format("{0} length is incorrect!", (object)this.selectedPhoneKeyType));
                        break;
                    }
                    if (!this.IsNumber(text))
                    {
                        flag = false;
                        this.ShowErrorMessage("Invalid character!");
                        break;
                    }
                    break;
                case "MEID":
                case "MEID2":
                    if (text.Length != 14)
                    {
                        flag = false;
                        this.ShowErrorMessage(string.Format("{0} length is incorrect!", (object)this.selectedPhoneKeyType));
                        break;
                    }
                    if (!this.IsContainInvalidCharacter(text))
                    {
                        flag = false;
                        this.ShowErrorMessage("Invalid character!");
                        break;
                    }
                    break;
                case "WiFi Addr":
                case "BT Addr":
                case "BT2 Addr":
                    if (text.Length != 12)
                    {
                        flag = false;
                        this.ShowErrorMessage(string.Format("{0} length is incorrect!", (object)this.selectedPhoneKeyType));
                        break;
                    }
                    if (!this.IsContainInvalidCharacter(text))
                    {
                        flag = false;
                        this.ShowErrorMessage("Invalid character!");
                        break;
                    }
                    break;
                case "WallPaper ID":
                    if (text.Length != 1 && text.Length != 2)
                    {
                        flag = false;
                        this.ShowErrorMessage(string.Format("{0} length is incorrect!", (object)this.selectedPhoneKeyType));
                        break;
                    }
                    if (!this.IsContainInvalidCharacter(text))
                    {
                        flag = false;
                        this.ShowErrorMessage("Invalid character!");
                        break;
                    }
                    break;
            }
            return flag;
        }

        private bool IsNumber(string value)
        {
            bool flag = true;
            foreach (char c in value)
            {
                if (!char.IsNumber(c))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private bool IsContainInvalidCharacter(string value)
        {
            bool flag = true;
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            value.ToUpper();
            foreach (char ch in value)
            {
                if (!str.Contains(ch.ToString()))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private void ShowErrorMessage(string message)
        {
            CLogs.E(message);
            int num = (int)MessageBox.Show(message, "ERROR");
        }

        private void ShowProgressMessage(string format, params object[] argus)
        {
            string format1 = string.Format(format, argus);
            CLogs.I(format1);
            this.labelPhoneInfoStatus.Text = format1;
            this.Refresh();
        }

        private void ShowProgressErrorMessage(string format, params object[] argus)
        {
            string format1 = string.Format(format, argus);
            CLogs.E(format1);
            this.labelPhoneInfoStatus.Text = format1;
            this.Refresh();
        }

        public static void bringToFront(string title)
        {
            IntPtr window = Form_PhoneKeyInfo.FindWindow((string)null, title);
            if (window == IntPtr.Zero)
                return;
            Form_PhoneKeyInfo.BringWindowToTop(window);
            Form_PhoneKeyInfo.ShowWindow(window, 3);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private void NokiaSimSwap_InitContorlsAndStatus()
        {
            this.textBox_NokiaSimSwapReturnDeviceSn.Text = string.Empty;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Visible = false;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Text = string.Empty;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Visible = false;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Text = string.Empty;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Text = string.Empty;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Text = string.Empty;
        }

        private void NokiaSimSwap_InitStatus()
        {
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Visible = false;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Text = string.Empty;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Visible = false;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Text = string.Empty;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Text = string.Empty;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Text = string.Empty;
        }

        private void NokiaSimSwap_ShowReturnDeviceStatus(string status)
        {
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Visible = true;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Text = status;
            this.Refresh();
        }

        private void NokiaSimSwap_ShowNewDeviceStatus(string status)
        {
            this.label_NokiaSimSwap_NewDeviceLockStatus.Visible = true;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Text = status;
            this.Refresh();
        }

        private void NokiaSimSwap_ShowReturnDeviceGuid(string guid)
        {
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Visible = true;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Text = "GUID: " + guid;
            this.Refresh();
        }

        private void NokiaSimSwap_ShowNewDeviceGuid(string guid)
        {
            this.label_NokiaSimSwap_NewDeviceLockGuid.Visible = true;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Text = "GUID: " + guid;
            this.Refresh();
        }

        private void tabPage_NokiaSimLockSwap_Enter(object sender, EventArgs e)
        {
            try
            {
                long num = 0;
                int iSimLockStatus = -1;
                this.NokiaSimSwap_InitContorlsAndStatus();
                this.ShowProgressMessage("Get new device information...");
                if (num == 0L)
                {
                    OtaPhoneItem otaPhoneItem = new OtaPhoneItem(new PhoneInformation().GetPhoneInformation(this.sessionID, this.deviceID));
                    if (otaPhoneItem == null)
                        num = 50702L;
                    if (num == 0L)
                        this.textBox_NokiaSimSwapNewDeviceSN.Text = otaPhoneItem.DeviceID;
                }
                if (num == 0L)
                {
                    if (iSimLockStatus == 1)
                        this.NokiaSimSwap_ShowNewDeviceStatus("Status: Already locked with previous SIM perso");
                    else
                        this.NokiaSimSwap_ShowNewDeviceStatus("Status: " + this.GetSimLockStatusString(iSimLockStatus));
                    this.ShowProgressMessage("Get new device information succeed.");
                    return;
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
            }
            this.ShowProgressErrorMessage("Get new device information fail!");
        }

        private void btn_NokiaSimSwapDevicesInfoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                long num = 0;
                string text1 = this.textBox_NokiaSimSwapReturnDeviceSn.Text;
                string text2 = this.textBox_NokiaSimSwapReturnDeviceSn.Text;
                string path = this.toolParam.ToolFolder + "\\GemsQuery\\GemsQuery.exe";
                this.NokiaSimSwap_InitStatus();
                this.ShowProgressMessage("Query information from GEMS...");
                if (num == 0L)
                {
                    if (text1 == string.Empty)
                    {
                        this.ShowProgressErrorMessage("Returned device SN is empty!");
                        return;
                    }
                    if (text2 == string.Empty)
                    {
                        this.ShowProgressErrorMessage("Connected/new device SN is empty!");
                        return;
                    }
                }
                this.mInfoReturnedDevice = new GemsQueryDeviceInfo(text1);
                this.mInfoNewDevice = new GemsQueryDeviceInfo(text2);
                if (num == 0L)
                {
                    string arguments = string.Format("--func QueryInfo --sn {0}", (object)text1);
                    string empty = string.Empty;
                    if (!Common.LaunchConsole(path, arguments, ref empty))
                    {
                        this.ShowProgressErrorMessage("Launch GemsQuery failed!");
                        return;
                    }
                    if (!this.ParseGemsQueryInfoFromResponse(empty, ref this.mInfoReturnedDevice))
                    {
                        this.ShowProgressErrorMessage("GemsQuery response format error!");
                        return;
                    }
                    this.NokiaSimSwap_ShowReturnDeviceStatus("SIM perso plan: " + (this.mInfoReturnedDevice.HasSimLockPerso() ? "Yes" : "No"));
                    this.NokiaSimSwap_ShowReturnDeviceGuid(this.mInfoReturnedDevice.guid);
                }
                if (num == 0L)
                {
                    string arguments = string.Format("--func QueryInfo --sn {0}", (object)text2);
                    string empty = string.Empty;
                    if (!Common.LaunchConsole(path, arguments, ref empty))
                    {
                        this.ShowProgressErrorMessage("Launch GemsQuery failed!");
                        return;
                    }
                    if (!this.ParseGemsQueryInfoFromResponse(empty, ref this.mInfoNewDevice))
                    {
                        this.ShowProgressErrorMessage("GemsQuery response format error!");
                        return;
                    }
                    this.NokiaSimSwap_ShowNewDeviceGuid(this.mInfoReturnedDevice.guid);
                }
                if (num == 0L)
                {
                    this.ShowProgressMessage("Query information from GEMS succeeded.");
                    return;
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
            }
            this.ShowProgressErrorMessage("Query information from GEMS failed!");
        }

        private bool ParseGemsQueryInfoFromResponse(string response, ref GemsQueryDeviceInfo info)
        {
            StringReader stringReader = new StringReader(response);
            string str1 = string.Empty;
            string str2;
            while ((str2 = stringReader.ReadLine()) != null)
            {
                if (str2.IndexOf("SN:") == 0)
                    info.sn = str2.IndexOf(":") == str2.Length - 1 ? string.Empty : str2.Substring(str2.IndexOf(":") + 1);
                else if (str2.IndexOf("SimLockGuid:") == 0)
                    info.guid = str2.IndexOf(":") == str2.Length - 1 ? string.Empty : str2.Substring(str2.IndexOf(":") + 1);
                else if (str2.IndexOf("SimLockFileName:") == 0)
                    info.simpersoFileName = str2.IndexOf(":") == str2.Length - 1 ? string.Empty : str2.Substring(str2.IndexOf(":") + 1);
                else if (str2.IndexOf("SimLockFileContent:") == 0)
                    info.simpersoFileContent = str2.IndexOf(":") == str2.Length - 1 ? string.Empty : str2.Substring(str2.IndexOf(":") + 1);
                else if (str2.IndexOf("TestResult:") == 0)
                    str1 = str2.IndexOf(":") == str2.Length - 1 ? string.Empty : str2.Substring(str2.IndexOf(":") + 1);
            }
            if (info.sn == string.Empty || info.guid == string.Empty)
            {
                CLogs.E("sn or guid is empty: sn={0}, guid={1}", (object)info.sn, (object)info.guid);
                return false;
            }
            if (!Regex.IsMatch(info.guid, "\\A\\b[0-9a-fA-F]+\\b\\Z"))
            {
                CLogs.E("guid format is incorrect: {0}", (object)info.guid);
                return false;
            }
            try
            {
                new XmlDocument().LoadXml(info.simpersoFileContent);
            }
            catch (XmlException ex)
            {
                CLogs.E("SIM perso content format is incorrect: {0}", (object)info.simpersoFileContent);
                return false;
            }
            return str1.ToUpper() == "PASS";
        }

        private void button_NokiaSimSwapLockNewDevice_Click(object sender, EventArgs e)
        {
            try
            {
                long num = 0;
                int iSimLockStatus = -1;
                string path = this.toolParam.ToolFolder + "\\GemsQuery\\GemsQuery.exe";
                this.ShowProgressMessage("Update connected/new device sim lock and process swap...");
                if (num == 0L && (!this.mInfoReturnedDevice.IsValid() || !this.mInfoNewDevice.IsValid()))
                {
                    this.ShowProgressErrorMessage("Devices information is invalid!");
                    return;
                }
                if (num == 0L)
                {
                    iSimLockStatus = -1;
                    if (num != 0L)
                    {
                        this.ShowProgressErrorMessage("Unlock new device failed!");
                        return;
                    }
                }
                if (num == 0L)
                {
                    if (!this.mInfoReturnedDevice.HasSimLockPerso())
                    {
                        CLogs.I("Bypass to lock new device, since there is no simperso lock requirement for returned device.");
                    }
                    else
                    {
                        iSimLockStatus = -1;
                        if (num != 0L)
                        {
                            this.ShowProgressErrorMessage("Lock new device failed!");
                            return;
                        }
                    }
                }
                if (num == 0L)
                {
                    string arguments = string.Format("--func SwapDevices --returnSN {0} --newSN {0}", (object)this.mInfoReturnedDevice.sn, (object)this.mInfoNewDevice.sn);
                    string empty = string.Empty;
                    if (!Common.LaunchConsole(path, arguments, ref empty))
                    {
                        this.ShowProgressErrorMessage("Launch GemsQuery failed!");
                        return;
                    }
                    if (!this.ParseGemsQueryInfoFromResponse(empty, ref this.mInfoReturnedDevice))
                    {
                        this.ShowProgressErrorMessage("GemsQuery response error!");
                        return;
                    }
                }
                if (num == 0L)
                {
                    this.NokiaSimSwap_ShowNewDeviceStatus("Status: " + this.GetSimLockStatusString(iSimLockStatus));
                    this.ShowProgressMessage("Update new device and swap succeeded.");
                    return;
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
            }
            this.ShowProgressErrorMessage("Update new device or swap failed!");
        }

        private void GemesImeiReset_clearString()
        {
            this.psn = string.Empty;
            this.currentImei1 = string.Empty;
            this.currentImei2 = string.Empty;
            this.currentMeid = string.Empty;
            this.newImei1 = string.Empty;
            this.newImei2 = string.Empty;
            this.newMeid = string.Empty;
            this.ShowProgressErrorMessage("");
            this.newImeiResult = (NewImeiResult)null;
            this.ackImeiStatusResult = (AckImeiStatusResult)null;
        }

        private void btnClick_GemsImeiReset(object sender, EventArgs e)
        {
            this.DisableButton();
            this.GemesImeiReset_clearString();
            this.textBox_GemsImeiReset.Clear();
            this.GemsImeiReset_showTitleMessage("Reading device information...");
            this.GemsImeiReset_ReadProductID();
        }

        private void GemsImeiReset_ReadProductID()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadProductID_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 0, "");
        }

        private void GemsImeiReset_ReadProductID_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage("Read PSN fail!");
                this.GemsImeiReset_showFailureMessage();
            }
            else if (str == string.Empty)
            {
                this.GemsImeiReset_showErrorMessage("Read PSN fail! No FTM response.");
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.psn = str;
                this.GemsImeiReset_showMessage("PSN: " + this.psn);
                this.GemsImeiReset_ReadIMEI1();
            }
        }

        private void GemsImeiReset_ReadIMEI1()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadIMEI1_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 2, "");
        }

        private void GemsImeiReset_ReadIMEI1_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage("Read current IMEI fail!");
                this.GemsImeiReset_showFailureMessage();
            }
            else if (string.IsNullOrEmpty(str))
            {
                this.GemsImeiReset_showErrorMessage("Read current IMEI fail! No FTM response");
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.currentImei1 = str;
                this.GemsImeiReset_showMessage("IMEI1: " + this.currentImei1);
                this.GemsImeiReset_ReadIMEI2();
            }
        }

        private void GemsImeiReset_ReadIMEI2()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadIMEI2_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 4, "");
        }

        private void GemsImeiReset_ReadIMEI2_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            switch (result)
            {
                case 0:
                    if (string.IsNullOrEmpty(str))
                    {
                        this.GemsImeiReset_showErrorMessage("IMEI2: <EMPTY>");
                        this.GemsImeiReset_showFailureMessage();
                        break;
                    }
                    this.currentImei2 = str;
                    this.GemsImeiReset_showMessage("IMEI2: " + this.currentImei2);
                    this.GemsImeiReset_ReadMEID();
                    break;
                case 1646:
                    this.GemsImeiReset_showMessage("IMEI2: N/A.");
                    this.GemsImeiReset_GetNewImei();
                    break;
                default:
                    this.GemsImeiReset_showErrorMessage("IMEI2: N/A");
                    this.GemsImeiReset_showFailureMessage();
                    break;
            }
        }

        private void GemsImeiReset_ReadMEID()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadMEID_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 6, "");
        }

        private void GemsImeiReset_ReadMEID_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            if (result != 0L)
                this.GemsImeiReset_showMessage("MEID: N/A");
            else if (string.IsNullOrEmpty(str))
            {
                this.GemsImeiReset_showMessage("MEID: <EMPTY>");
            }
            else
            {
                this.currentMeid = str;
                this.GemsImeiReset_showMessage("MEID: " + this.currentMeid);
            }
            this.GemsImeiReset_GetNewImei();
        }

        private void GemsImeiReset_GetNewImei()
        {
            if (string.IsNullOrEmpty(this.currentImei2))
                this.currentImei2 = "NA";
            try
            {
                string path = this.toolParam.ToolFolder + "\\GemsQuery\\GemsQuery.exe";
                string arguments = string.Format("--func GetNewImei --psn {0} --imei1 {1} --imei2 {2} --factory {3} --logmode {4} --servermode {5}", (object)this.psn, (object)this.currentImei1, (object)this.currentImei2, (object)this.factoryCode, (object)"normal", (object)"release");
                string empty = string.Empty;
                this.GemsImeiReset_showTitleMessage("Getting new IMEI from GEMs...");
                if (!Common.LaunchConsole(path, arguments, ref empty))
                {
                    this.GemsImeiReset_showErrorMessage("Error message: " + empty + this.newline + "Get new IMEI fails due to console program returns fault.");
                    this.GemsImeiReset_showFailureMessage();
                }
                else
                {
                    this.newImeiResult = JsonConvert.DeserializeObject<NewImeiResult>(empty);
                    string str = "PSN " + this.psn + " with old Primary IMEI " + this.currentImei1 + " is awaiting for Status confirmation from OST, so unable to process new request.";
                    if (this.newImeiResult.SuccessFlag)
                    {
                        this.GemsImeiReset_showMessage("NewPrimaryImei: " + this.newImeiResult.NewPrimaryImei + this.newline + "NewSecondaryImei: " + this.newImeiResult.NewSecondaryImei + this.newline + "NewMeid: " + this.newImeiResult.NewMEID);
                        this.GemsImeiReset_SetNewImei1();
                    }
                    else if (this.newImeiResult.ErrorMessage == str)
                    {
                        this.GemsImeiReset_AckNewImeiRenew();
                    }
                    else
                    {
                        this.GemsImeiReset_showErrorMessage("Error message: " + this.newImeiResult.ErrorMessage);
                        this.GemsImeiReset_showFailureMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                this.GemsImeiReset_showErrorMessage("Exception: " + ex.Message);
                this.GemsImeiReset_showFailureMessage();
            }
        }

        private void GemsImeiReset_AckNewImeiRenew()
        {
            string empty = string.Empty;
            try
            {
                string path = this.toolParam.ToolFolder + "\\GemsQuery\\GemsQuery.exe";
                string arguments = string.Format("--func AckImeiWritten --psn {0} --flag {1} --factory {2} --logmode {3} --servermode {4}", (object)this.psn, (object)"false", (object)this.factoryCode, (object)"normal", (object)"release");
                this.GemsImeiReset_showMessage("Synchronizing with GEMs to renew quest...");
                if (!Common.LaunchConsole(path, arguments, ref empty))
                {
                    this.GemsImeiReset_showErrorMessage("Error message: " + empty + this.newline + "Sync GEMs fails due to console program returns fault.");
                    this.GemsImeiReset_showFailureMessage();
                    return;
                }
                this.ackImeiStatusResult = JsonConvert.DeserializeObject<AckImeiStatusResult>(empty);
                if (this.ackImeiStatusResult.AckFlag == 1)
                    this.GemsImeiReset_showMessage("Sync GEMs to renew quest OK.");
                else
                    this.GemsImeiReset_showMessage("fail to sync GEMs to renew quest, and still try to get new IMEI(s)");
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                if (!string.IsNullOrEmpty(empty))
                    this.GemsImeiReset_showErrorMessage("Error message:" + empty + this.newline + "Sync GEMs fails.");
                this.GemsImeiReset_showErrorMessage("Sync exception: " + ex.Message + this.newline + "Error message: " + this.ackImeiStatusResult.Message);
            }
            this.GemsImeiReset_GetNewImei();
        }

        private void GemsImeiReset_SetNewImei1()
        {
            this.GemsImeiReset_showTitleMessage("Writing new IMEI1...");
            if (string.IsNullOrEmpty(this.newImeiResult.NewPrimaryImei))
            {
                this.GemsImeiReset_showMessage("The new IMEI1 is empty, and thus bypass.");
                this.GemsImeiReset_SetNewImei2();
            }
            else if (this.newImeiResult.NewPrimaryImei.Equals(this.currentImei1))
            {
                this.GemsImeiReset_showMessage("The new IMEI1 is the same as current one, and thus bypass.");
                this.GemsImeiReset_SetNewImei2();
            }
            else
            {
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_SetNewImei1_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 3, this.newImeiResult.NewPrimaryImei);
            }
        }

        private void GemsImeiReset_SetNewImei1_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage(string.Format("Write {0} fail!", (object)this.newImeiResult.NewPrimaryImei));
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.GemsImeiReset_showMessage(string.Format("Write {0} succeed.", (object)this.newImeiResult.NewPrimaryImei));
                this.GemsImeiReset_SetNewImei2();
            }
        }

        private void GemsImeiReset_SetNewImei2()
        {
            this.GemsImeiReset_showTitleMessage("Writing new IMEI2...");
            if (string.IsNullOrEmpty(this.newImeiResult.NewSecondaryImei))
            {
                this.GemsImeiReset_showMessage("The new IMEI2 is empty, and thus bypass.");
                this.GemsImeiReset_SetNewMeid();
            }
            else if (this.newImeiResult.NewSecondaryImei.Equals(this.currentImei2))
            {
                this.GemsImeiReset_showMessage("The new IMEI2 is the same as current one, and thus bypass.");
                this.GemsImeiReset_SetNewMeid();
            }
            else
            {
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_SetNewImei2_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 5, this.newImeiResult.NewSecondaryImei);
            }
        }

        private void GemsImeiReset_SetNewImei2_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage(string.Format("Write {0} fail!", (object)this.newImeiResult.NewSecondaryImei));
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.GemsImeiReset_showMessage(string.Format("Write {0} succeed.", (object)this.newImeiResult.NewSecondaryImei));
                this.GemsImeiReset_SetNewMeid();
            }
        }

        private void GemsImeiReset_SetNewMeid()
        {
            this.GemsImeiReset_showTitleMessage("Writing new MEID...");
            if (string.IsNullOrEmpty(this.newImeiResult.NewMEID))
            {
                this.GemsImeiReset_showMessage("The new MEID is empty, and thus bypass.");
                this.GemsImeiReset_AckNewImeiWritten("true");
            }
            else if (this.newImeiResult.NewMEID.Equals(this.currentMeid))
            {
                this.GemsImeiReset_showMessage("The new MEID is the same as current one, and thus bypass.");
                this.GemsImeiReset_AckNewImeiWritten("true");
            }
            else
            {
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_SetNewMeid_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 7, this.newImeiResult.NewMEID);
            }
        }

        private void GemsImeiReset_SetNewMeid_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage(string.Format("Write {0} fail!", (object)this.newImeiResult.NewMEID));
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.GemsImeiReset_showMessage(string.Format("Write {0} succeed.", (object)this.newImeiResult.NewMEID));
                this.GemsImeiReset_AckNewImeiWritten("true");
            }
        }

        private void GemsImeiReset_AckNewImeiWritten(string successFlag)
        {
            string empty = string.Empty;
            try
            {
                string path = this.toolParam.ToolFolder + "\\GemsQuery\\GemsQuery.exe";
                string arguments = string.Format("--func AckImeiWritten --psn {0} --flag {1} --factory {2} --logmode {3} --servermode {4}", (object)this.psn, (object)successFlag, (object)this.factoryCode, (object)"normal", (object)"release");
                this.GemsImeiReset_showTitleMessage("Synchronizing with GEMs...");
                if (!Common.LaunchConsole(path, arguments, ref empty) && successFlag.Equals("true"))
                {
                    this.GemsImeiReset_showErrorMessage("Error message: " + empty + this.newline + "Sync GEMs fails due to console program returns fault." + this.newline + "Start to roll IMEI(s) back");
                    this.GemsImeiReset_RollBackImei1();
                }
                else
                {
                    this.ackImeiStatusResult = JsonConvert.DeserializeObject<AckImeiStatusResult>(empty);
                    if (this.ackImeiStatusResult.AckFlag == 1)
                    {
                        this.GemsImeiReset_showMessage("Sync GEMs Done.");
                        this.GemsImeiReset_showSuccessMessage();
                    }
                    else
                    {
                        this.GemsImeiReset_showErrorMessage("Sync GEMs fails due to AckFlag is fault." + this.newline + "Error message: " + this.ackImeiStatusResult.Message + this.newline + this.newline + "Start to roll IMEI(s) back");
                        this.GemsImeiReset_RollBackImei1();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                if (!string.IsNullOrEmpty(empty))
                    this.GemsImeiReset_showErrorMessage("Error message:" + empty + this.newline + "Sync GEMs fails.");
                this.GemsImeiReset_showErrorMessage("Sync exception: " + ex.Message + this.newline + "Error message: " + this.ackImeiStatusResult.Message + this.newline + this.newline + "Start to roll IMEI(s) back");
                this.GemsImeiReset_RollBackImei1();
            }
        }

        private void GemsImeiReset_RollBackImei1()
        {
            this.GemsImeiReset_showTitleMessage("Roll back IMEI1...");
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_RollBackImei1_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 3, this.currentImei1);
        }

        private void GemsImeiReset_RollBackImei1_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage(string.Format("Roll back IMEI1: {0} fail!", (object)this.currentImei1));
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.GemsImeiReset_showMessage(string.Format("Roll back IMEI1: {0} succeed.", (object)this.currentImei1));
                this.GemsImeiReset_RollBackImei2();
            }
        }

        private void GemsImeiReset_RollBackImei2()
        {
            this.GemsImeiReset_showTitleMessage("Roll back IMEI2...");
            if (string.IsNullOrEmpty(this.currentImei2))
            {
                this.GemsImeiReset_showMessage("The original IMEI2 is empty, and thus bypass.");
            }
            else
            {
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_RollBackImei2_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 5, this.currentImei2);
            }
        }

        private void GemsImeiReset_RollBackImei2_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
            {
                this.GemsImeiReset_showErrorMessage(string.Format("Roll back IMEI2: {0} fail!", (object)this.currentImei2));
                this.GemsImeiReset_showFailureMessage();
            }
            else
            {
                this.GemsImeiReset_showMessage(string.Format("Roll back IMEI2: {0} succeed.", (object)this.currentImei2));
                this.GemsImeiReset_RollBackMeid();
            }
        }

        private void GemsImeiReset_RollBackMeid()
        {
            this.GemsImeiReset_showTitleMessage("Roll back MEID...");
            if (string.IsNullOrEmpty(this.currentMeid))
            {
                this.GemsImeiReset_showMessage("The original MEID is empty, and thus bypass.");
            }
            else
            {
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_RollBackMeid_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 7, this.currentMeid);
            }
        }

        private void GemsImeiReset_RollBackMeid_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            if (result != 0L)
                this.GemsImeiReset_showErrorMessage(string.Format("Roll back MEID: {0} fail!", (object)this.currentMeid));
            else
                this.GemsImeiReset_showMessage(string.Format("Roll back IMEI2: {0} succeed.", (object)this.currentMeid));
            this.GemsImeiReset_showFailureMessage();
        }

        private void GemsImeiReset_showMessage(string message)
        {
            this.textBox_GemsImeiReset.AppendText(message + this.newline);
            this.textBox_GemsImeiReset.Focus();
            this.textBox_GemsImeiReset.Select(this.textBox_GemsImeiReset.Text.Length, 0);
            this.textBox_GemsImeiReset.ScrollToCaret();
            this.textBox_GemsImeiReset.Refresh();
        }

        private void GemsImeiReset_showErrorMessage(string message)
        {
            this.textBox_GemsImeiReset.SelectionColor = Color.OrangeRed;
            this.GemsImeiReset_showMessage(message);
            this.textBox_GemsImeiReset.SelectionColor = Color.Black;
        }

        private void GemsImeiReset_showFailureMessage()
        {
            Font selectionFont = this.textBox_GemsImeiReset.SelectionFont;
            this.textBox_GemsImeiReset.SelectionFont = new Font(selectionFont.FontFamily, selectionFont.Size + 2f, FontStyle.Bold);
            this.textBox_GemsImeiReset.SelectionColor = Color.Red;
            this.GemsImeiReset_showMessage(this.newline + "Fail to reset IMEI.");
            this.textBox_GemsImeiReset.SelectionColor = Color.Black;
            this.textBox_GemsImeiReset.SelectionFont = selectionFont;
            this.GemsImeiReset_ReadIMEI1ForFinal();
            this.DisplayButton();
        }

        private void GemsImeiReset_showSuccessMessage()
        {
            Font selectionFont = this.textBox_GemsImeiReset.SelectionFont;
            this.textBox_GemsImeiReset.SelectionFont = new Font(selectionFont.FontFamily, selectionFont.Size + 2f, FontStyle.Bold);
            this.textBox_GemsImeiReset.SelectionColor = Color.Blue;
            this.GemsImeiReset_showMessage(this.newline + "Reset IMEI is done.");
            this.textBox_GemsImeiReset.SelectionColor = Color.Black;
            this.textBox_GemsImeiReset.SelectionFont = selectionFont;
            this.GemsImeiReset_ReadIMEI1ForFinal();
            this.DisplayButton();
        }

        private void GemsImeiReset_showTitleMessage(string message)
        {
            Font selectionFont = this.textBox_GemsImeiReset.SelectionFont;
            this.textBox_GemsImeiReset.SelectionFont = new Font(selectionFont.FontFamily, selectionFont.Size + 2f, FontStyle.Bold);
            this.GemsImeiReset_showMessage(this.newline + message);
            this.textBox_GemsImeiReset.SelectionFont = selectionFont;
        }

        private void GemsImeiReset_ReadIMEI1ForFinal()
        {
            this.GemsImeiReset_showTitleMessage("Current IMEI(s) of the device: ");
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadIMEI1ForFinal_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 2, "");
        }

        private void GemsImeiReset_ReadIMEI1ForFinal_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            if (result != 0L)
                this.GemsImeiReset_showErrorMessage("Read current IMEI fail!");
            else if (str == string.Empty)
            {
                this.GemsImeiReset_showErrorMessage("Read current IMEI fail! No FTM response");
            }
            else
            {
                this.currentImei1 = str;
                this.GemsImeiReset_showMessage("IMEI1: " + this.currentImei1);
            }
            this.GemsImeiReset_ReadIMEI2ForFinal();
        }

        private void GemsImeiReset_ReadIMEI2ForFinal()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadIMEI2ForFinal_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 4, "");
        }

        private void GemsImeiReset_ReadIMEI2ForFinal_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            switch (result)
            {
                case 0:
                    if (str == string.Empty)
                    {
                        this.GemsImeiReset_showErrorMessage("Read current IMEI2 fail! No FTM response");
                        break;
                    }
                    this.currentImei2 = str;
                    this.GemsImeiReset_showMessage("IMEI2: " + this.currentImei2);
                    break;
                case 1646:
                    this.GemsImeiReset_showMessage("IMEI2: N/A");
                    break;
                default:
                    this.GemsImeiReset_showErrorMessage("Read current IMEI2 fail!");
                    break;
            }
            this.GemsImeiReset_ReadMeidForFinal();
        }

        private void GemsImeiReset_ReadMeidForFinal()
        {
            DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.GemsImeiReset_ReadMeidForFinal_OnTaskCompleted));
            Sessions.Restart();
            dispatchTask.StartTask_ExecFtmApiFuncion(this.sessionID, this.deviceID, 6, "");
        }

        private void GemsImeiReset_ReadMeidForFinal_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            string str = result == 0L ? outParams["Output"].ToString() : string.Empty;
            if (result != 0L)
                this.GemsImeiReset_showErrorMessage("MEID: N/A");
            else if (str == string.Empty)
            {
                this.GemsImeiReset_showErrorMessage("Read current MEID fail! No FTM response");
            }
            else
            {
                this.currentMeid = str;
                this.GemsImeiReset_showMessage("MEID: " + this.currentMeid);
            }
            this.GemsImeiReset_showTitleMessage("END");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelPhoneKeyWriteTitle = new Label();
            this.btnPhoneKeyWrite = new Button();
            this.labelPhoneKeyReadTitle = new Label();
            this.btnPhoneKeyRead = new Button();
            this.labelPhoneInfoStatus = new Label();
            this.grpBoxPhoneKeyType = new GroupBox();
            this.rdoBtnWallPaperID = new RadioButton();
            this.rdoBtnMEID2 = new RadioButton();
            this.rdoBtnIMEI2 = new RadioButton();
            this.rdoBtnIMEI = new RadioButton();
            this.rdoBtnPSN = new RadioButton();
            this.rdoBtnMEID = new RadioButton();
            this.rdoBtnBTAddr = new RadioButton();
            this.rdoBtnBT2Addr = new RadioButton();
            this.rdoBtnBatteryInfo = new RadioButton();
            this.rdoBtnWiFiAddr = new RadioButton();
            this.btnContinue = new Button();
            this.btnFinish = new Button();
            this.textBoxPhoneKeyWriteValue = new TextBox();
            this.tabControl_PhoneKey = new TabControl();
            this.tabPage_PhoneKey = new TabPage();
            this.textBoxPhoneKeyReadValue = new TextBox();
            this.tabPage_SimLock = new TabPage();
            this.btnGetSimLockStatus = new Button();
            this.btnSelectSimPersoFile = new Button();
            this.textBoxSimPersoFile = new TextBox();
            this.labelSimPersoFileHeader = new Label();
            this.textBoxUnlockCodeValue = new TextBox();
            this.btnLockSIM = new Button();
            this.btnUnlockSIM = new Button();
            this.labelSimLockUnlockCodeHeader = new Label();
            this.labelSimLockStatusValue = new Label();
            this.labelSimLockStatusHeader = new Label();
            this.tabPage_NokiaSimLockSwap = new TabPage();
            this.groupBox_NokiaSimSwapStep2 = new GroupBox();
            this.label_NokiaSimSwap_NewDeviceLockGuid = new Label();
            this.label_NokiaSimSwap_NewDeviceLockStatus = new Label();
            this.button_NokiaSimSwapLockNewDevice = new Button();
            this.textBox_NokiaSimSwapNewDeviceSN = new TextBox();
            this.label_NokiaSimSwapStep2Msg1 = new Label();
            this.groupBox_NokiaSimSwapStep1 = new GroupBox();
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid = new Label();
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus = new Label();
            this.btn_NokiaSimSwapReturnedDeviceQuery = new Button();
            this.textBox_NokiaSimSwapReturnDeviceSn = new TextBox();
            this.label_NokiaSimSwapStep1Msg1 = new Label();
            this.tabPage_GemsImeiReset = new TabPage();
            this.textBox_GemsImeiReset = new RichTextBox();
            this.btn_GemsImeiReset = new Button();
            this.rdoBtnBT2Addr = new RadioButton();
            this.rdoBtnBatteryInfo = new RadioButton();
            this.grpBoxPhoneKeyType.SuspendLayout();
            this.tabControl_PhoneKey.SuspendLayout();
            this.tabPage_PhoneKey.SuspendLayout();
            this.tabPage_SimLock.SuspendLayout();
            this.tabPage_NokiaSimLockSwap.SuspendLayout();
            this.groupBox_NokiaSimSwapStep2.SuspendLayout();
            this.groupBox_NokiaSimSwapStep1.SuspendLayout();
            this.tabPage_GemsImeiReset.SuspendLayout();
            this.SuspendLayout();
            this.labelPhoneKeyWriteTitle.AutoSize = true;
            this.labelPhoneKeyWriteTitle.Font = new Font("Arial", 9f);
            this.labelPhoneKeyWriteTitle.Location = new Point(7, 116);
            this.labelPhoneKeyWriteTitle.Name = "labelPhoneKeyWriteTitle";
            this.labelPhoneKeyWriteTitle.Size = new Size(169, 15);
            this.labelPhoneKeyWriteTitle.TabIndex = 11;
            this.labelPhoneKeyWriteTitle.Text = "LABEL_PHONE_KEY_WRITE";
            this.btnPhoneKeyWrite.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.btnPhoneKeyWrite.Location = new Point(377, 114);
            this.btnPhoneKeyWrite.Name = "btnPhoneKeyWrite";
            this.btnPhoneKeyWrite.Size = new Size(75, 23);
            this.btnPhoneKeyWrite.TabIndex = 15;
            this.btnPhoneKeyWrite.Text = "BTN_PHONE_KEY_WRITE";
            this.btnPhoneKeyWrite.UseVisualStyleBackColor = true;
            this.btnPhoneKeyWrite.Click += new EventHandler(this.btnPhoneKeyWrite_Click);
            this.labelPhoneKeyReadTitle.AutoSize = true;
            this.labelPhoneKeyReadTitle.Font = new Font("Arial", 9f);
            this.labelPhoneKeyReadTitle.Location = new Point(7, 85);
            this.labelPhoneKeyReadTitle.Name = "labelPhoneKeyReadTitle";
            this.labelPhoneKeyReadTitle.Size = new Size(164, 15);
            this.labelPhoneKeyReadTitle.TabIndex = 0;
            this.labelPhoneKeyReadTitle.Text = "LABEL_PHONE_KEY_READ";
            this.btnPhoneKeyRead.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.btnPhoneKeyRead.Location = new Point(377, 82);
            this.btnPhoneKeyRead.Name = "btnPhoneKeyRead";
            this.btnPhoneKeyRead.Size = new Size(75, 23);
            this.btnPhoneKeyRead.TabIndex = 4;
            this.btnPhoneKeyRead.Text = "BTN_PHONE_KEY_READ";
            this.btnPhoneKeyRead.UseVisualStyleBackColor = true;
            this.btnPhoneKeyRead.Click += new EventHandler(this.btnPhoneKeyRead_Click);
            this.labelPhoneInfoStatus.AutoSize = true;
            this.labelPhoneInfoStatus.BackColor = Color.Transparent;
            this.labelPhoneInfoStatus.Font = new Font("Arial", 9f);
            this.labelPhoneInfoStatus.ForeColor = SystemColors.ControlText;
            this.labelPhoneInfoStatus.Location = new Point(12, 375);
            this.labelPhoneInfoStatus.Name = "labelPhoneInfoStatus";
            this.labelPhoneInfoStatus.Size = new Size(166, 15);
            this.labelPhoneInfoStatus.TabIndex = 12;
            this.labelPhoneInfoStatus.Text = "PHONE_KEY_INFO_STATUS";
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnBT2Addr);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnBatteryInfo);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnWallPaperID);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnMEID2);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnIMEI2);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnIMEI);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnPSN);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnMEID);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnBTAddr);
            this.grpBoxPhoneKeyType.Controls.Add((Control)this.rdoBtnWiFiAddr);
            this.grpBoxPhoneKeyType.Font = new Font("Arial", 9f, FontStyle.Bold);
            this.grpBoxPhoneKeyType.Location = new Point(7, 3);
            this.grpBoxPhoneKeyType.Name = "grpBoxPhoneKeyType";
            this.grpBoxPhoneKeyType.Size = new Size(445, 69);
            this.grpBoxPhoneKeyType.TabIndex = 11;
            this.grpBoxPhoneKeyType.TabStop = false;
            this.grpBoxPhoneKeyType.Text = "GROUPBOX_PHONE_KEY_TYPE";
            this.rdoBtnWallPaperID.AutoSize = true;
            this.rdoBtnWallPaperID.Font = new Font("Arial", 9f);
            this.rdoBtnWallPaperID.Location = new Point(160, 44);
            this.rdoBtnWallPaperID.Name = "rdoBtnWallPaperID";
            this.rdoBtnWallPaperID.Size = new Size(97, 19);
            this.rdoBtnWallPaperID.TabIndex = 9;
            this.rdoBtnWallPaperID.TabStop = true;
            this.rdoBtnWallPaperID.Text = "WallPaper ID";
            this.rdoBtnWallPaperID.UseVisualStyleBackColor = true;
            this.rdoBtnWallPaperID.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnMEID2.AutoSize = true;
            this.rdoBtnMEID2.Font = new Font("Arial", 9f);
            this.rdoBtnMEID2.Location = new Point(286, 21);
            this.rdoBtnMEID2.Name = "rdoBtnMEID2";
            this.rdoBtnMEID2.Size = new Size(61, 19);
            this.rdoBtnMEID2.TabIndex = 8;
            this.rdoBtnMEID2.TabStop = true;
            this.rdoBtnMEID2.Text = "MEID2";
            this.rdoBtnMEID2.UseVisualStyleBackColor = true;
            this.rdoBtnMEID2.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnIMEI2.AutoSize = true;
            this.rdoBtnIMEI2.Font = new Font("Arial", 9f);
            this.rdoBtnIMEI2.Location = new Point(160, 21);
            this.rdoBtnIMEI2.Name = "rdoBtnIMEI2";
            this.rdoBtnIMEI2.Size = new Size(55, 19);
            this.rdoBtnIMEI2.TabIndex = 7;
            this.rdoBtnIMEI2.TabStop = true;
            this.rdoBtnIMEI2.Text = "IMEI2";
            this.rdoBtnIMEI2.UseVisualStyleBackColor = true;
            this.rdoBtnIMEI2.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnIMEI.AutoSize = true;
            this.rdoBtnIMEI.Font = new Font("Arial", 9f);
            this.rdoBtnIMEI.Location = new Point(82, 21);
            this.rdoBtnIMEI.Name = "rdoBtnIMEI";
            this.rdoBtnIMEI.Size = new Size(48, 19);
            this.rdoBtnIMEI.TabIndex = 3;
            this.rdoBtnIMEI.TabStop = true;
            this.rdoBtnIMEI.Text = "IMEI";
            this.rdoBtnIMEI.UseVisualStyleBackColor = true;
            this.rdoBtnIMEI.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnPSN.AutoSize = true;
            this.rdoBtnPSN.Font = new Font("Arial", 9f);
            this.rdoBtnPSN.Location = new Point(9, 21);
            this.rdoBtnPSN.Name = "rdoBtnPSN";
            this.rdoBtnPSN.Size = new Size(50, 19);
            this.rdoBtnPSN.TabIndex = 2;
            this.rdoBtnPSN.TabStop = true;
            this.rdoBtnPSN.Text = "PSN";
            this.rdoBtnPSN.UseVisualStyleBackColor = true;
            this.rdoBtnPSN.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnMEID.AutoSize = true;
            this.rdoBtnMEID.Font = new Font("Arial", 9f);
            this.rdoBtnMEID.Location = new Point(226, 21);
            this.rdoBtnMEID.Name = "rdoBtnMEID";
            this.rdoBtnMEID.Size = new Size(54, 19);
            this.rdoBtnMEID.TabIndex = 4;
            this.rdoBtnMEID.TabStop = true;
            this.rdoBtnMEID.Text = "MEID";
            this.rdoBtnMEID.UseVisualStyleBackColor = true;
            this.rdoBtnMEID.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnBTAddr.AutoSize = true;
            this.rdoBtnBTAddr.Font = new Font("Arial", 9f);
            this.rdoBtnBTAddr.Location = new Point(9, 44);
            this.rdoBtnBTAddr.Name = "rdoBtnBTAddr";
            this.rdoBtnBTAddr.Size = new Size(67, 19);
            this.rdoBtnBTAddr.TabIndex = 6;
            this.rdoBtnBTAddr.TabStop = true;
            this.rdoBtnBTAddr.Text = "BT Addr";
            this.rdoBtnBTAddr.UseVisualStyleBackColor = true;
            this.rdoBtnBTAddr.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnBT2Addr.AutoSize = true;
            this.rdoBtnBT2Addr.Font = new Font("Arial", 9f);
            this.rdoBtnBT2Addr.Location = new Point(82, 44);
            this.rdoBtnBT2Addr.Name = "rdoBtnBT2Addr";
            this.rdoBtnBT2Addr.Size = new Size(74, 19);
            this.rdoBtnBT2Addr.TabIndex = 10;
            this.rdoBtnBT2Addr.TabStop = true;
            this.rdoBtnBT2Addr.Text = "BT2 Addr";
            this.rdoBtnBT2Addr.UseVisualStyleBackColor = true;
            this.rdoBtnBT2Addr.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnBatteryInfo.AutoSize = true;
            this.rdoBtnBatteryInfo.Font = new Font("Arial", 9f);
            this.rdoBtnBatteryInfo.Location = new Point(286, 44);
            this.rdoBtnBatteryInfo.Name = "rdoBtnBatteryInfo";
            this.rdoBtnBatteryInfo.Size = new Size(74, 19);
            this.rdoBtnBatteryInfo.TabIndex = 10;
            this.rdoBtnBatteryInfo.TabStop = true;
            this.rdoBtnBatteryInfo.Text = "Battery Info";
            this.rdoBtnBatteryInfo.UseVisualStyleBackColor = true;
            this.rdoBtnBatteryInfo.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.rdoBtnWiFiAddr.AutoSize = true;
            this.rdoBtnWiFiAddr.Font = new Font("Arial", 9f);
            this.rdoBtnWiFiAddr.Location = new Point(357, 21);
            this.rdoBtnWiFiAddr.Name = "rdoBtnWiFiAddr";
            this.rdoBtnWiFiAddr.Size = new Size(76, 19);
            this.rdoBtnWiFiAddr.TabIndex = 5;
            this.rdoBtnWiFiAddr.TabStop = true;
            this.rdoBtnWiFiAddr.Text = "WiFi Addr";
            this.rdoBtnWiFiAddr.UseVisualStyleBackColor = true;
            this.rdoBtnWiFiAddr.CheckedChanged += new EventHandler(this.rdoBtnPhoneKeyInfo_CheckedChanged);
            this.btnContinue.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.btnContinue.Location = new Point(188, 407);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new Size(152, 23);
            this.btnContinue.TabIndex = 15;
            this.btnContinue.Text = "BTN_PHONE_KEY_CONTINUE";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new EventHandler(this.btnContinue_Click);
            this.btnFinish.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.btnFinish.Location = new Point(346, 407);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new Size(152, 23);
            this.btnFinish.TabIndex = 16;
            this.btnFinish.Text = "BTN_PHONE_KEY_FINISH";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new EventHandler(this.btnFinish_Click);
            this.textBoxPhoneKeyWriteValue.Location = new Point(142, 114);
            this.textBoxPhoneKeyWriteValue.Name = "textBoxPhoneKeyWriteValue";
            this.textBoxPhoneKeyWriteValue.Size = new Size(230, 21);
            this.textBoxPhoneKeyWriteValue.TabIndex = 17;
            this.tabControl_PhoneKey.Controls.Add((Control)this.tabPage_PhoneKey);
            this.tabControl_PhoneKey.Controls.Add((Control)this.tabPage_SimLock);
            this.tabControl_PhoneKey.Controls.Add((Control)this.tabPage_NokiaSimLockSwap);
            this.tabControl_PhoneKey.Controls.Add((Control)this.tabPage_GemsImeiReset);
            this.tabControl_PhoneKey.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.tabControl_PhoneKey.Location = new Point(12, 12);
            this.tabControl_PhoneKey.Name = "tabControl_PhoneKey";
            this.tabControl_PhoneKey.SelectedIndex = 0;
            this.tabControl_PhoneKey.Size = new Size(490, 346);
            this.tabControl_PhoneKey.TabIndex = 18;
            this.tabPage_PhoneKey.BackColor = Color.Transparent;
            this.tabPage_PhoneKey.Controls.Add((Control)this.textBoxPhoneKeyReadValue);
            this.tabPage_PhoneKey.Controls.Add((Control)this.grpBoxPhoneKeyType);
            this.tabPage_PhoneKey.Controls.Add((Control)this.textBoxPhoneKeyWriteValue);
            this.tabPage_PhoneKey.Controls.Add((Control)this.labelPhoneKeyWriteTitle);
            this.tabPage_PhoneKey.Controls.Add((Control)this.labelPhoneKeyReadTitle);
            this.tabPage_PhoneKey.Controls.Add((Control)this.btnPhoneKeyRead);
            this.tabPage_PhoneKey.Controls.Add((Control)this.btnPhoneKeyWrite);
            this.tabPage_PhoneKey.Location = new Point(4, 22);
            this.tabPage_PhoneKey.Name = "tabPage_PhoneKey";
            this.tabPage_PhoneKey.Size = new Size(482, 320);
            this.tabPage_PhoneKey.TabIndex = 0;
            this.tabPage_PhoneKey.Text = "Phone Key";
            this.tabPage_PhoneKey.UseVisualStyleBackColor = true;
            this.textBoxPhoneKeyReadValue.Location = new Point(142, 82);
            this.textBoxPhoneKeyReadValue.Name = "textBoxPhoneKeyReadValue";
            this.textBoxPhoneKeyReadValue.ReadOnly = true;
            this.textBoxPhoneKeyReadValue.Size = new Size(230, 21);
            this.textBoxPhoneKeyReadValue.TabIndex = 18;
            this.tabPage_SimLock.BackColor = Color.Transparent;
            this.tabPage_SimLock.Controls.Add((Control)this.btnGetSimLockStatus);
            this.tabPage_SimLock.Controls.Add((Control)this.btnSelectSimPersoFile);
            this.tabPage_SimLock.Controls.Add((Control)this.textBoxSimPersoFile);
            this.tabPage_SimLock.Controls.Add((Control)this.labelSimPersoFileHeader);
            this.tabPage_SimLock.Controls.Add((Control)this.textBoxUnlockCodeValue);
            this.tabPage_SimLock.Controls.Add((Control)this.btnLockSIM);
            this.tabPage_SimLock.Controls.Add((Control)this.btnUnlockSIM);
            this.tabPage_SimLock.Controls.Add((Control)this.labelSimLockUnlockCodeHeader);
            this.tabPage_SimLock.Controls.Add((Control)this.labelSimLockStatusValue);
            this.tabPage_SimLock.Controls.Add((Control)this.labelSimLockStatusHeader);
            this.tabPage_SimLock.Location = new Point(4, 22);
            this.tabPage_SimLock.Name = "tabPage_SimLock";
            this.tabPage_SimLock.Size = new Size(482, 320);
            this.tabPage_SimLock.TabIndex = 0;
            this.tabPage_SimLock.Text = "SIM Lock";
            this.tabPage_SimLock.UseVisualStyleBackColor = true;
            this.tabPage_SimLock.Enter += new EventHandler(this.tabPage_SimLock_Enter);
            this.btnGetSimLockStatus.Location = new Point(397, 25);
            this.btnGetSimLockStatus.Name = "btnGetSimLockStatus";
            this.btnGetSimLockStatus.Size = new Size(72, 25);
            this.btnGetSimLockStatus.TabIndex = 24;
            this.btnGetSimLockStatus.Text = "Get Status";
            this.btnGetSimLockStatus.UseVisualStyleBackColor = true;
            this.btnGetSimLockStatus.Click += new EventHandler(this.btnGetSimLockStatus_Click);
            this.btnSelectSimPersoFile.Location = new Point(358, 98);
            this.btnSelectSimPersoFile.Name = "btnSelectSimPersoFile";
            this.btnSelectSimPersoFile.Size = new Size(34, 25);
            this.btnSelectSimPersoFile.TabIndex = 23;
            this.btnSelectSimPersoFile.Text = "...";
            this.btnSelectSimPersoFile.UseVisualStyleBackColor = true;
            this.btnSelectSimPersoFile.Click += new EventHandler(this.btnSelectSimPersoFile_Click);
            this.textBoxSimPersoFile.Location = new Point(117, 100);
            this.textBoxSimPersoFile.Name = "textBoxSimPersoFile";
            this.textBoxSimPersoFile.Size = new Size(235, 21);
            this.textBoxSimPersoFile.TabIndex = 22;
            this.textBoxSimPersoFile.TextChanged += new EventHandler(this.textBoxSimPersoFile_TextChanged);
            this.labelSimPersoFileHeader.Font = new Font("Arial", 9f);
            this.labelSimPersoFileHeader.Location = new Point(44, 97);
            this.labelSimPersoFileHeader.Name = "labelSimPersoFileHeader";
            this.labelSimPersoFileHeader.Size = new Size(103, 25);
            this.labelSimPersoFileHeader.TabIndex = 21;
            this.labelSimPersoFileHeader.Text = "Perso File:";
            this.labelSimPersoFileHeader.TextAlign = ContentAlignment.MiddleLeft;
            this.textBoxUnlockCodeValue.Location = new Point(117, 65);
            this.textBoxUnlockCodeValue.Name = "textBoxUnlockCodeValue";
            this.textBoxUnlockCodeValue.Size = new Size(275, 21);
            this.textBoxUnlockCodeValue.TabIndex = 20;
            this.textBoxUnlockCodeValue.Text = "1234567890123456";
            this.textBoxUnlockCodeValue.TextChanged += new EventHandler(this.textBoxUnlockCodeValue_TextChanged);
            this.btnLockSIM.Location = new Point(397, 98);
            this.btnLockSIM.Name = "btnLockSIM";
            this.btnLockSIM.Size = new Size(72, 25);
            this.btnLockSIM.TabIndex = 19;
            this.btnLockSIM.Text = "Lock SIM";
            this.btnLockSIM.UseVisualStyleBackColor = true;
            this.btnLockSIM.Click += new EventHandler(this.btnLockSIM_Click);
            this.btnUnlockSIM.Location = new Point(397, 62);
            this.btnUnlockSIM.Name = "btnUnlockSIM";
            this.btnUnlockSIM.Size = new Size(72, 25);
            this.btnUnlockSIM.TabIndex = 6;
            this.btnUnlockSIM.Text = "Unlock SIM";
            this.btnUnlockSIM.UseVisualStyleBackColor = true;
            this.btnUnlockSIM.Click += new EventHandler(this.btnUnlockSIM_Click);
            this.labelSimLockUnlockCodeHeader.Font = new Font("Arial", 9f);
            this.labelSimLockUnlockCodeHeader.Location = new Point(30, 62);
            this.labelSimLockUnlockCodeHeader.Name = "labelSimLockUnlockCodeHeader";
            this.labelSimLockUnlockCodeHeader.Size = new Size(103, 25);
            this.labelSimLockUnlockCodeHeader.TabIndex = 4;
            this.labelSimLockUnlockCodeHeader.Text = "Unlock Code: ";
            this.labelSimLockUnlockCodeHeader.TextAlign = ContentAlignment.MiddleLeft;
            this.labelSimLockStatusValue.BorderStyle = BorderStyle.FixedSingle;
            this.labelSimLockStatusValue.Font = new Font("Arial", 9f);
            this.labelSimLockStatusValue.Location = new Point(117, 25);
            this.labelSimLockStatusValue.Name = "labelSimLockStatusValue";
            this.labelSimLockStatusValue.Size = new Size(275, 25);
            this.labelSimLockStatusValue.TabIndex = 2;
            this.labelSimLockStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            this.labelSimLockStatusHeader.Font = new Font("Arial", 9f);
            this.labelSimLockStatusHeader.Location = new Point(16, 24);
            this.labelSimLockStatusHeader.Name = "labelSimLockStatusHeader";
            this.labelSimLockStatusHeader.Size = new Size(103, 25);
            this.labelSimLockStatusHeader.TabIndex = 1;
            this.labelSimLockStatusHeader.Text = "SIM Lock Status:";
            this.labelSimLockStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
            this.tabPage_NokiaSimLockSwap.Controls.Add((Control)this.groupBox_NokiaSimSwapStep2);
            this.tabPage_NokiaSimLockSwap.Controls.Add((Control)this.groupBox_NokiaSimSwapStep1);
            this.tabPage_NokiaSimLockSwap.Location = new Point(4, 22);
            this.tabPage_NokiaSimLockSwap.Name = "tabPage_NokiaSimLockSwap";
            this.tabPage_NokiaSimLockSwap.Padding = new Padding(3);
            this.tabPage_NokiaSimLockSwap.Size = new Size(482, 320);
            this.tabPage_NokiaSimLockSwap.TabIndex = 1;
            this.tabPage_NokiaSimLockSwap.Text = "Nokia SIM Lock Swap";
            this.tabPage_NokiaSimLockSwap.UseVisualStyleBackColor = true;
            this.tabPage_NokiaSimLockSwap.Enter += new EventHandler(this.tabPage_NokiaSimLockSwap_Enter);
            this.groupBox_NokiaSimSwapStep2.Controls.Add((Control)this.label_NokiaSimSwap_NewDeviceLockGuid);
            this.groupBox_NokiaSimSwapStep2.Controls.Add((Control)this.label_NokiaSimSwap_NewDeviceLockStatus);
            this.groupBox_NokiaSimSwapStep2.Controls.Add((Control)this.button_NokiaSimSwapLockNewDevice);
            this.groupBox_NokiaSimSwapStep2.Controls.Add((Control)this.textBox_NokiaSimSwapNewDeviceSN);
            this.groupBox_NokiaSimSwapStep2.Controls.Add((Control)this.label_NokiaSimSwapStep2Msg1);
            this.groupBox_NokiaSimSwapStep2.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)136);
            this.groupBox_NokiaSimSwapStep2.Location = new Point(17, 140);
            this.groupBox_NokiaSimSwapStep2.Name = "groupBox_NokiaSimSwapStep2";
            this.groupBox_NokiaSimSwapStep2.Size = new Size(444, 101);
            this.groupBox_NokiaSimSwapStep2.TabIndex = 1;
            this.groupBox_NokiaSimSwapStep2.TabStop = false;
            this.groupBox_NokiaSimSwapStep2.Text = "Step 2. Lock new device";
            this.label_NokiaSimSwap_NewDeviceLockGuid.AutoSize = true;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwap_NewDeviceLockGuid.Location = new Point(6, 79);
            this.label_NokiaSimSwap_NewDeviceLockGuid.Name = "label_NokiaSimSwap_NewDeviceLockGuid";
            this.label_NokiaSimSwap_NewDeviceLockGuid.Size = new Size(43, 15);
            this.label_NokiaSimSwap_NewDeviceLockGuid.TabIndex = 7;
            this.label_NokiaSimSwap_NewDeviceLockGuid.Text = "GUID: ";
            this.label_NokiaSimSwap_NewDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_NewDeviceLockStatus.AutoSize = true;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwap_NewDeviceLockStatus.Location = new Point(6, 62);
            this.label_NokiaSimSwap_NewDeviceLockStatus.Name = "label_NokiaSimSwap_NewDeviceLockStatus";
            this.label_NokiaSimSwap_NewDeviceLockStatus.Size = new Size(48, 15);
            this.label_NokiaSimSwap_NewDeviceLockStatus.TabIndex = 4;
            this.label_NokiaSimSwap_NewDeviceLockStatus.Text = "Status: ";
            this.label_NokiaSimSwap_NewDeviceLockStatus.Visible = false;
            this.button_NokiaSimSwapLockNewDevice.Font = new Font("Arial", 9f);
            this.button_NokiaSimSwapLockNewDevice.Location = new Point(345, 35);
            this.button_NokiaSimSwapLockNewDevice.Name = "button_NokiaSimSwapLockNewDevice";
            this.button_NokiaSimSwapLockNewDevice.Size = new Size(88, 23);
            this.button_NokiaSimSwapLockNewDevice.TabIndex = 3;
            this.button_NokiaSimSwapLockNewDevice.Text = "Lock / Swap";
            this.button_NokiaSimSwapLockNewDevice.UseVisualStyleBackColor = true;
            this.button_NokiaSimSwapLockNewDevice.Click += new EventHandler(this.button_NokiaSimSwapLockNewDevice_Click);
            this.textBox_NokiaSimSwapNewDeviceSN.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.textBox_NokiaSimSwapNewDeviceSN.Location = new Point(7, 34);
            this.textBox_NokiaSimSwapNewDeviceSN.Name = "textBox_NokiaSimSwapNewDeviceSN";
            this.textBox_NokiaSimSwapNewDeviceSN.ReadOnly = true;
            this.textBox_NokiaSimSwapNewDeviceSN.Size = new Size(323, 21);
            this.textBox_NokiaSimSwapNewDeviceSN.TabIndex = 2;
            this.label_NokiaSimSwapStep2Msg1.AutoSize = true;
            this.label_NokiaSimSwapStep2Msg1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwapStep2Msg1.Location = new Point(5, 17);
            this.label_NokiaSimSwapStep2Msg1.Name = "label_NokiaSimSwapStep2Msg1";
            this.label_NokiaSimSwapStep2Msg1.Size = new Size(186, 15);
            this.label_NokiaSimSwapStep2Msg1.TabIndex = 0;
            this.label_NokiaSimSwapStep2Msg1.Text = "New device SN (USB connected)";
            this.groupBox_NokiaSimSwapStep1.Controls.Add((Control)this.label_NokiaSimSwap_ReturnedDeviceLockGuid);
            this.groupBox_NokiaSimSwapStep1.Controls.Add((Control)this.label_NokiaSimSwap_ReturnedDeviceLockStatus);
            this.groupBox_NokiaSimSwapStep1.Controls.Add((Control)this.btn_NokiaSimSwapReturnedDeviceQuery);
            this.groupBox_NokiaSimSwapStep1.Controls.Add((Control)this.textBox_NokiaSimSwapReturnDeviceSn);
            this.groupBox_NokiaSimSwapStep1.Controls.Add((Control)this.label_NokiaSimSwapStep1Msg1);
            this.groupBox_NokiaSimSwapStep1.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)136);
            this.groupBox_NokiaSimSwapStep1.Location = new Point(17, 18);
            this.groupBox_NokiaSimSwapStep1.Name = "groupBox_NokiaSimSwapStep1";
            this.groupBox_NokiaSimSwapStep1.Size = new Size(444, 105);
            this.groupBox_NokiaSimSwapStep1.TabIndex = 0;
            this.groupBox_NokiaSimSwapStep1.TabStop = false;
            this.groupBox_NokiaSimSwapStep1.Text = "Step 1. Query returned SIM lock information from GEMS";
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.AutoSize = true;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Location = new Point(5, 83);
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Name = "label_NokiaSimSwap_ReturnedDeviceLockGuid";
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Size = new Size(43, 15);
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.TabIndex = 6;
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Text = "GUID: ";
            this.label_NokiaSimSwap_ReturnedDeviceLockGuid.Visible = false;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.AutoSize = true;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Location = new Point(5, 64);
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Name = "label_NokiaSimSwap_ReturnedDeviceLockStatus";
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Size = new Size(48, 15);
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.TabIndex = 5;
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Text = "Status: ";
            this.label_NokiaSimSwap_ReturnedDeviceLockStatus.Visible = false;
            this.btn_NokiaSimSwapReturnedDeviceQuery.Font = new Font("Arial", 9f);
            this.btn_NokiaSimSwapReturnedDeviceQuery.Location = new Point(345, 37);
            this.btn_NokiaSimSwapReturnedDeviceQuery.Name = "btn_NokiaSimSwapReturnedDeviceQuery";
            this.btn_NokiaSimSwapReturnedDeviceQuery.Size = new Size(88, 23);
            this.btn_NokiaSimSwapReturnedDeviceQuery.TabIndex = 2;
            this.btn_NokiaSimSwapReturnedDeviceQuery.Text = "Query";
            this.btn_NokiaSimSwapReturnedDeviceQuery.UseVisualStyleBackColor = true;
            this.btn_NokiaSimSwapReturnedDeviceQuery.Click += new EventHandler(this.btn_NokiaSimSwapDevicesInfoQuery_Click);
            this.textBox_NokiaSimSwapReturnDeviceSn.Font = new Font("Arial", 9f);
            this.textBox_NokiaSimSwapReturnDeviceSn.Location = new Point(8, 38);
            this.textBox_NokiaSimSwapReturnDeviceSn.Name = "textBox_NokiaSimSwapReturnDeviceSn";
            this.textBox_NokiaSimSwapReturnDeviceSn.Size = new Size(322, 21);
            this.textBox_NokiaSimSwapReturnDeviceSn.TabIndex = 1;
            this.label_NokiaSimSwapStep1Msg1.AutoSize = true;
            this.label_NokiaSimSwapStep1Msg1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label_NokiaSimSwapStep1Msg1.Location = new Point(6, 21);
            this.label_NokiaSimSwapStep1Msg1.Name = "label_NokiaSimSwapStep1Msg1";
            this.label_NokiaSimSwapStep1Msg1.Size = new Size(183, 15);
            this.label_NokiaSimSwapStep1Msg1.TabIndex = 0;
            this.label_NokiaSimSwapStep1Msg1.Text = "Please input returned device SN";
            this.tabPage_GemsImeiReset.Controls.Add((Control)this.textBox_GemsImeiReset);
            this.tabPage_GemsImeiReset.Controls.Add((Control)this.btn_GemsImeiReset);
            this.tabPage_GemsImeiReset.Location = new Point(4, 22);
            this.tabPage_GemsImeiReset.Name = "tabPage_GemsImeiReset";
            this.tabPage_GemsImeiReset.Padding = new Padding(3);
            this.tabPage_GemsImeiReset.Size = new Size(482, 320);
            this.tabPage_GemsImeiReset.TabIndex = 2;
            this.tabPage_GemsImeiReset.Text = "Online IMEI Reset";
            this.tabPage_GemsImeiReset.UseVisualStyleBackColor = true;
            this.textBox_GemsImeiReset.Location = new Point(18, 59);
            this.textBox_GemsImeiReset.Name = "textBox_GemsImeiReset";
            this.textBox_GemsImeiReset.Size = new Size(444, 243);
            this.textBox_GemsImeiReset.TabIndex = 1;
            this.textBox_GemsImeiReset.Text = "";
            this.btn_GemsImeiReset.Location = new Point(18, 15);
            this.btn_GemsImeiReset.Name = "btn_GemsImeiReset";
            this.btn_GemsImeiReset.Size = new Size(444, 29);
            this.btn_GemsImeiReset.TabIndex = 0;
            this.btn_GemsImeiReset.Text = "Reset IMEI";
            this.btn_GemsImeiReset.UseVisualStyleBackColor = true;
            this.btn_GemsImeiReset.Click += new EventHandler(this.btnClick_GemsImeiReset);
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(514, 442);
            this.Controls.Add((Control)this.tabControl_PhoneKey);
            this.Controls.Add((Control)this.labelPhoneInfoStatus);
            this.Controls.Add((Control)this.btnFinish);
            this.Controls.Add((Control)this.btnContinue);
            this.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)136);
            this.Name = nameof(Form_PhoneKeyInfo);
            this.Text = "Edit Phone Information";
            this.Load += new EventHandler(this.Form_PhoneInfo_Load);
            this.grpBoxPhoneKeyType.ResumeLayout(false);
            this.grpBoxPhoneKeyType.PerformLayout();
            this.tabControl_PhoneKey.ResumeLayout(false);
            this.tabPage_PhoneKey.ResumeLayout(false);
            this.tabPage_PhoneKey.PerformLayout();
            this.tabPage_SimLock.ResumeLayout(false);
            this.tabPage_SimLock.PerformLayout();
            this.tabPage_NokiaSimLockSwap.ResumeLayout(false);
            this.groupBox_NokiaSimSwapStep2.ResumeLayout(false);
            this.groupBox_NokiaSimSwapStep2.PerformLayout();
            this.groupBox_NokiaSimSwapStep1.ResumeLayout(false);
            this.groupBox_NokiaSimSwapStep1.PerformLayout();
            this.tabPage_GemsImeiReset.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SimLockPage_DisableButtons()
        {
            this.labelSimLockStatusValue.Text = "";
            this.btnLockSIM.Enabled = false;
            this.btnUnlockSIM.Enabled = false;
        }

        private void tabPage_SimLock_Enter(object sender, EventArgs e)
        {
            this.SimLockPage_DisableButtons();
            this.textBoxUnlockCodeValue_TextChanged(sender, e);
        }

        private void btnGetSimLockStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelSimLockStatusValue.Text = "";
                this.ShowProgressMessage("Get SIM status...");
                CLogs.I("Unlock code: " + RsaCrypt.EncryptLog(this.textBoxUnlockCodeValue.Text));
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.ExecSimLockFunction_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecSimLockFunction(this.sessionID, this.deviceID, 0, string.Empty, string.Empty, string.Empty);
                this.DisableButton();
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                this.ShowProgressErrorMessage("Get SIM status fail! Get Exception!");
                this.DisplayButton();
            }
        }

        private void ExecSimLockFunction_OnTaskCompleted(
          long result,
          Dictionary<string, object> outParams)
        {
            int iSimLockStatus = -1;
            string str = "Unknown SIM lock function";
            try
            {
                switch (Convert.ToInt32(outParams["FuncType"]))
                {
                    case 0:
                        str = "Get SIM status";
                        break;
                    case 1:
                        str = "Lock SIM";
                        break;
                    case 2:
                        str = "Unlock SIM";
                        break;
                }
                if (result == 0L)
                {
                    iSimLockStatus = Convert.ToInt32(outParams["SimLockStatus"]);
                    this.ShowProgressMessage("{0} succeed.", (object)str);
                }
                else
                    this.ShowProgressErrorMessage("{0} fail!", (object)str);
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                this.ShowProgressErrorMessage("{0} fail! Get exception!", (object)str);
            }
            this.labelSimLockStatusValue.Text = this.GetSimLockStatusString(iSimLockStatus);
            this.DisplayButton();
        }

        private void btnUnlockSIM_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelSimLockStatusValue.Text = "";
                this.ShowProgressMessage("Unlock SIM...");
                CLogs.I("Unlock code: " + RsaCrypt.EncryptLog(this.textBoxUnlockCodeValue.Text));
                DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.ExecSimLockFunction_OnTaskCompleted));
                Sessions.Restart();
                dispatchTask.StartTask_ExecSimLockFunction(this.sessionID, this.deviceID, 2, this.textBoxUnlockCodeValue.Text, string.Empty, string.Empty);
                this.DisableButton();
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                this.ShowProgressErrorMessage("Unlock SIM fail! Get Exception!");
                this.DisplayButton();
            }
        }

        private void btnLockSIM_Click(object sender, EventArgs e)
        {
            try
            {
                string text1 = this.textBoxSimPersoFile.Text;
                if (!File.Exists(text1))
                {
                    this.ShowProgressErrorMessage("Error! SIM perso file not found!");
                }
                else
                {
                    string simpersoFileContent = File.ReadAllText(text1);
                    string fileName = Path.GetFileName(text1);
                    string text2 = this.textBoxUnlockCodeValue.Text;
                    if (simpersoFileContent == string.Empty)
                        this.ShowProgressErrorMessage("Error! SIM perso file format invalid!");
                    else if (text2 == string.Empty)
                    {
                        this.ShowProgressErrorMessage("Error! Unlock code is empty!");
                    }
                    else
                    {
                        this.labelSimLockStatusValue.Text = "";
                        this.ShowProgressMessage("Lock SIM...");
                        CLogs.I("Unlock code: " + RsaCrypt.EncryptLog(this.textBoxUnlockCodeValue.Text));
                        DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.ExecSimLockFunction_OnTaskCompleted));
                        Sessions.Restart();
                        dispatchTask.StartTask_ExecSimLockFunction(this.sessionID, this.deviceID, 1, text2, fileName, simpersoFileContent);
                        this.DisableButton();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogs.E("Get exception: " + ex.Message + ex.StackTrace);
                this.ShowProgressErrorMessage("Lock SIM fail! Get Exception!");
                this.DisplayButton();
            }
        }

        private void btnSelectSimPersoFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = UserConfig.Instance.InitSimPersoDir;
            openFileDialog.Filter = "SIM perso files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() != DialogResult.OK || !Path.GetExtension(openFileDialog.FileName).Equals(".xml"))
                return;
            this.textBoxSimPersoFile.Text = Path.GetFullPath(openFileDialog.FileName);
            UserConfig.Instance.InitSimPersoDir = Path.GetDirectoryName(openFileDialog.FileName);
        }

        private string GetSimLockStatusString(int iSimLockStatus)
        {
            if (iSimLockStatus == 0)
                return "Unlock";
            return iSimLockStatus == 1 ? "Lock" : "Unknown";
        }

        private void textBoxSimPersoFile_TextChanged(object sender, EventArgs e) => this.btnLockSIM.Enabled = this.textBoxUnlockCodeValue.Text.Length >= 16 && File.Exists(this.textBoxSimPersoFile.Text);

        private void textBoxUnlockCodeValue_TextChanged(object sender, EventArgs e)
        {
            this.btnUnlockSIM.Enabled = this.textBoxUnlockCodeValue.Text.Length >= 16;
            this.btnLockSIM.Enabled = this.textBoxUnlockCodeValue.Text.Length >= 16 && File.Exists(this.textBoxSimPersoFile.Text);
        }
    }
}
