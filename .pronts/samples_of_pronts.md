# Alis Solution - Architecture Documentation

## OVERVIEW

**Alis** is a comprehensive C# ECS (Entity Component System) game engine framework with 142 projects, 6,253 .cs files, and ~15GB of codebase.

It provides:
- Multiple ECS backends (custom + Arch, DefaultEcs, Flecs.NET, HypEcs, Morpeh, Svelto.ECS, Friflo.Engine.ECS, etc.)
- Cross-platform support (Desktop, Web, Android, iOS)
- Rich extension ecosystem (Ads, Cloud, Graphic, Network, Media, etc.)
- Procedural generation, physics engine, audio system
- Benchmarking suite comparing 10+ ECS implementations

## SOLUTION FILES

| File | Purpose |
|------|---------|
| `alis.sln` | Main solution (all projects) |
| `Alis.slnx` | New-style solution format |
| `alis_benchmarks.sln` | Benchmark-only solution |
| `alis_design.sln` | Design-time solution |
| `.config/default.sln` | Default configuration |

## DIRECTORY STRUCTURE (6 Modules)

```
Alis/
├── 1_Presentation/   (71 csproj, 3,330 cs)  - Apps + Extensions
├── 2_Application/    (30 csproj, 485 cs)     - Main app + samples
├── 3_Structuration/  (3 csproj, 264 cs)      - Core ECS foundation
├── 4_Operation/      (14 csproj, 1,264 cs)   - Engine systems
├── 5_Declaration/    (3 csproj, 59 cs)       - Aspect declarations
└── 6_Ideation/       (21 csproj, 851 cs)     - Utility aspects
```

## ARCHITECTURAL LAYERS

### Layer 1: Presentation (1_Presentation)
**Purpose:** User-facing applications and extensibility plugins

#### Applications
| Project | Namespace | Files | Description |
|---------|-----------|-------|-------------|
| Alis.App.Engine | Alis.App.Engine | ~500+ | Main game engine runtime app with windows, menus, demos, shaders |
| Alis.App.Engine.Test | - | Tests | Engine application tests |
| Alis.App.Hub | Alis.App.Hub | ~200+ | Hub application for managing games/projects |
| Alis.App.Hub.Test | - | Tests | Hub tests |
| Alis.App.Agent | Alis.App.Agent | Agent | AI agent application |
| Alis.App.Agent.Query | Alis.App.Query | Query | Agent query interface |
| Alis.App.Installer | Alis.App.Installer | Installer | Application installer |
| Alis.Benchmark | Alis.Benchmark | ~215 | Benchmark suite comparing ECS implementations |

#### Extensions (25+ extensions, each with src/sample/test)
| Category | Extensions |
|----------|-----------|
| **Ads** | GoogleAds |
| **Cloud** | DropBox, GoogleDrive |
| **Graphic** | Glfw, Sdl2, Sfml, Ui |
| **Io** | FileDialog |
| **Language** | Dialogue, Translator |
| **Math** | HighSpeedPriorityQueue, ProceduralDungeon |
| **Media** | FFmpeg |
| **Network** | Client/Server architecture with samples |
| **Payment** | Stripe |
| **Profile** | Full profiling system |
| **Security** | Security utilities |
| **Thread** | Thread pooling, scheduling, strategies |
| **Updater** | Auto-updater service |

### Layer 2: Application (2_Application)
**Purpose:** Main application logic and sample games

#### Core
- **Alis.csproj** - Main application entry point (~163 files)
  - `Builder/Core/Ecs/Entity/` - GameObject, Scene, Transform builders
  - `Builder/Core/Ecs/Components/` - Render, Body, Collider, Audio, Light builders
  - `Builder/Core/Ecs/System/` - VideoGame, Settings builders
  - `Core/Ecs/Components/` - Info, Transform, Sprite, Camera, Animation, Animator
  - `Core/Ecs/Systems/` - VideoGame runtime, Managers (Scene, Graphic, Audio, Physic, Network, Time)
  - `Core/Ecs/Systems/Configuration/` - Settings interfaces and implementations

#### Sample Games (13 games × 2-3 platforms = 28 projects)
| Game | Platforms |
|------|-----------|
| Asteroid | Desktop, Web, Android, IOS |
| Dino | Desktop, Web |
| Egg | Desktop, Web |
| Empty | Desktop, Web |
| Flappy.Bird | Desktop, Web |
| Inefable | Desktop, Web |
| King.Platform | Desktop, Web |
| Pong | Desktop, Web |
| Rogue | Desktop, Web |
| RuinsOfTartarus | Desktop, Web |
| Snake | Desktop, Web |
| Space.Simulator | Desktop, Web |
| SplitCamera | Desktop, Web |

### Layer 3: Structuration (3_Structuration)
**Purpose:** Core ECS foundation

- **Alis.Core.csproj** - Core ECS abstractions (~264 files in obj included)
  - Multi-target: net471, netstandard2.0, netstandard2.1, net5.0-net9.0

### Layer 4: Operation (4_Operation)
**Purpose:** Game engine operational systems

| System | Project | Files | Description |
|--------|---------|-------|-------------|
| **ECS** | Alis.Core.Ecs | ~155 | Core ECS implementation with archetypes, events, marshalling |
| **ECS Generator** | Alis.Core.Ecs.Generator | Source gen | ECS code generation |
| **Audio** | Alis.Core.Audio | ~56 | Audio system with interfaces and players |
| **Graphic** | Alis.Core.Graphic | ~195 | OpenGL-based rendering with platform backends |
| **Graphic Generator** | Alis.Core.Graphic.Generator | Source gen | Graphic code generation |
| **Physic** | Alis.Core.Physic | ~239 | Physics engine with collisions, joints, contacts |

#### Physic Subsystem
- Collisions (Shapes: Circle, Box, Polygon)
- Convex Hull computation
- Polygon decomposition (CDT, Delaunay triangulation, Seidel)
- Dynamics (Contacts, Joints)
- Controllers

### Layer 5: Declaration (5_Declaration)
**Purpose:** Aspect-oriented programming declarations

- **Alis.Core.Aspect.csproj** - Meta-programming aspects
  - Data serialization aspects
  - Fluent API aspects

### Layer 6: Ideation (6_Ideation)
**Purpose:** Utility aspects and mathematical foundations

| Aspect | Project | Files | Description |
|--------|---------|-------|-------------|
| **Data** | Alis.Core.Aspect.Data | ~68 | JSON serialization/deserialization with generators |
| **Fluent** | Alis.Core.Aspect.Fluent | ~178 | Fluent API builder with source generator |
| **Logging** | Alis.Core.Aspect.Logging | ~74 | Logging framework with filters, formatters, outputs |
| **Math** | Alis.Core.Aspect.Math | ~79 | Math primitives: Vector, Matrix, Shapes (Circle, Line, Point, Rectangle, Square) |
| **Memory** | Alis.Core.Aspect.Memory | ~53 | Memory management with generators |
| **Time** | Alis.Core.Aspect.Time | ~51 | Time management utilities |

Each Ideation aspect follows the pattern: `src` + `generator` + `sample` + `test`

## DEPENDENCY GRAPH

```
1_Presentation/Engine ──┐
1_Presentation/Hub      │
1_Presentation/Agent    │
1_Presentation/Installer├──→ 2_Application/Alis (main app)
1_Presentation/Benchmark│      │
                          │      ↓
1_Presentation/Extension/* ──→ 3_Structuration/Core
                          │      ↑
4_Operation/Ecs ──────────┼──────┘
4_Operation/Audio ────────┤
4_Operation/Graphic ──────┤
4_Operation/Physic ───────┤
                          │
5_Declaration/Aspect ─────┘
                          │
6_Ideation/* ─────────────┘
```

### Key Dependencies
- **Engine** depends on: Graphic.Ui, Io.FileDialog, Updater, Alis (app core)
- **Alis (app)** depends on: Core ECS systems, all Operation modules
- **Extensions** depend on: Alis core, Operation modules
- **Benchmarks** reference: 10+ ECS implementations for comparison

## ECS ECOSYSTEM

The solution benchmarks and integrates these ECS implementations:

| ECS Library | Purpose |
|-------------|---------|
| **Alis.Core.Ecs** | Custom ECS (primary) |
| Arch | High-performance ECS |
| DefaultEcs | Data-oriented ECS |
| Flecs.NET | Flecs port for .NET |
| Friflo.Engine.ECS | Fast ECS |
| HypEcs | Lightweight ECS |
| Scellecs.Morpeh | Morpeh ECS |
| Svelto.ECS | Enterprise ECS |
| myECS | Simple ECS |
| fennecs | Fast ECS |

## NUGET DEPENDENCIES

### Source Generators
- Microsoft.CodeAnalysis.CSharp
- Microsoft.CodeAnalysis.Analyzers

### Testing
- xunit, xunit.runner.visualstudio
- Moq
- Microsoft.NET.Test.Sdk
- Xunit.StaFact

### Benchmarking
- BenchmarkDotNet

### External SDKs
- Google.Apis.Drive.v3
- Dropbox.Api
- Stripe.net
- MonoGame.Framework.DesktopGL

### Code Analysis
- Roslynator.Analyzers
- Roslynator.CodeAnalysis.Analyzers
- Roslynator.Formatting.Analyzers
- Microsoft.CodeAnalysis.NetAnalyzers

## BUILD CONFIGURATION

### Shared Props (`Directory.Build.props`)
- AssemblyVersion: 1.0.6
- EmitCompilerGeneratedFiles: true
- VSTestLogger: trx
- Test output: `.test/$(TargetFramework)/`

### Config Profiles (`.config/default/`)
- `default_csproj.props` - Standard library
- `default_app_csproj.props` - Application projects
- `default_test_csproj.props` - Test projects
- `default_sample_csproj.props` - Sample projects
- `default_generator_csproj.props` - Source generators
- `default_sample_web_csproj.props` - Web samples
- `default_sample_android_csproj.props` - Android samples
- `default_sample_ios_csproj.props` - iOS samples

### Target File (`.config/target/alis.targets`)
- Custom build targets for the solution

## TARGET FRAMEWORKS

Multi-targeting across:
- .NET Framework 4.7.1
- .NET Standard 2.0, 2.1
- .NET Core 2.0, 2.1, 3.0
- .NET 5.0 through 9.0

## NAMING CONVENTIONS

| Prefix | Meaning |
|--------|---------|
| `Alis.App.*` | Application projects (UI, runtime) |
| `Alis.Extension.*` | Extension plugins |
| `Alis.Core.*` | Core library modules |
| `Alis.Core.Aspect.*` | Aspect-oriented modules |
| `Alis.Sample.*` | Sample/demo projects |
| `Alis.*.Generator` | Source generator projects |
| `Alis.*.Test` | Test projects |

## KEY PATTERNS

### Builder Pattern
Extensive use in `2_Application/Alis/src/Builder/` for:
- GameObject building
- Scene composition
- Component configuration
- System setup

### Manager Pattern
`Core/Ecs/Systems/Manager/` contains:
- SceneManager, GraphicManager, AudioManager, PhysicManager
- NetworkManager, TimeManager, InputManager

### Context/Scope Pattern
`Core/Ecs/Systems/Scope/` provides:
- IContext, Context, IContextHandler, ContextHandler

### Runtime Pattern
`Core/Ecs/Systems/Execution/` provides:
- IRuntime, InternalRuntime, IRunteable

### Setting Pattern
`Core/Ecs/Systems/Configuration/` provides:
- ISetting, Setting with typed sub-settings (Audio, Graphic, Input, etc.)
