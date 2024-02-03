# IsNotNullAttribute Class

## Description

The `IsNotNullAttribute` class is a validation attribute that checks if a given value is not null. It is part of
the `Alis.Core.Aspect.Memory.Attributes` namespace.

## Usage

This attribute can be used to decorate properties or fields that should not be null. If the value is null,
a `NotNullException` is thrown.

```csharp
[IsNotNull]
public string MyProperty { get; set; }
```

## Methods

### Validate(object value, string name)

This method validates the value. If the value is null, it throws a `NotNullException`.

- `value`: The value to validate.
- `name`: The name of the value.

## Exceptions

### NotNullException

This exception is thrown when the value is null.

## See Also

- `IsValidationAttribute`: The base class for this attribute.
