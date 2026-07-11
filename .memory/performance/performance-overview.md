---
title: Performance Overview
tags:
  - performance
  - overview
  - benchmarking
status: Draft
license: GPLv3
---

# Performance Overview

## Performance-Sensitive Areas

| Area | Project | Concern | Priority |
|---|---|---|---|
| Entity-Component System | Alis.Core.Ecs | Entity iteration, archetype queries, component access | Critical |
| Physics Simulation | Alis.Core.Physic | Collision detection, rigid body dynamics | Critical |
| Graphics Rendering | Alis.Core.Graphic | Frame rate, draw calls, shader compilation | Critical |
| Audio Mixing | Alis.Core.Audio | Audio buffer processing, latency | High |
| Data Serialization | Alis.Core.Aspect.Data | JSON parsing, serialization speed | High |
| Memory Management | Alis.Core.Aspect.Memory | Asset loading, cache efficiency | High |
| Math Operations | Alis.Core.Aspect.Math | Vector/matrix operations, trig functions | High |

## Performance Patterns

1. **Data-Oriented Design**: ECS components stored in contiguous arrays for cache efficiency
2. **Span<T> Usage**: Prefer spans over arrays for slice operations
3. **No LINQ in Hot Paths**: Manual loops preferred for iteration
4. **Struct Usage**: Value types for small, frequently-accessed data
5. **Source Generators**: Compile-time code generation avoids reflection
6. **Object Pooling**: ECS entity recycling

## Benchmark Project

`Alis.Benchmark` contains performance comparisons for:

- Class vs Struct performance
- Custom collection implementations
- ECS iteration strategies
- Interface vs abstract class dispatch
- Loop optimization techniques
- Collection removal strategies
- String operations

## Performance Constraints

- AOT compatibility required (no runtime code generation)
- No `System.Reflection.Emit`
- Minimal allocations in hot paths
- SIMD-friendly data layouts preferred

## Related

- [[Performance Index]]
- [[Alis.Benchmark]]
- [[Architecture Rules]]
