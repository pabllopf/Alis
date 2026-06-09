# ChunkTuple

tags:
  - glossary,terminology,reference

## Definition

A **ChunkTuple** is a batch entity creation result container that returns multiple component spans along with entity enumerators for high-performance bulk entity operations.

## Core Purpose

ChunkTuple enables efficient creation and iteration of many entities simultaneously, avoiding per-entity allocation overhead.

## Structure

### Single Component Type

```csharp
public struct ChunkTuple<T>
{
    public GameObjectEnumerator Entities;  // Entity iteration
    public Span<T> Span;                  // Component data
    
    // Iterate entities and components together
    foreach (var entity in Entities)
    {
        ref var component = ref Span[entityIndex];
        // Process entity and component
    }
}
```

### Multiple Component Types

```csharp
public struct ChunkTuple<T1, T2, T3>
{
    public GameObjectEnumerator Entities;
    public Span<T1> Span1;
    public Span<T2> Span2;
    public Span<T3> Span3;
    
    // Iterate all components together
    for (int i = 0; i < Entities.Count; i++)
    {
        ref var comp1 = ref Span1[i];
        ref var comp2 = ref Span2[i];
        ref var comp3 = ref Span3[i];
        
        // Process all components for entity i
    }
}
```

## Usage Examples

### Create Many Entities

```csharp
// Create 1000 entities with Transform and Health
ChunkTuple<Transform, Health> batch = 
    scene.CreateMany<Transform, Health>(1000);

// Iterate efficiently
int index = 0;
foreach (var entity in batch.Entities)
{
    ref var transform = ref batch.Span1[index];
    ref var health = ref batch.Span2[index];
    
    transform.X = index * 10f;
    health.Value = 100;
    
    index++;
}
```

### Three Component Types

```csharp
ChunkTuple<Transform, Velocity, Health> batch = 
    scene.CreateMany<Transform, Velocity, Health>(500);

for (int i = 0; i < batch.Entities.Count; i++)
{
    ref var transform = ref batch.Span1[i];
    ref var velocity = ref batch.Span2[i];
    ref var health = ref batch.Span3[i];
    
    // Set up entity i
}
```

## Performance Benefits

| Benefit | Description |
|---------|-------------|
| **Zero Allocations** | No per-entity object creation |
| **Cache Efficiency** | Contiguous component storage |
| **Batch Processing** | Process many entities in loop |
| **Type Safety** | Compile-time component checking |

## Entity Enumeration

### GameObjectEnumerator

Entity iteration wrapper:

```csharp
public struct GameObjectEnumerator
{
    public Scene Scene { get; }
    public int Count { get; }
    
    public EntityEnumerable GetEnumerator();
}

public struct EntityEnumerable : IEnumerable<GameObject>
{
    public EntityEnumerator GetEnumerator();
}

public struct EntityEnumerator : IEnumerator<GameObject>
{
    public GameObject Current { get; }
    public bool MoveNext();
    public void Reset();
}
```

## Related

- [[GameObject]] - Entity handle
- [[Scene]] - World container
- [[FastestStack]] - Memory-efficient stack
- [[GameObjectEnumerator]] - Entity iteration
- [[Component]] - Data-only struct
- [[Archetype]] - Component optimization
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Batch performance
- [[architecture-index]] — Patterns
