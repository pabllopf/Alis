# LanguageNotFound Class

The `LanguageNotFound` class is part of the `Alis.Core.Aspect.Translation` namespace. It is a custom exception used to indicate that a specific language was not found in the application.

## Constructor

- `LanguageNotFound(string message)`: Initializes a new instance of the `LanguageNotFound` class with a specified error message.

## Usage

Here is an example of how to use the `LanguageNotFound` class:

```csharp
try
{
    // Attempt to find a language
    // If the language is not found, throw a LanguageNotFound exception
    throw new LanguageNotFound("Language not found");
}
catch (LanguageNotFound ex)
{
    Console.WriteLine(ex.Message);
}
```

In this example, a `LanguageNotFound` exception is thrown and then caught in a catch block. The message of the exception is then printed to the console.

## Notes

The `LanguageNotFound` class is a custom exception that you can throw when a specific language is not found in your application. It extends the `Exception` class and takes a string message as a parameter in its constructor. This message can be used to provide more detailed information about the exception.