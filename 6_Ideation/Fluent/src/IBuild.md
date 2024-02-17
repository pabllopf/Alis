# IBuild Interface

## Namespace

`Alis.Core.Aspect.Fluent`

## Description

The `IBuild` interface is a part of the `Alis.Core.Aspect.Fluent` namespace. It provides a contract for building
instances of a specific type.

## Generic Type Parameters

- `TOrigin`: The type of the object that is being built.

## Methods

### Build

The `Build` method is used to construct an instance of `TOrigin`.

#### Declaration

```csharp
TOrigin Build();
```

#### Returns

Type: `TOrigin`  
The constructed instance of `TOrigin`.

## Examples

The `IBuild` interface can be implemented by any class that needs to construct instances of a specific type. Here is a
basic example:

```csharp
public class ExampleBuilder : IBuild<Example>
{
    private Example _example;

    public ExampleBuilder()
    {
        _example = new Example();
    }

    public Example Build()
    {
        return _example;
    }
}
```

In this example, `ExampleBuilder` is a class that implements the `IBuild` interface to construct instances of
the `Example` class.

