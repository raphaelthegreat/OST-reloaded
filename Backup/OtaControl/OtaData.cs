// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaData
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using OtaControl.OtaImageCache;
using OtaControl.PhoneReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace OtaControl
{
  public class OtaData
  {
    private Dictionary<string, string> instance;

    public Dictionary<string, string> Instance => this.instance;

    public OtaData() => this.instance = new Dictionary<string, string>();

    public OtaData(OtaData from)
    {
      this.instance = new Dictionary<string, string>();
      foreach (KeyValuePair<string, string> keyValuePair in from.Instance)
        this.Set(keyValuePair.Key, keyValuePair.Value);
    }

    public OtaData(ImageData from)
    {
      this.instance = new Dictionary<string, string>();
      foreach (KeyValuePair<string, string> keyValuePair in from.Instance)
        this.Set(keyValuePair.Key, keyValuePair.Value);
    }

    public OtaData Set(string key, object value) => this.Set(key, value == null ? string.Empty : value.ToString());

    public OtaData Set(string key, string value)
    {
      if (!string.IsNullOrEmpty(value) && !value.Equals("NULL"))
        this.instance[key] = value;
      else if (this.instance.ContainsKey(key))
        this.instance.Remove(key);
      return this;
    }

    public bool Contain(string key) => this.instance.ContainsKey(key);

    public string Get(string key) => !this.instance.ContainsKey(key) ? string.Empty : this.instance[key];

    public static OtaData Combine(OtaData data1, OtaData data2)
    {
      OtaData otaData = new OtaData();
      foreach (KeyValuePair<string, string> keyValuePair in data1.instance)
        otaData.Set(keyValuePair.Key, keyValuePair.Value);
      foreach (KeyValuePair<string, string> keyValuePair in data2.instance)
        otaData.Set(keyValuePair.Key, keyValuePair.Value);
      return otaData;
    }

    public OtaData SubData(string[] keys)
    {
      OtaData otaData = new OtaData();
      foreach (string key in keys)
        otaData.Set(key, this.Get(key));
      return otaData;
    }

    public OtaData ExcludeData(string[] keys)
    {
      OtaData otaData = new OtaData();
      using (Dictionary<string, string>.Enumerator enumerator = this.instance.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          KeyValuePair<string, string> pair = enumerator.Current;
          if (!Array.Exists<string>(keys, (Predicate<string>) (key => key.Equals(pair.Key))))
            otaData.Set(pair.Key, pair.Value);
        }
      }
      return otaData;
    }

    public OtaData Remove(string key, string value)
    {
      if (this.instance.ContainsKey(key) && this.instance[key].Equals(value))
        this.instance.Remove(key);
      return this;
    }

    public OtaData Remove(string key)
    {
      if (this.instance.ContainsKey(key))
        this.instance.Remove(key);
      return this;
    }

    public static OtaData Parse(PhoneInformationEntity from)
    {
      OtaData otaData = new OtaData();
      otaData.Set("OtaNb0Update", from.otaNb0Update);
      otaData.Set("OtaDeltaUpdate", from.otaDeltaUpdate);
      otaData.Set("Version", from.version);
      otaData.Set("SubVersion", from.subVersion);
      otaData.Set("ImageID", from.imageId);
      otaData.Set("ChannelID", from.channelId);
      otaData.Set("OperatorID", from.operatorId);
      otaData.Set("InternalModel", from.internalModel);
      otaData.Set("ExternalModel", from.externalModel);
      otaData.Set("ExternalVersion", from.externalVersion);
      otaData.Set("DeviceID", from.deviceId);
      otaData.Set("SerialNumber", from.serialNumber);
      otaData.Set("MCC", from.mcc);
      otaData.Set("MNC", from.mnc);
      otaData.Set("SKUID", from.skuId);
      otaData.Set("CDAVersion", from.cdaVersion);
      otaData.Set("StorageSize", from.storageSize);
      otaData.Set("RootStatus", from.rootStatus);
      return otaData;
    }

    public static OtaData Parse(OtaFile from)
    {
      OtaData otaData = new OtaData();
      otaData.Set("ID", from.ID);
      otaData.Set("FilePath", from.FilePath);
      return otaData;
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
