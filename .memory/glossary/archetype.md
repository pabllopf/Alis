---
title: Archetype
tags:
  - glossary
  - terminology
  - reference

status: draft
---


## Definition

An **Archetype** is an optimization structure that groups entities with identical component type combinations. Archetypes enable cache-efficient storage and fast entity queries by organizing components contiguously.

## Core Concept

### Component Type Combinations

Each unique combination of component types creates a distinct archetype:

```csharp
// Entity with Transform + Health → Archetype A
var entity1 = scene.Create(new Transform(), new Health());

// Entity with Transform + Velocity → Archetype B  
var entity2 = scene.Create(new Transform(), new Velocity());

// Entity with Transform + Health + Velocity → Archetype C
var entity3 = scene.Create(new Transform(), new Health(), new Velocity());
```

### Archetype Structure

```csharp
public class Archetype
{
    public FastImmutableArray<ComponentId> Types;      // Component types
    public ComponentStorageBase[] Components;          // Typed storage arrays
    public int EntityCount;                            // Entity count in archetype
    public FastestTable<GameObjectLocation> EntityTable; // Entity lookup
}
```

## Archetype Operations

### Creation

Archetypes created automatically when entities added:

```csharp
// Creates archetype with Transform + Health
var entity = scene.Create(new Transform(), new Health());

// Creates archetype with Transform + Velocity + Health
var entity2 = scene.Create(new Transform(), new Velocity(), new Health());
```

### Entity Movement

When entity components change, entity moves to different archetype:

```csharp
var entity = scene.Create(new Transform(), new Health());

// Remove Health → entity moves to Transform-only archetype
entity.Remove<Health>();

// Add Velocity → entity moves to Transform + Velocity archetype
entity.Add(new Velocity());
```

### Archetype Graph

Archetypes connected via graph edges:

- **Add Edge**: Archetype A → Archetype B (adding component)
- **Remove Edge**: Archetype A → Archetype B (removing component)

```csharp
// Traverse archetype graph
Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T>>(
    scene,
    ref NeighborCacheAdd<T>.Lookup,
    ref thisLookup,
    true);
```

## Performance Characteristics

| Metric | Value |
|--------|-------|
| **Query Speed** | O(1) via archetype lookup |
| **Memory Layout** | Contiguous per component type |
| **Cache Efficiency** | High (SIMD-friendly) |
| **Entity Count** | Unlimited (dynamic growth) |

## Archetype Table

Scene maintains archetype table:

```csharp
public WorldArchetypeTableItem[] WorldArchetypeTable;
```

Table indexed by archetype ID for fast lookup.

## Archetype Events

- `ArchetypeAdded` - Fired when archetype created
- `ArchetypeRemoved` - Fired when archetype destroyed
- Query attachment/detachment notifications

## Related

- [[Scene]] - World container
- [[Component Storage]] - Typed data storage
- [[GameObject]] - Entity handle
- [[Query]] - Entity filtering
- [[Component]] - Data-only struct
- [[System]] - Logic processor
- [[entity-component-system-ecs]] — ECS overview
- [[GameObjectEnumerator]] — Entity iteration
- [[ChunkTuple]] — Batch creation

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project docs
- [[architecture-index]] — Patterns
- [[performance-index]] — Performance optimizations
- [[queries-index]] — Query documentation
