# NotNullException Class

## Description

The `NotNullException` class is an exception that is thrown when a value is null. It is part of
the `Alis.Core.Aspect.Memory.Exceptions` namespace.

## Usage

This exception can be thrown when a value that should not be null is validated.

```csharp
throw new NotNullException("Value cannot be null.");
```

## Constructor

### NotNullException(string message)

This constructor creates a new instance of the `NotNullException` class with a specified error message.

- `message`: The error message that explains the reason for the exception.

## See Also

- `Exception`: The base class for this exception.
