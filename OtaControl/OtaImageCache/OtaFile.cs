// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaImageCache.OtaFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.IO;
using System.Text;
using Utils;

namespace OtaControl.OtaImageCache
{
    public abstract class OtaFile
    {
        protected string id;
        protected OtaService webService;
        protected string filePath;
        protected Progress progress;

        public string ID => this.id;

        public abstract bool IsDelta { get; }

        public OtaService WebService => this.webService;

        public string FilePath => this.filePath;

        protected OtaFile()
        {
            this.id = string.Empty;
            this.webService = (OtaService)null;
            this.filePath = string.Empty;
        }

        protected OtaFile(string id, OtaService webService)
        {
            this.id = id;
            this.webService = webService;
            this.filePath = string.Empty;
        }

        protected OtaFile(string id, OtaService webService, string filePath)
        {
            this.id = id;
            this.webService = webService;
            this.filePath = filePath;
        }

        public static OtaFile LoadFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            if (extension.StartsWith(".nb") || extension.StartsWith(".zi"))
            {
                string[] strArray = Path.GetFileNameWithoutExtension(filePath).Split('_');
                if (strArray.Length == 2)
                {
                    OtaService webService = OtaCacheConfig.Instance.GetWebService(int.Parse(strArray[0]));
                    if (webService != null)
                        return OtaFile.NewOtaFile(strArray[1], webService, filePath);
                }
            }
            return (OtaFile)null;
        }

        public static OtaFile CreateFile(
          string id,
          bool isDelta,
          OtaService webService,
          string folder)
        {
            int num = OtaCacheConfig.Instance.SetWebService(webService);
            return OtaFile.NewOtaFile(id, webService, Path.Combine(folder, string.Format("{0}_{1}{2}", (object)num, (object)id, isDelta ? (object)".zi_" : (object)".nb_")));
        }

        private static OtaFile NewOtaFile(string id, OtaService webService, string filePath) => Path.GetExtension(filePath).StartsWith(".nb") ? (OtaFile)new OtaNb0File(id, webService, filePath) : (OtaFile)new OtaDeltaFile(id, webService, filePath);

        public static OtaFile NewOtaFile(string id, bool isDelta, OtaService webService) => !isDelta ? (OtaFile)new OtaNb0File(id, webService) : (OtaFile)new OtaDeltaFile(id, webService);

        public static int CompareByModifiedDate(OtaFile x, OtaFile y) => new FileInfo(x.filePath).LastWriteTime.CompareTo(new FileInfo(y.filePath).LastWriteTime);

        public OtaFile SetProgress(Progress progress)
        {
            this.progress = progress;
            return this;
        }

        public abstract bool Ongoing { get; }

        public abstract bool Completed { get; }

        public abstract OtaFile MarkCompleted();

        public override bool Equals(object obj) => obj is OtaFile otaFile && this.ID.Equals(otaFile.ID) && this.WebService.Equals((object)otaFile.WebService);

        public override int GetHashCode() => int.Parse(this.id) + this.webService.GetHashCode();

        public virtual string ToLogString()
        {
            StringBuilder stringBuilder = new StringBuilder("{ ", 2048);
            stringBuilder.Append(this.id).Append(" ");
            if (this.IsDelta)
                stringBuilder.Append("Detla ");
            stringBuilder.Append(new Uri(this.webService.FileHandler).Host).Append(" ");
            return stringBuilder.Append("}").ToString();
        }
    }
}
