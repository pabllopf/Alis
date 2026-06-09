---
title: Memory Management
tags:
  - glossary
  - terminology
  - reference

status: Draft

license: GPLv3

---


## Overview

Memory management in Alis focuses on efficient resource handling, compressed storage, and fast asset retrieval through specialized components.

## ZipCacheEntry

### Definition

A **ZipCacheEntry** is a compressed cache entry that stores data in a memory-efficient format, enabling fast retrieval with minimal memory footprint.

### Structure

```csharp
public class ZipCacheEntry
{
    public byte[] CompressedData { get; }
    public int OriginalSize { get; }
    public int CompressionRatio { get; }
    
    public T Get<T>() where T : class;
    public void Invalidate();
}
```

### Usage

```csharp
var cache = new ZipCacheEntry();
cache.Set("important data");

// Retrieve with type safety
var data = cache.Get<string>();

// Invalidate entry
cache.Invalidate();
```

### Compression

- Uses standard compression algorithms
- Tracks original vs compressed size
- Calculates compression ratio for efficiency metrics

## AssetRegistry

### Definition

An **AssetRegistry** is a resource management registry that handles asset loading, caching, and lifecycle management.

### Core Functions

```csharp
public class AssetRegistry
{
    // Load assets from various sources
    public T Load<T>(string path) where T : class;
    
    // Cache management
    public void Cache(string key, object value);
    public T Get<T>(string key) where T : class;
    
    // Cleanup
    public void ClearCache();
    public void EvictLeastRecentlyUsed(int count);
}
```

### Asset Types

- Textures and images
- Audio clips
- Scripts and configurations
- Binary resources

### Lifecycle Management

```csharp
var texture = AssetRegistry.LoadTexture("player.png");

// Auto-cleanup when no longer referenced
texture.Dispose();

// Or manual cleanup
AssetRegistry.ClearCache();
```

## ZipEntryInfo

### Definition

**ZipEntryInfo** provides metadata about archive entries, including compression details, timestamps, and file attributes.

### Properties

```csharp
public class ZipEntryInfo
{
    public string FileName { get; }
    public long CompressedSize { get; }
    public long OriginalSize { get; }
    public DateTime LastModified { get; }
    public bool IsDirectory { get; }
    
    public double CompressionRatio => 
        (1.0 - (double)CompressedSize / OriginalSize);
}
```

### Usage

```csharp
var entries = ZipFile.Read("archive.zip")
    .Select(e => new ZipEntryInfo(e))
    .ToList();

// Filter by compression ratio
var efficientEntries = entries.Where(e => e.CompressionRatio > 0.5);
```

## Memory Optimization Strategies

### Struct Layout

```csharp
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GameObject
{
    // Packed without padding
}
```

### Span<T> Usage

Zero-copy memory slices:

```csharp
Span<ComponentStorageBase> components = 
    archetype.Components.AsSpan();
```

### Ref<T> Wrapper

Reference wrapper for component access:

```csharp
Ref<Transform> transformRef = player.TryGetCore<Transform>(out bool exists);
```

## Related

- [[ZipCacheEntry]] - Compressed cache entry
- [[AssetRegistry]] - Resource management
- [[ZipEntryInfo]] - Archive metadata
- [[GameObject]] - Entity handle (struct packing)
- [[Ref<T>]] - Reference wrapper
- [[Span<T>]] - Memory slice

## Related Architecture

- [[Alis.Core.Aspect.Memory]] — Memory aspect project
- [[performance-index]] — Performance optimizations
- [[security-overview]] — Memory security
- [[glossary/index]] — All glossary terms
