//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="CompanionProxyApi.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.CompanionProxy
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class CompanionProxyApi : ICompanionProxyApi
    {
        
        /// <summary>
        /// Backing field for the <see cref="Parent"/> property
        /// </summary>
        private ILibiMobileDevice parent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanionProxyApi"/> class
        /// </summary>
        /// <param name="parent">
        /// The <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="CompanionProxy"/>.
        /// </param>
        public CompanionProxyApi(ILibiMobileDevice parent)
        {
            this.parent = parent;
        }
        
        /// <inheritdoc/>
        public ILibiMobileDevice Parent
        {
            get
            {
                return this.parent;
            }
        }
        
        /// <summary>
        /// Connects to the companion_proxy service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// companion_proxy_client_t upon successful return. Must be freed using
        /// companion_proxy_client_free() after use.
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success, COMPANION_PROXY_E_INVALID_ARG when
        /// the arguments are invalid, or an COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out CompanionProxyClientHandle client)
        {
            CompanionProxyError returnValue;
            returnValue = CompanionProxyNativeMethods.companion_proxy_client_new(device, service, out client);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Starts a new companion_proxy service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// companion_proxy_client_t upon successful return. Must be freed using
        /// companion_proxy_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success, or an COMPANION_PROXY_E_* error
        /// code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_client_start_service(iDeviceHandle device, out CompanionProxyClientHandle client, string label)
        {
            CompanionProxyError returnValue;
            returnValue = CompanionProxyNativeMethods.companion_proxy_client_start_service(device, out client, label);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Disconnects a companion_proxy client from the device and frees up the
        /// companion_proxy client data.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client to disconnect and free.
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success, COMPANION_PROXY_E_INVALID_ARG when
        /// client is NULL, or an COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_client_free(System.IntPtr client)
        {
            return CompanionProxyNativeMethods.companion_proxy_client_free(client);
        }
        
        /// <summary>
        /// Sends a plist to the service.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="plist">
        /// The plist to send
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// COMPANION_PROXY_E_INVALID_ARG when client or plist is NULL
        /// </returns>
        public virtual CompanionProxyError companion_proxy_send(CompanionProxyClientHandle client, PlistHandle plist)
        {
            return CompanionProxyNativeMethods.companion_proxy_send(client, plist);
        }
        
        /// <summary>
        /// Receives a plist from the service.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="plist">
        /// The plist to store the received data
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// COMPANION_PROXY_E_INVALID_ARG when client or plist is NULL
        /// </returns>
        public virtual CompanionProxyError companion_proxy_receive(CompanionProxyClientHandle client, out PlistHandle plist)
        {
            CompanionProxyError returnValue;
            returnValue = CompanionProxyNativeMethods.companion_proxy_receive(client, out plist);
            plist.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Retrieves a list of paired devices.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="pairedDevices">
        /// Point that will receive a PLIST_ARRAY with paired device UDIDs
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// COMPANION_PROXY_E_NO_DEVICES if no devices are paired,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        /// <remarks>
        /// The device closes the connection after sending the reply.
        /// </remarks>
        public virtual CompanionProxyError companion_proxy_get_device_registry(CompanionProxyClientHandle client, out PlistHandle pairedDevices)
        {
            CompanionProxyError returnValue;
            returnValue = CompanionProxyNativeMethods.companion_proxy_get_device_registry(client, out pairedDevices);
            pairedDevices.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Starts listening for paired devices.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="callback">
        /// Callback function that will be called when a new device is detected
        /// </param>
        /// <param name="userdata">
        /// Pointer that that will be passed to the callback function
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        /// <remarks>
        /// The event parameter that gets passed to the callback function is
        /// freed internally after returning from the callback. The consumer needs
        /// to make a copy if required.
        /// </remarks>
        public virtual CompanionProxyError companion_proxy_start_listening_for_devices(CompanionProxyClientHandle client, CompanionProxyDeviceEventCallBack callback, System.IntPtr userdata)
        {
            return CompanionProxyNativeMethods.companion_proxy_start_listening_for_devices(client, callback, userdata);
        }
        
        /// <summary>
        /// Stops listening for paired devices
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_stop_listening_for_devices(CompanionProxyClientHandle client)
        {
            return CompanionProxyNativeMethods.companion_proxy_stop_listening_for_devices(client);
        }
        
        /// <summary>
        /// Returns a value for the given key.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="companionUdid">
        /// UDID of the (paired) companion device
        /// </param>
        /// <param name="key">
        /// The key to retrieve the value for
        /// </param>
        /// <param name="value">
        /// A pointer to a plist_t that will receive the value for the given key.
        /// The consumer is responsible for freeing the value with plist_free() when no longer needed.
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// COMPANION_PROXY_E_INVALID_ARG when client or paired_devices is invalid,
        /// COMPANION_PROXY_E_UNSUPPORTED_KEY if the companion device doesn't support the given key,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        /// <remarks>
        /// The device closes the connection after sending the reply.
        /// </remarks>
        public virtual CompanionProxyError companion_proxy_get_value_from_registry(CompanionProxyClientHandle client, string companionUdid, string key, out PlistHandle value)
        {
            CompanionProxyError returnValue;
            returnValue = CompanionProxyNativeMethods.companion_proxy_get_value_from_registry(client, companionUdid, key, out value);
            value.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Start forwarding a service port on the companion device to a port on the idevice.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="remotePort">
        /// remote port
        /// </param>
        /// <param name="serviceName">
        /// The name of the service that shall be forwarded
        /// </param>
        /// <param name="forwardPort">
        /// Pointer that will receive the newly-assigned port accessible via USB/Network on the idevice
        /// </param>
        /// <param name="options">
        /// PLIST_DICT with additional options. Currently known are
        /// IsServiceLowPriority (boolean) and PreferWifi (boolean).
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_start_forwarding_service_port(CompanionProxyClientHandle client, ushort remotePort, string serviceName, ref ushort forwardPort, PlistHandle options)
        {
            return CompanionProxyNativeMethods.companion_proxy_start_forwarding_service_port(client, remotePort, serviceName, ref forwardPort, options);
        }
        
        /// <summary>
        /// Stop forwarding a service port between companion device and idevice.
        /// </summary>
        /// <param name="client">
        /// The companion_proxy client
        /// </param>
        /// <param name="remotePort">
        /// remote port
        /// </param>
        /// <returns>
        /// COMPANION_PROXY_E_SUCCESS on success,
        /// or a COMPANION_PROXY_E_* error code otherwise.
        /// </returns>
        public virtual CompanionProxyError companion_proxy_stop_forwarding_service_port(CompanionProxyClientHandle client, ushort remotePort)
        {
            return CompanionProxyNativeMethods.companion_proxy_stop_forwarding_service_port(client, remotePort);
        }
    }
}
