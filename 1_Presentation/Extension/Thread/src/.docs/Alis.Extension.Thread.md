# Alis.Extension.Thread

Advanced parallel execution extension for the Alis game engine. This extension provides transparent multi-threading support for ECS component updates with zero-overhead abstractions and memory-efficient execution.

## Features

- 🚀 **Automatic Parallelization**: Components marked with `[ParallelSafe]` or implementing `IParallelCapable` are automatically parallelized
- 🎯 **Smart Batching**: Intelligent work partitioning based on CPU cores and batch size constraints
- 💾 **Memory Efficient**: Uses `Span<T>`, object pooling, and zero-allocation strategies
- 🔧 **Configurable**: Fluent API for easy configuration
- 🧪 **Type-Safe**: Compile-time safety with attribute-based configuration
- 📊 **No Singleton Pattern**: Dependency injection friendly architecture
- ⚡ **Zero Configuration**: Works out-of-the-box with sensible defaults

## Quick Start

### Installation

Add the package reference to your project:

```bash
dotnet add package Alis.Extension.Thread
```

### Basic Usage

#### 1. Mark Your Components as Parallel-Safe

```csharp
using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Interfaces;

[ParallelSafe(minBatchSize: 128)]
public struct VelocityComponent : IParallelCapable
{
    public float X;
    public float Y;
    public float Z;
}

[ParallelSafe(minBatchSize: 64)]
public struct PositionComponent : IParallelCapable
{
    public float X;
    public float Y;
    public float Z;
}
```

#### 2. Create a Parallel Executor

```csharp
using Alis.Extension.Thread.Builder;
using Alis.Extension.Thread.Integration;

// Simple setup with auto-detection
ComponentUpdateParallelizer parallelizer = ParallelExtensionBuilder.Create()
    .EnableParallelExecution()
    .WithAutoThreadCount()
    .BuildParallelizer();
```

#### 3. Execute Parallel Updates

```csharp
const int entityCount = 10000;
Span<VelocityComponent> velocities = GetVelocities();
Span<PositionComponent> positions = GetPositions();

// Update velocities in parallel
parallelizer.ExecuteComponentUpdate<VelocityComponent>(velocities, index =>
{
    velocities[index].X *= 1.01f;
    velocities[index].Y *= 1.01f;
    velocities[index].Z *= 1.01f;
});

// Update positions in parallel using range action
parallelizer.ExecuteRangeUpdate<PositionComponent>(entityCount, (start, length) =>
{
    for (int i = start; i < start + length; i++)
    {
        positions[i].X += velocities[i].X * deltaTime;
        positions[i].Y += velocities[i].Y * deltaTime;
        positions[i].Z += velocities[i].Z * deltaTime;
    }
});
```

## Advanced Configuration

### Custom Thread Manager

```csharp
using Alis.Extension.Thread.Configuration;

ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
    .WithParallelExecution(true)
    .WithMaxDegreeOfParallelism(4)
    .WithMinBatchSizePerThread(32)
    .WithDefaultMinBatchSize(128)
    .Build();

using (ThreadManager manager = new ThreadManager(config))
{
    // Use manager.ParallelExecutor for updates
}
```

### Fluent Builder API

```csharp
ThreadManager manager = ParallelExtensionBuilder.Create()
    .EnableParallelExecution()
    .WithMaxThreads(8)
    .WithMinBatchSize(64)
    .BuildManager();
```

### Custom Execution Strategy

```csharp
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Strategies;

public class CustomStrategy : IParallelExecutionStrategy
{
    public bool CanExecuteInParallel(Type componentType)
    {
        // Custom logic to determine parallelizability
        return componentType.GetCustomAttribute<ParallelSafeAttribute>() != null;
    }

    public int GetMinimumBatchSize(Type componentType)
    {
        // Custom batch size logic
        return 256;
    }
}

// Use custom strategy
var config = new ParallelExtensionConfigurationBuilder()
    .WithExecutionStrategy(new CustomStrategy())
    .Build();
```

## Architecture

### Core Components

- **ParallelExecutionContext**: Manages parallelism configuration and system detection
- **ParallelExecutionScheduler**: Schedules and executes work items across threads
- **BatchPartitioner**: Divides work into optimal batches
- **WorkItemPool**: Object pool for reducing allocations
- **AttributeBasedExecutionStrategy**: Determines component parallel capability

### Integration Components

- **ComponentUpdateParallelizer**: High-level API for ECS integration
- **ParallelExtensionBuilder**: Fluent configuration builder
- **ThreadManager**: Manages both legacy threads and parallel execution

## Performance Best Practices

### 1. Batch Size Tuning

```csharp
// For small components (< 32 bytes)
[ParallelSafe(minBatchSize: 256)]
public struct SmallComponent { }

// For large components or expensive operations
[ParallelSafe(minBatchSize: 64)]
public struct ExpensiveComponent { }
```

### 2. Avoid Shared State

```csharp
// ❌ BAD: Race condition
int sharedCounter = 0;
parallelizer.ExecuteComponentUpdate<MyComponent>(components, index =>
{
    sharedCounter++; // Race condition!
});

// ✅ GOOD: Thread-local state
parallelizer.ExecuteRangeUpdate<MyComponent>(count, (start, length) =>
{
    int localCounter = 0;
    for (int i = start; i < start + length; i++)
    {
        localCounter++;
    }
    // Aggregate results safely outside parallel region
});
```

### 3. Use Span<T> for Zero-Copy

```csharp
// ✅ GOOD: Zero-copy access
Span<VelocityComponent> velocities = archetypeData.GetComponentSpan<VelocityComponent>();
parallelizer.ExecuteComponentUpdate<VelocityComponent>(velocities, index =>
{
    ref VelocityComponent vel = ref velocities[index];
    vel.X *= damping;
});
```

### 4. Profile Before Parallelizing

Not all updates benefit from parallelization. Profile your code:

```csharp
Stopwatch sw = Stopwatch.StartNew();

// Sequential baseline
for (int i = 0; i < count; i++)
{
    ProcessComponent(i);
}
long sequentialTime = sw.ElapsedMilliseconds;

// Parallel version
sw.Restart();
parallelizer.ExecuteUpdate(count, (start, length) =>
{
    for (int i = start; i < start + length; i++)
    {
        ProcessComponent(i);
    }
}, forceParallel: true);
long parallelTime = sw.ElapsedMilliseconds;

Console.WriteLine($"Speedup: {(double)sequentialTime / parallelTime:F2}x");
```

## Legacy Thread Support

The extension maintains backward compatibility with legacy thread tasks:

```csharp
using (ThreadManager manager = new ThreadManager())
{
    CancellationTokenSource cts = new CancellationTokenSource();
    ThreadTask task = new ThreadTask(token =>
    {
        while (!token.IsCancellationRequested)
        {
            // Do work
            Thread.Sleep(100);
        }
    }, cts.Token);

    manager.StartThread(task);
    
    // Later...
    manager.StopThread(task);
}
```

## Thread Safety Guidelines

### Safe Operations
- ✅ Reading component data in parallel
- ✅ Modifying component data at different indices
- ✅ Using thread-local variables
- ✅ Atomic operations (`Interlocked.*`)

### Unsafe Operations (Without Synchronization)
- ❌ Writing to shared collections
- ❌ Modifying global state
- ❌ Non-atomic read-modify-write operations
- ❌ IO operations (consider sequential or use sync)

## Debugging Parallel Code

### Enable Sequential Mode for Debugging

```csharp
// Disable parallelism during development
ThreadManager manager = ParallelExtensionBuilder.Create()
    .DisableParallelExecution()
    .BuildManager();
```

### Check Thread Count

```csharp
ParallelExecutionContext context = new ParallelExecutionContext();
Console.WriteLine($"Available processors: {context.ProcessorCount}");
Console.WriteLine($"Max parallel threads: {context.MaxDegreeOfParallelism}");
```

## Examples

See the [Sample Project](sample/Program.cs) for complete examples including:

- Legacy thread task system
- Modern parallel execution
- ECS component integration
- Performance benchmarking

## Requirements

- .NET Standard 2.0 or .NET 8.0+
- Alis.Core.Ecs (for ECS integration)

## License

GNU General Public License v3.0

## Contributing

Contributions are welcome! Please ensure:
- Clean code following C# conventions
- XML documentation for public APIs
- Unit tests for new features
- No singleton patterns

## Authors

Pablo Perdomo Falcón - [pabllopf.dev](https://www.pabllopf.dev/)

