using System;
using System.Collections.Generic;
namespace RtkIRLib
{
    public interface IIRDevice
    {
        DeviceType DeviceType { get; }

        /// <summary>
        /// Contains the VID and PID of the device.
        /// </summary>
        DeviceID DeviceID { get; set; }

        /// <summary>
        /// Tries to initialize the Infra Red device. A return value indicates whether the initialization succeeded.
        /// </summary>
        bool TryInitIRDevice();

        /// <summary>
        /// Tries to uninitialize the Infra Red device. A return value indicates whether the uninitialization succeeded.
        /// </summary>
        bool TryUnInitIRDevice();

        /// <summary>
        /// Tries to read the IR code. A return value indicates whether the operation succeeded.
        /// </summary>
        bool TryReadIRCode(uint maskCode, out int irCode);

    }

    public enum DeviceType
    {
        /// <summary>
        /// Realtek 2832U
        /// </summary>
        RTKIR,

        /// <summary>
        /// Afatek/ITE 91xx
        /// </summary>
        AF9100IR
    }
}
