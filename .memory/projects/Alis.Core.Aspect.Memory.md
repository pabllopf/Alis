---
title: Alis.Core.Aspect.Memory
tags:
  - project
  - documentation
  - reference

status: Draft

license: GPLv3

---


**Status**: ✅ Documented  
**Type**: Asset Registry / ZIP Management  
**Layer**: 6_Ideation  
**Target Frameworks**: 15+ (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)

## Overview

Asset registry system for managing embedded asset packages (.pack/.zip) across assemblies. Provides thread-safe caching, resource resolution, and automatic extraction to temporary files.

## Key Features

- ✅ Thread-safe asset registration
- ✅ Per-assembly cache management
- ✅ O(1) resource lookup with dictionaries
- ✅ Automatic file extraction with validation
- ✅ SHA-256 unique file naming
- ✅ Multi-assembly support

## Public API

| Type | Purpose |
|---|---|
| `AssetRegistry` | Static asset registry |

## Internal Types

| Type | Purpose |
|---|---|
| `ZipCacheEntry` | Archive cache with dictionaries |
| `ZipEntryInfo` | Entry metadata |

## Properties

- `ActiveAssemblyName` - Current active assembly (internal)

## Methods

- `RegisterAssembly(string, Func<Stream>)` - Register assembly
- `GetResourceMemoryStreamByName(string)` - Get as MemoryStream
- `GetResourcePathByName(string)` - Get file path

## Documentation

- [[Domain/Memory/Overview]] - Complete overview
- [[Domain/Memory/Asset-Registry-API]] - API reference

## File Structure

```
6_Ideation/Memory/src/
├── AssetRegistry.cs - Main implementation (619 lines)
├── ZipCacheEntry.cs - Cache entry (63 lines)
├── ZipEntryInfo.cs - Entry metadata (60 lines)
└── .docs/
    ├── architecture.md
    ├── usage_examples.md
    └── testing_strategy.md
```

## Thread Safety

**Thread-safe** - All public methods use proper locking.

## Caching

- **Archive caching**: Per-assembly, lazy-loaded
- **File caching**: Path validation with size/timestamp
- **Dictionary lookups**: O(1) performance

## Tests

See: `6_Ideation/Memory/test/Alis.Core.Aspect.Memory.Test.csproj`

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Time]] - Time measurement
- [[Alis.Core.Aspect.Fluent]] - Fluent builder system
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU GPL v3.0

## Author

Pablo Perdomo Falcón
