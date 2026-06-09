---
title: Multi-Targeting Strategy
tags:
  - concept
  - theory
  - documentation

status: draft

license: GPLv3
---


Alis uses aggressive multi-targeting across 15+ framework configurations simultaneously for maximum compatibility.

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
    <TargetFrameworks Condition="'$(Configuration)' == 'Debug'">
        netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461
    </TargetFrameworks>
    
    <TargetFrameworks Condition="'$(Configuration)' == 'Release'">
        netcoreapp2.0;netcoreapp2.1;netcoreapp2.2;netcoreapp3.0;netcoreapp3.1;
        net5.0;net6.0;net7.0;net8.0;net9.0;net10.0;
        netstandard2.0;netstandard2.1;
        net461;net471;net472;net48;net481
    </TargetFrameworks>
    
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

## Usage Pattern

```csharp
#if browserwasm
// WebAssembly-specific code
#elif winx64
// Windows x64-specific code
#elif linuxx64
// Linux x64-specific code
#endif
```

## See Also
- [[Platform-Specific Build Constants]]
- [[Build System Configuration]]
- [[Multi-Platform Samples]]
