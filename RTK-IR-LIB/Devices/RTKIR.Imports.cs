using System;
using System.Runtime.InteropServices;
namespace RtkIRLib
{
    partial class RTKIR
    {
        public enum IRType
        {
            RC6 = 0,
            RC5,
            NEC
        }

        private const string RTL283XDLL = "RTL283XAccess.dll";

        [DllImport(RTL283XDLL, EntryPoint = "RTK_BDAFilterInit", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_BDAFilterInit(IntPtr hDlgHandle);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_BDAFilterRelease", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_BDAFilterRelease(IntPtr hDlgHandle);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_DeviceIsOnProcess", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_DeviceIsOnProcess();

        [DllImport(RTL283XDLL, EntryPoint = "RTK_DeviceIsOffProcess", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_DeviceIsOffProcess();

        [DllImport(RTL283XDLL, EntryPoint = "RTK_HaveAtLeastOneDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_HaveAtLeastOneDevice();

        [DllImport(RTL283XDLL, EntryPoint = "RTK_DeviceIsOk", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_DeviceIsOk();

        [DllImport(RTL283XDLL, EntryPoint = "RTK_Demod_Byte_Read", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_Demod_Byte_Read(byte page, ushort offset, uint length, [MarshalAs(UnmanagedType.LPArray)] byte[] data);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_Get_Suspend_Status", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_Get_Suspend_Status(out bool status);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_I2C_Read", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_I2C_Read(byte baseaddress, ushort offset, uint length, byte[] data);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_I2C_Read", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_I2C_Read(byte baseinterface, byte baseaddress, byte[] data, uint length);

        //[DllImport(RTL283XDLL, EntryPoint = "RTK_IR_Read", CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool RTK_IR_Read(ushort address, uint length, byte* data);

        //[DllImport(RTL283XDLL, EntryPoint = "RTK_IR_Write", CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool RTK_IR_Write(ushort address, uint length, byte* data);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_InitialAPModeIRParameter", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_InitialAPModeIRParameter();

        //[DllImport(RTL283XDLL, EntryPoint = "RTK_GetAPModeIRCode", CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool RTK_GetAPModeIRCode(out ushort irSingle, byte* irCode, uint length);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_GetAPModeIRCode", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_GetAPModeIRCode(out ushort received, byte[] irCode, uint length);

        //[DllImport(RTL283XDLL, EntryPoint = "RTK_GetAPModeIRCurrentIRType", CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool RTK_GetAPModeIRCurrentIRType(byte* irType);

        [DllImport(RTL283XDLL, EntryPoint = "RTK_GetAPModeIRCurrentIRType", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RTK_GetAPModeIRCurrentIRType(byte[] irType);
    }
}
