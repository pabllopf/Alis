# Query

## Definition

**Query** is a component-based entity filter that efficiently retrieves entities matching specific component combinations for processing.

## Core Purpose

Query enables:

- Efficient entity filtering by component signature
- Zero-copy component access during iteration
- Automatic archetype-based optimization

## Structure

```csharp
public struct Query<T1, T2> where T1 : struct where T2 : struct
{
    public GameObject[] Entities { get; }
    public FastestTable<T1> Table1 { get; }
    public FastestTable<T2> Table2 { get; }
    
    public T1 GetComponent1(GameObject entity);
    public T2 GetComponent2(GameObject entity);
}

// Generic multi-component query
public struct Query<T1, T2, T3> where T1 : struct where T2 : struct where T3 : struct
{
    public GameObject[] Entities { get; }
    public FastestTable<T1> Table1 { get; }
    public FastestTable<T2> Table2 { get; }
    public FastestTable<T3> Table3 { get; }
}
```

## Usage in ECS

### Basic Query

Filter entities by component combination:

```csharp
// Create query for entities with Transform and Velocity
Query<Transform, Velocity> movementQuery = 
    new Query<Transform, Velocity>(scene);

// Iterate matching entities
foreach (var entity in movementQuery.Entities)
{
    ref Transform transform = ref movementQuery.GetComponent1(entity);
    ref Velocity velocity = ref movementQuery.GetComponent2(entity);
    
    // Update position based on velocity
    transform.Position += velocity.Value * deltaTime;
}
```

### Query Creation

Initialize query with scene reference:

```csharp
public struct Query<T1, T2> where T1 : struct where T2 : struct
{
    private Scene _scene;
    
    public Query(Scene scene)
    {
        _scene = scene;
        
        // Find archetype with both components
        GameObjectType type = FindArchetype<T1, T2>(scene);
        
        // Get component tables from archetype
        Table1 = type.GetComponentStorage<T1>();
        Table2 = type.GetComponentStorage<T2>();
        
        // Get matching entities
        Entities = GetMatchingEntities(type);
    }
}

// Usage
Query<Transform, Health> query = new Query<Transform, Health>(scene);
```

### Component Access

Get components from queried entities:

```csharp
public T1 GetComponent1(GameObject entity)
{
    GameObjectLocation location = GetEntityLocation(entity);
    return Table1[location.Index];
}

public T2 GetComponent2(GameObject entity)
{
    GameObjectLocation location = GetEntityLocation(entity);
    return Table2[location.Index];
}

// Usage
foreach (var entity in query.Entities)
{
    ref Transform transform = ref query.GetComponent1(entity);
    ref Health health = ref query.GetComponent2(entity);
    
    // Process entity and components
}
```

### Multi-Component Queries

Query with multiple component types:

```csharp
// Query with 3 components
Query<Transform, Health, Render> combatQuery = 
    new Query<Transform, Health, Render>(scene);

foreach (var entity in combatQuery.Entities)
{
    ref Transform transform = ref combatQuery.GetComponent1(entity);
    ref Health health = ref combatQuery.GetComponent2(entity);
    ref Render render = ref combatQuery.GetComponent3(entity);
    
    // Process entity with all three components
}
```

## Query Optimization

### Archetype Matching

Query automatically finds matching archetypes:

```csharp
private GameObjectType FindArchetype<T1, T2>(Scene scene)
{
    foreach (var archetype in scene.Archetypes.Values)
    {
        if (archetype.HasComponent<T1>() && 
            archetype.HasComponent<T2>())
        {
            return archetype.Type;
        }
    }
    
    return null;
}

// Query only iterates entities from matching archetypes
```

### Entity Filtering

Filter entities by component presence:

```csharp
private GameObject[] GetMatchingEntities(GameObjectType type)
{
    FastestTable<GameObject> entityTable = type.GetEntityTable();
    
    // Get entities that have both components
    FastestTable<T1> table1 = type.GetComponentStorage<T1>();
    FastestTable<T2> table2 = type.GetComponentStorage<T2>();
    
    // Intersection of entity indices
    return GetEntityIntersection(table1, table2);
}

// Query returns only entities with all required components
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Query Creation** | O(a) where a = archetype count |
| **Entity Iteration** | O(m) where m = matching entities |
| **Component Access** | O(1) FastestTable lookup |
| **Memory Overhead** | Minimal (no allocation during iteration) |

## Related

- [[System]] - Processing unit using queries
- [[FastestTable]] - High-performance lookup table
- [[Archetype]] - Component type optimization
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[GameObject]] - Entity handle
- [[entity-component-system-ecs]] — ECS overview
- [[Rule]] — Query constraint
- [[GameObjectEnumerator]] — Entity iteration

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[queries-index]] — Full query index
- [[performance-index]] — Query performance
- [[architecture-index]] — Patterns
