# Memory Module Plan

## Overview

ZIP-based asset management system with in-memory caching and disk extraction. Provides SHA256-based temp file naming, dual cache (in-memory pack bytes + disk extracted paths), and per-assembly locking for concurrent asset access.

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Memory | `src/` | Library (net461-net9.0) | 3 source files |
| Alis.Core.Aspect.Memory.Generator | `generator/` | Source Generator | - |
| Alis.Core.Aspect.Memory.Sample | `sample/` | Console App | - |
| Alis.Core.Aspect.Memory.Test | `test/` | xUnit Tests | - |

## Source Files (src/)

### AssetRegistry (`AssetRegistry.cs`)
Static class - the core of the module. Manages:

- **RegisteredAssetLoaders**: `Dictionary<string, Func<Stream>>` - maps file extensions to stream factory functions for custom asset loading
- **_assemblyLocks**: `ConcurrentDictionary<string, object>` - per-assembly locks to reduce contention vs. global lock
- **_globalLock**: `object` - fallback lock for cross-assembly coordination
- **_zipCache**: `Dictionary<string, ZipCacheEntry>` - in-memory cache of ZIP pack bytes + parsed entry indices
- **_extractedPathCache**: `Dictionary<string, string>` - maps entry keys to extracted file paths on disk
- **ActiveAssemblyName**: `string` - current assembly context for asset resolution

Key operations:
- `RegisterAssetLoader(string extension, Func<Stream> factory)` - register custom stream loaders
- `GetOrLoadZipCache(string zipPath)` - load ZIP file, parse entries into ZipCacheEntry, cache in memory
- `ExtractEntry(ZipCacheEntry cache, string entryName, string outputPath)` - extract single entry from cached ZIP bytes
- `GetEntryStream(string assemblyName, string entryPath)` - get stream for an asset entry (cache lookup or extract)
- `ClearCache()` - clear both _zipCache and _extractedPathCache
- `CleanupTempFiles()` - remove extracted temp files

### ZipCacheEntry (`ZipCacheEntry.cs`)
Internal class representing a cached ZIP pack:

- **PackBytes**: `byte[]` - raw ZIP file bytes loaded into memory (avoids re-opening ZIP)
- **EntriesByFullNameLower**: `Dictionary<string, ZipEntryInfo>` - fast lookup by full path (lowercase key)
- **EntriesByFileNameLower**: `Dictionary<string, List<ZipEntryInfo>>` - lookup by filename only (multiple entries can share same filename)

### ZipEntryInfo (`ZipEntryInfo.cs`)
Internal struct-like class holding ZIP entry metadata:

- **FullName**: `string` - full path within ZIP archive
- **Length**: `long` - uncompressed size in bytes
- **LastWriteTimeUtc**: `DateTimeOffset` - modification timestamp

## Dependencies

- **Internal**: None (leaf module)
- **External**: System.IO.Compression, System.Security.Cryptography (SHA256)

## Architecture Notes

- **Static singleton pattern**: AssetRegistry is a static class - global state with no DI support
- **Dual cache strategy**: ZIP bytes kept in memory (_zipCache) for fast extraction, extracted files cached on disk (_extractedPathCache) to avoid repeated decompression
- **Per-assembly locking**: `_assemblyLocks` uses ConcurrentDictionary to create one lock object per assembly name, reducing contention when multiple assemblies access assets concurrently
- **SHA256 temp files**: Extracted files use SHA256 hash of entry path as filename for uniqueness and cache invalidation
- **Func<Stream> loaders**: Custom asset loaders can be registered by file extension for non-ZIP assets
- **Lazy extraction**: ZIP entries are extracted on-demand, not pre-extracted

## Code Quality Issues

1. **Static global state**: AssetRegistry uses static fields throughout - no DI support, impossible to mock in tests, single instance per process.
2. **Memory leak risk**: `_zipCache` stores entire ZIP files in memory (`PackBytes`). Large ZIP packs (100MB+) will consume significant heap with no size limit or eviction policy.
3. **No cache eviction**: No LRU, TTL, or size-based eviction for either cache. Memory grows unbounded as new ZIPs are loaded.
4. **Disk cleanup not guaranteed**: `_extractedPathCache` stores temp file paths but `CleanupTempFiles()` is never called automatically. Temp files accumulate on disk.
5. **Thread safety gaps**: `_zipCache` and `_extractedPathCache` are protected by `_globalLock` but `_assemblyLocks` is used inconsistently. Race condition possible between cache lookup and entry.
6. **ActiveAssemblyName is global mutable state**: Setting `ActiveAssemblyName` affects all subsequent asset lookups - not thread-safe, not scoped.
7. **No compression options**: ZIP entries are extracted with default compression - no control over memory buffer sizes or parallel extraction.
8. **Generator directory exists but empty**: `generator/` folder present in project structure but no source generator files visible.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Add cache size limits**: Implement LRU eviction for `_zipCache` (max N ZIPs in memory) and `_extractedPathCache` (max M extracted files).
2. **Fix thread safety**: Audit all read/write paths through `_zipCache` and `_extractedPathCache`. Ensure per-assembly locks cover the full lookup-and-extract operation.
3. **Add automatic temp file cleanup**: Schedule periodic `CleanupTempFiles()` or use FileSystemWatcher to detect and clean orphaned temp files.

### Priority 2 - Important
4. **Support DI/IAssetRegistry**: Create interface and non-static implementation for testability and dependency injection.
5. **Add memory pressure handling**: Monitor `GC.GetTotalMemory()` and evict least-recently-used ZIP caches under memory pressure.
6. **Add async extraction**: `ExtractEntryAsync()` for non-blocking extraction of large entries.
7. **Add ZIP streaming**: Support streaming extraction without loading entire ZIP into memory (for packs > 500MB).

### Priority 3 - Nice to have
8. **Add asset versioning**: Include version hash in cache keys to detect pack updates.
9. **Add asset dependency tracking**: Track which assets depend on which others for incremental cache invalidation.
10. **Add compression level control**: Allow configuring DeflateLevel for extraction.
11. **Implement generator**: Create source generator for compile-time asset path validation (catch typos at build time).

## Test Coverage

- Tests for ZIP cache loading and entry lookup
- Tests for entry extraction and stream retrieval
- Tests for cache clearing and cleanup
- Tests for concurrent assembly access
- Tests for custom asset loader registration
