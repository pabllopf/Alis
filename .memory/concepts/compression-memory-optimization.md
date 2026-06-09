# Compression & Memory Optimization

Compression and memory optimization techniques reduce memory footprint and improve cache efficiency through compression algorithms and smart caching strategies.

## Core Techniques

### 1. Zip-Based Compression
- **Pattern**: Deflate compression for cache entries
- **Location**: `6_Ideation/Memory/src/ZipCacheEntry.cs`
- **Benefits**: 60-80% memory reduction, disk caching

### 2. Memory-Mapped Files
- **Pattern**: Map files directly to memory space
- **Benefits**: Zero-copy file access, efficient large file handling

### 3. Object Pooling
- **Pattern**: Reuse objects instead of creating new ones
- **Benefits**: Reduced GC pressure, predictable allocation patterns

## Implementation Example

### ZipCacheEntry

```csharp
public class ZipCacheEntry<T> : CacheEntry<T> where T : class
{
    private readonly byte[] _compressedData;
    private readonly int _originalSize;
    
    public ZipCacheEntry(T value, TimeSpan expiry) : base(value, expiry)
    {
        _originalSize = GetSize(value);
        _compressedData = Compress(value);
    }
    
    public override T Value
    {
        get
        {
            if (IsExpired)
                return null;
            
            return Decompress(_compressedData);
        }
    }
    
    private byte[] Compress(T value)
    {
        using var ms = new MemoryStream();
        using (var zip = new ZipOutputStream(ms))
        {
            var stream = new MemoryStream(Serialize(value));
            zip.PutNextEntry("data");
            stream.CopyTo(zip);
            zip.CloseEntry();
        }
        
        return ms.ToArray();
    }
    
    private T Decompress(byte[] compressed)
    {
        using var ms = new MemoryStream(compressed);
        using var zip = new ZipInputStream(ms);
        zip.GetNextEntry();
        
        using var result = new MemoryStream();
        zip.CopyTo(result);
        
        return Deserialize(result.ToArray());
    }
    
    public int GetCompressedSize() => _compressedData.Length;
    public int GetCompressionRatio() => (double)_compressedData.Length / _originalSize;
}
```

### Memory Pool

```csharp
public class ObjectPool<T> where T : class, new()
{
    private readonly Stack<T> _pool = new();
    private readonly int _maxSize;
    
    public ObjectPool(int maxSize = 1000)
    {
        _maxSize = maxSize;
    }
    
    public T Get()
    {
        lock (_pool)
        {
            if (_pool.Count > 0)
                return _pool.Pop();
            
            return new T();
        }
    }
    
    public void Return(T item)
    {
        lock (_pool)
        {
            if (_pool.Count < _maxSize)
                _pool.Push(item);
        }
    }
}

// Usage: Pool entity components
var positionPool = new ObjectPool<Position>();
var velocityPool = new ObjectPool<Velocity>();

// Get from pool
var position = positionPool.Get();
position.X = 0f;
position.Y = 0f;

// Return to pool when done
positionPool.Return(position);
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Memory Reduction** | 60-80% smaller cache entries |
| **Disk Caching** | Compressed data fits in memory better |
| **Reduced GC Pressure** | Object pooling reuses instances |
| **Faster Serialization** | Binary compression faster than text |

## Performance Comparison

| Method | Memory Usage | Load Time | Compression Ratio |
|--------|--------------|-----------|-------------------|
| **Uncompressed** | 100% | Fast | 1:1 |
| **Zip Compression** | 20-40% | Moderate | 2.5-5:1 |
| **LZ4 Compression** | 30-50% | Very Fast | 2-3:1 |
| **Snappy** | 40-60% | Fast | 1.5-2:1 |

## Use Cases in Alis

### Asset Caching

```csharp
// Cache textures with compression
var textureCache = new ZipCacheEntry<Texture2D>(loadedTexture, TimeSpan.FromHours(1));

// Store in memory-efficient cache
_memoryCache.Set("sprite.png", textureCache);

// Retrieve when needed
var cached = _memoryCache.Get<ZipCacheEntry<Texture2D>>("sprite.png");
if (cached != null && !cached.IsExpired)
{
    Draw(cached.Value);
}
```

### Save Game Compression

```csharp
public class SaveGameManager
{
    public void SaveGame(GameState state, string path)
    {
        var compressed = new ZipCacheEntry<GameState>(state, TimeSpan.FromDays(30));
        
        using var file = File.Create(path);
        file.Write(compressed.GetCompressedData());
    }
    
    public GameState LoadGame(string path)
    {
        using var file = File.OpenRead(path);
        var compressedData = file.ReadAllBytes();
        
        var state = Decompress(compressedData);
        return state;
    }
}
```

## When to Use Compression

### Suitable For
- Large asset caching
- Save game data
- Network transmission
- Disk persistence

### Not Suitable For
- Real-time rendering data
- Performance-critical paths
- Small data structures (<1KB)

## See Also
- [`.memory/concepts/resource-management-patterns.md`] - Resource Management Patterns
