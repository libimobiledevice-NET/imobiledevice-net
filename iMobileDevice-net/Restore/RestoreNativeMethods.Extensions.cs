//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="RestoreNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.Restore
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class RestoreNativeMethods
    {
        
        public static RestoreError restored_query_type(RestoreClientHandle client, out string type, ref ulong version)
        {
            System.Runtime.InteropServices.ICustomMarshaler typeMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr typeNative = System.IntPtr.Zero;
            RestoreError returnValue = RestoreNativeMethods.restored_query_type(client, out typeNative, ref version);
            type = ((string)typeMarshaler.MarshalNativeToManaged(typeNative));
            typeMarshaler.CleanUpNativeData(typeNative);
            return returnValue;
        }
    }
}
