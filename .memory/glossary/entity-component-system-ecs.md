---
title: Entity Component System (ECS)
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**Entity Component System (ECS)** is a game development architecture pattern that separates data (components) from logic (systems), using entities as lightweight identifiers that link components together.

## Core Concepts

### Entity

In ECS, an **entity** is NOT a game object with embedded logic. It's simply:

- A unique identifier (ID)
- A collection of component references
- Zero bytes of game logic

Entities are managed by the [[Scene]] and accessed via [[GameObject]] handles.

### Component

A **component** is:

- A data-only struct (no methods, no inheritance)
- Attached to entities for type-safe access
- Processed by systems based on [[Update Type Attribute]]

Example:

```csharp
public struct Transform
{
    public float X, Y;
}

public struct Health
{
    public int Value;
}
```

### System

A **system** is:

- Logic that operates on components with specific attributes
- Iterates over entities matching component queries
- Executes in update cycles via [[Scene.Update<T>()]]

Example:

```csharp
[UpdateType(typeof(FixedUpdate))]
public class MovementSystem : IComponentUpdateFilter
{
    public void Update(ref Transform t, ref Velocity v)
    {
        t.X += v.X;
        t.Y += v.Y;
    }
}
```

## Architecture Benefits

| Benefit | Description |
|---------|-------------|
| **Cache Efficiency** | Components of same type stored contiguously |
| **Data-Oriented** | Separation of data and logic improves CPU utilization |
| **Scalability** | Process thousands of entities efficiently |
| **Testability** | Systems are pure functions, easy to unit test |
| **AOT Compatibility** | No reflection, no dynamic code generation |

## ECS in Alis

The Alis ECS implementation provides:

- [[GameObject]] - Entity handle with versioning for safe deletion handling
- [[Scene]] - World container managing entities and systems
- [[Archetype]] - Component type combination optimization
- [[Query]] - Rule-based entity filtering
- [[ChunkTuple]] - Batch entity creation for performance

## Related

- [[GameObject]] - Entity identifier struct
- [[Scene]] - World container
- [[Component Storage]] - Typed data storage
- [[Archetype]] - Component combination optimization
- [[Component]] - Data-only struct
- [[System]] - Logic processor
- [[Query]] - Entity filtering
- [[Rule]] - Component constraint

## Related Architecture

- [[Layered Architecture]] — Layer structure
- [[Alis Architecture Overview]] — Full architecture
- [[architecture/repository-overview]] — Architecture docs
- [[queries-index]] — Query system
- [[events-index]] — Event system
- [[commands-index]] — Commands
- [[handlers-index]] — Handlers
- [[performance-index]] — Performance analysis
- [[architecture-index]] — Patterns

## Related Projects

- [[Alis.Core.Ecs]] — ECS project
- [[projects/Index]] — All project docs
