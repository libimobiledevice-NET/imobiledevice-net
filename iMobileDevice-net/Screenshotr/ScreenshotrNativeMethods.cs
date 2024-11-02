//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="ScreenshotrNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.Screenshotr
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class ScreenshotrNativeMethods
    {
        
        public const string LibraryName = "libimobiledevice";
        
        static ScreenshotrNativeMethods()
        {
            LibraryResolver.EnsureRegistered();
        }
        
        /// <summary>
        /// Connects to the screenshotr service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// screenshotr_client_t upon successful return.
        /// </param>
        /// <returns>
        /// SCREENSHOTR_E_SUCCESS on success, SCREENSHOTR_E_INVALID ARG if one
        /// or more parameters are invalid, or SCREENSHOTR_E_CONN_FAILED if the
        /// connection to the device could not be established.
        /// </returns>
        /// <remarks>
        /// This service is only available if a developer disk image has been
        /// mounted.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute(ScreenshotrNativeMethods.LibraryName, EntryPoint="screenshotr_client_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern ScreenshotrError screenshotr_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out ScreenshotrClientHandle client);
        
        /// <summary>
        /// Starts a new screenshotr service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// screenshotr_client_t upon successful return. Must be freed using
        /// screenshotr_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// SCREENSHOTR_E_SUCCESS on success, or an SCREENSHOTR_E_* error
        /// code otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(ScreenshotrNativeMethods.LibraryName, EntryPoint="screenshotr_client_start_service", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern ScreenshotrError screenshotr_client_start_service(iDeviceHandle device, out ScreenshotrClientHandle client, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string label);
        
        /// <summary>
        /// Disconnects a screenshotr client from the device and frees up the
        /// screenshotr client data.
        /// </summary>
        /// <param name="client">
        /// The screenshotr client to disconnect and free.
        /// </param>
        /// <returns>
        /// SCREENSHOTR_E_SUCCESS on success, or SCREENSHOTR_E_INVALID_ARG
        /// if client is NULL.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(ScreenshotrNativeMethods.LibraryName, EntryPoint="screenshotr_client_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern ScreenshotrError screenshotr_client_free(System.IntPtr client);
        
        /// <summary>
        /// Get a screen shot from the connected device.
        /// </summary>
        /// <param name="client">
        /// The connection screenshotr service client.
        /// </param>
        /// <param name="imgdata">
        /// Pointer that will point to a newly allocated buffer
        /// containing TIFF image data upon successful return. It is up to the
        /// caller to free the memory.
        /// </param>
        /// <param name="imgsize">
        /// Pointer to a uint64_t that will be set to the size of the
        /// buffer imgdata points to upon successful return.
        /// </param>
        /// <returns>
        /// SCREENSHOTR_E_SUCCESS on success, SCREENSHOTR_E_INVALID_ARG if
        /// one or more parameters are invalid, or another error code if an
        /// error occurred.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(ScreenshotrNativeMethods.LibraryName, EntryPoint="screenshotr_take_screenshot", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern ScreenshotrError screenshotr_take_screenshot(ScreenshotrClientHandle client, ref System.IntPtr imgdata, ref ulong imgsize);
        
        /// <summary>
        /// Frees the memory used by a screen shot
        /// </summary>
        /// <param name="imgdata">
        /// The screenshot
        /// </param>
        /// <returns>
        /// SCREENSHOTR_E_SUCCESS on success
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(ScreenshotrNativeMethods.LibraryName, EntryPoint="screenshotr_screenshot_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern ScreenshotrError screenshotr_screenshot_free(System.IntPtr imgdata);
    }
}
