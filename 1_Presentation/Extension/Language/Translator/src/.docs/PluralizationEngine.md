# PluralizationEngine Class Documentation

## Overview

The `PluralizationEngine` is the default implementation of the `IPluralizationEngine` interface. It handles pluralization rules for different languages with built-in support for common languages and the ability to register custom rules.

## Built-in Language Rules

The engine includes pluralization rules for:

| Language | Code | Forms | Examples |
|----------|------|-------|----------|
| English | en | 2 | 1 item, 2 items |
| Spanish | es | 2 | 1 artículo, 2 artículos |
| French | fr | 2 | 1 article, 2 articles |
| German | de | 2 | 1 Artikel, 2 Artikel |
| Portuguese | pt | 2 | 1 artigo, 2 artigos |
| Italian | it | 2 | 1 articolo, 2 articoli |
| Russian | ru | 3 | 1 статья, 2 статьи, 5 статей |
| Polish | pl | 3 | 1 artykuł, 2 artykuły, 5 artykułów |
| Japanese | ja | 1 | 1個, 5個 |
| Korean | ko | 1 | 1개, 5개 |
| Chinese | zh | 1 | 1个, 5个 |

## Methods

### GetPluralForm(string languageCode, int quantity) : int
Returns the plural form index for a given quantity and language.

```csharp
var engine = new PluralizationEngine();

// English
int form1 = engine.GetPluralForm("en", 1);  // 0 (singular)
int form5 = engine.GetPluralForm("en", 5);  // 1 (plural)

// Russian (3 forms)
int ru1 = engine.GetPluralForm("ru", 1);   // 0
int ru2 = engine.GetPluralForm("ru", 2);   // 1
int ru5 = engine.GetPluralForm("ru", 5);   // 2
```

### RegisterPluralizationRule(string languageCode, PluralRule rule) : void
Registers a custom pluralization rule for a language.

```csharp
var engine = new PluralizationEngine();

// Register custom rule
engine.RegisterPluralizationRule("myLang", (quantity) =>
{
    if (quantity == 0) return 0;
    if (quantity == 1) return 1;
    return 2;
});
```

### GetPluralFormCount(string languageCode) : int
Returns the number of plural forms for a language.

```csharp
int en = engine.GetPluralFormCount("en");   // 2
int ru = engine.GetPluralFormCount("ru");   // 3
int ja = engine.GetPluralFormCount("ja");   // 1
```

## Usage Examples

### Basic Pluralization

```csharp
var engine = new PluralizationEngine();

// English
string[] enForm = { "1 apple", "2 apples" };
int enIndex = engine.GetPluralForm("en", 5);
Console.WriteLine(enForm[enIndex]); // Output: 2 apples

// Russian with 3 forms
string[] ruForms = { "1 яблоко", "2 яблока", "5 яблок" };
int ru5 = engine.GetPluralForm("ru", 5);
Console.WriteLine(ruForms[ru5]); // Output: 5 яблок
```

### With TranslationManager

```csharp
var manager = new TranslationManager();
manager.SetLanguage("en");

// Register translations with plural forms
manager.AddTranslation("en", "item[0]", "1 item");
manager.AddTranslation("en", "item[1]", "{count} items");

// Use
Console.WriteLine(manager.TranslatePlural("item", 1));  // "1 item"
Console.WriteLine(manager.TranslatePlural("item", 5));  // "{count} items"
```

### Custom Pluralization Rules

```csharp
var engine = new PluralizationEngine();

// Define custom rule (e.g., for a fictional language with 4 forms)
PluralRule customRule = (quantity) =>
{
    if (quantity == 0) return 0;
    if (quantity == 1) return 1;
    if (quantity <= 4) return 2;
    return 3;
};

// Register and use
engine.RegisterPluralizationRule("custom", customRule);

int form0 = engine.GetPluralForm("custom", 0);  // 0
int form1 = engine.GetPluralForm("custom", 1);  // 1
int form3 = engine.GetPluralForm("custom", 3);  // 2
int form5 = engine.GetPluralForm("custom", 5);  // 3
```

### Handling Unknown Languages

```csharp
var engine = new PluralizationEngine();

// Unknown languages default to English rules (2 forms)
int form = engine.GetPluralForm("unknownLang", 5); // 1 (plural)

// Get count - also defaults to 2
int count = engine.GetPluralFormCount("unknownLang"); // 2
```

## Plural Form Rules Details

### English-style (2 forms)
- Form 0: quantity == 1 (singular)
- Form 1: quantity != 1 (plural)

### Russian-style (3 forms)
- Form 0: ends with 1 (excluding 11)
- Form 1: ends with 2-4 (excluding 12-14)
- Form 2: everything else

### Polish-style (3 forms)
- Form 0: quantity == 1
- Form 1: quantity ends with 2-4 (excluding 12-14)
- Form 2: everything else

### Asian languages (1 form)
- No plural distinction

## Exception Handling

```csharp
var engine = new PluralizationEngine();

// Null rule throws ArgumentNullException
try
{
    engine.RegisterPluralizationRule("lang", null); // Throws
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Null language code throws ArgumentException
try
{
    engine.GetPluralForm(null, 1); // Throws
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Performance Characteristics

- **GetPluralForm**: O(1) - Simple function call
- **RegisterPluralizationRule**: O(1) - Dictionary insertion
- **GetPluralFormCount**: O(1) - Dictionary lookup

## Thread Safety

The `PluralizationEngine` is thread-safe for:
- Reading plural forms (GetPluralForm, GetPluralFormCount)
- Registering new rules (during initialization)

Avoid registering rules after initialization if accessed from multiple threads.

## Complete Example

```csharp
// Setup
var engine = new PluralizationEngine();
var manager = new TranslationManager(
    new LanguageProvider(),
    new MemoryTranslationProvider(),
    new MemoryTranslationCache(),
    engine
);

// Configure languages
manager.AddLanguage("en", "English");
manager.AddLanguage("ru", "Russian");

// Add translations
manager.SetLanguage("en");
manager.AddTranslation("en", "books[0]", "1 book");
manager.AddTranslation("en", "books[1]", "{count} books");

manager.SetLanguage("ru");
manager.AddTranslation("ru", "books[0]", "1 книга");
manager.AddTranslation("ru", "books[1]", "{count} книги");
manager.AddTranslation("ru", "books[2]", "{count} книг");

// Use
manager.SetLanguage("en");
Console.WriteLine(manager.TranslatePlural("books", 1));   // "1 book"
Console.WriteLine(manager.TranslatePlural("books", 5));   // "{count} books"

manager.SetLanguage("ru");
Console.WriteLine(manager.TranslatePlural("books", 1));   // "1 книга"
Console.WriteLine(manager.TranslatePlural("books", 2));   // "{count} книги"
Console.WriteLine(manager.TranslatePlural("books", 5));   // "{count} книг"
```

## Notes

- Plural forms are 0-indexed
- Form indices match the order returned by GetPluralFormCount
- Unknown languages fall back to English rules (2 forms)
- Rules can be overridden by registering a new rule for the same language code

