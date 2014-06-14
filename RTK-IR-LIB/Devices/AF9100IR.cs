using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
namespace RtkIRLib
{
    public partial class AF9100IR : IIRDevice
    {
        /// <summary>
        /// TODO: whats with AF15IRTBL.bin in C:\Windows\System32???
        /// 
        /// </summary>

        public byte[] irCodeBytes = new byte[4];

        public DeviceID DeviceID
        {
            get;
            set;
        }

        public AF9100IR(DeviceID deviceID)
        {
            this.DeviceID = deviceID;
        }

        public bool TryInitIRDevice()
        {
            // TODO: is af9100_init required?
            if (!af9100_init())
            {
                Debug.WriteLine("Failed to initialize device");
                //return false;
            }

            if (!af9100_initIRDev())
            {
                Debug.WriteLine("Failed to initialize IR device");
                //return false;
            }
            return true;
        }

        public bool TryUnInitIRDevice()
        {
            return !af9100_exit();
        }

        // af9100_ReadRawIR
        //  DVB_SetDEVData
        //  0           -   ok
        //  DVB_GetDEVData
        //  8007001f    -   error
        //  0           -   IR Code received        
        // af9100_ReadRawIR
        //  1           -   failed
        //  0           -   success
        public bool TryReadIRCode(uint maskCode, out int irCode)
        {
            //irCodeBytes = new byte[4];
            if (!af9100_ReadRawIR(irCodeBytes))
            {
                irCode = (int)(BitConverter.ToUInt32(irCodeBytes, 0) & maskCode);
                return true;
            }

            irCode = 0;
            return false;
        }

        //public bool TryReadIRCode(uint maskCode, out int irCode)
        //{
        //    byte[] irCodeBytes = new byte[4];
        //    IntPtr p = Marshal.AllocHGlobal(irCodeBytes.Length);
        //    Marshal.Copy(irCodeBytes, 0, p, irCodeBytes.Length);
        //    bool res = !af9100_ReadRawIR(p);
        //    Marshal.FreeHGlobal(p);
        //    if (res)
        //    {
        //        irCode = (int)(BitConverter.ToUInt32(irCodeBytes, 0) & maskCode);
        //        return true;
        //    }

        //    irCode = 0;
        //    return false;
        //}

        //public void GetInfo()
        //{
        //    byte[] buf = new byte[4];
        //    Debug.WriteLine(af9100_GetDrvInfo(buf));
        //    Debug.WriteLine(Encoding.ASCII.GetString(buf));
        //}


        public DeviceType DeviceType
        {
            get { return DeviceType.AF9100IR; }
        }
    }
}
