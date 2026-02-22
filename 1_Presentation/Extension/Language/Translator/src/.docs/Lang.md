# Lang Class Documentation

## Overview

The `Lang` class is a concrete implementation of the `ILanguage` interface that represents a language with its metadata including code, display name, native name, culture information, and default language flag.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Code` | string | The language code (e.g., 'en', 'es', 'fr') - Used as unique identifier |
| `Name` | string | The display name of the language |
| `NativeName` | string | The native name of the language (e.g., 'English', 'Español', 'Français') |
| `CultureCode` | string | The culture code for this language (e.g., 'en-US', 'es-ES') |
| `IsDefault` | bool | Flag indicating whether this is the default language |

## Constructors

### Lang()
Default constructor initializing a new language instance.

### Lang(string code, string name)
Creates a language with code and display name.

### Lang(string code, string name, string nativeName, string cultureCode, bool isDefault = false)
Creates a fully initialized language with all properties.

## Methods

### Equals(ILanguage other) : bool
Compares two languages based on their code and name.

### Equals(object obj) : bool
Compares this language with another object.

### GetHashCode() : int
Returns the hash code for use in collections.

### ToString() : string
Returns a string representation in the format "{Code} - {Name}".

## Usage Examples

### Creating Languages

```csharp
// Simple language with code and name
var english = new Lang("en", "English");

// Full language with culture code
var english = new Lang("en", "English", "English", "en-US");

// With default flag
var defaultLanguage = new Lang("en", "English", "English", "en-US", true);
```

### Common Language Definitions

```csharp
var english = new Lang("en", "English", "English", "en-US");
var spanish = new Lang("es", "Spanish", "Español", "es-ES");
var french = new Lang("fr", "French", "Français", "fr-FR");
var german = new Lang("de", "German", "Deutsch", "de-DE");
var portuguese = new Lang("pt", "Portuguese", "Português", "pt-BR");
var russian = new Lang("ru", "Russian", "Русский", "ru-RU");
```

### Using with TranslationManager

```csharp
var manager = new TranslationManager();

var english = new Lang("en", "English", "English", "en-US", true);
var spanish = new Lang("es", "Spanish", "Español", "es-ES");

manager.AddLanguage(english);
manager.AddLanguage(spanish);

// Set and use the language
manager.SetLanguage(english);
string translation = manager.Translate("greeting");
```

## Notes

- The `Code` property serves as the unique identifier for a language
- Two languages are considered equal if their codes and names match
- The `IsDefault` flag can be used to identify the application's default language
- This class is thread-safe for immutable operations after initialization
