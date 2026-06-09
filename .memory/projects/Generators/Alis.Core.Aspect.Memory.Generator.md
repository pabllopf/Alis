---
title: Alis.Core.Aspect.Memory.Generator
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


## Overview
Incremental generator (`IIncrementalGenerator`) for AOT-safe resource embedding. Reads `assets.pack` from `AdditionalTexts`, decompresses/re-compresses it, and embeds the compressed byte array into generated code for runtime access without reflection.

## Details
- **Layer**: 6_Ideation (Memory aspect)
- **Type**: `IIncrementalGenerator`
- **Files**: 2 (1 `.csproj` + 1 `.cs`)
- **Target**: `netstandard2.0;net8.0;net10.0`

## Source Files

| File | Purpose |
|---|---|
| `ResourceAccessorGenerator.cs` | Main incremental generator — reads `assets.pack`, generates embedded `AssemblyLoader.g.cs` |

## Generated Output
- `AssemblyLoader.g.cs` containing:
  - `ResourceAnchor` internal class with compressed asset data as `byte[]` and `LoadAsset()` method
  - `AssemblyLoader` public class with `[ModuleInitializer]` registering the assembly in `AssetRegistry`

## Diagnostics
| Code | Description |
|---|---|
| ALIS0011 | Missing assets.pack file |
| ALIS0012 | Empty assets.pack file |
| ALIS0013 | Non-executable project |
| ALIS0007 | Hash reporting |

## Related
- [[projects/6_Ideation/Memory]] — Memory aspect
- [[projects/Generators]] — Generator overview
