using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RtkIRLib
{
    public class IRMonitor
    {
        private static readonly DeviceID DefaultDeviceIdRTK = new DeviceID(0x0BDA, 0x2838);
        private static readonly DeviceID DefaultDeviceIdAF = new DeviceID(0x048D, 0x9135);

        private DeviceChangeBroadcastReceiver broadcastReceiver;

        private volatile bool isMonitoring;
        private Thread monitorThread;
        private int lastIRCode;

        public event EventHandler<IRCodeReceivedEventArgs> IRCodeReceived;
        public event EventHandler<IRDeviceChangeEventArgs> IRDeviceArrived;
        public event EventHandler<IRDeviceChangeEventArgs> IRDeviceRemoved;

        private RTKIR RTKDevice;
        private AF9100IR AFDevice;

        public uint MaskCode { get; private set; }

        public List<DeviceID> RTKDeviceIdLookup { get; private set; }
        public List<DeviceID> AFDeviceIdLookup { get; private set; }

        public IRMonitor(uint maskCode)
        {
            MaskCode = maskCode;
            RTKDeviceIdLookup = new List<DeviceID>() { DefaultDeviceIdRTK };
            AFDeviceIdLookup = new List<DeviceID>() { DefaultDeviceIdAF };

            broadcastReceiver = new DeviceChangeBroadcastReceiver();
            broadcastReceiver.DeviceArrived += broadcastReceiver_DeviceArrived;
            broadcastReceiver.DeviceRemoved += broadcastReceiver_DeviceRemoved;

            foreach (USBDeviceInfo device in USBDevices.GetUSBDevices())
            {
                Console.WriteLine(device.DeviceID.ToString());
                CheckDevice(device.DeviceID);
            }
        }

        public IRMonitor(uint maskCode, List<DeviceID> rtkDeviceIdLookup, List<DeviceID> afDeviceIdLookup)
        {
            MaskCode = maskCode;
            RTKDeviceIdLookup = rtkDeviceIdLookup;
            AFDeviceIdLookup = afDeviceIdLookup;

            broadcastReceiver = new DeviceChangeBroadcastReceiver();
            broadcastReceiver.DeviceArrived += broadcastReceiver_DeviceArrived;
            broadcastReceiver.DeviceRemoved += broadcastReceiver_DeviceRemoved;

            foreach (USBDeviceInfo device in USBDevices.GetUSBDevices())
            {
                CheckDevice(device.DeviceID);
            }
        }

        void broadcastReceiver_DeviceArrived(object sender, DeviceArrivedEventArgs e)
        {
            CheckDevice(e.DeviceID);
        }

        private void CheckDevice(DeviceID devID)
        {
            if (RTKDevice == null && RTKDeviceIdLookup.Contains(devID))
            {
                Thread initThread = new Thread(() => InitializeDevice(DeviceType.RTKIR, devID));
                initThread.SetApartmentState(ApartmentState.STA);
                initThread.IsBackground = true;
                initThread.Start();
                return;
            }

            if (AFDevice == null && AFDeviceIdLookup.Contains(devID))
            {
                Thread initThread = new Thread(() => InitializeDevice(DeviceType.AF9100IR, devID));
                initThread.SetApartmentState(ApartmentState.STA);
                initThread.IsBackground = true;
                initThread.Start();
            }
        }

        private void InitializeDevice(DeviceType type, DeviceID id)
        {
            // Wait a few seconds until device becomes ready
            Thread.Sleep(2000);
            switch (type)
            {
                case DeviceType.RTKIR:
                    RTKIR rtk = new RTKIR(id);
                    if (rtk.TryInitIRDevice())
                    {
                        RTKDevice = rtk;
                        OnIRDeviceArrived(new IRDeviceChangeEventArgs() { Device = DeviceType.RTKIR, DeviceID = id });
                    }
                    break;
                case DeviceType.AF9100IR:
                    AF9100IR af = new AF9100IR(id);
                    if (af.TryInitIRDevice())
                    {
                        AFDevice = af;
                        OnIRDeviceArrived(new IRDeviceChangeEventArgs() { Device = DeviceType.AF9100IR, DeviceID = id });
                    }
                    break;
            }
        }

        void broadcastReceiver_DeviceRemoved(object sender, DeviceRemovedEventArgs e)
        {
            if (RTKDevice != null && RTKDevice.DeviceID.Equals(e.DeviceID))
            {
                lock (RTKDevice)
                {
                    RTKDevice = null;
                }
                OnIRDeviceRemoved(new IRDeviceChangeEventArgs() { Device = DeviceType.RTKIR, DeviceID = e.DeviceID });
                return;
            }

            if (AFDevice != null && AFDevice.DeviceID.Equals(e.DeviceID))
            {
                lock (AFDevice)
                {
                    AFDevice = null;
                }
                OnIRDeviceRemoved(new IRDeviceChangeEventArgs() { Device = DeviceType.AF9100IR, DeviceID = e.DeviceID });
            }
        }

        public void StartMonitoring()
        {
            if (isMonitoring)
            {
                return;
            }

            isMonitoring = true;
            monitorThread = new Thread(MonitorIRCodes);
            monitorThread.SetApartmentState(ApartmentState.STA);
            monitorThread.IsBackground = true;
            monitorThread.Start();
        }

        public void StopMonitoring()
        {
            if (!isMonitoring)
            {
                return;
            }

            isMonitoring = false;
            if (!monitorThread.Join(200))
            {
                monitorThread.Abort();
            }

            monitorThread = null;
        }

        private void MonitorIRCodes()
        {
            while (isMonitoring)
            {
                if (RTKDevice != null)
                {
                    lock (RTKDevice)
                    {
                        if (RTKDevice.TryNativeReadIRCode(MaskCode, out lastIRCode))
                        {
                            OnIRCodeReceived(new IRCodeReceivedEventArgs() { Device = DeviceType.RTKIR, IRCode = lastIRCode });
                        }
                    }
                }

                if (AFDevice != null)
                {
                    lock (AFDevice)
                    {
                        if (AFDevice.TryReadIRCode(MaskCode, out lastIRCode))
                        {
                            OnIRCodeReceived(new IRCodeReceivedEventArgs() { Device = DeviceType.AF9100IR, IRCode = lastIRCode });
                        }
                    }
                }

                Thread.Sleep(100);
            }
            Debug.WriteLine("Monitoring ended");
        }

        protected virtual void OnIRDeviceArrived(IRDeviceChangeEventArgs e)
        {
            EventHandler<IRDeviceChangeEventArgs> handler = IRDeviceArrived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnIRDeviceRemoved(IRDeviceChangeEventArgs e)
        {
            EventHandler<IRDeviceChangeEventArgs> handler = IRDeviceRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnIRCodeReceived(IRCodeReceivedEventArgs e)
        {
            EventHandler<IRCodeReceivedEventArgs> handler = IRCodeReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class IRCodeReceivedEventArgs : EventArgs
    {
        public DeviceType Device { get; set; }

        public int IRCode { get; set; }
    }

    public class IRDeviceChangeEventArgs : EventArgs
    {
        public DeviceType Device { get; set; }
        public DeviceID DeviceID { get; set; }
    }
}
