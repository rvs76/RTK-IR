using System;
using System.Runtime.InteropServices;
using System.Text;

internal static class UsbNotification
{
    public const int DbtDevicearrival = 0x8000; // system detected a new device        
    public const int DbtDeviceremovecomplete = 0x8004; // device is gone      
    public const int WmDevicechange = 0x0219; // device change event
    private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
    //private static readonly Guid GuidDevinterfaceMedia = new Guid("4d36e96c-e325-11ce-bfc1-08002be10318"); // MEDIA

    private static IntPtr notificationHandle;

    /// <summary>
    /// Registers a window to receive notifications when USB devices are plugged or unplugged.
    /// </summary>
    /// <param name="windowHandle">Handle to the window receiving notifications.</param>
    public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
    {
        DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
        {
            DeviceType = (int)DevType.DeviceInterface,
            Reserved = 0,
            ClassGuid = GuidDevinterfaceUSBDevice,
        };

        dbi.Size = Marshal.SizeOf(dbi);
        IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
        Marshal.StructureToPtr(dbi, buffer, true);

        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
    }

    /// <summary>
    /// Unregisters the window for USB device notifications
    /// </summary>
    public static void UnregisterUsbDeviceNotification()
    {
        UnregisterDeviceNotification(notificationHandle);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

    [DllImport("user32.dll")]
    private static extern bool UnregisterDeviceNotification(IntPtr handle);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DevBroadcastDeviceinterface
    {
        internal int Size;
        internal int DeviceType;
        internal int Reserved;
        internal Guid ClassGuid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        internal string Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DevBroadcastHdr
    {
        internal int Size;
        internal int DeviceType;
        internal IntPtr Reserved;
    }

    public enum DevType
    {
        DeviceInterface = 0x00000005,
        Handle = 0x00000006,
        OEM = 0x00000000,
        Port = 0x00000003,
        Volume = 0x00000002
    }
}
