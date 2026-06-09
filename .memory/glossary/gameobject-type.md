---
title: GameObjectType
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**GameObjectType** represents an archetype type identifier that defines a unique combination of component types for entity grouping and optimization.

## Core Purpose

GameObjectType enables:

- Archetype identification and management
- Component type combination tracking
- Efficient entity grouping by component signature

## Structure

```csharp
public struct GameObjectType
{
    public int Id;                    // Unique archetype identifier
    public ComponentId[] ComponentIds; // Component type list
    
    public GameObjectType(int id, ComponentId[] componentIds);
    
    public int ComponentCount => ComponentIds.Length;
    public bool HasComponent(ComponentId componentId);
}

// Comparison operators
public static bool operator ==(GameObjectType a, GameObjectType b);
public static bool operator !=(GameObjectType a, GameObjectType b);
```

## Usage in ECS

### Archetype Creation

Create new archetype type:

```csharp
ComponentId[] componentIds = new ComponentId[]
{
    ComponentId<Transform>,
    ComponentId<Health>
};

GameObjectType archetypeType = new GameObjectType(archetypeId, componentIds);

// Create archetype with this type
Archetype archetype = new Archetype(archetypeType);
```

### Component Presence Check

Check if archetype has specific component:

```csharp
public bool HasComponent(ComponentId componentId)
{
    foreach (var compId in ComponentIds)
    {
        if (compId == componentId)
        {
            return true;
        }
    }
    
    return false;
}

// Usage
if (archetypeType.HasComponent(ComponentId<Transform>))
{
    // Process entities with Transform component
}
```

### Archetype Lookup

Find archetype by type:

```csharp
public Archetype GetArchetype(GameObjectType type)
{
    return Archetypes[type.Id];
}

// Get archetype for entity
GameObjectType type = entityLookup.Archetype;
Archetype archetype = GetArchetype(type);
```

## Archetype Management

### Component Type List

Store component type identifiers:

```csharp
public struct GameObjectType
{
    public int Id;
    public ComponentId[] ComponentIds;  // Ordered list
    
    // ComponentIds must be sorted for efficient lookup
}
```

### Type Hashing

Efficient type comparison:

```csharp
public override int GetHashCode()
{
    int hash = Id;
    
    foreach (var compId in ComponentIds)
    {
        hash ^= compId.GetHashCode();
    }
    
    return hash;
}

// Fast archetype lookup by type hash
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **HasComponent** | O(n) where n = component count |
| **Type Hash** | O(n) component iteration |
| **Comparison** | O(1) ID comparison |
| **Memory Size** | Variable (depends on component count) |

## Related

- [[Archetype]] - Component type optimization
- [[ComponentId]] - Component type identifier
- [[GameObjectLocation]] - Entity location data
- [[GameObject]] - Entity handle
- [[Scene]] - World container
- [[Component]] - Data-only struct
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[architecture-index]] — Patterns
- [[queries-index]] — Query system
