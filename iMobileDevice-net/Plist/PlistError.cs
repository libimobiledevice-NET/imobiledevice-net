//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="PlistErr.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.Plist
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    /// <summary>
    /// libplist error values
    /// </summary>
    public enum PlistError : int
    {
        
        ErrSuccess = 0,
        
        ErrInvalidArg = -1,
        
        ErrFormat = -2,
        
        ErrParse = -3,
        
        ErrNoMem = -4,
        
        /// <summary>
        /// an unspecified error occurred 
        /// </summary>
        ErrUnknown = -255,
    }
}