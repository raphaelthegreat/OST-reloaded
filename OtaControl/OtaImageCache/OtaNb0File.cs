// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaImageCache.OtaNb0File
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.IO;
using Utils;

namespace OtaControl.OtaImageCache
{
    internal class OtaNb0File : OtaFile
    {
        public override bool IsDelta => false;

        public OtaNb0File(string filePath) => this.filePath = filePath;

        public OtaNb0File(string id, OtaService webService)
          : base(id, webService)
        {
        }

        public OtaNb0File(string id, OtaService webService, string filePath)
          : base(id, webService, filePath)
        {
        }

        public override bool Ongoing => Path.GetExtension(this.filePath).Equals(".nb_") && File.Exists(this.filePath);

        public override bool Completed => Path.GetExtension(this.filePath).Equals(".nb0") && File.Exists(this.filePath);

        public override OtaFile MarkCompleted()
        {
            string str = Path.ChangeExtension(this.filePath, ".swp");
            string destFileName = Path.ChangeExtension(this.filePath, ".nb0");
            ZipUtil.UnZipFile(this.filePath, 0, str, this.progress);
            File.Delete(this.filePath);
            File.Move(str, destFileName);
            this.filePath = destFileName;
            return (OtaFile)this;
        }
    }
}
