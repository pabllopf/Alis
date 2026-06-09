---
title: Alis.Core.Aspect.Memory
tags:
  - ideation
  - aspect
  - library
  - documentation

status: draft
---


## Overview

The **Alis.Core.Aspect.Memory** project provides a ZIP-based asset management system with in-memory caching and disk extraction capabilities. It enables efficient storage and retrieval of embedded assets through a dual-cache strategy (in-memory ZIP bytes + disk-extracted paths).

## Purpose

- Manage embedded asset packages (.pack/.zip files)
- Provide fast in-memory ZIP caching with entry indexing
- Extract assets to temporary disk files when needed
- Support concurrent access across multiple assemblies
- Generate unique file names using SHA256 hashing

## Architecture

### Core Components

| Component | Type | Description |
|-----------|------|-------------|
| `AssetRegistry` | Static Class | Main entry point - manages asset loading and caching |
| `ZipCacheEntry` | Class | Represents cached ZIP data with entry indexes |
| `ZipEntryInfo` | Class | Holds ZIP entry metadata (path, length, timestamp) |

### Cache Strategy

**Dual Cache System:**

1. **In-Memory Cache** (`_zipCache`)
   - Stores entire ZIP file bytes in memory (`PackBytes`)
   - Maintains entry indexes for fast lookup
   - Per-assembly locking to reduce contention

2. **Disk Cache** (`_extractedPathCache`)
   - Stores extracted file paths on disk
   - Uses SHA256 hash for unique file naming
   - Validates cached files against entry metadata

### Thread Safety

- **Global Lock** (`_globalLock`) - Cross-assembly coordination
- **Per-Assembly Locks** (`_assemblyLocks`) - Reduces contention for same-assembly access
- **ConcurrentDictionary** - Thread-safe assembly lock management

## Public API

### AssetRegistry Class

```csharp
public static class AssetRegistry
{
    // Registration
    static void RegisterAssembly(string assemblyName, Func<Stream> assetLoader);
    
    // Resource Access
    MemoryStream GetResourceMemoryStreamByName(string resourceName);
    string GetResourcePathByName(string resourceName);
    
    // Cache Management (internal)
    static void EnsureZipCachedForActiveAssembly();
    static ZipEntryInfo FindZipEntryInfo(ZipCacheEntry cacheEntry, string resourceName);
}
```

### Usage Example

```csharp
using Alis.Core.Aspect.Memory;

// Register an assembly with its assets.pack
var assembly = typeof(MyGameAssembly).Assembly;
var stream = assembly.GetManifestResourceStream("assets.pack");
AssetRegistry.RegisterAssembly(assembly.GetName().Name, () => stream);

// Get resource as stream
var resourceStream = AssetRegistry.GetResourceMemoryStreamByName("textures/sprite.png");

// Get resource path on disk
var filePath = AssetRegistry.GetResourcePathByName("sounds/music.mp3");
```

## Files

| File | Lines | Description |
|------|-------|-------------|
| AssetRegistry.cs | 612 | Core asset management logic |
| ZipCacheEntry.cs | - | ZIP cache entry data structure |
| ZipEntryInfo.cs | - | Entry metadata holder |

## Dependencies

- **System.IO.Compression** - ZIP archive handling
- **System.Security.Cryptography** - SHA256 hashing
- **System.Buffers** - Array pooling for buffer management

## Configuration

See [QualityPlan.md](QualityPlan.md) for performance goals.

## Quality Plan

See [plan.md](plan.md) for detailed architecture notes and TODOs.

## Performance Characteristics

| Operation | Complexity | Notes |
|-----------|------------|-------|
| Register Assembly | O(1) | Adds to dictionary |
| Cache ZIP | O(N) | N = number of entries in ZIP |
| Lookup Entry | O(1) | Hash-based lookup |
| Extract to Disk | O(M) | M = entry size in bytes |
| Cache Hit (stream) | O(1) | In-memory lookup |
| Cache Hit (disk) | O(1) | Path lookup + validation |

## Known Issues

1. **Memory Leak Risk** - `_zipCache` stores entire ZIP files with no size limit or eviction policy
2. **Thread Safety Gaps** - Race conditions possible between cache lookup and entry extraction
3. **No Cache Eviction** - Memory grows unbounded as new ZIPs are loaded
4. **Disk Cleanup Not Guaranteed** - Temp files accumulate without automatic cleanup
5. **Global Mutable State** - `ActiveAssemblyName` affects all subsequent lookups

## TODOs

- [ ] Add cache size limits (LRU eviction)
- [ ] Fix thread safety gaps in per-assembly locking
- [ ] Add automatic temp file cleanup
- [ ] Support DI/IAssetRegistry interface
- [ ] Add memory pressure handling
- [ ] Implement async extraction
- [ ] Add ZIP streaming for large packs (>500MB)
- [ ] Create source generator for compile-time asset validation

## Related Projects

- [[Alis.Core.Aspect.Fluent]] - Fluent aspect system
- [[Alis.Core.Aspect.Data]] - Data aspect system
- [[Alis.Core.Aspect.Memory.Generator]] - Source generator (if exists)
