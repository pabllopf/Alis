$sdkVersion="6.0.100"
$runtimeVersion="6.0.0"

$sdkPaths = Get-ChildItem -Path /usr/local/share/dotnet/ -Include $sdkVersion -Directory -Recurse
$runtimePaths = Get-ChildItem -Path /usr/local/share/dotnet/ -Include $runtimeVersion -Directory -Recurse

$sdkPaths | ForEach-Object {
    sudo rm -rf $_.FullName
}

$runtimePaths | ForEach-Object {
    sudo rm -rf $_.FullName
}