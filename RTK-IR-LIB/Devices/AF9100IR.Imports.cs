using System;
using System.Runtime.InteropServices;

namespace RtkIRLib
{
    partial class AF9100IR
    {
        private const string AF9100EXDLL = "AF9100EX.dll";

        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_GetDrvInfo();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_GetSignalStrength(
            out IntPtr i);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_GetVitBER();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_PowerCtl();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_Read15IR();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_Read15IR(
            byte[] intptr);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_ReadEEPROM(
            out IntPtr i);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_ReadEEPROM(
            int offSet, int buff_len, out byte[] b);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_ReadLinkReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_ReadOFDMReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_ReadSlaveReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_WriteLinkReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_WriteOFDMReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int af9100_WriteSlaveReg();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_init();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_initIRDev();
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_ReadRawIR(
            IntPtr intptr);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_ReadRawIR(
            byte[] intptr);
        [DllImport(AF9100EXDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool af9100_exit();
    }
}
