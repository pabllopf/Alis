---
title: Alis.Benchmark
tags:
  - presentation
  - benchmark
  - performance
status: Draft
license: GPLv3
---

# Alis.Benchmark

**Layer:** 1_Presentation
**Path:** `1_Presentation/Benchmark/src/Alis.Benchmark.csproj`

## Purpose

Performance benchmarks for the Alis framework using BenchmarkDotNet.

## Benchmarks

- **ECS Performance**: Alis ECS vs Frent ECS comparison
- **Entity Component System**: Create, update, destroy operations with 1-3 components
- **Neighbor Cache**: Alis vs Frent neighbor cache
- **Collections**: FastArray vs FastestArray vs NativeArray
- **Class vs Struct**: Performance comparison
- **Interface vs Abstract**: Dispatch overhead
- **Iterators**: Loop iteration patterns
- **Strings**: String manipulation
- **IDs**: ID storage
- **Loop**: Loop constructs
- **RemoveAt**: RemoveAt vs RemoveUnorderedAt

## Dependencies

- Alis (2_Application)

## Related Documents

- [[Alis]]
- [[Alis.Core.Ecs]]
- [[performance-overview]]
