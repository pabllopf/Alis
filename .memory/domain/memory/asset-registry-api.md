---
title: AssetRegistry API Reference
tags:
  - domain
  - api
  - reference
  - documentation

status: Draft

license: GPLv3

---


## Class

- **Type**: `AssetRegistry` (static)
- **Namespace**: `Alis.Core.Aspect.Memory`
- **Source**: `6_Ideation/Memory/src/AssetRegistry.cs`

## Registration

### `RegisterAssembly(string assemblyName, Func<Stream> assetLoader)`

Registers an asset loader function for the specified assembly.

**Parameters:**
- `assemblyName` - Unique identifier for the assembly
- `assetLoader` - Factory delegate returning assets.pack stream

**Behavior:**
- Sets active assembly if none configured
- Invalidates zip cache for this assembly
- Clears extracted path cache entries
- Thread-safe with global lock

```csharp
AssetRegistry.RegisterAssembly(
    "MyGame.Assets",
    () => typeof(Assets).Assembly.GetManifestResourceStream("assets.pack")
);
```

## Resource Resolution

### `MemoryStream GetResourceMemoryStreamByName(string resourceName)`

Gets resource as MemoryStream from active assembly's assets.pack.

**Parameters:**
- `resourceName` - Resource name (case-insensitive, slash-agnostic)

**Returns:**
- MemoryStream positioned at zero

**Exceptions:**
- `ArgumentException` - Null or empty resource name
- `InvalidOperationException` - No active assembly
- `FileNotFoundException` - Resource not found

```csharp
MemoryStream stream = AssetRegistry.GetResourceMemoryStreamByName("textures/player.png");
// Use stream...
stream.Dispose();
```

### `string GetResourcePathByName(string resourceName)`

Extracts resource to temporary file and returns path.

**Parameters:**
- `resourceName` - Resource name (case-insensitive, slash-agnostic)

**Returns:**
- Absolute file system path to extracted file

**Exceptions:**
- `ArgumentException` - Null or empty resource name
- `InvalidOperationException` - No active assembly
- `FileNotFoundException` - Resource not found

**Note:** Caller responsible for file cleanup

```csharp
string path = AssetRegistry.GetResourcePathByName("models/character.obj");
// Load from path...
File.Delete(path); // Cleanup
```

## Internal Classes

### ZipCacheEntry

Caches raw archive bytes and lookup dictionaries.

**Properties:**
- `PackBytes` - Raw compressed archive bytes
- `EntriesByFullNameLower` - Full path lookup (O(1))
- `EntriesByFileNameLower` - Filename lookup with collision handling

### ZipEntryInfo

Metadata for individual zip entries.

**Properties:**
- `FullName` - Full path in archive
- `Length` - Uncompressed size in bytes
- `LastWriteTimeUtc` - Last modification timestamp

## Caching Behavior

### Archive Caching

1. **Lazy Loading** - Archives loaded on first access
2. **Byte Sharing** - Raw bytes shared across operations
3. **Index Building** - Pre-built dictionaries for fast lookups
4. **Per-Assembly Locks** - Independent synchronization

### File Extraction Caching

1. **Path Validation** - Checks size and timestamp
2. **Composite Keys** - Assembly + normalized name
3. **SHA-256 Naming** - Unique file names
4. **Automatic Cleanup** - Invalidated on re-registration

## Thread Safety

- **Public methods**: Thread-safe
- **Locking strategy**: Per-assembly locks + global lock
- **Dictionary access**: Concurrent patterns

```csharp
// Safe to call from multiple threads
AssetRegistry.RegisterAssembly("Assembly1", loader1);
AssetRegistry.RegisterAssembly("Assembly2", loader2);

// Safe to resolve from multiple threads
var stream1 = AssetRegistry.GetResourceMemoryStreamByName("res1.txt");
var stream2 = AssetRegistry.GetResourceMemoryStreamByName("res2.txt");
```

## Error Handling

### Validation

- Resource names normalized (lowercase, forward slashes)
- Active assembly must be registered
- Archive entries validated on extraction

### Exception Messages

- "resourceName no puede estar vacío." - Empty resource name
- "No hay una asamblea activa configurada." - No active assembly
- "La asamblea activa '{name}' no tiene un assets.pack registrado." - No loader registered
- "Resource '{name}' not found in `assets.pack`." - Resource missing

## Performance Notes

- **First access**: O(n) - Archive indexing
- **Subsequent access**: O(1) - Dictionary lookup
- **Memory**: O(m) - m = total archive size
- **File I/O**: Cached with validation

## Related

- [[Memory Overview]] - Complete overview
- [[Memory Project]] - Project summary
