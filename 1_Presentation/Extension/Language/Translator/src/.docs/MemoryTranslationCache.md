# MemoryTranslationCache Class Documentation

## Overview

The `MemoryTranslationCache` is a thread-safe, in-memory implementation of the `ITranslationCache` interface. It stores translations in nested dictionaries, making it suitable for small to medium-sized applications with a limited number of translations.

## Thread Safety

The cache uses locking mechanisms to ensure thread-safe operations for concurrent access from multiple threads.

## Methods

### TryGetTranslation(string languageCode, string key, out string value) : bool
Attempts to retrieve a cached translation.

```csharp
var cache = new MemoryTranslationCache();
cache.Set("en", "greeting", "Hello");

if (cache.TryGetTranslation("en", "greeting", out string translation))
{
    Console.WriteLine(translation); // Output: Hello
}
```

### Set(string languageCode, string key, string value) : void
Adds or updates a translation in the cache.

```csharp
cache.Set("en", "greeting", "Hello");
cache.Set("en", "farewell", "Goodbye");
```

### Remove(string languageCode, string key) : bool
Removes a specific translation from the cache.

```csharp
bool removed = cache.Remove("en", "greeting");
if (removed)
{
    Console.WriteLine("Translation removed");
}
```

### InvalidateLanguage(string languageCode) : void
Clears all cached translations for a specific language.

```csharp
cache.InvalidateLanguage("en"); // Clears all English translations
```

### Clear() : void
Clears all cached translations across all languages.

```csharp
cache.Clear(); // Empties the entire cache
```

## Usage Examples

### Basic Caching

```csharp
var cache = new MemoryTranslationCache();

// Cache translations
cache.Set("en", "hello", "Hello");
cache.Set("en", "goodbye", "Goodbye");
cache.Set("es", "hello", "Hola");
cache.Set("es", "goodbye", "Adiós");

// Retrieve
if (cache.TryGetTranslation("en", "hello", out string english))
{
    Console.WriteLine(english); // Output: Hello
}

if (cache.TryGetTranslation("es", "hello", out string spanish))
{
    Console.WriteLine(spanish); // Output: Hola
}
```

### Language Invalidation

```csharp
var cache = new MemoryTranslationCache();

// Add translations for multiple languages
cache.Set("en", "key1", "value1");
cache.Set("en", "key2", "value2");
cache.Set("es", "key1", "valor1");
cache.Set("es", "key2", "valor2");

// Invalidate English only
cache.InvalidateLanguage("en");

// English keys are cleared, Spanish keys remain
bool enFound = cache.TryGetTranslation("en", "key1", out _); // false
bool esFound = cache.TryGetTranslation("es", "key1", out _); // true
```

### Multi-Language Support

```csharp
var cache = new MemoryTranslationCache();

// Cache for multiple languages independently
string[] languages = { "en", "es", "fr", "de", "it" };
string[] keys = { "greeting", "farewell", "welcome" };

foreach (var lang in languages)
{
    foreach (var key in keys)
    {
        cache.Set(lang, key, $"{lang}-{key}");
    }
}

// Each language maintains independent translations
for (int i = 0; i < languages.Length; i++)
{
    if (cache.TryGetTranslation(languages[i], "greeting", out string greeting))
    {
        Console.WriteLine(greeting);
    }
}
```

### With TranslationManager

```csharp
var cache = new MemoryTranslationCache();
var provider = new MemoryTranslationProvider();
var languageProvider = new LanguageProvider();
var pluralizationEngine = new PluralizationEngine();

var manager = new TranslationManager(
    languageProvider,
    provider,
    cache,
    pluralizationEngine
);

// The manager will automatically cache translations
manager.SetLanguage("en");
manager.AddTranslation("en", "greeting", "Hello");

// First call loads from provider and caches
string text1 = manager.Translate("greeting"); // Cached

// Second call retrieves from cache
string text2 = manager.Translate("greeting"); // From cache

// Clear cache when needed
manager.ClearCache();
```

## Performance Characteristics

| Operation | Complexity | Notes |
|-----------|-----------|-------|
| Set | O(1) | Hash table insertion |
| Get | O(1) | Hash table lookup |
| Remove | O(1) | Hash table deletion |
| InvalidateLanguage | O(k) | k = translations for language |
| Clear | O(n) | n = total translations |

## Exception Handling

- **ArgumentException**: Thrown when language code or key is null/empty in Set method

```csharp
try
{
    cache.Set(null, "key", "value"); // Throws ArgumentException
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid input: {ex.Message}");
}
```

## Memory Considerations

- Each translation uses memory proportional to the string length
- Nested dictionary structure allows efficient organization
- Consider cache size for very large translation sets
- Use InvalidateLanguage periodically to free memory for specific languages

## Thread Safety Example

```csharp
var cache = new MemoryTranslationCache();

// Safe for concurrent access from multiple threads
var tasks = new List<Task>();

for (int i = 0; i < 10; i++)
{
    int index = i;
    tasks.Add(Task.Run(() =>
    {
        cache.Set("en", $"key{index}", $"value{index}");
    }));
}

Task.WaitAll(tasks.ToArray());
Console.WriteLine("All threads completed safely");
```

## Notes

- The cache stores strings as-is without compression
- Empty strings are stored (not treated as null)
- Case-sensitive language codes and keys
- Suitable for production applications with moderate translation volumes

