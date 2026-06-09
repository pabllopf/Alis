---
title: GameObjectEnumerator
tags:
  - glossary
  - terminology
  - reference

status: draft
---


## Definition

**GameObjectEnumerator** is an entity iteration wrapper that provides safe, efficient enumeration of entities within a batch or archetype, supporting zero-copy iteration.

## Core Purpose

GameObjectEnumerator enables:

- Safe entity enumeration without copying
- Batch entity processing
- Memory-efficient iteration over entity collections

## Structure

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

## Usage Examples

### Batch Entity Iteration

```csharp
// Create many entities
Chunk<Transform, Health> batch = 
    scene.CreateMany<Transform, Health>(1000);

// Iterate entities and components
int index = 0;
foreach (var entity in batch.Entities)
{
    ref var transform = ref batch.Span1[index];
    ref var health = ref batch.Span2[index];
    
    // Process entity and components
    transform.X = index * 10f;
    health.Value = 100;
    
    index++;
}
```

### Entity Enumeration

```csharp
public struct GameObjectEnumerator
{
    public Scene Scene { get; }
    public int Count { get; }
    
    public EntityEnumerable GetEnumerator()
    {
        return new EntityEnumerable(Scene, Count);
    }
}

// Iterate all entities in batch
foreach (var entity in batch.Entities)
{
    Console.WriteLine($"Entity {entity.EntityID}");
}
```

### Index-Based Access

Access entities by index:

```csharp
public struct EntityEnumerator : IEnumerator<GameObject>
{
    private int _index;
    private GameObject[] _entities;
    
    public GameObject Current 
    { 
        get => _index >= 0 && _index < _entities.Length 
            ? _entities[_index] 
            : default;
    }
    
    public bool MoveNext()
    {
        _index++;
        return _index < _entities.Length;
    }
    
    public void Reset()
    {
        _index = -1;
    }
}

// Iterate with index
for (int i = 0; i < batch.Entities.Count; i++)
{
    GameObject entity = batch.Entities[i];
    // Process entity at index i
}
```

## Performance Benefits

| Benefit | Description |
|---------|-------------|
| **Zero Copy** | No entity copying during iteration |
| **Cache Efficiency** | Contiguous memory access |
| **Type Safety** | Compile-time component checking |
| **Memory Efficient** | Minimal allocation overhead |

## Related

- [[ChunkTuple]] - Batch entity creation result
- [[GameObject]] - Entity handle
- [[FastestStack]] - Memory-efficient stack
- [[Scene]] - World container
- [[Component]] - Data-only struct
- [[Query]] - Entity filtering
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[queries-index]] — Query index
- [[architecture-index]] — Patterns
