---
title: Lifecycle Hooks
tags:
  - domain
  - api
  - reference
  - documentation

status: draft
---


## Overview

Lifecycle hooks are interfaces that define when component code executes during the entity lifecycle.

## Initialization

### IOnAwake

Called when entity is first created.

```csharp
public interface IOnAwake
{
    void OnAwake(IGameObject self);
}
```

**Usage:**
- Initialize component state
- Set up references
- Register for events

### IOnStart

Called on first frame after `OnAwake`.

```csharp
public interface IOnStart
{
    void OnStart(IGameObject self);
}
```

**Usage:**
- Start game logic
- Begin animations
- Initialize AI

## Update Loop

### IOnUpdate<T>

Per-frame update with optional parameters.

```csharp
public interface IOnUpdate<T1>
{
    void Update(IGameObject self, ref T1 arg1);
}

// Multiple parameters (up to 8)
public interface IOnUpdate<T1, T2, T3>
{
    void Update(IGameObject self, ref T1 arg1, ref T2 arg2, ref T3 arg3);
}
```

**Common signatures:**
- `IOnUpdate<float>` - With deltaTime
- `IOnUpdate<float, Vector2>` - With deltaTime + extra
- `IOnUpdate<float, Vector2, KeyCode>` - With deltaTime + input

**Usage:**
- Move entities
- Update animations
- Handle AI
- Process physics

### IOnFixedUpdate

Fixed timestep physics update.

```csharp
public interface IOnFixedUpdate
{
    void OnFixedUpdate(IGameObject self);
}
```

**Usage:**
- Physics calculations
- Collision resolution
- Fixed timestep logic

### IOnBeforeUpdate

Called before main update.

```csharp
public interface IOnBeforeUpdate
{
    void OnBeforeUpdate(IGameObject self);
}
```

**Usage:**
- Prepare state
- Cache values
- Validate conditions

### IOnAfterUpdate

Called after main update.

```csharp
public interface IOnAfterUpdate
{
    void OnAfterUpdate(IGameObject self);
}
```

**Usage:**
- Cleanup state
- Apply changes
- Log results

## Rendering

### IOnDraw

Main render hook.

```csharp
public interface IOnDraw
{
    void OnDraw(IGameObject self);
}
```

**Usage:**
- Draw sprites
- Render meshes
- Visual effects

### IOnBeforeDraw

Called before main draw.

```csharp
public interface IOnBeforeDraw
{
    void OnBeforeDraw(IGameObject self);
}
```

**Usage:**
- Set up transforms
- Prepare materials
- Enable blending

### IOnAfterDraw

Called after main draw.

```csharp
public interface IOnAfterDraw
{
    void OnAfterDraw(IGameObject self);
}
```

**Usage:**
- Cleanup materials
- Restore state
- Disable blending

## Collision

### IOnCollisionEnter

Called when collision starts.

```csharp
public interface IOnCollisionEnter
{
    void OnCollisionEnter(IGameObject self, IGameObject other);
}
```

**Usage:**
- Handle impact
- Trigger events
- Apply damage

### IOnCollisionExit

Called when collision ends.

```csharp
public interface IOnCollisionExit
{
    void OnCollisionExit(IGameObject self, IGameObject other);
}
```

**Usage:**
- Stop collision effects
- Reset state
- Remove triggers

## Input

### IOnPressKey

Called when key is pressed.

```csharp
public interface IOnPressKey
{
    void OnPressKey(IGameObject self, KeyCode key);
}
```

**Usage:**
- Handle input
- Trigger actions
- Start abilities

### IOnHoldKey

Called while key is held.

```csharp
public interface IOnHoldKey
{
    void OnHoldKey(IGameObject self, KeyCode key);
}
```

**Usage:**
- Continuous actions
- Charge abilities
- Hold interactions

### IOnReleaseKey

Called when key is released.

```csharp
public interface IOnReleaseKey
{
    void OnReleaseKey(IGameObject self, KeyCode key);
}
```

**Usage:**
- Stop actions
- Release charges
- End abilities

## Cleanup

### IOnDestroy

Called when entity is destroyed.

```csharp
public interface IOnDestroy
{
    void OnDestroy(IGameObject self);
}
```

**Usage:**
- Cleanup resources
- Unregister events
- Release handles

### IOnExit

Called when entity exits scene.

```csharp
public interface IOnExit
{
    void OnExit(IGameObject self);
}
```

**Usage:**
- Save state
- Cleanup scene
- Log exit

## Processing

### IOnProcessPendingChanges

Called to process pending changes.

```csharp
public interface IOnProcessPendingChanges
{
    void OnProcessPendingChanges(IGameObject self);
}
```

**Usage:**
- Apply queued changes
- Process updates
- Synchronize state

## Component Example

```csharp
public struct PlayerCharacter : IComponentBase,
    IOnAwake, IOnStart, IOnUpdate<float>,
    IOnCollisionEnter, IOnDestroy,
    IOnPressKey, IOnReleaseKey
{
    public float Health;
    public Vector2 Position;
    public float Speed;
    
    public void OnAwake(IGameObject self)
    {
        Health = 100f;
        Speed = 5f;
    }
    
    public void OnStart(IGameObject self)
    {
        // Start game logic
    }
    
    public void Update(IGameObject self, ref float deltaTime)
    {
        Position += Velocity * deltaTime;
    }
    
    public void OnCollisionEnter(IGameObject self, IGameObject other)
    {
        var otherHealth = other.Get<HealthComponent>();
        otherHealth.Health -= 10f;
    }
    
    public void OnPressKey(IGameObject self, KeyCode key)
    {
        if (key == KeyCode.Space)
        {
            Jump();
        }
    }
    
    public void OnDestroy(IGameObject self)
    {
        // Cleanup
    }
}
```

## Related

- [[Component System]] - Component architecture
- [[Lifecycle]] - All lifecycle methods
