// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.SwImageEntry
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.SWImageService;
using OtaControl;
using System;
using System.Collections.Generic;

namespace MyResources.OtaHandlerService
{
  internal class SwImageEntry
  {
    private DictionaryEntry[] instance;

    public DictionaryEntry[] Instance => this.instance;

    public SwImageEntry(OtaData from)
    {
      int index = 0;
      this.instance = new DictionaryEntry[from.Instance.Count];
      foreach (KeyValuePair<string, string> keyValuePair in from.Instance)
      {
        this.instance[index] = new DictionaryEntry();
        this.instance[index].Key = (object) keyValuePair.Key;
        this.instance[index].Value = (object) keyValuePair.Value;
        ++index;
      }
    }

    public SwImageEntry(DictionaryEntry[] entry) => this.instance = entry;

    public SwImageEntry Add(string key, object value)
    {
      Array.Resize<DictionaryEntry>(ref this.instance, this.instance.Length + 1);
      this.instance[this.instance.Length - 1] = new DictionaryEntry();
      this.instance[this.instance.Length - 1].Key = (object) key;
      this.instance[this.instance.Length - 1].Value = value;
      return this;
    }

    public OtaData ToOtaData()
    {
      OtaData otaData = new OtaData();
      foreach (DictionaryEntry dictionaryEntry in this.instance)
        otaData.Set(dictionaryEntry.Key.ToString(), dictionaryEntry.Value);
      return otaData;
    }
  }
}
