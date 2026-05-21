# Usage Examples

## Basic measurement

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();
clock.Start();

clock.Stop();

Console.WriteLine($"Elapsed: {clock.ElapsedMilliseconds} ms");
```

## Factory-based start

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

clock.Stop();
Console.WriteLine(clock.Elapsed);
```

## Accumulated timing across phases

```csharp
using Alis.Core.Aspect.Time;

Clock clock = new Clock();

clock.Start();
clock.Stop();

clock.Start();
clock.Stop();

Console.WriteLine($"Total ms: {clock.ElapsedMilliseconds}");
```

## Restart for a fresh run

```csharp
using Alis.Core.Aspect.Time;

Clock clock = Clock.Create();

clock.Restart();

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

