---
title: Entity Component System (ECS)
tags: [concept,theory,documentation]
---


Alis implements an ECS architecture for game logic with source code generation for optimal performance.

## ECS Architecture Principles

### Core Concepts

| Concept | Description |
|---------|-------------|
| **Entities** | Unique identifiers for game objects, no data |
| **Components** | Data-only structs attached to entities |
| **Systems** | Logic processors that operate on component groups |

### ECS Benefits

1. **Performance** - Cache-friendly data layout, SIMD optimization
2. **Scalability** - Handle thousands of entities efficiently
3. **Determinism** - Predictable execution order
4. **Testability** - Isolated system logic, easy to mock
5. **AOT Compatibility** - No reflection, compile-time code generation

## Source Generator Integration

`Alis.Core.Ecs.Generator` produces:
- Component registration code
- System iteration logic
- Entity management helpers
- Query optimizations

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
            entity.Position.Y += entity.Velocity.Y * deltaTime;
        }
    }
}

// Register in generator
[GenerateComponent(typeof(Position))]
[GenerateComponent(typeof(Velocity))]
[GenerateSystem(typeof(MovementSystem))]
public class GameModule { }
```

## System Execution Order

Systems execute in defined order:
1. InputSystem - Handle user input
2. PhysicsSystem - Update physics
3. MovementSystem - Apply movement
4. RenderingSystem - Prepare rendering

## See Also
- [[Generator Pattern]]
- [[Layered Architecture]]
- [[Alis Architecture Overview]]

## Related
- [[Alis.Core.Ecs]] — ECS project docs
- [[entity-component-system-ecs]] — ECS glossary term
- [[Component]] — Data-only struct pattern
- [[System]] — Logic processor
- [[Archetype]] — Component optimization
- [[Query]] — Entity filtering
- [[Scene]] — World container
- [[GameObject]] — Entity handle
- [[performance-index]] — ECS performance
- [[queries-index]] — Query system
- [[architecture-index]] — Patterns index
