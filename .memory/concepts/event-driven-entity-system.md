---
title: Event-Driven Entity System
tags:
  - concept
  - theory
  - documentation

status: draft
---


Event-driven entity systems provide per-entity event notifications for lifecycle management, debugging, and decoupled system communication.

## Core Concept

### Per-Entity Events
- **Pattern**: Events tied to specific entity lifecycle
- **Location**: `4_Operation/Ecs/src/PerEntityEvents.cs`
- **Benefits**: Decoupled systems, reactive architecture, debugging hooks

### Event Types

| Event | Trigger | Usage |
|-------|---------|-------|
| **EntityCreated** | Entity created | Initialization, setup |
| **EntityDestroyed** | Entity removed | Cleanup, resource release |
| **ComponentAdded<T>** | Component added | React to new component |
| **ComponentRemoved<T>** | Component removed | Cleanup, state reset |

## Implementation Examples

### PerEntityEvents System

```csharp
public class PerEntityEvents
{
    private readonly Dictionary<EntityId, List<Action>> _createdHandlers;
    private readonly Dictionary<EntityId, List<Action>> _destroyedHandlers;
    
    public void SubscribeCreated(EntityId entity, Action handler)
    {
        if (!_createdHandlers.ContainsKey(entity))
            _createdHandlers[entity] = new List<Action>();
        
        _createdHandlers[entity].Add(handler);
    }
    
    public void SubscribeDestroyed(EntityId entity, Action handler)
    {
        if (!_destroyedHandlers.ContainsKey(entity))
            _destroyedHandlers[entity] = new List<Action>();
        
        _destroyedHandlers[entity].Add(handler);
    }
}
```

### Usage Pattern

```csharp
// Subscribe to entity creation
events.SubscribeCreated(myEntity, () =>
{
    // Initialize entity resources
    LoadTexture("sprite.png");
    PlaySound("spawn");
});

// Subscribe to entity destruction
events.SubscribeDestroyed(myEntity, () =>
{
    // Cleanup resources
    DisposeTexture();
    StopSound();
});

// Entity automatically triggers events on lifecycle changes
var entity = world.CreateEntity();
// Triggers EntityCreated event
```

### Component Event Handlers

```csharp
public class MovementSystem : ISystem
{
    private PerEntityEvents _events;
    private Query<Position, Velocity> _query;
    
    public void Initialize(PerEntityEvents events)
    {
        _events = events;
        
        // React to Velocity component changes
        events.SubscribeComponentAdded<Velocity>(entity =>
        {
            // Enable movement for this entity
            EnableMovement(entity);
        });
        
        events.SubscribeComponentRemoved<Velocity>(entity =>
        {
            // Disable movement for this entity
            DisableMovement(entity);
        });
    }
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Decoupling** | Systems react to events without direct dependencies |
| **Debugging** | Easy to trace entity lifecycle |
| **Extensibility** | Add new behaviors without modifying existing code |
| **Testing** | Mock events for unit testing |

## Performance Considerations

| Metric | Value |
|--------|-------|
| Event subscription overhead | ~100ns |
| Event dispatch (100 entities) | ~500ns |
| Memory per entity events | ~64 bytes |

## When to Use Event-Driven Entity System

### Suitable For
- Game entity lifecycle management
- Resource cleanup automation
- Debugging and logging
- Plugin architectures

### Not Suitable For
- Performance-critical tight loops
- Simple state machines
- Low-frequency updates

## See Also
- [`.memory/sources/ecs-sources.md`] - Entity Component System
