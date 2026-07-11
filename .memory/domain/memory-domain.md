---
title: Memory Domain
tags:
  - domain
  - memory
  - assets
  - caching
status: Draft
license: GPLv3
---

# Memory Domain

## Overview

The Memory domain provides memory management and asset registry capabilities. Implemented in [[Alis.Core.Aspect.Memory]].

## Key Types

| Type | Purpose |
|---|---|
| `AssetRegistry` | Central asset registration and lookup |
| `ZipCacheEntry` | Cached ZIP entry for asset packing |
| `ZipEntryInfo` | ZIP entry metadata |

## Asset Packing Integration

Works with the build system's asset packing pipeline:
1. Assets are hashed (SHA-256) and zipped during build
2. Base64-encoded into assembly as `obj/assets.pack`
3. `AssetRegistry` loads and caches at runtime

## Related

- [[Alis.Core.Aspect.Memory]]
- [[Alis.Core.Aspect.Memory.Generator]]
- [[Alis.Core.Ecs]]
- [[Build System]]
