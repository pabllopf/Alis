# IsNotEmptyAttribute Class

## Description

The `IsNotEmptyAttribute` class is a validation attribute that checks if a given value is not null or empty. It is part
of the `Alis.Core.Aspect.Memory.Attributes` namespace.

## Usage

This attribute can be used to decorate properties or fields that should not be null or empty. If the value is a string
and it is null or empty, a `NotEmptyException` is thrown.

```csharp
[IsNotEmpty]
public string MyProperty { get; set; }
```

## Methods

### Validate(object value, string name)

This method validates the value. If the value is a string and it is null or empty, it throws a `NotEmptyException`.

- `value`: The value to validate.
- `name`: The name of the value.

## Exceptions

### NotEmptyException

This exception is thrown when the value is a string and it is null or empty.

## See Also

- `IsValidationAttribute`: The base class for this attribute.

