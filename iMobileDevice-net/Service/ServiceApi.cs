//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="ServiceApi.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.Service
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class ServiceApi : IServiceApi
    {
        
        /// <summary>
        /// Backing field for the <see cref="Parent"/> property
        /// </summary>
        private ILibiMobileDevice parent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceApi"/> class
        /// </summary>
        /// <param name="parent">
        /// The <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="Service"/>.
        /// </param>
        public ServiceApi(ILibiMobileDevice parent)
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
        /// Creates a new service for the specified service descriptor.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// service_client_t upon successful return.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG when one of the arguments is invalid,
        /// or SERVICE_E_MUX_ERROR when connecting to the device failed.
        /// </returns>
        public virtual ServiceError service_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out ServiceClientHandle client)
        {
            ServiceError returnValue;
            returnValue = ServiceNativeMethods.service_client_new(device, service, out client);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Starts a new service on the specified device with given name and
        /// connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service_name">
        /// The name of the service to start.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated service_client_t
        /// upon successful return. Must be freed using service_client_free() after
        /// use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <param name="constructor_func">
        /// Constructor function for the service client to create (e.g. afc_client_new())
        /// </param>
        /// <param name="error_code">
        /// Pointer to an int32_t that will receive the service start error code.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success, or a SERVICE_E_* error code
        /// otherwise.
        /// </returns>
        public virtual ServiceError service_client_factory_start_service(iDeviceHandle device, string serviceName, ref System.IntPtr client, string label, ref ConstructorFunc constructorFunc, ref int errorCode)
        {
            return ServiceNativeMethods.service_client_factory_start_service(device, serviceName, ref client, label, ref constructorFunc, ref errorCode);
        }
        
        /// <summary>
        /// Frees a service instance.
        /// </summary>
        /// <param name="client">
        /// The service instance to free.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG when client is invalid, or a
        /// SERVICE_E_UNKNOWN_ERROR when another error occurred.
        /// </returns>
        public virtual ServiceError service_client_free(System.IntPtr client)
        {
            return ServiceNativeMethods.service_client_free(client);
        }
        
        /// <summary>
        /// Sends data using the given service client.
        /// </summary>
        /// <param name="client">
        /// The service client to use for sending.
        /// </param>
        /// <param name="data">
        /// Data to send
        /// </param>
        /// <param name="size">
        /// Size of the data to send
        /// </param>
        /// <param name="sent">
        /// Number of bytes sent (can be NULL to ignore)
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG when one or more parameters are
        /// invalid, or SERVICE_E_UNKNOWN_ERROR when an unspecified
        /// error occurs.
        /// </returns>
        public virtual ServiceError service_send(ServiceClientHandle client, byte[] data, uint size, ref uint sent)
        {
            return ServiceNativeMethods.service_send(client, data, size, ref sent);
        }
        
        /// <summary>
        /// Receives data using the given service client with specified timeout.
        /// </summary>
        /// <param name="client">
        /// The service client to use for receiving
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the data received
        /// </param>
        /// <param name="size">
        /// Number of bytes to receive
        /// </param>
        /// <param name="received">
        /// Number of bytes received (can be NULL to ignore)
        /// </param>
        /// <param name="timeout">
        /// Maximum time in milliseconds to wait for data.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG when one or more parameters are
        /// invalid, SERVICE_E_MUX_ERROR when a communication error
        /// occurs, or SERVICE_E_UNKNOWN_ERROR when an unspecified
        /// error occurs.
        /// </returns>
        public virtual ServiceError service_receive_with_timeout(ServiceClientHandle client, byte[] data, uint size, ref uint received, uint timeout)
        {
            return ServiceNativeMethods.service_receive_with_timeout(client, data, size, ref received, timeout);
        }
        
        /// <summary>
        /// Receives data using the given service client.
        /// </summary>
        /// <param name="client">
        /// The service client to use for receiving
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the data received
        /// </param>
        /// <param name="size">
        /// Number of bytes to receive
        /// </param>
        /// <param name="received">
        /// Number of bytes received (can be NULL to ignore)
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG when one or more parameters are
        /// invalid, SERVICE_E_NOT_ENOUGH_DATA when not enough data
        /// received, SERVICE_E_TIMEOUT when the connection times out,
        /// SERVICE_E_MUX_ERROR when a communication error
        /// occurs, or SERVICE_E_UNKNOWN_ERROR when an unspecified
        /// error occurs.
        /// </returns>
        public virtual ServiceError service_receive(ServiceClientHandle client, byte[] data, uint size, ref uint received)
        {
            return ServiceNativeMethods.service_receive(client, data, size, ref received);
        }
        
        /// <summary>
        /// Enable SSL for the given service client.
        /// </summary>
        /// <param name="client">
        /// The connected service client for that SSL should be enabled.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG if client or client->connection is
        /// NULL, SERVICE_E_NOT_ENOUGH_DATA when not enough data
        /// received, SERVICE_E_TIMEOUT when the connection times out,
        /// SERVICE_E_SSL_ERROR when SSL could not be enabled,
        /// or SERVICE_E_UNKNOWN_ERROR otherwise.
        /// </returns>
        public virtual ServiceError service_enable_ssl(ServiceClientHandle client)
        {
            return ServiceNativeMethods.service_enable_ssl(client);
        }
        
        /// <summary>
        /// Disable SSL for the given service client.
        /// </summary>
        /// <param name="client">
        /// The connected service client for which SSL should be disabled.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG if client or client->connection is
        /// NULL, or SERVICE_E_UNKNOWN_ERROR otherwise.
        /// </returns>
        public virtual ServiceError service_disable_ssl(ServiceClientHandle client)
        {
            return ServiceNativeMethods.service_disable_ssl(client);
        }
        
        /// <summary>
        /// Disable SSL for the given service client, optionally without sending SSL terminate messages.
        /// </summary>
        /// <param name="client">
        /// The connected service client for which SSL should be disabled.
        /// </param>
        /// <param name="sslBypass">
        /// A boolean value indicating wether to disable SSL with a proper
        /// SSL shutdown (0), or bypass the shutdown (1).
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG if client or client->connection is
        /// NULL, or SERVICE_E_UNKNOWN_ERROR otherwise.
        /// </returns>
        public virtual ServiceError service_disable_bypass_ssl(ServiceClientHandle client, char sslbypass)
        {
            return ServiceNativeMethods.service_disable_bypass_ssl(client, sslbypass);
        }
        
        /// <summary>
        /// Return a handle to the parent #idevice_connection_t of the given service client.
        /// </summary>
        /// <param name="client">
        /// The service client
        /// </param>
        /// <param name="connection">
        /// Pointer to be assigned to the #idevice_connection_t.
        /// </param>
        /// <returns>
        /// SERVICE_E_SUCCESS on success,
        /// SERVICE_E_INVALID_ARG if one or more of the arguments are invalid.
        /// </returns>
        public virtual ServiceError service_get_connection(ServiceClientHandle client, out iDeviceConnectionHandle connection)
        {
            ServiceError returnValue;
            returnValue = ServiceNativeMethods.service_get_connection(client, out connection);
            connection.Api = this.Parent;
            return returnValue;
        }
    }
}
