---
title: Alis.Core.Ecs
tags:
  - project
  - ecs
  - entity
  - component
  - system
  - layer-4
status: Draft
license: GPLv3
---

# Alis.Core.Ecs

## Overview

Entity-Component-System (ECS) architecture implementation (Layer 4 - Operation). Core game object model with entities, components, systems, and queries.

## Properties

| Property | Value |
|---|---|
| **Layer** | 4 - Operation |
| **Project Path** | `4_Operation/Ecs/src/` |
| **Test Project** | `Alis.Core.Ecs.Test` |
| **Generator** | `Alis.Core.Ecs.Generator` |
| **Has Samples** | Yes (`Alis.Core.Ecs.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (via Layer 3/5 chain)
- **Depends On**: [[Alis.Core.Aspect.Memory]], [[Alis.Core.Aspect.Time]]
- **Used By**: [[Alis.App.Engine]]

## Architecture

- `src/Collections/` - Specialized collections for ECS (entity queries, archetypes)
- `src/Exceptions/` - ECS-specific exceptions
- `src/Kernel/` - Core ECS kernel (GameObject, Scene, EntityData)
- `src/Marshalling/` - Data marshalling utilities
- `src/Redifinition/` - Type redefinition
- `src/Systems/` - System base classes and implementations
- `src/Updating/` - Update loop management

## Source Structure

```
src/
  Collections/
  Exceptions/
  Kernel/
  Marshalling/
  Redifinition/
  Systems/
  Updating/
```

## Key Types

- `GameObject` - Core entity type
- `Scene` - Scene management
- `EntityData` - Entity data storage
- `QueryEnumerable` - Entity query system
- `NeighborCache` - Spatial neighbor caching

## Testing

- Test project: `Alis.Core.Ecs.Test`
- Located at `4_Operation/Ecs/test/`

## Related

- [[ECS Architecture]]
- [[Alis.Core.Aspect.Memory]]
- [[Alis.Core.Aspect.Time]]
- [[Alis.App.Engine]]
- [[Projects Index]]
