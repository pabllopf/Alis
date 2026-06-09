# Multi-Targeting Strategy

tags:
  - concept,theory,documentation

Multi-targeting enables compiling once and deploying everywhere, supporting .NET 2.0 through .NET 10, .NET Framework 4.61-4.81, and WebAssembly.

## Target Frameworks

### .NET Core / .NET 5+

| Framework | Version | Status |
|-----------|---------|--------|
| **.NET Core 2.0** | 2.0.0 | Legacy support |
| **.NET Core 2.1** | 2.1.0 | LTS (Long Term Support) |
| **.NET Core 3.1** | 3.1.0 | LTS (Extended support) |
| **.NET 5** | 5.0.0 | Standard support |
| **.NET 6** | 6.0.0 | LTS |
| **.NET 7** | 7.0.0 | Standard support |
| **.NET 8** | 8.0.0 | LTS |
| **.NET 9** | 9.0.0 | Standard support |
| **.NET 10** | 10.0.0 | Latest |

### .NET Standard

| Standard | Version | Compatible With |
|----------|---------|-----------------|
| **.NET Standard 2.0** | 2.0.3 | .NET Framework 4.6.1+, .NET Core 2.0+ |
| **.NET Standard 2.1** | 2.1.0 | .NET Core 2.1+, .NET 5+ |

### .NET Framework

| Framework | Version | Status |
|-----------|---------|--------|
| **.NET Framework 4.61** | 4.6.1 | Legacy enterprise |
| **.NET Framework 4.7** | 4.7.0 | Legacy support |
| **.NET Framework 4.71** | 4.7.1 | Legacy support |
| **.NET Framework 4.72** | 4.7.2 | Legacy support |
| **.NET Framework 4.8** | 4.8.0 | Current LTS |
| **.NET Framework 4.81** | 4.8.1 | Latest |

## Configuration

### Project File (.csproj)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;netstandard2.1;netcoreapp2.0;netcoreapp3.1;net5.0;net6.0;net7.0;net8.0;net9.0;net10.0;net461;net472;net48;net481</TargetFrameworks>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <Nullable>disable</Nullable>
    <WarningsAsErrors>true</WarningsAsErrors>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  </PropertyGroup>
  
  <!-- Platform-specific conditions -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net481'">
    <Reference Include="System.Windows" />
  </ItemGroup>
  
  <ItemGroup Condition="'$(TargetFramework)' == 'net9.0' Or '$(TargetFramework)' == 'net10.0'">
    <PackageReference Include="System.Memory" Version="4.5.5" />
  </ItemGroup>
</Project>
```

### Build Configuration (.config/Config.props)

```xml
<Project>
  <PropertyGroup>
    <MultiTargetingEnabled>true</MultiTargetingEnabled>
    <RuntimeIdentifiers>win-x64;win-x86;linux-x64;linux-musl-x64;osx-x64;osx-arm64;browser-wasm</RuntimeIdentifiers>
    <EnableTrimAnalyzer Condition="'$(TargetFramework)'.StartsWith('net6') Or '$(TargetFramework)'.StartsWith('net7') Or '$(TargetFramework)'.StartsWith('net8') Or '$(TargetFramework)'.StartsWith('net9') Or '$(TargetFramework)'.StartsWith('net10')">true</EnableTrimAnalyzer>
  </PropertyGroup>
</Project>
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Maximum Compatibility** | Support legacy and modern systems |
| **Enterprise Support** | .NET Framework 4.81 for Windows apps |
| **Cross-Platform** | Linux, macOS, Windows, WebAssembly |
| **Future-Proof** | Support for .NET 5+ new features |

## Conditional Compilation

### Platform-Specific Code

```csharp
#if NET481 || NET48 || NET472
// .NET Framework specific code
using System.Windows;
#elif NET6_0_OR_GREATER
// .NET 6+ features
using System.Runtime.Intrinsics;
#elif NETSTANDARD2_0
// .NET Standard 2.0 fallback
#endif

// Runtime checks
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    // Windows-specific implementation
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    // Linux-specific implementation
}
```

## AOT Compatibility

### Native AOT Support

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
  <TrimMode>link</TrimMode>
  <EnableUnsafeBinaryFormatterSerialization>false</EnableUnsafeBinaryFormatterSerialization>
</PropertyGroup>
```

### Source Generator Requirements

- No runtime IL emit
- No reflection-based code generation
- Static, compile-time generated code
- Full Native AOT support

## When to Use Multi-Targeting

### Suitable For
- Libraries and frameworks
- Cross-platform applications
- Enterprise software
- Game engines

### Not Suitable For
- Simple utilities
- Platform-specific tools
- One-off applications

## See Also
- [`.memory/sources/sources-overview.md`] - Build System Configuration
