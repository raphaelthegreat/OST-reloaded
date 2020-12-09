// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.SwImageEntries
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.SWImageService;
using OtaControl;
using System.Collections.Generic;

namespace MyResources.OtaHandlerService
{
  internal class SwImageEntries
  {
    private DictionaryEntry[][] instance;

    public SwImageEntries() => this.instance = new DictionaryEntry[0][];

    public SwImageEntries(DictionaryEntry[][] entries) => this.instance = entries;

    public List<OtaData> ToOtaDatas(string key)
    {
      List<OtaData> otaDataList = new List<OtaData>();
      foreach (DictionaryEntry[] dictionaryEntryArray in this.instance)
      {
        foreach (DictionaryEntry dictionaryEntry in dictionaryEntryArray)
        {
          if (dictionaryEntry.Key.ToString().Equals(key))
          {
            otaDataList.Add(new OtaData().Set(dictionaryEntry.Key.ToString(), dictionaryEntry.Value));
            break;
          }
        }
      }
      return otaDataList;
    }
  }
}
