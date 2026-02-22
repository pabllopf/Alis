# ITranslationProvider Interface Documentation

## Overview

The `ITranslationProvider` interface defines the contract for a translation provider. Translation providers are responsible for loading and managing translations from various sources such as files, databases, or remote services.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | string | The name of the provider |

## Methods

### LoadTranslationsAsync() : Task<Dictionary<string, Dictionary<string, string>>>
Loads all translations from the source.

```csharp
var translations = await provider.LoadTranslationsAsync();
```

### SaveTranslationsAsync(Dictionary<string, Dictionary<string, string>> translations) : Task
Saves the translations to the source.

```csharp
await provider.SaveTranslationsAsync(translations);
```

### GetTranslationAsync(string languageCode, string key) : Task<string>
Gets a translation for a specific key and language code.

```csharp
string translation = await provider.GetTranslationAsync("en", "greeting");
```

### SetTranslationAsync(string languageCode, string key, string value) : Task
Adds or updates a translation.

```csharp
await provider.SetTranslationAsync("en", "greeting", "Hello");
```

### RemoveTranslationAsync(string languageCode, string key) : Task
Removes a translation.

```csharp
await provider.RemoveTranslationAsync("en", "greeting");
```

### GetKeysAsync(string languageCode) : Task<IEnumerable<string>>
Gets all translation keys for a specific language.

```csharp
var keys = await provider.GetKeysAsync("en");
```

## Implementations

- `MemoryTranslationProvider`: In-memory provider for testing and simple applications

## Usage

```csharp
ITranslationProvider provider = new MemoryTranslationProvider();

await provider.SetTranslationAsync("en", "greeting", "Hello");
string translation = await provider.GetTranslationAsync("en", "greeting");
```

## Notes

- This interface provides the abstraction for different translation sources
- Methods are asynchronous to support remote sources
- Implementations should be thread-safe

