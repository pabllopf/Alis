---
title: ComponentEvent
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**ComponentEvent** is a lifecycle event handler that manages component addition and removal callbacks for entity state tracking.

## Core Purpose

ComponentEvent enables:

- Component lifecycle monitoring
- Entity state change notifications
- Automatic event flag management

## Structure

```csharp
public class ComponentEvent
{
    public Event<ComponentId> ComponentAddedEvent { get; }
    public Event<ComponentId> ComponentRemovedEvent { get; }
    
    public GameObjectFlags Flags { get; set; }
    
    public void FireComponentAdded(GameObject gameObject, ComponentId componentId);
    public void FireComponentRemoved(GameObject gameObject, ComponentId componentId);
}
```

## Usage in ECS

### Component Added Event

```csharp
public void FireComponentAdded(GameObject gameObject, ComponentId componentId)
{
    // Set flag for event handling
    Flags |= GameObjectFlags.AddComp;
    
    // Invoke all listeners
    ComponentAddedEvent.Invoke(gameObject, componentId);
}

// Subscribe to events
scene.ComponentEvent.ComponentAddedEvent.Add((entity, compId) =>
{
    Console.WriteLine($"Component {compId} added to entity {entity.EntityID}");
});
```

### Component Removed Event

```csharp
public void FireComponentRemoved(GameObject gameObject, ComponentId componentId)
{
    // Set flag for event handling
    Flags |= GameObjectFlags.RemoveComp;
    
    // Invoke all listeners
    ComponentRemovedEvent.Invoke(gameObject, componentId);
}

// Subscribe to events
scene.ComponentEvent.ComponentRemovedEvent.Add((entity, compId) =>
{
    Console.WriteLine($"Component {compId} removed from entity {entity.EntityID}");
});
```

### Event Flag Management

Automatic flag updates:

```csharp
public void FireComponentAdded(GameObject gameObject, ComponentId componentId)
{
    // Update flags based on event listeners
    if (ComponentAddedEvent.HasListeners)
    {
        Flags |= GameObjectFlags.AddComp;
    }
    
    // Fire event
    ComponentAddedEvent.Invoke(gameObject, componentId);
}
```

## Event Lifecycle

### Registration

```csharp
public class Scene
{
    public ComponentEvent ComponentEvent = new ComponentEvent();
    
    public void Initialize()
    {
        // Register default event handlers
        ComponentEvent.ComponentAddedEvent.Add(OnComponentAdded);
        ComponentEvent.ComponentRemovedEvent.Add(OnComponentRemoved);
    }
}
```

### Cleanup

```csharp
public void Dispose()
{
    // Remove all listeners
    ComponentEvent.ComponentAddedEvent.Clear();
    ComponentEvent.ComponentRemovedEvent.Clear();
}
```

## Related

- [[GameObjectFlags]] - Entity state flags
- [[Event<T>]] - Generic event handler
- [[GameObject]] - Entity handle
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[events-index]] — Event system index
- [[handlers-index]] — Handler index
