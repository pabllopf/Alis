---
title: Alis.Benchmark
tags:
  - project
  - benchmark
  - performance
  - testing
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Benchmark

## Overview

Performance benchmarking application (Layer 1 - Presentation). Measures and compares performance of various engine systems and data structures.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation |
| **Project Path** | `1_Presentation/Benchmark/src/` |
| **Has Tests** | No |
| **Output Type** | Exe |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/ClassVsStruct/` - Class vs struct performance comparison
- `src/CustomCollections/` - Custom collection benchmarks
- `src/CustomEcs/` - Custom ECS benchmarks
- `src/CustomNeighborCache/` - Neighbor cache benchmarks
- `src/EntityComponentSystem/` - ECS performance tests
- `src/IDs/` - ID generation benchmarks
- `src/InterfaceVsAbstract/` - Interface vs abstract class comparison
- `src/Iterators/` - Iterator performance comparison
- `src/Loop/` - Loop optimization benchmarks
- `src/Release/` - Release mode benchmarks
- `src/RemoveAtVsRemoveUnnorderAt/` - Collection removal comparison
- `src/Results/` - Benchmark results storage
- `src/Strings/` - String operation benchmarks

## Source Structure

```
src/
  ClassVsStruct/
  CustomCollections/
  CustomEcs/
  CustomNeighborCache/
  EntityComponentSystem/
  IDs/
  InterfaceVsAbstract/
  Iterators/
  Loop/
  Release/
  RemoveAtVsRemoveUnnorderAt/
  Results/
  Strings/
```

## Related

- [[Alis]]
- [[Performance Overview]]
- [[Projects Index]]
