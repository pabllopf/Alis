# TimeConfiguration Class

The `TimeConfiguration` class is part of the `Alis.Core.Aspect.Time` namespace. It is used to manage time-related configurations in an application.

## Properties

- `FixedTimeStep`: A framerate-independent interval that dictates when physics calculations and FixedUpdate() events are performed.
- `MaximumAllowedTimeStep`: A framerate-independent interval that caps the worst case scenario when frame-rate is low. Physics calculations and FixedUpdate() events will not be performed for longer time than specified.
- `TimeScale`: The speed at which time progresses. Change this value to simulate bullet-time effects. A value of 1 means real-time. A value of .5 means half speed; a value of 2 is double speed.

## Constructor

The `TimeConfiguration` class has a constructor that accepts three parameters, each corresponding to one of the properties mentioned above. The parameters have default values, so they can be omitted when instantiating the `TimeConfiguration` class.

```csharp
public TimeConfiguration(float fixedTimeStep = 0.016f, float maximumAllowedTimeStep = 0.10f, float timeScale = 1.00f)
```

## Usage

Here is an example of how to use the `TimeConfiguration` class:

```csharp
TimeConfiguration timeConfig = new TimeConfiguration(0.02f, 0.15f, 1.0f);
```

In this example, a new `TimeConfiguration` object is created with a `FixedTimeStep` of 0.02, a `MaximumAllowedTimeStep` of 0.15, and a `TimeScale` of 1.0.