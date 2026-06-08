# GameObjectLocation

## Definition

**GameObjectLocation** is a struct that stores an entity's current location within the world, including archetype ID and storage index for fast component lookup.

## Core Purpose

GameObjectLocation enables:

- Fast entity-to-component mapping
- O(1) component retrieval by entity ID
- Efficient archetype and storage tracking

## Structure

```csharp
public struct GameObjectLocation
{
    public int ArchetypeId;      // Archetype identifier
    public int Index;            // Component storage index
    
    public GameObjectLocation(int archetypeId, int index);
    
    public bool IsValid => ArchetypeId != 0 && Index >= 0;
}

// Comparison operators
public static bool operator ==(GameObjectLocation a, GameObjectLocation b);
public static bool operator !=(GameObjectLocation a, GameObjectLocation b);
```

## Usage in ECS

### Entity Location Lookup

Retrieve entity location by ID:

```csharp
GameObjectLocation location = scene.EntityTable[entityId];

// Access archetype and storage index
int archetypeId = location.ArchetypeId;
int storageIndex = location.Index;

// Get component from archetype
ComponentStorage<Transform> storage = 
    archetype.GetComponentStorage<Transform>();

Transform transform = storage[storageIndex];
```

### Entity Table Integration

Store locations in FastestTable:

```csharp
public FastestTable<GameObjectLocation> EntityTable = 
    new FastestTable<GameObjectLocation>(256);

// Set entity location
EntityTable[entityId] = new GameObjectLocation(archetypeId, storageIndex);

// Get entity location
GameObjectLocation location = EntityTable[entityId];
```

### Component Retrieval

Fast component access:

```csharp
public T GetComponent<T>(int entityId) where T : struct
{
    GameObjectLocation location = EntityTable[entityId];
    
    if (!location.IsValid)
    {
        throw new InvalidOperationException("Entity not found");
    }
    
    Archetype archetype = GetArchetype(location.ArchetypeId);
    ComponentStorage<T> storage = archetype.GetComponentStorage<T>();
    
    return storage[location.Index];
}
```

## Location Validation

### Valid Check

```csharp
public bool IsValid => ArchetypeId != 0 && Index >= 0;

// Check location validity
GameObjectLocation location = EntityTable[entityId];
if (location.IsValid)
{
    // Safe to access component
}
else
{
    // Entity does not exist or has been deleted
}
```

### Invalid Locations

Invalid location scenarios:

- ArchetypeId == 0 (no archetype assigned)
- Index < 0 (negative storage index)
- Entity deleted from world

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Get Location** | O(1) FastestTable lookup |
| **Set Location** | O(1) FastestTable assignment |
| **Valid Check** | O(1) simple comparison |
| **Memory Size** | 8 bytes (two int values) |

## Related

- [[FastestTable]] - High-performance lookup table
- [[Archetype]] - Component type optimization
- [[Component Storage]] - Typed data storage
