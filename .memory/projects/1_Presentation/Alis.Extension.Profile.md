# Alis.Extension.Profile

## Overview
Performance profiling extension for ALIS applications. Provides CPU time tracking, memory metrics, and resource monitoring for performance analysis.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~9 C# files across multiple directories

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Profile Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides application profiling capabilities including execution time measurement, resource consumption tracking (CPU, memory), and performance snapshot generation. Uses dependency injection for testability and follows the Facade pattern for simplified API.

## Key Components

### ProfilerService
Main orchestrator following the Facade pattern:
- Session-based profiling (Start/Stop)
- Real-time snapshot retrieval
- Resource metrics tracking
- Elapsed time measurement
- Reset capability

### Interfaces
- **IProfilerService** — Profiler service contract
- **ITimeTracker** — Time measurement abstraction
- **IResourceMonitor** — Resource monitoring contract

### Implementations
- **StopwatchTimeTracker** — High-precision time tracking via System.Diagnostics.Stopwatch
- **ProcessResourceMonitor** — Process-level CPU/memory monitoring

### Models
- **ProfileSnapshot** — Profiling session data (elapsed time, start/end metrics, timestamps)
- **ResourceMetrics** — CPU and memory usage measurements

### Builder Pattern
- **ProfilerServiceBuilder** — Fluent builder for ProfilerService configuration

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- [[Alis.App.Core]] (2_Application) — Core framework

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: enabled

## Architecture Notes
1. Facade pattern simplifies profiling API
2. Builder pattern for flexible configuration
3. Interface-based abstractions for testability
4. Stopwatch-based high-precision time tracking
5. Snapshot pattern for immutable profiling data
6. DI-ready constructor design

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Profile.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Benchmark]] — Benchmarking application
- [[Alis.Core.Aspect.Logging]] — Logging infrastructure
- [[Alis.Core.Aspect.Time]] — Time aspect

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
