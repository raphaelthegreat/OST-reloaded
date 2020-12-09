// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserLogin
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MRG.Controls.UI;
using MyResources.OtaHandlerService;
using MyResources.Properties;
using OtaControl;
using Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Utils;

namespace UserForms
{
  public class FormUserLogin : Form
  {
    private string account;
    private string password;
    private string domain;
    private string commToken;
    private FormUserLogin.LoginState state;
    private string loginMessage;
    private BackgroundWorker worker;
    private string errSvrStatus = string.Empty;
    private string errSvrMsg = string.Empty;
    private IContainer components;
    private Button btnUserLoginOk;
    private Button btnUserLoginCancel;
    private Label labelUserLoginAccount;
    private Label labelUserLoginPassword;
    private TextBox textBoxUserAccount;
    private TextBox textBoxUserPassword;
    private Label labelUserLoginMessage;
    private LoadingCircle loadingCircle;
    private Label labelUserLoginDomain;
    private ComboBox textBoxUserDomain;
    private Label labelServerErrMsg;

    public string Account => this.account;

    public string Password => this.password;

    public string Domain => this.domain;

    public string CommToken => this.commToken;

    public FormUserLogin(string account)
    {
      this.InitializeComponent();
      this.account = account;
      this.password = string.Empty;
      this.commToken = "";
      this.state = FormUserLogin.LoginState.IDLE;
      this.loginMessage = string.Empty;
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
    }

    public FormUserLogin(string account, string domain)
    {
      this.InitializeComponent();
      this.account = account;
      this.password = string.Empty;
      this.domain = domain;
      this.commToken = "";
      this.state = FormUserLogin.LoginState.IDLE;
      this.loginMessage = string.Empty;
      this.worker = new BackgroundWorker();
      this.worker.WorkerSupportsCancellation = false;
      this.worker.DoWork += new DoWorkEventHandler(this.DoWork);
      this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
    }

    private void FormUserLogin_Load(object sender, EventArgs e)
    {
      this.ReloadDefaultTexts();
      this.textBoxUserAccount.Text = this.account;
      this.textBoxUserPassword.Text = this.password;
      if (this.domain.Length > 0)
      {
        for (int index = 0; index < this.textBoxUserDomain.Items.Count; ++index)
        {
          if (this.textBoxUserDomain.GetItemText(this.textBoxUserDomain.Items[index]) == this.domain)
            this.textBoxUserDomain.SelectedIndex = index;
        }
      }
      this.state = FormUserLogin.LoginState.IDLE;
      this.DisplayControls();
      this.textBoxUserAccount.Focus();
      this.loadingCircle.InnerCircleRadius = 5;
      this.loadingCircle.OuterCircleRadius = 8;
      UserInterAction.Owner = (IWin32Window) this;
      CLogs.B("Starting login request.");
    }

    private void ReloadDefaultTexts()
    {
      this.Text = Locale.Instance.LoadCombinedText(this.Text);
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control is Label || control is Button)
          control.Text = Locale.Instance.LoadCombinedText(control.Text);
      }
      this.ReCalculateLayout(new Control[3]
      {
        (Control) this.labelUserLoginAccount,
        (Control) this.labelUserLoginPassword,
        (Control) this.labelUserLoginDomain
      }, new Control[3]
      {
        (Control) this.textBoxUserAccount,
        (Control) this.textBoxUserPassword,
        (Control) this.textBoxUserDomain
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
      switch (right)
      {
        case TextBox _:
        case ComboBox _:
          right.Width -= num;
          break;
      }
    }

    private void btnUserLoginOk_Click(object sender, EventArgs e) => this.StartLoginTask();

    private void btnUserLoginCancel_Click(object sender, EventArgs e)
    {
      CLogs.E("login request is canceled.");
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private string GetStateMessage()
    {
      switch (this.state)
      {
        case FormUserLogin.LoginState.RUNNING:
          return Locale.Instance.LoadCombinedText("USER_DEPLOYMENT_UPDATE_MSG_CONNECT");
        case FormUserLogin.LoginState.RETRY:
          return Locale.Instance.LoadCombinedText("USER_LOGIN_FAILED");
        default:
          return string.Empty;
      }
    }

    private void DisplayControls()
    {
      this.labelUserLoginAccount.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.textBoxUserAccount.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.labelUserLoginPassword.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.textBoxUserPassword.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.labelUserLoginDomain.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.textBoxUserDomain.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.loadingCircle.Visible = this.state == FormUserLogin.LoginState.RUNNING;
      this.loadingCircle.Active = this.state == FormUserLogin.LoginState.RUNNING;
      this.labelUserLoginMessage.ForeColor = this.state == FormUserLogin.LoginState.RETRY ? Color.Red : Color.Black;
      this.labelUserLoginMessage.Text = this.GetStateMessage();
      this.labelUserLoginMessage.Visible = !string.IsNullOrEmpty(this.labelUserLoginMessage.Text);
      this.btnUserLoginOk.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
      this.btnUserLoginCancel.Enabled = this.state != FormUserLogin.LoginState.RUNNING;
    }

    public bool StartLogin(string account, string password, string domain)
    {
      this.account = account;
      this.password = password;
      this.domain = domain;
      string empty = string.Empty;
      try
      {
        CLogs.I("Query rights from remote server, account: {0}, domain: {1}", (object) account, (object) domain);
        string domain1 = domain;
        if (domain1 == "N/A")
          domain1 = "";
        this.QueryRights(account, password, domain1);
        return true;
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      return false;
    }

    private void StartLoginTask()
    {
      this.state = FormUserLogin.LoginState.RUNNING;
      this.DisplayControls();
      this.account = this.textBoxUserAccount.Text;
      this.password = this.textBoxUserPassword.Text;
      this.domain = this.textBoxUserDomain.Text;
      this.commToken = "";
      this.worker.RunWorkerAsync((object) new Dictionary<string, string>()
      {
        {
          "Account",
          this.account
        },
        {
          "Password",
          this.password
        },
        {
          "Domain",
          this.domain
        }
      });
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      string empty = string.Empty;
      Sessions.AddChildThread(empty);
      this.RemoveServerErrMsg();
      try
      {
        Dictionary<string, string> dictionary = e.Argument as Dictionary<string, string>;
        string account;
        dictionary.TryGetValue("Account", out account);
        string password;
        dictionary.TryGetValue("Password", out password);
        dictionary.TryGetValue("Domain", out this.domain);
        CLogs.I("Query rights from remote server, account: " + account);
        string domain = this.domain;
        if (domain == "N/A")
          domain = "";
        this.QueryRights(account, password, domain);
        e.Result = (object) 0L;
      }
      catch (CException ex)
      {
        e.Result = (object) ex.CResult;
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      catch (Exception ex)
      {
        e.Result = (object) 1064L;
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        Sessions.RemoveChildThread(empty);
      }
    }

    private void QueryRights(string account, string password, string domain)
    {
      if (!ServerInfo.login(account, password, domain, ref this.commToken, ref this.errSvrStatus, ref this.errSvrMsg) || this.commToken.Length == 0)
        throw new WebException("Login failed!");
    }

    private void QueryRightsIns(string account, string password)
    {
      OtaAccount account1 = OtaParam.Instance.Account;
      OtaHandler otaHandler = new OtaHandler().SetLoginUrl(OtaParam.Instance.LoginUrl).Login(account, password);
      account1.SetRights(otaHandler.QueryToolRights());
      foreach (string group in new List<string>((IEnumerable<string>) account1.WebServiceGroups.Keys))
        account1.SetWebServiceGroup(group, otaHandler.QueryServices(group));
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        if ((long) e.Result == 0L)
        {
          CLogs.I("Login request is success.");
          this.DialogResult = DialogResult.OK;
        }
        else
        {
          CLogs.W("Login request is failed, wait to retry again.");
          this.state = FormUserLogin.LoginState.RETRY;
          this.DisplayControls();
          this.DisplayServerErrMsg();
        }
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
      }
      finally
      {
        CLogs.NewLine();
        CLogs.NewLine();
      }
    }

    private void textBoxUserPassword_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnUserLoginOk_Click(sender, (EventArgs) e);
    }

    private void DisplayServerErrMsg()
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new FormUserLogin.DisplayServerErrMsg_Callback(this.DisplayServerErrMsg));
      }
      else
      {
        this.labelServerErrMsg.Visible = true;
        if (this.errSvrStatus == "ConnectFailed")
        {
          this.labelServerErrMsg.Text = "Connection failed";
        }
        else
        {
          if (this.errSvrStatus == string.Empty)
            this.errSvrStatus = "NA";
          if (this.errSvrMsg == string.Empty)
            this.errSvrMsg = "NA";
          this.labelServerErrMsg.Text = "Server response: " + this.errSvrStatus + Environment.NewLine + "Error message: " + this.errSvrMsg;
        }
      }
    }

    private void RemoveServerErrMsg()
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new FormUserLogin.RemoveServerErrMsg_Callback(this.RemoveServerErrMsg));
      }
      else
      {
        this.errSvrStatus = string.Empty;
        this.errSvrMsg = string.Empty;
        this.labelServerErrMsg.Visible = false;
        this.labelServerErrMsg.Text = string.Empty;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormUserLogin));
      this.btnUserLoginOk = new Button();
      this.btnUserLoginCancel = new Button();
      this.labelUserLoginAccount = new Label();
      this.labelUserLoginPassword = new Label();
      this.labelUserLoginDomain = new Label();
      this.textBoxUserAccount = new TextBox();
      this.textBoxUserPassword = new TextBox();
      this.labelUserLoginMessage = new Label();
      this.loadingCircle = new LoadingCircle();
      this.textBoxUserDomain = new ComboBox();
      this.labelServerErrMsg = new Label();
      this.SuspendLayout();
      this.btnUserLoginOk.BackColor = Color.Transparent;
      this.btnUserLoginOk.BackgroundImage = (Image) Resources.Button;
      this.btnUserLoginOk.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserLoginOk.ForeColor = Color.MidnightBlue;
      this.btnUserLoginOk.Location = new Point(74, 118);
      this.btnUserLoginOk.Margin = new Padding(0);
      this.btnUserLoginOk.Name = "btnUserLoginOk";
      this.btnUserLoginOk.Size = new Size(110, 28);
      this.btnUserLoginOk.TabIndex = 2;
      this.btnUserLoginOk.Text = "BTN_OK";
      this.btnUserLoginOk.UseVisualStyleBackColor = false;
      this.btnUserLoginOk.Click += new EventHandler(this.btnUserLoginOk_Click);
      this.btnUserLoginCancel.BackColor = Color.Transparent;
      this.btnUserLoginCancel.BackgroundImage = (Image) Resources.Button;
      this.btnUserLoginCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserLoginCancel.ForeColor = Color.MidnightBlue;
      this.btnUserLoginCancel.Location = new Point(190, 118);
      this.btnUserLoginCancel.Margin = new Padding(0);
      this.btnUserLoginCancel.Name = "btnUserLoginCancel";
      this.btnUserLoginCancel.Size = new Size(107, 28);
      this.btnUserLoginCancel.TabIndex = 3;
      this.btnUserLoginCancel.Text = "BTN_CANCEL";
      this.btnUserLoginCancel.UseVisualStyleBackColor = false;
      this.btnUserLoginCancel.Click += new EventHandler(this.btnUserLoginCancel_Click);
      this.labelUserLoginAccount.AutoSize = true;
      this.labelUserLoginAccount.BackColor = Color.Transparent;
      this.labelUserLoginAccount.Location = new Point(26, 23);
      this.labelUserLoginAccount.Margin = new Padding(5, 0, 5, 0);
      this.labelUserLoginAccount.MaximumSize = new Size(404, 0);
      this.labelUserLoginAccount.Name = "labelUserLoginAccount";
      this.labelUserLoginAccount.Size = new Size(162, 16);
      this.labelUserLoginAccount.TabIndex = 19;
      this.labelUserLoginAccount.Text = "USER_LOGIN_ACCOUNT";
      this.labelUserLoginPassword.AutoSize = true;
      this.labelUserLoginPassword.BackColor = Color.Transparent;
      this.labelUserLoginPassword.Location = new Point(26, 55);
      this.labelUserLoginPassword.Margin = new Padding(5, 0, 5, 0);
      this.labelUserLoginPassword.MaximumSize = new Size(404, 0);
      this.labelUserLoginPassword.Name = "labelUserLoginPassword";
      this.labelUserLoginPassword.Size = new Size(173, 16);
      this.labelUserLoginPassword.TabIndex = 20;
      this.labelUserLoginPassword.Text = "USER_LOGIN_PASSWORD";
      this.labelUserLoginDomain.AutoSize = true;
      this.labelUserLoginDomain.BackColor = Color.Transparent;
      this.labelUserLoginDomain.Location = new Point(26, 84);
      this.labelUserLoginDomain.Margin = new Padding(5, 0, 5, 0);
      this.labelUserLoginDomain.MaximumSize = new Size(404, 0);
      this.labelUserLoginDomain.Name = "labelUserLoginDomain";
      this.labelUserLoginDomain.Size = new Size(151, 16);
      this.labelUserLoginDomain.TabIndex = 25;
      this.labelUserLoginDomain.Text = "USER_LOGIN_DOMAIN";
      this.textBoxUserAccount.Location = new Point(197, 20);
      this.textBoxUserAccount.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserAccount.Name = "textBoxUserAccount";
      this.textBoxUserAccount.Size = new Size(165, 23);
      this.textBoxUserAccount.TabIndex = 0;
      this.textBoxUserPassword.Location = new Point(197, 52);
      this.textBoxUserPassword.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserPassword.Name = "textBoxUserPassword";
      this.textBoxUserPassword.PasswordChar = '*';
      this.textBoxUserPassword.Size = new Size(165, 23);
      this.textBoxUserPassword.TabIndex = 1;
      this.textBoxUserPassword.KeyDown += new KeyEventHandler(this.textBoxUserPassword_KeyDown);
      this.labelUserLoginMessage.AutoSize = true;
      this.labelUserLoginMessage.BackColor = Color.Transparent;
      this.labelUserLoginMessage.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelUserLoginMessage.Location = new Point(26, 153);
      this.labelUserLoginMessage.Margin = new Padding(5, 0, 5, 0);
      this.labelUserLoginMessage.MaximumSize = new Size(404, 0);
      this.labelUserLoginMessage.Name = "labelUserLoginMessage";
      this.labelUserLoginMessage.Size = new Size(145, 13);
      this.labelUserLoginMessage.TabIndex = 23;
      this.labelUserLoginMessage.Text = "USER_LOGIN_MESSAGE";
      this.loadingCircle.Active = false;
      this.loadingCircle.BackColor = Color.Transparent;
      this.loadingCircle.Color = Color.DarkGray;
      this.loadingCircle.ForeColor = SystemColors.HotTrack;
      this.loadingCircle.InnerCircleRadius = 5;
      this.loadingCircle.Location = new Point(31, 119);
      this.loadingCircle.Name = "loadingCircle";
      this.loadingCircle.NumberSpoke = 12;
      this.loadingCircle.OuterCircleRadius = 11;
      this.loadingCircle.RotationSpeed = 80;
      this.loadingCircle.Size = new Size(18, 20);
      this.loadingCircle.SpokeThickness = 2;
      this.loadingCircle.StylePreset = LoadingCircle.StylePresets.MacOSX;
      this.loadingCircle.TabIndex = 24;
      this.loadingCircle.Text = "loadingCircle";
      this.textBoxUserDomain.CausesValidation = false;
      this.textBoxUserDomain.DropDownWidth = 100;
      this.textBoxUserDomain.Items.AddRange(new object[5]
      {
        (object) "fihtdc.com",
        (object) "CMCS.NJ.com",
        (object) "idpbg.efoxconn.com",
        (object) "fih.gd",
        (object) "N/A"
      });
      this.textBoxUserDomain.Location = new Point(197, 84);
      this.textBoxUserDomain.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserDomain.MaxDropDownItems = 3;
      this.textBoxUserDomain.Name = "textBoxUserDomain";
      this.textBoxUserDomain.Size = new Size(165, 24);
      this.textBoxUserDomain.TabIndex = 0;
      this.textBoxUserDomain.Text = "fihtdc.com";
      this.labelServerErrMsg.AutoSize = true;
      this.labelServerErrMsg.BackColor = Color.Transparent;
      this.labelServerErrMsg.Font = new Font("Verdana", 8.25f);
      this.labelServerErrMsg.ForeColor = Color.Red;
      this.labelServerErrMsg.Location = new Point(26, 171);
      this.labelServerErrMsg.Margin = new Padding(5, 0, 5, 0);
      this.labelServerErrMsg.MaximumSize = new Size(404, 0);
      this.labelServerErrMsg.Name = "labelServerErrMsg";
      this.labelServerErrMsg.Size = new Size(116, 13);
      this.labelServerErrMsg.TabIndex = 26;
      this.labelServerErrMsg.Text = "SERVER_ERR_MSG";
      this.labelServerErrMsg.Visible = false;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLightLight;
      this.BackgroundImage = (Image) Resources.BackWarning;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(388, 209);
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelServerErrMsg);
      this.Controls.Add((Control) this.textBoxUserDomain);
      this.Controls.Add((Control) this.labelUserLoginDomain);
      this.Controls.Add((Control) this.loadingCircle);
      this.Controls.Add((Control) this.labelUserLoginMessage);
      this.Controls.Add((Control) this.textBoxUserPassword);
      this.Controls.Add((Control) this.textBoxUserAccount);
      this.Controls.Add((Control) this.labelUserLoginPassword);
      this.Controls.Add((Control) this.labelUserLoginAccount);
      this.Controls.Add((Control) this.btnUserLoginCancel);
      this.Controls.Add((Control) this.btnUserLoginOk);
      this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (FormUserLogin);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "TITLE_LOGIN";
      this.Load += new EventHandler(this.FormUserLogin_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private enum LoginState
    {
      IDLE = 1,
      RUNNING = 2,
      RETRY = 3,
    }

    private delegate void DisplayServerErrMsg_Callback();

    private delegate void RemoveServerErrMsg_Callback();
  }
}
