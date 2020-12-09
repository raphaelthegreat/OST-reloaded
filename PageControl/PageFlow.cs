// Decompiled with JetBrains decompiler
// Type: PageControl.PageFlow
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Collections.Generic;
using System.Windows.Forms;

namespace PageControl
{
  internal class PageFlow
  {
    private List<TabPage> tabPageList;

    public PageFlow(TabPage[] tabPages)
    {
      this.tabPageList = new List<TabPage>(tabPages.Length);
      foreach (TabPage tabPage in tabPages)
        this.tabPageList.Add(tabPage);
    }

    public TabPage NextPageOf(TabPage tabPage)
    {
      int num = this.tabPageList.IndexOf(tabPage);
      return num != -1 && num != this.tabPageList.Count - 1 ? this.tabPageList[num + 1] : tabPage;
    }

    public TabPage PrevPageOf(TabPage tabPage)
    {
      int num = this.tabPageList.IndexOf(tabPage);
      switch (num)
      {
        case -1:
        case 0:
          return tabPage;
        default:
          return this.tabPageList[num - 1];
      }
    }

    public TabPage FirstPage => this.tabPageList[0];

    public TabPage FinalPage => this.tabPageList[this.tabPageList.Count - 1];

    public List<TabPage> Pages => this.tabPageList;
  }
}
