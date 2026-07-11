---
title: Alis.Core.Aspect.Memory
tags:
  - project
  - memory
  - assets
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Memory

## Overview

Memory and asset management library (Layer 6 - Ideation). Provides asset registry, ZIP entry caching, and memory management utilities.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Memory/src/` |
| **Test Project** | `Alis.Core.Aspect.Memory.Test` |
| **Generator** | `Alis.Core.Aspect.Memory.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Memory.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)
- **Used By**: [[Alis.Core.Ecs]]

## Architecture

- Flat file structure in `src/`
- Key classes: `AssetRegistry`, `ZipCacheEntry`, `ZipEntryInfo`

## Source Structure

```
src/
  (flat files)
```

## Testing

- Test project: `Alis.Core.Aspect.Memory.Test`
- Located at `6_Ideation/Memory/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Alis.Core.Ecs]]
- [[Memory Domain]]
- [[Projects Index]]
