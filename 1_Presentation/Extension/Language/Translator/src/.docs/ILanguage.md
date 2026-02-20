# ILanguage Interface Documentation

## Overview

The `ILanguage` interface defines the contract for representing a language in the translation system. It provides metadata about a language including its code, display name, native name, and culture information.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | string | The display name of the language |
| `Code` | string | The language code (e.g., 'en', 'es', 'fr') - Used as unique identifier |
| `NativeName` | string | The native name of the language (e.g., 'English', 'Español', 'Français') |
| `CultureCode` | string | The culture code for this language (e.g., 'en-US', 'es-ES') |
| `IsDefault` | bool | Flag indicating whether this is the default language |

## Methods

### Equals(ILanguage other) : bool
Compares two languages for equality.

## Implementations

- `Lang`: Default implementation

## Usage

```csharp
ILanguage english = new Lang("en", "English", "English", "en-US", true);

if (english.Code == "en")
{
    Console.WriteLine($"Current language: {english.Name}");
}
```

## Notes

- This interface provides the abstraction layer for language representation
- Implementations should provide immutable language metadata
- The `Code` property serves as the unique identifier

