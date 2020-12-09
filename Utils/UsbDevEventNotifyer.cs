// Decompiled with JetBrains decompiler
// Type: Utils.UsbDevEventNotifyer
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Utils
{
  public class UsbDevEventNotifyer
  {
    private static UsbDevEventNotifyer m_Instance;

    public static UsbDevEventNotifyer Instance
    {
      get
      {
        if (UsbDevEventNotifyer.m_Instance == null)
          UsbDevEventNotifyer.m_Instance = new UsbDevEventNotifyer();
        return UsbDevEventNotifyer.m_Instance;
      }
    }

    public UsbEvent GetUsbEvent(int iEventType, string sDevicePath)
    {
      string[] strArray = sDevicePath.Split('#');
      if (strArray.Length < 3)
        return (UsbEvent) null;
      UsbEvent usbEvent = new UsbEvent();
      usbEvent.sDevicePath = sDevicePath;
      usbEvent.dtLastUpdateTime = DateTime.Now;
      if (iEventType == 32768)
      {
        usbEvent.sDeviceVidPid = strArray[1];
        usbEvent.sDevEventType = "Insert";
        usbEvent.sUsbAddress = strArray[2];
      }
      else
      {
        usbEvent.sDeviceVidPid = strArray[1];
        usbEvent.sDevEventType = "Remove";
        usbEvent.sUsbAddress = strArray[2];
      }
      return usbEvent;
    }

    public void WriteEventMsgToLog(UsbEvent objUsbEvent) => CLogs.Broadcast(objUsbEvent.ToString());

    public void WndProc(ref Message m)
    {
      if (m.Msg != 537)
        return;
      int int32 = m.WParam.ToInt32();
      switch (int32)
      {
        case 32768:
        case 32772:
          string sDevicePath = (new string(((DevMsg.DEV_BROADCAST_DEVICEINTERFACE1) Marshal.PtrToStructure(m.LParam, typeof (DevMsg.DEV_BROADCAST_DEVICEINTERFACE1))).dbcc_name).Split('}')[0] + "}").Replace("{", "{{").Replace("}", "}}");
          UsbEvent usbEvent = this.GetUsbEvent(int32, sDevicePath);
          if (usbEvent == null)
            break;
          this.WriteEventMsgToLog(usbEvent);
          break;
      }
    }
  }
}
