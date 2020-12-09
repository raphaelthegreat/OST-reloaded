// Decompiled with JetBrains decompiler
// Type: ImageControl.ImageData
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl.ImageLoader;
using System.Collections.Generic;
using System.Text;

namespace ImageControl
{
  public class ImageData
  {
    private Dictionary<string, string> instance;

    public Dictionary<string, string> Instance => this.instance;

    public ImageData() => this.instance = new Dictionary<string, string>();

    public ImageData Set(string key, object value) => this.Set(key, value == null ? string.Empty : value.ToString());

    public ImageData Set(string key, string value)
    {
      if (!string.IsNullOrEmpty(value) && !value.Equals("NULL"))
        this.instance[key] = value;
      else if (this.instance.ContainsKey(key))
        this.instance.Remove(key);
      return this;
    }

    public bool Contain(string key) => this.instance.ContainsKey(key);

    public string Get(string key) => !this.instance.ContainsKey(key) ? string.Empty : this.instance[key];

    public static ImageData Parse(ImageInformationEntity from)
    {
      ImageData imageData = new ImageData();
      imageData.Set("Version", from.version);
      imageData.Set("SubVersion", from.subVersion);
      imageData.Set("ImageID", from.imageId);
      imageData.Set("ChannelID", from.channelId);
      imageData.Set("OperatorID", from.operatorId);
      imageData.Set("InternalModel", from.internalModel);
      imageData.Set("ExternalModel", from.externalModel);
      imageData.Set("ExternalVersion", from.externalVersion);
      imageData.Set("CDAVersion", from.cdaVersion);
      imageData.Set("SecurityVersion", from.securityVersion);
      imageData.Set("HasBackupNvOption", from.hasBackupNvOption);
      imageData.Set("HasEraseUserDataOption", from.hasEraseUserDataOption);
      imageData.Set("HasEraseBoxDataOption", from.hasEraseBoxDataOption);
      imageData.Set("HasCustomerSKUIDOption", from.hasCustomerSKUIDOption);
      imageData.Set("HasNativeOption", from.hasNativeOption);
      imageData.Set("HasNativeFormatOption", from.hasNativeFormatOption);
      imageData.Set("HasEraseFrpOption", from.hasEraseFrpOption);
      imageData.Set("HasUFSProvisionOption", from.hasUFSProvisionOption);
      imageData.Set("HasUnlockScreenOption", from.hasUnlockScreenLockOption);
      imageData.Set("HasCollectAprLogOption", from.hasCollectAprLogOption);
      return imageData;
    }

    public override string ToString()
    {
      int num = 0;
      StringBuilder stringBuilder = new StringBuilder("{ ", 1024);
      foreach (string key in this.instance.Keys)
      {
        if (num++ > 0)
          stringBuilder.Append(", ");
        stringBuilder.Append("{ ").Append(key).Append(": ").Append(this.instance[key]).Append(" }");
      }
      return stringBuilder.Append(" }").ToString();
    }
  }
}
