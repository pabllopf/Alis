# Words

tags:
  - domain,api,reference,documentation

## Overview

"Words" are fluent builder interfaces that configure entity properties. Each "word" is a method that returns a builder for chaining.

## Common Words

### IWithName<TBuilder, TArgument>

Sets the entity name.

```csharp
TBuilder WithName(TArgument name);
```

### IPosition2D<TBuilder, TArgument>

Sets 2D position.

```csharp
TBuilder WithPosition(TArgument x, TArgument y);
```

### IScale2D<TBuilder, TArgument>

Sets 2D scale.

```csharp
TBuilder WithScale(TArgument x, TArgument y);
```

### IWithColor<TBuilder, TArgument>

Sets color.

```csharp
TBuilder WithColor(TArgument r, TArgument g, TArgument b, TArgument a);
```

### IWithTag<TBuilder, TArgument>

Adds a tag.

```csharp
TBuilder WithTag(TArgument tag);
```

### IWithModel<TBuilder, TArgument>

Sets model path.

```csharp
TBuilder WithModel(TArgument path);
```

### IWithAudioClip<TBuilder, TArgument>

Sets audio clip.

```csharp
TBuilder WithAudioClip(TArgument path);
```

### IAdd<TBuilder, TComponent>

Adds a component type.

```csharp
TBuilder Add<TComponent>();
```

### IDelete<TBuilder>

Deletes entity.

```csharp
TBuilder Delete();
```

### IIsActive<TBuilder, TArgument>

Sets active state.

```csharp
TBuilder IsActive(TArgument active);
```

### IIs<TBuilder, TArgument>

Sets entity type.

```csharp
TBuilder Is(TArgument type);
```

## Special Words

### IDebug<TBuilder>

Enables debug mode.

```csharp
TBuilder Debug();
```

### IDebugColor<TBuilder, TArgument>

Sets debug color.

```csharp
TBuilder DebugColor(TArgument color);
```

### IManagerOf<TBuilder, TComponent>

Sets manager for component.

```csharp
TBuilder ManagerOf<TComponent>(TArgument manager);
```

### IManager<TBuilder, TComponent>

Sets component manager.

```csharp
TBuilder Manager<TComponent>(TArgument manager);
```

### IWindow<TBuilder>

Configures window.

```csharp
TBuilder Window();
```

### IScreenMode<TBuilder, TArgument>

Sets screen mode.

```csharp
TBuilder ScreenMode(TArgument mode);
```

### IVersion<TBuilder, TArgument>

Sets version.

```csharp
TBuilder Version(TArgument version);
```

### IConfiguration<TBuilder, TArgument>

Sets configuration.

```csharp
TBuilder Configuration(TArgument config);
```

### IStore<TBuilder, TArgument>

Sets store reference.

```csharp
TBuilder Store(TArgument store);
```

### IWorld<TBuilder, TArgument>

Sets world reference.

```csharp
TBuilder World(TArgument world);
```

### IProfile<TBuilder, TArgument>

Sets profile.

```csharp
TBuilder Profile(TArgument profile);
```

### IFile<TBuilder, TArgument>

Sets file path.

```csharp
TBuilder File(TArgument path);
```

### IAds<TBuilder, TArgument>

Configures ads.

```csharp
TBuilder Ads(TArgument ads);
```

### IAi<TBuilder, TArgument>

Configures AI.

```csharp
TBuilder Ai(TArgument ai);
```

### IInput<TBuilder, TArgument>

Configures input.

```csharp
TBuilder Input(TArgument input);
```

### ILogLevel<TBuilder, TArgument>

Sets log level.

```csharp
TBuilder LogLevel(TArgument level);
```

### IDescription<TBuilder, TArgument>

Sets description.

```csharp
TBuilder Description(TArgument desc);
```

### ISize<TBuilder, TArgument>

Sets size.

```csharp
TBuilder Size(TArgument size);
```

### ILinearVelocity<TBuilder, TArgument>

Sets linear velocity.

```csharp
TBuilder LinearVelocity(TArgument velocity);
```

### IAngularVelocity<TBuilder, TArgument>

Sets angular velocity.

```csharp
TBuilder AngularVelocity(TArgument velocity);
```

### IFixedRotation<TBuilder, TArgument>

Sets fixed rotation.

```csharp
TBuilder FixedRotation(TArgument rotation);
```

### IDepth<TBuilder, TArgument>

Sets depth.

```csharp
TBuilder Depth(TArgument depth);
```

### IIsStatic<TBuilder, TArgument>

Sets static flag.

```csharp
TBuilder IsStatic(TArgument isStatic);
```

### IIsTrigger<TBuilder, TArgument>

Sets trigger flag.

```csharp
TBuilder IsTrigger(TArgument isTrigger);
```

### ISetTexture<TBuilder, TArgument>

Sets texture.

```csharp
TBuilder SetTexture(TArgument texture);
```

### ISetAudioClip<TBuilder, TArgument>

Sets audio clip.

```csharp
TBuilder SetAudioClip(TArgument clip);
```

### IAddFrame<TBuilder, TArgument>

Adds frame.

```csharp
TBuilder AddFrame(TArgument frame);
```

### IBackground<TBuilder, TArgument>

Sets background.

```csharp
TBuilder Background(TArgument background);
```

### IAudio<TBuilder, TArgument>

Sets audio.

```csharp
TBuilder Audio(TArgument audio);
```

### IAudio<TBuilder, TArgument>

Configures audio settings.

```csharp
TBuilder Audio(TArgument audio);
```

### IManagerOf<TBuilder, TComponent>

Sets component manager.

```csharp
TBuilder ManagerOf<TComponent>(TArgument manager);
```

### IIsActive<TBuilder, TArgument>

Sets active state.

```csharp
TBuilder IsActive(TArgument active);
```

### IIs<TBuilder, TArgument>

Sets entity type.

```csharp
TBuilder Is(TArgument type);
```

### IName<TBuilder, TArgument>

Sets name (alias).

```csharp
TBuilder Name(TArgument name);
```

### ICreate<TBuilder>

Creates entity.

```csharp
TBuilder Create();
```

### IUpdate<TBuilder, TArgument>

Configures update.

```csharp
TBuilder Update(TArgument update);
```

### IWindow<TBuilder, TArgument>

Configures window.

```csharp
TBuilder Window(TArgument window);
```

### IProfile<TBuilder, TArgument>

Sets profile.

```csharp
TBuilder Profile(TArgument profile);
```

### IStore<TBuilder, TArgument>

Sets store.

```csharp
TBuilder Store(TArgument store);
```

### IWorld<TBuilder, TArgument>

Sets world.

```csharp
TBuilder World(TArgument world);
```

### IManager<TBuilder, TComponent>

Sets manager.

```csharp
TBuilder Manager<TComponent>(TArgument manager);
```

### IWithModel<TBuilder, TArgument>

Sets model.

```csharp
TBuilder WithModel(TArgument model);
```

### IWithColor<TBuilder, TArgument>

Sets color.

```csharp
TBuilder WithColor(TArgument color);
```

### IWith<TBuilder, TArgument>

Generic with method.

```csharp
TBuilder With(TArgument value);
```

## Usage Example

```csharp
var entity = Build.Entity()
    .WithName("Player")
    .WithPosition(0, 0)
    .WithScale(1f)
    .WithColor(1f, 1f, 1f, 1f)
    .WithTag("player")
    .WithTag("active")
    .WithModel("models/player.obj")
    .WithAudio("sounds/player.wav")
    .Debug()
    .DebugColor(Color.red)
    .IsActive(true)
    .Add<HealthComponent>()
    .Add<MovementComponent>()
    .Add<PlayerInput>()
    .Run();
```

## Related

- [[Fluent Builders]] - Builder pattern
- [[Words Index]] - All words
