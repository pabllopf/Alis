---
title: Query-Based Architecture
tags: [concept,theory,documentation]
---


Query-based architecture uses declarative component queries to filter and process entities, replacing inheritance hierarchies with composition-based filtering.

## Core Concept

### What is a Query?
- **Definition**: Type-safe component filtering mechanism
- **Pattern**: LINQ-like syntax for ECS entities
- **Implementation**: `Query<TComponent1, TComponent2, ...>`

## Implementation in Alis

### Query Syntax

```csharp
// Define query for entities with Position and Velocity
var query = world.Query<Position, Velocity>();

// Iterate over matching entities
foreach (var entity in query)
{
    // Update position based on velocity
    entity.Position.X += entity.Velocity.X * deltaTime;
    entity.Position.Y += entity.Velocity.Y * deltaTime;
}
```

### Query with Additional Components

```csharp
// Query entities with Position, Velocity, and Renderable
var renderQuery = world.Query<Position, Velocity, Renderable>();

foreach (var entity in renderQuery)
{
    // Update position
    entity.Position.X += entity.Velocity.X * deltaTime;
    
    // Render entity
    Draw(entity.Position, entity.Renderable.Color);
}
```

### Query with Filtering

```csharp
// Filter entities by custom predicate
var activeEntities = world.Query<Position>()
    .Where(e => e.Position.X > 0 && e.Position.Y > 0);

foreach (var entity in activeEntities)
{
    Process(entity);
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Type Safety** | Compile-time checking of component types |
| **Performance** | Zero allocations, cache-friendly iteration |
| **Composability** | Combine any number of components |
| **Declarative** | Clear intent, no imperative filtering logic |

## Query Implementation Details

```csharp
public class Query<T1, T2> where T1 : IComponent where T2 : IComponent
{
    private T1[] _components1;
    private T2[] _components2;
    private BitVector _activeMask;
    
    public QueryEnumerator<T1, T2> GetEnumerator()
    {
        return new QueryEnumerator<T1, T2>(_components1, _components2, _activeMask);
    }
}

// Enumerator provides zero-copy iteration
public ref struct QueryEnumerator<T1, T2>
{
    private int _index;
    
    public bool MoveNext()
    {
        while (++_index < _components1.Length)
        {
            if (_activeMask[_index]) return true;
        }
        return false;
    }
}
```

## When to Use Query-Based Architecture

### Suitable For
- Game loops and update systems
- ECS architectures
- Data processing pipelines
- High-performance filtering

### Not Suitable For
- Simple CRUD operations
- Low-frequency data access
- Business logic without entity composition

## See Also
- [`.memory/sources/ecs-sources.md`] - Entity Component System
- [`.memory/concepts/data-oriented-design.md`] - Data-Oriented Design
- [`.memory/concepts/zero-copy-abstractions.md`] - Zero-Copy Abstractions
