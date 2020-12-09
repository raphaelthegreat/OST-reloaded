// Decompiled with JetBrains decompiler
// Type: MainForms.ProgressItem
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Framework.Controls;
using System.Collections.Generic;
using Tasks;

namespace MainForms
{
  internal class ProgressItem
  {
    private string deviceId;
    private bool connected;
    private List<string> interfaceItemList;
    private DispatchTask updateTask;
    private XpProgressBar progress;

    public string DeviceId => this.deviceId;

    public string SessionId => "S01";

    public DispatchTask Task
    {
      get => this.updateTask;
      set => this.updateTask = value;
    }

    public bool Connected => this.connected;

    public List<string> DeviceInterface => this.interfaceItemList;

    public ProgressItem(XpProgressBar progress)
    {
      this.deviceId = string.Empty;
      this.connected = false;
      this.progress = progress;
    }

    public void SetDeviceStatus(string deviceId, bool connected, List<string> interfaceItems)
    {
      this.deviceId = deviceId;
      this.connected = connected;
      this.interfaceItemList = interfaceItems;
    }

    public void Reset() => this.connected = false;

    public void ResetProgress()
    {
      this.progress.Position = 0;
      this.progress.Text = string.Empty;
    }

    public void SetProgress(int position, string message)
    {
      this.progress.Position = position;
      this.progress.Text = message;
    }
  }
}
