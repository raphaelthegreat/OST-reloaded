// Decompiled with JetBrains decompiler
// Type: MainForms.Form1
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using DataCollection.DataFileCache;
using Deployment;
using Devices;
using ErrorDef;
using Framework.Controls;
using HookKeyboards;
using Locales;
using MRG.Controls.UI;
using MyCommonFunction;
using MyResources.Properties;
using PageControl;
using Params;
using Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Tasks;
using UserForms;
using Utils;

namespace MainForms
{
  public class Form1 : Form
  {
    private IContainer components;
    private Button btnBack;
    private Button btnNext;
    private Button btnCancel;
    private TabControl tabPageCtrl;
    private TabPage tabPageWelcome;
    private TabPage tabPageSelectedFw;
    private TabPage tabPageOnlineFw;
    private TextBox textBoxSelectedFw;
    private Button btnSelectedFw;
    private TabPage tabPageProgress;
    private TabPage tabPageMultiProgress;
    private TabPage tabPageFinish;
    private Label labelWelcomeTag;
    private XpProgressBar progressBarUpdate;
    private Label labelWelcomeMsg;
    private Label labelFinishTag;
    private Label labelFinishErrorCode;
    private Label labelSelectedFwStep;
    private Label labelSelectedFwStatus;
    private Label labelOnlineFwStatus;
    private Label labelSelectedFwMsg;
    private Label labelOnlineFwCurrentVersionTag;
    private Label labelWelcomeStatus;
    private Timer timerFetchMsg;
    private Label labelProgressWarning;
    private Label labelWelcomeTitle;
    private Label labelFinishTitle;
    private Label labelProgressTitle;
    private Label labelMultiProgressTitle;
    private Label labelSelectedFwTitle;
    private Label labelOnlineFwTitle;
    private TabPage tabPageBundledFw;
    private Label labelBundledFwTitle;
    private Label labelBundledFwStatus;
    private Label labelBundledFwStep;
    private Label labelWelcomeWarning;
    private Label labelFinishErrorMsg;
    private Label labelBundledFwTag;
    private Label labelBundledFwWarning;
    private Label labelProgreeMsg;
    private Timer timerCountRunTime;
    private Timer timerAutoRun;
    private Label labelSelectedFwOption;
    private Label labelOnlineFwOption;
    private ComboBoxEx comboBoxSelectedFwOption;
    private ComboBoxEx comboBoxOnlineFwOption;
    private FlowLayoutPanel flowLayoutPanelMultiProgress;
    private Label labelMultiProgressStatus;
    private Label labelMultiProgressMsgPanel;
    private Label labelOnlineFwNewVersionTag;
    private Label labelOnlineFwCurrentVersion;
    private ComboBox comboBoxOnlineFwNewVersion;
    private Label labelOnlineFwModelTag;
    private Label labelOnlineFwModel;
    private LoadingCircle loadingCircleOnlineFwStatus;
    private Button btnOnlineFw;
    private Label labelOnlineFwStep;
    private Button btnPhoneKeyInfo;
    private Label label_dev_sw_ver;
    private ToolParam toolParam;
    private FwPage fwPage;
    private PageFlow pageFlow;
    private MyDevice detector;
    private Product product;
    private int runTime;
    private string title;
    private bool autoRun;
    private DateTime autoRunTime;
    private Label lableOption;
    private ComboBoxEx comboBoxOption;
    private ShowWarningDialogDelegate showWarningDialogDelegate;
    private ShowEnterSpcDialogDelegate showEnterSpcDialogDelegate;
    private ShowReEnterSpcDialogDelegate showReEnterSpcDialogDelegate;
    private ShowModelWarningDialogDelegate showModelWarningDialogDelegate;
    private ShowModelSelectSkuIdDialogDelegate showModelSelectSkuIdDialogDelegate;
    private AcquireAuthenticationDelegate doAuthenticationDelegate;
    private DoReportServiceResultDelegate doReportServiceResultDelegate;
    private QueryServerSimUnlockCode queryServerSimUnlockCode;
    private DeleteServerSimUnlockCode deleteServerSimUnlockCode;
    private Timer timerDataCollection;
    private DeploymentTask deploymentTask;
    private Timer timerDeployment;
    private ProgressItem progressItem;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.tabPageCtrl = new TabControl();
      this.tabPageWelcome = new TabPage();
      this.labelWelcomeWarning = new Label();
      this.labelWelcomeTitle = new Label();
      this.labelWelcomeStatus = new Label();
      this.labelWelcomeMsg = new Label();
      this.labelWelcomeTag = new Label();
      this.tabPageBundledFw = new TabPage();
      this.labelBundledFwWarning = new Label();
      this.labelBundledFwTag = new Label();
      this.labelBundledFwStep = new Label();
      this.labelBundledFwStatus = new Label();
      this.labelBundledFwTitle = new Label();
      this.tabPageSelectedFw = new TabPage();
      this.btnPhoneKeyInfo = new Button();
      this.labelSelectedFwOption = new Label();
      this.comboBoxSelectedFwOption = new ComboBoxEx();
      this.label_dev_sw_ver = new Label();
      this.labelSelectedFwStatus = new Label();
      this.labelSelectedFwTitle = new Label();
      this.labelSelectedFwMsg = new Label();
      this.labelSelectedFwStep = new Label();
      this.textBoxSelectedFw = new TextBox();
      this.btnSelectedFw = new Button();
      this.tabPageOnlineFw = new TabPage();
      this.labelOnlineFwStep = new Label();
      this.btnOnlineFw = new Button();
      this.loadingCircleOnlineFwStatus = new LoadingCircle();
      this.labelOnlineFwModel = new Label();
      this.labelOnlineFwModelTag = new Label();
      this.comboBoxOnlineFwNewVersion = new ComboBox();
      this.labelOnlineFwCurrentVersion = new Label();
      this.labelOnlineFwNewVersionTag = new Label();
      this.labelOnlineFwOption = new Label();
      this.comboBoxOnlineFwOption = new ComboBoxEx();
      this.labelOnlineFwStatus = new Label();
      this.labelOnlineFwTitle = new Label();
      this.labelOnlineFwCurrentVersionTag = new Label();
      this.tabPageProgress = new TabPage();
      this.labelProgressTitle = new Label();
      this.labelProgressWarning = new Label();
      this.labelProgreeMsg = new Label();
      this.progressBarUpdate = new XpProgressBar();
      this.tabPageMultiProgress = new TabPage();
      this.labelMultiProgressMsgPanel = new Label();
      this.flowLayoutPanelMultiProgress = new FlowLayoutPanel();
      this.labelMultiProgressStatus = new Label();
      this.labelMultiProgressTitle = new Label();
      this.tabPageFinish = new TabPage();
      this.labelFinishErrorMsg = new Label();
      this.labelFinishTitle = new Label();
      this.labelFinishErrorCode = new Label();
      this.labelFinishTag = new Label();
      this.timerFetchMsg = new Timer(this.components);
      this.timerCountRunTime = new Timer(this.components);
      this.timerAutoRun = new Timer(this.components);
      this.btnNext = new Button();
      this.btnCancel = new Button();
      this.btnBack = new Button();
      this.tabPageCtrl.SuspendLayout();
      this.tabPageWelcome.SuspendLayout();
      this.tabPageBundledFw.SuspendLayout();
      this.tabPageSelectedFw.SuspendLayout();
      this.tabPageOnlineFw.SuspendLayout();
      this.tabPageProgress.SuspendLayout();
      this.tabPageMultiProgress.SuspendLayout();
      this.tabPageFinish.SuspendLayout();
      this.SuspendLayout();
      this.tabPageCtrl.Controls.Add((Control) this.tabPageWelcome);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageBundledFw);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageSelectedFw);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageOnlineFw);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageProgress);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageMultiProgress);
      this.tabPageCtrl.Controls.Add((Control) this.tabPageFinish);
      this.tabPageCtrl.ItemSize = new Size(1, 0);
      this.tabPageCtrl.Location = new Point(-4, -25);
      this.tabPageCtrl.Margin = new Padding(0);
      this.tabPageCtrl.Name = "tabPageCtrl";
      this.tabPageCtrl.SelectedIndex = 3;
      this.tabPageCtrl.Size = new Size(664, 521);
      this.tabPageCtrl.SizeMode = TabSizeMode.Fixed;
      this.tabPageCtrl.TabIndex = 3;
      this.tabPageCtrl.SelectedIndexChanged += new EventHandler(this.tabPageCtrl_SelectedIndexChanged);
      this.tabPageWelcome.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageWelcome.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageWelcome.Controls.Add((Control) this.labelWelcomeWarning);
      this.tabPageWelcome.Controls.Add((Control) this.labelWelcomeTitle);
      this.tabPageWelcome.Controls.Add((Control) this.labelWelcomeStatus);
      this.tabPageWelcome.Controls.Add((Control) this.labelWelcomeMsg);
      this.tabPageWelcome.Controls.Add((Control) this.labelWelcomeTag);
      this.tabPageWelcome.Location = new Point(4, 25);
      this.tabPageWelcome.Margin = new Padding(3, 4, 3, 4);
      this.tabPageWelcome.Name = "tabPageWelcome";
      this.tabPageWelcome.Size = new Size(656, 492);
      this.tabPageWelcome.TabIndex = 1;
      this.tabPageWelcome.Text = "tabPageWelcome";
      this.tabPageWelcome.UseVisualStyleBackColor = true;
      this.labelWelcomeWarning.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelWelcomeWarning.ForeColor = Color.Red;
      this.labelWelcomeWarning.Location = new Point(67, 340);
      this.labelWelcomeWarning.Name = "labelWelcomeWarning";
      this.labelWelcomeWarning.Size = new Size(549, 60);
      this.labelWelcomeWarning.TabIndex = 3;
      this.labelWelcomeWarning.Text = "WELCOME_WARNING";
      this.labelWelcomeTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelWelcomeTitle.ForeColor = Color.MidnightBlue;
      this.labelWelcomeTitle.Location = new Point(19, 17);
      this.labelWelcomeTitle.Name = "labelWelcomeTitle";
      this.labelWelcomeTitle.Size = new Size(403, 73);
      this.labelWelcomeTitle.TabIndex = 0;
      this.labelWelcomeTitle.Text = "TITLE";
      this.labelWelcomeStatus.AutoSize = true;
      this.labelWelcomeStatus.Location = new Point(25, 405);
      this.labelWelcomeStatus.Name = "labelWelcomeStatus";
      this.labelWelcomeStatus.Size = new Size(140, 16);
      this.labelWelcomeStatus.TabIndex = 4;
      this.labelWelcomeStatus.Text = "XXX_STATUS_NEXT";
      this.labelWelcomeMsg.AutoSize = true;
      this.labelWelcomeMsg.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelWelcomeMsg.Location = new Point(67, 171);
      this.labelWelcomeMsg.Name = "labelWelcomeMsg";
      this.labelWelcomeMsg.Size = new Size(111, 16);
      this.labelWelcomeMsg.TabIndex = 2;
      this.labelWelcomeMsg.Text = "WELCOME_MSG";
      this.labelWelcomeTag.AutoSize = true;
      this.labelWelcomeTag.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelWelcomeTag.Location = new Point(49, 137);
      this.labelWelcomeTag.Name = "labelWelcomeTag";
      this.labelWelcomeTag.Size = new Size(118, 16);
      this.labelWelcomeTag.TabIndex = 1;
      this.labelWelcomeTag.Text = "WELCOME_TAG";
      this.tabPageBundledFw.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageBundledFw.BackgroundImageLayout = ImageLayout.Stretch;
      this.tabPageBundledFw.Controls.Add((Control) this.labelBundledFwWarning);
      this.tabPageBundledFw.Controls.Add((Control) this.labelBundledFwTag);
      this.tabPageBundledFw.Controls.Add((Control) this.labelBundledFwStep);
      this.tabPageBundledFw.Controls.Add((Control) this.labelBundledFwStatus);
      this.tabPageBundledFw.Controls.Add((Control) this.labelBundledFwTitle);
      this.tabPageBundledFw.Location = new Point(4, 25);
      this.tabPageBundledFw.Name = "tabPageBundledFw";
      this.tabPageBundledFw.Padding = new Padding(3);
      this.tabPageBundledFw.Size = new Size(656, 492);
      this.tabPageBundledFw.TabIndex = 6;
      this.tabPageBundledFw.Text = "tabPageBundledFw";
      this.tabPageBundledFw.UseVisualStyleBackColor = true;
      this.labelBundledFwWarning.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelBundledFwWarning.ForeColor = Color.Red;
      this.labelBundledFwWarning.Location = new Point(67, 340);
      this.labelBundledFwWarning.Name = "labelBundledFwWarning";
      this.labelBundledFwWarning.Size = new Size(549, 60);
      this.labelBundledFwWarning.TabIndex = 3;
      this.labelBundledFwWarning.Text = "WELCOME_WARNING";
      this.labelBundledFwTag.AutoSize = true;
      this.labelBundledFwTag.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelBundledFwTag.Location = new Point(49, 137);
      this.labelBundledFwTag.Name = "labelBundledFwTag";
      this.labelBundledFwTag.Size = new Size(118, 16);
      this.labelBundledFwTag.TabIndex = 1;
      this.labelBundledFwTag.Text = "WELCOME_TAG";
      this.labelBundledFwStep.AllowDrop = true;
      this.labelBundledFwStep.AutoEllipsis = true;
      this.labelBundledFwStep.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelBundledFwStep.Location = new Point(67, 171);
      this.labelBundledFwStep.Name = "labelBundledFwStep";
      this.labelBundledFwStep.Size = new Size(527, 154);
      this.labelBundledFwStep.TabIndex = 2;
      this.labelBundledFwStep.Text = "WELCOME_MSG;SELECTED_FW_STEP_L1;SELECTED_FW_STEP_L2_NORMAL;SELECTED_FW_STEP_L3_NORMAL;SELECTED_FW_STEP_L4_NORMAL";
      this.labelBundledFwStatus.AutoSize = true;
      this.labelBundledFwStatus.BackColor = Color.Transparent;
      this.labelBundledFwStatus.ForeColor = SystemColors.ControlText;
      this.labelBundledFwStatus.Location = new Point(25, 405);
      this.labelBundledFwStatus.Name = "labelBundledFwStatus";
      this.labelBundledFwStatus.Size = new Size(140, 16);
      this.labelBundledFwStatus.TabIndex = 4;
      this.labelBundledFwStatus.Text = "XXX_STATUS_NEXT";
      this.labelBundledFwTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelBundledFwTitle.ForeColor = Color.MidnightBlue;
      this.labelBundledFwTitle.Location = new Point(19, 17);
      this.labelBundledFwTitle.Name = "labelBundledFwTitle";
      this.labelBundledFwTitle.Size = new Size(403, 73);
      this.labelBundledFwTitle.TabIndex = 0;
      this.labelBundledFwTitle.Text = "TITLE";
      this.tabPageSelectedFw.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageSelectedFw.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageSelectedFw.Controls.Add((Control) this.btnPhoneKeyInfo);
      this.tabPageSelectedFw.Controls.Add((Control) this.labelSelectedFwOption);
      this.tabPageSelectedFw.Controls.Add((Control) this.comboBoxSelectedFwOption);
      this.tabPageSelectedFw.Controls.Add((Control) this.label_dev_sw_ver);
      this.tabPageSelectedFw.Controls.Add((Control) this.labelSelectedFwStatus);
      this.tabPageSelectedFw.Controls.Add((Control) this.labelSelectedFwTitle);
      this.tabPageSelectedFw.Controls.Add((Control) this.labelSelectedFwMsg);
      this.tabPageSelectedFw.Controls.Add((Control) this.labelSelectedFwStep);
      this.tabPageSelectedFw.Controls.Add((Control) this.textBoxSelectedFw);
      this.tabPageSelectedFw.Controls.Add((Control) this.btnSelectedFw);
      this.tabPageSelectedFw.Location = new Point(4, 25);
      this.tabPageSelectedFw.Margin = new Padding(3, 4, 3, 4);
      this.tabPageSelectedFw.Name = "tabPageSelectedFw";
      this.tabPageSelectedFw.Size = new Size(656, 492);
      this.tabPageSelectedFw.TabIndex = 3;
      this.tabPageSelectedFw.Text = "tabPageSelectedFw";
      this.tabPageSelectedFw.UseVisualStyleBackColor = true;
      this.btnPhoneKeyInfo.Enabled = false;
      this.btnPhoneKeyInfo.Location = new Point(410, 390);
      this.btnPhoneKeyInfo.Name = "btnPhoneKeyInfo";
      this.btnPhoneKeyInfo.Size = new Size(222, 31);
      this.btnPhoneKeyInfo.TabIndex = 8;
      this.btnPhoneKeyInfo.Text = "BTN_PHONE_KEY_INFO";
      this.btnPhoneKeyInfo.UseVisualStyleBackColor = true;
      this.btnPhoneKeyInfo.Click += new EventHandler(this.btnPhoneKeyInfo_Click);
      this.labelSelectedFwOption.AutoSize = true;
      this.labelSelectedFwOption.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelSelectedFwOption.Location = new Point(34, 190);
      this.labelSelectedFwOption.Name = "labelSelectedFwOption";
      this.labelSelectedFwOption.Size = new Size(156, 14);
      this.labelSelectedFwOption.TabIndex = 4;
      this.labelSelectedFwOption.Text = "SELECTED_FW_OPTION";
      this.labelSelectedFwOption.Visible = false;
      this.comboBoxSelectedFwOption.DrawMode = DrawMode.OwnerDrawFixed;
      this.comboBoxSelectedFwOption.DropDownHeight = 1;
      this.comboBoxSelectedFwOption.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxSelectedFwOption.FormattingEnabled = true;
      this.comboBoxSelectedFwOption.IntegralHeight = false;
      this.comboBoxSelectedFwOption.IsMutilpeSelect = true;
      this.comboBoxSelectedFwOption.Location = new Point(133, 187);
      this.comboBoxSelectedFwOption.Name = "comboBoxSelectedFwOption";
      this.comboBoxSelectedFwOption.Size = new Size(443, 23);
      this.comboBoxSelectedFwOption.TabIndex = 5;
      this.comboBoxSelectedFwOption.Visible = false;
      this.label_dev_sw_ver.AutoSize = true;
      this.label_dev_sw_ver.BackColor = Color.Transparent;
      this.label_dev_sw_ver.ForeColor = SystemColors.ControlText;
      this.label_dev_sw_ver.Location = new Point(25, 453);
      this.label_dev_sw_ver.Name = "label_dev_sw_ver";
      this.label_dev_sw_ver.Size = new Size(175, 16);
      this.label_dev_sw_ver.TabIndex = 7;
      this.label_dev_sw_ver.Text = "SW version of the device";
      this.labelSelectedFwStatus.AutoSize = true;
      this.labelSelectedFwStatus.BackColor = Color.Transparent;
      this.labelSelectedFwStatus.ForeColor = SystemColors.ControlText;
      this.labelSelectedFwStatus.Location = new Point(25, 405);
      this.labelSelectedFwStatus.Name = "labelSelectedFwStatus";
      this.labelSelectedFwStatus.Size = new Size(175, 16);
      this.labelSelectedFwStatus.TabIndex = 7;
      this.labelSelectedFwStatus.Text = "XXX_STATUS_NO_IMAGE";
      this.labelSelectedFwTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelSelectedFwTitle.ForeColor = Color.MidnightBlue;
      this.labelSelectedFwTitle.Location = new Point(19, 17);
      this.labelSelectedFwTitle.Name = "labelSelectedFwTitle";
      this.labelSelectedFwTitle.Size = new Size(403, 73);
      this.labelSelectedFwTitle.TabIndex = 0;
      this.labelSelectedFwTitle.Text = "TITLE";
      this.labelSelectedFwMsg.AutoSize = true;
      this.labelSelectedFwMsg.Location = new Point(34, 126);
      this.labelSelectedFwMsg.Name = "labelSelectedFwMsg";
      this.labelSelectedFwMsg.Size = new Size(141, 16);
      this.labelSelectedFwMsg.TabIndex = 1;
      this.labelSelectedFwMsg.Text = "SELECTED_FW_MSG";
      this.labelSelectedFwStep.AllowDrop = true;
      this.labelSelectedFwStep.AutoEllipsis = true;
      this.labelSelectedFwStep.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelSelectedFwStep.Location = new Point(34, 224);
      this.labelSelectedFwStep.Name = "labelSelectedFwStep";
      this.labelSelectedFwStep.Size = new Size(582, 163);
      this.labelSelectedFwStep.TabIndex = 6;
      this.labelSelectedFwStep.Text = "DYNAMIC";
      this.labelSelectedFwStep.Visible = false;
      this.textBoxSelectedFw.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxSelectedFw.Location = new Point(35, 161);
      this.textBoxSelectedFw.Margin = new Padding(3, 4, 3, 4);
      this.textBoxSelectedFw.Name = "textBoxSelectedFw";
      this.textBoxSelectedFw.Size = new Size(541, 23);
      this.textBoxSelectedFw.TabIndex = 2;
      this.textBoxSelectedFw.TextChanged += new EventHandler(this.textBoxSelectedFw_TextChanged);
      this.btnSelectedFw.Location = new Point(586, 161);
      this.btnSelectedFw.Margin = new Padding(3, 4, 3, 4);
      this.btnSelectedFw.Name = "btnSelectedFw";
      this.btnSelectedFw.Size = new Size(33, 22);
      this.btnSelectedFw.TabIndex = 3;
      this.btnSelectedFw.Text = "...";
      this.btnSelectedFw.UseVisualStyleBackColor = true;
      this.tabPageOnlineFw.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageOnlineFw.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwStep);
      this.tabPageOnlineFw.Controls.Add((Control) this.btnOnlineFw);
      this.tabPageOnlineFw.Controls.Add((Control) this.loadingCircleOnlineFwStatus);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwModel);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwModelTag);
      this.tabPageOnlineFw.Controls.Add((Control) this.comboBoxOnlineFwNewVersion);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwCurrentVersion);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwNewVersionTag);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwOption);
      this.tabPageOnlineFw.Controls.Add((Control) this.comboBoxOnlineFwOption);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwStatus);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwTitle);
      this.tabPageOnlineFw.Controls.Add((Control) this.labelOnlineFwCurrentVersionTag);
      this.tabPageOnlineFw.Location = new Point(4, 25);
      this.tabPageOnlineFw.Margin = new Padding(3, 4, 3, 4);
      this.tabPageOnlineFw.Name = "tabPageOnlineFw";
      this.tabPageOnlineFw.Size = new Size(656, 492);
      this.tabPageOnlineFw.TabIndex = 3;
      this.tabPageOnlineFw.Text = "tabPageOnlineFw";
      this.tabPageOnlineFw.UseVisualStyleBackColor = true;
      this.labelOnlineFwStep.AllowDrop = true;
      this.labelOnlineFwStep.AutoEllipsis = true;
      this.labelOnlineFwStep.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOnlineFwStep.Location = new Point(34, 258);
      this.labelOnlineFwStep.Name = "labelOnlineFwStep";
      this.labelOnlineFwStep.Size = new Size(582, 142);
      this.labelOnlineFwStep.TabIndex = 18;
      this.labelOnlineFwStep.Text = "DYNAMIC";
      this.labelOnlineFwStep.Visible = false;
      this.btnOnlineFw.Location = new Point(554, 193);
      this.btnOnlineFw.Margin = new Padding(3, 4, 3, 4);
      this.btnOnlineFw.Name = "btnOnlineFw";
      this.btnOnlineFw.Size = new Size(33, 22);
      this.btnOnlineFw.TabIndex = 17;
      this.btnOnlineFw.Text = "...";
      this.btnOnlineFw.UseVisualStyleBackColor = true;
      this.loadingCircleOnlineFwStatus.Active = false;
      this.loadingCircleOnlineFwStatus.BackColor = Color.Transparent;
      this.loadingCircleOnlineFwStatus.Color = Color.DarkGray;
      this.loadingCircleOnlineFwStatus.ForeColor = SystemColors.HotTrack;
      this.loadingCircleOnlineFwStatus.InnerCircleRadius = 5;
      this.loadingCircleOnlineFwStatus.Location = new Point(207, 403);
      this.loadingCircleOnlineFwStatus.Name = "loadingCircleOnlineFwStatus";
      this.loadingCircleOnlineFwStatus.NumberSpoke = 12;
      this.loadingCircleOnlineFwStatus.OuterCircleRadius = 11;
      this.loadingCircleOnlineFwStatus.RotationSpeed = 80;
      this.loadingCircleOnlineFwStatus.Size = new Size(20, 20);
      this.loadingCircleOnlineFwStatus.SpokeThickness = 2;
      this.loadingCircleOnlineFwStatus.StylePreset = LoadingCircle.StylePresets.MacOSX;
      this.loadingCircleOnlineFwStatus.TabIndex = 16;
      this.loadingCircleOnlineFwStatus.Text = "loadingCircle";
      this.labelOnlineFwModel.AutoSize = true;
      this.labelOnlineFwModel.Location = new Point(296, 139);
      this.labelOnlineFwModel.Name = "labelOnlineFwModel";
      this.labelOnlineFwModel.Size = new Size(193, 16);
      this.labelOnlineFwModel.TabIndex = 9;
      this.labelOnlineFwModel.Text = "ONLINE_STATUS_UNKNOWN";
      this.labelOnlineFwModelTag.AutoSize = true;
      this.labelOnlineFwModelTag.Location = new Point(34, 139);
      this.labelOnlineFwModelTag.Name = "labelOnlineFwModelTag";
      this.labelOnlineFwModelTag.Size = new Size(173, 16);
      this.labelOnlineFwModelTag.TabIndex = 8;
      this.labelOnlineFwModelTag.Text = "ONLINE_FW_MODEL_TAG";
      this.comboBoxOnlineFwNewVersion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxOnlineFwNewVersion.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxOnlineFwNewVersion.FormattingEnabled = true;
      this.comboBoxOnlineFwNewVersion.Location = new Point(296, 194);
      this.comboBoxOnlineFwNewVersion.Name = "comboBoxOnlineFwNewVersion";
      this.comboBoxOnlineFwNewVersion.Size = new Size(252, 22);
      this.comboBoxOnlineFwNewVersion.TabIndex = 4;
      this.labelOnlineFwCurrentVersion.AutoSize = true;
      this.labelOnlineFwCurrentVersion.Location = new Point(296, 167);
      this.labelOnlineFwCurrentVersion.Name = "labelOnlineFwCurrentVersion";
      this.labelOnlineFwCurrentVersion.Size = new Size(193, 16);
      this.labelOnlineFwCurrentVersion.TabIndex = 2;
      this.labelOnlineFwCurrentVersion.Text = "ONLINE_STATUS_UNKNOWN";
      this.labelOnlineFwNewVersionTag.AutoSize = true;
      this.labelOnlineFwNewVersionTag.Location = new Point(34, 197);
      this.labelOnlineFwNewVersionTag.Name = "labelOnlineFwNewVersionTag";
      this.labelOnlineFwNewVersionTag.Size = new Size(224, 16);
      this.labelOnlineFwNewVersionTag.TabIndex = 3;
      this.labelOnlineFwNewVersionTag.Text = "ONLINE_FW_NEW_VERSION_TAG";
      this.labelOnlineFwOption.AutoSize = true;
      this.labelOnlineFwOption.Font = new Font("Verdana", 9.75f);
      this.labelOnlineFwOption.Location = new Point(34, 227);
      this.labelOnlineFwOption.Name = "labelOnlineFwOption";
      this.labelOnlineFwOption.Size = new Size(163, 16);
      this.labelOnlineFwOption.TabIndex = 5;
      this.labelOnlineFwOption.Text = "SELECTED_FW_OPTION";
      this.labelOnlineFwOption.Visible = false;
      this.comboBoxOnlineFwOption.DrawMode = DrawMode.OwnerDrawFixed;
      this.comboBoxOnlineFwOption.DropDownHeight = 1;
      this.comboBoxOnlineFwOption.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxOnlineFwOption.FormattingEnabled = true;
      this.comboBoxOnlineFwOption.IntegralHeight = false;
      this.comboBoxOnlineFwOption.IsMutilpeSelect = true;
      this.comboBoxOnlineFwOption.Location = new Point(296, 224);
      this.comboBoxOnlineFwOption.Name = "comboBoxOnlineFwOption";
      this.comboBoxOnlineFwOption.Size = new Size(252, 23);
      this.comboBoxOnlineFwOption.TabIndex = 6;
      this.comboBoxOnlineFwOption.Visible = false;
      this.labelOnlineFwStatus.AutoSize = true;
      this.labelOnlineFwStatus.BackColor = Color.Transparent;
      this.labelOnlineFwStatus.ForeColor = SystemColors.ControlText;
      this.labelOnlineFwStatus.Location = new Point(25, 405);
      this.labelOnlineFwStatus.Name = "labelOnlineFwStatus";
      this.labelOnlineFwStatus.Size = new Size(176, 16);
      this.labelOnlineFwStatus.TabIndex = 7;
      this.labelOnlineFwStatus.Text = "XXX_STATUS_NO_PHONE";
      this.labelOnlineFwTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOnlineFwTitle.ForeColor = Color.MidnightBlue;
      this.labelOnlineFwTitle.Location = new Point(19, 17);
      this.labelOnlineFwTitle.Name = "labelOnlineFwTitle";
      this.labelOnlineFwTitle.Size = new Size(403, 73);
      this.labelOnlineFwTitle.TabIndex = 0;
      this.labelOnlineFwTitle.Text = "TITLE";
      this.labelOnlineFwCurrentVersionTag.AutoSize = true;
      this.labelOnlineFwCurrentVersionTag.Location = new Point(34, 167);
      this.labelOnlineFwCurrentVersionTag.Name = "labelOnlineFwCurrentVersionTag";
      this.labelOnlineFwCurrentVersionTag.Size = new Size(254, 16);
      this.labelOnlineFwCurrentVersionTag.TabIndex = 1;
      this.labelOnlineFwCurrentVersionTag.Text = "ONLINE_FW_CURRENT_VERSION_TAG";
      this.tabPageProgress.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageProgress.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageProgress.Controls.Add((Control) this.labelProgressTitle);
      this.tabPageProgress.Controls.Add((Control) this.labelProgressWarning);
      this.tabPageProgress.Controls.Add((Control) this.labelProgreeMsg);
      this.tabPageProgress.Controls.Add((Control) this.progressBarUpdate);
      this.tabPageProgress.Location = new Point(4, 25);
      this.tabPageProgress.Margin = new Padding(3, 4, 3, 4);
      this.tabPageProgress.Name = "tabPageProgress";
      this.tabPageProgress.Size = new Size(656, 492);
      this.tabPageProgress.TabIndex = 4;
      this.tabPageProgress.Text = "tabPageProgress";
      this.tabPageProgress.UseVisualStyleBackColor = true;
      this.labelProgressTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelProgressTitle.ForeColor = Color.MidnightBlue;
      this.labelProgressTitle.Location = new Point(19, 17);
      this.labelProgressTitle.Name = "labelProgressTitle";
      this.labelProgressTitle.Size = new Size(403, 73);
      this.labelProgressTitle.TabIndex = 0;
      this.labelProgressTitle.Text = "TITLE";
      this.labelProgressWarning.AutoSize = true;
      this.labelProgressWarning.ForeColor = Color.Red;
      this.labelProgressWarning.Location = new Point(49, 394);
      this.labelProgressWarning.Name = "labelProgressWarning";
      this.labelProgressWarning.Size = new Size(147, 16);
      this.labelProgressWarning.TabIndex = 3;
      this.labelProgressWarning.Text = "PROGRESS_WARNING";
      this.labelProgreeMsg.AutoSize = true;
      this.labelProgreeMsg.Location = new Point(36, 144);
      this.labelProgreeMsg.Name = "labelProgreeMsg";
      this.labelProgreeMsg.Size = new Size(114, 16);
      this.labelProgreeMsg.TabIndex = 1;
      this.labelProgreeMsg.Text = "PROGRESS_MSG";
      this.progressBarUpdate.ColorBackGround = Color.White;
      this.progressBarUpdate.ColorBarBorder = Color.FromArgb(170, 240, 170);
      this.progressBarUpdate.ColorBarCenter = Color.FromArgb(10, 150, 10);
      this.progressBarUpdate.ColorText = Color.Black;
      this.progressBarUpdate.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.progressBarUpdate.Location = new Point(39, 164);
      this.progressBarUpdate.Margin = new Padding(3, 4, 3, 4);
      this.progressBarUpdate.Name = "progressBarUpdate";
      this.progressBarUpdate.Position = 0;
      this.progressBarUpdate.PositionMax = 100;
      this.progressBarUpdate.PositionMin = 0;
      this.progressBarUpdate.Size = new Size(582, 30);
      this.progressBarUpdate.TabIndex = 2;
      this.tabPageMultiProgress.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageMultiProgress.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageMultiProgress.Controls.Add((Control) this.labelMultiProgressMsgPanel);
      this.tabPageMultiProgress.Controls.Add((Control) this.flowLayoutPanelMultiProgress);
      this.tabPageMultiProgress.Controls.Add((Control) this.labelMultiProgressStatus);
      this.tabPageMultiProgress.Controls.Add((Control) this.labelMultiProgressTitle);
      this.tabPageMultiProgress.Location = new Point(4, 25);
      this.tabPageMultiProgress.Margin = new Padding(3, 4, 3, 4);
      this.tabPageMultiProgress.Name = "tabPageMultiProgress";
      this.tabPageMultiProgress.Size = new Size(656, 492);
      this.tabPageMultiProgress.TabIndex = 4;
      this.tabPageMultiProgress.Text = "tabPageMultiProgress";
      this.tabPageMultiProgress.UseVisualStyleBackColor = true;
      this.labelMultiProgressMsgPanel.AutoSize = true;
      this.labelMultiProgressMsgPanel.Location = new Point(34, 126);
      this.labelMultiProgressMsgPanel.Name = "labelMultiProgressMsgPanel";
      this.labelMultiProgressMsgPanel.Size = new Size(163, 16);
      this.labelMultiProgressMsgPanel.TabIndex = 1;
      this.labelMultiProgressMsgPanel.Text = "PROGRESS_MSG_PANEL";
      this.flowLayoutPanelMultiProgress.AutoScroll = true;
      this.flowLayoutPanelMultiProgress.ForeColor = SystemColors.ControlText;
      this.flowLayoutPanelMultiProgress.Location = new Point(35, 148);
      this.flowLayoutPanelMultiProgress.Name = "flowLayoutPanelMultiProgress";
      this.flowLayoutPanelMultiProgress.Size = new Size(579, 244);
      this.flowLayoutPanelMultiProgress.TabIndex = 2;
      this.labelMultiProgressStatus.AutoSize = true;
      this.labelMultiProgressStatus.Location = new Point(25, 405);
      this.labelMultiProgressStatus.Name = "labelMultiProgressStatus";
      this.labelMultiProgressStatus.Size = new Size(176, 16);
      this.labelMultiProgressStatus.TabIndex = 3;
      this.labelMultiProgressStatus.Text = "XXX_STATUS_NO_PHONE";
      this.labelMultiProgressTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelMultiProgressTitle.ForeColor = Color.MidnightBlue;
      this.labelMultiProgressTitle.Location = new Point(19, 17);
      this.labelMultiProgressTitle.Name = "labelMultiProgressTitle";
      this.labelMultiProgressTitle.Size = new Size(403, 73);
      this.labelMultiProgressTitle.TabIndex = 0;
      this.labelMultiProgressTitle.Text = "TITLE";
      this.tabPageFinish.BackgroundImage = (Image) Resources.BackMain;
      this.tabPageFinish.BackgroundImageLayout = ImageLayout.Zoom;
      this.tabPageFinish.Controls.Add((Control) this.labelFinishErrorMsg);
      this.tabPageFinish.Controls.Add((Control) this.labelFinishTitle);
      this.tabPageFinish.Controls.Add((Control) this.labelFinishErrorCode);
      this.tabPageFinish.Controls.Add((Control) this.labelFinishTag);
      this.tabPageFinish.Location = new Point(4, 25);
      this.tabPageFinish.Margin = new Padding(3, 4, 3, 4);
      this.tabPageFinish.Name = "tabPageFinish";
      this.tabPageFinish.Size = new Size(656, 492);
      this.tabPageFinish.TabIndex = 5;
      this.tabPageFinish.Text = "tabPageFinish";
      this.tabPageFinish.UseVisualStyleBackColor = true;
      this.labelFinishErrorMsg.AutoEllipsis = true;
      this.labelFinishErrorMsg.ForeColor = Color.Red;
      this.labelFinishErrorMsg.Location = new Point(53, 187);
      this.labelFinishErrorMsg.Name = "labelFinishErrorMsg";
      this.labelFinishErrorMsg.Size = new Size(543, 225);
      this.labelFinishErrorMsg.TabIndex = 3;
      this.labelFinishErrorMsg.Text = "FINISH_ERROR_MSG";
      this.labelFinishErrorMsg.Visible = false;
      this.labelFinishTitle.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelFinishTitle.ForeColor = Color.MidnightBlue;
      this.labelFinishTitle.Location = new Point(19, 17);
      this.labelFinishTitle.Name = "labelFinishTitle";
      this.labelFinishTitle.Size = new Size(403, 73);
      this.labelFinishTitle.TabIndex = 0;
      this.labelFinishTitle.Text = "TITLE";
      this.labelFinishErrorCode.AutoSize = true;
      this.labelFinishErrorCode.ForeColor = Color.Red;
      this.labelFinishErrorCode.Location = new Point(53, 160);
      this.labelFinishErrorCode.Name = "labelFinishErrorCode";
      this.labelFinishErrorCode.Size = new Size(147, 16);
      this.labelFinishErrorCode.TabIndex = 2;
      this.labelFinishErrorCode.Text = "FINISH_ERROR_CODE";
      this.labelFinishErrorCode.Visible = false;
      this.labelFinishTag.AutoSize = true;
      this.labelFinishTag.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelFinishTag.Location = new Point(47, 128);
      this.labelFinishTag.Name = "labelFinishTag";
      this.labelFinishTag.Size = new Size(96, 16);
      this.labelFinishTag.TabIndex = 1;
      this.labelFinishTag.Text = "FINISH_TAG";
      this.timerFetchMsg.Tick += new EventHandler(this.timerFetchMsg_Tick);
      this.timerCountRunTime.Interval = 1000;
      this.timerCountRunTime.Tick += new EventHandler(this.timerCountRunTime_Tick);
      this.timerAutoRun.Interval = 5000;
      this.timerAutoRun.Tick += new EventHandler(this.timerAutoRun_Tick);
      this.btnNext.AccessibleDescription = "";
      this.btnNext.BackgroundImage = (Image) Resources.Button;
      this.btnNext.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnNext.ForeColor = Color.MidnightBlue;
      this.btnNext.Location = new Point(410, 447);
      this.btnNext.Margin = new Padding(3, 4, 3, 4);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new Size(108, 28);
      this.btnNext.TabIndex = 0;
      this.btnNext.Text = "BTN_NEXT";
      this.btnNext.UseVisualStyleBackColor = true;
      this.btnNext.Click += new EventHandler(this.btnNext_Click);
      this.btnCancel.BackgroundImage = (Image) Resources.Button;
      this.btnCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnCancel.ForeColor = Color.MidnightBlue;
      this.btnCancel.Location = new Point(524, 447);
      this.btnCancel.Margin = new Padding(3, 4, 3, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(108, 28);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "BTN_CANCEL";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnBack.BackgroundImage = (Image) Resources.Button;
      this.btnBack.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnBack.ForeColor = Color.MidnightBlue;
      this.btnBack.Location = new Point(296, 447);
      this.btnBack.Margin = new Padding(3, 4, 3, 4);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new Size(108, 28);
      this.btnBack.TabIndex = 2;
      this.btnBack.Text = "BTN_BACK";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new EventHandler(this.btnBack_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(656, 492);
      this.Controls.Add((Control) this.btnNext);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnBack);
      this.Controls.Add((Control) this.tabPageCtrl);
      this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (Form1);
      this.Text = "TITLE";
      this.Load += new EventHandler(this.Form1_Load);
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.tabPageCtrl.ResumeLayout(false);
      this.tabPageWelcome.ResumeLayout(false);
      this.tabPageWelcome.PerformLayout();
      this.tabPageBundledFw.ResumeLayout(false);
      this.tabPageBundledFw.PerformLayout();
      this.tabPageSelectedFw.ResumeLayout(false);
      this.tabPageSelectedFw.PerformLayout();
      this.tabPageOnlineFw.ResumeLayout(false);
      this.tabPageOnlineFw.PerformLayout();
      this.tabPageProgress.ResumeLayout(false);
      this.tabPageProgress.PerformLayout();
      this.tabPageMultiProgress.ResumeLayout(false);
      this.tabPageMultiProgress.PerformLayout();
      this.tabPageFinish.ResumeLayout(false);
      this.tabPageFinish.PerformLayout();
      this.ResumeLayout(false);
    }

    private void InitFormCustom()
    {
      this.lableOption = this.labelSelectedFwOption;
      this.comboBoxOption = this.comboBoxSelectedFwOption;
      this.labelSelectedFwStep.Visible = false;
      this.labelBundledFwStep.Text = Locale.Instance.LoadCombinedText("WELCOME_MSG;" + this.GetUpdateStepLabels(this.toolParam.Option.DoEmergecyDownload));
      this.comboBoxSelectedFwOption.CheckedListBoxItem.SelectedIndexChanged += new EventHandler(this.comboBoxOption_SelectionChangeCommitted);
      this.btnSelectedFw.Click += new EventHandler(this.btnSelectedFw_Click);
      this.StartDeployment();
    }

    private void btnSelectedFw_Click(object sender, EventArgs e)
    {
      try
      {
        this.JudgeProduct(this.textBoxSelectedFw.Text, this.textBoxSelectedFw);
        this.DisplayOptions();
        this.DisplayUpdateSteps();
        this.DisplayButtons();
        this.DisplayStatus("NO_SW_VER_INFO");
        if (!this.toolParam.AutoTest)
          return;
        this.autoRun = true;
        this.autoRunTime = DateTime.Now;
        this.timerAutoRun.Enabled = true;
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void comboBoxOption_SelectionChangeCommitted(object sender, EventArgs e)
    {
      this.DisplayButtons();
      this.DisplayStatus("NO_SW_VER_INFO");
      this.DisplayUpdateSteps();
    }

    private void comboBoxOnlineFwOption_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void JudgePage()
    {
      if (this.toolParam.BundledImageExist)
      {
        this.fwPage = (FwPage) new FwPageBundled(this.tabPageBundledFw, this.tabPageBundledFw, this.tabPageProgress, this.toolParam.BundledImage);
        this.pageFlow = new PageFlow(new TabPage[3]
        {
          this.tabPageBundledFw,
          this.tabPageProgress,
          this.tabPageFinish
        });
      }
      else
      {
        this.fwPage = (FwPage) new FwPageSelected(this.tabPageSelectedFw, this.tabPageSelectedFw, this.tabPageProgress);
        this.pageFlow = new PageFlow(new TabPage[4]
        {
          this.tabPageWelcome,
          this.tabPageSelectedFw,
          this.tabPageProgress,
          this.tabPageFinish
        });
      }
    }

    private void DisplayButtons()
    {
      this.btnBack.Visible = !this.toolParam.BundledImageExist;
      this.btnBack.Enabled = !this.toolParam.AutoTest && this.tabPageCtrl.SelectedTab != this.pageFlow.FirstPage && this.tabPageCtrl.SelectedTab == this.fwPage.ImagePage;
      this.btnNext.Text = this.tabPageCtrl.SelectedTab == this.pageFlow.FinalPage ? Locale.Instance.LoadText("BTN_CONTINUE") : Locale.Instance.LoadText("BTN_NEXT");
      bool flag = this.tabPageCtrl.SelectedTab != this.fwPage.ProgressPage;
      if (flag && this.tabPageCtrl.SelectedTab == this.fwPage.MainPage)
        flag = this.product != null && (this.DeviceConnected && this.IsContainWorkInterface && this.IsContainDownloadOption || this.IsNativeUpdate);
      this.btnNext.Enabled = flag;
      this.btnCancel.Text = this.tabPageCtrl.SelectedTab == this.pageFlow.FinalPage ? Locale.Instance.LoadText("BTN_FINISH") : Locale.Instance.LoadText("BTN_CANCEL");
      this.btnCancel.Enabled = this.tabPageCtrl.SelectedTab != this.tabPageProgress;
      this.btnPhoneKeyInfo.Visible = OstOption.HasPhoneInfoOption();
      int deviceMode;
      if (this.textBoxSelectedFw.Text.Length > 0 && File.Exists(this.textBoxSelectedFw.Text) && (this.product != null && this.DeviceConnected) && (MyDevice.GetDeviceMode(this.progressItem.DeviceId, out deviceMode) && MyDevice.DeviceModePhoneDataEditSupported((MyDevice.DeviceMode) deviceMode)))
        this.btnPhoneKeyInfo.Enabled = true;
      else
        this.btnPhoneKeyInfo.Enabled = false;
    }

    private void DisplayStatus(string swVersion)
    {
      if (this.tabPageCtrl.SelectedTab != this.fwPage.MainPage)
        return;
      string localeId = this.product == null || !this.IsNativeUpdate ? (this.product == null || !this.DeviceConnected || (!this.IsContainWorkInterface || !this.IsContainDownloadOption) ? (!this.DeviceConnected || !this.IsContainWorkInterface ? "XXX_STATUS_NO_PHONE" : "XXX_STATUS_NO_IMAGE") : "XXX_STATUS_NEXT") : "XXX_STATUS_NEXT";
      this.labelBundledFwStatus.Text = Locale.Instance.LoadText(localeId);
      this.labelSelectedFwStatus.Text = Locale.Instance.LoadText(localeId);
      if (swVersion.Equals("NO_SW_VER_INFO"))
        return;
      this.label_dev_sw_ver.Text = swVersion;
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (keyData == (Keys.B | Keys.Control) && !this.toolParam.Option.Backup)
      {
        this.toolParam.EnableBackupOption();
        this.DisplayOptions();
        return true;
      }
      if (keyData != (Keys.F | Keys.Control) || this.toolParam.Option.NativeFormatAndUpdate)
        return false;
      this.toolParam.EnableNativeFormatAndUpdateOption();
      this.DisplayOptions();
      return true;
    }

    private void DisplayUpdateSteps()
    {
      if (this.product != null)
      {
        this.labelSelectedFwStep.Text = Locale.Instance.LoadCombinedText(this.GetUpdateStepLabels(this.IsNativeUpdate));
        this.labelSelectedFwStep.Visible = true;
      }
      else
        this.labelSelectedFwStep.Visible = false;
    }

    private string GetUpdateStepLabels(bool nativeUpdate) => STSLicense.isEnableRoot() ? "SELECTED_FW_STEP_L1" + string.Format(";SELECTED_FW_STEP_L2_{0}", nativeUpdate ? (object) "NATIVE" : (object) "NORMAL") + string.Format(";SELECTED_FW_STEP_L3_{0}", nativeUpdate ? (object) "NATIVE" : (object) "NORMAL") + string.Format(";SELECTED_FW_STEP_L4_{0}", nativeUpdate ? (object) "NATIVE" : (object) "NORMAL") : "INSUFFICIENT_PERMISSIONS";

    public bool IsContainDownloadOption => this.comboBoxSelectedFwOption.IsContainDownloadOption || this.product != null && this.product.JudgeImageType(this.textBoxSelectedFw.Text) == ImageType.NV_XML_TYPE || this.toolParam.BundledImageExist;

    public bool IsNativeUpdate => this.comboBoxSelectedFwOption.HasOption(ProductOptions.NATIVE_UPDATE_PROCESS) || this.comboBoxSelectedFwOption.HasOption(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS) || (this.comboBoxSelectedFwOption.HasOption(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS) || this.toolParam.Option.DoEmergecyDownload);

    private bool HasInterface(string interfaceName) => this.DeviceInterfaceItems.Contains(interfaceName);

    private bool IsDoBackupRestore => this.product != null && this.product.JudgeImageType(this.textBoxSelectedFw.Text) == ImageType.NV_XML_TYPE || this.comboBoxSelectedFwOption.HasOption(ProductOptions.BACKUP_SETTINGS);

    private bool IsContainWorkInterface => !this.IsDoBackupRestore || this.HasInterface("Cdrom") || this.HasInterface("Ports");

    public Form1()
    {
      try
      {
        this.toolParam = ToolParam.Instance;
        this.InitializeComponent();
        this.ReloadDefaultTexts();
        this.ReloadBackground();
        this.ReCalculateLayout();
        this.SetUserInteractions();
        this.JudgePage();
        this.runTime = 0;
        this.title = this.Text;
        this.autoRun = false;
        this.autoRunTime = DateTime.Now;
        this.InitFormProgress();
        this.InitFormCustom();
        this.detector = new MyDevice(new MyDevice.OnDeviceChangedDelegate(this.OnDeviceChanged), (Control) this);
        this.detector.StartDetectDevice();
        DevMsg.Instance.RegisterHidNotification(this.Handle);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.DisableOptions();
      if (this.toolParam.BundledImageExist)
        this.JudgeProduct(this.toolParam.BundledImage, (TextBox) null);
      this.tabPageCtrl.SelectTab(this.pageFlow.FirstPage);
      this.SetBackColorOfAllLabels(Color.Transparent);
      HookKeyboard.EnableHookKeysToChangeTabPages(new Control[1]
      {
        (Control) this.textBoxSelectedFw
      });
      this.detector.DoDetectDevice(true);
      CLogs.I("Main form is loaded.");
    }

    private void ExitApplication()
    {
      Common.KillProcess("adb");
      this.Close();
    }

    private void ReloadDefaultTexts()
    {
      if (this.toolParam.BundledImageExist)
        this.Text = string.Format("{0} V{1}", (object) Locale.Instance.LoadCombinedText(this.Text), (object) this.toolParam.ToolVersion);
      else
        this.Text = string.Format("{0} {1} V{2}", (object) Locale.Instance.LoadCombinedText(this.Text), (object) this.toolParam.ToolUserTitle, (object) this.toolParam.ToolVersion);
      this.btnBack.Text = Locale.Instance.LoadCombinedText(this.btnBack.Text);
      this.btnNext.Text = Locale.Instance.LoadCombinedText(this.btnNext.Text);
      this.btnCancel.Text = Locale.Instance.LoadCombinedText(this.btnCancel.Text);
      this.btnPhoneKeyInfo.Text = Locale.Instance.LoadCombinedText(this.btnPhoneKeyInfo.Text);
      foreach (Control tabPage in this.tabPageCtrl.TabPages)
      {
        foreach (Control control in (ArrangedElementCollection) tabPage.Controls)
        {
          if (control is Label || control is Button)
            control.Text = Locale.Instance.LoadCombinedText(control.Text);
        }
      }
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      try
      {
        this.DisableButtons();
        this.tabPageCtrl.SelectTab(this.pageFlow.PrevPageOf(this.tabPageCtrl.SelectedTab));
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      try
      {
        this.DisableButtons();
        if (this.tabPageCtrl.SelectedTab == this.fwPage.ImagePage)
          this.StartMainTask();
        else if (this.tabPageCtrl.SelectedTab == this.pageFlow.FinalPage)
        {
          this.tabPageCtrl.SelectTab(this.fwPage.MainPage);
          this.DoDetectDevice(true);
        }
        else
          this.tabPageCtrl.SelectTab(this.pageFlow.NextPageOf(this.tabPageCtrl.SelectedTab));
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      try
      {
        this.ExitApplication();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void DisableButtons()
    {
      this.btnBack.Enabled = false;
      this.btnNext.Enabled = false;
      this.btnCancel.Enabled = false;
    }

    private void tabPageCtrl_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.tabPageCtrl.SelectedTab == this.fwPage.ImagePage)
          this.Text = this.title;
        this.DisplayButtons();
        this.DisplayStatus("NO_SW_VER_INFO");
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        this.detector.StopDetectDevice();
        this.timerFetchMsg.Enabled = false;
        this.timerCountRunTime.Enabled = false;
        this.timerAutoRun.Enabled = false;
        HookKeyboard.DisableHookKeys();
        if (File.Exists(Path.Combine(this.toolParam.ToolFolder, "UninstallSUT.bat")))
          new Process()
          {
            StartInfo = {
              FileName = Path.Combine(this.toolParam.ToolFolder, "UninstallSUT.bat"),
              WindowStyle = ProcessWindowStyle.Hidden
            }
          }.Start();
        DevMsg.Instance.UnRegisterHidNotification(this.Handle);
        Common.KillProcess("adb");
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void SetErrorMessage(long code, string message, string localeMessage)
    {
      this.labelFinishTag.Text = Locale.Instance.LoadText("FINISH_TAG_FAIL");
      this.labelFinishErrorCode.Visible = string.IsNullOrEmpty(localeMessage) && !message.Contains(ErrorCode.StringOf(code));
      this.labelFinishErrorCode.Text = string.Format("{0} {1}", (object) Locale.Instance.LoadText("FINISH_ERROR_CODE"), (object) ErrorCode.StringOf(code));
      string str = string.IsNullOrEmpty(localeMessage) ? message : localeMessage;
      this.labelFinishErrorMsg.Visible = !string.IsNullOrEmpty(str);
      this.labelFinishErrorMsg.ForeColor = Color.Red;
      this.labelFinishErrorMsg.Text = !string.IsNullOrEmpty(str) ? string.Format("{0} {1}", (object) Locale.Instance.LoadText("FINISH_ERROR_MSG"), (object) str) : "";
    }

    private void SetSuccessMessage(string message)
    {
      this.labelFinishTag.Text = Locale.Instance.LoadText("FINISH_TAG_SUCCESS");
      this.labelFinishErrorCode.Visible = false;
      this.labelFinishErrorMsg.Visible = ToolParam.ToolUser == ToolParam.User.RD && !string.IsNullOrEmpty(message);
      this.labelFinishErrorMsg.ForeColor = Color.Black;
      this.labelFinishErrorMsg.Text = !string.IsNullOrEmpty(message) ? string.Format("{0} {1}", (object) Locale.Instance.LoadText("FINISH_SUCCESS_MSG"), (object) message) : "";
    }

    private void ShowErrorMessage(long result, string message)
    {
      if (result == 0L)
      {
        this.SetSuccessMessage(message);
        this.tabPageCtrl.SelectTab(this.tabPageFinish);
      }
      else
      {
        this.SetErrorMessage(result, message, ErrorCode.LocaleStringOf(result));
        this.tabPageCtrl.SelectTab(this.tabPageFinish);
      }
    }

    private void DisableOptions()
    {
      this.lableOption.Visible = false;
      this.comboBoxOption.Visible = false;
    }

    private void DisplayOptions()
    {
      List<string> optionList = this.GetOptionList();
      if (!this.toolParam.OptionVisible)
      {
        this.comboBoxOption.SetCheckedListItems(optionList);
        this.comboBoxOption.EnableDefaultItem();
        this.DisableOptions();
      }
      else if (optionList.Count > 0)
      {
        this.comboBoxOption.SetCheckedListItems(optionList);
        this.comboBoxOption.EnableDefaultItem();
        this.lableOption.Visible = true;
        this.comboBoxOption.Visible = true;
      }
      else
      {
        this.comboBoxOption.ClearCheckedListItems();
        this.lableOption.Visible = false;
        this.comboBoxOption.Visible = false;
      }
    }

    private List<string> GetOptionList()
    {
      List<string> stringList = new List<string>();
      if (this.product.ImgSecurityVersion >= 8U && !STSLicense.isEnableRoot() || this.product == null)
        return stringList;
      string text1 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_0");
      if (this.product.HasUserOption(this.GetOptionValue(text1)) && OstOption.HasOption("NormalDownload"))
        stringList.Add(text1);
      string text2 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_1");
      if (this.product.HasUserOption(this.GetOptionValue(text2)) && OstOption.HasOption("EmergencyDownload"))
        stringList.Add(text2);
      string text3 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_2");
      if (this.product.HasUserOption(this.GetOptionValue(text3)) && OstOption.HasOption("ClearUserData"))
        stringList.Add(text3);
      string text4 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_3");
      if (this.product.HasUserOption(this.GetOptionValue(text4)) && OstOption.HasOption("EraseBoxData"))
        stringList.Add(text4);
      string text5 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_4");
      if (this.product.HasUserOption(this.GetOptionValue(text5)) && OstOption.HasOption("SwitchSkuid"))
        stringList.Add(text5);
      string text6 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_5");
      if (this.product.HasUserOption(this.GetOptionValue(text6)) && OstOption.HasOption("BackupNv"))
        stringList.Add(text6);
      string text7 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_6");
      if (this.product.HasUserOption(this.GetOptionValue(text7)))
        stringList.Add(text7);
      string text8 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_7");
      if (this.product.HasUserOption(this.GetOptionValue(text8)))
        stringList.Add(text8);
      string text9 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_8");
      if (this.product.HasUserOption(this.GetOptionValue(text9)) && OstOption.HasOption("EraseFrp") && this.product.HasSecurityVersion())
        stringList.Add(text9);
      string text10 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_9");
      if (this.product.HasUserOption(this.GetOptionValue(text10)) && OstOption.HasOption("UfsProvision"))
        stringList.Add(text10);
      string text11 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_10");
      if (this.product.HasUserOption(this.GetOptionValue(text11)) && OstOption.HasOption("UnlockScreenLock") && this.product.HasSecurityVersion())
        stringList.Add(text11);
      string text12 = Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_11");
      if (this.product.HasUserOption(this.GetOptionValue(text12)) && this.product.HasSecurityVersion())
        stringList.Add(text12);
      return stringList;
    }

    private ProductOptions GetOptionValue(string text)
    {
      if (text != null)
      {
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_0")))
          return ProductOptions.NONE;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_1")))
          return ProductOptions.NATIVE_UPDATE_PROCESS;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_2")))
          return ProductOptions.ERASE_USER_DATA;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_3")))
          return ProductOptions.ERASE_BOX_DATA;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_4")))
          return ProductOptions.SWITCH_CUSTOMER_SKUID;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_5")))
          return ProductOptions.BACKUP_SETTINGS;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_6")))
          return ProductOptions.NATIVE_ERASE_UPDATE_PROCESS;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_7")))
          return ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_8")))
          return ProductOptions.ERASE_FRP;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_9")))
          return ProductOptions.UFS_PROVISION;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_10")))
          return ProductOptions.UNLOCK_SCREEN_LOCK;
        if (text.Equals(Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_11")))
          return ProductOptions.COLLECT_APR_LOG;
      }
      return ProductOptions.UNKNOW_OPTION;
    }

    private string GetOptionText(ProductOptions option)
    {
      switch (option)
      {
        case ProductOptions.NATIVE_UPDATE_PROCESS:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_1");
        case ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_7");
        case ProductOptions.ERASE_USER_DATA:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_2");
        case ProductOptions.ERASE_BOX_DATA:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_3");
        case ProductOptions.SWITCH_CUSTOMER_SKUID:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_4");
        case ProductOptions.BACKUP_SETTINGS:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_5");
        case ProductOptions.NATIVE_ERASE_UPDATE_PROCESS:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_6");
        case ProductOptions.ERASE_FRP:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_8");
        case ProductOptions.UFS_PROVISION:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_9");
        case ProductOptions.UNLOCK_SCREEN_LOCK:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_10");
        case ProductOptions.COLLECT_APR_LOG:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_11");
        default:
          return Locale.Instance.LoadCombinedText("SELECTED_FW_OPTION_0");
      }
    }

    private void timerCountRunTime_Tick(object sender, EventArgs e)
    {
      try
      {
        if (!this.toolParam.UpdateCounter)
          return;
        this.Text = string.Format("{0} ... {1} {2}", (object) this.title, (object) ++this.runTime, (object) Locale.Instance.LoadText("PROGRESS_SECOND"));
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void timerAutoRun_Tick(object sender, EventArgs e)
    {
      TimeSpan timeSpan = DateTime.Now - this.autoRunTime;
      if (!this.autoRun || timeSpan.TotalMilliseconds <= (double) this.toolParam.AutoTestInterval || !this.btnNext.Enabled)
        return;
      this.autoRun = false;
      this.btnNext.PerformClick();
    }

    private void ReloadBackground()
    {
      foreach (Control tabPage in this.tabPageCtrl.TabPages)
        tabPage.BackgroundImage = (Image) Resources.BackMain;
    }

    private void ReCalculateLayout()
    {
      this.ReCalculateLayout(new Control[1]
      {
        (Control) this.labelSelectedFwOption
      }, new Control[1]
      {
        (Control) this.comboBoxSelectedFwOption
      });
      this.ReCalculateLayout(new Control[4]
      {
        (Control) this.labelOnlineFwModelTag,
        (Control) this.labelOnlineFwCurrentVersionTag,
        (Control) this.labelOnlineFwNewVersionTag,
        (Control) this.labelOnlineFwOption
      }, new Control[4]
      {
        (Control) this.labelOnlineFwModel,
        (Control) this.labelOnlineFwCurrentVersion,
        (Control) this.comboBoxOnlineFwNewVersion,
        (Control) this.comboBoxOnlineFwOption
      });
    }

    private void ReCalculateLayout(Control[] lefts, Control[] rights)
    {
      int num = 0;
      foreach (Control left in lefts)
        num = Math.Max(num, left.Right);
      foreach (Control right in rights)
        this.ReCalculateLayout(num, right);
    }

    private void ReCalculateLayout(int position, Control right)
    {
      int num = position - right.Left + right.Margin.Left;
      right.Left += num;
      if (!(right is ComboBox))
        return;
      right.Width -= num;
    }

    private void SetBackColorOfAllLabels(Color color)
    {
      foreach (Control tabPage in this.tabPageCtrl.TabPages)
      {
        foreach (Control control in (ArrangedElementCollection) tabPage.Controls)
        {
          if (control is Label label)
            label.BackColor = color;
        }
      }
    }

    private void SetUserInteractions()
    {
      
    }

    private void JudgeProduct(string imagePath, TextBox textBox)
    {
      long result = this.fwPage.SelectProduct(imagePath, ref this.product);
      if (result == 1223L)
        return;
      if (this.product != null)
      {
        if (textBox == null)
          return;
        textBox.Text = this.fwPage.SelectPath;
      }
      else
      {
        if (textBox != null)
          textBox.Text = string.Empty;
        StringBuilder message = new StringBuilder(1024);
        Form1.GetDetailMessage(string.Empty, message, message.Capacity);
        this.ShowErrorMessage(result, message.ToString());
      }
    }

    private void textBoxSelectedFw_TextChanged(object sender, EventArgs e)
    {
      if (OstOption.HasPhoneInfoOption() && this.textBoxSelectedFw.Text.Length > 0 && (File.Exists(this.textBoxSelectedFw.Text) && this.product != null) && this.DeviceConnected)
        this.btnPhoneKeyInfo.Enabled = true;
      else
        this.btnPhoneKeyInfo.Enabled = false;
    }

    private void ShowErrorMessage(string message)
    {
      CLogs.E(message);
      int num = (int) MessageBox.Show(message, "ERROR");
    }

    private void SwitchPhoneEditMode_OnTaskCompleted(
      long result,
      Dictionary<string, object> outParams)
    {
      try
      {
        if (result != 0L)
          this.ShowErrorMessage("Boot FTM mode fail!");
        if (result == 0L)
        {
          switch (new Form_PhoneKeyInfo(this.progressItem.SessionId, this.progressItem.DeviceId, this.toolParam.ToolUserTitle).ShowDialog())
          {
            case DialogResult.Cancel:
              CLogs.I("Close the dialog and the phone keeps FTM mode...");
              break;
            case DialogResult.Yes:
              CLogs.I("Choose continue and then switch to fastboot mode...");
              result = (long) Form1.SwitchDeviceMode(this.progressItem.SessionId, this.progressItem.DeviceId, 5);
              if (result != 0L)
              {
                this.ShowErrorMessage("Switch to download mode fail!");
                break;
              }
              break;
            case DialogResult.No:
              CLogs.I("Choose finish and then switch to OS mode...");
              result = (long) Form1.SwitchDeviceMode(this.progressItem.SessionId, this.progressItem.DeviceId, 1);
              if (result != 0L)
              {
                this.ShowErrorMessage("Switch to OS mode fail!");
                break;
              }
              break;
          }
        }
        this.labelSelectedFwStatus.Text = Locale.Instance.LoadText("XXX_STATUS_NEXT");
        this.labelSelectedFwStatus.Refresh();
        this.DisplayButtons();
        this.DoDetectDevice(true);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void btnPhoneKeyInfo_Click(object sender, EventArgs e)
    {
      this.labelSelectedFwStatus.Text = Locale.Instance.LoadText("XXX_STATUS_BOOTING_FTM");
      this.labelSelectedFwStatus.Refresh();
      int deviceMode = 0;
      if (MyDevice.GetDeviceMode(this.progressItem.DeviceId, out deviceMode))
      {
        CLogs.I("Current Device Mode: " + MyDevice.GetDeviceModeString(deviceMode));
        DispatchTask dispatchTask = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.SwitchPhoneEditMode_OnTaskCompleted));
        Sessions.Restart();
        this.product.InitProduct(this.fwPage.ImagePath);
        dispatchTask.StartTask_SwitchPhoneEditMode(this.progressItem.SessionId, this.progressItem.DeviceId);
        this.btnPhoneKeyInfo.Enabled = false;
        this.DisableButtons();
        this.DoDetectDevice(false);
      }
      else
        this.ShowErrorMessage("Detect device mode fail!");
    }

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
      UsbDevEventNotifyer.Instance.WndProc(ref m);
    }

    [DllImport("MobileFlashDll.dll")]
    private static extern bool GetDetailMessage(
      string sessionId,
      StringBuilder message,
      int messageSize);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackDoAuthentication(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackShowWarningDialog(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackShowEnterSpcDialog(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackShowReEnterSpcDialog(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackShowModelWarningDialog(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackShowModelSelectSKUIdDialog(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackDoReportServiceResult(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackQueryServerSimUnlockCode(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetCallBackDeleteServerSimUnlockCode(MulticastDelegate callback);

    [DllImport("MobileFlashDll.dll")]
    private static extern int SwitchDeviceMode(string sessionId, string deviceId, int deviceMode);

    public Form1 EnableDataCollection()
    {
      this.timerDataCollection = new Timer(this.components);
      this.timerDataCollection.Interval = 15000;
      this.timerDataCollection.Tick += new EventHandler(this.timerDataCollection_Tick);
      this.timerDataCollection.Enabled = true;
      return this;
    }

    private void timerSendLog_Tick(object sender, EventArgs e)
    {
      try
      {
        LogQueue instance = LogQueue.Instance;
        instance.RefershQueue();
        while (instance.Available)
        {
          CollectionFile availableFile = instance.GetAvailableFile();
          new OtaSendLogTaskEx(new OtaSendLogTaskEx.OnOtaSendLogTaskCompletedDelegate(this.OnSendLogCompleted)).StartTask(availableFile);
          CLogs.I(string.Format("Send Update Log {0}...", (object) availableFile));
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void OnSendLogCompleted(CollectionFile file)
    {
      LogQueue instance = LogQueue.Instance;
      if (file.Done)
      {
        CLogs.I(string.Format("Send Update Log {0} success.", (object) file));
        instance.Remove(file);
      }
      else
      {
        CLogs.I(string.Format("Send Update Log {0} fails.", (object) file));
        instance.Requeue(file);
      }
    }

    private bool IsNetworkDeployed
    {
      get
      {
        string company = Settings.Default.Company;
        string displayName = Settings.Default.DisplayName;
        string programx86Path = PathEx.GetProgramx86Path(string.IsNullOrEmpty(company) ? displayName : Path.Combine(company, displayName));
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToLower().Equals(programx86Path.ToLower());
      }
    }

    private void StartDeployment()
    {
      if (!this.IsNetworkDeployed)
        return;
      CLogs.I("This is a network depolyable program.");
      this.deploymentTask = new DeploymentTask(new DeploymentTask.OnTaskCompletedDelegate(this.OnDeploymentCompleted));
      this.timerDeployment = new Timer(this.components);
      this.timerDeployment.Interval = 900000;
      this.timerDeployment.Tick += new EventHandler(this.timerDeployment_Tick);
      this.timerDeployment.Enabled = true;
    }

    private void timerDeployment_Tick(object sender, EventArgs e)
    {
      try
      {
        if (this.deploymentTask.IsBusy)
          return;
        CLogs.I("Launch deployment process...");
        this.deploymentTask.StartTask();
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void OnDeploymentCompleted(long result)
    {
      if (result == 0L)
      {
        this.timerDeployment.Enabled = false;
        CLogs.I("Server deployment version was ready.");
      }
      else
        CLogs.E("Launch deployment process but fails, last error: " + ErrorCode.StringOf(result));
    }

    private void InitFormProgress() => this.progressItem = new ProgressItem(this.progressBarUpdate);

    private bool DeviceConnected => this.progressItem.Connected;

    private List<string> DeviceInterfaceItems => this.progressItem.DeviceInterface;

    private void OnDeviceChanged(string deviceId, bool connected, List<string> interfaceItems)
    {
      try
      {
        this.progressItem.SetDeviceStatus(deviceId, connected, interfaceItems);
        StringBuilder stringBuilder = new StringBuilder(128);
        string swVersion = "SW version of the device";
        int deviceMode = 0;
        if (MyDevice.GetDeviceMode(deviceId, out deviceMode))
        {
          CLogs.I("Current Device Mode: " + MyDevice.GetDeviceModeString(deviceMode));
          switch ((MyDevice.DeviceMode) deviceMode)
          {
            case MyDevice.DeviceMode.DevModeOsWithAdbAndPorts:
            case MyDevice.DeviceMode.DevModeFtm:
              Cursor.Current = Cursors.WaitCursor;
              int num = Form1.CheckDeviceAlive(this.progressItem.SessionId, deviceId, stringBuilder);
              swVersion = stringBuilder.ToString();
              Cursor.Current = Cursors.Default;
              if (num != 0)
              {
                this.progressItem.SetDeviceStatus(deviceId, false, interfaceItems);
                return;
              }
              break;
            case MyDevice.DeviceMode.DevModeFastboot:
              Cursor.Current = Cursors.WaitCursor;
              Form1.CheckDeviceAlive(this.progressItem.SessionId, deviceId, stringBuilder);
              swVersion = stringBuilder.ToString();
              Cursor.Current = Cursors.Default;
              break;
          }
        }
        this.DisplayButtons();
        this.DisplayStatus(swVersion);
        if (!this.toolParam.AutoTest || !this.btnNext.Enabled)
          return;
        this.detector.DoDetectDevice(false);
        this.autoRun = true;
        this.autoRunTime = DateTime.Now;
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void StartMainTask() => this.StartUpdate();

    private void StartUpdate()
    {
      Sessions.Restart();
      this.progressItem.ResetProgress();
      this.product.InitProduct(this.fwPage.ImagePath);
      this.progressItem.Task = new DispatchTask(new DispatchTask.OnTaskCompletedDelegate(this.StartUpdate_OnTaskCompleted));
      this.progressItem.Task.StartTask_StartUpdate(this.progressItem.SessionId, this.product, this.fwPage.ImagePath, this.progressItem.DeviceId, this.comboBoxSelectedFwOption.GetSelectedOptionValue());
      this.EnableBackgroundService(true);
      this.DoDetectDevice(false);
      this.tabPageCtrl.SelectTab(this.fwPage.ProgressPage);
    }

    private void timerFetchMsg_Tick(object sender, EventArgs e)
    {
      try
      {
        if (this.product == null)
          return;
        this.progressItem.SetProgress(this.product.FetchProgress(this.progressItem.SessionId), this.product.FetchProgressMessage(this.progressItem.SessionId));
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void StartUpdate_OnTaskCompleted(long result, Dictionary<string, object> outParams)
    {
      try
      {
        string message = this.product.FetchDetailMessage(outParams["SessionId"].ToString());
        this.product.StopUpdate();
        this.progressItem.Reset();
        this.EnableBackgroundService(false);
        if (this.toolParam.AutoTest)
          this.HandleAutoTestTask(result);
        else
          this.ShowErrorMessage(result, message);
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void HandleAutoTestTask(long result)
    {
      string str = string.Format("{0:0000}", (object) this.product.RunCount);
      this.toolParam.AutoTestProfile.WriteString("AutoTest", "Count", str);
      this.toolParam.AutoTestProfile.WriteString("AutoTest", str, result.ToString());
      if (this.toolParam.DecreaseAutoTestCount() == 0)
        this.ExitApplication();
      this.tabPageCtrl.SelectTab(this.fwPage.MainPage);
    }

    private void EnableBackgroundService(bool mainTaskRunning)
    {
      if (mainTaskRunning)
        this.runTime = 0;
      this.timerCountRunTime.Enabled = mainTaskRunning;
      this.timerFetchMsg.Enabled = mainTaskRunning;
    }

    private void DoDetectDevice(bool run)
    {
      this.detector.ResetDeviceList();
      this.detector.DoDetectDevice(run);
    }

    [DllImport("MobileFlashDll.dll")]
    private static extern int CheckDeviceAlive(
      string sessionId,
      string deviceId,
      StringBuilder stringBuilder);

    private void timerDataCollection_Tick(object sender, EventArgs e)
    {
      try
      {
        CollectionQueue instance = CollectionQueue.Instance;
        instance.RefershQueue();
        while (instance.Available)
        {
          CollectionFile availableFile = instance.GetAvailableFile();
          new DataUploadTask(new DataUploadTask.OnTaskCompletedDelegate(this.OnDataUploadCompleted)).StartTask(availableFile);
          CLogs.I(string.Format("Uploading collection data {0}...", (object) availableFile));
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
    }

    private void OnDataUploadCompleted(CollectionFile file)
    {
      CollectionQueue instance = CollectionQueue.Instance;
      if (file.Done)
      {
        CLogs.I(string.Format("Upload collection data {0} success.", (object) file));
        instance.Remove(file);
      }
      else
      {
        CLogs.I(string.Format("Upload collection data {0} fails.", (object) file));
        instance.Requeue(file);
      }
    }
  }
}
