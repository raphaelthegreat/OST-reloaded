// Decompiled with JetBrains decompiler
// Type: Devices.MyDevice
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Devices
{
    internal class MyDevice
    {
        private Control owner;
        private Thread detectThread;
        private List<string> deviceList;
        private MyDevice.OnDeviceChangedDelegate deviceChangedDelegate;
        private ManualResetEvent stopEvent;
        private ManualResetEvent runEvent;
        private ManualResetEvent idleEvent;

        private bool DeviceModeSupported(MyDevice.DeviceMode deviceMode) => deviceMode == MyDevice.DeviceMode.DevModeOsWithAdbAndPorts || deviceMode == MyDevice.DeviceMode.DevModeFastboot || deviceMode == MyDevice.DeviceMode.DevModeFtm;

        public static bool DeviceModePhoneDataEditSupported(MyDevice.DeviceMode deviceMode) => deviceMode == MyDevice.DeviceMode.DevModeFastboot || deviceMode == MyDevice.DeviceMode.DevModeFtm;

        public MyDevice(MyDevice.OnDeviceChangedDelegate newDelegate, Control owner)
        {
            this.owner = owner;
            this.deviceList = new List<string>();
            this.deviceChangedDelegate = newDelegate;
            this.stopEvent = new ManualResetEvent(false);
            this.runEvent = new ManualResetEvent(false);
            this.idleEvent = new ManualResetEvent(false);
        }

        public static string GetDeviceModeString(int deviceMode)
        {
            switch (deviceMode)
            {
                case 0:
                    return "DevModeUnknown";
                case 1:
                    return "DevModeOsNormal";
                case 2:
                    return "DevModeOsWithAdb";
                case 3:
                    return "DevModeOsWithAdbAndPorts";
                case 4:
                    return "DevModeFtm";
                case 5:
                    return "DevModeFastboot";
                case 6:
                    return "DevModeRecovery";
                case 7:
                    return "DevModeQcPbl";
                case 8:
                    return "DevModeMedfield";
                case 9:
                    return "DevModeOmap";
                case 10:
                    return "DevModePreloader";
                case 11:
                    return "DevModeDa";
                case 12:
                    return "DevModeSimpleio";
                default:
                    return "DevModeUnknown";
            }
        }

        public void StartDetectDevice()
        {
            this.detectThread = new Thread(new ThreadStart(this.DoDetectDevice));
            if (this.detectThread == null)
                return;
            this.detectThread.IsBackground = true;
            this.detectThread.Priority = ThreadPriority.BelowNormal;
            this.detectThread.Start();
        }

        public void StopDetectDevice() => this.stopEvent.Set();

        public void ResetDeviceList() => this.deviceList.Clear();

        public void DoDetectDevice(bool run)
        {
            if (run)
                this.runEvent.Set();
            else
                this.runEvent.Reset();
        }

        private void DoDetectDevice()
        {
            ManualResetEvent[] manualResetEventArray1 = new ManualResetEvent[2]
            {
        this.runEvent,
        this.stopEvent
            };
            ManualResetEvent[] manualResetEventArray2 = new ManualResetEvent[2]
            {
        this.idleEvent,
        this.stopEvent
            };
            List<string> addDeviceList = new List<string>();
            List<string> removeDeviceList = new List<string>();
            List<string> currentDeviceList = new List<string>();
            while (this.deviceChangedDelegate != null && WaitHandle.WaitAny((WaitHandle[])manualResetEventArray1) != 1)
            {
                addDeviceList.Clear();
                removeDeviceList.Clear();
                currentDeviceList.Clear();
                this.FindDeviceList(currentDeviceList);
                if (this.runEvent.WaitOne(0, false))
                {
                    this.CheckDeviceList(currentDeviceList, addDeviceList, removeDeviceList);
                    if (WaitHandle.WaitAny((WaitHandle[])manualResetEventArray2, 2000, false) == 1)
                        break;
                }
            }
        }

        private void FindDeviceList(List<string> currentDeviceList)
        {
            StringBuilder deviceIds = new StringBuilder(1024);
            if (!MyDevice.DetectDeviceList(deviceIds, deviceIds.Capacity) || deviceIds.Length <= 0)
                return;
            string str = deviceIds.ToString();
            char[] chArray = new char[1] { ';' };
            foreach (string deviceId in str.Split(chArray))
            {
                int deviceMode;
                if (MyDevice.GetDeviceMode(deviceId, out deviceMode) && this.DeviceModeSupported((MyDevice.DeviceMode)deviceMode))
                    currentDeviceList.Add(deviceId);
            }
        }

        private List<string> GetDeviceInterfaceList(string deviceId)
        {
            StringBuilder interfaceItems = new StringBuilder(1024);
            try
            {
                if (MyDevice.GetDeviceInterfaceList(deviceId, interfaceItems, interfaceItems.Capacity))
                    return new List<string>((IEnumerable<string>)interfaceItems.ToString().Split(';'));
            }
            catch (Exception)
            {
                return new List<string>();
            }
            return new List<string>();
        }

        private void CheckDeviceList(
          List<string> currentDeviceList,
          List<string> addDeviceList,
          List<string> removeDeviceList)
        {
            foreach (string device in this.deviceList)
            {
                if (!currentDeviceList.Contains(device))
                    removeDeviceList.Add(device);
            }
            foreach (string removeDevice in removeDeviceList)
            {
                this.deviceList.Remove(removeDevice);
                this.owner.Invoke((Delegate)this.deviceChangedDelegate, (object)removeDevice, (object)false, null);
            }
            foreach (string currentDevice in currentDeviceList)
            {
                if (!this.deviceList.Contains(currentDevice))
                    addDeviceList.Add(currentDevice);
            }
            foreach (string addDevice in addDeviceList)
            {
                List<string> deviceInterfaceList = this.GetDeviceInterfaceList(addDevice);
                if (deviceInterfaceList.Count != 0)
                {
                    this.deviceList.Add(addDevice);
                    this.owner.Invoke((Delegate)this.deviceChangedDelegate, (object)addDevice, (object)true, (object)deviceInterfaceList);
                }
            }
        }

        [DllImport("DeviceMngDll.dll")]
        public static extern bool DetectDeviceList(StringBuilder deviceIds, int deviceIdsSize);

        [DllImport("DeviceMngDll.dll")]
        public static extern bool GetDeviceMode(string deviceId, out int deviceMode);

        [DllImport("DeviceMngDll.dll")]
        public static extern bool GetDeviceInterfaceList(
          string deviceId,
          StringBuilder interfaceItems,
          int interfaceItemSize);

        [DllImport("DeviceMngDll.dll")]
        public static extern bool DetectExternalUsbHub(string deviceId, out bool extnalUsbHub);

        public delegate void OnDeviceChangedDelegate(
          string deviceId,
          bool connected,
          List<string> interfaceItems);

        public enum DeviceMode
        {
            DevModeUnknown,
            DevModeOsNormal,
            DevModeOsWithAdb,
            DevModeOsWithAdbAndPorts,
            DevModeFtm,
            DevModeFastboot,
            DevModeRecovery,
            DevModeQcPbl,
            DevModeMedfield,
            DevModeOmap,
            DevModePreloader,
            DevModeDa,
            DevModeSimpleio,
        }
    }
}
