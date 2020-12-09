// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaItemList
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;
using System.Text;

namespace OtaControl
{
  public class OtaItemList
  {
    private List<OtaItem> instance;

    public List<OtaItem> Instance => this.instance;

    public bool Empty => this.instance.Count == 0;

    public OtaItemList() => this.instance = new List<OtaItem>();

    public OtaItemList Add(OtaService webService, List<OtaData> datas)
    {
      foreach (OtaData data in datas)
      {
        OtaItem otaItem = new OtaItem(data, webService);
        if (this.instance.Contains(otaItem))
          this.instance[this.instance.IndexOf(otaItem)].AddItemData(new OtaItemData(data, webService));
        else
          this.instance.Add(otaItem);
      }
      this.instance.Sort(new Comparison<OtaItem>(this.CompareByFihVersion));
      return this;
    }

    public OtaItemList Replace(OtaItemList itemList)
    {
      foreach (OtaItem otaItem in itemList.Instance)
      {
        if (this.instance.Contains(otaItem))
          this.instance[this.instance.IndexOf(otaItem)] = otaItem;
        else
          this.instance.Add(otaItem);
      }
      this.instance.Sort(new Comparison<OtaItem>(this.CompareByFihVersion));
      return this;
    }

    public OtaItemList Replace(OtaItem item)
    {
      if (this.instance.Contains(item))
        this.instance[this.instance.IndexOf(item)] = item;
      else
        this.instance.Add(item);
      this.instance.Sort(new Comparison<OtaItem>(this.CompareByFihVersion));
      return this;
    }

    private int CompareByFihVersion(OtaItem x, OtaItem y)
    {
      if (x.Version.CompareTo(y.Version) > 0)
        return -1;
      if (x.Version.CompareTo(y.Version) < 0 || x.ImageID.CompareTo(y.ImageID) > 0)
        return 1;
      if (x.ImageID.CompareTo(y.ImageID) < 0 || x.SubVersion.CompareTo(y.SubVersion) > 0)
        return -1;
      return x.SubVersion.CompareTo(y.SubVersion) < 0 ? 1 : 0;
    }

    public OtaItemList ReserveLastestVersion(OtaItem phone)
    {
      this.instance.RemoveAll((Predicate<OtaItem>) (image =>
      {
        OtaItem otaItem1 = this.LatestVersionOf(image.ImageID);
        if (otaItem1 != null && otaItem1.Equals((object) image))
          return false;
        OtaItem otaItem2 = this.LatestBranchVersionOf(phone.BranchVersion, image.ImageID);
        return otaItem2 == null || !otaItem2.Equals((object) image);
      }));
      return this;
    }

    public OtaItemList RemoveAll(Predicate<OtaItem> match)
    {
      this.instance.RemoveAll(match);
      return this;
    }

    public OtaItemList UpdateDisplayVersions()
    {
      this.instance.ForEach((Action<OtaItem>) (item => item.ShowSubVersion = this.instance.Exists((Predicate<OtaItem>) (_item => _item.Version.Equals(item.Version) && !_item.SubVersion.Equals(item.SubVersion)))));
      return this;
    }

    public OtaItem FindLatestVersionOf(OtaItem phone) => phone.IsBranchVersion ? this.LatestBranchVersionOf(phone.BranchVersion, phone.ImageID) : this.LatestVersionOf(phone.ImageID);

    private OtaItem LatestVersionOf(string imageId)
    {
      OtaItem otaItem1 = (OtaItem) null;
      foreach (OtaItem otaItem2 in this.instance)
      {
        if (otaItem2.ImageID.Equals(imageId) && (otaItem1 == null || otaItem1.FullVersion.CompareTo(otaItem2.FullVersion) < 0))
          otaItem1 = otaItem2;
      }
      return otaItem1;
    }

    private OtaItem LatestBranchVersionOf(string branchVersion, string imageId)
    {
      OtaItem otaItem1 = (OtaItem) null;
      foreach (OtaItem otaItem2 in this.instance)
      {
        if (otaItem2.ImageID.Equals(imageId) && otaItem2.IsBranchVersion && otaItem2.BranchVersion.Equals(branchVersion) && (otaItem1 == null || otaItem1.FullVersion.CompareTo(otaItem2.FullVersion) < 0))
          otaItem1 = otaItem2;
      }
      return otaItem1;
    }

    public string ToLogString()
    {
      int num = 0;
      StringBuilder stringBuilder = new StringBuilder("{ ", 2048);
      foreach (OtaService webService in this.GetWebServices())
      {
        string fihVersions = this.ToFihVersions(webService);
        if (!string.IsNullOrEmpty(fihVersions))
        {
          if (num++ > 0)
            stringBuilder.Append("; ");
          stringBuilder.Append(new Uri(webService.FileHandler).Host).Append(": ");
          stringBuilder.Append(fihVersions);
        }
      }
      return stringBuilder.Append(" }").ToString();
    }

    private List<OtaService> GetWebServices()
    {
      List<OtaService> otaServiceList = new List<OtaService>();
      foreach (OtaItem otaItem in this.instance)
      {
        foreach (OtaItemData itemData in otaItem.ItemDatas)
        {
          if (!otaServiceList.Contains(itemData.WebService))
            otaServiceList.Add(itemData.WebService);
        }
      }
      return otaServiceList;
    }

    private string ToFihVersions(OtaService webService)
    {
      int num = 0;
      StringBuilder stringBuilder = new StringBuilder(1024);
      foreach (OtaItem otaItem in this.instance)
      {
        foreach (OtaItemData itemData in otaItem.ItemDatas)
        {
          if (itemData.WebService.Equals((object) webService))
          {
            if (num++ > 0)
              stringBuilder.Append(", ");
            stringBuilder.Append(otaItem.FihVersion);
            if (itemData.IsDelta)
              stringBuilder.Append(" (Delta)");
          }
        }
      }
      return stringBuilder.ToString();
    }
  }
}
