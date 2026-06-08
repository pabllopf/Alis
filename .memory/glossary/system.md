# System

## Definition

A **System** is a logic processor that operates on components with specific attributes in the ECS architecture. Systems contain all game logic and iterate over entities matching component queries.

## Core Responsibilities

### Component Processing

Systems process components by:

1. Filtering entities with specific component combinations
2. Iterating over matching entities
3. Executing logic on component references

### Update Cycles

Systems execute in update cycles:

```csharp
// Update all systems with FixedUpdate attribute
scene.Update<FixedUpdate>();

// Update specific component type
scene.UpdateComponent<Transform>();
```

## System Types

### IComponentUpdateFilter

Single-component update system:

```csharp
[UpdateType(typeof(FixedUpdate))]
public class MovementSystem : IComponentUpdateFilter
{
    public void Update(ref Transform t, ref Velocity v)
    {
        t.X += v.X;
        t.Y += v.Y;
    }
}
```

### SceneUpdateFilter

Multi-component system with rules:

```csharp
[UpdateType(typeof(FixedUpdate))]
public class PhysicsSystem : SceneUpdateFilter
{
    public override void Update()
    {
        foreach (ref var entity in Entities)
        {
            ref var transform = ref entity.Get<Transform>();
            ref var velocity = ref entity.Get<Velocity>();
            
            transform.X += velocity.X;
            transform.Y += velocity.Y;
        }
    }
}
```

## System Attributes

### UpdateTypeAttribute

Marks systems for specific update cycles:

```csharp
[UpdateType(typeof(FixedUpdate))]
public class MovementSystem : IComponentUpdateFilter { }

[UpdateType(typeof(BeforeDraw))]
public class RenderingSystem : IComponentUpdateFilter { }
```

### UpdateOrderAttribute

Controls execution order within update cycle:

```csharp
[UpdateType(typeof(FixedUpdate))]
[UpdateOrder(1)]
public class PhysicsSystem : IComponentUpdateFilter { }

[UpdateType(typeof(FixedUpdate))]
[UpdateOrder(2)]
public class MovementSystem : IComponentUpdateFilter { }
```

## System Lifecycle

### Registration

Systems automatically registered when attached to scene:

1. Scene scans for `[UpdateType]` attributes
2. Systems added to update registry
3. Executed during `scene.Update<T>()`

### Execution

```csharp
// Enter update state
scene.EnterDisallowState();

try
{
    // Update all systems with attribute T
    scene.Update<T>();
}
finally
{
    // Exit update state, apply deferred changes
    scene.ExitDisallowState();
}
```

## System Events

- Component added/removed events trigger system updates
- Archetype changes automatically update system queries
- Deferred structural changes queued and applied

## Performance

- **Cache Efficiency**: Contiguous component storage
- **Query Caching**: Hash-based query result caching
- **AOT Safe**: No reflection, no dynamic code generation

## Related

- [[Component]] - Data container
- [[GameObject]] - Entity handle
- [[Scene]] - World container
- [[Query]] - Entity filtering
