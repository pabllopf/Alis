# Clock API Reference

tags:
  - domain,api,reference,documentation

## Class

- **Type**: `Clock`
- **Namespace**: `Alis.Core.Aspect.Time`
- **Source**: `6_Ideation/Time/src/Clock.cs`

## Construction

### `Clock()`

Creates a new clock in reset state:

- `IsRunning == false`
- `Elapsed == TimeSpan.Zero`

### `Clock.Create()`

Factory method that returns a new running clock.

## Properties

### `bool IsRunning`

Returns whether the clock is currently running.

```csharp
Clock clock = Clock.Create();
bool running = clock.IsRunning; // true

clock.Stop();
bool stopped = clock.IsRunning; // false
```

### `TimeSpan Elapsed`

Returns total elapsed time:

- While stopped: accumulated value
- While running: accumulated value plus current running segment

```csharp
Clock clock = Clock.Create();
Thread.Sleep(100);
clock.Stop();

TimeSpan elapsed = clock.Elapsed; // ~100ms
```

### `long ElapsedMilliseconds`

Returns `Elapsed.TotalMilliseconds` cast to `long`.

```csharp
long ms = clock.ElapsedMilliseconds;
```

### `long ElapsedSeconds`

Returns `ElapsedMilliseconds / 1000`.

```csharp
long seconds = clock.ElapsedSeconds;
```

### `long ElapsedTicks`

Returns `Elapsed.Ticks` (100-nanosecond units).

```csharp
long ticks = clock.ElapsedTicks;
```

## Methods

### `void Start()`

Starts measuring time.

**Behavior:**
- If the clock is stopped, stores current UTC time and moves to running state
- If already running, does nothing

```csharp
Clock clock = new Clock();
clock.Start(); // Now running
clock.Start(); // No-op, still running
```

### `void Stop()`

Stops measuring and accumulates the current running segment.

**Behavior:**
- If running, adds `(UtcNow - startTime)` to accumulated elapsed and marks as stopped
- If already stopped, does nothing

```csharp
Clock clock = Clock.Create();
Thread.Sleep(100);
clock.Stop(); // Now stopped, elapsed frozen

long ms = clock.ElapsedMilliseconds; // ~100ms
```

### `void Reset()`

Resets all state:

- Clears elapsed to zero
- Marks clock as stopped
- Clears start marker (`DateTime.MinValue`)

```csharp
Clock clock = Clock.Create();
Thread.Sleep(100);
clock.Reset();

bool isRunning = clock.IsRunning; // false
long elapsed = clock.ElapsedMilliseconds; // 0
```

### `void Restart()`

Equivalent to resetting and immediately starting:

- Elapsed becomes zero
- Start marker is set to `DateTime.UtcNow`
- Clock is running

```csharp
Clock clock = Clock.Create();
Thread.Sleep(100);
clock.Restart(); // Reset and start

bool isRunning = clock.IsRunning; // true
long elapsed = clock.ElapsedMilliseconds; // 0
```

### `string ToString()`

Returns `Elapsed.ToString()`.

```csharp
Clock clock = Clock.Create();
Thread.Sleep(100);
string time = clock.ToString(); // "00:00:00.1000000"
```

## Behavioral Notes

1. **Multiple Start/Stop cycles** accumulate elapsed time
2. **Calling Elapsed repeatedly while running** will generally return increasing values
3. **Calling Elapsed while stopped** returns a stable value until next state change
4. **Not thread-safe** - Do not share across threads

## Usage Pattern

```csharp
using Alis.Core.Aspect.Time;

// Create and start immediately
Clock clock = Clock.Create();

// Do work
DoWork();

// Stop and check
clock.Stop();
long ms = clock.ElapsedMilliseconds;
```

## Related

- [[Time Overview]] - Complete overview
- [[Usage Examples]] - Usage patterns
