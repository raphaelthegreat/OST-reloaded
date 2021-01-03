// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserModelWarning
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
    public class FormUserModelWarning : Form
    {
        private string title;
        private string phoneModel;
        private string imageModel;
        private IContainer components;
        private Label labelUserModelWarningMsg;
        private Button btnUserModelWarningOk;
        private Button btnUserModelWarningCancel;
        private CheckBox chkUserModelWarningApply;
        private Label labelUserModelWarningPhoneTag;
        private Label labelUserModelWarningImageTag;
        private Label labelUserModelWarningPhoneValue;
        private Label labelUserModelWarningImageValue;

        public string Title
        {
            set => this.title = value;
            get => this.title;
        }

        public bool CacheEnabled
        {
            set => this.chkUserModelWarningApply.Visible = value;
        }

        public bool CacheApplied => this.chkUserModelWarningApply.CheckState == CheckState.Checked;

        public FormUserModelWarning(string phoneModel, string imageModel)
        {
            this.InitializeComponent();
            this.title = Locale.Instance.LoadCombinedText("TITLE_WARNING");
            this.phoneModel = phoneModel;
            this.imageModel = imageModel;
        }

        private void FormUserModelWarning_Load(object sender, EventArgs e) => this.ReloadDefaultTexts();

        private void ReloadDefaultTexts()
        {
            this.Text = this.title;
            this.btnUserModelWarningOk.Text = Locale.Instance.LoadCombinedText(this.btnUserModelWarningOk.Text);
            this.btnUserModelWarningCancel.Text = Locale.Instance.LoadCombinedText(this.btnUserModelWarningCancel.Text);
            this.labelUserModelWarningPhoneTag.Text = Locale.Instance.LoadCombinedText(this.labelUserModelWarningPhoneTag.Text);
            this.labelUserModelWarningPhoneValue.Text = this.phoneModel;
            this.labelUserModelWarningImageTag.Text = Locale.Instance.LoadCombinedText(this.labelUserModelWarningImageTag.Text);
            this.labelUserModelWarningImageValue.Text = this.imageModel;
            this.chkUserModelWarningApply.Text = Locale.Instance.LoadCombinedText(this.chkUserModelWarningApply.Text);
            int height = this.labelUserModelWarningMsg.Size.Height;
            this.labelUserModelWarningMsg.Text = Locale.Instance.LoadCombinedText(this.labelUserModelWarningMsg.Text);
            this.ReCalculateLayout(this.labelUserModelWarningMsg.Size.Height - height);
            this.ReCalculateLayout(new Control[2]
            {
        (Control) this.labelUserModelWarningPhoneTag,
        (Control) this.labelUserModelWarningImageTag
            }, new Control[2]
            {
        (Control) this.labelUserModelWarningPhoneValue,
        (Control) this.labelUserModelWarningImageValue
            });
        }

        private void ReCalculateLayout(int offsetHeight)
        {
            if (this.chkUserModelWarningApply.Visible)
            {
                this.Height += offsetHeight;
                this.chkUserModelWarningApply.Top += offsetHeight;
                this.btnUserModelWarningOk.Top += offsetHeight;
                this.btnUserModelWarningCancel.Top += offsetHeight;
            }
            else
            {
                this.Height += offsetHeight - this.chkUserModelWarningApply.Height;
                this.btnUserModelWarningOk.Top += offsetHeight - this.chkUserModelWarningApply.Height;
                this.btnUserModelWarningCancel.Top += offsetHeight - this.chkUserModelWarningApply.Height;
            }
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
        }

        private void btnUserModelWarningOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUserModelWarningCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormUserModelWarning));
            this.labelUserModelWarningMsg = new Label();
            this.btnUserModelWarningOk = new Button();
            this.btnUserModelWarningCancel = new Button();
            this.chkUserModelWarningApply = new CheckBox();
            this.labelUserModelWarningPhoneTag = new Label();
            this.labelUserModelWarningImageTag = new Label();
            this.labelUserModelWarningPhoneValue = new Label();
            this.labelUserModelWarningImageValue = new Label();
            this.SuspendLayout();
            this.labelUserModelWarningMsg.AutoSize = true;
            this.labelUserModelWarningMsg.BackColor = Color.Transparent;
            this.labelUserModelWarningMsg.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.labelUserModelWarningMsg.ForeColor = SystemColors.ControlText;
            this.labelUserModelWarningMsg.Location = new Point(17, 100);
            this.labelUserModelWarningMsg.Margin = new Padding(4, 0, 4, 0);
            this.labelUserModelWarningMsg.MaximumSize = new Size(315, 0);
            this.labelUserModelWarningMsg.Name = "labelUserModelWarningMsg";
            this.labelUserModelWarningMsg.Size = new Size(239, 16);
            this.labelUserModelWarningMsg.TabIndex = 12;
            this.labelUserModelWarningMsg.Text = "USER_MODEL_NOT_MATCH_MSG_1";
            this.btnUserModelWarningOk.BackColor = Color.Transparent;
            this.btnUserModelWarningOk.BackgroundImage = (Image)Resources.Button;
            this.btnUserModelWarningOk.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnUserModelWarningOk.ForeColor = Color.MidnightBlue;
            this.btnUserModelWarningOk.Location = new Point(38, 170);
            this.btnUserModelWarningOk.Margin = new Padding(0);
            this.btnUserModelWarningOk.Name = "btnUserModelWarningOk";
            this.btnUserModelWarningOk.Size = new Size(108, 28);
            this.btnUserModelWarningOk.TabIndex = 15;
            this.btnUserModelWarningOk.Text = "BTN_OK";
            this.btnUserModelWarningOk.UseVisualStyleBackColor = false;
            this.btnUserModelWarningOk.Click += new EventHandler(this.btnUserModelWarningOk_Click);
            this.btnUserModelWarningCancel.BackColor = Color.Transparent;
            this.btnUserModelWarningCancel.BackgroundImage = (Image)Resources.Button;
            this.btnUserModelWarningCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnUserModelWarningCancel.ForeColor = Color.MidnightBlue;
            this.btnUserModelWarningCancel.Location = new Point(178, 170);
            this.btnUserModelWarningCancel.Margin = new Padding(0);
            this.btnUserModelWarningCancel.Name = "btnUserModelWarningCancel";
            this.btnUserModelWarningCancel.Size = new Size(108, 28);
            this.btnUserModelWarningCancel.TabIndex = 16;
            this.btnUserModelWarningCancel.Text = "BTN_CANCEL";
            this.btnUserModelWarningCancel.UseVisualStyleBackColor = false;
            this.btnUserModelWarningCancel.Click += new EventHandler(this.btnUserModelWarningCancel_Click);
            this.chkUserModelWarningApply.AutoSize = true;
            this.chkUserModelWarningApply.BackColor = Color.Transparent;
            this.chkUserModelWarningApply.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.chkUserModelWarningApply.Location = new Point(25, 134);
            this.chkUserModelWarningApply.Margin = new Padding(4, 3, 4, 3);
            this.chkUserModelWarningApply.Name = "chkUserModelWarningApply";
            this.chkUserModelWarningApply.Size = new Size(99, 17);
            this.chkUserModelWarningApply.TabIndex = 18;
            this.chkUserModelWarningApply.Text = "USER_APPLY";
            this.chkUserModelWarningApply.UseVisualStyleBackColor = false;
            this.chkUserModelWarningApply.Visible = false;
            this.labelUserModelWarningPhoneTag.AutoSize = true;
            this.labelUserModelWarningPhoneTag.BackColor = Color.Transparent;
            this.labelUserModelWarningPhoneTag.Location = new Point(17, 29);
            this.labelUserModelWarningPhoneTag.Name = "labelUserModelWarningPhoneTag";
            this.labelUserModelWarningPhoneTag.Size = new Size(252, 16);
            this.labelUserModelWarningPhoneTag.TabIndex = 19;
            this.labelUserModelWarningPhoneTag.Text = "USER_MODEL_WARNING_PHONE_TAG";
            this.labelUserModelWarningImageTag.AutoSize = true;
            this.labelUserModelWarningImageTag.BackColor = Color.Transparent;
            this.labelUserModelWarningImageTag.Location = new Point(17, 56);
            this.labelUserModelWarningImageTag.Name = "labelUserModelWarningImageTag";
            this.labelUserModelWarningImageTag.Size = new Size(250, 16);
            this.labelUserModelWarningImageTag.TabIndex = 20;
            this.labelUserModelWarningImageTag.Text = "USER_MODEL_WARNING_IMAGE_TAG";
            this.labelUserModelWarningPhoneValue.AutoSize = true;
            this.labelUserModelWarningPhoneValue.BackColor = Color.Transparent;
            this.labelUserModelWarningPhoneValue.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelUserModelWarningPhoneValue.ForeColor = Color.Red;
            this.labelUserModelWarningPhoneValue.Location = new Point(275, 29);
            this.labelUserModelWarningPhoneValue.Name = "labelUserModelWarningPhoneValue";
            this.labelUserModelWarningPhoneValue.Size = new Size(27, 16);
            this.labelUserModelWarningPhoneValue.TabIndex = 21;
            this.labelUserModelWarningPhoneValue.Text = "PV";
            this.labelUserModelWarningImageValue.AutoSize = true;
            this.labelUserModelWarningImageValue.BackColor = Color.Transparent;
            this.labelUserModelWarningImageValue.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelUserModelWarningImageValue.ForeColor = Color.Red;
            this.labelUserModelWarningImageValue.Location = new Point(275, 56);
            this.labelUserModelWarningImageValue.Name = "labelUserModelWarningImageValue";
            this.labelUserModelWarningImageValue.Size = new Size(24, 16);
            this.labelUserModelWarningImageValue.TabIndex = 22;
            this.labelUserModelWarningImageValue.Text = "IV";
            this.AutoScaleDimensions = new SizeF(8f, 16f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlLightLight;
            this.BackgroundImage = (Image)Resources.BackWarning;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new Size(338, 218);
            this.ControlBox = false;
            this.Controls.Add((Control)this.labelUserModelWarningImageValue);
            this.Controls.Add((Control)this.labelUserModelWarningPhoneValue);
            this.Controls.Add((Control)this.labelUserModelWarningImageTag);
            this.Controls.Add((Control)this.labelUserModelWarningPhoneTag);
            this.Controls.Add((Control)this.chkUserModelWarningApply);
            this.Controls.Add((Control)this.btnUserModelWarningCancel);
            this.Controls.Add((Control)this.btnUserModelWarningOk);
            this.Controls.Add((Control)this.labelUserModelWarningMsg);
            this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = nameof(FormUserModelWarning);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "TITLE_WARNING";
            this.Load += new EventHandler(this.FormUserModelWarning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
