---
title: Alis.Core.Aspect.Data
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


**Status**: ✅ Documented  
**Type**: Library / Aspect  
**Layer**: 6_Ideation  
**Target Frameworks**: 15+ (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)

## Overview

JSON serialization/deserialization library for AOT environments. Provides reflection-free JSON handling through interface-based contracts.

## Key Features

- ✅ AOT-compatible (no System.Reflection.Emit)
- ✅ Multi-targeted to 15+ frameworks
- ✅ Pure .NET, no NuGet dependencies
- ✅ Thread-safe lazy initialization
- ✅ File I/O with automatic directory creation

## Public API

| Type | Purpose |
|---|---|
| `JsonNativeAot` | Static facade for all JSON operations |
| `IJsonSerializable` | Serialization contract |
| `IJsonDesSerializable<T>` | Deserialization contract |
| `JsonNativeIgnoreAttribute` | Exclude properties from serialization |
| `JsonNativePropertyNameAttribute` | Custom property names |

## Documentation

- [[Domain/Data/Overview]] - Complete overview
- [[Domain/Data/Serialization/Serialization-Contract]] - Serialization API
- [[Domain/Data/Deserialization/Deserialization-Contract]] - Deserialization API
- [[Domain/Data/Parsing/Parsing-Contract]] - Low-level parsing
- [[Domain/Data/File-Operations/File-Operations]] - File I/O
- [[Domain/Data/JsonNativeAot-Facade]] - Main facade
- [[Domain/Data/Exceptions/Exceptions]] - Error handling
- [[Domain/Data/Architecture]] - Architecture patterns

## Tests

See: `6_Ideation/Data/test/Alis.Core.Aspect.Data.Test.csproj`

## Related Projects

- [[Alis.Core.Aspect.Memory]] - Memory persistence
- [[Alis.Core.Aspect.Fluent]] - Fluent validation
- [[Alis.Core.Aspect.Time]] - Time aspects
- [[Alis.Core.Aspect.Logging]] - Logging

## License

GNU GPL v3.0

## Author

Pablo Perdomo Falcón
