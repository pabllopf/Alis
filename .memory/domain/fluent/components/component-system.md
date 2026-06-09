# Components

tags:
  - domain,api,reference,documentation

## IComponentBase

Marker interface for all component interfaces in the fluent game entity system.

### Interface Definition

```csharp
public interface IComponentBase;
```

### Purpose

- **Marker-only**: No members, just a type tag
- **Auto-registration**: Components implementing this are registered for AOT
- **Type safety**: Compile-time component type checking

### Usage

```csharp
// A simple component
public struct HealthComponent : IComponentBase
{
    public float Value;
    public float MaxValue;
}

// A component with lifecycle
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

## IGameObject

Represents a game entity that owns components and provides access to them.

### Interface Definition

```csharp
public interface IGameObject
{
    ref T Get<T>();
    bool Has<T>();
    bool Has(Type type);
    bool TryHas<T>();
}
```

### Methods

| Method | Return | Description |
|---|---|---|
| `Get<T>()` | `ref T` | Get component by type (throws if missing) |
| `Has<T>()` | `bool` | Check component presence |
| `Has(Type)` | `bool` | Check component by runtime type |
| `TryHas<T>()` | `bool` | Safe presence check (no throw) |

### Entity Identity

- **ID**: Unique entity identifier
- **Version**: Counter for safe ID reuse after destruction
- **O(1) Access**: Direct component lookup

### Example

```csharp
var entity = /* ... */;

// Get component (throws if missing)
var health = entity.Get<HealthComponent>();

// Check presence
if (entity.Has<MovementComponent>())
{
    var movement = entity.Get<MovementComponent>();
}

// Safe check
if (entity.TryHas<AIComponent>())
{
    // Component exists
}
```

## IAction<T>

Fluent action delegate that operates on arguments.

### Partial Interface

8 overloads for different argument counts:

```csharp
IAction<T1>
IAction<T1, T2>
IAction<T1, T2, T3>
// ... up to IAction<T1, T2, T3, T4, T5, T6, T7, T8>
```

### Usage

```csharp
public struct DamageDealer : IAction<IGameObject>
{
    public float Damage;
    
    public void Run(ref IGameObject target)
    {
        var health = target.Get<HealthComponent>();
        health.Value -= Damage;
    }
}

// Execute
var action = new DamageDealer { Damage = 10f };
action.Run(ref targetEntity);
```

## Lifecycle Hooks

### IOnAwake

Called when entity is first created.

```csharp
public interface IOnAwake
{
    void OnAwake(IGameObject self);
}
```

### IOnStart

Called on first frame after `OnAwake`.

```csharp
public interface IOnStart
{
    void OnStart(IGameObject self);
}
```

### IOnUpdate<T>

Per-frame update with optional parameters.

```csharp
public interface IOnUpdate<T1>
{
    void Update(IGameObject self, ref T1 arg1);
}

// Multiple parameters supported (up to 8)
public interface IOnUpdate<T1, T2>
{
    void Update(IGameObject self, ref T1 arg1, ref T2 arg2);
}
```

### IOnFixedUpdate

Physics update with fixed timestep.

```csharp
public interface IOnFixedUpdate
{
    void OnFixedUpdate(IGameObject self);
}
```

### IOnBeforeUpdate / IOnAfterUpdate

Pre and post update hooks.

```csharp
public interface IOnBeforeUpdate
{
    void OnBeforeUpdate(IGameObject self);
}

public interface IOnAfterUpdate
{
    void OnAfterUpdate(IGameObject self);
}
```

### IOnDraw / IOnBeforeDraw / IOnAfterDraw

Rendering hooks.

```csharp
public interface IOnDraw
{
    void OnDraw(IGameObject self);
}

public interface IOnBeforeDraw
{
    void OnBeforeDraw(IGameObject self);
}

public interface IOnAfterDraw
{
    void OnAfterDraw(IGameObject self);
}
```

### IOnCollisionEnter / IOnCollisionExit

Collision event hooks.

```csharp
public interface IOnCollisionEnter
{
    void OnCollisionEnter(IGameObject self, IGameObject other);
}

public interface IOnCollisionExit
{
    void OnCollisionExit(IGameObject self, IGameobject other);
}
```

### IOnDestroy

Cleanup when entity is destroyed.

```csharp
public interface IOnDestroy
{
    void OnDestroy(IGameObject self);
}
```

### Input Hooks

```csharp
public interface IOnPressKey
{
    void OnPressKey(IGameObject self, KeyCode key);
}

public interface IOnHoldKey
{
    void OnHoldKey(IGameObject self, KeyCode key);
}

public interface IOnReleaseKey
{
    void OnReleaseKey(IGameObject self, KeyCode key);
}
```

## IOnProcessPendingChanges

Processes pending component changes.

```csharp
public interface IOnProcessPendingChanges
{
    void OnProcessPendingChanges(IGameObject self);
}
```

## Component Composition

Components can combine multiple interfaces:

```csharp
public struct PlayerCharacter : IComponentBase, 
    IOnAwake, IOnStart, IOnUpdate<float>,
    IOnCollisionEnter, IOnDestroy
{
    public float Health;
    public Vector2 Position;
    
    public void OnAwake(IGameObject self)
    {
        // Initialize
    }
    
    public void Update(IGameObject self, ref float deltaTime)
    {
        // Move
    }
    
    public void OnCollisionEnter(IGameObject self, IGameObject other)
    {
        // Handle collision
    }
}
```

## Related

- [[IGameObject]] - Entity interface
- [[IComponentBase]] - Base marker
- [[Lifecycle Hooks]] - All lifecycle methods
