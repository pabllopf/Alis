# Platform-Specific Build Constants

Alis automatically defines build-time constants based on the target platform.

## Constant Definition Logic

Constants are derived from `RuntimeIdentifier` and `NETCoreSdkRuntimeIdentifier`:

```xml
<DefineConstants Condition="'$(RuntimeIdentifier)' != ''">
    $(DefineConstants);$([System.String]::Copy('$(RuntimeIdentifier)').Replace('-',''))
</DefineConstants>
```

## Platform Constants

| RuntimeIdentifier | Defined Constant |
|-------------------|------------------|
| `win-x64` | `winx64` |
| `linux-x64` | `linuxx64` |
| `browser-wasm` | `browserwasm` |
| `osx-arm64` | `osxarm64` |
| `android-arm64` | `androidarm64` |

## Linux Flavor Detection

The system also detects Linux distributions:

```xml
<DefineConstants Condition="...StartsWith('ubuntu')...">
    $(DefineConstants);linuxx64
</DefineConstants>
```

Supported distributions:
- Ubuntu, Debian, Alpine, CentOS, Fedora, Rocky, RHEL, openSUSE, Raspbian, Mariner

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
- [[Multi-Targeting Strategy]]
- [[Multi-Platform Samples]]
