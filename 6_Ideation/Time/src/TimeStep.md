# TimeStep Class

The `TimeStep` class is part of the `Alis.Core.Aspect.Time` namespace. It is used to manage and measure time steps in an
application.

## Properties

- `DeltaTime`: Time step (Delta time).
- `DeltaTimeRatio`: dt * inv_dt0.
- `InvertedDeltaTime`: Inverse time step (0 if dt == 0).
- `InvertedDeltaTimeZero`: The inverted delta time.
- `PositionIterations`: The position iterations.
- `VelocityIterations`: The velocity iterations.
- `WarmStarting`: The warm starting.

## Methods

- `Reset()`: Resets this instance. It does not return any value.

## Usage

Here is an example of how to use the `TimeStep` class:

```csharp
TimeStep timeStep = new TimeStep();
// Do some work
timeStep.Reset();
```

In this example, a new `TimeStep` object is created. After some work is done, the `Reset` method is called to reset the
instance.

## Notes

The `TimeStep` class is useful for managing and measuring time steps in your application. It provides a set of
properties to get and set time step information, and a method to reset the instance. The `TimeStep` class is designed to
be easy to use and understand, making it a great choice for developers of all skill levels.