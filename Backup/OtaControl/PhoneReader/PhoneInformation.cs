// Decompiled with JetBrains decompiler
// Type: OtaControl.PhoneReader.PhoneInformation
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ErrorDef;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Utils;

namespace OtaControl.PhoneReader
{
  public class PhoneInformation
  {
    public OtaData GetPhoneInformation(string sessionId, string deviceId)
    {
      try
      {
        StringBuilder phoneInfo = new StringBuilder(1024);
        int num = PhoneInformation.ReadPhoneInformation(sessionId, deviceId, phoneInfo, phoneInfo.Capacity);
        if (num == 0)
          return OtaData.Parse(JsonConvert.DeserializeObject<PhoneInformationEntity>(phoneInfo.ToString()));
        throw new CException((long) num, "Read device information fails, last error: " + ErrorCode.StringOf((long) num));
      }
      catch (CException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
        throw new CException(1066L, "Catch exception when reading device information.");
      }
    }

    [DllImport("MobileFlashDll.dll")]
    private static extern int ReadPhoneInformation(
      string sessionId,
      string deviceId,
      StringBuilder phoneInfo,
      int phoneInfoSize);
  }
}
