---
title: Alis.Core.Aspect.Fluent
tags: [domain,api,reference,documentation]
---


## Overview

**Alis.Core.Aspect.Fluent** is a game entity component system with fluent builder patterns. It provides an AOT-compatible, reflection-free approach to entity-component architecture through interface-based contracts.

## Purpose

This project enables:
- Game entity management with O(1) component access
- Fluent builder patterns for entity creation
- Lifecycle hooks (Update, Draw, Collision, etc.)
- AOT-compatible component registration
- Zero-allocation component queries

## Architecture

### Core Interfaces

| Interface | Namespace | Purpose |
|---|---|---|
| `IComponentBase` | `Alis.Core.Aspect.Fluent.Components` | Marker interface for all components |
| `IGameObject` | `Alis.Core.Aspect.Fluent.Components` | Entity handle with component access |
| `IAction<T>` | `Alis.Core.Aspect.Fluent.Components` | Fluent action delegates |
| `IBuild<T>` | `Alis.Core.Aspect.Fluent` | Terminal build operation |
| `IRun` | `Alis.Core.Aspect.Fluent.Words` | Execute builder pipeline |

### Lifecycle Hooks

- `IOnAwake` - Entity initialization
- `IOnStart` - First frame after awake
- `IOnUpdate` - Per-frame update (8 overloads)
- `IOnFixedUpdate` - Physics update
- `IOnBeforeUpdate`, `IOnAfterUpdate` - Pre/post update
- `IOnDraw`, `IOnBeforeDraw`, `IOnAfterDraw` - Rendering hooks
- `IOnCollisionEnter`, `IOnCollisionExit` - Collision events
- `IOnDestroy` - Entity cleanup
- `IOnPressKey`, `IOnHoldKey`, `IOnReleaseKey` - Input handling

## Dependencies

```xml
<Import Project="$(SolutionDir).config/Config.props"/>
```

No external NuGet packages. Pure .NET Standard implementation.

## Target Frameworks

Multi-targeted to 15+ frameworks:
- .NET Standard 2.0-2.1
- .NET Core 2.0-3.1
- .NET 5.0-10.0
- .NET Framework 4.61-4.81

## AOT Compatibility

This library is specifically designed for AOT environments:

✅ **Allowed:**
- Interface-based contracts
- Marker interfaces (IComponentBase)
- Partial interfaces (IAction<T>)
- Struct components
- Ref returns

❌ **Forbidden:**
- System.Reflection.Emit
- Runtime IL generation
- DynamicMethod creation
- Runtime Type.GetMembers() reflection

## Usage Pattern

### Entity Creation

```csharp
// Fluent builder pattern
var entity = Build.Entity()
    .WithName("Player")
    .WithPosition(0, 0)
    .WithScale(1f)
    .Add<HealthComponent>()
    .Add<MovementComponent>()
    .Run();

// Access components
var health = entity.Get<HealthComponent>();
var movement = entity.Get<MovementComponent>();
```

### Component Definition

```csharp
// A component implements lifecycle hooks
public struct HealthComponent : IComponentBase, IOnUpdate<float>
{
    public float Value;
    public float MaxValue;
    
    public void Update(IGameObject self, ref float deltaTime)
    {
        // Regenerate health over time
        Value = Math.Min(Value + deltaTime, MaxValue);
    }
}

public struct MovementComponent : IComponentBase, IOnUpdate<float>
{
    public Vector2 Position;
    public Vector2 Velocity;
    
    public void Update(IGameObject self, ref float deltaTime)
    {
        Position += Velocity * deltaTime;
    }
}
```

### Input Handling

```csharp
public struct PlayerInput : IComponentBase, IOnPressKey, IOnReleaseKey
{
    public void OnPressKey(IGameObject self, KeyCode key)
    {
        // Handle key press
    }
    
    public void OnReleaseKey(IGameObject self, KeyCode key)
    {
        // Handle key release
    }
}
```

## File Structure

```
6_Ideation/Fluent/src/
├── IBuild.cs
├── IHasBuilder.cs
├── KeyEventInfo.cs
├── Components/
│   ├── IComponentBase.cs
│   ├── IGameObject.cs
│   ├── IAction.cs (partial, 1-8 args)
│   ├── IAction.2.cs - IAction.8.cs
│   ├── Lifecycle hooks (IOnAwake, IOnUpdate, etc.)
│   └── IOnProcessPendingChanges.cs
└── Words/
    ├── IRun.cs
    ├── IWithName.cs
    ├── IPosition2D.cs
    ├── IScale2D.cs
    ├── IAdd.cs
    ├── IDelete.cs
    └── 80+ more builder interfaces
```

## Fluent Builder Pattern

### Builder Chain

```
Build.Entity()
  .WithName("EntityName")           // IWithName
  .WithPosition(x, y)               // IPosition2D
  .WithScale(scale)                 // IScale2D
  .Add<HealthComponent>()           // IAdd
  .Add<MovementComponent>()         // IAdd
  .Run()                            // IRun (terminal)
```

### Terminal Operations

| Interface | Method | Purpose |
|---|---|---|
| `IBuild<T>` | `T Build()` | Build final object |
| `IRun` | `void Run()` | Execute pipeline |
| `IHasBuilder<T>` | `T Builder()` | Access builder |

## Component System

### Entity Management

`IGameObject` provides:
- O(1) component retrieval via `Get<T>()`
- Component presence checks via `Has<T>()`
- Safe component queries via `TryHas<T>()`
- Entity ID and version tracking

### Component Registration

Components implementing `IComponentBase` are auto-registered for AOT:

```csharp
// Marker interface triggers registration
public struct MyComponent : IComponentBase
{
    // Component logic
}
```

## Lifecycle Management

### Update Loop

8 overloads of `IOnUpdate<T>` support different signatures:

```csharp
IOnUpdate<float>           // With deltaTime
IOnUpdate<float, Vector2>  // With deltaTime + extra args
// ... up to 8 parameters
```

### Physics Updates

`IOnFixedUpdate` - Fixed timestep physics updates.

### Rendering

- `IOnDraw` - Main render hook
- `IOnBeforeDraw` - Pre-render preparation
- `IOnAfterDraw` - Post-render cleanup

### Collision Events

- `IOnCollisionEnter` - Collision start
- `IOnCollisionExit` - Collision end

## Error Handling

| Exception | Trigger |
|---|---|
| `InvalidOperationException` | Component not found |
| `ArgumentException` | Invalid builder state |
| `NullReferenceException` | Null entity reference |

## Performance Characteristics

- **Component Get**: O(1) - Direct lookup
- **Component Has**: O(1) - Hash check
- **Entity Creation**: O(n) - n = number of components
- **Update Loop**: O(m) - m = active components

## Multi-Overload Pattern

### IAction<T>

Partial interface with 8 overloads:

```csharp
IAction<T1>
IAction<T1, T2>
IAction<T1, T2, T3>
// ... up to 8 type parameters
```

### IOnUpdate<T>

8 overloads for different update signatures.

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Memory]] - Memory management
- [[Alis.Core.Aspect.Time]] - Time system
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU General Public License v3.0

## Author

Pablo Perdomo Falcón  
Web: https://www.pabllopf.dev/
