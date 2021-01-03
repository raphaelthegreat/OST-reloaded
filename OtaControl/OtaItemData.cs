// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaItemData
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Text;
using Utils;

namespace OtaControl
{
    public class OtaItemData
    {
        private OtaData data;
        private OtaService webService;

        public OtaData Data => this.data;

        public OtaService WebService => this.webService;

        public OtaItemData(OtaData data, OtaService service)
        {
            this.data = this.ToItemData(data);
            this.webService = service;
        }

        public OtaItemData(OtaItemData from)
        {
            this.data = new OtaData(from.data);
            this.webService = new OtaService(from.webService);
        }

        private OtaData ToItemData(OtaData from) => from.SubData(new string[5]
        {
      "ID",
      "Official",
      "Service",
      "MP",
      "Delta"
        });

        public string ID => this.data.Get(nameof(ID));

        public string Official => this.data.Get(nameof(Official));

        public string Service => this.data.Get(nameof(Service));

        public string MP => this.data.Get(nameof(MP));

        public bool IsDelta => this.data.Get("Delta").Equals("True");

        public override bool Equals(object obj) => obj is OtaItemData otaItemData && this.ID.Equals(otaItemData.ID) && this.webService.Equals((object)otaItemData.webService) && this.IsDelta.Equals(otaItemData.IsDelta);

        public override int GetHashCode() => (int)Crc32.Compute(Encoding.ASCII.GetBytes(string.Join("", new string[3]
        {
      this.ID,
      this.webService.ToString(),
      this.IsDelta.ToString()
        })));
    }
}
