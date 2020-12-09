// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.FileHandlerEntry
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.FileHandlerService;
using OtaControl;

namespace MyResources.OtaHandlerService
{
  internal class FileHandlerEntry
  {
    private DictionaryEntry[] instance;

    public DictionaryEntry[] Instance => this.instance;

    public FileHandlerEntry(DictionaryEntry[] entry) => this.instance = entry;

    public OtaData ToOtaData()
    {
      OtaData otaData = new OtaData();
      foreach (DictionaryEntry dictionaryEntry in this.instance)
        otaData.Set(dictionaryEntry.Key.ToString(), dictionaryEntry.Value);
      return otaData;
    }
  }
}
