//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="PlistType.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
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
    /// The enumeration of plist node types.
    /// </summary>
    public enum PlistType : int
    {
        
        None = -1,
        
        Boolean = 0,
        
        Int = 1,
        
        Real = 2,
        
        String = 3,
        
        Array = 4,
        
        Dict = 5,
        
        Date = 6,
        
        Data = 7,
        
        Key = 8,
        
        Uid = 9,
        
        Null = 10,
    }
}
