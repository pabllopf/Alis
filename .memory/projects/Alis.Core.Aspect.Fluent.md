---
title: Alis.Core.Aspect.Fluent
tags:
  - ideation
  - fluent
  - api
  - builder
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Fluent

**Layer:** 6_Ideation
**Path:** `6_Ideation/Fluent/src/Alis.Core.Aspect.Fluent.csproj`

## Purpose

Fluent API builder infrastructure for constructing game objects, components, and configurations using a type-safe, chainable interface pattern.

## Structure

### Core Interfaces
- `IBuild` — Build execution marker
- `IHasBuilder` — Builder ownership

### Component Interfaces (38 files)
Action, Game object lifecycle hooks:
- `IAction` (8 overloads for arity) — Generic action component
- `IComponentBase` — Base component
- `IGameObject` — Game object
- `IOnAwake`, `IOnStart`, `IOnUpdate` (8 overloads), `IOnDestroy`, `IOnDraw`
- `IOnCollisionEnter`, `IOnCollisionExit`
- `IOnFixedUpdate`, `IOnPhysicUpdate`
- `IOnPressKey`, `IOnHoldKey`, `IOnReleaseKey`
- `IOnBeforeDraw`, `IOnAfterDraw`
- `IOnBeforeUpdate`, `IOnAfterUpdate`
- `IOnBeforeFixedUpdate`, `IOnAfterFixedUpdate`
- `IOnInit`, `IOnExit`, `IOnProcessPendingChanges`

### Word Interfaces (85 files)
Domain-specific language words for configuration:
- `ICreate`, `IAdd`, `ISet`, `IWith`, `IHas`, `IWhere`
- `IName`, `IIcon`, `IDescription`, `IVersion`, `IAuthor`, `ILicense`
- `IPosition2D`, `IRotation`, `IScale2D`, `ITransform`
- `IAudio`, `IGraphic`, `IPhysic`, `INetwork`, `IInput`
- `IBackground`, `IBackgroundColor`, `IDebug`, `IDebugColor`
- `IConfiguration`, `ISettings`, `IGeneral`, `IWorld`
- `IWindow`, `IResolution`, `IScreenMode`, `IStyle`, `IOrder`
- And many more domain-specific words

### Miscellaneous
- `KeyEventInfo` — Input event data

## Source Generator

**Path:** `6_Ideation/Fluent/generator/`

- `AotReflectionAnalyzer` — AOT-compatible reflection analysis for fluent builder resolution

## Dependencies

None (leaf layer)

## Testing

**Path:** `6_Ideation/Fluent/test/`

75 test files covering all component and word interface implementations.

## Observations

- Extremely large interface surface (105+ interfaces)
- High test coverage with per-interface unit tests
- Some interfaces may be redundant (e.g., `IOnUpdate` with 8 overloads)

## Related Documents

- [[Alis.Core.Aspect]]
- [[architecture-overview]]
- [[Alis.Core.Aspect.Data]]
