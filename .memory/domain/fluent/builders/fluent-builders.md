---
title: Fluent Builders
tags:
  - domain
  - api
  - reference
  - documentation

status: Draft

license: GPLv3

---


## IBuild<T>

Terminal interface that constructs and returns the final object.

### Interface Definition

```csharp
public interface IBuild<out TOrigin>
{
    TOrigin Build();
}
```

### Purpose

- **Terminal operation**: Ends the fluent chain
- **Type-safe**: Returns specific type `TOrigin`
- **Validation**: Validates builder state before build

### Usage

```csharp
var entity = Build.Entity()
    .WithName("Player")
    .WithPosition(0, 0)
    .Add<HealthComponent>()
    .Build(); // Returns IGameObject
```

## IHasBuilder<T>

Provides access to the builder instance.

### Interface Definition

```csharp
public interface IHasBuilder<out TOut>
{
    TOut Builder();
}
```

### Purpose

- **Builder access**: Retrieve builder from configured state
- **Fluent continuation**: Continue building after partial configuration

## IRun

Terminal interface that executes the builder pipeline.

### Interface Definition

```csharp
public interface IRun
{
    void Run();
}
```

### Purpose

- **Execute pipeline**: Creates entity and registers components
- **Terminal operation**: Cannot be reused after `Run()`
- **Validation**: Validates all required components

### Usage

```csharp
// Fluent chain
var entity = Build.Entity()
    .WithName("Player")
    .WithPosition(0, 0)
    .Add<HealthComponent>()
    .Run(); // Terminal - entity created
```

## Builder Pattern

### Fluent Chain

```
Build.Entity()
  → IWithName<TBuilder, TArgument>
  → IPosition2D<TBuilder, float>
  → IScale2D<TBuilder, float>
  → IAdd<TBuilder, TComponent>
  → IRun<TBuilder>
```

### Builder Methods

| Method | Interface | Description |
|---|---|---|
| `WithName(name)` | `IWithName` | Set entity name |
| `WithPosition(x, y)` | `IPosition2D` | Set 2D position |
| `WithScale(scale)` | `IScale2D` | Set scale factor |
| `Add<TComponent>()` | `IAdd` | Add component type |
| `WithModel(path)` | `IWithModel` | Set model path |
| `WithColor(r, g, b, a)` | `IWithColor` | Set color |
| `WithTag(tag)` | `IWithTag` | Add tag |
| `WithAudio(path)` | `IAudio` | Set audio clip |

## Builder State

### Configuration

- **Name**: Entity identifier
- **Position**: 2D position vector
- **Scale**: Uniform scale factor
- **Color**: RGBA color
- **Tags**: String tags for queries
- **Model**: Model file path
- **Audio**: Audio clip path

### Component Registration

Components are registered during builder chain:

```csharp
.Add<HealthComponent>()
.Add<MovementComponent>()
.Add<AIComponent>()
```

### Validation

Before `Run()` or `Build()`:
- Required components checked
- Invalid state detected
- Configuration validated

## Builder Overloads

### IAction<T>

8 overloads for different argument counts:

```csharp
IAction<T1>
IAction<T1, T2>
IAction<T1, T2, T3>
// ... up to 8 parameters
```

### IOnUpdate<T>

8 overloads for update signatures:

```csharp
IOnUpdate<float>
IOnUpdate<float, Vector2>
IOnUpdate<float, Vector2, KeyCode>
// ... up to 8 parameters
```

## Related

- [[IBuild<T>]] - Build terminal
- [[IRun]] - Execute terminal
- [[Builder Pattern]] - Fluent builders
