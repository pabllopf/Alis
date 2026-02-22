# IPluralizationEngine Interface Documentation

## Overview

The `IPluralizationEngine` interface defines the contract for a pluralization engine. Pluralization engines handle the rules for converting translations based on quantity and language-specific pluralization rules.

## Methods

### GetPluralForm(string languageCode, int quantity) : int
Gets the plural form based on the quantity and language.

```csharp
int form = engine.GetPluralForm("en", 5); // Returns 1 (plural form)
int form = engine.GetPluralForm("en", 1); // Returns 0 (singular form)
```

### RegisterPluralizationRule(string languageCode, Func<int, int> rule) : void
Registers custom pluralization rules for a language.

```csharp
engine.RegisterPluralizationRule("customLang", (quantity) => quantity == 1 ? 0 : 1);
```

### GetPluralFormCount(string languageCode) : int
Gets the number of plural forms for a language.

```csharp
int count = engine.GetPluralFormCount("en");   // Returns 2
int count = engine.GetPluralFormCount("ru");   // Returns 3
int count = engine.GetPluralFormCount("ja");   // Returns 1
```


## Implementations

- `PluralizationEngine`: Default implementation with built-in rules for multiple languages

## Built-in Language Rules

### English (en) - 2 Forms
- Singular: quantity == 1
- Plural: quantity != 1

### Spanish (es) - 2 Forms
- Singular: quantity == 1
- Plural: quantity != 1

### French (fr) - 2 Forms
- Singular: quantity == 1
- Plural: quantity != 1

### Russian (ru) - 3 Forms
- Form 0: ends with 1 (except 11)
- Form 1: ends with 2-4 (except 12-14)
- Form 2: all other

### Polish (pl) - 3 Forms
- Form 0: quantity == 1
- Form 1: quantity ends with 2-4
- Form 2: all other

### Japanese (ja) - 1 Form
- No pluralization

## Usage

### Basic Pluralization

```csharp
var engine = new PluralizationEngine();

// Built-in English rules
int form1 = engine.GetPluralForm("en", 1);  // 0 (singular)
int form5 = engine.GetPluralForm("en", 5);  // 1 (plural)

// Russian with 3 forms
int ru1  = engine.GetPluralForm("ru", 1);   // 0
int ru2  = engine.GetPluralForm("ru", 2);   // 1
int ru5  = engine.GetPluralForm("ru", 5);   // 2
```

### With TranslationManager

```csharp
var manager = new TranslationManager();
manager.SetLanguage("en");

// Add plural translations
manager.AddTranslation("en", "items[0]", "1 item");
manager.AddTranslation("en", "items[1]", "{count} items");

// Use
string one = manager.TranslatePlural("items", 1);    // "1 item"
string many = manager.TranslatePlural("items", 10);  // "{count} items"
```

### Custom Pluralization Rules

```csharp
var engine = new PluralizationEngine();

// Register custom rule (e.g., for a hypothetical language)
engine.RegisterPluralizationRule("customLang", (quantity) =>
{
    if (quantity == 0) return 0;
    if (quantity == 1) return 1;
    if (quantity <= 4) return 2;
    return 3;
});

int form = engine.GetPluralForm("customLang", 3); // Returns 2
int count = engine.GetPluralFormCount("customLang"); // Returns 4
```

## Plural Forms Reference

| Language | Forms | Examples |
|----------|-------|----------|
| English | 2 | 1 book, 2 books |
| Spanish | 2 | 1 libro, 2 libros |
| Russian | 3 | 1 книга, 2 книги, 5 книг |
| Polish | 3 | 1 książka, 2 książki, 5 książek |
| Japanese | 1 | 1冊, 5冊 (same form) |

## Notes

- Most languages have 2 forms (singular/plural)
- Some languages like Russian have 3 forms
- Some languages like Japanese have 1 form (no pluralization)
- Built-in rules are initialized automatically
- Custom rules override built-in rules for the same language

