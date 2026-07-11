---
title: ECS Domain
tags:
  - domain
  - ecs
  - entity
  - component
  - system
status: Draft
license: GPLv3
---

# ECS Domain

## Overview

The Entity-Component-System architecture is the core game object model in Alis, implemented in [[Alis.Core.Ecs]].

## Architecture

```mermaid
graph TD
    subgraph "ECS Core"
        World[World] --> EntityManager[Entity Manager]
        World --> ComponentManager[Component Manager]
        World --> SystemManager[System Manager]
    end
    
    subgraph "Entity"
        ID[Entity ID] --> Archetype[Archetype]
    end
    
    subgraph "Component"
        Data[Component Data] --> Array[Component Array]
        Array --> Archetype
    end
    
    subgraph "System"
        System[System] --> Query[Entity Query]
        Query --> Archetype
        System --> Execute[System.Execute]
    end
```

## Key Concepts

### Entity
A lightweight identifier (typically an integer) that represents a game object. Entities have no data or behavior themselves.

### Component
Pure data containers (struct or class) that hold entity state. Components follow data-oriented design principles:
- No behavior
- No inheritance
- No virtual methods
- POCO-style

### System
Contains the logic that operates on entities with specific component combinations. Systems are executed in order each frame.

### Archetype
A unique combination of component types. Entities with the same archetype share the same memory layout for cache efficiency.

## Relationships

| Concept | Module | File |
|---|---|---|
| Entity | Kernel | `GameObject.cs` |
| Scene | Kernel | `Scene.cs` |
| Component Data | Collections | `EntityData.cs` |
| Query | Collections | `QueryEnumerable.cs` |
| Neighbor Cache | Specialized | `NeighborCache.cs` |

## Performance

- Cache-friendly contiguous component arrays
- Archetype-based entity grouping
- No virtual dispatch in hot paths
- SIMD-friendly data layouts

## Related

- [[Alis.Core.Ecs]]
- [[Component Entity]]
- [[Performance Overview]]
- [[ECS Architecture]]
