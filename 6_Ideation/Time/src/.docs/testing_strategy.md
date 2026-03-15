# Testing Strategy

## Test projects and files

- Test project: `6_Ideation/Time/test/Alis.Core.Aspect.Time.Test.csproj`
- Main suites:
  - `6_Ideation/Time/test/ClockTest.cs`
  - `6_Ideation/Time/test/ClockExtensiveTest.cs`

## What is validated

The existing tests verify core behaviors of `Clock`.

### Lifecycle behavior

- constructor initializes reset state
- `Start()` transitions to running state
- `Stop()` transitions to stopped state
- `Reset()` clears elapsed values
- `Restart()` clears and immediately restarts

### Elapsed value contracts

- `Elapsed` increases while running
- `Elapsed` remains stable while stopped
- `ElapsedMilliseconds`, `ElapsedSeconds`, and `ElapsedTicks` report expected ranges
- `ToString()` returns a non-empty elapsed representation

### Idempotence and accumulation

- `Start()` on a running clock is a no-op
- `Stop()` on a stopped clock is a no-op
- multiple start/stop cycles accumulate elapsed time

### Multi-instance behavior

- multiple clocks run independently

## Test runtime characteristics

- Several tests use `Thread.Sleep(...)` and assert range-based timing.
- Timing assertions include tolerances to reduce flakiness.
- Results may still vary by host load, scheduler resolution, and runtime.

## Suggested future improvements

- Introduce a pluggable time provider (or internal abstraction) to reduce wall-clock dependence in tests.
- Add stress tests for repeated rapid start/stop cycles.
- Add concurrency-focused tests if thread-safety becomes a module requirement.

