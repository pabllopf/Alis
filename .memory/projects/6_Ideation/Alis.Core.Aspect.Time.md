---
title: Alis.Core.Aspect.Time
tags:
  - ideation
  - aspect
  - library
  - documentation

status: draft
---


## Overview

The **Alis.Core.Aspect.Time** project provides a high-resolution time measurement utility for the ALIS game engine. It implements a stopwatch-like `Clock` class for measuring elapsed time with start, stop, reset, and restart operations.

## Purpose

- Measure elapsed time with high resolution
- Support timing for game loops and performance profiling
- Provide UTC-based time measurements
- Enable timing operations without GC pressure

## Architecture

### Clock Class

Main entry point for time measurement:

```csharp
public class Clock
{
    // Properties
    TimeSpan Elapsed { get; }
    long ElapsedMilliseconds { get; }
    long ElapsedSeconds { get; }
    long ElapsedTicks { get; }
    bool IsRunning { get; }
    
    // Methods
    void Start();
    void Stop();
    void Reset();
    void Restart();
    static Clock Create(); // Factory method
}
```

### Implementation Details

- Uses `DateTime.UtcNow` as underlying time source
- Not thread-safe - requires external synchronization for shared use
- Accumulates elapsed time when stopped, continues when restarted

## Files

| File | Lines | Description |
|------|-------|-------------|
| Clock.cs | 171 | Main clock implementation |

## Dependencies

- **System** - DateTime, TimeSpan

## Usage Example

```csharp
using Alis.Core.Aspect.Time;

// Create and start clock
var clock = Clock.Create();

// Do some work
DoWork();

// Stop and check elapsed time
clock.Stop();
Console.WriteLine($"Took {clock.ElapsedMilliseconds}ms");

// Restart for next measurement
clock.Restart();
DoMoreWork();
clock.Stop();
```

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance goals.

## TODOs

- [ ] Add thread-safe variant
- [ ] Support high-resolution timer (Stopwatch) as alternative
- [ ] Add timing statistics (min, max, average)

## Related Projects

- [[Alis.Core.Ecs]] - Uses Clock for frame timing
- [[Alis.Core.Graphic]] - Rendering uses timing
