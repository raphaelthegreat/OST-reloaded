// Decompiled with JetBrains decompiler
// Type: MainForms.GemsQueryDeviceInfo
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace MainForms
{
  public class GemsQueryDeviceInfo
  {
    public string sn;
    public string guid;
    public string simpersoFileName;
    public string simpersoFileContent;

    public GemsQueryDeviceInfo(string sn)
    {
      this.sn = sn;
      this.guid = string.Empty;
      this.simpersoFileName = string.Empty;
      this.simpersoFileContent = string.Empty;
    }

    public bool IsValid() => this.sn != string.Empty && this.guid != string.Empty;

    public bool HasSimLockPerso() => this.simpersoFileName != string.Empty && this.simpersoFileContent != string.Empty;
  }
}
