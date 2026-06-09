---
title: Benchmark Sources
tags:
  - source
  - reference
  - documentation

status: Draft

license: GPLv3

---


Performance benchmarks in `1_Presentation/Benchmark/`.

## Benchmark Projects

| Benchmark | Files | Target |
|-----------|-------|--------|
| **StringManipulationBenchmark** | 10+ | String operations performance |
| **CustomEcsBenchmarks** | 20+ | ECS system performance |
| **AlisEcsBenchmark** | 15+ | Alis ECS vs alternatives |

## Benchmark Structure

```
1_Presentation/Benchmark/
├── src/
│   ├── Strings/
│   │   └── StringManipulationBenchmark.cs
│   └── CustomEcs/
│       ├── AlisEcsBenchmark.cs
│       ├── FrentEcsBenchmark.cs
│       ├── Components/
│       │   ├── Component1.cs through Component16.cs
│       └── Setup.cs
└── test/
```

## Key Benchmark Files

### String Benchmarks
| File | Purpose |
|------|---------|
| `StringManipulationBenchmark.cs` | String operation comparisons |

### ECS Benchmarks
| File | Purpose |
|------|---------|
| `AlisEcsBenchmark.cs` | Alis ECS performance tests |
| `FrentEcsBenchmark.cs` | Frent ECS comparison |
| `Setup.cs` | Benchmark setup and configuration |

### Component Benchmarks
- **Component1.cs** through **Component16.cs** - Different component types for ECS benchmarks

## Benchmark Patterns

### XUnit Benchmarks
```csharp
[Benchmark]
public void EntityCreation()
{
    var entity = _world.CreateEntity();
    entity.AddComponent<Position>();
}

[Benchmark]
public void QueryPerformance()
{
    var query = _world.Query<Position, Velocity>();
    foreach (var entity in query)
    {
        // Process entities
    }
}
```

### Comparison Benchmarks
- Alis ECS vs FrentEcs
- String manipulation methods
- Memory allocation patterns

## See Also
- [[Entity Component System]]
- [[Layered Architecture]]
