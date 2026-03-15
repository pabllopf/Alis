# Module Overview: Alis.Core.Aspect.Time

## Purpose

`Alis.Core.Aspect.Time` is a lightweight time utility module that exposes a single public class, `Clock`, to measure elapsed time.

It is designed for:

- game-loop timing basics
- measuring operation duration
- simple diagnostics and instrumentation

## What is included

- `Clock` class in `6_Ideation/Time/src/Clock.cs`
- Build project in `6_Ideation/Time/src/Alis.Core.Aspect.Time.csproj`
- Sample usage in `6_Ideation/Time/sample/Program.cs`
- Unit tests in `6_Ideation/Time/test/ClockTest.cs` and `6_Ideation/Time/test/ClockExtensiveTest.cs`

## Public API at a glance

- State and values:
  - `IsRunning`
  - `Elapsed`
  - `ElapsedMilliseconds`
  - `ElapsedSeconds`
  - `ElapsedTicks`
- Operations:
  - `Start()`
  - `Stop()`
  - `Reset()`
  - `Restart()`
  - `Create()`
  - `ToString()`

## Implementation style

- Uses `DateTime.UtcNow` as the time source.
- Computes elapsed values on demand (no background thread).
- Accumulates total time over multiple `Start()`/`Stop()` cycles.
- Keeps behavior deterministic for repeated `Start()` or `Stop()` calls (both are no-op when already in the target state).

## Scope and non-goals

In scope:

- practical elapsed-time measurement with a minimal API
- broad compatibility across many target frameworks inherited from shared build config

Out of scope:

- high-precision benchmarking APIs
- frame scheduler, timers, or delayed callbacks
- explicit thread-safety guarantees

