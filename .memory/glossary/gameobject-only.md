# GameObjectOnly

tags:
  - glossary,terminology,reference

## Definition

**GameObjectOnly** is a lightweight entity wrapper that stores only the entity identifier without world or version information, used for recycled entity tracking and efficient ID management.

## Core Purpose

GameObjectOnly enables:

- Minimal memory footprint for entity IDs
- Recycled entity ID tracking
- Fast ID comparison and storage

## Structure

```csharp
public struct GameObjectOnly
{
    public int EntityID;  // Unique entity identifier
    
    public GameObjectOnly(int id);
    public bool Equals(GameObjectOnly other);
    public override int GetHashCode();
}

// Comparison operators
public static bool operator ==(GameObjectOnly a, GameObjectOnly b);
public static bool operator !=(GameObjectOnly a, GameObjectOnly b);
```

## Usage in ECS

### Recycled Entity IDs

Track recycled entity identifiers:

```csharp
public FastestStack<GameObjectOnly> RecycledEntityIds = 
    new FastestStack<GameObjectOnly>(256);

// Push recycled ID
RecycledEntityIds.Push(new GameObjectOnly(entity.EntityID));

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
GameObjectOnly id1 = new GameObjectOnly(42);
GameObjectOnly id2 = new GameObjectOnly(42);

if (id1 == id2)
{
    Console.WriteLine("Same entity ID");
}

// Hash for dictionary lookup
Dictionary<int, GameObjectOnly> idMap = new Dictionary<int, GameObjectOnly>();
idMap[id1.EntityID] = id1;
```

### Entity ID Generation

Generate unique entity IDs:

```csharp
private int _nextEntityId = 1;

public GameObjectOnly GenerateEntityId()
{
    return new GameObjectOnly(_nextEntityId++);
}

// Create entity with generated ID
GameObjectOnly id = GenerateEntityId();
GameObject entity = new GameObject(id);
```

## Memory Efficiency

### Minimal Size

Only stores entity ID:

```csharp
public struct GameObjectOnly
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
- [[GameObjectIdOnly]] - Similar ID-only wrapper
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Memory efficiency
- [[architecture-index]] — Patterns
