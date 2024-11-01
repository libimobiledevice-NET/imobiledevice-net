# .NET bindings for imobiledevice
[![NuGet Status](http://img.shields.io/nuget/v/imobiledevice-net.svg?style=flat)](https://www.nuget.org/packages/imobiledevice-net/)

imobiledevice-net is a library which allows you to interact with iOS devices on Windows, macOS and Linux using .NET
languages (such as C# or Visual Basic). It is based on the libimobiledevice library.

imobiledevice-net is compatible with recent versions of .NET Framework and .NET Core.

## Maintenance 🔧

This project is currently in maintenance mode and may not compile using the latest commit.

* Added generator support for new enums
* Added BtPacketLogger and ReverseProxy APIs
* Regenerated the libimobiledevice API
* ideviceactivation binary is now included with all platform distributions
* Added byte array PInvoke handler for uint8_t arrays in C style structs

### Status
* Azure Pipelines and workflows broken
* macOS support broken
* Ubuntu support broken

## Installing
You can install imobiledevice-net as a [NuGet package](https://www.nuget.org/packages/imobiledevice-net)

```
PM> Install-Package imobiledevice-net
```

## Advantages of imobiledevice-net
We've done some work to make sure imobiledevice-net "just works":
- __Better string handling__: Strings are marshalled (copied from .NET code to unmanaged code and vice versa) as UTF-8 strings. This is what libimobiledevice uses natively.
- __Better array handling__: In most cases, we'll return a `ReadOnlyCollection<string>` object instead of `IntPtr` objects when the native API returns an array of strings.
- __Less memory leaks__: We give you safe handles instead of `IntPtr` objects. When you dispose of the safe handle (or you forget, and the framework does it for you), the safe memory is freed, too.
- __Unit testing support__: You interact with libimobiledevice through classes such as `iDevice` or `Lockdown`. For each of these classes, we also expose an interface, allowing you to unit test your code.
- __XML Documentation__: Where possible, we've copied over the documentation of libimobiledevice to imobiledevice-net, giving you IntelliSense support.

## How it works
We use `libclang` to parse the libimobiledevice C headers and generate the C# P/Invoke code.

## Generating
To use the custom generator, prepare a folder named `headers` containing `usbmuxd.h`, `libirecovery.h`, `libideviceactivation.h` along with the `plist` and `libimobiledevice` directories from the `include` folder of their respective project.

Then build `iMobileDevice.Generator` on Windows, open command prompt and run:
```
cd [iMobileDevice.Generator\bin\x64\Release\netcoreapp3.1 dir]
iMobileDevice.Generator.exe generate -s [the path of the header folder you created]
```
The generator will update the source code for every API. You should double check for any warning messages and review every change it made before compiling. The generator may create broken XML comment changes which you can discard.

**Make sure the headers you feed into the generator correspond to the library you compile. Failure to do so can result in library runtime crashes.**

## Documentation
See the [API Documentation](https://libimobiledevice-win32.github.io/imobiledevice-net/index.html) for more information on imobiledevice-net.

## Getting started

### Using the library
Before you use the library, you must call `NativeLibraries.Load()` so that `libimobiledevice` is loaded correctly:
```
NativeLibraries.Load();
```

### Listing all iOS devices
The following snippit lists all devices which are currently connected to your PC:

```
ReadOnlyCollection<string> udids;
int count = 0;

var idevice = LibiMobileDevice.Instance.iDevice;
var lockdown = LibiMobileDevice.Instance.Lockdown;

var ret = idevice.idevice_get_device_list(out udids, ref count);

if (ret == iDeviceError.NoDevice)
{
    // Not actually an error in our case
    return;
}

ret.ThrowOnError();

// Get the device name
foreach (var udid in udids)
{
    iDeviceHandle deviceHandle;
    idevice.idevice_new(out deviceHandle, udid).ThrowOnError();

    LockdownClientHandle lockdownHandle;
    lockdown.lockdownd_client_new_with_handshake(deviceHandle, out lockdownHandle, "Quamotion").ThrowOnError();

    string deviceName;
    lockdown.lockdownd_get_device_name(lockdownHandle, out deviceName).ThrowOnError();

    deviceHandle.Dispose();
    lockdownHandle.Dispose();
}
```

## Binary distributions of libimobiledevice for Windows, macOS and Ubuntu Linux

We also provide binary distributions of libimobiledevice for Windows, macOS, and Ubuntu Linux.

For Windows and macOS, you can download a zip file with the libimobiledevice libraries and tools using the
[GitHub releases page](https://github.com/libimobiledevice-win32/imobiledevice-net/releases).

For Ubuntu Linux, you can use our PPA (package archive) to install the latest libimobiledevice libraries and tools using `apt-get`.
See the [Quamotion PPA](https://launchpad.net/~quamotion/+archive/ubuntu/ppa) for more information.

The native binaries are all built from the various repositories ([libplist](https://github.com/libimobiledevice-win32/libplist),
[libusbmuxd](https://github.com/libimobiledevice-win32/libusbmuxd), [libimobiledevice](https://github.com/libimobiledevice-win32/libimobiledevice),
to name a few) in the [libimobiledevice-win32](https://github.com/libimobiledevice-win32) organization.

For macOS and Linux, you can use autotools to compile and install the native binaries from source.
For Windows, you can use the Visual Studio solution and projects hosted in the [libimobiledevice-vs](https://github.com/libimobiledevice-win32/libimobiledevice-vs)
repository.
