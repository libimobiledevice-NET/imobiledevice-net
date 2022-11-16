set LIBIMOBILEDEVICE_VERSION=169
set LIBIDEVICEACTIVATION_VERSION=40

REM download the archives
wget -nc https://qmcdn.blob.core.windows.net/imobiledevice/libimobiledevice-osx-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz -O ext\libimobiledevice-osx-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz
wget -nc https://qmcdn.blob.core.windows.net/imobiledevice/libideviceactivation-osx-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz -O ext\libideviceactivation-osx-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz

wget -nc https://qmcdn.blob.core.windows.net/imobiledevice/libimobiledevice-linux-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz -O ext\libimobiledevice-linux-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz
wget -nc https://qmcdn.blob.core.windows.net/imobiledevice/libideviceactivation-linux-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz -O ext\libideviceactivation-linux-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz

REM extract tar file from tar.gz
7z x -aos ext\libimobiledevice-osx-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz -oext\
7z x -aos ext\libideviceactivation-osx-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz -oext\

7z x -aos ext\libimobiledevice-linux-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar.gz -oext\
7z x -aos ext\libideviceactivation-linux-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar.gz -oext\

REM extract files from the tar files
7z x -aos ext\libimobiledevice-osx-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar -oext\osx-x64
7z x -aos ext\libideviceactivation-osx-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar -oext\osx-x64

7z x -aos ext\libimobiledevice-linux-x64-1.2.1-%LIBIMOBILEDEVICE_VERSION%.tar -oext\linux-x64
7z x -aos ext\libideviceactivation-linux-x64-1.0.0-%LIBIDEVICEACTIVATION_VERSION%.tar -oext\linux-x64
