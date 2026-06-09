---
title: GameObjectLookup
tags: [glossary,terminology,reference]
---


## Definition

**GameObjectLookup** is a wrapper that provides safe entity access with version checking, preventing operations on deleted or recycled entities.

## Core Purpose

GameObjectLookup enables:

- Safe entity access with version validation
- Detection of recycled or deleted entities
- Zero-copy entity reference without full GameObject

## Structure

```csharp
public struct GameObjectLookup
{
    public int EntityID;
    public ushort EntityVersion;
    public GameObjectType Archetype;
    
    public bool IsValid => EntityID != 0 && EntityVersion == GetEntityVersion(EntityID);
    
    public GameObjectLocation Location { get; }
}

// Comparison operators
public static bool operator ==(GameObjectLookup a, GameObjectLookup b);
public static bool operator !=(GameObjectLookup a, GameObjectLookup b);
```

## Usage in ECS

### Entity Version Checking

Validate entity is still alive:

```csharp
public bool IsValid => EntityID != 0 && EntityVersion == GetEntityVersion(EntityID);

// Check entity validity
GameObjectLookup lookup = scene.GetEntityLookup(entityId);
if (lookup.IsValid)
{
    // Safe to access entity
    Transform transform = lookup.GetComponent<Transform>();
}
else
{
    // Entity has been deleted or recycled
}
```

### Component Access

Get component from valid entity:

```csharp
public T GetComponent<T>(GameObjectLookup lookup) where T : struct
{
    if (!lookup.IsValid)
    {
        throw new InvalidOperationException("Entity not found");
    }
    
    GameObjectLocation location = lookup.Location;
    Archetype archetype = GetArchetype(location.ArchetypeId);
    ComponentStorage<T> storage = archetype.GetComponentStorage<T>();
    
    return storage[location.Index];
}

// Usage
GameObjectLookup lookup = scene.GetEntityLookup(entityId);
Transform transform = lookup.GetComponent<Transform>();
```

### Entity Enumeration

Iterate entities safely:

```csharp
public IEnumerable<GameObjectLookup> GetAllEntities()
{
    foreach (var entry in EntityTable)
    {
        GameObjectLookup lookup = new GameObjectLookup
        {
            EntityID = entry.Key,
            EntityVersion = entry.Value.Version,
            Archetype = GetArchetype(entry.Value.ArchetypeId)
        };
        
        if (lookup.IsValid)
        {
            yield return lookup;
        }
    }
}

// Iterate all valid entities
foreach (var entity in scene.GetAllEntities())
{
    // Process entity
}
```

## Version Checking

### Entity Version Update

Update version when entity recycled:

```csharp
public void RecycleEntity(int entityId)
{
    // Increment version to invalidate old references
    EntityVersion = (ushort)(GetEntityVersion(entityId) + 1);
    
    // Update stored version
    EntityTable[entityId].Version = EntityVersion;
}

// Check if entity is still valid
if (lookup.EntityVersion == GetEntityVersion(entityId))
{
    // Entity still alive
}
```

### Invalid Entity Detection

Detect deleted entities:

```csharp
public bool IsValid => EntityID != 0 && EntityVersion == GetEntityVersion(EntityID);

// Entity deleted scenarios:
// - EntityID == 0 (no entity)
// - EntityVersion mismatch (entity recycled)
// - Entity not in EntityTable (deleted)
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **IsValid Check** | O(1) version comparison |
| **Get Component** | O(1) FastestTable lookup |
| **Location Access** | O(1) property access |
| **Memory Size** | 12 bytes (int + ushort + reference) |

## Related

- [[GameObject]] - Full entity handle with world and version
- [[FastestTable]] - High-performance lookup table
- [[GameObjectLocation]] - Entity location data
- [[GameObjectType]] - Archetype type
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[architecture-index]] — Patterns
- [[events-index]] — Event system
