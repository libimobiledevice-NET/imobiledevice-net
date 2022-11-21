$buildPropsPath = (Get-Item .).FullName + "\Directory.Build.props"

[xml]$buildProps = Get-Content $buildPropsPath
$version = $buildProps.Project.PropertyGroup.MobileDeviceDotNetNuGetVersion
Write-Host "Current NuGet package version: $version"

$projectFile = Get-Content "iMobileDevice.IntegrationTests.net462.csproj"
$projectFile = $projectFile.Replace("{imobiledevice-version}", $version)
Set-Content "iMobileDevice.IntegrationTests.net462.csproj" $projectFile

$packagesFile = Get-Content "packages.config"
$packagesFile = $packagesFile.Replace("{imobiledevice-version}", $version)
Set-Content "packages.config" $packagesFile