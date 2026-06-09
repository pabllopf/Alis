---
title: Scene
tags:
  - entity
  - gameobject
  - scene
  - component
status: To Do
license: GPLv3
---


## Overview
The central container for all entities and systems in the ECS architecture. Manages an isolated world or game level with its own collection of entities, each consisting of typed components.

## Summary
- **Type**: Class (reference type)
- **Namespace**: `Alis.Core.Ecs`
- **Implements**: `IDisposable`
- **Primary Role**: Entity management, component operations, system execution

## Core Responsibilities

### Entity Management
- Create entities with arbitrary component combinations
- Add/remove components dynamically
- Delete entities with proper cleanup
- Structural change safety during update cycles

### Component Operations
- Register component types for ECS storage
- Add components to entities
- Remove components from entities
- Query components by type

### System Execution
- Update systems by attribute type (Update, FixedUpdate)
- Execute per-frame game logic
- Manage update order and dependencies

## Key Features

### Deferred Structural Changes
- **Queue modifications** during update cycles
- **Apply after update completes** to maintain consistency
- **Recursion limit**: 200 deferred operations maximum

### Custom Queries
- **Rule-based filtering**: Filter entities by component presence
- **Type-safe queries**: Compile-time component type checking
- **High-performance iteration**: Chunk-based entity iteration

### Bulk Operations
- **Massive entity creation**: Create hundreds/thousands of entities efficiently
- **Bulk component addition**: Add same component to multiple entities
- **Chunk-based processing**: Cache-friendly for performance

## API Reference

### Entity Creation
```csharp
// Create entity with components
var player = scene.Create(
    new Transform { X = 0, Y = 0 }, 
    new Health { Value = 100 }
);

// Create multiple entities at once
var enemies = scene.CreateMany(100, () => 
    new Transform { X = 0, Y = 0 }
);

// Create with specific archetype
var entity = scene.Create(new ComponentA(), new ComponentB());
```

### Component Operations
```csharp
// Add component
entity.Add(new Velocity { X = 5, Y = 10 });

// Remove component
entity.Remove<Health>();

// Check if entity has component
if (entity.Has<Velocity>())
{
    // Component exists
}

// Get component reference (zero-copy)
ref var transform = ref entity.Get<Transform>();
transform.X += 10;
```

### Querying
```csharp
// Create query with rules
var query = scene.CreateQuery(
    Rule.With<Transform>().And<Health>()
);

// Iterate entities with components
foreach (var entity in query)
{
    var transform = entity.Get<Transform>();
    var health = entity.Get<Health>();
    
    // Process entity
}

// Get single entity
var player = scene.Get<Player>();
```

### System Execution
```csharp
// Update all systems
scene.Update();

// Update specific system type
scene.Update<FixedUpdate>();

// Update with custom order
scene.Update<Update>(order: UpdateOrder.First);
```

## Internal Structure

### Data Structures
| Component | Type | Purpose |
|---|---|---|
| EntityStorage | SparseSet | Fast entity lookup by ID |
| ComponentStorage | Dictionary<Type, Storage> | Type-based component storage |
| ArchetypeTable | Dictionary<Archetype, Chunk> | Archetype grouping for cache efficiency |
| UpdateSystems | List<ISystem> | Registered update systems |

### Memory Layout
- **SparseSet**: Entity ID to index mapping for O(1) lookup
- **Chunks**: Contiguous memory blocks for entities with same components
- **Archetypes**: Component type combinations grouped together

## Lifecycle Management

### Scene Creation
```csharp
using Scene scene = new Scene();
```

### Entity Lifecycle
1. **Create**: `scene.Create()` assigns ID and version
2. **Update**: Components modified during game loop
3. **Delete**: Entity marked deleted, ID may be recycled

### Disposal
```csharp
using Scene scene = new Scene();
// Automatically disposes entities and releases resources
```

## Performance Characteristics

### Query Performance
- **O(1) entity lookup**: SparseSet indexing
- **O(n) query iteration**: n = matching entities
- **Cache-friendly**: Chunk-based storage for sequential access

### Memory Efficiency
- **No heap allocation** for GameObject structs (8 bytes)
- **Chunk-based storage**: Contiguous memory for components
- **Archetype optimization**: Entities with same components grouped

### Update Performance
- **System execution**: O(m) where m = number of systems
- **Component iteration**: Cache-efficient chunk traversal
- **Deferred changes**: Minimal overhead during structural modifications

## Threading Considerations

### Thread Safety
- **Not thread-safe**: Scene operations require synchronization
- **Update cycle safety**: Structural changes queued, not applied immediately
- **Multi-threaded scenarios**: May have race conditions without external synchronization

### Best Practices
- Serialize scene access from multiple threads
- Use locks or concurrent collections for shared scenes
- Consider separate scenes per thread

## Related Documentation
- [[GameObject]] - Entity struct representation
- [[EntityData]] - Compact entity identity
- [[Component]] - Component data pattern
- [[Query]] - ECS query system
- [[Archetype]] - Component type grouping
- [[Entity Component System]] - ECS concept overview

## See Also
- [[projects/4_Operation/Ecs.md]] - Full ECS documentation
- [[diagrams/scene-architecture]] - Scene architecture diagram
- [[decisions/adr-004-scene-management]] - Scene management decisions
