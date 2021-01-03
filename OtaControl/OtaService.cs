// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaService
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Text;
using Utils;

namespace OtaControl
{
    public class OtaService
    {
        private OtaData service;
        private double timeout;

        public OtaData Service
        {
            set => this.service = value;
            get => this.service;
        }

        public OtaService() => this.service = new OtaData();

        public OtaService(string fileHandlerUrl, string loginUrl, string swImageUrl, string logUrl) => this.service = new OtaData().Set(nameof(FileHandler), fileHandlerUrl).Set(nameof(Login), loginUrl).Set(nameof(SWImage), swImageUrl).Set(nameof(Log), logUrl);

        public OtaService(OtaData service) => this.service = service;

        public OtaService(OtaService from) => this.service = new OtaData(from.service);

        public bool Enabled => !string.IsNullOrEmpty(this.FileHandler) && !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.SWImage);

        public string FileHandler => this.service.Get(nameof(FileHandler));

        public string Login => this.service.Get(nameof(Login));

        public string SWImage => this.service.Get(nameof(SWImage));

        public string Log => this.service.Get(nameof(Log));

        public double TimeoutLimit => !this.service.Contain(nameof(TimeoutLimit)) ? double.MaxValue : double.Parse(this.service.Get(nameof(TimeoutLimit)));

        public double Timeout
        {
            set => this.timeout = value;
        }

        public bool Available => this.timeout < this.TimeoutLimit;

        public override bool Equals(object obj) => obj is OtaService otaService && this.FileHandler.Equals(otaService.FileHandler) && (this.Login.Equals(otaService.Login) && this.SWImage.Equals(otaService.SWImage)) && this.Log.Equals(otaService.Log);

        public override int GetHashCode() => (int)Crc32.Compute(Encoding.ASCII.GetBytes(string.Join("", new string[4]
        {
      this.FileHandler,
      this.Login,
      this.SWImage,
      this.Log
        })));

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{ ", 1024);
            stringBuilder.Append("{ FileHandler: ").Append(this.FileHandler).Append(" }, ");
            stringBuilder.Append("{ Login: ").Append(this.Login).Append(" }, ");
            stringBuilder.Append("{ SWImage: ").Append(this.SWImage).Append(" },");
            stringBuilder.Append("{ Log: ").Append(this.Log).Append(" }");
            return stringBuilder.Append(" }").ToString();
        }
    }
}
