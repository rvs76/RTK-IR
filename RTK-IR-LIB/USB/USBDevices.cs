using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RtkIRLib
{
    public class USBDevices
    {
        public static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBControllerDevice"))
                collection = searcher.Get();

            DeviceID devID;
            foreach (var device in collection)
            {
                //(string)device.GetPropertyValue("DeviceID"),
                //(string)device.GetPropertyValue("PNPDeviceID"),
                //(string)device.GetPropertyValue("Description")
                if (TryParseDeviceId((string)device.GetPropertyValue("Dependent"), out devID))
                {
                    devices.Add(new USBDeviceInfo(devID));
                }
               
            }

            collection.Dispose();
            return devices;
        }

        private static bool TryParseDeviceId(string input, out DeviceID devID)
        {
            devID = new DeviceID();

            string pattern = "VID_([0-9A-F]{4})&PID_([0-9A-F]{4})";
            Match match = Regex.Match(input, pattern);

            if (!match.Success)
            {
                return false;
            }

            devID.Vid = UInt16.Parse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            devID.Pid = UInt16.Parse(match.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);

            return true;
        }
    }

    public class USBDeviceInfo
    {
        public USBDeviceInfo(DeviceID deviceID)
        {
            this.DeviceID = deviceID;
            //this.PnpDeviceID = pnpDeviceID;
            //this.Description = description;
        }
        public DeviceID DeviceID { get; private set; }
        //public string PnpDeviceID { get; private set; }
        //public string Description { get; private set; }
    }
}
