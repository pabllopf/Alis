# Clock API Reference

## Class

- **Type**: `Clock`
- **Namespace**: `Alis.Core.Aspect.Time`
- **Source**: `6_Ideation/Time/src/Clock.cs`

## Construction

### `Clock()`

Creates a new clock in reset state:

- `IsRunning == false`
- `Elapsed == TimeSpan.Zero`

### `Clock.Create()`

Factory method that returns a new running clock.

## Properties

### `bool IsRunning`

Returns whether the clock is currently running.

### `TimeSpan Elapsed`

Returns total elapsed time:

- while stopped: accumulated value
- while running: accumulated value plus current running segment

### `long ElapsedMilliseconds`

Returns `Elapsed.TotalMilliseconds` cast to `long`.

### `long ElapsedSeconds`

Returns `ElapsedMilliseconds / 1000`.

### `long ElapsedTicks`

Returns `Elapsed.Ticks`.

## Methods

### `void Start()`

Starts measuring time.

Behavior:

- If the clock is stopped, stores current UTC time and moves to running state.
- If already running, does nothing.

### `void Stop()`

Stops measuring and accumulates the current running segment.

Behavior:

- If running, adds `(UtcNow - startTime)` to accumulated elapsed and marks as stopped.
- If already stopped, does nothing.

### `void Reset()`

Resets all state:

- clears elapsed to zero
- marks clock as stopped
- clears start marker (`DateTime.MinValue`)

### `void Restart()`

Equivalent to resetting and immediately starting:

- elapsed becomes zero
- start marker is set to `DateTime.UtcNow`
- clock is running

### `string ToString()`

Returns `Elapsed.ToString()`.

## Behavioral notes

- Multiple `Start()`/`Stop()` cycles accumulate elapsed time.
- Calling `Elapsed` repeatedly while running will generally return increasing values.
- Calling `Elapsed` while stopped returns a stable value until next state change.

## Usage pattern

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

// Do work...
clock.Stop();

long ms = clock.ElapsedMilliseconds;
```

