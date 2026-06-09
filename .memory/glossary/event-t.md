---
title: Event<T>
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**Event<T>** is a generic event handler that provides type-safe event registration, invocation, and management for ECS lifecycle events and component callbacks.

## Core Purpose

Event<T> enables:

- Type-safe event subscription
- Efficient event invocation
- Listener management and cleanup

## Structure

```csharp
public class Event<T>
{
    public Action<T>[] Listeners { get; }
    public int Count { get; }
    
    public void Add(Action<T> listener);
    public void Remove(Action<T> listener);
    public bool HasListeners { get; }
    
    public void Invoke(T param);
    public void InvokeInternal(GameObject gameObject, ComponentId componentId);
}

public class Event  // Non-generic version
{
    public Action<GameObject>[] Listeners { get; }
    public int Count { get; }
    
    public void Add(Action<GameObject> listener);
    public void Remove(Action<GameObject> listener);
}
```

## Usage Examples

### Component Added Event

```csharp
public Event<ComponentId> ComponentAddedEvent = new Event<ComponentId>();

// Subscribe to component added events
scene.ComponentAddedEvent.Add((gameObject, componentId) =>
{
    Console.WriteLine($"Component added to entity {gameObject.EntityID}");
});

// Fire event
ComponentAddedEvent.Invoke(gameObject, ComponentId);
```

### Entity Lifecycle Events

```csharp
public GameObjectOnlyEvent EntityCreatedEvent = new GameObjectOnlyEvent();
public GameObjectOnlyEvent EntityDeletedEvent = new GameObjectOnlyEvent();

// Subscribe to entity creation
scene.EntityCreated += (entity) =>
{
    Console.WriteLine($"Entity created: {entity.EntityID}");
};

// Subscribe to entity deletion
scene.EntityDeleted += (entity) =>
{
    Console.WriteLine($"Entity deleted: {entity.EntityID}");
};
```

### Event Management

```csharp
// Check if event has listeners
if (ComponentAddedEvent.HasListeners)
{
    // Fire event
    ComponentAddedEvent.Invoke(gameObject, componentId);
}

// Remove all listeners
ComponentAddedEvent.Clear();

// Remove specific listener
scene.ComponentAddedEvent.Remove(listener);
```

## Event Invocation

### Single Parameter

```csharp
public void Invoke(T param)
{
    if (Listeners == null) return;
    
    for (int i = 0; i < Listeners.Length; i++)
    {
        Listeners[i](param);
    }
}
```

### Multiple Parameters

```csharp
public void InvokeInternal(GameObject gameObject, ComponentId componentId)
{
    if (Listeners == null) return;
    
    for (int i = 0; i < Listeners.Length; i++)
    {
        Listeners[i](gameObject, componentId);
    }
}
```

## Event Performance

| Operation | Complexity |
|-----------|------------|
| **Add Listener** | O(1) amortized |
| **Remove Listener** | O(n) linear scan |
| **Invoke All** | O(m) where m = listener count |
| **HasListeners Check** | O(1) |

## Related

- [[GameObjectFlags]] - Entity state flags
- [[ComponentEvent]] - Component lifecycle events
- [[GameObjectOnlyEvent]] - Entity-only event handler
- [[GameObject]] - Entity handle
- [[Component]] - Data-only struct
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[events-index]] — Event system index
- [[handlers-index]] — Handler index
- [[architecture-index]] — Patterns
