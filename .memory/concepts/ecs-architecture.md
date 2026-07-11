---
title: ECS Architecture Concept
tags:
  - concept
  - ecs
  - architecture
  - data-oriented
status: Draft
license: GPLv3
---

# ECS Architecture Concept

## Overview

Entity-Component-System (ECS) is a data-oriented architectural pattern that separates data (components) from behavior (systems), with entities as lightweight identifiers.

## Principles

### 1. Data-Oriented Design
Components are stored in contiguous arrays (archetypes) for cache efficiency. Systems iterate over these arrays sequentially.

### 2. Composition Over Inheritance
Entities gain capabilities through component composition rather than class inheritance hierarchies.

### 3. Separation of Data and Logic
- **Components**: Pure data, no behavior
- **Systems**: Pure behavior, no data
- **Entities**: Identifiers, neither data nor behavior

## Memory Layout

```text
Archetype: Player
├── Transform: [t1, t2, t3, ...]  ← contiguous array
├── Velocity:  [v1, v2, v3, ...]  ← contiguous array
└── Health:    [h1, h2, h3, ...]  ← contiguous array
```

This layout maximizes cache utilization by grouping similar data together.

## Query System

Systems declare which component types they need and the ECS framework efficiently returns matching entities:

```csharp
// Example: System queries entities with Transform + Velocity
foreach (var entity in world.Query<Transform, Velocity>())
{
    // Process matching entities
}
```

## Alis Implementation

In [[Alis.Core.Ecs]]:
- `GameObject` - Core entity type
- `Scene` - Container for entities and systems
- `EntityData` - Component storage management
- `QueryEnumerable` - Archetype query engine
- `NeighborCache` - Spatial data structure for proximity queries

## Related

- [[ECS Domain]]
- [[Alis.Core.Ecs]]
- [[Performance Overview]]
- [[Data-Oriented Design]]
