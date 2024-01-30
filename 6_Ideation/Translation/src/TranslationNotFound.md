# TranslationNotFound Class

The `TranslationNotFound` class is part of the `Alis.Core.Aspect.Translation` namespace. It is a custom exception used to indicate that a specific translation was not found in the application.

## Constructor

- `TranslationNotFound(string key)`: Initializes a new instance of the `TranslationNotFound` class with a specified key. The error message is automatically set to "Translation not found for key: {key}".

## Usage

Here is an example of how to use the `TranslationNotFound` class:

```csharp
try
{
    // Attempt to find a translation
    // If the translation is not found, throw a TranslationNotFound exception
    throw new TranslationNotFound("hello");
}
catch (TranslationNotFound ex)
{
    Console.WriteLine(ex.Message);
}
```

In this example, a `TranslationNotFound` exception is thrown and then caught in a catch block. The message of the exception is then printed to the console.

## Notes

The `TranslationNotFound` class is a custom exception that you can throw when a specific translation is not found in your application. It extends the `Exception` class and takes a string key as a parameter in its constructor. This key is used to provide more detailed information about the exception.