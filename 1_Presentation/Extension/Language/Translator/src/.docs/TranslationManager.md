# TranslationManager Class Documentation

## Overview

The `TranslationManager` class is the main facade for the translation system. It coordinates language management, translation lookup, caching, pluralization, and observer notifications. It uses dependency injection to allow flexible configuration of providers, caches, and other services.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Lang` | ILanguage | Gets the currently selected language |

## Constructors

### TranslationManager()
Creates a new instance with default providers (in-memory provider and cache).

### TranslationManager(ILanguageProvider, ITranslationProvider, ITranslationCache, IPluralizationEngine)
Creates a new instance with custom providers for full control over the implementation.

## Core Methods

### Language Management

#### SetLanguage(ILanguage language)
Sets the current language by language object.

```csharp
var manager = new TranslationManager();
var english = new Lang("en", "English");
manager.SetLanguage(english);
```

#### SetLanguage(string name, string code)
Sets the current language by name and code.

```csharp
manager.SetLanguage("English", "en");
```

#### AddLanguage(ILanguage language)
Adds a new language to the manager.

```csharp
manager.AddLanguage(new Lang("es", "Spanish"));
```

#### AddLanguage(string name, string code)
Adds a new language by name and code.

```csharp
manager.AddLanguage("Spanish", "es");
```

#### GetAvailableLanguages() : IReadOnlyList<ILanguage>
Returns all available languages.

```csharp
var languages = manager.GetAvailableLanguages();
```

### Translation Methods

#### Translate(string key) : string
Translates a key for the current language.

```csharp
string greeting = manager.Translate("greeting");
```

#### Translate(string key, string defaultValue) : string
Translates a key with a fallback default value.

```csharp
string greeting = manager.Translate("greeting", "Hello");
```

#### Translate(string key, IDictionary<string, object> parameters) : string
Translates a key and substitutes parameters.

```csharp
var parameters = new Dictionary<string, object> { { "name", "John" } };
string greeting = manager.Translate("greeting", parameters);
// If "greeting" is "Hello {name}!", result is "Hello John!"
```

#### TranslatePlural(string key, int quantity) : string
Gets the plural form of a translation based on quantity.

```csharp
string result = manager.TranslatePlural("items", 5);
// For English: quantity=1 returns singular form, quantity>1 returns plural form
```

### Translation Management

#### AddTranslation(ILanguage language, string key, string value)
Adds a translation for a specific language.

```csharp
var english = new Lang("en", "English");
manager.AddTranslation(english, "greeting", "Hello");
```

#### AddTranslation(string languageCode, string key, string value)
Adds a translation using language code.

```csharp
manager.AddTranslation("en", "greeting", "Hello");
```

#### RemoveTranslation(string languageCode, string key)
Removes a translation.

```csharp
manager.RemoveTranslation("en", "greeting");
```

### Advanced Features

#### SetFallbackLanguages(params string[] fallbackCodes)
Sets up fallback languages for missing translations.

```csharp
manager.SetFallbackLanguages("en-US", "en");
// If translation not found in "en-US", tries "en"
```

#### Subscribe(ITranslationObserver observer)
Subscribes an observer to translation events.

```csharp
manager.Subscribe(new MyTranslationObserver());
```

#### Unsubscribe(ITranslationObserver observer)
Unsubscribes an observer from translation events.

```csharp
manager.Unsubscribe(observer);
```

#### ClearCache()
Clears the translation cache.

```csharp
manager.ClearCache();
```

## Usage Examples

### Basic Setup

```csharp
var manager = new TranslationManager();

// Add languages
manager.AddLanguage("English", "en");
manager.AddLanguage("Spanish", "es");

// Set current language
manager.SetLanguage("en");

// Add translations
manager.AddTranslation("en", "greeting", "Hello");
manager.AddTranslation("en", "farewell", "Goodbye");
manager.AddTranslation("es", "greeting", "Hola");
manager.AddTranslation("es", "farewell", "Adiós");

// Translate
Console.WriteLine(manager.Translate("greeting")); // Output: Hello
manager.SetLanguage("es");
Console.WriteLine(manager.Translate("greeting")); // Output: Hola
```

### Pluralization

```csharp
// Add plural translations
manager.AddTranslation("en", "items[0]", "1 item");
manager.AddTranslation("en", "items[1]", "{count} items");

// Use pluralization
Console.WriteLine(manager.TranslatePlural("items", 1));  // Output: 1 item
Console.WriteLine(manager.TranslatePlural("items", 5));  // Output: {count} items
```

### Parameter Substitution

```csharp
manager.AddTranslation("en", "welcome", "Welcome {name}!");

var parameters = new Dictionary<string, object>
{
    { "name", "John" }
};

Console.WriteLine(manager.Translate("welcome", parameters));
// Output: Welcome John!
```

### Fallback Languages

```csharp
manager.AddLanguage("English (US)", "en-US");
manager.AddLanguage("English (GB)", "en-GB");
manager.AddLanguage("English", "en");

manager.SetLanguage("en-US");

// Set fallback chain
manager.SetFallbackLanguages("en-US", "en");

// If translation not found in en-US, will try en
```

### Observer Pattern

```csharp
public class MyTranslationObserver : ITranslationObserver
{
    public void OnLanguageChanged(ILanguage language)
    {
        Console.WriteLine($"Language changed to {language.Code}");
    }

    public void OnTranslationsUpdated(string languageCode)
    {
        Console.WriteLine($"Translations updated for {languageCode}");
    }

    public void OnTranslationNotFound(string languageCode, string key)
    {
        Console.WriteLine($"Translation not found: {languageCode}/{key}");
    }
}

var observer = new MyTranslationObserver();
manager.Subscribe(observer);
```

### Custom Providers

```csharp
// Use custom providers for different scenarios
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
```

## Exception Handling

The manager throws the following exceptions:

- `ArgumentNullException`: When null values are passed where not allowed
- `InvalidOperationException`: When operations are attempted without setting a language first
- `LanguageNotFound`: When attempting to use a language that doesn't exist
- `TranslationNotFound`: When a translation key cannot be found

## Notes

- The manager is thread-safe for concurrent read and write operations
- Caching improves performance for frequently accessed translations
- The observer pattern allows components to react to language changes
- Pluralization rules are built-in for common languages (English, Spanish, Russian, etc.)
- The design uses dependency injection for maximum flexibility
