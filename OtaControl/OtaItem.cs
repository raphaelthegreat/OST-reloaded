// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaItem
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace OtaControl
{
    public class OtaItem
    {
        protected OtaData item;
        protected List<OtaItemData> itemDatas;
        private bool showSubVersion;

        public OtaData Item => this.item;

        public List<OtaItemData> ItemDatas => this.itemDatas;

        public bool ShowSubVersion
        {
            set => this.showSubVersion = value;
        }

        public bool Valid => this.item.Instance.Count > 0;

        public OtaItem(OtaData item)
        {
            this.item = this.ToItem(item);
            this.itemDatas = new List<OtaItemData>();
        }

        public OtaItem(OtaData item, OtaService service)
        {
            this.item = this.ToItem(item);
            this.itemDatas = new List<OtaItemData>();
            this.AddItemData(new OtaItemData(item, service));
        }

        public OtaItem(OtaItem from)
        {
            this.item = new OtaData(from.item);
            this.itemDatas = new List<OtaItemData>((IEnumerable<OtaItemData>)from.itemDatas);
        }

        private OtaData ToItem(OtaData from) => from.SubData(new string[12]
        {
      "OtaNb0Update",
      "OtaDeltaUpdate",
      "Platform",
      "ImageID",
      "Version",
      "SubVersion",
      "ChannelID",
      "OperatorID",
      "InternalModel",
      "ExternalModel",
      "ExternalVersion",
      "CDAVersion"
        });

        public OtaItem AddItemData(OtaItemData itemData)
        {
            if (!this.itemDatas.Contains(itemData) && itemData.WebService.Enabled)
                this.itemDatas.Add(itemData);
            return this;
        }

        public OtaItem RemoveDetlaImages()
        {
            this.itemDatas.RemoveAll((Predicate<OtaItemData>)(data => data.IsDelta));
            return this;
        }

        public bool DeltaImageExists => this.itemDatas.Exists((Predicate<OtaItemData>)(data => data.IsDelta));

        public bool Nb0UpdateAvailable => this.item.Get("OtaNb0Update").Equals("True");

        public bool DeltaUpdateAvailable => this.item.Get("OtaDeltaUpdate").Equals("True");

        public bool OtaUpdateAvailable => this.Nb0UpdateAvailable || this.DeltaUpdateAvailable;

        public string Platform => this.item.Get(nameof(Platform));

        public string ImageID => this.item.Get(nameof(ImageID));

        public string Version => this.item.Get(nameof(Version));

        public string SubVersion => this.item.Get(nameof(SubVersion));

        public string ChannelID => this.item.Get(nameof(ChannelID));

        public string OperatorID => this.item.Get(nameof(OperatorID));

        public string InternalModel => this.item.Get(nameof(InternalModel));

        public string ExternalModel => this.item.Get(nameof(ExternalModel));

        public string ExternalVersion => this.item.Get(nameof(ExternalVersion));

        public string CDAVersion => this.item.Get(nameof(CDAVersion));

        public bool IsMainVersion => !string.IsNullOrEmpty(this.Version) && !this.IsBranchVersion;

        public string BranchVersion => this.Version.Substring(0, this.Version.Length - 1);

        public bool IsBranchVersion => !string.IsNullOrEmpty(this.Version) && new Regex("[A-Za-z]").IsMatch(this.Version.Substring(this.Version.Length - 1));

        public string FullVersion => string.Format("{0}_{1}", (object)this.Version, (object)this.SubVersion);

        public string DisplayModel => !this.item.Contain("ExternalModel") ? this.InternalModel : this.item.Get("ExternalModel");

        public string DisplayVersion => this.item.Contain("ExternalVersion") ? this.AppendSubVersion(this.item.Get("ExternalVersion")) : this.FihVersion;

        public virtual string FihModel => this.item.Get("InternalModel");

        public virtual string FihVersion => this.item.Contain("Version") && this.item.Contain("ImageID") ? this.AppendSubVersion(string.Format("{0}_{1}_{2}", (object)this.item.Get("ImageID"), (object)this.item.Get("Version").Substring(0, 1), (object)this.item.Get("Version").Substring(1))) : string.Empty;

        protected virtual string AppendSubVersion(string version) => this.showSubVersion && this.item.Contain("SubVersion") ? string.Format("{0} ({1})", (object)version, (object)this.item.Get("SubVersion")) : version;

        public override bool Equals(object obj) => obj is OtaItem otaItem && this.Platform.Equals(otaItem.Platform) && (this.ImageID.Equals(otaItem.ImageID) && this.Version.Equals(otaItem.Version)) && (this.SubVersion.Equals(otaItem.SubVersion) && this.ChannelID.Equals(otaItem.ChannelID) && (this.OperatorID.Equals(otaItem.OperatorID) && this.InternalModel.Equals(otaItem.InternalModel))) && (this.ExternalModel.Equals(otaItem.ExternalModel) && this.ExternalVersion.Equals(otaItem.ExternalVersion));

        public override int GetHashCode() => (int)Crc32.Compute(Encoding.ASCII.GetBytes(string.Join("", new string[9]
        {
      this.Platform,
      this.ImageID,
      this.Version,
      this.SubVersion,
      this.ChannelID,
      this.OperatorID,
      this.InternalModel,
      this.ExternalModel,
      this.ExternalVersion
        })));

        public override string ToString() => string.IsNullOrEmpty(this.DisplayVersion) ? Locale.Instance.LoadText("ONLINE_STATUS_UNKNOWN") : this.DisplayVersion;

        public virtual string ToLogString()
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder("{ ", 2048);
            stringBuilder.Append(this.FihVersion).Append(": ");
            foreach (OtaItemData itemData in this.itemDatas)
            {
                if (num++ > 0)
                    stringBuilder.Append("; ");
                stringBuilder.Append(itemData.ID).Append(" ");
                if (itemData.IsDelta)
                    stringBuilder.Append("Detla ");
                stringBuilder.Append(new Uri(itemData.WebService.FileHandler).Host);
            }
            return stringBuilder.Append(" }").ToString();
        }
    }
}
