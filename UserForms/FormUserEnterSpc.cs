// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserEnterSpc
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
    public class FormUserEnterSpc : Form
    {
        private string messageLocaleId;
        private string spc;
        private IContainer components;
        private Button btnUserEnterSpcOk;
        private Button btnUserEnterSpcCancel;
        private Label labelUserEnterSpcMsg;
        private TextBox textBoxUserEnterSpcValue;

        public string MessageLocaleId
        {
            set => this.messageLocaleId = value;
        }

        public string Spc
        {
            get => this.spc;
            set => this.spc = value;
        }

        public FormUserEnterSpc()
        {
            this.InitializeComponent();
            this.messageLocaleId = "USER_ENTER_SPC_MSG";
        }

        private void FormUserEnterSpc_Load(object sender, EventArgs e)
        {
            this.ReloadDefaultTexts();
            this.RemoveInvlidCharacters(this.spc);
            this.DisplayButtons();
        }

        private void ReloadDefaultTexts()
        {
            this.Text = Locale.Instance.LoadCombinedText(this.Text);
            this.btnUserEnterSpcOk.Text = Locale.Instance.LoadCombinedText(this.btnUserEnterSpcOk.Text);
            this.btnUserEnterSpcCancel.Text = Locale.Instance.LoadCombinedText(this.btnUserEnterSpcCancel.Text);
            int height = this.labelUserEnterSpcMsg.Size.Height;
            this.labelUserEnterSpcMsg.Text = Locale.Instance.LoadCombinedText(this.messageLocaleId);
            this.ReCalculateLayout(this.labelUserEnterSpcMsg.Size.Height - height);
        }

        private void ReCalculateLayout(int offsetHeight)
        {
            this.Height += offsetHeight;
            this.textBoxUserEnterSpcValue.Top += offsetHeight;
            this.btnUserEnterSpcOk.Top += offsetHeight;
            this.btnUserEnterSpcCancel.Top += offsetHeight;
        }

        private void DisplayButtons() => this.btnUserEnterSpcOk.Enabled = this.textBoxUserEnterSpcValue.Text.Length == this.textBoxUserEnterSpcValue.MaxLength;

        private void btnUserEnterSpcOk_Click(object sender, EventArgs e)
        {
            this.spc = this.textBoxUserEnterSpcValue.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUserEnterSpcCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxUserEnterSpcValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.CompareTo('0') >= 0 || (e.KeyChar.CompareTo('9') <= 0 || Convert.ToInt32(e.KeyChar) == Keys.Back.GetHashCode()))
                return;
            e.Handled = true;
        }

        private void textBoxUserEnterSpcValue_TextChanged(object sender, EventArgs e)
        {
            this.RemoveInvlidCharacters(this.textBoxUserEnterSpcValue.Text);
            this.DisplayButtons();
        }

        private void RemoveInvlidCharacters(string input)
        {
            string empty = string.Empty;
            foreach (char ch in input)
            {
                switch (ch)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        empty += (string)(object)ch;
                        break;
                }
                if (empty.Length == this.textBoxUserEnterSpcValue.MaxLength)
                    break;
            }
            this.spc = empty;
            this.textBoxUserEnterSpcValue.Text = empty;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormUserEnterSpc));
            this.btnUserEnterSpcOk = new Button();
            this.btnUserEnterSpcCancel = new Button();
            this.labelUserEnterSpcMsg = new Label();
            this.textBoxUserEnterSpcValue = new TextBox();
            this.SuspendLayout();
            this.btnUserEnterSpcOk.BackColor = Color.Transparent;
            this.btnUserEnterSpcOk.BackgroundImage = (Image)Resources.Button;
            this.btnUserEnterSpcOk.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnUserEnterSpcOk.ForeColor = Color.MidnightBlue;
            this.btnUserEnterSpcOk.Location = new Point(22, 79);
            this.btnUserEnterSpcOk.Margin = new Padding(0);
            this.btnUserEnterSpcOk.Name = "btnUserEnterSpcOk";
            this.btnUserEnterSpcOk.Size = new Size(108, 28);
            this.btnUserEnterSpcOk.TabIndex = 3;
            this.btnUserEnterSpcOk.Text = "BTN_OK";
            this.btnUserEnterSpcOk.UseVisualStyleBackColor = false;
            this.btnUserEnterSpcOk.Click += new EventHandler(this.btnUserEnterSpcOk_Click);
            this.btnUserEnterSpcCancel.BackColor = Color.Transparent;
            this.btnUserEnterSpcCancel.BackgroundImage = (Image)Resources.Button;
            this.btnUserEnterSpcCancel.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.btnUserEnterSpcCancel.ForeColor = Color.MidnightBlue;
            this.btnUserEnterSpcCancel.Location = new Point(157, 79);
            this.btnUserEnterSpcCancel.Margin = new Padding(0);
            this.btnUserEnterSpcCancel.Name = "btnUserEnterSpcCancel";
            this.btnUserEnterSpcCancel.Size = new Size(108, 28);
            this.btnUserEnterSpcCancel.TabIndex = 5;
            this.btnUserEnterSpcCancel.Text = "BTN_CANCEL";
            this.btnUserEnterSpcCancel.UseVisualStyleBackColor = false;
            this.btnUserEnterSpcCancel.Click += new EventHandler(this.btnUserEnterSpcCancel_Click);
            this.labelUserEnterSpcMsg.AutoSize = true;
            this.labelUserEnterSpcMsg.BackColor = Color.Transparent;
            this.labelUserEnterSpcMsg.Location = new Point(19, 11);
            this.labelUserEnterSpcMsg.Margin = new Padding(4, 0, 4, 0);
            this.labelUserEnterSpcMsg.MaximumSize = new Size(303, 0);
            this.labelUserEnterSpcMsg.Name = "labelUserEnterSpcMsg";
            this.labelUserEnterSpcMsg.Size = new Size(163, 16);
            this.labelUserEnterSpcMsg.TabIndex = 6;
            this.labelUserEnterSpcMsg.Text = "USER_ENTER_SPC_MSG";
            this.textBoxUserEnterSpcValue.Location = new Point(21, 35);
            this.textBoxUserEnterSpcValue.Margin = new Padding(4, 3, 4, 3);
            this.textBoxUserEnterSpcValue.MaxLength = 6;
            this.textBoxUserEnterSpcValue.Name = "textBoxUserEnterSpcValue";
            this.textBoxUserEnterSpcValue.Size = new Size(244, 23);
            this.textBoxUserEnterSpcValue.TabIndex = 8;
            this.textBoxUserEnterSpcValue.TextChanged += new EventHandler(this.textBoxUserEnterSpcValue_TextChanged);
            this.textBoxUserEnterSpcValue.KeyPress += new KeyPressEventHandler(this.textBoxUserEnterSpcValue_KeyPress);
            this.AutoScaleDimensions = new SizeF(8f, 16f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlLightLight;
            this.BackgroundImage = (Image)Resources.BackWarning;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new Size(292, 123);
            this.ControlBox = false;
            this.Controls.Add((Control)this.textBoxUserEnterSpcValue);
            this.Controls.Add((Control)this.labelUserEnterSpcMsg);
            this.Controls.Add((Control)this.btnUserEnterSpcCancel);
            this.Controls.Add((Control)this.btnUserEnterSpcOk);
            this.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = nameof(FormUserEnterSpc);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "USER_ENTER_SPC_TITLE";
            this.Load += new EventHandler(this.FormUserEnterSpc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
