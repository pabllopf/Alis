---
title: Extension: Profile
tags: [on]
---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Profile` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core |

## Purpose

The Profile extension provides runtime profiling and performance monitoring for Alis applications. It tracks CPU usage, memory allocation, frame timing, and custom metrics.

## Core Components

### ProfilerService

```csharp
public class ProfilerService
```

Central profiling service for performance monitoring.

**Responsibilities:**
- Track frame timing and FPS
- Monitor memory allocation
- Profile method execution time
- Collect custom metrics
- Generate performance reports

**Key Methods:**
- `Start()` — Begin profiling session
- `Stop()` — End profiling session
- `BeginSection(string name)` — Start timing a code section
- `EndSection(string name)` — End timing a code section
- `RecordMetric(string name, double value)` — Record custom metric
- `GetReport()` — Generate performance report
- `ExportJson(string path)` — Export metrics to JSON

### FrameStats

```csharp
public record FrameStats
{
    public long FrameNumber { get; init; }
    public double DeltaTime { get; init; }
    public double Fps { get; init; }
    public long MemoryUsed { get; init; }
    public int DrawCalls { get; init; }
    public int Triangles { get; init; }
}
```

Immutable snapshot of per-frame performance data.

### ProfileSection

```csharp
public class ProfileSection : IDisposable
{
    public string Name { get; }
    public Stopwatch Stopwatch { get; }
    public long ElapsedMilliseconds { get; }
}
```

RAII-style section timing using `using` blocks.

## Usage Examples

### Basic Profiling

```csharp
var profiler = new ProfilerService();
profiler.Start();

// Profile a section
using (profiler.BeginSection("Render"))
{
    renderer.Draw(scene);
}

// Record custom metric
profiler.RecordMetric("entities_processed", entityCount);

// Get report
var report = profiler.GetReport();
Console.WriteLine($"Average FPS: {report.AverageFps}");
Console.WriteLine($"Peak Memory: {report.PeakMemory} bytes");
```

### Automatic Frame Timing

```csharp
profiler.Start();

while (running)
{
    using (profiler.BeginSection("Frame"))
    {
        // Game logic
        gameState.Update(deltaTime);
        
        // Rendering
        renderer.Draw(scene);
    }
    
    // profiler auto-tracks frame timing
    var frameStats = profiler.CurrentFrame;
    if (frameStats.FrameNumber % 60 == 0)
    {
        Console.WriteLine($"FPS: {frameStats.Fps:F1}");
    }
}
```

### Memory Tracking

```csharp
profiler.TrackMemory = true;

// ... game runs ...

var report = profiler.GetReport();
Console.WriteLine($"Total Allocated: {report.TotalAllocated} bytes");
Console.WriteLine($"GC Collections: {report.GcCollections}");
```

## Metrics Collected

| Metric | Type | Description |
|--------|------|-------------|
| Frame Time | double | Milliseconds per frame |
| FPS | double | Frames per second |
| Memory Used | long | Current memory usage |
| Peak Memory | long | Maximum memory usage |
| GC Gen0 | int | Gen 0 collections |
| GC Gen1 | int | Gen 1 collections |
| GC Gen2 | int | Gen 2 collections |
| Draw Calls | int | Graphics draw calls |
| Triangles | int | Triangles rendered |

## Export Format

```json
{
  "session": {
    "startTime": "2024-01-15T10:30:00Z",
    "endTime": "2024-01-15T10:35:00Z",
    "totalFrames": 18000,
    "averageFps": 60.0
  },
  "frames": [
    {
      "frameNumber": 1,
      "deltaTime": 16.67,
      "memoryUsed": 104857600
    }
  ],
  "sections": [
    {
      "name": "Render",
      "averageMs": 8.33,
      "maxMs": 16.67,
      "minMs": 2.5
    }
  ],
  "metrics": {
    "entities_processed": {
      "average": 1500,
      "max": 2000,
      "min": 1000
    }
  }
}
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |
| Web (WASM) | ⚠️ | Limited metrics |

## Performance Impact

- Minimal overhead when profiling is disabled
- Section timing uses `Stopwatch` for high precision
- Metrics are buffered to avoid I/O during frames

## Related

- [[extensions/index|Extensions Index]]
- [[testing/analysis|Testing Analysis]]
- [[architecture/repository-overview|Repository Overview]]
