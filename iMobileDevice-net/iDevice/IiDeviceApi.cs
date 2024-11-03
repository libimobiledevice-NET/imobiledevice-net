//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="IiDeviceApi.cs" company="Quamotion">
// Copyright (c) 2016-2021 Quamotion. All rights reserved.
// Copyright (c) 2022-2024 Wayne Bonnici.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.iDevice
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial interface IiDeviceApi
    {
        
        /// <summary>
        /// Gets or sets the <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="iDevice"/>.
        /// </summary>
        ILibiMobileDevice Parent
        {
            get;
        }
        
        /// <summary>
        /// Sets the callback to invoke when writing out debug messages. If this callback is set, messages
        /// will be written to this callback instead of the standard output.
        /// </summary>
        /// <param name="callback">
        /// The callback which will receive the debug messages. Set to NULL to redirect to stdout.
        /// </param>
        void idevice_set_debug_callback(iDeviceDebugCallBack callback);
        
        /// <summary>
        /// Set the level of debugging.
        /// </summary>
        /// <param name="level">
        /// Set to 0 for no debug output or 1 to enable debug output.
        /// </param>
        void idevice_set_debug_level(int level);
        
        /// <summary>
        /// Subscribe a callback function that will be called when device add/remove
        /// events occur.
        /// </summary>
        /// <param name="context">
        /// A pointer to a idevice_subscription_context_t that will be
        /// set upon creation of the subscription. The returned context must be
        /// passed to idevice_events_unsubscribe() to unsubscribe the callback.
        /// </param>
        /// <param name="callback">
        /// Callback function to call.
        /// </param>
        /// <param name="userData">
        /// Application-specific data passed as parameter
        /// to the registered callback function.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_events_subscribe(out iDeviceSubscriptionContextHandle context, iDeviceEventCallBack callback, System.IntPtr userData);
        
        /// <summary>
        /// Unsubscribe the event callback function that has been registered with
        /// idevice_events_subscribe().
        /// </summary>
        /// <param name="context">
        /// A valid context as returned from idevice_events_subscribe().
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_events_unsubscribe(iDeviceSubscriptionContextHandle context);
        
        /// <summary>
        /// (DEPRECATED) Register a callback function that will be called when device add/remove
        /// events occur.
        /// </summary>
        /// <param name="callback">
        /// Callback function to call.
        /// </param>
        /// <param name="userData">
        /// Application-specific data passed as parameter
        /// to the registered callback function.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_event_subscribe(iDeviceEventCallBack callback, System.IntPtr userData);
        
        /// <summary>
        /// (DEPRECATED) Release the event callback function that has been registered with
        /// idevice_event_subscribe().
        /// </summary>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_event_unsubscribe();
        
        /// <summary>
        /// Get a list of UDIDs of currently available devices (USBMUX devices only).
        /// </summary>
        /// <param name="devices">
        /// List of UDIDs of devices that are currently available.
        /// This list is terminated by a NULL pointer.
        /// </param>
        /// <param name="count">
        /// Number of devices found.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        /// <remarks>
        /// This function only returns the UDIDs of USBMUX devices. To also include
        /// network devices in the list, use idevice_get_device_list_extended().
        /// </remarks>
        iDeviceError idevice_get_device_list(out System.Collections.ObjectModel.ReadOnlyCollection<string> devices, ref int count);
        
        /// <summary>
        /// Free a list of device UDIDs.
        /// </summary>
        /// <param name="devices">
        /// List of UDIDs to free.
        /// </param>
        /// <returns>
        /// Always returnes IDEVICE_E_SUCCESS.
        /// </returns>
        iDeviceError idevice_device_list_free(System.IntPtr devices);
        
        /// <summary>
        /// Get a list of currently available devices
        /// </summary>
        /// <param name="devices">
        /// List of idevice_info_t records with device information.
        /// This list is terminated by a NULL pointer.
        /// </param>
        /// <param name="count">
        /// Number of devices included in the list.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_get_device_list_extended(ref System.IntPtr devices, ref int count);
        
        /// <summary>
        /// Free an extended device list retrieved through idevice_get_device_list_extended().
        /// </summary>
        /// <param name="devices">
        /// Device list to free.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occurred.
        /// </returns>
        iDeviceError idevice_device_list_extended_free(System.IntPtr devices);
        
        /// <summary>
        /// Creates an idevice_t structure for the device specified by UDID,
        /// if the device is available (USBMUX devices only).
        /// </summary>
        /// <param name="device">
        /// Upon calling this function, a pointer to a location of type
        /// idevice_t. On successful return, this location will be populated.
        /// </param>
        /// <param name="udid">
        /// The UDID to match.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        /// <remarks>
        /// The resulting idevice_t structure has to be freed with
        /// idevice_free() if it is no longer used.
        /// If you need to connect to a device available via network, use
        /// idevice_new_with_options() and include IDEVICE_LOOKUP_NETWORK in options.
        /// </remarks>
        iDeviceError idevice_new(out iDeviceHandle device, string udid);
        
        /// <summary>
        /// Creates an idevice_t structure for the device specified by UDID,
        /// if the device is available, with the given lookup options.
        /// </summary>
        /// <param name="device">
        /// Upon calling this function, a pointer to a location of type
        /// idevice_t. On successful return, this location will be populated.
        /// </param>
        /// <param name="udid">
        /// The UDID to match.
        /// </param>
        /// <param name="options">
        /// Specifies what connection types should be considered
        /// when looking up devices. Accepts bitwise or'ed values of idevice_options.
        /// If 0 (no option) is specified it will default to IDEVICE_LOOKUP_USBMUX.
        /// To lookup both USB and network-connected devices, pass
        /// IDEVICE_LOOKUP_USBMUX | IDEVICE_LOOKUP_NETWORK. If a device is available
        /// both via USBMUX *and* network, it will select the USB connection.
        /// This behavior can be changed by adding IDEVICE_LOOKUP_PREFER_NETWORK
        /// to the options in which case it will select the network connection.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        /// <remarks>
        /// The resulting idevice_t structure has to be freed with
        /// idevice_free() if it is no longer used.
        /// </remarks>
        iDeviceError idevice_new_with_options(out iDeviceHandle device, string udid, int options);
        
        /// <summary>
        /// Cleans up an idevice structure, then frees the structure itself.
        /// </summary>
        /// <param name="device">
        /// idevice_t to free.
        /// </param>
        iDeviceError idevice_free(System.IntPtr device);
        
        /// <summary>
        /// Set up a connection to the given device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="port">
        /// The destination port to connect to.
        /// </param>
        /// <param name="connection">
        /// Pointer to an idevice_connection_t that will be filled
        /// with the necessary data of the connection.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_connect(iDeviceHandle device, ushort port, out iDeviceConnectionHandle connection);
        
        /// <summary>
        /// Disconnect from the device and clean up the connection structure.
        /// </summary>
        /// <param name="connection">
        /// The connection to close.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_disconnect(System.IntPtr connection);
        
        /// <summary>
        /// Send data to a device via the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to send data over.
        /// </param>
        /// <param name="data">
        /// Buffer with data to send.
        /// </param>
        /// <param name="len">
        /// Size of the buffer to send.
        /// </param>
        /// <param name="sentBytes">
        /// Pointer to an uint32_t that will be filled
        /// with the number of bytes actually sent.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_connection_send(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint sentBytes);
        
        /// <summary>
        /// Receive data from a device via the given connection.
        /// This function will return after the given timeout even if no data has been
        /// received.
        /// </summary>
        /// <param name="connection">
        /// The connection to receive data from.
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the received data.
        /// This buffer has to be large enough to hold len bytes.
        /// </param>
        /// <param name="len">
        /// Buffer size or number of bytes to receive.
        /// </param>
        /// <param name="recvBytes">
        /// Number of bytes actually received.
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds after which this function should
        /// return even if no data has been received.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_connection_receive_timeout(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint recvBytes, uint timeout);
        
        /// <summary>
        /// Receive data from a device via the given connection.
        /// This function is like idevice_connection_receive_timeout, but with a
        /// predefined reasonable timeout.
        /// </summary>
        /// <param name="connection">
        /// The connection to receive data from.
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the received data.
        /// This buffer has to be large enough to hold len bytes.
        /// </param>
        /// <param name="len">
        /// Buffer size or number of bytes to receive.
        /// </param>
        /// <param name="recvBytes">
        /// Number of bytes actually received.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_connection_receive(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint recvBytes);
        
        /// <summary>
        /// Enables SSL for the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to enable SSL for.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, IDEVICE_E_INVALID_ARG when connection
        /// is NULL or connection->ssl_data is non-NULL, or IDEVICE_E_SSL_ERROR when
        /// SSL initialization, setup, or handshake fails.
        /// </returns>
        iDeviceError idevice_connection_enable_ssl(iDeviceConnectionHandle connection);
        
        /// <summary>
        /// Disable SSL for the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to disable SSL for.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, IDEVICE_E_INVALID_ARG when connection
        /// is NULL. This function also returns IDEVICE_E_SUCCESS when SSL is not
        /// enabled and does no further error checking on cleanup.
        /// </returns>
        iDeviceError idevice_connection_disable_ssl(iDeviceConnectionHandle connection);
        
        /// <summary>
        /// Disable bypass SSL for the given connection without sending out terminate messages.
        /// </summary>
        /// <param name="connection">
        /// The connection to disable SSL for.
        /// </param>
        /// <param name="sslbypass">
        /// if true ssl connection will not be terminated but just cleaned up, allowing
        /// plain text data going on underlying connection
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, IDEVICE_E_INVALID_ARG when connection
        /// is NULL. This function also returns IDEVICE_E_SUCCESS when SSL is not
        /// enabled and does no further error checking on cleanup.
        /// </returns>
        iDeviceError idevice_connection_disable_bypass_ssl(iDeviceConnectionHandle connection, char sslbypass);
        
        /// <summary>
        /// Get the underlying file descriptor for a connection
        /// </summary>
        /// <param name="connection">
        /// The connection to get fd of
        /// </param>
        /// <param name="fd">
        /// Pointer to an int where the fd is stored
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        iDeviceError idevice_connection_get_fd(iDeviceConnectionHandle connection, ref int fd);
        
        /// <summary>
        /// Gets the handle or (USBMUX device id) of the device.
        /// </summary>
        /// <param name="device">
        /// The device to get the USBMUX device id for.
        /// </param>
        /// <param name="handle">
        /// Pointer to a uint32_t that will be set to the USBMUX handle value.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, otherwise an error code.
        /// </returns>
        iDeviceError idevice_get_handle(iDeviceHandle device, ref uint handle);
        
        /// <summary>
        /// Gets the Unique Device ID for the device.
        /// </summary>
        /// <param name="device">
        /// The device to get the Unique Device ID for.
        /// </param>
        /// <param name="udid">
        /// Pointer that will be set to an allocated buffer with the device UDID. The consumer is responsible for releasing the allocated memory.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, otherwise an error code.
        /// </returns>
        iDeviceError idevice_get_udid(iDeviceHandle device, out string udid);
        
        /// <summary>
        /// Returns a static string of the libimobiledevice version.
        /// </summary>
        /// <returns>
        /// The libimobiledevice version as static ascii string
        /// </returns>
        System.IntPtr libimobiledevice_version();
        
        /// <summary>
        /// Sets the socket type (Unix socket or TCP socket) libimobiledevice should use when connecting
        /// to usbmuxd.
        /// </summary>
        /// <param name="value">
        /// IDEVICE_SOCKET_TYPE_UNIX or IDEVICE_SOCKET_TYPE_TCP
        /// </param>
        /// <returns>
        /// 0 on success or negative on error
        /// </returns>
        iDeviceError idevice_set_socket_type(int value);
        
        /// <summary>
        /// Gets the socket type (Unix socket or TCP socket) libimobiledevice should use when connecting
        /// to usbmuxd.
        /// </summary>
        /// <param name="value">
        /// A pointer to an integer which will reveive the current socket type
        /// </param>
        /// <returns>
        /// 0 on success or negative on error
        /// </returns>
        iDeviceError idevice_get_socket_type(ref int value);
        
        /// <summary>
        /// Sets the TCP endpoint to which libimobiledevice will connect if the socket type is set to
        /// SOCKET_TYPE_TCP
        /// </summary>
        /// <param name="host">
        /// The hostname or IP address to which to connect
        /// </param>
        /// <param name="port">
        /// The port to which to connect.
        /// </param>
        /// <returns>
        /// 0 on success or negative on error
        /// </returns>
        iDeviceError idevice_set_tcp_endpoint(string host, ushort port);
        
        /// <summary>
        /// Gets the TCP endpoint to which libimobiledevice will connect if the socket type is set to
        /// SOCKET_TYPE_TCP
        /// </summary>
        /// <param name="host">
        /// A pointer which will be set to the hostname or IP address to which to connect.
        /// The caller must free this string.
        /// </param>
        /// <param name="port">
        /// The port to which to connect
        /// </param>
        /// <returns>
        /// 0 on success or negative on error
        /// </returns>
        iDeviceError idevice_get_tcp_endpoint(out string host, ref ushort port);
    }
}
