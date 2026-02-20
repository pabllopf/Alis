# ILanguageProvider Interface Documentation

## Overview

The `ILanguageProvider` interface defines the contract for a language provider. Language providers are responsible for managing available languages in the system.

## Methods

### GetAvailableLanguages() : IReadOnlyList<ILanguage>
Gets all available languages.

```csharp
var languages = provider.GetAvailableLanguages();
```

### AddLanguage(ILanguage language) : void
Adds a new language.

```csharp
provider.AddLanguage(new Lang("en", "English"));
```

### RemoveLanguage(string languageCode) : bool
Removes a language by its code. Returns true if successful.

```csharp
bool removed = provider.RemoveLanguage("en");
```

### GetLanguageByCode(string code) : ILanguage
Gets a language by its code. Returns null if not found.

```csharp
var language = provider.GetLanguageByCode("en");
```

### LanguageExists(string code) : bool
Determines whether a language with the specified code exists.

```csharp
if (provider.LanguageExists("en"))
{
    // Language exists
}
```

## Implementations

- `LanguageProvider`: Default in-memory implementation

## Usage

```csharp
ILanguageProvider provider = new LanguageProvider();

provider.AddLanguage(new Lang("en", "English"));
provider.AddLanguage(new Lang("es", "Spanish"));

var languages = provider.GetAvailableLanguages();
foreach (var language in languages)
{
    Console.WriteLine($"{language.Code} - {language.Name}");
}
```

## Notes

- This interface provides abstraction for different language storage mechanisms
- Implementations should validate language codes for uniqueness
- The Code property serves as the unique identifier

