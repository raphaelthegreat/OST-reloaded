// Decompiled with JetBrains decompiler
// Type: OnlineUpdateTool.UserForms.FormUserEnterSerialNumber
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MyResources.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineUpdateTool.UserForms
{
  public class FormUserEnterSerialNumber : Form
  {
    private IContainer components;
    private Button btnUserEnterSerialNumberOk;
    private Button btnUserEnterSerialNumberCancel;
    private Label labelUserEnterSerialNumber;
    private TextBox textBoxUserEnterSerialNumberValue;
    private string messageLocaleId;
    private string serialNumner;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormUserEnterSerialNumber));
      this.btnUserEnterSerialNumberOk = new Button();
      this.btnUserEnterSerialNumberCancel = new Button();
      this.labelUserEnterSerialNumber = new Label();
      this.textBoxUserEnterSerialNumberValue = new TextBox();
      this.SuspendLayout();
      this.btnUserEnterSerialNumberOk.BackColor = Color.Transparent;
      this.btnUserEnterSerialNumberOk.BackgroundImage = (Image) Resources.Button;
      this.btnUserEnterSerialNumberOk.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserEnterSerialNumberOk.ForeColor = Color.MidnightBlue;
      this.btnUserEnterSerialNumberOk.Location = new Point(22, 79);
      this.btnUserEnterSerialNumberOk.Margin = new Padding(0);
      this.btnUserEnterSerialNumberOk.Name = "btnUserEnterSerialNumberOk";
      this.btnUserEnterSerialNumberOk.Size = new Size(108, 28);
      this.btnUserEnterSerialNumberOk.TabIndex = 3;
      this.btnUserEnterSerialNumberOk.Text = "BTN_OK";
      this.btnUserEnterSerialNumberOk.UseVisualStyleBackColor = false;
      this.btnUserEnterSerialNumberOk.Click += new EventHandler(this.btnUserEnterSerialNumberOk_Click);
      this.btnUserEnterSerialNumberCancel.BackColor = Color.Transparent;
      this.btnUserEnterSerialNumberCancel.BackgroundImage = (Image) Resources.Button;
      this.btnUserEnterSerialNumberCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUserEnterSerialNumberCancel.ForeColor = Color.MidnightBlue;
      this.btnUserEnterSerialNumberCancel.Location = new Point(157, 79);
      this.btnUserEnterSerialNumberCancel.Margin = new Padding(0);
      this.btnUserEnterSerialNumberCancel.Name = "btnUserEnterSerialNumberCancel";
      this.btnUserEnterSerialNumberCancel.Size = new Size(108, 28);
      this.btnUserEnterSerialNumberCancel.TabIndex = 5;
      this.btnUserEnterSerialNumberCancel.Text = "BTN_CANCEL";
      this.btnUserEnterSerialNumberCancel.UseVisualStyleBackColor = false;
      this.btnUserEnterSerialNumberCancel.Click += new EventHandler(this.btnUserEnterSerialNumberCancel_Click);
      this.labelUserEnterSerialNumber.AutoSize = true;
      this.labelUserEnterSerialNumber.BackColor = Color.Transparent;
      this.labelUserEnterSerialNumber.Location = new Point(19, 11);
      this.labelUserEnterSerialNumber.Margin = new Padding(4, 0, 4, 0);
      this.labelUserEnterSerialNumber.MaximumSize = new Size(303, 0);
      this.labelUserEnterSerialNumber.Name = "labelUserEnterSerialNumber";
      this.labelUserEnterSerialNumber.Size = new Size(163, 16);
      this.labelUserEnterSerialNumber.TabIndex = 6;
      this.labelUserEnterSerialNumber.Text = "USER_ENTER_SERIAL_NUMBER_MSG";
      this.textBoxUserEnterSerialNumberValue.Location = new Point(21, 35);
      this.textBoxUserEnterSerialNumberValue.Margin = new Padding(4, 3, 4, 3);
      this.textBoxUserEnterSerialNumberValue.MaxLength = 32;
      this.textBoxUserEnterSerialNumberValue.Name = "textBoxUserEnterSerialNumberValue";
      this.textBoxUserEnterSerialNumberValue.Size = new Size(244, 23);
      this.textBoxUserEnterSerialNumberValue.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLightLight;
      this.BackgroundImage = (Image) Resources.BackWarning;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(292, 123);
      this.ControlBox = false;
      this.Controls.Add((Control) this.textBoxUserEnterSerialNumberValue);
      this.Controls.Add((Control) this.labelUserEnterSerialNumber);
      this.Controls.Add((Control) this.btnUserEnterSerialNumberCancel);
      this.Controls.Add((Control) this.btnUserEnterSerialNumberOk);
      this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4, 3, 4, 3);
      this.Name = "FormUserEnterSpc";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "USER_ENTER_SERIAL_NUMBER_TITLE";
      this.Load += new EventHandler(this.FormUserEnterSerialNumber_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public string MessageLocaleId
    {
      set => this.messageLocaleId = value;
    }

    public string SerialNumner => this.serialNumner;

    public FormUserEnterSerialNumber()
    {
      this.InitializeComponent();
      this.messageLocaleId = "USER_ENTER_SERIAL_NUMBER_MSG";
    }

    private void FormUserEnterSerialNumber_Load(object sender, EventArgs e) => this.ReloadDefaultTexts();

    private void ReloadDefaultTexts()
    {
      this.Text = Locale.Instance.LoadCombinedText(this.Text);
      this.btnUserEnterSerialNumberOk.Text = Locale.Instance.LoadCombinedText(this.btnUserEnterSerialNumberOk.Text);
      this.btnUserEnterSerialNumberCancel.Text = Locale.Instance.LoadCombinedText(this.btnUserEnterSerialNumberCancel.Text);
      int height = this.labelUserEnterSerialNumber.Size.Height;
      this.labelUserEnterSerialNumber.Text = Locale.Instance.LoadCombinedText(this.messageLocaleId);
      this.ReCalculateLayout(this.labelUserEnterSerialNumber.Size.Height - height);
    }

    private void ReCalculateLayout(int offsetHeight)
    {
      this.Height += offsetHeight;
      this.textBoxUserEnterSerialNumberValue.Top += offsetHeight;
      this.btnUserEnterSerialNumberOk.Top += offsetHeight;
      this.btnUserEnterSerialNumberCancel.Top += offsetHeight;
    }

    private void DisplayButtons() => this.btnUserEnterSerialNumberOk.Enabled = this.textBoxUserEnterSerialNumberValue.Text.Length == this.textBoxUserEnterSerialNumberValue.MaxLength;

    private void btnUserEnterSerialNumberOk_Click(object sender, EventArgs e)
    {
      this.serialNumner = this.textBoxUserEnterSerialNumberValue.Text;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnUserEnterSerialNumberCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
