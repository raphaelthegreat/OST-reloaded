// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserAuth
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MyResources.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace UserForms
{
  public class FormUserAuth : Form
  {
    private string username;
    private string password;
    private string domain;
    private IContainer components;
    private Button btnUserAuthOk;
    private Button btnUserAuthCancel;
    private Label labelUserAuthAccount;
    private Label labelUserAuthPassword;
    private TextBox textBoxUserAccount;
    private TextBox textBoxUserPassword;

    public string Username => this.username;

    public string Password => this.password;

    public string Domain => this.domain;

    public string Account => string.IsNullOrEmpty(this.username) || string.IsNullOrEmpty(this.domain) ? this.username : this.domain + "\\" + this.username;

    public FormUserAuth(string username, string domain)
    {
      this.InitializeComponent();
      this.username = username;
      this.password = string.Empty;
      this.domain = domain;
    }

    private void FormUserAuth_Load(object sender, EventArgs e)
    {
      this.ReloadDefaultTexts();
      this.textBoxUserAccount.Text = this.Account;
      this.textBoxUserPassword.Text = this.password;
      this.DisplayControls();
      this.textBoxUserAccount.Focus();
    }

    private void ReloadDefaultTexts()
    {
      this.Text = Locale.Instance.LoadCombinedText(this.Text);
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control is Label || control is Button)
          control.Text = Locale.Instance.LoadCombinedText(control.Text);
      }
      this.ReCalculateLayout(new Control[2]
      {
        (Control) this.labelUserAuthAccount,
        (Control) this.labelUserAuthPassword
      }, new Control[2]
      {
        (Control) this.textBoxUserAccount,
        (Control) this.textBoxUserPassword
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
      if (!(right is TextBox))
        return;
      right.Width -= num;
    }

    private void btnUserAuthOk_Click(object sender, EventArgs e)
    {
      this.username = this.textBoxUserAccount.Text.Contains("\\") ? this.textBoxUserAccount.Text.Substring(this.textBoxUserAccount.Text.IndexOf("\\") + 1) : this.textBoxUserAccount.Text;
      this.password = this.textBoxUserPassword.Text;
      this.domain = this.textBoxUserAccount.Text.Contains("\\") ? this.textBoxUserAccount.Text.Substring(0, this.textBoxUserAccount.Text.IndexOf("\\")) : string.Empty;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnUserAuthCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void DisplayControls() => this.btnUserAuthOk.Enabled = !string.IsNullOrEmpty(this.labelUserAuthAccount.Text) && !string.IsNullOrEmpty(this.labelUserAuthPassword.Text);

    private void labelUserAuth_TextChanged(object sender, EventArgs e) => this.DisplayControls();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormUserAuth));
      this.btnUserAuthOk = new Button();
      this.btnUserAuthCancel = new Button();
      this.labelUserAuthAccount = new Label();
      this.labelUserAuthPassword = new Label();
      this.textBoxUserAccount = new TextBox();
      this.textBoxUserPassword = new TextBox();
      this.SuspendLayout();
      this.btnUserAuthOk.BackColor = Color.Transparent;
      this.btnUserAuthOk.BackgroundImage = (Image) Resources.Button;
      this.btnUserAuthOk.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserAuthOk.ForeColor = Color.MidnightBlue;
      this.btnUserAuthOk.Location = new Point(45, 92);
      this.btnUserAuthOk.Margin = new Padding(0);
      this.btnUserAuthOk.Name = "btnUserAuthOk";
      this.btnUserAuthOk.Size = new Size(108, 28);
      this.btnUserAuthOk.TabIndex = 2;
      this.btnUserAuthOk.Text = "BTN_OK";
      this.btnUserAuthOk.UseVisualStyleBackColor = false;
      this.btnUserAuthOk.Click += new EventHandler(this.btnUserAuthOk_Click);
      this.btnUserAuthCancel.BackColor = Color.Transparent;
      this.btnUserAuthCancel.BackgroundImage = (Image) Resources.Button;
      this.btnUserAuthCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserAuthCancel.ForeColor = Color.MidnightBlue;
      this.btnUserAuthCancel.Location = new Point(174, 92);
      this.btnUserAuthCancel.Margin = new Padding(0);
      this.btnUserAuthCancel.Name = "btnUserAuthCancel";
      this.btnUserAuthCancel.Size = new Size(108, 28);
      this.btnUserAuthCancel.TabIndex = 3;
      this.btnUserAuthCancel.Text = "BTN_CANCEL";
      this.btnUserAuthCancel.UseVisualStyleBackColor = false;
      this.btnUserAuthCancel.Click += new EventHandler(this.btnUserAuthCancel_Click);
      this.labelUserAuthAccount.AutoSize = true;
      this.labelUserAuthAccount.BackColor = Color.Transparent;
      this.labelUserAuthAccount.Location = new Point(26, 23);
      this.labelUserAuthAccount.Margin = new Padding(5, 0, 5, 0);
      this.labelUserAuthAccount.MaximumSize = new Size(404, 0);
      this.labelUserAuthAccount.Name = "labelUserAuthAccount";
      this.labelUserAuthAccount.Size = new Size(165, 16);
      this.labelUserAuthAccount.TabIndex = 19;
      this.labelUserAuthAccount.Text = "USER_AUTH_USERNAME";
      this.labelUserAuthPassword.AutoSize = true;
      this.labelUserAuthPassword.BackColor = Color.Transparent;
      this.labelUserAuthPassword.Location = new Point(26, 55);
      this.labelUserAuthPassword.Margin = new Padding(5, 0, 5, 0);
      this.labelUserAuthPassword.MaximumSize = new Size(404, 0);
      this.labelUserAuthPassword.Name = "labelUserAuthPassword";
      this.labelUserAuthPassword.Size = new Size(173, 16);
      this.labelUserAuthPassword.TabIndex = 20;
      this.labelUserAuthPassword.Text = "USER_LOGIN_PASSWORD";
      this.textBoxUserAccount.Location = new Point(135, 20);
      this.textBoxUserAccount.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserAccount.Name = "textBoxUserAccount";
      this.textBoxUserAccount.Size = new Size(165, 23);
      this.textBoxUserAccount.TabIndex = 0;
      this.textBoxUserAccount.TextChanged += new EventHandler(this.labelUserAuth_TextChanged);
      this.textBoxUserPassword.Location = new Point(135, 49);
      this.textBoxUserPassword.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserPassword.Name = "textBoxUserPassword";
      this.textBoxUserPassword.PasswordChar = '*';
      this.textBoxUserPassword.Size = new Size(165, 23);
      this.textBoxUserPassword.TabIndex = 1;
      this.textBoxUserPassword.TextChanged += new EventHandler(this.labelUserAuth_TextChanged);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLightLight;
      this.BackgroundImage = (Image) Resources.BackWarning;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(335, 142);
      this.ControlBox = false;
      this.Controls.Add((Control) this.textBoxUserPassword);
      this.Controls.Add((Control) this.textBoxUserAccount);
      this.Controls.Add((Control) this.labelUserAuthPassword);
      this.Controls.Add((Control) this.labelUserAuthAccount);
      this.Controls.Add((Control) this.btnUserAuthCancel);
      this.Controls.Add((Control) this.btnUserAuthOk);
      this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (FormUserAuth);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "TITLE_AUTH";
      this.Load += new EventHandler(this.FormUserAuth_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private enum LoginState
    {
      IDLE = 1,
      RUNNING = 2,
      RETRY = 3,
    }
  }
}
