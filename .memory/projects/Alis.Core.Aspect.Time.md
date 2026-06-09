---
title: Alis.Core.Aspect.Time
tags:
  - project
  - documentation
  - reference

status: draft
---


**Status**: ✅ Documented  
**Type**: Time Measurement / Stopwatch  
**Layer**: 6_Ideation  
**Target Frameworks**: 15+ (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)

## Overview

High-resolution time measurement utility using `DateTime.UtcNow`. Provides stopwatch-like functionality with start, stop, reset, and restart operations.

## Key Features

- ✅ High-resolution timing
- ✅ Accumulated timing across phases
- ✅ Factory method for convenience
- ✅ Multiple time unit properties
- ✅ Simple, focused API

## Public API

| Type | Purpose |
|---|---|
| `Clock` | High-resolution stopwatch |

## Properties

- `IsRunning` - Whether clock is running
- `Elapsed` - Total elapsed time (TimeSpan)
- `ElapsedMilliseconds` - Elapsed in milliseconds
- `ElapsedSeconds` - Elapsed in whole seconds
- `ElapsedTicks` - Elapsed in 100-ns units

## Methods

- `Start()` - Start or resume measuring
- `Stop()` - Stop and freeze elapsed
- `Reset()` - Reset to zero and stop
- `Restart()` - Reset and start immediately
- `Create()` - Factory method (create + start)

## Documentation

- [[Domain/Time/Overview]] - Complete overview
- [[Domain/Time/Clock-API]] - API reference

## File Structure

```
6_Ideation/Time/src/
├── Clock.cs - Main implementation
└── .docs/
    ├── clock_api.md
    ├── usage_examples.md
    ├── arquitecture.md
    ├── design_constraints.md
    ├── module_overview.md
    └── testing_strategy.md
```

## Thread Safety

**Not thread-safe** - Do not share instances across threads.

## Tests

See: `6_Ideation/Time/test/Alis.Core.Aspect.Time.Test.csproj`

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Fluent]] - Fluent builder system
- [[Alis.Core.Aspect.Memory]] - Memory management
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU GPL v3.0

## Author

Pablo Perdomo Falcón
