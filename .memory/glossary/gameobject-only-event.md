---
title: GameObjectOnlyEvent
tags:
  - glossary
  - terminology
  - reference

status: draft
---


## Definition

**GameObjectOnlyEvent** is a specialized event handler that manages entity lifecycle events without component parameters, focusing on entity creation and deletion.

## Core Purpose

GameObjectOnlyEvent enables:

- Entity lifecycle monitoring
- Creation and deletion event handling
- Simple entity-based callbacks without component data

## Structure

```csharp
public class GameObjectOnlyEvent
{
    public Action<GameObject>[] Listeners { get; }
    public int Count { get; }
    
    public void Add(Action<GameObject> listener);
    public void Remove(Action<GameObject> listener);
    public bool HasListeners { get; }
    
    public void Invoke(GameObject gameObject);
}

public class GameObjectOnlyEvent : Event<GameObject>
{
    // Inherits from generic Event<T> with T = GameObject
}
```

## Usage Examples

### Entity Creation Event

```csharp
public GameObjectOnlyEvent EntityCreatedEvent = new GameObjectOnlyEvent();

// Subscribe to entity creation
scene.EntityCreated += (entity) =>
{
    Console.WriteLine($"Entity created: {entity.EntityID}");
};

// Fire event when entity created
EntityCreatedEvent.Invoke(newEntity);
```

### Entity Deletion Event

```csharp
public GameObjectOnlyEvent EntityDeletedEvent = new GameObjectOnlyEvent();

// Subscribe to entity deletion
scene.EntityDeleted += (entity) =>
{
    Console.WriteLine($"Entity deleted: {entity.EntityID}");
};

// Fire event when entity deleted
EntityDeletedEvent.Invoke(entityToDelete);
```

### Event Management

```csharp
// Check if event has listeners
if (EntityCreatedEvent.HasListeners)
{
    // Fire event
    EntityCreatedEvent.Invoke(entity);
}

// Remove all listeners
EntityCreatedEvent.Clear();

// Remove specific listener
scene.EntityCreated -= listener;
```

## Event Lifecycle

### Entity Creation

```csharp
public GameObject CreateEntity()
{
    // Create new entity
    GameObject newEntity = new GameObject();
    
    // Fire creation event
    EntityCreatedEvent.Invoke(newEntity);
    
    return newEntity;
}

// Subscribe to creation events
scene.EntityCreated += (entity) =>
{
    Console.WriteLine($"Entity {entity.EntityID} created in world");
};
```

### Entity Deletion

```csharp
public void DeleteEntity(GameObject entity)
{
    // Fire deletion event before removing
    EntityDeletedEvent.Invoke(entity);
    
    // Remove entity from world
    EntityTable.Remove(entity.EntityID);
}

// Subscribe to deletion events
scene.EntityDeleted += (entity) =>
{
    Console.WriteLine($"Entity {entity.EntityID} deleted from world");
};
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Add Listener** | O(1) amortized |
| **Remove Listener** | O(n) linear scan |
| **Invoke All** | O(m) where m = listener count |
| **HasListeners Check** | O(1) |

## Related

- [[Event<T>]] - Generic event handler
- [[GameObject]] - Entity handle
- [[ComponentEvent]] - Component lifecycle events
- [[GameObjectFlags]] - Entity state flags
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[events-index]] — Event system
- [[handlers-index]] — Handler index
- [[architecture-index]] — Patterns
