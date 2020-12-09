// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.LoginEntries
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using System.Collections.Generic;

namespace MyResources.OtaHandlerService
{
  internal class LoginEntries
  {
    protected MyResources.LoginService.DictionaryEntry[] instance;

    public MyResources.LoginService.DictionaryEntry[] Instance => this.instance;

    public LoginEntries() => this.instance = new MyResources.LoginService.DictionaryEntry[0];

    public LoginEntries(MyResources.LoginService.DictionaryEntry[] entries) => this.instance = entries;

    public List<OtaData> ToOtaDataList()
    {
      List<OtaData> otaDataList = new List<OtaData>();
      foreach (MyResources.LoginService.DictionaryEntry dictionaryEntry1 in this.instance)
      {
        if (dictionaryEntry1.Value is MyResources.LoginService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.LoginService.DictionaryEntry dictionaryEntry2 in (MyResources.LoginService.DictionaryEntry[]) dictionaryEntry1.Value)
            otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.FileHandlerService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.FileHandlerService.DictionaryEntry dictionaryEntry2 in (MyResources.FileHandlerService.DictionaryEntry[]) dictionaryEntry1.Value)
            otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.SWImageService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.SWImageService.DictionaryEntry dictionaryEntry2 in (MyResources.SWImageService.DictionaryEntry[]) dictionaryEntry1.Value)
            otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.LogService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.LogService.DictionaryEntry dictionaryEntry2 in (MyResources.LogService.DictionaryEntry[]) dictionaryEntry1.Value)
            otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          otaDataList.Add(otaData);
        }
      }
      return otaDataList;
    }
  }
}
