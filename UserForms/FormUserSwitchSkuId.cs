// Decompiled with JetBrains decompiler
// Type: UserForms.FormUserSwitchSkuId
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using MyResources.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserForms
{
    public class FormUserSwitchSkuId : Form
    {
        private IContainer components;
        private ComboBox comboBoxSelectSkuId;
        private Label labelUserModelSelectSKUId;
        private Label labelSKUIDInfomation;
        private Label labelSKUIDInformatin;
        private Button btnUserModelSelectSkuidCancel;
        private Button btnUserModelSelectSkuidOk;
        private string title;
        private string message;
        private string defaultSKUID;
        private FormUserSwitchSkuId.ButtonCaseID buttonCaseId;
        private string skuid;
        private Dictionary<string, string> skuidList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormUserSwitchSkuId));
            this.comboBoxSelectSkuId = new ComboBox();
            this.labelUserModelSelectSKUId = new Label();
            this.labelSKUIDInfomation = new Label();
            this.labelSKUIDInformatin = new Label();
            this.btnUserModelSelectSkuidCancel = new Button();
            this.btnUserModelSelectSkuidOk = new Button();
            this.SuspendLayout();
            this.comboBoxSelectSkuId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSelectSkuId.FormattingEnabled = true;
            this.comboBoxSelectSkuId.Location = new Point(24, 48);
            this.comboBoxSelectSkuId.Name = "comboBoxSelectSkuId";
            this.comboBoxSelectSkuId.Size = new Size(346, 24);
            this.comboBoxSelectSkuId.Sorted = true;
            this.comboBoxSelectSkuId.TabIndex = 0;
            this.comboBoxSelectSkuId.SelectedIndexChanged += new EventHandler(this.comboBoxSelectSkuId_SelectedIndexChanged);
            this.labelUserModelSelectSKUId.AutoSize = true;
            this.labelUserModelSelectSKUId.BackColor = Color.Transparent;
            this.labelUserModelSelectSKUId.Location = new Point(22, 22);
            this.labelUserModelSelectSKUId.Name = "labelUserModelSelectSKUId";
            this.labelUserModelSelectSKUId.Size = new Size(201, 16);
            this.labelUserModelSelectSKUId.TabIndex = 2;
            this.labelUserModelSelectSKUId.Text = "USER_MODEL_SELECT_SKUID";
            this.labelSKUIDInfomation.AutoSize = true;
            this.labelSKUIDInfomation.BackColor = Color.Transparent;
            this.labelSKUIDInfomation.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelSKUIDInfomation.ForeColor = Color.Blue;
            this.labelSKUIDInfomation.Location = new Point(22, 106);
            this.labelSKUIDInfomation.Name = "labelSKUIDInfomation";
            this.labelSKUIDInfomation.Size = new Size(110, 16);
            this.labelSKUIDInfomation.TabIndex = 4;
            this.labelSKUIDInfomation.Text = "INFORAMTION";
            this.labelSKUIDInformatin.AutoSize = true;
            this.labelSKUIDInformatin.BackColor = Color.Transparent;
            this.labelSKUIDInformatin.Location = new Point(22, 82);
            this.labelSKUIDInformatin.Name = "labelSKUIDInformatin";
            this.labelSKUIDInformatin.Size = new Size(191, 16);
            this.labelSKUIDInformatin.TabIndex = 6;
            this.labelSKUIDInformatin.Text = "USER_SKUID_INFORMATION";
            this.btnUserModelSelectSkuidCancel.Location = new Point(217, 207);
            this.btnUserModelSelectSkuidCancel.Name = "btnUserModelSelectSkuidCancel";
            this.btnUserModelSelectSkuidCancel.Size = new Size(80, 30);
            this.btnUserModelSelectSkuidCancel.TabIndex = 3;
            this.btnUserModelSelectSkuidCancel.Text = "BTN_CANCEL";
            this.btnUserModelSelectSkuidCancel.UseVisualStyleBackColor = true;
            this.btnUserModelSelectSkuidCancel.Click += new EventHandler(this.btnUserModelSelectSkuidCancel_Click);
            this.btnUserModelSelectSkuidOk.Location = new Point(60, 207);
            this.btnUserModelSelectSkuidOk.Name = "btnUserModelSelectSkuidOk";
            this.btnUserModelSelectSkuidOk.Size = new Size(80, 30);
            this.btnUserModelSelectSkuidOk.TabIndex = 1;
            this.btnUserModelSelectSkuidOk.Text = "BTN_OK";
            this.btnUserModelSelectSkuidOk.UseVisualStyleBackColor = true;
            this.btnUserModelSelectSkuidOk.Click += new EventHandler(this.btnUserModelSelectSkuidOk_Click);
            this.AutoScaleDimensions = new SizeF(8f, 16f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlLightLight;
            this.BackgroundImage = (Image)Resources.BackWarning;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new Size(384, 261);
            this.ControlBox = false;
            this.Controls.Add((Control)this.labelSKUIDInformatin);
            this.Controls.Add((Control)this.labelSKUIDInfomation);
            this.Controls.Add((Control)this.btnUserModelSelectSkuidCancel);
            this.Controls.Add((Control)this.labelUserModelSelectSKUId);
            this.Controls.Add((Control)this.btnUserModelSelectSkuidOk);
            this.Controls.Add((Control)this.comboBoxSelectSkuId);
            this.Font = new Font("Verdana", 9.75f);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(4);
            this.Name = nameof(FormUserSwitchSkuId);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "USER_SELECT_SKUID_TITLE";
            this.Load += new EventHandler(this.FormUserSwitchSkuId_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public string Title
        {
            set => this.title = value;
            get => this.title;
        }

        public string Message
        {
            set => this.message = value;
        }

        public string DefaultSKUID
        {
            set => this.defaultSKUID = value;
        }

        public FormUserSwitchSkuId.ButtonCaseID ButtonCaseId
        {
            set => this.buttonCaseId = value;
        }

        public string SkuId
        {
            get => this.skuid;
            set => this.skuid = value;
        }

        public FormUserSwitchSkuId()
        {
            this.InitializeComponent();
            this.skuidList = new Dictionary<string, string>();
        }

        private void FormUserSwitchSkuId_Load(object sender, EventArgs e) => this.ReloadDefaultTexts();

        private void ReloadDefaultTexts()
        {
            this.Text = this.title;
            bool flag = this.message.Trim().Contains("(");
            this.labelUserModelSelectSKUId.Text = Locale.Instance.LoadCombinedText("USER_SELECT_SKUID");
            this.labelSKUIDInformatin.Text = flag ? Locale.Instance.LoadCombinedText("USER_SKUID_INFORMATION") : string.Empty;
            string[] strArray1 = this.message.Trim().Split(new char[1]
            {
        ';'
            }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < strArray1.Length; ++index)
            {
                if (flag)
                {
                    string[] strArray2 = strArray1[index].Trim().Split(new char[2]
                    {
            '(',
            ')'
                    }, StringSplitOptions.RemoveEmptyEntries);
                    this.skuidList.Add(strArray2[0].Trim(), strArray2[1].Trim());
                    this.comboBoxSelectSkuId.Items.Add((object)strArray2[0].Trim());
                }
                else
                {
                    this.skuidList.Add(strArray1[index].Trim(), string.Empty);
                    this.comboBoxSelectSkuId.Items.Add((object)strArray1[index].Trim());
                }
            }
            int num = this.comboBoxSelectSkuId.Items.IndexOf((object)this.defaultSKUID);
            this.comboBoxSelectSkuId.SelectedIndex = num == -1 ? 0 : num;
            if (flag)
                this.labelSKUIDInfomation.Text = num == -1 ? this.skuidList[this.comboBoxSelectSkuId.Text].Replace('&', '\n') : this.skuidList[this.defaultSKUID].Replace('&', '\n');
            else
                this.labelSKUIDInfomation.Text = string.Empty;
            this.btnUserModelSelectSkuidOk.Text = Locale.Instance.LoadCombinedText(this.btnUserModelSelectSkuidOk.Text);
            this.btnUserModelSelectSkuidCancel.Text = Locale.Instance.LoadCombinedText(this.btnUserModelSelectSkuidCancel.Text);
        }

        private void btnUserModelSelectSkuidOk_Click(object sender, EventArgs e)
        {
            this.skuid = this.comboBoxSelectSkuId.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUserModelSelectSkuidCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxSelectSkuId_SelectedIndexChanged(object sender, EventArgs e) => this.labelSKUIDInfomation.Text = this.skuidList[this.comboBoxSelectSkuId.Text].Replace('&', '\n');

        public enum ButtonCaseID
        {
            OK = 1,
            OK_CANCEL = 2,
            OK_IGNORE = 3,
        }
    }
}
