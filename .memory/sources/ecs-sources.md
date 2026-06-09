---
title: ECS Sources
tags: [source,reference,documentation]
---


Entity Component System runtime and source generator in `4_Operation/Ecs/`.

## ECS Structure

```
4_Operation/Ecs/
├── src/              ← Main ECS runtime
│   ├── Entity.cs     ← Entity definition
│   ├── Component.cs  ← Component interface
│   ├── System.cs     ← System base class
│   ├── Query.cs      ← Component queries
│   └── ...
├── generator/        ← Source generator
│   ├── ComponentRegistryGenerator.cs
│   └── SystemRegistryGenerator.cs
├── test/             ← ECS tests
└── sample/           ← ECS samples
```

## Key Source Files

### Core Types
| File | Purpose |
|------|---------|
| `src/Entity.cs` | Entity identifier and management |
| `src/IComponent.cs` | Component interface marker |
| `src/ISystem.cs` | System execution interface |
| `src/Query<T>.cs` | Component type queries |

### ECS Runtime
- **EntityManager** - Entity lifecycle management
- **SystemManager** - System registration and execution
- **QueryManager** - Component queries and filtering
- **World** - ECS world context

### Source Generator
| Generator | Produces |
|-----------|----------|
| `ComponentUpdateTypeRegistryGenerator` | Component update registry |
| `SystemRegistryGenerator` | System execution order |

## Usage Pattern

```csharp
// Define component (data-only struct)
public struct Position : IComponent
{
    public float X;
    public float Y;
}

// Define system (logic processor)
public class MovementSystem : ISystem
{
    private Query<Position, Velocity> _query;
    
    public void Update(float deltaTime)
    {
        foreach (var entity in _query)
        {
            entity.Position.X += entity.Velocity.X * deltaTime;
        }
    }
}

// Register with generator
[GenerateComponent(typeof(Position))]
[GenerateSystem(typeof(MovementSystem))]
public class GameModule { }
```

## Test Files

| Test File | Purpose |
|-----------|---------|
| `GameObjectRefTupleTest.cs` | Entity reference tests |
| `GameObjectLocationParametrizedTest.cs` | Location-based entity tests |
| `QueryEnumerableTest.cs` | Query enumeration tests |
| `GameObjectRemoveTest.cs` | Entity removal tests |

## See Also
- [[Generator Pattern]]
- [[Layered Architecture]]
- [[Entity Component System]]
