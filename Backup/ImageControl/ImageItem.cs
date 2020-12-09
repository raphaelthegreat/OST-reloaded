// Decompiled with JetBrains decompiler
// Type: ImageControl.ImageItem
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Text;
using Utils;

namespace ImageControl
{
  public class ImageItem
  {
    protected ImageData item;

    public ImageData Item => this.item;

    public ImageItem(ImageData item) => this.item = item;

    public string Platform => this.item.Get(nameof (Platform));

    public string ImageID => this.item.Get(nameof (ImageID));

    public string Version => this.item.Get(nameof (Version));

    public string SubVersion => this.item.Get(nameof (SubVersion));

    public string ChannelID => this.item.Get(nameof (ChannelID));

    public string OperatorID => this.item.Get(nameof (OperatorID));

    public string InternalModel => this.item.Get(nameof (InternalModel));

    public string ExternalModel => this.item.Get(nameof (ExternalModel));

    public string ExternalVersion => this.item.Get(nameof (ExternalVersion));

    public string FilePath => this.item.Get(nameof (FilePath));

    public string DisplayModel
    {
      get
      {
        if (this.item.Contain("ExternalModel"))
          return this.item.Get("ExternalModel");
        return this.item.Contain("InternalModel") ? this.item.Get("InternalModel") : string.Empty;
      }
    }

    public string DisplayVersion
    {
      get
      {
        if (this.item.Contain("ExternalVersion"))
          return this.item.Get("ExternalVersion");
        return this.item.Contain("Version") && this.item.Contain("ImageID") ? string.Format("{0}_{1}_{2}", (object) this.item.Get("ImageID"), (object) this.item.Get("Version").Substring(0, 1), (object) this.item.Get("Version").Substring(1)) : string.Empty;
      }
    }

    public override bool Equals(object obj) => obj is ImageItem imageItem && this.Platform.Equals(imageItem.Platform) && (this.ImageID.Equals(imageItem.ImageID) && this.Version.Equals(imageItem.Version)) && (this.SubVersion.Equals(imageItem.SubVersion) && this.ChannelID.Equals(imageItem.ChannelID) && (this.OperatorID.Equals(imageItem.OperatorID) && this.InternalModel.Equals(imageItem.InternalModel))) && (this.ExternalModel.Equals(imageItem.ExternalModel) && this.ExternalVersion.Equals(imageItem.ExternalVersion));

    public override int GetHashCode() => (int) Crc32.Compute(Encoding.ASCII.GetBytes(string.Join("", new string[9]
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

    public override string ToString() => this.DisplayVersion;
  }
}
