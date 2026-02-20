# MemoryTranslationProvider Class Documentation

## Overview

The `MemoryTranslationProvider` is an in-memory implementation of the `ITranslationProvider` interface. It stores translations in memory using nested dictionaries and is suitable for applications where translations are predefined and don't change frequently.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | string | Returns "MemoryTranslationProvider" |

## Methods

### LoadTranslationsAsync() : Task<Dictionary<string, Dictionary<string, string>>>
Loads all translations from the in-memory storage.

```csharp
var provider = new MemoryTranslationProvider();
await provider.SetTranslationAsync("en", "hello", "Hello");

var translations = await provider.LoadTranslationsAsync();
// Returns: {"en": {"hello": "Hello"}}
```

### SaveTranslationsAsync(Dictionary<string, Dictionary<string, string>> translations) : Task
Saves the provided translations, replacing all existing data.

```csharp
var translations = new Dictionary<string, Dictionary<string, string>>
{
    {
        "en", new Dictionary<string, string>
        {
            { "hello", "Hello" }
        }
    }
};

await provider.SaveTranslationsAsync(translations);
```

### GetTranslationAsync(string languageCode, string key) : Task<string>
Retrieves a specific translation. Returns null if not found.

```csharp
await provider.SetTranslationAsync("en", "hello", "Hello");
string translation = await provider.GetTranslationAsync("en", "hello");
// Returns: "Hello"
```

### SetTranslationAsync(string languageCode, string key, string value) : Task
Adds or updates a translation.

```csharp
await provider.SetTranslationAsync("en", "hello", "Hello");
await provider.SetTranslationAsync("en", "goodbye", "Goodbye");
```

### RemoveTranslationAsync(string languageCode, string key) : Task
Removes a translation.

```csharp
await provider.RemoveTranslationAsync("en", "hello");
```

### GetKeysAsync(string languageCode) : Task<IEnumerable<string>>
Gets all translation keys for a specific language.

```csharp
var keys = await provider.GetKeysAsync("en");
// Returns: { "hello", "goodbye" }
```

## Usage Examples

### Basic Operations

```csharp
var provider = new MemoryTranslationProvider();

// Add translations
await provider.SetTranslationAsync("en", "greeting", "Hello");
await provider.SetTranslationAsync("en", "farewell", "Goodbye");
await provider.SetTranslationAsync("es", "greeting", "Hola");

// Get translation
string greeting = await provider.GetTranslationAsync("en", "greeting");
Console.WriteLine(greeting); // Output: Hello

// Get all keys
var keys = await provider.GetKeysAsync("en");
foreach (var key in keys)
{
    Console.WriteLine(key); // Output: greeting, farewell
}

// Remove translation
await provider.RemoveTranslationAsync("en", "greeting");

// Check if removed
string result = await provider.GetTranslationAsync("en", "greeting");
Console.WriteLine(result ?? "Not found"); // Output: Not found
```

### Multiple Languages

```csharp
var provider = new MemoryTranslationProvider();

// Add translations for multiple languages
string[] languages = { "en", "es", "fr" };
var translations = new Dictionary<string, Dictionary<string, string>>();

foreach (var lang in languages)
{
    translations[lang] = new Dictionary<string, string>
    {
        { "hello", $"Hello in {lang}" },
        { "goodbye", $"Goodbye in {lang}" }
    };
}

// Save all at once
await provider.SaveTranslationsAsync(translations);

// Verify
var loaded = await provider.LoadTranslationsAsync();
Console.WriteLine($"Total languages: {loaded.Count}");
```

### With TranslationManager

```csharp
var languageProvider = new LanguageProvider();
var translationProvider = new MemoryTranslationProvider();
var cache = new MemoryTranslationCache();
var pluralizationEngine = new PluralizationEngine();

var manager = new TranslationManager(
    languageProvider,
    translationProvider,
    cache,
    pluralizationEngine
);

// Add languages
manager.AddLanguage("en", "English");
manager.AddLanguage("es", "Spanish");

// Use manager to add translations (internally uses provider)
manager.SetLanguage("en");
manager.AddTranslation("en", "hello", "Hello");
manager.AddTranslation("en", "goodbye", "Goodbye");

manager.SetLanguage("es");
manager.AddTranslation("es", "hello", "Hola");
manager.AddTranslation("es", "goodbye", "Adiós");

// Retrieve
string greeting = manager.Translate("hello");
```

### Bulk Operations

```csharp
var provider = new MemoryTranslationProvider();

// Create bulk data
var bulkTranslations = new Dictionary<string, Dictionary<string, string>>();

for (int i = 1; i <= 3; i++)
{
    string lang = i switch
    {
        1 => "en",
        2 => "es",
        3 => "fr",
        _ => ""
    };

    bulkTranslations[lang] = new Dictionary<string, string>
    {
        { "key1", $"Value1 in {lang}" },
        { "key2", $"Value2 in {lang}" },
        { "key3", $"Value3 in {lang}" }
    };
}

// Load all at once
await provider.SaveTranslationsAsync(bulkTranslations);

// Process
var allTranslations = await provider.LoadTranslationsAsync();
foreach (var kvp in allTranslations)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} translations");
}
```

## Thread Safety

The `MemoryTranslationProvider` is thread-safe using internal locking mechanisms for all operations.

```csharp
var provider = new MemoryTranslationProvider();
var tasks = new List<Task>();

// Safe concurrent access
for (int i = 0; i < 10; i++)
{
    int index = i;
    tasks.Add(provider.SetTranslationAsync("en", $"key{index}", $"value{index}"));
}

await Task.WhenAll(tasks);
```

## Exception Handling

```csharp
var provider = new MemoryTranslationProvider();

// Null language code
try
{
    await provider.SetTranslationAsync(null, "key", "value");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Null translations dictionary in SaveTranslationsAsync
try
{
    await provider.SaveTranslationsAsync(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Performance Characteristics

| Operation | Complexity | Notes |
|-----------|-----------|-------|
| GetTranslationAsync | O(1) | Hash table lookup |
| SetTranslationAsync | O(1) | Hash table insertion |
| RemoveTranslationAsync | O(1) | Hash table deletion |
| GetKeysAsync | O(k) | k = number of keys in language |
| LoadTranslationsAsync | O(n) | n = total translations (copy) |
| SaveTranslationsAsync | O(m) | m = translations to save (copy) |

## Memory Usage

- Each translation uses memory for the string keys and values
- For large translation sets, consider lazy-loading or other caching strategies
- The provider creates copies during Load/Save operations

## Notes

- Suitable for small to medium-sized translation sets
- All operations are asynchronous even though execution is synchronous
- Case-sensitive language codes and keys
- Returns null for missing translations (rather than throwing)
- Thread-safe for concurrent read/write operations

