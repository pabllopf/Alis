# Architecture Documentation

## System Overview

The Profile extension module is designed with a focus on:

- **Testability**: All components are loosely coupled via interfaces
- **Extensibility**: Easy to add new monitoring strategies
- **Maintainability**: Small, focused classes with single responsibilities
- **Performance**: Minimal overhead with efficient measurements

## Component Design

### Layer Architecture

```
┌─────────────────────────────────────────────┐
│           Presentation Layer                │
│  (ProfilerScope, Formatters, Builders)      │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│           Service Layer                     │
│         (ProfilerService)                   │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│         Infrastructure Layer                │
│  (TimeTracker, ResourceMonitor, Factories)  │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│           Domain Layer                      │
│    (ResourceMetrics, ProfileSnapshot)       │
└─────────────────────────────────────────────┘
```

## Design Decisions

### Why Structs for Data Models?

**ResourceMetrics** and **ProfileSnapshot** are implemented as `readonly struct` because:

1. **Immutability**: Data should never change after capture
2. **Performance**: Stack allocation avoids GC pressure
3. **Value Semantics**: Natural copy behavior for snapshots
4. **Thread Safety**: Immutable data is inherently thread-safe

### Why Dependency Injection?

All dependencies are injected to:

1. Enable unit testing with mocks
2. Support different platform implementations
3. Follow the Dependency Inversion Principle
4. Allow runtime configuration flexibility

### Why No Singleton?

Singleton pattern is avoided because:

1. **Testability**: Singletons are difficult to mock and test
2. **Flexibility**: Multiple profiler instances may be needed
3. **Coupling**: Reduces tight coupling in the codebase
4. **Lifetime Management**: Explicit control over service lifetime

### Time Tracking Strategy

We use `Stopwatch` instead of `DateTime` because:

- Higher precision (nanosecond level)
- Not affected by system time changes
- Better performance characteristics
- Industry standard for performance measurement

## Interface Segregation

### ITimeTracker

Responsible only for time measurement:
- Start/Stop tracking
- Query elapsed time
- Query start time
- Reset state

### IResourceMonitor

Responsible only for resource queries:
- CPU usage measurement
- Memory usage measurement
- GC statistics
- Thread counting

### IProfilerService

Responsible for orchestrating:
- Starting/stopping profiling sessions
- Coordinating trackers and monitors
- Creating snapshots
- Managing session state

## Data Flow

### Start Profiling

```
Client
  │
  ├→ ProfilerService.StartProfiling()
  │    ├→ TimeTracker.Start()
  │    └→ ResourceMetricsFactory.CreateSnapshot()
  │         └→ ResourceMonitor.Get*()
  │
  └─ [Profiling Active]
```

### Stop Profiling

```
Client
  │
  ├→ ProfilerService.StopProfiling()
  │    ├→ TimeTracker.Stop()
  │    ├→ TimeTracker.GetElapsedTime()
  │    ├→ ResourceMetricsFactory.CreateSnapshot()
  │    │    └→ ResourceMonitor.Get*()
  │    └→ Create ProfileSnapshot
  │
  └─ ProfileSnapshot returned
```

## Error Handling Strategy

### Validation

- Constructor parameters are validated with null checks
- Numeric values are validated for range (non-negative)
- State is validated before operations (e.g., must be active to stop)

### Exception Types

- `ArgumentNullException`: For null dependencies
- `ArgumentException`: For invalid parameter values
- `InvalidOperationException`: For invalid state transitions

### Resource Monitoring Resilience

The `ProcessResourceMonitor` handles process exit gracefully:
- Returns 0 instead of throwing when process has exited
- Allows profiling to continue even if some metrics fail

## Testing Strategy

### Unit Tests

Each component has dedicated test class:

- **Models**: Test value semantics, immutability, validation
- **Implementations**: Test actual behavior with system APIs
- **Factories**: Test creation logic and coordination
- **Builders**: Test configuration and construction
- **Utilities**: Test lifecycle and RAII patterns

### Mocks

Mock implementations enable isolated testing:

- `MockTimeTracker`: Controllable time tracking
- `MockResourceMonitor`: Controllable resource metrics
- Both track method calls for verification

### Test Coverage Goals

- Line coverage: >90%
- Branch coverage: >85%
- All public APIs tested
- Edge cases and error paths tested

## Extension Guidelines

### Adding New Metrics

To add a new metric type:

1. Extend `IResourceMonitor` with new method
2. Update `ProcessResourceMonitor` implementation
3. Add field to `ResourceMetrics` struct
4. Update factory to capture new metric
5. Add tests for new functionality

### Custom Monitors

Example of a custom GPU monitor:

```csharp
public class GpuResourceMonitor : IResourceMonitor
{
    public double GetCpuUsage() => // Delegate to process
    public long GetMemoryUsage() => // GPU memory
    public int GetGarbageCollectionCount() => // From GC
    public int GetThreadCount() => // From process
}
```

### Platform-Specific Implementations

Use conditional compilation for platform-specific code:

```csharp
public class PlatformResourceMonitor : IResourceMonitor
{
    public double GetCpuUsage()
    {
        #if WINDOWS
            return GetWindowsCpuUsage();
        #elif LINUX
            return GetLinuxCpuUsage();
        #else
            return GetDefaultCpuUsage();
        #endif
    }
}
```

## Performance Optimization

### Minimize Allocations

- Use structs for data models (stack allocated)
- Reuse profiler service instances
- Avoid creating snapshots in tight loops

### Reduce Monitoring Overhead

- Call `GetCurrentSnapshot()` sparingly
- Don't profile every frame in a game loop
- Use conditional compilation to remove profiling code in release builds

### Best Practices

```csharp
// Good: Profile at checkpoints
void GameLoop()
{
    while (running)
    {
        if (frameCount % 60 == 0) // Every 60 frames
        {
            var snapshot = profiler.GetCurrentSnapshot();
            LogPerformance(snapshot);
        }
        
        UpdateGame();
        RenderGame();
    }
}

// Avoid: Profile every iteration
void GameLoop()
{
    while (running)
    {
        using (new ProfilerScope(profiler, LogPerformance)) // Too frequent!
        {
            UpdateGame();
            RenderGame();
        }
    }
}
```

## Thread Safety

### Thread-Safe Components

- `StopwatchTimeTracker`: Stopwatch is not thread-safe, use one per thread
- `ProcessResourceMonitor`: Process APIs are thread-safe
- `ResourceMetrics`: Immutable, inherently thread-safe
- `ProfileSnapshot`: Immutable, inherently thread-safe

### Multi-Threading Considerations

For multi-threaded profiling:

```csharp
// Create separate profiler per thread
ThreadLocal<IProfilerService> profiler = new ThreadLocal<IProfilerService>(
    () => ProfilerServiceBuilder.CreateDefault()
);

// Use in each thread
using (new ProfilerScope(profiler.Value, LogSnapshot))
{
    PerformThreadWork();
}
```

## Memory Management

### No Manual Memory Management

- No unmanaged resources used
- No IDisposable on services (only on ProfilerScope)
- Structs are stack-allocated and auto-cleaned

### GC Pressure

The module creates minimal GC pressure:
- Snapshots are structs (no heap allocation)
- Services are long-lived (create once, reuse)
- Temporary allocations only during snapshot creation

## Dependency Graph

```
ProfilerService
├── depends on → ITimeTracker
├── depends on → ResourceMetricsFactory
│                └── depends on → IResourceMonitor
└── returns → ProfileSnapshot
              └── contains → ResourceMetrics

ProfilerScope
└── depends on → IProfilerService

ProfilerServiceBuilder
├── creates → ProfilerService
├── creates → StopwatchTimeTracker (default)
├── creates → ProcessResourceMonitor (default)
└── creates → ResourceMetricsFactory
```

## Code Metrics Goals

- **Cyclomatic Complexity**: <10 per method
- **Class Size**: <300 lines
- **Method Size**: <50 lines
- **Constructor Parameters**: <4
- **Dependencies per Class**: <5

## Future Enhancements

Potential improvements for future versions:

1. **Async Support**: Async profiling for async/await scenarios
2. **Profiler Aggregation**: Combine multiple sessions into reports
3. **Export Formats**: JSON, XML, CSV export capabilities
4. **Visualization**: Integration with profiling visualization tools
5. **Performance Baselines**: Compare against baseline metrics
6. **Alerts**: Threshold-based performance alerts
7. **Sampling Profiler**: Statistical sampling for lower overhead

