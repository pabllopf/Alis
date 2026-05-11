# Time Module Plan

## Overview

Simple stopwatch-like timing utility for the Alis game engine. Provides elapsed time tracking with start/stop/reset/restart semantics.

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Time | `src/` | Library (net461-net9.0) | 1 source file |
| Alis.Core.Aspect.Time.Sample | `sample/` | Console App | - |
| Alis.Core.Aspect.Time.Test | `test/` | xUnit Tests | - |

## Source Files (src/)

### Clock (`Clock.cs`)
Single class - the entire module implementation:

**Fields:**
- `_elapsed` (`TimeSpan`) - accumulated elapsed time from previous sessions
- `_isRunning` (`bool`) - running state flag
- `_startTime` (`DateTime`) - last start timestamp

**Properties:**
- `ElapsedSeconds` (`long`) - elapsed time in seconds (via ElapsedMilliseconds / 1000)
- `IsRunning` (`bool`) - whether the clock is currently running
- `Elapsed` (`TimeSpan`) - computed property: `_isRunning ? _elapsed + (DateTime.UtcNow - _startTime) : _elapsed`
- `ElapsedMilliseconds` (`long`) - elapsed time in milliseconds (cast from TimeSpan)

**Methods:**
- `Clock()` - constructor calls `Reset()`
- `Start()` - sets `_isRunning = true`, records `_startTime = DateTime.UtcNow`
- `Stop()` - sets `_elapsed += (DateTime.UtcNow - _startTime)`, `_isRunning = false`
- `Reset()` - sets `_elapsed = TimeSpan.Zero`, `_isRunning = false`
- `Restart()` - calls `Reset()` then `Start()`

## Dependencies

- **Internal**: None (leaf module)
- **External**: None

## Architecture Notes

- **Minimal implementation**: Single class, ~80 lines total. No interfaces, no abstractions.
- **DateTime-based**: Uses `DateTime.UtcNow` instead of `Stopwatch.ElapsedTicks` - lower precision but monotonic across app domain boundaries.
- **Accumulated timing**: `_elapsed` persists across Start/Stop cycles - calling Stop() saves the accumulated time, so subsequent Start() continues from where it left off.
- **No high-resolution timing**: `DateTime.UtcNow` has ~15ms resolution on Windows, ~1ms on Linux. Not suitable for frame-accurate timing.

## Code Quality Issues

1. **Low precision timing**: `DateTime.UtcNow` has limited resolution (~1-15ms depending on OS). Game engines typically need millisecond or microsecond precision for frame timing. Should use `Stopwatch.ElapsedTicks` or `DateTimeOffset.UtcNow` (higher precision on .NET Core).
2. **No delta time**: Game engines need `DeltaTime` (time since last frame) for frame-rate independent physics. Clock only provides cumulative elapsed time.
3. **No fixed timestep support**: No concept of fixed update interval (e.g., 60fps = 16.67ms). Game physics typically runs on fixed timestep while rendering runs at variable rate.
4. **Single responsibility gap**: Clock is too simple to be a module. It's essentially a thin wrapper around `DateTime.UtcNow`. Could be replaced with a struct or extension methods.
5. **No pause/resume**: `Stop()` accumulates time but there's no way to "pause" without losing accumulated time context.
6. **ElapsedSeconds truncation**: `ElapsedMilliseconds / 1000` truncates - should use `TimeSpan.TotalSeconds` for fractional seconds.
7. **No time scaling**: No concept of `TimeScale` (slow motion, pause, speed up). Game engines typically support `TimeScale = 0.5f` for half-speed.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Switch to higher precision timer**: Replace `DateTime.UtcNow` with `Stopwatch.ElapsedTicks` or `DateTimeOffset.UtcNow` for sub-millisecond precision.
2. **Add TimeScale support**: Add `TimeScale` property (default 1.0f) that multiplies all elapsed time calculations - essential for slow-motion/pause functionality.

### Priority 2 - Important
3. **Add DeltaTime property**: Track `_lastElapsed` and compute `DeltaTime` on each access for frame-rate independent updates.
4. **Add FixedTimestep support**: Optional fixed interval with `AccumulateFixedTime()` that returns number of fixed steps elapsed - for physics updates.
5. **Make it a struct**: Since Clock has no virtual members or inheritance, convert to `readonly struct` for zero-allocation usage in hot paths.

### Priority 3 - Nice to have
6. **Add Stopwatch integration**: Expose `Stopwatch` instance for external high-precision timing.
7. **Add elapsed events**: `OnTick`, `OnElapsed` events for callback-based timing.
8. **Add performance counter**: Platform-specific high-resolution counter for benchmarking.

## Test Coverage

- Tests for Start/Stop/Reset lifecycle
- Tests for elapsed time accuracy
- Tests for IsRunning state transitions
- Tests for accumulated timing across multiple Start/Stop cycles
- Tests for Restart behavior
