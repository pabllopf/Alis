# Scene

## Definition

A **Scene** is the central container for all entities and systems in the ECS architecture. It manages entity lifecycle, component storage, archetype optimization, and system execution.

## Core Responsibilities

### Entity Management

- Create entities with components: `scene.Create(new Transform(), new Health())`
- Delete entities and recycle IDs
- Track entity versions for safe deletion handling
- Manage entity table lookups

### Component Storage

- Organize components by type into [[Component Storage]] instances
- Optimize memory layout via [[Archetype]] structures
- Provide fast component access via `Ref<T>` wrappers

### System Execution

- Update systems by attribute: `scene.Update<FixedUpdate>()`
- Execute component-specific updates: `scene.UpdateComponent<T>()`
- Manage structural change safety during update cycles

### Query Processing

- Create custom queries: `scene.CreateQuery(Rule.With<Transform>().And<Health>())`
- Cache query results by hash
- Attach/detach archetypes dynamically

## Key Properties

| Property | Type | Description |
|----------|------|-------------|
| `Id` | `ushort` | Unique scene identifier |
| `EntityCount` | `int` | Current entity count |
| `AllowStructualChanges` | `bool` | Structural change safety flag |
| `DefaultArchetype` | `Archetype` | Zero-component archetype |
| `EntityTable` | `FastestTable<GameObjectLocation>` | Entity lookup table |

## Update Cycle

```csharp
// Enter update state (disallow structural changes)
scene.EnterDisallowState();

try
{
    // Update all systems
    scene.Update();
    
    // Update specific component type
    scene.UpdateComponent<Transform>();
}
finally
{
    // Exit update state, apply deferred changes
    scene.ExitDisallowState();
}
```

## Deferred Structural Changes

When structural changes occur during update:

1. Changes queued in [[WorldUpdateCommandBuffer]]
2. Applied after current update completes
3. Recursion limit: 200 operations

## Events

- `EntityCreated` - Fired when entity created
- `EntityDeleted` - Fired when entity deleted
- `ComponentAdded` - Fired when component added
- `ComponentRemoved` - Fired when component removed

## Related

- [[GameObject]] - Entity handle
- [[Archetype]] - Component type optimization
- [[Query]] - Entity filtering
- [[System]] - Logic processor
