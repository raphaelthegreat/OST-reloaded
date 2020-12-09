// Decompiled with JetBrains decompiler
// Type: MyResources.OtaHandlerService.LoginServiceEntries
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using System.Collections.Generic;

namespace MyResources.OtaHandlerService
{
  internal class LoginServiceEntries : LoginEntries
  {
    public LoginServiceEntries()
    {
    }

    public LoginServiceEntries(MyResources.LoginService.DictionaryEntry[] entries)
      : base(entries)
    {
    }

    public List<OtaData> ToWebServices(string loginUrl, out List<string> redirectedUrls)
    {
      redirectedUrls = new List<string>();
      List<OtaData> otaDataList = new List<OtaData>();
      foreach (MyResources.LoginService.DictionaryEntry dictionaryEntry1 in this.instance)
      {
        if (dictionaryEntry1.Value is MyResources.LoginService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.LoginService.DictionaryEntry dictionaryEntry2 in (MyResources.LoginService.DictionaryEntry[]) dictionaryEntry1.Value)
          {
            if (dictionaryEntry2.Key.ToString().Equals("_SUT_Redirect_"))
              redirectedUrls.Add(dictionaryEntry2.Value.ToString().Replace("_SUT_Redirect_", "login"));
            else
              otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          }
          if (!otaData.Contain("Login"))
            otaData.Set("Login", loginUrl);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.FileHandlerService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.FileHandlerService.DictionaryEntry dictionaryEntry2 in (MyResources.FileHandlerService.DictionaryEntry[]) dictionaryEntry1.Value)
          {
            if (dictionaryEntry2.Key.ToString().Equals("_SUT_Redirect_"))
              redirectedUrls.Add(dictionaryEntry2.Value.ToString().Replace("_SUT_Redirect_", "login"));
            else
              otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          }
          if (!otaData.Contain("Login"))
            otaData.Set("Login", loginUrl);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.SWImageService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.SWImageService.DictionaryEntry dictionaryEntry2 in (MyResources.SWImageService.DictionaryEntry[]) dictionaryEntry1.Value)
          {
            if (dictionaryEntry2.Key.ToString().Equals("_SUT_Redirect_"))
              redirectedUrls.Add(dictionaryEntry2.Value.ToString().Replace("_SUT_Redirect_", "login"));
            else
              otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          }
          if (!otaData.Contain("Login"))
            otaData.Set("Login", loginUrl);
          otaDataList.Add(otaData);
        }
        else if (dictionaryEntry1.Value is MyResources.LogService.DictionaryEntry[])
        {
          OtaData otaData = new OtaData();
          foreach (MyResources.LogService.DictionaryEntry dictionaryEntry2 in (MyResources.LogService.DictionaryEntry[]) dictionaryEntry1.Value)
          {
            if (dictionaryEntry2.Key.ToString().Equals("_SUT_Redirect_"))
              redirectedUrls.Add(dictionaryEntry2.Value.ToString().Replace("_SUT_Redirect_", "login"));
            else
              otaData.Set(dictionaryEntry2.Key.ToString(), dictionaryEntry2.Value);
          }
          if (!otaData.Contain("Login"))
            otaData.Set("Login", loginUrl);
          otaDataList.Add(otaData);
        }
      }
      return otaDataList;
    }
  }
}
