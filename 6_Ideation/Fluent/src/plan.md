# Fluent Module Plan

## Overview

Fluent API interface system for the Alis game engine. Provides a chainable interface builder pattern using marker interfaces ("words" and "components") that compose to build game objects, scenes, and configurations.

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Fluent | `src/` | Library (net461-net9.0) | 130+ source files |
| Alis.Core.Aspect.Fluent.Generator | `generator/` | Source Generator | 1 file |
| Alis.Core.Aspect.Fluent.Sample | `sample/` | Console App | 3 files |
| Alis.Core.Aspect.Fluent.Test | `test/` | xUnit Tests | 50+ files |

## Source Files (src/)

### Core Interfaces
- `IBuild.cs` - `IBuild<TOrigin>` with Build() returning TOrigin
- `IHasBuilder.cs` - `IHasBuilder<out TOut>` with Builder() returning TOut
- `KeyEventInfo.cs` - Keyboard event information struct

### Components (38 files)
Lifecycle and action interfaces for ECS components:

- `IComponentBase.cs` - Base interface for all component interfaces
- `IGameObject.cs` - Game object reference
- `IAction.cs` through `IAction.8.cs` - Action interfaces with 1-8 generic parameters
- `IOnAwake.cs` - Called when component is awakened
- `IOnStart.cs` - Called before first update
- `IOnUpdate.cs` through `IOnUpdate.8.cs` - Update loop interfaces (9 variants)
- `IOnFixedUpdate.cs` - Fixed timestep update
- `IOnBeforeUpdate.cs` / `IOnAfterUpdate.cs` - Pre/post update hooks
- `IOnBeforeFixedUpdate.cs` / `IOnAfterFixedUpdate.cs` - Pre/post fixed update hooks
- `IOnDraw.cs` / `IOnBeforeDraw.cs` / `IOnAfterDraw.cs` - Rendering hooks
- `IOnPhysicUpdate.cs` - Physics update hook
- `IOnInit.cs` / `IOnExit.cs` - Initialization hooks
- `IOnDestroy.cs` - Cleanup hook
- `IOnCollisionEnter.cs` / `IOnCollisionExit.cs` - Collision events
- `IOnPressKey.cs` / `IOnHoldKey.cs` / `IOnReleaseKey.cs` - Input events
- `IOnProcessPendingChanges.cs` - Change processing hook

### Words (80+ files)
Marker interfaces for fluent API chaining. Each word adds a capability to the build chain:

**Entity properties**: IName, IDescription, IAuthor, IStyle, ILicense, IVersion, IIcon
**Transform**: IPosition2D, IScale2D, IRotation, IRelativePosition, IOrder, IDepth
**Physics**: IBodyType, IMass, IFriction, IRestitution, IDensity, IGravityScale, ILinearVelocity, IAngularVelocity, IFixedRotation, IIsDynamic, IIsStatic, IIsTrigger
**Rendering**: IGraphic, IDepth, IDebug, IDebugColor, IBackground, IBackgroundColor
**Audio**: IAudio, IVolume, ISpeed, IPlayOnAwake, ISetAudioClip
**Animation**: IAddAnimation, IAddFrame
**Components**: IAddComponent, IHas, IWith, IWithName, IWithTag, IWithColor, IWithModel
**Configuration**: IConfiguration, ISettings, IGeneral, IManager, IManagerOf
**Scene**: IWorld, IWindow, IResolution, IScreenMode, ISplashScreen
**Input**: IInput, IIsActive, IIsResizable
**Network**: INetwork
**Logging**: ILogLevel
**UI/Extras**: IAds, ICloud, IFile, IFilePath, IPlugin, IProfile, IStore
**Actions**: ICreate, IDelete, IUpdate, IRun, ISet, IAdd, IAddAnimation, IAddFrame
**Query**: IWhere, IIs, IHas
**AI**: IAi, IScript
**Camera**: ICamera (in Core.Ecs)

## Generator Files

### AotReflectionAnalyzer
- Roslyn analyzer for AOT compatibility checking
- Detects reflection usage that would break Native AOT publishing

## Dependencies

- **Internal**: None (leaf module)
- **External**: Microsoft.CodeAnalysis.CSharp (generator only)

## Architecture Notes

- Pure interface design: zero implementation code in src/
- "Word" pattern: each interface is a marker that composes with others via generic constraints
- Fluent chain: `new Builder().WithName("player").WithPosition2D(10, 20).Build()`
- Component lifecycle: 25+ lifecycle hooks covering awake, start, update, draw, physics, collision, input
- Update variants: IOnUpdate through IOnUpdate.8 support multiple update rates (1x-8x speed)
- Action variants: IAction through IAction.8 support 1-8 generic parameters for typed callbacks
- Generator produces AOT-compatible reflection code

## Code Quality Issues

1. **Interface explosion**: 80+ "word" interfaces + 38 component interfaces = 120+ files. Hard to navigate and discover.
2. **No documentation**: Interfaces have minimal XML docs. No examples of fluent chain usage.
3. **Naming inconsistency**: Some words use verbs (IAdd, ISet, IRun), others nouns (IName, IAudio), others adjectives (IIs, IIsActive).
4. **Generic parameter proliferation**: IOnUpdate.1 through IOnUpdate.8 and IAction.1 through IAction.8 are code duplication.
5. **No interface hierarchy**: All interfaces are flat with no grouping. IWhere and IIs should be under a Query namespace.
6. **Missing implementations**: src/ has zero implementations. All implementations are in 4_Operation/Ecs and 2_Application/Alis.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Namespace organization**: Group words into logical namespaces (Query, Transform, Physics, Rendering, Audio, Animation, Configuration, Input, Network, UI).
2. **Add XML documentation**: Every interface needs summary docs with usage examples.

### Priority 2 - Important
3. **Consolidate update/action variants**: Replace IOnUpdate.1-8 with a single `IOnUpdate { int Speed { get; } }` interface. Same for IAction.
4. **Fluent chain documentation**: Add a sample project demonstrating the full fluent API surface.
5. **Remove dead interfaces**: Audit which words are actually used vs orphaned.

### Priority 3 - Nice to have
6. **Interface inheritance hierarchy**: ITransformable { IPosition2D, IScale2D, IRotation }, IPhysical { IMass, IFriction, IGravityScale }, etc.
7. **Code generation for words**: Generate word interfaces from a single definition file to reduce boilerplate.
8. **Add fluent validation**: IValidatable interface for build-time validation of fluent chains.

## Test Coverage

- Tests for each word interface (INameTest, IPosition2DTest, etc.)
- Tests for each component interface (IOnAwakeTest, IOnUpdateTest, etc.)
- Builder tests and build tests
- Extensive parametrized configuration tests
