---
title: System
tags:
  - glossary
  - terminology
  - reference

status: draft

license: GPLv3
---


## Definition

**System** is a processing unit that operates on entities with specific component combinations, following the ECS architecture pattern.

## Core Purpose

System enables:

- Entity processing based on component combinations
- Update cycle management with UpdateTypeAttribute markers
- Query-based entity filtering and iteration

## Structure

```csharp
[UpdateType(UpdateType.Update)]
public class MovementSystem : SystemBase
{
    public Query<Transform, Velocity> Query { get; }
    
    public override void Update()
    {
        foreach (var entity in Query.Entities)
        {
            ref Transform transform = ref entity.GetComponent<Transform>(scene);
            ref Velocity velocity = ref entity.GetComponent<Velocity>(scene);
            
            transform.Position += velocity.Value * deltaTime;
        }
    }
}

public abstract class SystemBase
{
    public Scene Scene { get; protected set; }
    public abstract void Update();
}
```

## Usage in ECS

### System Declaration

Create system with component requirements:

```csharp
[UpdateType(UpdateType.Update)]
public class RenderSystem : SystemBase
{
    public Query<Transform, Color> Query { get; }
    
    public RenderSystem(Scene scene) : base(scene)
    {
        Query = new Query<Transform, Color>(scene);
    }
    
    public override void Update()
    {
        foreach (var entity in Query.Entities)
        {
            ref Transform transform = ref Query.GetComponent1(entity);
            ref Color color = ref Query.GetComponent2(entity);
            
            // Render entity at transform.Position with color
        }
    }
}
```

### Query-Based Processing

Process entities matching component signature:

```csharp
public class Query<T1, T2> where T1 : struct where T2 : struct
{
    public GameObject[] Entities { get; }
    public FastestTable<T1> Table1 { get; }
    public FastestTable<T2> Table2 { get; }
    
    public T1 GetComponent1(GameObject entity);
    public T2 GetComponent2(GameObject entity);
}

// Query entities with Transform and Health components
Query<Transform, Health> query = new Query<Transform, Health>(scene);

foreach (var entity in query.Entities)
{
    ref Transform transform = ref query.GetComponent1(entity);
    ref Health health = ref query.GetComponent2(entity);
    
    // Process entity
}
```

### Update Cycle

Execute systems in update order:

```csharp
public class GameLoop
{
    private SystemBase[] _systems;
    
    public void Update(float deltaTime)
    {
        // Sort systems by UpdateTypeAttribute
        Array.Sort(_systems, (a, b) => 
            a.UpdateType.CompareTo(b.UpdateType));
        
        // Execute systems in order
        foreach (var system in _systems)
        {
            system.Update(deltaTime);
        }
    }
}

// Usage
GameLoop loop = new GameLoop();
loop.Update(deltaTime);
```

## UpdateTypeAttribute

Mark system update timing:

```csharp
public enum UpdateType
{
    LateUpdate,   // After all updates
    Update,       // Standard update
    FixedUpdate   // Fixed timestep physics
}

[UpdateType(UpdateType.FixedUpdate)]
public class PhysicsSystem : SystemBase
{
    public Query<Transform, Velocity> Query { get; }
    
    public override void Update()
    {
        // Physics calculations at fixed timestep
    }
}

[UpdateType(UpdateType.Update)]
public class MovementSystem : SystemBase
{
    public Query<Transform, Velocity> Query { get; }
    
    public override void Update()
    {
        // Movement calculations at variable timestep
    }
}
```

## System Lifecycle

### Create → Register → Update → Destroy

```csharp
// 1. Create systems
MovementSystem movement = new MovementSystem(scene);
RenderSystem render = new RenderSystem(scene);

// 2. Register systems with game loop
GameLoop loop = new GameLoop();
loop.RegisterSystem(movement);
loop.RegisterSystem(render);

// 3. Update cycle
loop.Update(deltaTime);

// 4. Cleanup
movement.Dispose();
render.Dispose();
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Query Creation** | O(n) archetype iteration |
| **Entity Iteration** | O(m) where m = matching entities |
| **Component Access** | O(1) FastestTable lookup |
| **System Update** | O(m × k) where k = component count |

## Related

- [[Query]] - Component-based entity filtering
- [[GameObject]] - Entity handle
- [[Archetype]] - Component type optimization
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[entity-component-system-ecs]] — ECS overview
- [[Rule]] — Component constraint
- [[ComponentEvent]] — Lifecycle events

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[handlers-index]] — Handler index
- [[events-index]] — Event system
- [[queries-index]] — Query system
- [[architecture-index]] — Patterns
