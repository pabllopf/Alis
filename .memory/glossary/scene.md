---
title: Scene
tags:
  - glossary
  - terminology
  - reference

status: Draft

license: GPLv3

---


## Definition

**Scene** is the core container that manages entities, components, archetypes, and systems in the ECS architecture.

## Core Purpose

Scene enables:

- Entity lifecycle management (create, delete, recycle)
- Component storage and retrieval
- Archetype optimization and management
- System execution and update cycles

## Structure

```csharp
public struct Scene
{
    public FastestTable<GameObject, GameObjectLookup> EntityTable;
    public FastestTable<GameObjectType, Archetype> Archetypes;
    public FastestStack<GameObjectOnly> RecycledEntityIds;
    
    public GameObject CreateEntity<T1, T2>(...);
    public void DeleteEntity(GameObject entity);
    public GameObjectType GetOrCreateArchetype<T1, T2>(...);
}
```

## Usage in ECS

### Entity Creation

Create entities with components:

```csharp
Scene scene = new Scene();

// Create entity with Transform and Render components
GameObject entity = scene.CreateEntity<Transform, Render>();

// Access components
ref Transform transform = ref entity.GetComponent<Transform>(scene);
ref Render render = ref entity.GetComponent<Render>(scene);

transform.Position = Vector3.Zero;
render.Color = Color.White;
```

### Entity Deletion

Delete entities from scene:

```csharp
public void DeleteEntity(GameObject entity)
{
    // Remove from archetype
    GameObjectLocation location = GetEntityLocation(entity);
    Archetype archetype = GetArchetype(location.ArchetypeId);
    
    // Move to end and swap for O(1) deletion
    archetype.RemoveEntity(location);
    
    // Recycle entity ID
    RecycledEntityIds.Push(new GameObjectOnly(entity.EntityID));
}

// Usage
scene.DeleteEntity(entity);
```

### Archetype Management

Create and manage archetypes:

```csharp
public GameObjectType GetOrCreateArchetype<T1, T2>()
{
    ComponentId[] componentIds = new ComponentId[]
    {
        ComponentId<T1>,
        ComponentId<T2>
    };
    
    GameObjectType type = new GameObjectType(archetypeId, componentIds);
    
    if (!Archetypes.TryGetValue(type, out Archetype archetype))
    {
        archetype = new Archetype(type);
        Archetypes[type] = archetype;
    }
    
    return type;
}

// Usage
GameObjectType type = scene.GetOrCreateArchetype<Transform, Health>();
```

## Entity Lifecycle

### Create → Use → Delete

```csharp
// 1. Create entity
GameObject entity = scene.CreateEntity<Transform, Health>();

// 2. Use entity (update components)
ref Transform transform = ref entity.GetComponent<Transform>(scene);
transform.Position += deltaTime * movementSpeed;

// 3. Delete entity
scene.DeleteEntity(entity);

// 4. Entity ID recycled for reuse
GameObject newEntity = scene.CreateEntity<Transform>();
```

### Version Checking

Scene manages entity versions:

```csharp
public struct GameObject
{
    public int EntityID;
    public ushort EntityVersion;
    public int WorldID;
}

// Scene updates version when entity recycled
scene.RecycleEntity(entity.EntityID);
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Create Entity** | O(1) archetype lookup + FastestTable insert |
| **Delete Entity** | O(1) swap-and-pop from archetype |
| **Get Component** | O(1) FastestTable lookup |
| **Archetype Lookup** | O(1) FastestTable lookup |

## Related

- [[GameObject]] - Entity handle
- [[Archetype]] - Component type optimization
- [[FastestTable]] - High-performance lookup table
- [[Component]] - Data-only struct
- [[System]] - Logic processor
- [[Query]] - Entity filtering
- [[entity-component-system-ecs]] — ECS overview
- [[Component Storage]] — Typed data storage
- [[ChunkTuple]] — Batch creation
- [[GameObjectEnumerator]] — Entity iteration

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[queries-index]] — Query index
- [[handlers-index]] — Handler index
- [[events-index]] — Event system
- [[architecture-index]] — Patterns
