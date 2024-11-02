//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="PropertyListServiceNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.PropertyListService
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class PropertyListServiceNativeMethods
    {
        
        public const string LibraryName = "libimobiledevice";
        
        static PropertyListServiceNativeMethods()
        {
            LibraryResolver.EnsureRegistered();
        }
        
        /// <summary>
        /// Creates a new property list service for the specified port.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// property_list_service_client_t upon successful return.
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when one of the arguments is invalid,
        /// or PROPERTY_LIST_SERVICE_E_MUX_ERROR when connecting to the device failed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_client_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out PropertyListServiceClientHandle client);
        
        /// <summary>
        /// Frees a PropertyList service.
        /// </summary>
        /// <param name="client">
        /// The property list service to free.
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when client is invalid, or a
        /// PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR when another error occurred.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_client_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_client_free(System.IntPtr client);
        
        /// <summary>
        /// Sends an XML plist.
        /// </summary>
        /// <param name="client">
        /// The property list service client to use for sending.
        /// </param>
        /// <param name="plist">
        /// plist to send
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when client or plist is NULL,
        /// PROPERTY_LIST_SERVICE_E_PLIST_ERROR when dict is not a valid plist,
        /// or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR when an unspecified error occurs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_send_xml_plist", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_send_xml_plist(PropertyListServiceClientHandle client, PlistHandle plist);
        
        /// <summary>
        /// Sends a binary plist.
        /// </summary>
        /// <param name="client">
        /// The property list service client to use for sending.
        /// </param>
        /// <param name="plist">
        /// plist to send
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when client or plist is NULL,
        /// PROPERTY_LIST_SERVICE_E_PLIST_ERROR when dict is not a valid plist,
        /// or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR when an unspecified error occurs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_send_binary_plist", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_send_binary_plist(PropertyListServiceClientHandle client, PlistHandle plist);
        
        /// <summary>
        /// Receives a plist using the given property list service client with specified
        /// timeout.
        /// Binary or XML plists are automatically handled.
        /// </summary>
        /// <param name="client">
        /// The property list service client to use for receiving
        /// </param>
        /// <param name="plist">
        /// pointer to a plist_t that will point to the received plist
        /// upon successful return
        /// </param>
        /// <param name="timeout">
        /// Maximum time in milliseconds to wait for data.
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when connection or *plist is NULL,
        /// PROPERTY_LIST_SERVICE_E_PLIST_ERROR when the received data cannot be
        /// converted to a plist, PROPERTY_LIST_SERVICE_E_MUX_ERROR when a
        /// communication error occurs, or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR when
        /// an unspecified error occurs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_receive_plist_with_timeout", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_receive_plist_with_timeout(PropertyListServiceClientHandle client, out PlistHandle plist, uint timeout);
        
        /// <summary>
        /// Receives a plist using the given property list service client.
        /// Binary or XML plists are automatically handled.
        /// This function is like property_list_service_receive_plist_with_timeout
        /// using a timeout of 10 seconds.
        /// </summary>
        /// <param name="client">
        /// The property list service client to use for receiving
        /// </param>
        /// <param name="plist">
        /// pointer to a plist_t that will point to the received plist
        /// upon successful return
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG when client or *plist is NULL,
        /// PROPERTY_LIST_SERVICE_E_NOT_ENOUGH_DATA when not enough data
        /// received, PROPERTY_LIST_SERVICE_E_RECEIVE_TIMEOUT when the connection times out,
        /// PROPERTY_LIST_SERVICE_E_PLIST_ERROR when the received data cannot be
        /// converted to a plist, PROPERTY_LIST_SERVICE_E_MUX_ERROR when a
        /// communication error occurs, or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR when
        /// an unspecified error occurs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_receive_plist", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_receive_plist(PropertyListServiceClientHandle client, out PlistHandle plist);
        
        /// <summary>
        /// Enable SSL for the given property list service client.
        /// </summary>
        /// <param name="client">
        /// The connected property list service client for which SSL
        /// should be enabled.
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG if one or more of the arguments are invalid,
        /// PROPERTY_LIST_SERVICE_E_SSL_ERROR when SSL could not be enabled,
        /// or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_enable_ssl", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_enable_ssl(PropertyListServiceClientHandle client);
        
        /// <summary>
        /// Disable SSL for the given property list service client.
        /// </summary>
        /// <param name="client">
        /// The connected property list service client for which SSL
        /// should be disabled.
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG if one or more of the arguments are invalid,
        /// or PROPERTY_LIST_SERVICE_E_UNKNOWN_ERROR otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_disable_ssl", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_disable_ssl(PropertyListServiceClientHandle client);
        
        /// <summary>
        /// Return a handle to the parent #service_client_t of the given property list service client.
        /// </summary>
        /// <param name="client">
        /// The property list service client
        /// </param>
        /// <param name="service_client">
        /// Pointer to be assigned to the parent #service_client_t
        /// </param>
        /// <returns>
        /// PROPERTY_LIST_SERVICE_E_SUCCESS on success,
        /// PROPERTY_LIST_SERVICE_E_INVALID_ARG if one or more of the arguments are invalid.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(PropertyListServiceNativeMethods.LibraryName, EntryPoint="property_list_service_get_service_client", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PropertyListServiceError property_list_service_get_service_client(PropertyListServiceClientHandle client, ref System.IntPtr serviceClient);
    }
}
