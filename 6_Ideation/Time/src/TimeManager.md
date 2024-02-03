# TimeManager Class

The `TimeManager` class is part of the `Alis.Core.Aspect.Time` namespace. It provides an interface to get time
information and manage time in an application.

## Properties

- `Configuration`: Gets or sets the value of the configuration. It is represented as a `TimeConfiguration` object.
- `Clock`: Gets the value of the clock. It is represented as a `Clock` object.
- `DeltaTime`: The interval in seconds from the last frame to the current one.
- `FixedDeltaTime`: The interval in seconds at which physics and other fixed frame rate updates.
- `FixedTime`: The time since the last FixedUpdate started. This is the time in seconds since the start of the game.
- `FixedTimeAsDouble`: The double precision time since the last FixedUpdate started. This is the time in seconds since
  the start of the game.
- `FixedUnscaledDeltaTime`: The timeScale-independent interval in seconds from the last Runtime.FixedUpdate() phase to
  the current one.
- `FixedUnscaledTime`: The timeScale-independent time at the beginning of the last Runtime.FixedUpdate() phase. This is
  the time in seconds since the start of the game.
- `FixedUnscaledTimeAsDouble`: The double precision timeScale-independent time at the beginning of the last FixedUpdate.
  This is the time in seconds since the start of the game.
- `FrameCount`: The total number of frames since the start of the game.
- `InFixedTimeStep`: Returns true if called inside a fixed time step callback (like Runtime FixedUpdate), otherwise
  returns false.
- `MaximumDeltaTime`: The maximum value of TimeManager.DeltaTime in any given frame. This is a time in seconds that
  limits the increase of TimeManager.time between two frames.
- `RealtimeSinceStartup`: The real time in seconds since the game started.
- `RealtimeSinceStartupAsDouble`: The real time in seconds since the game started. Double precision version of
  realtimeSinceStartup.
- `SmoothDeltaTime`: A smoothed out TimeManager.DeltaTime.
- `Time`: The time at the beginning of this frame.
- `TimeAsDouble`: The double precision time at the beginning of this frame. This is the time in seconds since the start
  of the game.
- `TimeScale`: The scale at which time passes.
- `UnscaledDeltaTime`: The timeScale-independent interval in seconds from the last frame to the current one.
- `UnscaledTime`: The timeScale-independent time for this frame. This is the time in seconds since the start of the
  game.
- `UnscaledTimeAsDouble`: The double precision timeScale-independent time for this frame. This is the time in seconds
  since the start of the game.

## Constructor

The `TimeManager` class has a constructor that initializes a new instance of the `TimeManager` class and starts the
clock.

```csharp
public TimeManager()
{
    Clock = new Clock();
    Clock.Start();
}
```

## Usage

Here is an example of how to use the `TimeManager` class:

```csharp
TimeManager timeManager = new TimeManager();
// Do some work
Console.WriteLine($"Elapsed time: {timeManager.Clock.ElapsedMilliseconds} ms");
```

In this example, a new `TimeManager` object is created and started. After some work is done, the elapsed time is printed
to the console.

### Notes

The TimeManager class is a crucial part of any game or application that requires time management. It provides a
comprehensive set of properties and methods to manage time in your application. The TimeManager class uses the Clock and
TimeConfiguration classes to provide a high level of abstraction for managing time. The TimeManager class is designed to
be easy to use and understand, making it a great choice for developers of all skill levels.