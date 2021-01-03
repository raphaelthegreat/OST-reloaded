// Decompiled with JetBrains decompiler
// Type: Utils.DevMsg
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.InteropServices;

namespace Utils
{
    public class DevMsg
    {
        public const int WM_DEVICECHANGE = 537;
        public const int DBT_DEVICEARRIVAL = 32768;
        public const int DBT_DEVICEREMOVECOMPLETE = 32772;
        public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        public const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
        public const int DBT_DEVTYP_DEVICEINTERFACE = 5;
        private static DevMsg m_Instance;
        public static Guid GUID_CLASS_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
        public static Guid GUID_CLASS_USB_HUB = new Guid("f18a0e88-c30c-11d0-8815-00a0c906bed8");

        public static DevMsg Instance
        {
            get
            {
                if (DevMsg.m_Instance == null)
                    DevMsg.m_Instance = new DevMsg();
                return DevMsg.m_Instance;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(
          IntPtr hRecipient,
          IntPtr NotificationFilter,
          int Flags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr UnregisterDeviceNotification(IntPtr hHandle);

        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        public void RegisterHidNotification(IntPtr Handle)
        {
            DevMsg.DEV_BROADCAST_DEVICEINTERFACE broadcastDeviceinterface1 = new DevMsg.DEV_BROADCAST_DEVICEINTERFACE();
            int cb = Marshal.SizeOf((object)broadcastDeviceinterface1);
            broadcastDeviceinterface1.dbcc_size = cb;
            broadcastDeviceinterface1.dbcc_devicetype = 5;
            broadcastDeviceinterface1.dbcc_reserved = 0;
            broadcastDeviceinterface1.dbcc_classguid = DevMsg.GUID_CLASS_USB_DEVICE;
            IntPtr num1 = Marshal.AllocHGlobal(cb);
            Marshal.StructureToPtr((object)broadcastDeviceinterface1, num1, false);
            if (DevMsg.RegisterDeviceNotification(Handle, num1, 0) == IntPtr.Zero)
                Console.WriteLine(DevMsg.GetLastError().ToString());
            DevMsg.DEV_BROADCAST_DEVICEINTERFACE broadcastDeviceinterface2 = new DevMsg.DEV_BROADCAST_DEVICEINTERFACE();
            broadcastDeviceinterface2.dbcc_size = cb;
            broadcastDeviceinterface2.dbcc_devicetype = 5;
            broadcastDeviceinterface2.dbcc_reserved = 0;
            broadcastDeviceinterface2.dbcc_classguid = DevMsg.GUID_CLASS_USB_HUB;
            IntPtr num2 = Marshal.AllocHGlobal(cb);
            Marshal.StructureToPtr((object)broadcastDeviceinterface2, num2, false);
            if (!(DevMsg.RegisterDeviceNotification(Handle, num2, 0) == IntPtr.Zero))
                return;
            Console.WriteLine(DevMsg.GetLastError().ToString());
        }

        public void UnRegisterHidNotification(IntPtr Handle) => DevMsg.UnregisterDeviceNotification(Handle);

        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_DEVICEINTERFACE
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            public Guid dbcc_classguid;
            public string dbcc_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DEV_BROADCAST_DEVICEINTERFACE1
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
            public byte[] dbcc_classguid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] dbcc_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_PORT
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            public string dbcc_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DEV_BROADCAST_PORT1
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] dbcc_name;
        }
    }
}
