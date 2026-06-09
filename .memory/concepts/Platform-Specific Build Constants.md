# Platform-Specific Build Constants

tags:
  - concept,theory,documentation

Alis automatically defines build-time constants based on the target platform for conditional compilation.

## Constant Definition Logic

Constants are derived from `RuntimeIdentifier` and `NETCoreSdkRuntimeIdentifier`:

```xml
<DefineConstants Condition="'$(RuntimeIdentifier)' != ''">
    $(DefineConstants);$([System.String]::Copy('$(RuntimeIdentifier)').Replace('-',''))
</DefineConstants>
```

## Platform Constants Mapping

| RuntimeIdentifier | Defined Constant | Example Usage |
|-------------------|------------------|---------------|
| `win-x64` | `winx64` | Windows x64-specific code |
| `win-x86` | `winx86` | Windows x86-specific code |
| `linux-x64` | `linuxx64` | Linux x64-specific code |
| `linux-arm64` | `linuxarm64` | Linux ARM64-specific code |
| `osx-x64` | `osxx64` | macOS x64-specific code |
| `osx-arm64` | `osxarm64` | macOS Apple Silicon-specific code |
| `browser-wasm` | `browserwasm` | Blazor WebAssembly code |
| `android-arm64` | `androidarm64` | Android ARM64-specific code |
| `ios-arm64` | `iosarm64` | iOS ARM64-specific code |

## Linux Distribution Detection

The system also detects Linux distributions and defines flavor constants:

```xml
<DefineConstants Condition="...StartsWith('ubuntu')...">
    $(DefineConstants);linuxx64
</DefineConstants>
```

Supported distributions:
- Ubuntu, Debian, Alpine, CentOS, Fedora, Rocky, RHEL, openSUSE, Raspbian, Mariner

## Conditional Compilation Usage

```csharp
#if browserwasm
// WebAssembly-specific code
#elif winx64
// Windows x64-specific code
#elif linuxx64
// Linux x64-specific code
#elif osxarm64
// macOS Apple Silicon-specific code
#endif
```

## Platform Detection at Runtime

```csharp
public static class PlatformHelper
{
    public static bool IsWeb => 
        #if browserwasm
        true;
        #else
        false;
        #endif

    public static bool IsWindows => 
        #if winx64 || winx86
        true;
        #else
        false;
        #endif

    public static bool IsLinux => 
        #if linuxx64 || linuxarm64
        true;
        #else
        false;
        #endif
}
```

## See Also
- [[Multi-Targeting Strategy]]
- [[Multi-Platform Samples]]
- [[Build System Configuration]]
