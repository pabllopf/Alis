
# NotZeroException Class

## Description

The `NotZeroException` class is an exception that is thrown when a value is zero. It is part of the `Alis.Core.Aspect.Memory.Exceptions` namespace.

## Usage

This exception can be thrown when a value that should not be zero is validated.

```csharp
throw new NotZeroException("Value cannot be zero.");
```

## Constructor

### NotZeroException(string message)

This constructor creates a new instance of the `NotZeroException` class with a specified error message.

- `message`: The error message that explains the reason for the exception.

## See Also

- `Exception`: The base class for this exception.
