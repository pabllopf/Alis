# LanguageProvider Class Documentation

## Overview

The `LanguageProvider` is the default implementation of the `ILanguageProvider` interface. It manages a collection of languages in memory, making it suitable for most applications with a predefined set of supported languages.

## Methods

### GetAvailableLanguages() : IReadOnlyList<ILanguage>
Returns a read-only list of all available languages.

```csharp
var languages = provider.GetAvailableLanguages();
foreach (var language in languages)
{
    Console.WriteLine($"{language.Code}: {language.Name}");
}
```

### AddLanguage(ILanguage language) : void
Adds a new language to the provider.

```csharp
provider.AddLanguage(new Lang("en", "English", "English", "en-US"));
```

### RemoveLanguage(string languageCode) : bool
Removes a language by its code. Returns true if successful, false if not found.

```csharp
bool removed = provider.RemoveLanguage("en");
if (removed)
{
    Console.WriteLine("Language removed successfully");
}
```

### GetLanguageByCode(string code) : ILanguage
Retrieves a language by its code. Returns null if not found.

```csharp
var language = provider.GetLanguageByCode("en");
if (language != null)
{
    Console.WriteLine($"Found: {language.Name}");
}
```

### LanguageExists(string code) : bool
Checks if a language with the specified code exists.

```csharp
if (provider.LanguageExists("es"))
{
    Console.WriteLine("Spanish is supported");
}
```

## Usage Examples

### Basic Setup

```csharp
var provider = new LanguageProvider();

// Add languages
provider.AddLanguage(new Lang("en", "English", "English", "en-US"));
provider.AddLanguage(new Lang("es", "Spanish", "Español", "es-ES"));
provider.AddLanguage(new Lang("fr", "French", "Français", "fr-FR"));

// Get available languages
var languages = provider.GetAvailableLanguages();
Console.WriteLine($"Total languages: {languages.Count}");

// Get specific language
var english = provider.GetLanguageByCode("en");
if (english != null)
{
    Console.WriteLine($"Language: {english.Name}");
}
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

languageProvider.AddLanguage(new Lang("en", "English"));
manager.SetLanguage("en");
```

### Language Management

```csharp
var provider = new LanguageProvider();

// Add
provider.AddLanguage(new Lang("en", "English"));

// Check existence
if (provider.LanguageExists("en"))
{
    // Get it
    var language = provider.GetLanguageByCode("en");
    
    // Remove it
    provider.RemoveLanguage("en");
}
```

## Exception Handling

- **ArgumentNullException**: Thrown when null values are passed
- **InvalidOperationException**: Thrown when trying to add a language with a duplicate code

```csharp
try
{
    provider.AddLanguage(new Lang("en", "English"));
    provider.AddLanguage(new Lang("en", "English (US)")); // Will throw
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Thread Safety

The `LanguageProvider` is thread-safe for concurrent access to read operations. However, modifications should be synchronized if accessed from multiple threads simultaneously.

## Notes

- Languages are identified by their code, which must be unique
- Null language codes are not allowed
- Removing a non-existent language returns false (doesn't throw)
- The provider returns read-only views to prevent external modifications

