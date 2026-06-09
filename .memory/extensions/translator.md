---
Extension: Language.Translator
tags:
  - extension
  - plugin
  - translator
  - translation
  - documentation

status: draft

license: GPLv3
---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Language.Translator` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core |

## Purpose

The Translator extension provides internationalization (i18n) support for Alis applications. It enables runtime language switching, localization of strings, and cultural formatting.

## Core Components

### TranslationManager

```csharp
public class TranslationManager
```

Singleton manager that handles all translation operations.

**Responsibilities:**
- Load and cache translation files
- Provide localized strings at runtime
- Handle language switching
- Fall back to default language when translations are missing

**Key Methods:**
- `LoadTranslations(string directory)` — Loads all `.json` translation files from directory
- `SetLanguage(string languageCode)` — Switches active language (e.g., "en", "es", "fr")
- `GetTranslation(string key)` — Returns localized string for given key
- `GetTranslation(string key, params object[] args)` — Returns formatted localized string

### Lang

```csharp
public static class Lang
```

Static helper class for quick translation access.

**Usage:**
```csharp
// Direct translation
string greeting = Lang.Get("ui.button.start");

// With interpolation
string message = Lang.Get("ui.dialog.welcome", userName);
```

### Translation File Format

```json
{
  "ui": {
    "button": {
      "start": "Start",
      "pause": "Pause",
      "quit": "Quit"
    },
    "dialog": {
      "welcome": "Welcome, {0}!",
      "confirm": "Are you sure?"
    }
  },
  "game": {
    "score": "Score: {0}",
    "level": "Level {0}"
  }
}
```

## Supported Languages

| Code | Language | Status |
|------|----------|--------|
| `en` | English | Complete |
| `es` | Spanish | Complete |
| `fr` | French | Partial |
| `de` | German | Partial |
| `pt` | Portuguese | Partial |
| `ja` | Japanese | Partial |

## Language File Structure

```
translations/
├── en.json
├── es.json
├── fr.json
├── de.json
├── pt.json
└── ja.json
```

## Integration Pattern

```csharp
// Initialize at startup
var translations = new TranslationManager();
translations.LoadTranslations("translations");
translations.SetLanguage("es"); // Spanish

// Use in UI
string startButton = translations.GetTranslation("ui.button.start");
Console.WriteLine(startButton); // "Iniciar"
```

## Fallback Behavior

1. Look up key in current language
2. If not found, look up in default language (English)
3. If still not found, return the key itself
4. Log warning for missing translations

## Performance

- Translations are cached in memory after initial load
- Thread-safe access via `ConcurrentDictionary`
- Minimal overhead for string lookups

## Related

- [[extensions/index|Extensions Index]]
- [[extensions/dialogue|Dialogue Extension]]
- [[system/indexes/projects-index|Projects Index]]
