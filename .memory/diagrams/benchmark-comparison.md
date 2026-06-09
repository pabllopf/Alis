---
title: Benchmark Comparison Map
tags: [diagram,visualization,mermaid]
---


## ECS Frameworks Compared

```mermaid
quadrantChart
    title ECS Framework Comparison
    x-axis "Minimal Features" --> "Full Features"
    y-axis "Lower Performance" --> "Higher Performance"
    quadrant-1 "High Performance, Full Featured"
    quadrant-2 "High Performance, Minimal"
    quadrant-3 "Lower Performance, Minimal"
    quadrant-4 "Lower Performance, Full Featured"
    "ALIS ECS": [0.85, 0.90]
    "Arch": [0.80, 0.85]
    "Flecs.NET": [0.90, 0.80]
    "Frent": [0.70, 0.85]
    "Friflo.ECS": [0.75, 0.75]
    "Myriad.ECS": [0.80, 0.70]
    "DefaultEcs": [0.60, 0.65]
    "Svelto.ECS": [0.85, 0.60]
    "Morpeh": [0.70, 0.55]
    "Leopotam.Ecs": [0.50, 0.65]
    "HypEcs": [0.60, 0.80]
```

## Benchmark Categories

```mermaid
mindmap
  root((BENCHMARKS))
    ECS Creation
      CreateEntityWith1Component
      CreateEntityWith2Components
      CreateEntityWith3Components
      16 implementations each
    ECS Systems
      SystemWith1Component
      SystemWith2Components
      SystemWith3Components
      MultipleComposition
    ALIS ECS Specific
      Individual Create 1-8
      Bulk Create 1-8
      Query Inline
      Query Delegate
      SIMD Vectorized
      Padding P0/P10
    Data Structures
      NativeArray Safe vs Unsafe
      Lists
      Stacks
    Language Features
      Class vs Struct
      Interface vs Abstract
      ID Storage
      Iterations
      Loops
      String Manipulation
      RemoveAt vs RemoveUnorderedAt
    Spatial
      Neighbor Cache
```

## ECS Frameworks Tested (17)

```mermaid
timeline
    title ECS Frameworks in ALIS Benchmark
    Popular ECS : Arch 1.2.8 : DefaultEcs 0.17.2 : Leopotam.Ecs 1.0.1 : Leopotam.EcsLite 1.0.1
    Modern ECS : Flecs.NET 3.2.11 : Frent 0.5.4 : Friflo.ECS 3.2.3 : Myriad.ECS 34.6.0
    Niche ECS : fennecs 0.1.1-beta : HypEcs 1.2.1 : RelEcs 1.5.1 : Scellecs.Morpeh 2024.1
    Specialized : MonoGame.Extended.Entities 3.8.0 : Svelto.ECS 3.5.2 : ALIS Custom ECS
```

## Related
- [[projects/1_Presentation/Alis.Benchmark]] — Full benchmark documentation
- [[diagrams/ecs-architecture]] — ALIS ECS architecture
- [[diagrams/architecture-overview]] — Layer context
