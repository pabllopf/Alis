---
title: Alis.Core.Aspect.Memory
tags: [domain,api,reference,documentation]
---


## Overview

**Alis.Core.Aspect.Memory** provides an asset registry system for managing embedded asset packages (.pack/.zip) across assemblies. It enables loading, caching, and resolving embedded resources from compressed archives with thread-safe operations and intelligent caching strategies.

## Purpose

This project enables:
- Registering assembly-level embedded asset packages
- Resolving embedded resource paths or streams by name
- Thread-safe caching of decompressed archives
- Automatic extraction to temporary files with validation
- SHA-256 based unique file naming

## Architecture

### Core Classes

| Class | Type | Purpose |
|---|---|---|
| `AssetRegistry` | Static | Asset registration and resolution |
| `ZipCacheEntry` | Internal | Cache entry for decompressed archives |
| `ZipEntryInfo` | Internal | Metadata for zip entries |

## Dependencies

```xml
<Import Project="$(SolutionDir).config/Config.props"/>
```

**System References:**
- `System.Buffers` - Array pooling
- `System.IO.Compression` - ZIP archive handling
- `System.Security.Cryptography` - SHA-256 hashing

No external NuGet packages. Pure .NET Standard implementation.

## Target Frameworks

Multi-targeted to 15+ frameworks:
- .NET Standard 2.0-2.1
- .NET Core 2.0-3.1
- .NET 5.0-10.0
- .NET Framework 4.61-4.81

## Thread Safety

**Thread-safe** - All public methods use proper locking mechanisms:
- Per-assembly locks for independent cache operations
- Global lock for registry modifications
- Dictionary-based concurrent access patterns

## Usage Pattern

### Registering an Assembly

```csharp
using Alis.Core.Aspect.Memory;

// Register your assembly's assets.pack
AssetRegistry.RegisterAssembly(
    "MyGame.Assets",
    () => typeof(MyGame.Assets.Assets).Assembly
          .GetManifestResourceStream("assets.pack")
);
```

### Getting Resource as Stream

```csharp
using Alis.Core.Aspect.Memory;

// Get resource as MemoryStream
MemoryStream stream = AssetRegistry.GetResourceMemoryStreamByName("textures/player.png");

// Use the stream
using (var reader = new StreamReader(stream))
{
    string content = reader.ReadToEnd();
}
```

### Getting Resource Path

```csharp
using Alis.Core.Aspect.Memory;

// Get resource path on disk
string path = AssetRegistry.GetResourcePathByName("models/character.obj");

// Load from file
var model = LoadModel(path);
```

### Multi-Assembly Support

```csharp
using Alis.Core.Aspect.Memory;

// Register multiple assemblies
AssetRegistry.RegisterAssembly("Game.Assets", GetGameAssets);
AssetRegistry.RegisterAssembly("Game.Textures", GetTextureAssets);
AssetRegistry.RegisterAssembly("Game.Audio", GetAudioAssets);

// Resources resolved by active assembly name
```

## File Structure

```
6_Ideation/Memory/src/
├── AssetRegistry.cs - Main registry implementation (619 lines)
├── ZipCacheEntry.cs - Cache entry class (63 lines)
├── ZipEntryInfo.cs - Entry metadata class (60 lines)
└── .docs/
    ├── architecture.md - Architecture documentation
    ├── usage_examples.md - Usage examples
    └── testing_strategy.md - Testing strategy
```

## API Reference

### AssetRegistry Methods

| Method | Description |
|---|---|
| `RegisterAssembly(string, Func<Stream>)` | Register assembly's assets.pack loader |
| `GetResourceMemoryStreamByName(string)` | Get resource as MemoryStream |
| `GetResourcePathByName(string)` | Get resource path on disk |

### ZipCacheEntry Properties

| Property | Type | Description |
|---|---|---|
| `PackBytes` | `byte[]` | Raw compressed archive bytes |
| `EntriesByFullNameLower` | `Dictionary<string, ZipEntryInfo>` | Full path lookup (O(1)) |
| `EntriesByFileNameLower` | `Dictionary<string, List<ZipEntryInfo>>` | Filename lookup with collisions |

### ZipEntryInfo Properties

| Property | Type | Description |
|---|---|---|
| `FullName` | `string` | Full path in archive |
| `Length` | `long` | Uncompressed size in bytes |
| `LastWriteTimeUtc` | `DateTimeOffset` | Last modification timestamp |

## Caching Strategy

### Archive Caching

1. **Lazy Loading** - Archives loaded only when first accessed
2. **Per-Assembly Locks** - Independent synchronization per assembly
3. **Byte Sharing** - Raw bytes shared across all extractions
4. **Index Building** - Pre-built dictionaries for O(1) lookups

### File Extraction Caching

1. **Path Validation** - Checks file size and timestamp
2. **Composite Keys** - Assembly + normalized resource name
3. **SHA-256 Naming** - Unique, collision-free file names
4. **Automatic Cleanup** - Invalidated entries removed on re-registration

## Performance Characteristics

| Operation | Complexity | Notes |
|---|---|---|
| `RegisterAssembly` | O(1) | Invalidates caches |
| `GetResourceMemoryStreamByName` | O(1) | After initial archive load |
| `GetResourcePathByName` | O(1) | After initial extraction |
| Cache lookup | O(1) | Dictionary-based |
| Archive indexing | O(n) | One-time per assembly |

## Error Handling

### Exceptions

| Exception | When Thrown |
|---|---|
| `ArgumentException` | Null or empty resource name |
| `InvalidOperationException` | No active assembly configured |
| `FileNotFoundException` | Resource not found in archive |

### Validation

- Resource names normalized (case-insensitive, slash-agnostic)
- Active assembly must be registered before use
- Archive entries validated on extraction

## Use Cases

### Game Asset Loading

```csharp
// Register game assets
AssetRegistry.RegisterAssembly("Game.Assets", () =>
    typeof(Assets).Assembly.GetManifestResourceStream("assets.pack")
);

// Load texture
using (var stream = AssetRegistry.GetResourceMemoryStreamByName("textures/player.png"))
{
    var texture = TextureLoader.Load(stream);
}

// Load model to disk
string modelPath = AssetRegistry.GetResourcePathByName("models/player.obj");
var model = ModelLoader.Load(modelPath);
```

### Multi-Platform Resources

```csharp
// Platform-specific asset packs
AssetRegistry.RegisterAssembly("Game.Windows", GetWindowsAssets);
AssetRegistry.RegisterAssembly("Game.Linux", GetLinuxAssets);
AssetRegistry.RegisterAssembly("Game.MacOS", GetMacOSAssets);

// Resolve based on platform
string platform = PlatformDetector.GetPlatform();
string path = AssetRegistry.GetResourcePathByName($"platforms/{platform}/config.json");
```

### Asset Versioning

```csharp
// Versioned asset packs
AssetRegistry.RegisterAssembly("Game.v1.0", GetV1Assets);
AssetRegistry.RegisterAssembly("Game.v2.0", GetV2Assets);

// Switch versions
AssetRegistry.RegisterAssembly("Game.v2.0", GetV2Assets);
// Old caches automatically invalidated
```

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Time]] - Time measurement
- [[Alis.Core.Aspect.Fluent]] - Fluent builder system
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU General Public License v3.0

## Author

Pablo Perdomo Falcón  
Web: https://www.pabllopf.dev/
