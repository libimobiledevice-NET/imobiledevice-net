//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="MobileSyncAnchors.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.MobileSync
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MobileSyncAnchors
    {
        
        public System.IntPtr device_anchor;
        
        public System.IntPtr computer_anchor;
        
        public string device_anchorString
        {
            get
            {
                return Utf8Marshal.PtrToStringUtf8(this.device_anchor);
            }
        }
        
        public string computer_anchorString
        {
            get
            {
                return Utf8Marshal.PtrToStringUtf8(this.computer_anchor);
            }
        }
    }
}
