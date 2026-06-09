---
title: Alis.Benchmark
tags: [presentation,application,extension,documentation]
---


## Overview
BenchmarkDotNet-based performance benchmarking suite for the ALIS game engine. Compares ALIS ECS performance against 17+ third-party ECS frameworks across entity creation, component manipulation, system execution, and data access patterns.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Console Application (BenchmarkDotNet runner)
- **Framework**: `net8.0` (single-target, unlike multi-targeted library projects)
- **Output**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`
- **SonarQubeExclude**: `true`
- **WarningLevel**: `0` (all warnings suppressed — extensive CS/CA/NU/ALIS suppressions)

## Benchmark Suites (20+)

### Entity Component System (ECS) — 16 ECS frameworks compared
| Benchmark | Description |
|---|---|
| `CreateEntityWithOneComponent` | Entity creation with 1 component — 16 implementations |
| `CreateEntityWithTwoComponents` | Entity creation with 2 components — 16 implementations |
| `CreateEntityWithThreeComponents` | Entity creation with 3 components — 16 implementations |
| `SystemWithOneComponent` | System iteration with 1 component (Inline, Delegate, SIMD) |
| `SystemWithTwoComponents` | System iteration with 2 components |
| `SystemWithThreeComponents` | System iteration with 3 components |
| `SystemWithTwoComponentsMultipleComposition` | Complex composition patterns |
| `UpdateRunnerMicroBenchmark` | Micro-benchmark for system update runner overhead |

### Custom ECS (ALIS internal ECS)
| Benchmark | Description |
|---|---|
| `AlisEcsBenchmark` | ALIS ECS creation (1–8 components, individual + bulk), system execution (inline query, delegate query, SIMD-vectorized), padding variants (P0, P10) |

### Data Structures
| Benchmark | Description |
|---|---|
| `NativeArrayUnsafeVsNativeArraySafe` | Safe vs unsafe native array access |
| `ListsBenchmarks` | List<T> performance scenarios |
| `StacksBenchmarks` | Stack<T> performance scenarios |

### Language Features
| Benchmark | Description |
|---|---|
| `ClassVsStructBenchmark` | Class vs struct allocation/access overhead |
| `InterfaceVsAbstractBenchmark` | Interface dispatch vs abstract class dispatch |
| `IdStorageBenchmark` | Entity ID storage strategies |
| `IterationBenchmarks` | Collection iteration patterns (for, foreach, LINQ, Span) |
| `LoopBenchmark` | Loop construct performance (for, while, do-while, goto) |
| `StringManipulationBenchmark` | String concatenation, StringBuilder, Span-based |
| `RemoveAtVsRemoveUnnorderAtListBenchmark` | List removal strategies |

### Spatial
| Benchmark | Description |
|---|---|
| `CustomNeighborCacheBenchmark` | Spatial neighbor cache query performance |

## Third-Party ECS Frameworks Compared (17)
- **Arch** / **Arch.System** (v1.2.8 / v1.0.5)
- **DefaultEcs** (v0.17.2)
- **fennecs** (v0.1.1-beta)
- **Flecs.NET** (v3.2.11)
- **Frent** (v0.5.4.3-beta)
- **Friflo.Engine.ECS** (v3.2.3)
- **HypEcs** (v1.2.1)
- **Leopotam.Ecs** (v1.0.1)
- **Leopotam.EcsLite** (v1.0.1)
- **MonoGame.Extended.Entities** (v3.8.0)
- **Myriad.ECS** (v34.6.0)
- **RelEcs** (v1.5.1)
- **Scellecs.Morpeh** (v2024.1.0)
- **Svelto.ECS** (v3.5.2)

## Configuration (`CustomConfig`)
- **Memory diagnoser** enabled (allocation tracking)
- **Output**: GitHub Markdown + CSV exporters
- **Artifacts path**: `Release/Results/{yyyy-MM-dd}/` or `Debug/Results/{yyyy-MM-dd}/`
- **Job**: InProcess with GC force + server GC, .NET 8.0
- **Priority**: Real-time process priority via `GlobalSetup`

## Entry Point (`Program.cs`)
Uses `BenchmarkSwitcher.FromTypes()` with all 20+ benchmark types registered. Accepts command-line arguments for selective benchmark execution; runs all suites when no args provided.

## Dependencies
- **NuGet**: `BenchmarkDotNet 0.14.0` (primary), 17 ECS framework packages
- **Analyzers**: Microsoft.CodeAnalysis.NetAnalyzers, Roslynator (analyzers, code analysis, formatting)
- **Project References**: [[projects/2_Application/Alis]] (core Alis application library)
- **Source Generators**: All generators from 4_Operation and 6_Ideation

## Output Structure
```
Benchmark/src/
├── Release/Results/{yyyy-MM-dd}/   — Release benchmark results
└── Debug/Results/{yyyy-MM-dd}/     — Debug benchmark results
```

## Build Configuration
- **LangVersion**: `13` (inherited)
- **Nullable**: `disable`
- **AllowUnsafeBlocks**: `false`

## Notes
- BenchmarkDotNet results are published as GitHub-flavored Markdown and CSV for CI consumption
- ALIS ECS benchmarks include SIMD-vectorized (`Vector256`) execution paths using `System.Runtime.Intrinsics`
- Warning suppressions cover CS, CA, NU, and ALIS diagnostic IDs — results quality is the focus, not code analysis
