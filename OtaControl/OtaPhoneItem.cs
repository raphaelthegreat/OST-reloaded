// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaPhoneItem
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Text;

namespace OtaControl
{
    public class OtaPhoneItem : OtaItem
    {
        private OtaData information;

        public OtaData FullItem => OtaData.Combine(this.item, this.information);

        public long StorageSize => long.Parse(this.information.Get(nameof(StorageSize)));

        public long RootStatus => long.Parse(this.information.Get(nameof(RootStatus)));

        public bool IsRootStatus => (this.RootStatus & 100L) != 0L;

        public OtaPhoneItem(OtaData item)
          : base(item)
          => this.information = this.ToInformation(item);

        private OtaData ToInformation(OtaData from) => from.SubData(new string[7]
        {
      "DeviceID",
      "SerialNumber",
      "MCC",
      "MNC",
      "SKUID",
      "StorageSize",
      "RootStatus"
        });

        public string DeviceID => !this.information.Contain(nameof(DeviceID)) ? this.information.Get("SerialNumber") : this.information.Get(nameof(DeviceID));

        public string MccMnc => !this.information.Contain("MCC") || !this.information.Contain("MNC") ? string.Empty : this.information.Get("MCC") + this.information.Get("MNC");

        public string SKUID => this.information.Get(nameof(SKUID));

        public override string ToLogString()
        {
            StringBuilder stringBuilder = new StringBuilder("{ ", 1024);
            if (!string.IsNullOrEmpty(this.FihModel))
                stringBuilder.Append("{ Modle: ").Append(this.FihModel).Append(" }, ");
            if (!string.IsNullOrEmpty(this.FihVersion))
                stringBuilder.Append("{ Version: ").Append(this.FihVersion).Append(" }, ");
            if (!string.IsNullOrEmpty(this.SubVersion))
                stringBuilder.Append("{ SubVersion: ").Append(this.SubVersion).Append(" }, ");
            if (!string.IsNullOrEmpty(this.CDAVersion))
                stringBuilder.Append("{ CDAVersion: ").Append(this.CDAVersion).Append(" }, ");
            if (!string.IsNullOrEmpty(this.DeviceID))
                stringBuilder.Append("{ DeviceID: ").Append(this.DeviceID).Append(" }, ");
            if (!string.IsNullOrEmpty(this.MccMnc))
                stringBuilder.Append("{ Operator: ").Append(this.MccMnc).Append(" }, ");
            if (!string.IsNullOrEmpty(this.SKUID))
                stringBuilder.Append("{ SKUID: ").Append(this.SKUID).Append(" } ");
            return stringBuilder.Append("}").ToString();
        }
    }
}
