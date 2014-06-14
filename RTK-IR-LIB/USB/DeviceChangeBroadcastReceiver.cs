using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RtkIRLib
{
    public partial class DeviceChangeBroadcastReceiver : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public event EventHandler<DeviceArrivedEventArgs> DeviceArrived;
        public event EventHandler<DeviceRemovedEventArgs> DeviceRemoved;

        public DeviceChangeBroadcastReceiver()
        {
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        HandleUsbEvent(m.LParam, false);
                        break;
                    case UsbNotification.DbtDevicearrival:
                        HandleUsbEvent(m.LParam, true);
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the USB event.
        /// </summary>
        /// <param name="lParam">The lParam of the WndProc Message.</param>
        /// <param name="arrived">Value indicating whether the device arrived or departed.</param>
        public void HandleUsbEvent(IntPtr lParam, bool arrived)
        {
            UsbNotification.DevBroadcastHdr broadcastHdr = (UsbNotification.DevBroadcastHdr)Marshal.PtrToStructure(lParam, typeof(UsbNotification.DevBroadcastHdr));
            if ((UsbNotification.DevType)broadcastHdr.DeviceType == UsbNotification.DevType.DeviceInterface)
            {
                UsbNotification.DevBroadcastDeviceinterface dev = (UsbNotification.DevBroadcastDeviceinterface)Marshal.PtrToStructure(lParam, typeof(UsbNotification.DevBroadcastDeviceinterface));
                DeviceID devID;
                if (TryParseDeviceId(dev.Name, out devID))
	            {
                    if (arrived)
                    {
                        OnDeviceArrived(new DeviceArrivedEventArgs(devID));
                    }
                    else
                    {
                        OnDeviceRemoved(new DeviceRemovedEventArgs(devID));
                    }
	            }
            }
        }

        /// <summary>
        /// Tries to extract the device ids from a dbcc_name string. A return value indicates whether the operation succeeded or failed.
        /// dbcc_name format: \\?\USB#VID_048D&PID_9135#7&267556c3&0&3#{a5dcbf10-6530-11d2-901f-00c04fb951ed}
        /// </summary>
        private bool TryParseDeviceId(String dbcc_name, out DeviceID devID)
        {
            devID = new DeviceID();

            string pattern = "VID_([0-9A-F]{4})&PID_([0-9A-F]{4})";
            Match match = Regex.Match(dbcc_name, pattern);

            if (!match.Success)
            {
                return false;
            }

            devID.Vid = UInt16.Parse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            devID.Pid = UInt16.Parse(match.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);

            return true;
        }

        protected virtual void OnDeviceArrived(DeviceArrivedEventArgs e)
        {
            EventHandler<DeviceArrivedEventArgs> handler = DeviceArrived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDeviceRemoved(DeviceRemovedEventArgs e)
        {
            EventHandler<DeviceRemovedEventArgs> handler = DeviceRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class DeviceArrivedEventArgs : EventArgs
    {
        public DeviceID DeviceID { get; set; }

        public DeviceArrivedEventArgs(DeviceID deviceID)
        {
            this.DeviceID = deviceID;
        }
    }

    public class DeviceRemovedEventArgs : EventArgs
    {
        public DeviceID DeviceID { get; set; }

        public DeviceRemovedEventArgs(DeviceID deviceID)
        {
            this.DeviceID = deviceID;
        }
    }
}
