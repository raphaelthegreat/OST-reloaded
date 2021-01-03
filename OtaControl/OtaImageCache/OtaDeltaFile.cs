// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaImageCache.OtaDeltaFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.IO;

namespace OtaControl.OtaImageCache
{
    public class OtaDeltaFile : OtaFile
    {
        public override bool IsDelta => true;

        public OtaDeltaFile(string id, OtaService webService)
          : base(id, webService)
        {
        }

        public OtaDeltaFile(string id, OtaService webService, string filePath)
          : base(id, webService, filePath)
        {
        }

        public override bool Ongoing => Path.GetExtension(this.filePath).Equals(".zi_") && File.Exists(this.filePath);

        public override bool Completed => Path.GetExtension(this.filePath).Equals(".zip") && File.Exists(this.filePath);

        public override OtaFile MarkCompleted()
        {
            string destFileName = Path.ChangeExtension(this.filePath, ".zip");
            File.Move(this.filePath, destFileName);
            this.filePath = destFileName;
            return (OtaFile)this;
        }
    }
}
