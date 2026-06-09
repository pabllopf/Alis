---
title: GameObjectIdOnly
tags: [glossary,terminology,reference]
---


## Definition

**GameObjectIdOnly** is a lightweight entity ID wrapper that stores only the entity identifier without world or version information, used for recycled entity tracking and efficient ID management.

## Core Purpose

GameObjectIdOnly enables:

- Minimal memory footprint for entity IDs
- Recycled entity ID tracking
- Fast ID comparison and storage

## Structure

```csharp
public struct GameObjectIdOnly
{
    public int EntityID;  // Unique entity identifier
    
    public GameObjectIdOnly(int id);
    public bool Equals(GameObjectIdOnly other);
    public override int GetHashCode();
}

// Comparison operators
public static bool operator ==(GameObjectIdOnly a, GameObjectIdOnly b);
public static bool operator !=(GameObjectIdOnly a, GameObjectIdOnly b);
```

## Usage in ECS

### Recycled Entity IDs

Track recycled entity identifiers:

```csharp
public FastestStack<GameObjectIdOnly> RecycledEntityIds = 
    new FastestStack<GameObjectIdOnly>(256);

// Push recycled ID
RecycledEntityIds.Push(new GameObjectIdOnly(entity.EntityID));

// Pop for reuse
if (RecycledEntityIds.CanPop())
{
    var recycledId = RecycledEntityIds.Pop();
    // Reuse entity ID
}
```

### Entity ID Comparison

Compare entity IDs:

```csharp
GameObjectIdOnly id1 = new GameObjectIdOnly(42);
GameObjectIdOnly id2 = new GameObjectIdOnly(42);

if (id1 == id2)
{
    Console.WriteLine("Same entity ID");
}

// Hash for dictionary lookup
Dictionary<int, GameObjectIdOnly> idMap = new Dictionary<int, GameObjectIdOnly>();
idMap[id1.EntityID] = id1;
```

### Entity ID Generation

Generate unique entity IDs:

```csharp
private int _nextEntityId = 1;

public GameObjectIdOnly GenerateEntityId()
{
    return new GameObjectIdOnly(_nextEntityId++);
}

// Create entity with generated ID
GameObjectIdOnly id = GenerateEntityId();
GameObject entity = new GameObject(id);
```

## Memory Efficiency

### Minimal Size

Only stores entity ID:

```csharp
public struct GameObjectIdOnly
{
    public int EntityID;  // 4 bytes only
}

// Total size: 4 bytes (no padding)
```

### No World Information

Unlike GameObject, does not store:

- WorldID (excluded)
- EntityVersion (excluded)
- Only EntityID included

## Related

- [[GameObject]] - Full entity handle with world and version
- [[FastestStack]] - Memory-efficient stack for recycled IDs
- [[GameObjectLocation]] - Entity location with archetype index
- [[GameObjectOnly]] - Similar ID-only wrapper
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Memory efficiency
- [[architecture-index]] — Patterns
