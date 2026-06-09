# Component

tags:
  - glossary,terminology,reference

## Definition

A **Component** is a data-only struct attached to entities in the ECS architecture. Components contain no logic, no inheritance, and no methods—they are pure data containers processed by [[System]] instances.

## Characteristics

### Pure Data

```csharp
public struct Transform
{
    public float X, Y, Z;
}

public struct Velocity
{
    public float X, Y, Z;
}

public struct Health
{
    public int Value;
    public int MaxValue;
}
```

### No Logic

- No methods (except constructors)
- No inheritance
- No virtual calls
- No polymorphism

### Value Types

- Struct-based for cache efficiency
- Zero-copy access via `Ref<T>`
- Stored contiguously by type

## Component Lifecycle

### Registration

Components are automatically registered when attached to entities:

```csharp
var player = scene.Create(new Transform(), new Health());
// Component<Transform> and Component<Health> registered automatically
```

### Access

```csharp
// Get reference (throws if not present)
ref Transform t = ref player.Get<Transform>();

// Try get (safe, returns default if not present)
Ref<Transform> refT = player.TryGetCore<Transform>(out bool exists);

// Add component
player.Add(new Velocity { X = 5 });

// Remove component
player.Remove<Transform>();
```

### Storage

Components stored in [[Component Storage]] instances:

- Type-specific arrays
- Contiguous memory for cache efficiency
- Indexed by entity location

## Component Attributes

### Update Type Attribute

```csharp
[UpdateType(typeof(FixedUpdate))]
public class MovementSystem : IComponentUpdateFilter
{
    public void Update(ref Transform t, ref Velocity v)
    {
        // Logic here
    }
}
```

### Component<T> Generic Class

Auto-generated for each component type:

- `Id` - Component identifier
- `Initer` - Initialization callback
- Storage management

## Component Events

- `ComponentAdded` - Fired when component added to entity
- `ComponentRemoved` - Fired when component removed from entity

## Performance

- **Memory**: Struct size × entity count
- **Cache**: Contiguous storage per type
- **Access**: Zero-copy via `Ref<T>`
- **AOT Safe**: No reflection, no dynamic code

## Related

- [[GameObject]] - Entity handle
- [[System]] - Logic processor
- [[Component Storage]] - Typed data storage
- [[Archetype]] - Component type optimization
- [[entity-component-system-ecs]] — ECS overview
- [[Scene]] — Entity container
- [[Query]] — Entity filtering
- [[ComponentEvent]] — Lifecycle events
- [[Ref<T>]] — Reference wrapper
- [[memory-management]] — Memory strategy

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[architecture-index]] — Patterns
- [[performance-index]] — Struct optimization
