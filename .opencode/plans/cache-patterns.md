# Alis - Code Patterns and Conventions

## Overview
This cache documents the architectural patterns, naming conventions, and code organization rules used throughout the Alis solution.

## Architectural Patterns

### Builder Pattern
**Location:** `2_Application/Alis/src/Builder/Core/Ecs/`

Used for constructing complex ECS entities and scenes with fluent configuration.

| Builder | Purpose |
|---------|---------|
| `GameObjectBuilder` | Construct game entities with components |
| `SceneBuilder` | Compose scenes with entities |
| `TransformBuilder` | Configure transform properties |
| `CameraBuilder` / `CameraConfig` | Configure camera settings |
| `SpriteBuilder` / `SpriteConfig` | Configure sprite rendering |
| `AnimatorBuilder` / `AnimatorConfig` | Configure animation controllers |
| `RigidBodyBuilder` | Configure physics bodies |
| `AudioSourceBuilder` | Configure audio sources |
| `LightBuilder` variants | Point, Directional, Spot, Area lights |
| `ColliderBuilder` variants | Circle, Box colliders |
| `VideoGameBuilder` | Configure game runtime |
| `SettingsBuilder` | Configure game settings |

**Setting Builders:** InputSettingBuilder, GeneralSettingBuilder, NetworkSettingBuilder, GraphicSettingBuilder, AudioSettingBuilder, PhysicSettingBuilder

### Manager Pattern
**Location:** `2_Application/Alis/src/Core/Ecs/Systems/Manager/`

All subsystem managers follow a common interface hierarchy.

| Manager | Purpose |
|---------|---------|
| `IManager` / `AManager` | Base manager interface and abstract class |
| `SceneManager` | Scene lifecycle management |
| `GraphicManager` | Rendering pipeline management |
| `AudioManager` | Audio playback and mixing |
| `PhysicManager` | Physics simulation management |
| `NetworkManager` | Network connection management |
| `TimeManager` | Game time control |
| `InputManager` | Input device management |

### Context/Scope Pattern
**Location:** `2_Application/Alis/src/Core/Ecs/Systems/Scope/`

Provides scoped execution contexts for systems.

| Type | Purpose |
|------|---------|
| `IContext` / `Context` | Execution context interface and implementation |
| `IContextHandler` / `ContextHandler` | Context lifecycle management |

### Runtime Pattern
**Location:** `2_Application/Alis/src/Core/Ecs/Systems/Execution/`

Game loop and execution control.

| Type | Purpose |
|------|---------|
| `IRuntime` / `InternalRuntime` | Game runtime interface and implementation |
| `IRunteable` | Interface for runteable components |

### Setting Pattern
**Location:** `2_Application/Alis/src/Core/Ecs/Systems/Configuration/`

Typed configuration for all subsystems.

| Setting | Interface | Sub-settings |
|---------|-----------|--------------|
| General | `ISetting` / `Setting` | GeneralSetting, IGeneralSetting |
| Audio | - | AudioSetting, IAudioSetting |
| Graphic | - | GraphicSetting, IGraphicSetting |
| Input | - | InputSetting, IInputSetting |
| Network | - | NetworkSetting, INetworkSetting |
| Physic | - | PhysicSetting, IPhysicSetting |
| Time | - | TimeSetting, ITimeSetting |

### Client/Server Pattern
**Location:** `1_Presentation/Extension/Network/src/`

Network extension implements a full client/server architecture.

| Component | Location |
|-----------|----------|
| Client | `Network/Client/` |
| Server | `Network/Server/` |
| Core protocols | `Network/Core/` |
| Internal implementation | `Network/Internal/` |

### Aspect-Oriented Pattern
**Location:** `5_Declaration/`, `6_Ideation/`

Cross-cutting concerns implemented as aspects with source generators.

| Aspect | Purpose |
|--------|---------|
| Data | Serialization, validation, data access |
| Fluent | Builder pattern code generation |
| Logging | Tracing, diagnostics |
| Math | Numeric utilities, vector/matrix ops |
| Memory | Allocation tracking, pooling |
| Time | Profiling, latency measurement |

## Naming Conventions

### Project Naming
| Prefix | Meaning | Example |
|--------|---------|---------|
| `Alis.App.*` | Application projects | Alis.App.Engine, Alis.App.Hub |
| `Alis.Extension.*` | Extension plugins | Alis.Extension.Network |
| `Alis.Core.*` | Core library modules | Alis.Core.Ecs |
| `Alis.Core.Aspect.*` | Aspect-oriented modules | Alis.Core.Aspect.Math |
| `Alis.Sample.*` | Sample/demo projects | Alis.Sample.Pong |
| `Alis.*.Generator` | Source generator projects | Alis.Core.Ecs.Generator |
| `Alis.*.Test` | Test projects | Alis.Core.Ecs.Test |

### Namespace Naming
| Convention | Example |
|------------|---------|
| Root namespace = Project name without "Alis." prefix | `Alis.Core.Ecs`, `Alis.Extension.Network` |
| Sub-namespaces follow directory structure | `Alis.Core.Ecs.Systems.Manager` |
| Generators use `.Generator` suffix | `Alis.Core.Ecs.Generator.Collections` |
| Samples use `Alis.Sample.*` | `Alis.Sample.Pong` |

### Type Naming
| Pattern | Convention | Example |
|---------|------------|---------|
| Interfaces | `I` prefix | `IManager`, `ISetting` |
| Abstract classes | `A` prefix | `AManager`, `AComponent` |
| Concrete classes | PascalCase | `SceneManager`, `VideoGame` |
| Builders | `{Type}Builder` | `GameObjectBuilder`, `SceneBuilder` |
| Configurations | `{Type}Config` or `{Type}Setting` | `CameraConfig`, `GraphicSetting` |
| Enums | PascalCase, members PascalCase | `GameObjectFlags` |
| Structs | PascalCase | `Vector2`, `Matrix4x4` |

### File Naming
- PascalCase for all .cs files
- One public type per file (generally)
- File name matches the primary type name
- Extension methods in `{Type}Extensions.cs`

## Code Organization Rules

### Layer Dependency Rule
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```
- Higher layers can reference lower layers
- Lower layers NEVER reference higher layers
- No cross-layer references within the same number

### Project Structure Pattern
Most library projects follow:
```
ProjectName/
├── src/          # Production code
├── test/         # Unit tests
├── sample/       # Usage examples
└── generator/    # Source generators (if applicable)
```

### Component Organization (ECS)
```
4_Operation/Ecs/src/
├── GameObject.cs           # Entity type
├── Scene.cs                # Scene container
├── Kernel/                 # Core ECS engine
│   ├── Archetypes/         # Archetype implementations
│   └── Events/             # Event system
├── Components/             # Component definitions
│   ├── Audio/
│   ├── Body/
│   ├── Collider/
│   ├── Light/
│   ├── Render/
│   └── Ui/
├── Systems/                # System implementations
│   ├── Configuration/      # Typed settings
│   ├── Execution/          # Runtime execution
│   ├── Manager/            # Subsystem managers
│   └── Scope/              # Context/scope management
├── Marshalling/            # Serialization
├── Updating/               # Update loop
│   └── Runners/            # Update strategies
└── Generator/              # Source generator code
```

### Extension Organization
```
1_Presentation/Extension/{Category}/{Name}/
├── src/
│   ├── {Name}Library.cs
│   └── ...
├── sample/
│   └── {Name}.Sample.csproj
└── test/
    └── {Name}.Test.csproj
```

## Architecture Decisions

### Why 6 Numbered Modules?
- **1_Presentation**: User-facing code (apps + plugins) - highest layer
- **2_Application**: Business logic and sample games - application layer
- **3_Structuration**: Core abstractions - structural foundation
- **4_Operation**: Concrete implementations (engine systems) - operational layer
- **5_Declaration**: Meta-programming aspects - declaration layer
- **6_Ideation**: Utility/math primitives - foundational layer

### Why So Many ECS Implementations?
The benchmark suite compares 10+ ECS backends for research-driven development. This evaluates performance characteristics to inform the optimal ECS architecture choice.

### Why src/sample/test Pattern?
- `src/` - Production code, shipped in NuGet packages
- `sample/` - Usage examples, demonstrates API usage
- `test/` - Unit tests, ensures correctness
- `generator/` - Source generators (4th tier for generator projects)

### Why Conditional Project References?
Config.props uses conditional project references based on:
- Layer directory (`ProjectDir.Contains('1_Presentation')`)
- Configuration (Debug vs Release)
- This enables modular builds where only relevant dependencies are included

### Why Source Generators?
- Compile-time code generation for performance-critical ECS code
- Type-safe API generation (fluent builders, data serializers)
- Zero runtime reflection overhead
- Generated code emitted to `obj/` and can be viewed with `EmitCompilerGeneratedFiles=true`

### Why Multi-Targeting?
- Support legacy .NET Framework 4.6.1+ for enterprise Windows apps
- Support .NET Core 2.0+ for cross-platform compatibility
- Support .NET 5-10 for latest performance improvements
- Support .NET Standard 2.0/2.1 for maximum library compatibility
