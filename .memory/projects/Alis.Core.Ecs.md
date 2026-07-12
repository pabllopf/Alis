---
title: Alis.Core.Ecs
tags:
  - operation
  - ecs
  - entity
  - component
  - system
  - game-object
status: Draft
license: GPLv3
---

# Alis.Core.Ecs

**Layer:** 4_Operation
**Path:** `4_Operation/Ecs/src/Alis.Core.Ecs.csproj`

## Purpose

High-performance Entity Component System (ECS) framework — the core gameplay programming model for the Alis engine.

## Architecture

### Core Types
- `GameObject` — Primary game entity
- `Scene` — Container of game objects
- `Component` — Attachable behavior
- `EntityData` / `EntityHighLow` — Entity identity system

### Kernel
- `ComponentRegistry` — Component type registration
- `ComponentHandle` — Type-safe component access
- `Archetype` / `ArchetypeData` — Component storage archetypes
- `CommandBuffer` — Deferred structural changes
- `Ref<T>` — Component reference

### Systems
- `Query` / `QueryEnumerator` — Entity querying
- `Rule` / `RuleTypes` — Query rules and filters
- `With<T>` / `Not<T>` / `IncludeDisabled` — Query modifiers
- `GameObjectQueryEnumerator` — Optimized enumeration

### Updating
- `ComponentStorage` — Per-archetype component storage
- `UpdateRunnerFactory` / `GameObjectUpdate` — Update pipeline
- `SceneUpdateFilter` — Update filtering
- `UpdateOrderAttribute` — Update ordering

### Collections
- `FastestArrayPool` — Allocation pool
- `FastestTable` — High-performance hash table
- `FastestStack` — Stack data structure
- `FrugalStack` — Memory-efficient stack
- `IDTable` — Identity mapping
- `Chunk` — Archetype chunk storage
- `SparseSet` / `ShortSparseSet` — Sparse index sets

### Events
- `Event` / `GenericEvent` / `ComponentEvent` — ECS event system
- `GameObjectOnlyEvent` — Entity-scoped events

### Marshalling
- `GameObjectMarshal` / `SceneMarshal` — Interop marshalling

## Source Generator

**Path:** `4_Operation/Ecs/generator/`

Generates ECS-related code for component registration and query optimization.

## Dependencies

- Alis.Core.Aspect (5_Declaration)

## Testing

**Path:** `4_Operation/Ecs/test/`

~190 test files — largest test suite in the repository. Covers:
- All component lifecycle operations
- Query and filtering
- Scene management
- Edge cases and stress tests
- All collection types
- Archetype management
- Event system
- Marshalling
- System/update pipeline

## Performance Design

- Archetype-based component storage (cache-friendly)
- Custom allocation-efficient collections
- No LINQ in hot paths
- SIMD-friendly data layouts
- Query optimization through archetype graph

## Key Files

| Component | Description |
|---|---|
| `WorldArchetypeTableItem` | Archetype table entry |
| `NeighborCache` | Archetype neighbor lookup |
| `ArchetypeNeighborCache` | Graph edge traversal |
| `IArchetypeGraphEdge` | Edge interface |

## Related Documents

- [[Alis.Core.Aspect]]
- [[Alis.Core.Physic]]
- [[Alis.Core.Graphic]]
- [[testing-overview]]
