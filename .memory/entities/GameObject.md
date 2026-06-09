# GameObject

## Overview
A lightweight struct representing an entity in the ECS (Entity Component System) architecture. Serves as the primary handle for accessing and manipulating game objects within a Scene.

## Summary
- **Type**: Struct (value type)
- **Size**: 8 bytes (packed, no padding)
- **Memory Layout**: EntityID (4 bytes) + EntityVersion (2 bytes) + WorldID (2 bytes)
- **Pack**: 1 for optimal memory efficiency

## Core Structure
```csharp
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GameObject : IEquatable<GameObject>, IGameObject
{
    internal int EntityID;      // Unique identifier within scene
    internal ushort EntityVersion; // Version counter for ID recycling safety
    internal ushort WorldID;     // Scene identifier that owns this entity
}
```

## Key Features

### Entity ID Recycling Safety
- **Version Counter**: Increments each time an entity is deleted and recreated
- **Stale Reference Detection**: Prevents access to deleted entities through version validation
- **Compile-Time and Runtime Validation**: Dual-layer safety mechanism

### Memory Efficiency
- **8 bytes total**: Minimal footprint for bulk entity storage
- **No padding**: Pack = 1 ensures optimal memory layout
- **Value type**: No heap allocation, stack-friendly

### Operations
| Method | Description |
|---|---|
| `IsAlive()` | Checks if entity exists and hasn't been deleted |
| `Get<T>()` | Returns reference to component of type T |
| `Add<T>(T component)` | Adds a component to the entity |
| `Remove<T>()` | Removes a component from the entity |
| `Deconstruct()` | Decomposes into constituent parts |

## Usage Examples

### Creating Entities
```csharp
var scene = new Scene();

// Create entity with components
var player = scene.Create(
    new Transform { X = 0, Y = 0 }, 
    new Health { Value = 100 }
);

// Create entity with single component
var enemy = scene.Create(new Transform { X = 10, Y = 5 });
```

### Component Access
```csharp
// Get component reference (returns default if not present)
ref var health = ref player.Get<Health>();

// Modify component in-place
health.Value -= 10;

// Check if entity is alive
if (player.IsAlive())
{
    // Safe to modify components
    var transform = player.Get<Transform>();
    transform.X += 5;
}
```

### Adding/Removing Components
```csharp
// Add component dynamically
player.Add(new Velocity { X = 5, Y = 10 });

// Remove component
player.Remove<Health>();

// Check if entity has component
if (player.Has<Velocity>())
{
    // Component exists
}
```

## Lifecycle Management

### Creation
- Generated when calling `scene.Create()` with components
- Assigned unique EntityID and WorldID
- Version starts at 1 for new entities

### Deletion
- Entity marked as deleted but ID may be recycled
- Version increments to prevent stale references
- Components removed from entity

### Recycling
- Deleted entity IDs can be reassigned to new entities
- Old references become invalid (version mismatch)
- Systems must validate entity alive status before operations

## Performance Characteristics

### Memory Access
- **Direct memory access**: No indirection through GameObject struct
- **Span<T> based**: Component storage uses spans for cache efficiency
- **Archetype-based grouping**: Entities with same components stored contiguously

### Query Performance
- **O(1) component access**: Direct field access via ref returns
- **SparseSet indexing**: Fast entity lookup by ID
- **Chunk-based iteration**: Cache-friendly for bulk operations

## Related Documentation
- [[Scene]] - Scene container managing entities
- [[EntityData]] - Compact entity identity representation
- [[Component]] - Component data pattern
- [[Query]] - ECS query system
- [[Archetype]] - Component type grouping
- [[Entity Component System]] - ECS concept overview

## See Also
- [[projects/4_Operation/Ecs.md]] - Full ECS documentation
- [[diagrams/entity-lifecycle]] - Entity lifecycle diagram
- [[decisions/adr-003-entity-recycling]] - ID recycling architecture decision
