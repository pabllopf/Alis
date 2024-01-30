# Clock Class

The `Clock` class is part of the `Alis.Core.Aspect.Time` namespace. It is used to manage and measure time in an application.

## Properties

- `Elapsed`: Gets the total elapsed time measured by the current instance.
- `ElapsedMilliseconds`: Gets the total elapsed time measured by the current instance, in milliseconds.
- `ElapsedTicks`: Gets the total elapsed time measured by the current instance, in timer ticks.
- `ElapsedSeconds`: Gets the total elapsed time measured by the current instance, in seconds.

## Methods

- `Start()`: Starts, or resumes, measuring elapsed time for an interval.
- `Stop()`: Stops measuring elapsed time for an interval.
- `Reset()`: Stops time interval measurement and resets the elapsed time to zero.

## Usage

Here is an example of how to use the `Clock` class:

```csharp
Clock clock = new Clock();
clock.Start();
// Do some work
clock.Stop();
Console.WriteLine($"Elapsed time: {clock.ElapsedMilliseconds} ms");
```

In this example, a new `Clock` object is created and started. After some work is done, the clock is stopped and the elapsed time is printed to the console.

### Notes

The Clock class is useful for measuring elapsed time during the execution of your program. It can be used to time the execution of code blocks, measure performance, or create time-dependent functionality. The Elapsed property provides the most accurate time measurement, while the ElapsedMilliseconds and ElapsedSeconds properties provide more human-readable time measurements. The ElapsedTicks property provides a low-level time measurement in timer ticks.