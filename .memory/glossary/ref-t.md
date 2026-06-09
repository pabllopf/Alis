---
title: Ref<T>
tags:
  - glossary
  - terminology
  - reference

status: draft
---


## Definition

**Ref<T>** is a reference wrapper that provides direct, zero-copy access to component data without copying the underlying struct, enabling efficient component manipulation.

## Core Purpose

Ref<T> enables:

- Direct component modification without copying
- Safe component access with existence checking
- Zero-copy operations for performance

## Structure

```csharp
public ref struct Ref<T> where T : struct
{
    public ComponentStorage<T> Storage;
    public int Index;
    
    public T Value 
    { 
        get => Storage[Index];
        set => Storage[Index] = value;
    }
    
    public bool IsValid { get; }
}
```

## Usage Examples

### Get Component Reference

```csharp
// Try get component (safe, returns default if not present)
Ref<Transform> transformRef = player.TryGetCore<Transform>(out bool exists);

if (exists)
{
    // Modify component directly (no copy)
    transformRef.Value.X = 10;
    transformRef.Value.Y = 20;
}

// Get component (throws if not present)
ref Transform t = ref player.Get<Transform>();
t.X = 10;
```

### Component Modification

Direct modification without copying:

```csharp
Ref<Health> healthRef = player.TryGetCore<Health>(out bool exists);

if (exists)
{
    healthRef.Value.Value -= damage;
    
    // Or modify by reference
    ref Health health = ref healthRef.Value;
    health.Value = Math.Max(0, health.Value - damage);
}
```

### Span Integration

Convert to span for batch operations:

```csharp
Ref<Transform> transformRef = player.TryGetCore<Transform>(out _);

// Access underlying storage
Span<Transform> transforms = transformRef.Storage.AsSpan();

// Process all transforms in archetype
foreach (ref var transform in transforms)
{
    // Update transform
}
```

## Ref vs T Comparison

| Aspect | Ref<T> | T |
|--------|---------|---|
| **Copy** | No (reference) | Yes (value type) |
| **Performance** | O(1) reference | O(n) struct copy |
| **Modification** | Direct in-place | Requires assignment back |
| **Null Safety** | Exists flag | Always valid struct |

## TryGetCore Pattern

Safe component retrieval:

```csharp
public Ref<T> TryGetCore<T>(out bool exists)
{
    if (!InternalIsAlive(out Scene _, out GameObjectLocation entityLocation))
    {
        exists = false;
        return default(Ref<T>);
    }
    
    int compIndex = GlobalWorldTables.ComponentIndex(
        entityLocation.ArchetypeId, 
        Component<T>.Id);
    
    if (compIndex == 0)
    {
        exists = false;
        return default(Ref<T>);
    }
    
    exists = true;
    ComponentStorage<T> storage = Unsafe.As<ComponentStorage<T>>(
        Unsafe.Add(ref entityLocation.Archetype.Components[0], compIndex));
    
    return new Ref<T>(storage, entityLocation.Index);
}
```

## Related

- [[Component Storage]] - Typed data storage
- [[GameObject]] - Entity handle
- [[Archetype]] - Component type optimization
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[memory-management]] — Memory strategy
- [[Span<T>]] — Memory slice
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Zero-copy performance
- [[architecture-index]] — Patterns
