// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserWarning
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MyResources.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserForms
{
  public class FormUserWarning : Form
  {
    private string title;
    private string message;
    private FormUserWarning.ButtonCaseID buttonCaseId;
    private IContainer components;
    private Label labelUserWarningMsg;
    private Button btnUserWarningLeft;
    private Button btnUserWarningRight;
    private CheckBox chkUserWarningApply;

    public string Title
    {
      set => this.title = value;
      get => this.title;
    }

    public string Message
    {
      set => this.message = value;
    }

    public FormUserWarning.ButtonCaseID ButtonCaseId
    {
      set => this.buttonCaseId = value;
    }

    public bool CacheEnabled
    {
      set => this.chkUserWarningApply.Visible = value;
    }

    public bool CacheApplied => this.chkUserWarningApply.CheckState == CheckState.Checked;

    public FormUserWarning()
    {
      this.InitializeComponent();
      this.title = Locale.Instance.LoadCombinedText("TITLE_WARNING");
      this.message = string.Empty;
      this.buttonCaseId = FormUserWarning.ButtonCaseID.OK_CANCEL;
    }

    private void FormUserWarning_Load(object sender, EventArgs e) => this.ReloadDefaultTexts();

    private void ReloadDefaultTexts()
    {
      this.Text = this.title;
      this.chkUserWarningApply.Text = Locale.Instance.LoadCombinedText(this.chkUserWarningApply.Text);
      int height = this.labelUserWarningMsg.Size.Height;
      this.labelUserWarningMsg.Text = this.message.Replace("\\n", Environment.NewLine);
      this.ReCalculateLayout(this.labelUserWarningMsg.Size.Height - height);
      this.ReCalculateLayout(this.buttonCaseId);
    }

    private void ReCalculateLayout(int offsetHeight)
    {
      if (this.chkUserWarningApply.Visible)
      {
        this.Height += offsetHeight;
        this.chkUserWarningApply.Top += offsetHeight;
        this.btnUserWarningLeft.Top += offsetHeight;
        this.btnUserWarningRight.Top += offsetHeight;
      }
      else
      {
        this.Height += offsetHeight - this.chkUserWarningApply.Height;
        this.btnUserWarningLeft.Top += offsetHeight - this.chkUserWarningApply.Height;
        this.btnUserWarningRight.Top += offsetHeight - this.chkUserWarningApply.Height;
      }
      if (this.btnUserWarningLeft.Bottom + 10 <= this.Height)
        return;
      this.Height = 155;
    }

    private void ReCalculateLayout(FormUserWarning.ButtonCaseID buttonCaseId)
    {
      switch (buttonCaseId)
      {
        case FormUserWarning.ButtonCaseID.OK:
          this.btnUserWarningLeft.Text = Locale.Instance.LoadCombinedText("BTN_OK");
          this.btnUserWarningLeft.Left = (this.Width - this.btnUserWarningLeft.Width) / 2;
          this.btnUserWarningRight.Visible = false;
          break;
        case FormUserWarning.ButtonCaseID.OK_CANCEL:
          this.btnUserWarningLeft.Text = Locale.Instance.LoadCombinedText("BTN_OK");
          this.btnUserWarningRight.Text = Locale.Instance.LoadCombinedText("BTN_CANCEL");
          break;
        case FormUserWarning.ButtonCaseID.OK_IGNORE:
          this.btnUserWarningLeft.Text = Locale.Instance.LoadCombinedText("BTN_OK");
          this.btnUserWarningRight.Text = Locale.Instance.LoadCombinedText("BTN_IGNORE");
          break;
      }
    }

    private void btnUserWarningLeft_Click(object sender, EventArgs e)
    {
      this.DialogResult = this.GetDialogResult(this.btnUserWarningLeft.Text);
      this.Close();
    }

    private void btnUserWarningRight_Click(object sender, EventArgs e)
    {
      this.DialogResult = this.GetDialogResult(this.btnUserWarningRight.Text);
      this.Close();
    }

    private DialogResult GetDialogResult(string label)
    {
      if (label.Equals(Locale.Instance.LoadCombinedText("BTN_OK")))
        return DialogResult.OK;
      if (label.Equals(Locale.Instance.LoadCombinedText("BTN_CANCEL")))
        return DialogResult.Cancel;
      if (label.Equals(Locale.Instance.LoadCombinedText("BTN_RETRY")))
        return DialogResult.Retry;
      return label.Equals(Locale.Instance.LoadCombinedText("BTN_IGNORE")) ? DialogResult.Ignore : DialogResult.None;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormUserWarning));
      this.labelUserWarningMsg = new Label();
      this.btnUserWarningLeft = new Button();
      this.btnUserWarningRight = new Button();
      this.chkUserWarningApply = new CheckBox();
      this.SuspendLayout();
      this.labelUserWarningMsg.AutoSize = true;
      this.labelUserWarningMsg.BackColor = Color.Transparent;
      this.labelUserWarningMsg.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 136);
      this.labelUserWarningMsg.ForeColor = SystemColors.ControlText;
      this.labelUserWarningMsg.Location = new Point(14, 9);
      this.labelUserWarningMsg.MaximumSize = new Size(270, 0);
      this.labelUserWarningMsg.Name = "labelUserWarningMsg";
      this.labelUserWarningMsg.Size = new Size(137, 13);
      this.labelUserWarningMsg.TabIndex = 12;
      this.labelUserWarningMsg.Text = "USER_WARNING_MSG";
      this.btnUserWarningLeft.BackColor = Color.Transparent;
      this.btnUserWarningLeft.BackgroundImage = (Image) Resources.Button;
      this.btnUserWarningLeft.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserWarningLeft.ForeColor = Color.MidnightBlue;
      this.btnUserWarningLeft.Location = new Point(33, 55);
      this.btnUserWarningLeft.Margin = new Padding(0);
      this.btnUserWarningLeft.Name = "btnUserWarningLeft";
      this.btnUserWarningLeft.Size = new Size(108, 28);
      this.btnUserWarningLeft.TabIndex = 15;
      this.btnUserWarningLeft.Text = "BTN_OK";
      this.btnUserWarningLeft.UseVisualStyleBackColor = false;
      this.btnUserWarningLeft.Click += new EventHandler(this.btnUserWarningLeft_Click);
      this.btnUserWarningRight.BackColor = Color.Transparent;
      this.btnUserWarningRight.BackgroundImage = (Image) Resources.Button;
      this.btnUserWarningRight.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserWarningRight.ForeColor = Color.MidnightBlue;
      this.btnUserWarningRight.Location = new Point(153, 55);
      this.btnUserWarningRight.Margin = new Padding(0);
      this.btnUserWarningRight.Name = "btnUserWarningRight";
      this.btnUserWarningRight.Size = new Size(108, 28);
      this.btnUserWarningRight.TabIndex = 16;
      this.btnUserWarningRight.Text = "BTN_CANCEL";
      this.btnUserWarningRight.UseVisualStyleBackColor = false;
      this.btnUserWarningRight.Click += new EventHandler(this.btnUserWarningRight_Click);
      this.chkUserWarningApply.AutoSize = true;
      this.chkUserWarningApply.BackColor = Color.Transparent;
      this.chkUserWarningApply.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 136);
      this.chkUserWarningApply.Location = new Point(22, 34);
      this.chkUserWarningApply.Name = "chkUserWarningApply";
      this.chkUserWarningApply.Size = new Size(87, 15);
      this.chkUserWarningApply.TabIndex = 18;
      this.chkUserWarningApply.Text = "USER_APPLY";
      this.chkUserWarningApply.UseVisualStyleBackColor = false;
      this.chkUserWarningApply.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLightLight;
      this.BackgroundImage = (Image) Resources.BackWarning;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(294, 98);
      this.ControlBox = false;
      this.Controls.Add((Control) this.chkUserWarningApply);
      this.Controls.Add((Control) this.btnUserWarningRight);
      this.Controls.Add((Control) this.btnUserWarningLeft);
      this.Controls.Add((Control) this.labelUserWarningMsg);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FormUserWarning);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "TITLE_WARNING";
      this.Load += new EventHandler(this.FormUserWarning_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public enum ButtonCaseID
    {
      OK = 1,
      OK_CANCEL = 2,
      OK_IGNORE = 3,
    }
  }
}
