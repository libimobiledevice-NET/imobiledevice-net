﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="RestoreErrorExtensions.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573
#pragma warning disable 1574

namespace iMobileDevice.Restore
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public static class RestoreErrorExtensions
    {
        
        public static void ThrowOnError(this RestoreError value)
        {
            if ((value != RestoreError.Success))
            {
                throw new RestoreException(value);
            }
        }
        
        public static void ThrowOnError(this RestoreError value, string message)
        {
            if ((value != RestoreError.Success))
            {
                throw new RestoreException(value, message);
            }
        }
        
        public static bool IsError(this RestoreError value)
        {
            return (value != RestoreError.Success);
        }
    }
}
