# IsNotZeroAttribute Class

## Description

The `IsNotZeroAttribute` class is a validation attribute that checks if a given value is not zero. It is part of
the `Alis.Core.Aspect.Memory.Attributes` namespace.

## Usage

This attribute can be used to decorate properties or fields that should not be zero. If the value is zero,
a `NotZeroException` is thrown.

```csharp
[IsNotZero]
public int MyProperty { get; set; }
```

## Methods

### Validate(object value, string name)

This method validates the value. If the value is zero, it throws a `NotZeroException`.

- `value`: The value to validate.
- `name`: The name of the value.

## Exceptions

### NotZeroException

This exception is thrown when the value is zero.

## See Also

- `IsValidationAttribute`: The base class for this attribute.
