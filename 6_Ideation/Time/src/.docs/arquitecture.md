# Alis.Core.Aspect.Time Architecture

## Intent

`Alis.Core.Aspect.Time` provides a minimal, dependency-free clock abstraction for elapsed-time tracking inside the Alis ecosystem. The module is intentionally compact: one public type (`Clock`) with a stopwatch-like API that works across the framework's multi-target setup.

## Module boundaries

- **Namespace**: `Alis.Core.Aspect.Time`
- **Primary source file**: `6_Ideation/Time/src/Clock.cs`
- **Project file**: `6_Ideation/Time/src/Alis.Core.Aspect.Time.csproj`
- **Consumers**:
  - Samples in `6_Ideation/Time/sample/`
  - Tests in `6_Ideation/Time/test/`
  - Any higher-level Alis modules that need elapsed-time measurement

## High-level design

The clock stores three internal fields:

- `_elapsed` (`TimeSpan`): accumulated time while stopped or between cycles
- `_startTime` (`DateTime` UTC): timestamp captured when `Start()` or `Restart()` begins a run
- `_isRunning` (`bool`): current run state

Elapsed time is computed lazily:

- If stopped: `Elapsed == _elapsed`
- If running: `Elapsed == _elapsed + (DateTime.UtcNow - _startTime)`

This design avoids background timers and threads. Time is only recalculated when a property is read.

## Lifecycle model

- **Constructed**: equivalent to `Reset()` (`Elapsed = 0`, `IsRunning = false`)
- **Running**: after `Start()` or `Create()`/`Restart()`
- **Stopped**: after `Stop()` accumulates the running segment into `_elapsed`
- **Reset state**: after `Reset()`, all accumulated time is cleared

## Behavioral contract

- `Start()` on an already running clock is a no-op.
- `Stop()` on an already stopped clock is a no-op.
- Multiple start/stop cycles accumulate total elapsed time.
- `Restart()` clears accumulated time and starts immediately.
- `Create()` returns a new already-running instance.

## Timing source and implications

`Clock` uses `DateTime.UtcNow` as its time source.

Implications:

- Portable and simple, with no extra dependencies.
- Resolution and precision depend on platform/runtime timer behavior.
- Suitable for general elapsed-time measurement, not high-precision profiling.

## Build integration architecture

`Alis.Core.Aspect.Time.csproj` imports shared rules from `.config/Config.props`, which contributes:

- Multi-target framework strategy by configuration (`Debug` vs `Release`)
- Common analyzer/warning policy
- Packaging metadata and SourceLink defaults
- Documentation file generation in Release mode (`GenerateDocumentationFile=true`)

The module itself overrides output layout through `OutDir` to keep binaries organized by configuration, runtime identifier, and target framework.

## Why this architecture fits the module

- Single responsibility: elapsed-time tracking only
- Low maintenance cost: tiny API, tiny implementation
- Broad compatibility: no platform-specific APIs in core logic
- Predictable semantics aligned with common stopwatch expectations

