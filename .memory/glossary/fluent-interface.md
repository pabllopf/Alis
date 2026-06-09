# Fluent Interface

## Definition

A **Fluent Interface** is a method chaining pattern that enables object configuration through a sequence of method calls, improving code readability and reducing boilerplate.

## Pattern in Alis

The Alis project extensively uses fluent interfaces for:

- Entity creation and configuration
- Component attachment
- System registration
- Resource management

## Example Usage

```csharp
// Fluent entity creation
var player = scene.Create()
    .With<Transform>(t => { t.X = 0; t.Y = 0; })
    .With<Health>(h => { h.Value = 100; })
    .With<Velocity>(v => { v.X = 5; });

// Fluent resource loading
var texture = AssetRegistry.LoadTexture("player.png")
    .WithName("PlayerSprite")
    .WithFilterMode(TextureFilterMode.Bilinear)
    .WithWrapMode(TextureWrapMode.Clamp);

// Fluent system registration
scene.RegisterSystem<MovementSystem>()
    .WithUpdateOrder(1)
    .WithPriority(High);
```

## Interface Naming Convention

Interfaces follow specific naming patterns:

| Prefix | Purpose | Example |
|--------|---------|---------|
| `I` | Base interface | `ITransform`, `IVelocity` |
| `IWith` | Add component | `IWith<Transform>`, `IWith<Health>` |
| `IHas` | Has property | `IHasBuilder`, `IHasContext` |
| `IOn` | Lifecycle event | `IOnUpdate`, `IOnDraw`, `IOnAwake` |
| `ISet` | Set value | `ISetTexture`, `ISetAudioClip` |
| `IAs` | Cast/convert | `IAs<Transform>` |

## Fluent Builder Pattern

### IHasBuilder

Base interface for fluent builders:

```csharp
public interface IHasBuilder<TBuilder> where TBuilder : IHasBuilder<TBuilder>
{
    TBuilder With<T>(in T component) where T : struct;
    TBuilder With<T1, T2>(in T1 c1, in T2 c2) where T1 : struct where T2 : struct;
    // ...
}
```

### Component Attachment

```csharp
public interface IAdd<T> : IHasBuilder<IAdd<T>>
{
    IAdd<T> Add(in T component);
}

public interface IWithTag<T> : IHasBuilder<IWithTag<T>> where T : struct
{
    IWithTag<T> Tag();
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Readability** | Clear intent through method chaining |
| **Type Safety** | Compile-time checking of valid operations |
| **Discoverability** | IntelliSense shows available methods |
| **Immutability** | Each method returns new builder instance |

## Related

- [[Builder Pattern]] - Object construction pattern
- [[Component]] - Data container
- [[GameObject]] - Entity handle
- [[entity-component-system-ecs]] — ECS overview
- [[ComponentStorage]] — Typed data storage
- [[event-t]] — Generic event handler

## Related Architecture

- [[Alis.Core.Aspect.Fluent]] — Fluent aspect project
- [[architecture-index]] — Patterns index
- [[apis-index]] — Public APIs
- [[naming-conventions]] — Interface naming
