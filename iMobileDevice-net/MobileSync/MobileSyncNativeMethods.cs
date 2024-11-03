//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="MobileSyncNativeMethods.cs" company="Quamotion">
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
    
    
    public partial class MobileSyncNativeMethods
    {
        
        public const string LibraryName = "libimobiledevice";
        
        static MobileSyncNativeMethods()
        {
            LibraryResolver.EnsureRegistered();
        }
        
        /// <summary>
        /// Connects to the mobilesync service on the specified device.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one or more parameters are invalid
        /// DEVICE_LINK_SERVICE_E_BAD_VERSION if the mobilesync version on
        /// the device is newer.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// #mobilesync_client_t upon successful return.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_client_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out MobileSyncClientHandle client);
        
        /// <summary>
        /// Starts a new mobilesync service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// mobilesync_client_t upon successful return. Must be freed using
        /// mobilesync_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// MOBILESYNC_E_SUCCESS on success, or an MOBILESYNC_E_* error
        /// code otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_client_start_service", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_client_start_service(iDeviceHandle device, out MobileSyncClientHandle client, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string label);
        
        /// <summary>
        /// Disconnects a mobilesync client from the device and frees up the
        /// mobilesync client data.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if
        /// is NULL.
        /// </summary>
        /// <param name="client">
        /// The mobilesync client to disconnect and free.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_client_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_client_free(System.IntPtr client);
        
        /// <summary>
        /// Polls the device for mobilesync data.
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="plist">
        /// A pointer to the location where the plist should be stored
        /// </param>
        /// <returns>
        /// an error code
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_receive", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_receive(MobileSyncClientHandle client, out PlistHandle plist);
        
        /// <summary>
        /// Sends mobilesync data to the device
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="plist">
        /// The location of the plist to send
        /// </param>
        /// <returns>
        /// an error code
        /// </returns>
        /// <remarks>
        /// This function is low-level and should only be used if you need to send
        /// a new type of message.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_send", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_send(MobileSyncClientHandle client, PlistHandle plist);
        
        /// <summary>
        /// Requests starting synchronization of a data class with the device
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_PLIST_ERROR if the received plist is not of valid form
        /// MOBILESYNC_E_SYNC_REFUSED if the device refused to sync
        /// MOBILESYNC_E_CANCELLED if the device explicitly cancelled the
        /// sync request
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="dataClass">
        /// The data class identifier to sync
        /// </param>
        /// <param name="anchors">
        /// The anchors required to exchange with the device. The anchors
        /// allow the device to tell if the synchronization information on the computer
        /// and device are consistent to determine what sync type is required.
        /// </param>
        /// <param name="computerDataClassVersion">
        /// The version of the data class storage on the computer
        /// </param>
        /// <param name="syncType">
        /// A pointer to store the sync type reported by the device_anchor
        /// </param>
        /// <param name="deviceDataClassVersion">
        /// The version of the data class storage on the device
        /// </param>
        /// <param name="errorDescription">
        /// A pointer to store an error message if reported by the device
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_start", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_start(MobileSyncClientHandle client, byte[] dataClass, MobileSyncAnchorsHandle anchors, ulong computerDataClassVersion, ref MobileSyncSyncType syncType, ref ulong deviceDataClassVersion, out System.IntPtr errorDescription);
        
        /// <summary>
        /// Cancels a running synchronization session with a device at any time.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="reason">
        /// The reason to supply to the device for cancelling
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_cancel", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_cancel(MobileSyncClientHandle client, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string reason);
        
        /// <summary>
        /// Finish a synchronization session of a data class on the device.
        /// A session must have previously been started using mobilesync_start().
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_PLIST_ERROR if the received plist is not of valid
        /// form
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_finish", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_finish(MobileSyncClientHandle client);
        
        /// <summary>
        /// Requests to receive all records of the currently set data class from the device.
        /// The actually changes are retrieved using mobilesync_receive_changes() after this
        /// request has been successful.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_get_all_records_from_device", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_get_all_records_from_device(MobileSyncClientHandle client);
        
        /// <summary>
        /// Requests to receive only changed records of the currently set data class from the device.
        /// The actually changes are retrieved using mobilesync_receive_changes() after this
        /// request has been successful.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_get_changes_from_device", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_get_changes_from_device(MobileSyncClientHandle client);
        
        /// <summary>
        /// Requests the device to delete all records of the current data class
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_PLIST_ERROR if the received plist is not of valid form
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <remarks>
        /// The operation must be called after starting synchronization.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_clear_all_records_on_device", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_clear_all_records_on_device(MobileSyncClientHandle client);
        
        /// <summary>
        /// Receives changed entitites of the currently set data class from the device
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_CANCELLED if the device explicitly cancelled the
        /// session
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="entities">
        /// A pointer to store the changed entity records as a PLIST_DICT
        /// </param>
        /// <param name="isLastRecord">
        /// A pointer to store a flag indicating if this submission is the last one
        /// </param>
        /// <param name="actions">
        /// A pointer to additional flags the device is sending or NULL to ignore
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_receive_changes", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_receive_changes(MobileSyncClientHandle client, out PlistHandle entities, ref char isLastRecord, out PlistHandle actions);
        
        /// <summary>
        /// Acknowledges to the device that the changes have been merged on the computer
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_acknowledge_changes_from_device", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_acknowledge_changes_from_device(MobileSyncClientHandle client);
        
        /// <summary>
        /// Verifies if the device is ready to receive changes from the computer.
        /// This call changes the synchronization direction so that mobilesync_send_changes()
        /// can be used to send changes to the device.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_PLIST_ERROR if the received plist is not of valid form
        /// MOBILESYNC_E_WRONG_DIRECTION if the current sync direction does
        /// not permit this call
        /// MOBILESYNC_E_CANCELLED if the device explicitly cancelled the
        /// session
        /// MOBILESYNC_E_NOT_READY if the device is not ready to start
        /// receiving any changes
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_ready_to_send_changes_from_computer", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_ready_to_send_changes_from_computer(MobileSyncClientHandle client);
        
        /// <summary>
        /// Sends changed entities of the currently set data class to the device
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid,
        /// MOBILESYNC_E_WRONG_DIRECTION if the current sync direction does
        /// not permit this call
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="entities">
        /// The changed entity records as a PLIST_DICT
        /// </param>
        /// <param name="isLastRecord">
        /// A flag indicating if this submission is the last one
        /// </param>
        /// <param name="actions">
        /// Additional actions for the device created with mobilesync_actions_new()
        /// or NULL if no actions should be passed
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_send_changes", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_send_changes(MobileSyncClientHandle client, PlistHandle entities, char isLastRecord, PlistHandle actions);
        
        /// <summary>
        /// Receives any remapped identifiers reported after the device merged submitted changes.
        /// MOBILESYNC_E_SUCCESS on success
        /// MOBILESYNC_E_INVALID_ARG if one of the parameters is invalid
        /// MOBILESYNC_E_PLIST_ERROR if the received plist is not of valid
        /// form
        /// MOBILESYNC_E_WRONG_DIRECTION if the current sync direction does
        /// not permit this call
        /// MOBILESYNC_E_CANCELLED if the device explicitly cancelled the
        /// session
        /// </summary>
        /// <param name="client">
        /// The mobilesync client
        /// </param>
        /// <param name="mapping">
        /// A pointer to an array plist containing a dict of identifier remappings
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_remap_identifiers", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_remap_identifiers(MobileSyncClientHandle client, out PlistHandle mapping);
        
        /// <summary>
        /// Allocates memory for a new anchors struct initialized with the passed anchors.
        /// MOBILESYNC_E_SUCCESS on success
        /// </summary>
        /// <param name="deviceAnchor">
        /// An anchor the device reported the last time or NULL
        /// if none is known yet which for instance is true on first synchronization.
        /// </param>
        /// <param name="computerAnchor">
        /// An arbitrary string to use as anchor for the computer.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// #mobilesync_anchors_t struct. Must be freed using mobilesync_anchors_free().
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_anchors_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_anchors_new([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string deviceAnchor, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string computerAnchor, out MobileSyncAnchorsHandle client);
        
        /// <summary>
        /// Free memory used by anchors.
        /// MOBILESYNC_E_SUCCESS on success
        /// </summary>
        /// <param name="anchors">
        /// The anchors to free.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_anchors_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern MobileSyncError mobilesync_anchors_free(System.IntPtr anchors);
        
        /// <summary>
        /// Create a new actions plist to use in mobilesync_send_changes().
        /// </summary>
        /// <returns>
        /// A new plist_t of type PLIST_DICT.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_actions_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern PlistHandle mobilesync_actions_new();
        
        /// <summary>
        /// Add one or more new key:value pairs to the given actions plist.
        /// </summary>
        /// <param name="actions">
        /// The actions to modify.
        /// </param>
        /// <param name="...">
        /// KEY, VALUE, [KEY, VALUE], NULL
        /// </param>
        /// <remarks>
        /// The known keys so far are "SyncDeviceLinkEntityNamesKey" which expects
        /// an array of entity names, followed by a count paramter as well as
        /// "SyncDeviceLinkAllRecordsOfPulledEntityTypeSentKey" which expects an
        /// integer to use as a boolean value indicating that the device should
        /// link submitted changes and report remapped identifiers.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_actions_add", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void mobilesync_actions_add(PlistHandle actions);
        
        /// <summary>
        /// Free actions plist.
        /// </summary>
        /// <param name="actions">
        /// The actions plist to free. Does nothing if NULL is passed.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute(MobileSyncNativeMethods.LibraryName, EntryPoint="mobilesync_actions_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void mobilesync_actions_free(PlistHandle actions);
    }
}
