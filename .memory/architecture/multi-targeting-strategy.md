---
title: Multi-Targeting Strategy
tags:
  - architecture
  - build
  - multi-targeting
status: Draft
license: GPLv3
---

# Multi-Targeting Strategy

## Overview

Alis targets an extensive matrix of frameworks and platforms to support broad compatibility.

## Debug Configuration

```text
netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461
```

## Release Configuration

```text
netcoreapp2.0;netcoreapp2.1;netcoreapp2.2;netcoreapp3.0;netcoreapp3.1;
net5.0;net6.0;net7.0;net8.0;net9.0;net10.0;
netstandard2.0;netstandard2.1;
net461;net471;net472;net48;net481
```

## Platform-Specific Configurations

| Configuration | Frameworks | Platform |
|---|---|---|
| Win | netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461 | Windows |
| Osx | net5.0;net8.0;net10.0;netstandard2.0 | macOS |
| Linux | net5.0;net8.0;net10.0;netstandard2.0 | Linux |
| Browser | net8.0;net10.0;netstandard2.0 | Web (WASM) |
| Ios | net8.0;net10.0;netstandard2.0 | iOS |
| Android | net8.0;net10.0;netstandard2.0 | Android |

## Runtime Identifiers

```
browser-wasm
win-x64, win-x86
linux-x64, linux-arm64, linux-arm
osx-x64, osx-arm64
android-arm64, android-x64
ios-arm64, iossimulator-arm64, iossimulator-x64
```

## Conditional Compilation

DefineConstants are automatically set based on RuntimeIdentifier:

| RuntimeIdentifier | DefineConstant |
|---|---|
| win-x64 | WINx64 |
| win-x86 | WINx86 |
| linux-x64 | LINUXx64 |
| osx-arm64 | OSXarm64 |
| (others) | Pattern: `{OS}{ARCH}` |

## Backward Compatibility

- Legacy TFMs (net461, netcoreapp2.0) get compatibility packages:
  - `System.IO.Compression` 4.3.0
  - `System.Net.Http` 4.3.0
  - `System.Runtime.CompilerServices.Unsafe` 6.1.1
  - `System.Memory` 4.6.2

## Related Documents

- [[build-pipeline]]
- [[repository-overview]]
- [[config-props-details]]
