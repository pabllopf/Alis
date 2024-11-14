# TranslationManager Class

The `TranslationManager` class is part of the `Alis.Core.Aspect.Translation` namespace. It is used to manage
translations in the application.

## Properties

- `Language`: This property gets or sets the current language of the application. It is represented as a `Language`
  object.

## Methods

- `SetLanguage(Language language)`: Sets the language using the specified `Language` object.
- `SetLanguage(string name, string localCode)`: Sets the language using the specified name and local code.
- `AddLanguage(Language language)`: Adds a new language to the application.
- `Translate(string key)`: Translates the specified key and returns the translated string.
- `AddTranslation(Language language, string key, string value)`: Adds a new translation to the specified language.
- `AddTranslation(string localCode, string key, string value)`: Adds a new translation to the language with the
  specified local code.
- `GetAvailableLanguages()`: Returns a list of available languages in the application.

## Usage

Here is an example of how to use the `TranslationManager` class:

```csharp
TranslationManager translationManager = new TranslationManager();
Language english = new Language { Name = "English", Code = "EN" };
translationManager.AddLanguage(english);
translationManager.SetLanguage(english);
translationManager.AddTranslation(english, "hello", "Hello");
Console.WriteLine(translationManager.Translate("hello")); // Outputs: Hello
```

In this example, a new `TranslationManager` object is created, a new `Language` object is added, the language is set, a
new translation is added, and the translation is printed to the console.

## Notes

The `TranslationManager` class is useful for managing translations in your application. It provides a set of methods to
add languages, set the current language, add translations, and translate keys. The `TranslationManager` class is
designed to be easy to use and understand, making it a great choice for developers of all skill levels.