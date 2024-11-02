//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="LockdownCuPairingCallBackType.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.Lockdown
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    /// <summary>
    /// Callback types used in #lockdownd_cu_pairing_cb_t 
    /// </summary>
    public enum LockdownCuPairingCallBackType : int
    {
        
        PinRequested = 0,
        
        DeviceInfo = 1,
        
        /// <summary>
        /// pairing error message available: data_ptr is a NULL-terminated char* buffer containing the error message, and data_size is ignored. Buffer needs to be copied if it shall persist outside the callback. 
        /// </summary>
        Error = 2,
    }
}
