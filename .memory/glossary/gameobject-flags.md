---
title: GameObjectFlags
tags: [glossary,terminology,reference]
---


## Definition

**GameObjectFlags** is a bitwise flags enum that tracks entity state, lifecycle events, and component presence for efficient entity management and event handling.

## Core Purpose

GameObjectFlags enables:

- Efficient state tracking via bitwise operations
- Event notification based on entity state
- Component presence/absence detection

## Flag Definitions

```csharp
[Flags]
public enum GameObjectFlags : ushort
{
    None = 0,
    
    // Component events
    AddComp = 1 << 0,           // Component added flag
    RemoveComp = 1 << 1,         // Component removed flag
    AddGenericComp = 1 << 2,     // Generic component added
    
    // Entity lifecycle
    WorldCreate = 1 << 3,        // Entity created event
    OnDelete = 1 << 4,           // Entity deleted event
    
    // Component presence
    HasTransform = 1 << 5,       // Entity has Transform component
    HasHealth = 1 << 6,          // Entity has Health component
    
    // Event flags
    WorldEventFlags = 1 << 7,    // World-level events
}
```

## Usage in ECS

### Event Flag Checking

Check if entity has specific event flag:

```csharp
public static bool HasEventFlag(GameObjectFlags flags, GameObjectFlags eventFlag)
{
    return (flags & eventFlag) != 0;
}

// Check if component added event should fire
if (HasEventFlag(flags, GameObjectFlags.AddComp))
{
    // Fire component added event
}
```

### Component Presence Detection

Track component presence via flags:

```csharp
GameObjectFlags flags = thisLookup.Flags;

if (HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
{
    // Handle component addition
}
```

### Event Management

Update flags when events registered:

```csharp
public event Action<GameObject, ComponentId> ComponentAdded
{
    add
    {
        ComponentAddedEvent.Add(value);
        WorldEventFlags |= GameObjectFlags.AddComp;
    }
    remove
    {
        ComponentAddedEvent.Remove(value);
        if (!ComponentAddedEvent.HasListeners)
        {
            WorldEventFlags &= ~GameObjectFlags.AddComp;
        }
    }
}
```

## Flag Operations

### Bitwise AND

Check specific flag:

```csharp
if ((flags & GameObjectFlags.AddComp) != 0)
{
    // AddComp flag is set
}
```

### Bitwise OR

Set specific flag:

```csharp
WorldEventFlags |= GameObjectFlags.AddComp;  // Set AddComp
```

### Bitwise XOR

Toggle specific flag:

```csharp
WorldEventFlags ^= GameObjectFlags.OnDelete;  // Toggle OnDelete
```

### Bitwise NOT

Clear specific flag:

```csharp
WorldEventFlags &= ~GameObjectFlags.AddComp;  // Clear AddComp
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Flag Check** | O(1) bitwise AND |
| **Set Flag** | O(1) bitwise OR |
| **Clear Flag** | O(1) bitwise AND NOT |
| **Toggle Flag** | O(1) bitwise XOR |

## Related

- [[GameObject]] - Entity handle
- [[Event<T>]] - Generic event handler
- [[ComponentEvent]] - Component lifecycle events
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview
- [[GameObjectOnlyEvent]] — Entity-only event

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[events-index]] — Event system
- [[architecture-index]] — Patterns
