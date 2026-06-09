# Multi-Targeting Strategy

Alis uses aggressive multi-targeting across 15+ framework configurations simultaneously.

## Target Frameworks

### Debug Configuration
- `netcoreapp2.0`
- `net5.0`, `net8.0`, `net10.0`
- `netstandard2.0`
- `net461`

### Release Configuration (15+ frameworks)
- **.NET Core**: 2.0, 2.1, 2.2, 3.0, 3.1
- **.NET**: 5.0 through 10.0
- **.NET Standard**: 2.0, 2.1
- **.NET Framework**: 4.61, 4.71, 4.72, 4.8, 4.81

## Runtime Identifiers

### Desktop Platforms
- `win-x64`, `win-x86`
- `linux-x64`, `linux-arm64`, `linux-arm`
- `osx-x64`, `osx-arm64`

### Web Platform
- `browser-wasm` (Blazor WebAssembly)

### Mobile Platforms
- `android-arm64`, `android-x64`
- `ios-arm64`, `iossimulator-arm64`, `iossimulator-x64`

## Build Configuration

```xml
<PropertyGroup>
    <TargetFrameworks>netcoreapp2.0;net5.0;net8.0;net10.0;...</TargetFrameworks>
    <RuntimeIdentifiers>browser-wasm;win-x64;linux-x64;...</RuntimeIdentifiers>
    <LangVersion>13</LangVersion>
    <Nullable>disable</Nullable>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
</PropertyGroup>
```

## Platform-Specific Constants

Build-time constants are automatically defined based on `RuntimeIdentifier`:
- `win-x64` → defines `winx64` constant
- `linux-x64` → defines `linuxx64` constant
- `browser-wasm` → defines `browserwasm` constant

## See Also
- [[Layered Architecture]]
- [[Multi-Platform Samples]]
