// Decompiled with JetBrains decompiler
// Type: Utils.UsbEvent
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;

namespace Utils
{
    public class UsbEvent
    {
        public string sDevEventType = "";
        public string sUsbAddress = "";
        public string sDeviceVidPid = "";
        public string sDevicePath = "";
        public DateTime dtLastUpdateTime = new DateTime();
        public bool bRunTest;

        public UsbEvent()
        {
            this.sDevEventType = "";
            this.sUsbAddress = "";
            this.sDeviceVidPid = "";
            this.sDevicePath = "";
            this.dtLastUpdateTime = new DateTime();
            this.bRunTest = false;
        }

        public override string ToString() => string.Format("Type={0}", (object)this.sDevEventType) + "," + string.Format("Dev_VidPid={0}", (object)this.sDeviceVidPid) + "," + string.Format("USB_Address={0}", (object)this.sUsbAddress) + "," + string.Format("Time={0:00}:{1:00}:{2:00}::{3:000}", (object)this.dtLastUpdateTime.Hour, (object)this.dtLastUpdateTime.Minute, (object)this.dtLastUpdateTime.Second, (object)this.dtLastUpdateTime.Millisecond);
    }
}
