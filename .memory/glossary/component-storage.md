---
title: Component Storage
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**Component Storage** is a typed data storage container that holds component instances for entities within an [[Archetype]], providing fast indexed access and memory-efficient storage.

## Core Purpose

Component Storage manages component data for a specific component type across all entities in an archetype, enabling:

- Fast component retrieval by entity index
- Contiguous memory layout for cache efficiency
- Type-safe component access

## Structure

### ComponentStorageBase

Abstract base class for all component storage:

```csharp
public abstract class ComponentStorageBase(Array initialBuffer)
{
    public Array Buffer { get; }
    public int Length { get; }
    
    public abstract void SetAt(object value, int index);
    public abstract object GetAt(int index);
}
```

### ComponentStorage<T>

Generic typed storage:

```csharp
public abstract class ComponentStorage<T> : ComponentStorageBase
    where T : struct
{
    public T this[int index] 
    { 
        get => ((T[])Buffer)[index];
        set => ((T[])Buffer)[index] = value;
    }
    
    public Span<T> AsSpan();
    public void EnsureCapacity(int capacity);
}
```

## Usage in ECS

### Component Access

Retrieve component by entity index:

```csharp
ComponentStorage<Transform> storage = 
    archetype.GetComponentStorage<Transform>();

// Get component for entity at index 5
Transform transform = storage[5];

// Set component for entity at index 5
storage[5] = new Transform { X = 10, Y = 20 };
```

### Span Access

Zero-copy span access:

```csharp
Span<Transform> transforms = storage.AsSpan();

// Process all transforms in archetype
for (int i = 0; i < transforms.Length; i++)
{
    ref var transform = ref transforms[i];
    // Update transform
}
```

### Entity Location Mapping

Map entity location to storage index:

```csharp
GameObjectLocation location = scene.EntityTable[entityId];
int storageIndex = location.Index;

ref Transform t = ref storage[storageIndex];
// Access component for this entity
```

## Component Storage Lifecycle

### Creation

Storage created when archetype formed:

```csharp
public static ComponentStorage<T> Create(int capacity)
{
    return new ComponentStorage<T>(capacity);
}
```

### Capacity Management

Dynamic capacity expansion:

```csharp
public void EnsureCapacity(int newCapacity)
{
    if (newCapacity > Buffer.Length)
    {
        Array.Resize(ref ((Array)Buffer), newCapacity);
    }
}
```

### Archetype Integration

Storage integrated into archetype:

```csharp
public class Archetype
{
    public ComponentStorageBase[] Components;  // All storage types
    
    public ComponentStorage<T> GetComponentStorage<T>()
    {
        return (ComponentStorage<T>)Components[ComponentId<T>.Id];
    }
}
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Get by Index** | O(1) |
| **Set by Index** | O(1) |
| **Span Access** | O(1) |
| **Capacity Check** | O(1) |

## Related

- [[Archetype]] - Component type optimization
- [[GameObjectLocation]] - Entity location data
- [[Component<T>]] - Component wrapper
- [[GameObject]] - Entity handle
- [[Scene]] - World container
- [[Component]] - Data-only struct
- [[entity-component-system-ecs]] — ECS overview
- [[memory-management]] — Memory strategy
- [[FastestTable]] — Lookup table
- [[FastestStack]] — Memory-efficient stack

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Performance optimizations
- [[architecture-index]] — Patterns
