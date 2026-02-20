# ITranslationObserver Interface Documentation

## Overview

The `ITranslationObserver` interface defines the contract for observing translation events. Observers are notified when important translation events occur, such as language changes or translation updates.

## Methods

### OnLanguageChanged(ILanguage language) : void
Called when the current language has changed.

```csharp
public void OnLanguageChanged(ILanguage language)
{
    Console.WriteLine($"Language changed to {language.Code}");
}
```

### OnTranslationsUpdated(string languageCode) : void
Called when translations have been updated.

```csharp
public void OnTranslationsUpdated(string languageCode)
{
    Console.WriteLine($"Translations updated for {languageCode}");
}
```

### OnTranslationNotFound(string languageCode, string key) : void
Called when a translation is requested but not found.

```csharp
public void OnTranslationNotFound(string languageCode, string key)
{
    Console.WriteLine($"Translation not found: {languageCode}/{key}");
}
```

## Usage

```csharp
public class MyTranslationObserver : ITranslationObserver
{
    public void OnLanguageChanged(ILanguage language)
    {
        Console.WriteLine($"Language changed to {language.Name}");
    }

    public void OnTranslationsUpdated(string languageCode)
    {
        Console.WriteLine($"Translations updated for {languageCode}");
    }

    public void OnTranslationNotFound(string languageCode, string key)
    {
        Console.WriteLine($"Missing translation: {languageCode}/{key}");
    }
}

var manager = new TranslationManager();
var observer = new MyTranslationObserver();
manager.Subscribe(observer);
manager.SetLanguage("en"); // OnLanguageChanged will be called
```

## Implementation Guidelines

1. **Thread Safety**: Observers may be called from different threads
2. **Performance**: Keep observer methods fast to avoid blocking the translation system
3. **Error Handling**: Handle exceptions internally to avoid disrupting the translation system
4. **Unsubscription**: Remember to unsubscribe observers when no longer needed

## Common Use Cases

- Logging language changes for analytics
- Updating UI when language changes
- Collecting missing translation keys for later analysis
- Triggering cache invalidation
- Notifying other components of system state changes

## Notes

- Multiple observers can be subscribed simultaneously
- Observers are notified in subscription order
- Observers should not block or throw exceptions

