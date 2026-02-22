# ITranslationCache Interface Documentation

## Overview

The `ITranslationCache` interface defines the contract for a translation cache. Translation caches improve performance by storing frequently accessed translations in memory.

## Methods

### TryGetTranslation(string languageCode, string key, out string value) : bool
Gets a translation from the cache.

```csharp
if (cache.TryGetTranslation("en", "greeting", out string translation))
{
    Console.WriteLine(translation);
}
```

### Set(string languageCode, string key, string value) : void
Adds or updates a translation in the cache.

```csharp
cache.Set("en", "greeting", "Hello");
```

### Remove(string languageCode, string key) : bool
Removes a translation from the cache. Returns true if found and removed.

```csharp
bool removed = cache.Remove("en", "greeting");
```

### InvalidateLanguage(string languageCode) : void
Invalidates all cache entries for a specific language.

```csharp
cache.InvalidateLanguage("en");
```

### Clear() : void
Clears all cached translations.

```csharp
cache.Clear();
```

## Implementations

- `MemoryTranslationCache`: Thread-safe in-memory cache implementation

## Usage

```csharp
ITranslationCache cache = new MemoryTranslationCache();

// Add translations to cache
cache.Set("en", "greeting", "Hello");
cache.Set("en", "farewell", "Goodbye");

// Retrieve from cache
if (cache.TryGetTranslation("en", "greeting", out string greeting))
{
    Console.WriteLine(greeting); // Output: Hello
}

// Remove specific translation
cache.Remove("en", "greeting");

// Invalidate all for a language
cache.InvalidateLanguage("en");

// Clear everything
cache.Clear();
```

## Performance Considerations

- **Memory Usage**: In-memory cache stores all translations in RAM
- **Thread Safety**: MemoryTranslationCache is thread-safe
- **Invalidation**: Use InvalidateLanguage for targeted cache clearing
- **Cache Hits**: Reduces provider calls for frequently accessed translations

## Notes

- Caching is critical for performance in production applications
- Cache invalidation should be considered when translations are updated
- Thread-safe implementation prevents race conditions in multi-threaded scenarios

