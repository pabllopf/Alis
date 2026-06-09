---
title: Alis.Core.Aspect.Fluent
tags: [ideation,aspect,library,documentation]
---


## Overview

The **Alis.Core.Aspect.Fluent** project provides a fluent API interface system for the ALIS game engine. It implements a chainable interface builder pattern using marker interfaces ("words" and "components") that compose to build game objects, scenes, and configurations.

## Purpose

- Provide a fluent builder API for game object creation
- Define component lifecycle hooks (awake, start, update, draw, etc.)
- Enable type-safe configuration through interface composition
- Support AOT (Ahead-of-Time) compilation with source generators

## Architecture

### Word Pattern

"Words" are marker interfaces that add capabilities to the fluent chain:

| Category | Examples |
|----------|----------|
| **Entity Properties** | IName, IDescription, IAuthor, IStyle, ILicense, IVersion, IIcon |
| **Transform** | IPosition2D, IScale2D, IRotation, IRelativePosition, IOrder, IDepth |
| **Physics** | IBodyType, IMass, IFriction, IRestitution, IDensity, IGravityScale |
| **Rendering** | IGraphic, IDepth, IDebug, IDebugColor, IBackground |
| **Audio** | IAudio, IVolume, ISpeed, IPlayOnAwake, ISetAudioClip |
| **Animation** | IAddAnimation, IAddFrame |
| **Components** | IAddComponent, IHas, IWith, IWithName, IWithTag |
| **Configuration** | IConfiguration, ISettings, IGeneral, IManager |
| **Scene** | IWorld, IWindow, IResolution, IScreenMode |
| **Input** | IInput, IIsActive, IIsResizable |
| **Query** | IWhere, IIs, IHas |

### Component Lifecycle

Component interfaces define lifecycle hooks:

| Hook | Description |
|------|-------------|
| `IOnAwake` | Called when component is awakened |
| `IOnStart` | Called before first update |
| `IOnUpdate` through `IOnUpdate.8` | Update loop interfaces (1x-8x speed variants) |
| `IOnFixedUpdate` | Fixed timestep update |
| `IOnBeforeUpdate` / `IOnAfterUpdate` | Pre/post update hooks |
| `IOnDraw` / `IOnBeforeDraw` / `IOnAfterDraw` | Rendering hooks |
| `IOnPhysicUpdate` | Physics update hook |
| `IOnInit` / `IOnExit` | Initialization hooks |
| `IOnDestroy` | Cleanup hook |
| `IOnCollisionEnter` / `IOnCollisionExit` | Collision events |
| `IOnPressKey` / `IOnHoldKey` / `IOnReleaseKey` | Input events |

### Builder Pattern

Core interfaces:

```csharp
public interface IBuild<TOrigin>
{
    TOrigin Build();
}

public interface IHasBuilder<out TOut>
{
    TOut Builder();
}
```

Usage:

```csharp
var player = new Builder()
    .WithName("player")
    .WithPosition2D(10, 20)
    .WithScale2D(2, 2)
    .AddComponent<IOnUpdate>()
    .Build();
```

## Files

| File | Count | Description |
|------|-------|-------------|
| IBuild.cs | 1 | Build interface |
| IHasBuilder.cs | 1 | Builder interface |
| Components/*.cs | ~38 | Lifecycle interfaces |
| Words/*.cs | ~80+ | Marker interfaces |
| plan.md | 1 | Architecture documentation |

## Dependencies

- **Microsoft.CodeAnalysis.CSharp** - Source generator (generator/ only)
- **Alis.Core.Ecs** - Implementation of interfaces

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance goals.

## Code Quality Issues

1. **Interface Explosion** - 80+ "word" interfaces + 38 component interfaces = 120+ files
2. **No Documentation** - Interfaces have minimal XML docs, no usage examples
3. **Naming Inconsistency** - Mix of verbs (IAdd), nouns (IName), and adjectives (IIs)
4. **Generic Parameter Proliferation** - IOnUpdate.1-8 and IAction.1-8 are code duplication
5. **No Interface Hierarchy** - All interfaces are flat with no grouping

## TODOs

- [ ] Namespace organization (Query, Transform, Physics, Rendering, Audio, etc.)
- [ ] Add XML documentation with usage examples
- [ ] Consolidate update/action variants (IOnUpdate.1-8 → single interface)
- [ ] Fluent chain documentation with samples
- [ ] Remove dead/orphaned interfaces
- [ ] Interface inheritance hierarchy (ITransformable, IPhysical, etc.)
- [ ] Code generation for word interfaces

## Related Projects

- [[Alis.Core.Ecs]] - Implementation of fluent interfaces
- [[Alis.Core.Aspect.Memory]] - Memory aspect system
- [[Alis.Core.Aspect.Fluent.Generator]] - Source generator for AOT compatibility
