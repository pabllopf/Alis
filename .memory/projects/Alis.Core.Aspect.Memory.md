---
title: Alis.Core.Aspect.Memory
tags:
  - ideation
  - memory
  - assets
  - zip
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Memory

**Layer:** 6_Ideation
**Path:** `6_Ideation/Memory/src/Alis.Core.Aspect.Memory.csproj`

## Purpose

Memory management and asset registry for game assets, including ZIP-based resource packing.

## Types

- `AssetRegistry` — Central asset registry for game resources
- `ZipEntryInfo` — ZIP archive entry metadata
- `ZipCacheEntry` — Cached ZIP entry data

## Source Generator

**Path:** `6_Ideation/Memory/generator/`

- `ResourceAccessorGenerator` — Generates strongly-typed resource accessor code for embedded assets

## Dependencies

None (leaf layer)

## Testing

**Path:** `6_Ideation/Memory/test/`

7 test files covering:
- AssetRegistry (unit, pure logic, coverage)
- ZipEntryInfo
- ZipCacheEntry

## Related Documents

- [[Alis.Core.Aspect]]
- [[asset-management]]
