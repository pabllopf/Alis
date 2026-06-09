---
title: Alis.Core.Aspect
tags: [declaration,contract,interface,documentation]
---


## Overview
Aspect-oriented programming library for ALIS game engine. Provides fluent interfaces, logging, and cross-cutting concerns management.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: 4 files (sample/test only)

## Project Details

| Property | Value |
|---|---|
| **Layer** | 5_Declaration |
| **Type** | Library (AOP Framework) |
| **Framework** | net8.0 (multi-targeted) |
| **Output Type** | Class Library |
| **Namespace** | Alis.Core.Aspect |

## Purpose
Implements aspect-oriented programming patterns for cross-cutting concerns. Provides fluent interfaces, logging infrastructure, and declarative programming patterns.

## Architecture

### Core Components

#### Fluent Interface Pattern
Sample implementation showing fluent builder pattern.

**Sample: Car Builder**
```csharp
Car sampleCar = Car
    .Create()
    .WithName("Ferrari")
    .WithModel("F8")
    .WithColor("Red")
    .Build();
```

**Fluent Pattern Benefits:**
- Readable, chainable API
- Builder pattern implementation
- Type-safe configuration
- Immutable object creation

#### Logging System
Cross-cutting logging infrastructure.

**Features:**
- Multi-level logging (Trace, Log, Info, Warning, Error)
- Thread-safe logging
- Log level filtering
- Platform-independent logging

**Usage:**
```csharp
Logger.Trace("Trace message");
Logger.Log("Log message");
Logger.Info("Info message");
Logger.Warning("Warning message");
Logger.Error("Error message");
```

### Sample Projects

#### Car Sample
Fluent builder pattern example.

**Implementation:**
- Static `Create()` method
- Fluent property setters
- `Build()` method for finalization
- Immutable result

**Code:**
```csharp
Car sampleCar = Car
    .Create()
    .WithName("Ferrari")
    .WithModel("F8")
    .WithColor("Red")
    .Build();

Logger.Info($"Car: Name={sampleCar.Name} Model={sampleCar.Model} Color={sampleCar.Color}");
```

#### Time Sample
Clock/timer implementation.

**Features:**
- Elapsed time tracking
- Start/Stop functionality
- Millisecond precision
- Thread-safe timing

**Usage:**
```csharp
Clock clock = new Clock();
clock.Start();

// Perform operations
Thread.Sleep(1);

clock.Stop();
Logger.Info($"Elapsed time: {clock.ElapsedMilliseconds} ms");
```

#### Math Sample
Vector operations integration.

**Features:**
- Vector2F operations
- Mathematical computations
- Vector arithmetic

**Usage:**
```csharp
Logger.Info(new Vector2F(3.0f, 2.0f).ToString());
```

## Key Components

### Sample Files (4 files)
- **Program.cs** - Sample application
- **Car.cs** - Fluent builder example
- **CarBuilder.cs** - Builder implementation
- **DefaultTest.cs** - Unit tests

### Logging Infrastructure
- Logger class (external dependency)
- Log levels: Trace, Debug, Info, Warning, Error
- Thread-safe logging

## Dependencies

### Internal
- [[Alis.Core.Aspect.Logging]] - Logging infrastructure
- [[Alis.Core.Aspect.Math.Vector]] - Vector operations
- [[Alis.Core.Aspect.Time]] - Time management
- [[Alis.Core.Aspect.Memory]] - Memory management

### External
- None (pure .NET)

## Build Configuration

| Property | Value |
|---|---|
| **LangVersion** | 13 |
| **Nullable** | enabled |
| **Target Frameworks** | 15+ (netstandard2.0–net10.0, net461–net481) |

## Design Patterns

### Fluent Interface
- Method chaining
- Readable API
- Builder pattern

### Aspect-Oriented Programming
- Cross-cutting concerns
- Logging as aspect
- Separation of concerns

### Builder Pattern
- Object construction
- Fluent configuration
- Immutable results

## Public APIs

### Logger Class
```csharp
public static class Logger
{
    static void Trace(string message);
    static void Log(string message);
    static void Info(string message);
    static void Warning(string message);
    static void Error(string message);
}
```

### Car Builder (Sample)
```csharp
public static class Car
{
    static ICarBuilder Create();
}

public interface ICarBuilder
{
    ICarBuilder WithName(string name);
    ICarBuilder WithModel(string model);
    ICarBuilder WithColor(string color);
    Car Build();
}
```

### Clock Class (Sample)
```csharp
public class Clock
{
    void Start();
    void Stop();
    long ElapsedMilliseconds { get; }
}
```

## Namespaces

| Namespace | Purpose |
|---|---|
| `Alis.Core.Aspect` | Core aspect types |
| `Alis.Core.Aspect.Logging` - Logging infrastructure |
| `Alis.Core.Aspect.Math` - Math operations |
| `Alis.Core.Aspect.Time` - Time management |
| `Alis.Core.Aspect.Memory` - Memory management |

## Usage Examples

### Fluent Interface
```csharp
var car = Car.Create()
    .WithName("Ferrari")
    .WithModel("F8")
    .WithColor("Red")
    .Build();
```

### Logging
```csharp
Logger.Info("Application started");
Logger.Warning("Low memory warning");
Logger.Error("Critical error occurred");
```

### Timing
```csharp
var clock = new Clock();
clock.Start();
// Perform operations
clock.Stop();
Console.WriteLine($"Took {clock.ElapsedMilliseconds}ms");
```

## Configuration Usage

**Logging Configuration:**
- Set log level (Trace, Debug, Info, Warning, Error)
- Configure log output (console, file, network)
- Thread-safe logging

**Fluent API:**
- Method chaining
- Type-safe configuration
- Immutable object creation

## EF Core Usage

**None** - Pure AOP library, no ORM usage.

## Testing Status

| Test Type | Status |
|---|---|
| **Unit Tests** | Sample tests included |
| **Integration Tests** - Sample applications |
| **Coverage** | Low - sample project |

## Security-Sensitive Areas

1. **Logging Security**
   - Sensitive data in logs
   - Log injection
   - Thread safety

2. **Fluent API Security**
   - Input validation
   - Object state validation
   - Immutable guarantees

## Performance-Sensitive Areas

1. **Logging Performance**
   - String formatting
   - Thread synchronization
   - I/O operations

2. **Timing Operations**
   - High-resolution timers
   - Thread-safe counters
   - Precision accuracy

## Risks

1. **Thread Safety**
   - Logger not thread-safe
   - Clock state management
   - Concurrent access issues

2. **Resource Management**
   - Clock not disposed
   - Log file handles
   - Memory leaks

3. **Validation**
   - No input validation in samples
   - Fluent API state validation
   - Object consistency

## TODOs

- [ ] Add actual source files
- [ ] Expand logging infrastructure
- [ ] Add more fluent samples
- [ ] Create comprehensive tests
- [ ] Document AOP patterns
- [ ] Add performance benchmarks

## Complexity Observations

- **Low**: Fluent interface pattern
- **Low**: Logging infrastructure
- **Medium**: Sample applications
- **Low**: AOP patterns

## Related

- [[5_Declaration/Alis.Core.Aspect]] - Core aspect library
- [[4_Operation/Alis.Core.Ecs]] - ECS engine
- [[4_Operation/Alis.Core.Graphic]] - Graphics rendering
- [[6_Ideation/Alis.Core.Logging]] - Logging system

## See Also

- [[projects/5_Declaration/Core]] - Declaration layer
- [[architecture/repository-overview]] - Repository architecture
- [[glossary/aspect]] - Aspect definition
- [[glossary/fluent-interface]] - Fluent interface definition
