# Alis — Layer 2: Application (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `2_Application/`
- **Total .cs files**: ~177 (src: 88, test: 2, other: 87 [samples + builder code])
- **Total projects**: 30 (1 core app + 1 test + 28–30 sample game projects)
- **Build target**: `net10.0` for samples, `net8.0` for test, multi-targeting (via Config.props) for core lib
- **Outputs**: Library (Alis.csproj), EXE (samples)

## Core Application

| Project | Path | TF | Description |
|---------|------|----|-------------|
| Alis | `2_Application/Alis/src/` | multi (Config.props) | Main game runtime — core ECS components, systems, managers, builders. This is the central package everyone depends on. |
| Alis.Test | `2_Application/Alis/test/` | net8.0 | Core app tests | 2 test files |

### Alis.csproj Structure (163+ files in src/)

```
Alis/src/
├── Builder/
│   └── Core/Ecs/
│       ├── Entity/          — GameObjectBuilder, TransformBuilder, SceneBuilder
│       ├── Components/
│       │   ├── Audio/       — AudioSourceBuilder
│       │   ├── Body/        — RigidBodyBuilder
│       │   ├── Collider/    — CircleColliderBuilder, BoxColliderBuilder
│       │   ├── Light/       — PointLightBuilder, DirectionalLightBuilder, SpotLightBuilder, AreaLightBuilder
│       │   ├── Render/      — SpriteBuilder, FrameBuilder
│       │   └── Ui/          — CanvasBuilder
│       └── System/
│           ├── ConfigurationBuilders/    — Audio/General/Graphic/Input/Network/Physic/Time Setting Builders
│           ├── ManagerBuilders/         — SceneManagerBuilder
│           └── Scene/                   — Scene config builders
├── Core/
│   └── Ecs/
│       ├── Components/
│       │   ├── Audio/     — AudioSource component info
│       │   ├── Body/      — RigidBody component
│       │   ├── Collider/  — BoxCollider, CircleCollider
│       │   ├── Light/     — PointLight, DirectionalLight, SpotLight, AreaLight
│       │   ├── Render/    — Sprite, Frame, Canvas
│       │   └── Ui/        — UI components
│       └── Systems/
│           ├── Audio/       — Audio system
│           ├── Configuration/  — Settings: Audio, General, Graphic, Input, Network, Physic, Time
│           ├── Execution/     — IRuntime, InternalRuntime, IRunteable
│           ├── Manager/       — AManager, IManager, SceneManager, ScenesMap, GraphicManager, AudioManager, PhysicManager, NetworkManager, TimeManager, InputManager
│           └── Scope/         — IContext, Context, IContextHandler, ContextHandler
└── Core/Ecs/Systems/VideoGame.cs    — Main game runtime entry point
```

## Sample Games (13 games, 28–30 projects)

### Desktop + Web Games (12 games, 24 projects)

| Game | Desktop Project | Web Project | Notes |
|------|----------------|-------------|-------|
| Asteroid | `alis.sample.asteroid/desktop/` | `alis.sample.asteroid/web/` | Also has Android + iOS |
| Dino | `alis.sample.dino/desktop/` | `alis.sample.dino/web/` | |
| Egg | `alis.sample.egg/desktop/` | `alis.sample.egg/web/` | |
| Empty | `alis.sample.empty/desktop/` | `alis.sample.empty/web/` | |
| Flappy.Bird | `alis.sample.flappy.bird/desktop/` | `alis.sample.flappy.bird/web/` | |
| Inefable | `alis.sample.inefable/desktop/` | `alis.sample.inefable/web/` | |
| King.Platform | `alis.sample.king.platform/desktop/` | `alis.sample.king.platform/web/` | |
| Pong | `alis.sample.pong/desktop/` | `alis.sample.pong/web/` | |
| Rogue | `alis.sample.rogue/desktop/` | `alis.sample.rogue/web/` | |
| RuinsOfTartarus | `alis.sample.ruinsoftartarus/desktop/` | `alis.sample.ruinsoftartarus/web/` | |
| Snake | `alis.sample.snake/desktop/` | `alis.sample.snake/web/` | |
| Space.Simulator | `alis.sample.space.simulator/desktop/` | `alis.sample.space.simulator/web/` | |
| SplitCamera | `alis.sample.splitcamera/desktop/` | `alis.sample.splitcamera/web/` | |

### Mobile Games (1 game, 2 additional projects)

| Game | Android | iOS |
|------|---------|-----|
| Asteroid | `alis.sample.asteroid/android/Alis.Sample.Asteroid.Android.csproj` | `alis.sample.asteroid/ios/Alis.Sample.Asteroid.IOS.csproj` |

**Android**: `net10.0-android` + `net10.0` multi-target
**iOS**: `net10.0-ios`, multi-target with `net10.0-android;net10.0`

### Web vs Desktop Difference

| Platform | Target Framework | Key Package |
|----------|-----------------|-------------|
| Desktop | `net10.0` | Full platform deps (Graphic.Sdl2/Sfml/Glfw + 4_Operation modules) |
| Web | `net10.0` | `CoroutineScheduler 0.3.0` instead of full platform graphics stack |

### Sample Game .csproj Pattern

Desktop samples reference:
- `Alis.csproj` (main app)
- Graphic extension (Sdl2/Sfml/Glfw — which one varies)
- 4_Operation modules (Ecs, Audio, Graphic, Physic)
- 3_Structuration/Core
- 5_Declaration/Aspect

Web samples reference:
- `Alis.csproj` only
- `CoroutineScheduler 0.3.0` for WASM-compatible async

## Key Types in Alis Core App

### Components
- **Render**: `Sprite`, `Frame`, `Canvas`
- **Body**: `RigidBody`
- **Collider**: `BoxCollider`, `CircleCollider`
- **Light**: `PointLight`, `DirectionalLight`, `SpotLight`, `AreaLight`
- **Audio**: `AudioSource`
- **Transform**: `Transform`
- **Animation**: `Animation`, `Animator`
- **Camera**: `Camera`

### Systems/Managers
- `VideoGame` — Main game runtime, entry point via `VideoGame.Create().Run()`
- `IGame` — Game interface
- `InternalRuntime` / `IRuntime` — Runtime execution
- `IRunteable` — Runnable interface

**Managers**: `AManager` (base), `IManager`, `SceneManager`, `ScenesMap`, `GraphicManager`, `AudioManager`, `PhysicManager`, `NetworkManager`, `TimeManager`, `InputManager`

### Configuration
- `Setting` / `ISetting` — Settings base
- `GeneralSetting` / `IGeneralSetting`
- `AudioSetting` / `IAudioSetting`
- `GraphicSetting` / `IGraphicSetting`
- `InputSetting` / `IInputSetting`
- `NetworkSetting` / `INetworkSetting`
- `PhysicSetting` / `IPhysicSetting`
- `TimeSetting` / `ITimeSetting`

### Scope/Context
- `IContext`, `Context`
- `IContextHandler`, `ContextHandler`

## Size by Sample Directory (.cs in src/)

| Directory | Files |
|-----------|-------|
| Alis/src (core app) | 88 |
| Alis/test | 2 |
| Samples (combined, all games) | ~87 |

## Build Notes

- Samples use the same `Config.props` import as core lib
- Web samples exclude platform-specific graphic extensions
- Each sample game is a self-contained executable
- Desktop samples pull in the full engine stack
- Asteroid is the flagship sample (only one with Android/iOS)
