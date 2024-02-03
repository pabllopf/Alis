# NotEmptyException Class

## Description

The `NotEmptyException` class is an exception that is thrown when a value is null or empty. It is part of
the `Alis.Core.Aspect.Memory.Exceptions` namespace.

## Usage

This exception can be thrown when a value that should not be null or empty is validated.

```csharp
throw new NotEmptyException("Value cannot be null or empty.");
```

## Constructor

### NotEmptyException(string message)

This constructor creates a new instance of the `NotEmptyException` class with a specified error message.

- `message`: The error message that explains the reason for the exception.

## See Also

- `Exception`: The base class for this exception.
