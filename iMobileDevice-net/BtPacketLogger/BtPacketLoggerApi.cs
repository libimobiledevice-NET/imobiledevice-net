//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="BtPacketLoggerApi.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.BtPacketLogger
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class BtPacketLoggerApi : IBtPacketLoggerApi
    {
        
        /// <summary>
        /// Backing field for the <see cref="Parent"/> property
        /// </summary>
        private ILibiMobileDevice parent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BtPacketLoggerApi"/> class
        /// </summary>
        /// <param name="parent">
        /// The <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="BtPacketLogger"/>.
        /// </param>
        public BtPacketLoggerApi(ILibiMobileDevice parent)
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
        /// Connects to the bt_packet_logger service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// bt_packet_logger_client_t upon successful return. Must be freed using
        /// bt_packet_logger_client_free() after use.
        /// </param>
        /// <returns>
        /// BT_PACKET_LOGGER_E_SUCCESS on success, BT_PACKET_LOGGER_E_INVALID_ARG when
        /// client is NULL, or an BT_PACKET_LOGGER_E_* error code otherwise.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out BtPacketLoggerClientHandle client)
        {
            BtPacketLoggerError returnValue;
            returnValue = BtPacketLoggerNativeMethods.bt_packet_logger_client_new(device, service, out client);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Starts a new bt_packet_logger service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// bt_packet_logger_client_t upon successful return. Must be freed using
        /// bt_packet_logger_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// BT_PACKET_LOGGER_E_SUCCESS on success, or an BT_PACKET_LOGGER_E_* error
        /// code otherwise.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_client_start_service(iDeviceHandle device, out BtPacketLoggerClientHandle client, string label)
        {
            BtPacketLoggerError returnValue;
            returnValue = BtPacketLoggerNativeMethods.bt_packet_logger_client_start_service(device, out client, label);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Disconnects a bt_packet_logger client from the device and frees up the
        /// bt_packet_logger client data.
        /// </summary>
        /// <param name="client">
        /// The bt_packet_logger client to disconnect and free.
        /// </param>
        /// <returns>
        /// BT_PACKET_LOGGER_E_SUCCESS on success, BT_PACKET_LOGGER_E_INVALID_ARG when
        /// client is NULL, or an BT_PACKET_LOGGER_E_* error code otherwise.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_client_free(System.IntPtr client)
        {
            return BtPacketLoggerNativeMethods.bt_packet_logger_client_free(client);
        }
        
        /// <summary>
        /// Starts capturing the hci interface from the device using a callback.
        /// Use bt_packet_logger_stop_capture() to stop receiving hci data.
        /// </summary>
        /// <param name="client">
        /// The bt_packet_logger client to use
        /// </param>
        /// <param name="callback">
        /// Callback to receive each packet from the hci interface.
        /// </param>
        /// <param name="userData">
        /// Custom pointer passed to the callback function.
        /// </param>
        /// <returns>
        /// BT_PACKET_LOGGER_E_SUCCESS on success,
        /// BT_PACKET_LOGGER_E_INVALID_ARG when one or more parameters are
        /// invalid or BT_PACKET_LOGGER_E_UNKNOWN_ERROR when an unspecified
        /// error occurs or an hci capture has already been started.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_start_capture(BtPacketLoggerClientHandle client, BtPacketLoggerReceiveCallBack callback, System.IntPtr userData)
        {
            return BtPacketLoggerNativeMethods.bt_packet_logger_start_capture(client, callback, userData);
        }
        
        /// <summary>
        /// Stops capturing the hci interface from the device.
        /// Use bt_packet_logger_start_capture() to start receiving the hci data.
        /// </summary>
        /// <param name="client">
        /// The bt_packet_logger client to use
        /// </param>
        /// <returns>
        /// BT_PACKET_LOGGER_E_SUCCESS on success,
        /// BT_PACKET_LOGGER_E_INVALID_ARG when one or more parameters are
        /// invalid or BT_PACKET_LOGGER_E_UNKNOWN_ERROR when an unspecified
        /// error occurs or an hci capture has already been started.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_stop_capture(BtPacketLoggerClientHandle client)
        {
            return BtPacketLoggerNativeMethods.bt_packet_logger_stop_capture(client);
        }
        
        /// <summary>
        /// Receives data using the given bt_packet_logger client with specified timeout.
        /// </summary>
        /// <param name="client">
        /// The bt_packet_logger client to use for receiving
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
        /// BT_PACKET_LOGGER_E_SUCCESS on success,
        /// BT_PACKET_LOGGER_E_INVALID_ARG when one or more parameters are
        /// invalid, BT_PACKET_LOGGER_E_MUX_ERROR when a communication error
        /// occurs, or BT_PACKET_LOGGER_E_UNKNOWN_ERROR when an unspecified
        /// error occurs.
        /// </returns>
        public virtual BtPacketLoggerError bt_packet_logger_receive_with_timeout(BtPacketLoggerClientHandle client, byte[] data, uint size, ref uint received, uint timeout)
        {
            return BtPacketLoggerNativeMethods.bt_packet_logger_receive_with_timeout(client, data, size, ref received, timeout);
        }
    }
}
