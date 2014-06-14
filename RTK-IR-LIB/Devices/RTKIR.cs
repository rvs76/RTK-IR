using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
namespace RtkIRLib
{
    public partial class RTKIR : IIRDevice
    {
        public DeviceID DeviceID { get; set; }

        public RTKIR(DeviceID deviceID)
        {
            this.DeviceID = deviceID;
        }

        public bool TryInitIRDevice()
        {
            // Initialize RTK BDA Filter
            if (!RTK_BDAFilterInit(IntPtr.Zero))
            {
                Debug.WriteLine("Failed to initialize RTK BDA Filter");
                return false;
            }

            if (!RTK_DeviceIsOnProcess())
            {
                Debug.WriteLine("Failed to start device");
                return false;
            }

            // Initialize IR
            if (!RTK_InitialAPModeIRParameter())
            {
                Debug.WriteLine("Failed to initialize IR");
                return false;
            }

            return true;
        }

        public bool TryUnInitIRDevice()
        {
            if (!RTK_DeviceIsOffProcess())
            {
                return false;
            }

            return RTK_BDAFilterRelease(IntPtr.Zero);
        }

        public bool TryReadIRCode(uint maskCode, out int irCode)
        {
            ushort irSingle;
            byte[] irCodeBytes = new byte[4];

            // Read the IR code
            if (RTK_GetAPModeIRCode(out irSingle, irCodeBytes, (uint)irCodeBytes.Length))
            {
                // IR code received
                if (irSingle == 1)
                {
                    irCodeBytes = irCodeBytes.ReverseBits();
                    irCode = (int)(BitConverter.ToUInt32(irCodeBytes, 0) & maskCode);
                    return true;
                }
            }

            irCode = 0;
            return false;
        }

        /// <summary>
        /// Alternative method to read ir code.
        /// </summary>
        /// <param name="maskCode"></param>
        /// <param name="irCode"></param>
        /// <returns></returns>
        public bool TryNativeReadIRCode(uint maskCode, out int irCode)
        {
            bool status;
            byte[] irCodeBytes = new byte[4];

            // Check device status
            if (RTK_Get_Suspend_Status(out status) && status)
            {
                // Read the IR code
                if (RTK_Demod_Byte_Read(22, 1, 4, irCodeBytes))
                {
                    irCodeBytes = irCodeBytes.ReverseBits();
                    irCode = (int)(BitConverter.ToUInt32(irCodeBytes, 0) & maskCode);

                    if (irCode != 0)
                    {
                        return true;   
                    }
                }
            }
            irCode = 0;
            return false;
        }

        public bool TryReadInfo(out string info)
        {
            byte[] infoBytes = new byte[128];
            if (RTK_I2C_Read(0, 0x20, 33, infoBytes))
            {
                Console.WriteLine(infoBytes[0]);
                Console.WriteLine(infoBytes[55]);
                info = Encoding.ASCII.GetString(infoBytes);
                return true;    
            }
            info = String.Empty;
            return false;
        }

        /// <summary>
        /// Gets the IR type of the connected device.
        /// </summary>
        //public IRType IRType
        //{
        //    get 
        //    {
        //        byte[] irType = new byte[1];
        //        RTK_GetAPModeIRCurrentIRType(irType);
        //        return (IRType)irType[0]; 
        //    }
        //}

        public DeviceType DeviceType
        {
            get { return DeviceType.RTKIR; }
        }
    }
}
