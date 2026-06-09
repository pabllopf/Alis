---
title: Component
tags:
  - entity
  - gameobject
  - scene
  - component
status: Done
license: GPLv3
---


## Overview
A data-only struct or class that holds state information for entities in the ECS architecture. Components contain no logic—only data that systems operate on.

## Summary
- **Type**: Struct or class (data-only)
- **Purpose**: Hold entity state/data
- **Logic**: None (systems provide logic)
- **Pattern**: Data-Oriented Design

## Core Principles

### Data-Only Nature
- **No behavior**: Components contain only data fields
- **No inheritance**: Pure data containers
- **No virtual methods**: Static dispatch only
- **POCO-style**: Plain Old Component Objects

### Type Safety
- **Generic constraints**: `where T : unmanaged` for value types
- **Compile-time checking**: Type-safe component access
- **Zero-copy access**: Ref returns for in-place modification

### Component Registration
- **Explicit registration**: Must be registered before use
- **Type-based storage**: Components stored by type in Scene
- **Lifecycle events**: Component add/remove notifications

## Component Patterns

### Value Type Components
```csharp
[ComponentUpdate] // Marks for update system processing
public struct Transform : IComponent
{
    public float X;
    public float Y;
    public float Z;
}

[ComponentUpdate]
public struct Velocity : IComponent
{
    public float X;
    public float Y;
}

[ComponentUpdate]
public struct Health : IComponent
{
    public int Value;
    public int MaxValue;
}
```

### Reference Type Components
```csharp
[ComponentUpdate]
public class Inventory : IComponent
{
    public List<string> Items { get; set; } = new();
    public int Gold { get; set; }
}

[ComponentUpdate]
public class AIState : IComponent
{
    public enum StateType { Idle, Chase, Flee }
    public StateType CurrentState { get; set; }
    public GameObject Target { get; set; }
}
```

### Marker Components
```csharp
// Empty component for tagging entities
public struct Renderable : IComponent { }

// Tag for specific processing
public struct CollisionBox : IComponent 
{ 
    public float Radius; 
}

// Flag for special handling
public struct PlayerControlled : IComponent { }
```

## Component Lifecycle

### Registration
```csharp
// Implicit registration via scene.Create()
var entity = scene.Create(new Transform(), new Health());

// Explicit registration (if needed)
scene.RegisterComponent<Transform>();
```

### Addition to Entity
```csharp
// Add component dynamically
entity.Add(new Velocity { X = 5, Y = 10 });

// Add with initialization
entity.Add(new Health { Value = 100, MaxValue = 100 });

// Check before adding
if (!entity.Has<Velocity>())
{
    entity.Add(new Velocity());
}
```

### Removal from Entity
```csharp
// Remove component
entity.Remove<Health>();

// Check if exists before removing
if (entity.Has<Renderable>())
{
    entity.Remove<Renderable>();
}
```

### Component Events
- **OnAdd**: Triggered when component added to entity
- **OnRemove**: Triggered when component removed from entity
- **OnUpdate**: Called during update cycle if marked with `[ComponentUpdate]`

## Component Storage

### Archetype-Based Organization
- **Archetypes**: Groups of entities with same component types
- **Chunks**: Contiguous memory blocks within archetypes
- **SparseSet**: Fast entity lookup by ID

### Memory Layout
```
Scene
├── ArchetypeTable
│   ├── Archetype<Transform, Health>
│   │   └── Chunk1 [Transform, Transform, ...]
│   │        [Health,    Health,    ...]
│   └── Archetype<Transform, Velocity>
│       └── Chunk1 [Transform, Transform, ...]
│        [Velocity,  Velocity,    ...]
└── EntityStorage (SparseSet)
```

### Performance Characteristics
- **O(1) component access**: Direct ref return
- **Cache-friendly**: Chunk-based sequential storage
- **No allocation**: Value types stored inline in chunks

## Component Attributes

### Update Markers
```csharp
[ComponentUpdate] // Processed in Update system
public struct Transform : IComponent { }

[ComponentUpdate(typeof(FixedUpdate))] // Processed in FixedUpdate
public struct PhysicsBody : IComponent { }

[ComponentUpdate(UpdateOrder.First)] // Custom update order
public struct InputHandler : IComponent { }
```

### Custom Attributes
```csharp
[ComponentStorage(typeof(CustomStorage))] // Custom storage strategy
public struct SpecialComponent : IComponent { }

[ComponentEvent(typeof(ComponentEventHandler))] // Custom events
public struct EventTrigger : IComponent { }
```

## Component Best Practices

### Design Guidelines
1. **Keep components small**: Focused data containers
2. **Avoid references**: Prefer value types when possible
3. **No logic**: Only data, systems handle behavior
4. **Immutable where possible**: Use readonly for read-only components

### Performance Tips
1. **Use value types**: Avoid heap allocation
2. **Group related data**: Combine frequently accessed components
3. **Avoid virtual calls**: Static dispatch preferred
4. **Minimize component count**: Fewer components = better cache locality

### Common Patterns

#### Health System
```csharp
public struct Health : IComponent
{
    public int Current;
    public int Max;
    public bool IsDead => Current <= 0;
}

// System handles logic, component holds data
public class HealthSystem : IUpdate
{
    public void Update(Scene scene)
    {
        var query = scene.CreateQuery(Rule.With<Health>().And<Targetable>());
        
        foreach (var entity in query)
        {
            ref var health = ref entity.Get<Health>();
            // System logic, not component
        }
    }
}
```

#### Transform Component
```csharp
[ComponentUpdate]
public struct Transform : IComponent
{
    public float X, Y, Z;
    public float Rotation;
    public float Scale;
    
    // Helper methods allowed, no state changes
    public void Translate(float dx, float dy)
    {
        X += dx;
        Y += dy;
    }
}
```

## Related Documentation
- [[GameObject]] - Entity struct representation
- [[Scene]] - Scene container managing entities
- [[Query]] - ECS query system
- [[System]] - Logic processing pattern
- [[Archetype]] - Component type grouping
- [[Entity Component System]] - ECS concept overview

## See Also
- [[projects/4_Operation/Ecs.md]] - Full ECS documentation
- [[diagrams/component-patterns]] - Component pattern diagrams
- [[decisions/adr-005-component-design]] - Component design decisions
