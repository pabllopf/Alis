# Usage Examples

## Basic measurement

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();
clock.Start();

// Work to measure...
clock.Stop();

Console.WriteLine($"Elapsed: {clock.ElapsedMilliseconds} ms");
```

## Factory-based start

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

// Work...
clock.Stop();
Console.WriteLine(clock.Elapsed);
```

## Accumulated timing across phases

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();

clock.Start();
// Phase 1
clock.Stop();

clock.Start();
// Phase 2
clock.Stop();

Console.WriteLine($"Total ms: {clock.ElapsedMilliseconds}");
```

## Restart for a fresh run

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

// Warm-up logic...
clock.Restart();

// Actual run...
clock.Stop();
Console.WriteLine($"Run seconds: {clock.ElapsedSeconds}");
```

## Notes for reliable measurement

- Prefer measuring meaningful blocks rather than very tiny operations.
- Account for scheduler jitter when using sleeps or thread-blocking calls.
- For strict micro-benchmarking scenarios, use a dedicated benchmarking tool.

## Existing sample location

A minimal sample exists at:

- `6_Ideation/Time/sample/Program.cs`

