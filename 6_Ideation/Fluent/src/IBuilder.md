# IBuilder Interface

## Namespace

`Alis.Core.Aspect.Fluent`

## Description

The `IBuilder` interface is a part of the `Alis.Core.Aspect.Fluent` namespace. It provides a contract for building
instances of a specific type.

## Generic Type Parameters

- `TOut`: The type of the object that is being built.

## Methods

### Builder

The `Builder` method is used to construct an instance of `TOut`.

#### Declaration

```csharp
TOut Builder();
```

#### Returns

Type: `TOut`
The constructed instance of `TOut`.

## Examples

The `IBuilder` interface can be implemented by any class that needs to construct instances of a specific type. Here is a
basic example:

```csharp
public class ExampleBuilder : IBuilder<Example>
{
    private Example _example;

    public ExampleBuilder()
    {
        _example = new Example();
    }

    public Example Builder()
    {
        return _example;
    }
}
```

In this example, `ExampleBuilder` is a class that implements the `IBuilder` interface to construct instances of
the `Example` class.

