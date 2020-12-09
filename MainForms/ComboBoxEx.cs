// Decompiled with JetBrains decompiler
// Type: MainForms.ComboBoxEx
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainForms
{
  internal class ComboBoxEx : ComboBox
  {
    private CheckedListBox mCheckedListBox;
    private Dictionary<ProductOptions, string> mDownLoadOption;
    private bool mMutilpeSelect;

    public CheckedListBox CheckedListBoxItem => this.mCheckedListBox;

    public event ItemCheckEventHandler ItemCheck;

    public ComboBoxEx()
    {
      this.mCheckedListBox = new CheckedListBox();
      this.mDownLoadOption = new Dictionary<ProductOptions, string>();
    }

    public bool IsContainDownloadOption => this.mDownLoadOption.Count != 0 && (this.HasOption(ProductOptions.NONE) || this.HasOption(ProductOptions.NATIVE_UPDATE_PROCESS) || (this.HasOption(ProductOptions.BACKUP_SETTINGS) || this.HasOption(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS)));

    public void SetCheckedListItems(List<string> items)
    {
      this.MaxDropDownItems = items.Count;
      this.ClearCheckedListItems();
      this.mCheckedListBox.Items.AddRange((object[]) items.ToArray());
    }

    public void ClearCheckedListItems()
    {
      this.mCheckedListBox.Items.Clear();
      this.mDownLoadOption.Clear();
      this.mCheckedListBox.Visible = false;
    }

    public bool IsMutilpeSelect
    {
      get => this.mMutilpeSelect;
      set
      {
        this.mMutilpeSelect = value;
        if (this.mMutilpeSelect)
        {
          this.DrawMode = DrawMode.OwnerDrawFixed;
          this.IntegralHeight = false;
          this.DoubleBuffered = true;
          this.DroppedDown = false;
          this.DropDownHeight = 1;
          this.DropDownStyle = ComboBoxStyle.DropDown;
          this.mCheckedListBox.CheckOnClick = true;
          this.mCheckedListBox.ItemCheck += new ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
          this.ItemCheck += new ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
          this.TextChanged += new EventHandler(this.CheckedListBox_TextChanged);
          this.mCheckedListBox.BorderStyle = BorderStyle.Fixed3D;
          this.mCheckedListBox.Visible = false;
        }
        else
        {
          this.DrawMode = DrawMode.Normal;
          this.IntegralHeight = true;
          this.DoubleBuffered = true;
          this.DroppedDown = true;
          this.DropDownHeight = 106;
        }
      }
    }

    private void CheckedListBox_TextChanged(object sender, EventArgs e) => this.Text = this.SelectedDownloadOptionText.ToString();

    private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      ProductOptions option = this.GetOption(this.CheckedListBoxItem.Items[e.Index].ToString());
      if (e.NewValue == CheckState.Checked)
      {
        if (this.mDownLoadOption.ContainsKey(option))
          this.mDownLoadOption.Remove(option);
        this.mDownLoadOption.Add(option, this.GetOptionText(option));
        this.ReCheckSelectItems(option);
      }
      else if (e.NewValue == CheckState.Unchecked)
      {
        if (option == ProductOptions.ERASE_USER_DATA && this.IsAlwaysCheckedEraseUserData())
          e.NewValue = CheckState.Checked;
        else if (this.mDownLoadOption.ContainsKey(option))
          this.mDownLoadOption.Remove(option);
      }
      this.Text = this.SelectedDownloadOptionText.ToString();
    }

    public void EnableDefaultItem()
    {
      int optionIndex1 = this.GetOptionIndex(ProductOptions.COLLECT_APR_LOG);
      if (optionIndex1 != -1)
        this.mCheckedListBox.SetItemCheckState(optionIndex1, CheckState.Checked);
      int optionIndex2 = this.GetOptionIndex(ProductOptions.SWITCH_CUSTOMER_SKUID);
      if (optionIndex2 != -1)
        this.mCheckedListBox.SetItemCheckState(optionIndex2, CheckState.Checked);
      if (this.IsOption(ProductOptions.NONE))
      {
        this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NONE), CheckState.Checked);
      }
      else
      {
        if (!this.IsOption(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS))
          return;
        this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS), CheckState.Checked);
      }
    }

    public int GetSelectedOptionValue()
    {
      int num = 0;
      foreach (KeyValuePair<ProductOptions, string> keyValuePair in this.mDownLoadOption)
        num |= 1 << (int) (keyValuePair.Key & (ProductOptions) 31);
      return num;
    }

    public bool HasOption(ProductOptions option) => this.mDownLoadOption.ContainsKey(option);

    private ProductOptions GetOption(string text) => this.GetOptionValue(text);

    private bool IsOption(ProductOptions option) => this.mCheckedListBox.Items.Contains((object) this.GetOptionText(option));

    private void ReCheckSelectItems(ProductOptions option)
    {
      switch (option)
      {
        case ProductOptions.NONE:
          if (this.IsOption(ProductOptions.NATIVE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.BACKUP_SETTINGS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.BACKUP_SETTINGS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS), CheckState.Unchecked);
          if (!this.IsOption(ProductOptions.UFS_PROVISION))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.UFS_PROVISION), CheckState.Unchecked);
          break;
        case ProductOptions.NATIVE_UPDATE_PROCESS:
          if (this.IsOption(ProductOptions.NONE))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NONE), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.BACKUP_SETTINGS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.BACKUP_SETTINGS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.COLLECT_APR_LOG))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.COLLECT_APR_LOG), CheckState.Unchecked);
          if (!this.IsOption(ProductOptions.ERASE_USER_DATA))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_USER_DATA), CheckState.Checked);
          break;
        case ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS:
          if (this.IsOption(ProductOptions.NONE))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NONE), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.BACKUP_SETTINGS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.BACKUP_SETTINGS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_ERASE_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.COLLECT_APR_LOG))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.COLLECT_APR_LOG), CheckState.Unchecked);
          if (!this.IsOption(ProductOptions.ERASE_USER_DATA))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_USER_DATA), CheckState.Checked);
          break;
        case ProductOptions.SWITCH_CUSTOMER_SKUID:
          if (!this.IsOption(ProductOptions.BACKUP_SETTINGS))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.BACKUP_SETTINGS), CheckState.Unchecked);
          break;
        case ProductOptions.BACKUP_SETTINGS:
          if (this.IsOption(ProductOptions.NONE))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NONE), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.NATIVE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.ERASE_BOX_DATA))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_BOX_DATA), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.SWITCH_CUSTOMER_SKUID))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.SWITCH_CUSTOMER_SKUID), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.ERASE_FRP))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_FRP), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.UFS_PROVISION))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.UFS_PROVISION), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.UNLOCK_SCREEN_LOCK))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.UNLOCK_SCREEN_LOCK), CheckState.Unchecked);
          if (this.IsOption(ProductOptions.COLLECT_APR_LOG))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.COLLECT_APR_LOG), CheckState.Unchecked);
          if (!this.IsOption(ProductOptions.ERASE_USER_DATA))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_USER_DATA), CheckState.Unchecked);
          break;
        case ProductOptions.NATIVE_ERASE_UPDATE_PROCESS:
          if (this.IsOption(ProductOptions.NATIVE_UPDATE_PROCESS))
            this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS), CheckState.Unchecked);
          if (!this.IsOption(ProductOptions.COLLECT_APR_LOG))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.COLLECT_APR_LOG), CheckState.Unchecked);
          break;
        case ProductOptions.ERASE_FRP:
        case ProductOptions.UNLOCK_SCREEN_LOCK:
          if (!this.IsOption(ProductOptions.ERASE_USER_DATA))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.ERASE_USER_DATA), CheckState.Checked);
          break;
        case ProductOptions.UFS_PROVISION:
          if (!this.IsOption(ProductOptions.NONE))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.NONE), CheckState.Unchecked);
          break;
        default:
          if (!this.IsOption(ProductOptions.BACKUP_SETTINGS))
            break;
          this.mCheckedListBox.SetItemCheckState(this.GetOptionIndex(ProductOptions.BACKUP_SETTINGS), CheckState.Unchecked);
          break;
      }
    }

    private bool IsAlwaysCheckedEraseUserData() => this.IsOption(ProductOptions.NATIVE_UPDATE_PROCESS) && this.mCheckedListBox.GetItemChecked(this.GetOptionIndex(ProductOptions.NATIVE_UPDATE_PROCESS)) || this.IsOption(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS) && this.mCheckedListBox.GetItemChecked(this.GetOptionIndex(ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS));

    private int GetOptionIndex(ProductOptions option) => this.CheckedListBoxItem.Items.IndexOf((object) this.GetOptionText(option));

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

    public string SelectedDownloadOptionText
    {
      get
      {
        if (!this.IsMutilpeSelect)
          return "";
        string str = "";
        List<KeyValuePair<ProductOptions, string>> keyValuePairList = new List<KeyValuePair<ProductOptions, string>>((IEnumerable<KeyValuePair<ProductOptions, string>>) this.mDownLoadOption);
        keyValuePairList.Sort((Comparison<KeyValuePair<ProductOptions, string>>) ((s1, s2) => ((int) s1.Key).CompareTo((int) s2.Key)));
        foreach (KeyValuePair<ProductOptions, string> keyValuePair in keyValuePairList)
          str = str + keyValuePair.Value.ToString() + ";";
        return str.TrimEnd(';');
      }
    }

    public ListBox.SelectedObjectCollection SelectedItems => this.mCheckedListBox.SelectedItems;

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.IsMutilpeSelect)
        return;
      this.DroppedDown = false;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (!this.IsMutilpeSelect)
        return;
      this.DroppedDown = false;
      this.mCheckedListBox.Focus();
    }

    protected override void OnDropDown(EventArgs e)
    {
      if (!this.IsMutilpeSelect)
        return;
      this.mCheckedListBox.Visible = !this.mCheckedListBox.Visible;
      this.mCheckedListBox.ItemHeight = this.ItemHeight;
      this.mCheckedListBox.BorderStyle = BorderStyle.FixedSingle;
      this.mCheckedListBox.Size = new Size(this.DropDownWidth, this.ItemHeight * (this.MaxDropDownItems + 1));
      this.mCheckedListBox.Location = new Point(this.Left, this.Top + this.ItemHeight + 6);
      this.mCheckedListBox.BeginUpdate();
      this.mCheckedListBox.EndUpdate();
      if (this.Parent.Controls.Contains((Control) this.mCheckedListBox))
        return;
      this.Parent.Controls.Add((Control) this.mCheckedListBox);
      this.mCheckedListBox.BringToFront();
    }
  }
}
