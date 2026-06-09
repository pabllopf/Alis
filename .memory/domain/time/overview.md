---
title: Alis.Core.Aspect.Time
tags:
  - domain
  - api
  - reference
  - documentation

status: draft

license: GPLv3
---


## Overview

**Alis.Core.Aspect.Time** provides a high-resolution time measurement utility similar to a stopwatch. It allows measuring elapsed time with start, stop, reset, and restart operations using `DateTime.UtcNow` as the underlying time source.

## Purpose

This project enables:
- High-resolution time measurement
- Elapsed time tracking across multiple phases
- Performance profiling and benchmarking
- Time-based operations in game loops

## Architecture

### Core Class

| Class | Namespace | Purpose |
|---|---|---|
| `Clock` | `Alis.Core.Aspect.Time` | High-resolution stopwatch |

## Dependencies

```xml
<Import Project="$(SolutionDir).config/Config.props"/>
```

No external NuGet packages. Pure .NET Standard implementation.

## Target Frameworks

Multi-targeted to 15+ frameworks:
- .NET Standard 2.0-2.1
- .NET Core 2.0-3.1
- .NET 5.0-10.0
- .NET Framework 4.61-4.81

## Thread Safety

**Not thread-safe** - Instances should not be shared across threads without external synchronization.

## Usage Pattern

### Basic Measurement

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();
clock.Start();

// Code to measure
DoWork();

clock.Stop();
Console.WriteLine($"Elapsed: {clock.ElapsedMilliseconds} ms");
```

### Factory Method

```csharp
using Alis.Core.Aspect.Time;

// Create and start immediately
Clock clock = Clock.Create();

// Do work
DoWork();

clock.Stop();
Console.WriteLine(clock.Elapsed);
```

### Accumulated Timing

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();

// Phase 1
clock.Start();
Phase1();
clock.Stop();

// Phase 2
clock.Start();
Phase2();
clock.Stop();

// Phase 3
clock.Start();
Phase3();
clock.Stop();

Console.WriteLine($"Total ms: {clock.ElapsedMilliseconds}");
```

### Restart for Fresh Run

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

// Do work
DoWork();

clock.Restart(); // Reset and start again

// Measure again
DoWork();

clock.Stop();
Console.WriteLine($"Run seconds: {clock.ElapsedSeconds}");
```

## File Structure

```
6_Ideation/Time/src/
├── Clock.cs - Main stopwatch implementation
└── .docs/
    ├── clock_api.md - API reference
    ├── usage_examples.md - Usage examples
    ├── arquitecture.md - Architecture notes
    ├── design_constraints.md - Design constraints
    ├── module_overview.md - Module overview
    └── testing_strategy.md - Testing strategy
```

## API Reference

### Properties

| Property | Type | Description |
|---|---|---|
| `IsRunning` | `bool` | Whether clock is currently running |
| `Elapsed` | `TimeSpan` | Total elapsed time |
| `ElapsedMilliseconds` | `long` | Elapsed time in milliseconds |
| `ElapsedSeconds` | `long` | Elapsed time in whole seconds |
| `ElapsedTicks` | `long` | Elapsed time in 100-nanosecond units |

### Methods

| Method | Description |
|---|---|
| `Clock()` | Constructor - creates stopped clock |
| `Create()` | Factory - creates and starts clock |
| `Start()` | Start or resume measuring |
| `Stop()` | Stop and freeze elapsed value |
| `Reset()` | Reset to zero and stop |
| `Restart()` | Reset and start immediately |
| `ToString()` | Return elapsed as string |

## Behavioral Notes

1. **Multiple Start/Stop cycles** accumulate elapsed time
2. **Elapsed while running** includes current running segment
3. **Elapsed while stopped** returns stable value until next state change
4. **Multiple Start() calls** while running are no-ops
5. **Multiple Stop() calls** while stopped are no-ops

## Performance Characteristics

- **Start/Stop**: O(1) - Simple state changes
- **Elapsed property**: O(1) - Computed from stored values
- **Memory**: Minimal - 3 private fields (TimeSpan, bool, DateTime)

## Use Cases

### Performance Profiling

```csharp
Clock clock = Clock.Create();

// Measure operation
var result = ExpensiveOperation();

clock.Stop();
Console.WriteLine($"Operation took {clock.ElapsedMilliseconds}ms");
```

### Game Loop Timing

```csharp
Clock clock = Clock.Create();

while (gameRunning)
{
    clock.Start();
    
    Update();
    Draw();
    
    clock.Stop();
    
    // Maintain 60 FPS
    if (clock.ElapsedMilliseconds < 16)
        Thread.Sleep(16 - (int)clock.ElapsedMilliseconds);
}
```

### Multi-Phase Measurement

```csharp
Clock clock = new Clock();

// Load phase
clock.Start();
LoadAssets();
clock.Stop();
Console.WriteLine($"Loaded in {clock.ElapsedMilliseconds}ms");

// Initialize phase
clock.Restart();
InitializeSystems();
clock.Stop();
Console.WriteLine($"Initialized in {clock.ElapsedMilliseconds}ms");

// Total time
Console.WriteLine($"Total: {new Clock().Create().ElapsedMilliseconds}ms");
```

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Fluent]] - Fluent builder system
- [[Alis.Core.Aspect.Memory]] - Memory management
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU General Public License v3.0

## Author

Pablo Perdomo Falcón  
Web: https://www.pabllopf.dev/
