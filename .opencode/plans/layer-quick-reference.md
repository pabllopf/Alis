# Alis — Layer Quick Reference

## "I want to find X" — Where to Look

| You're looking for... | Go to... |
|----------------------|----------|
| Entity/Component/System runtime | `4_Operation/Ecs/src/` |
| Physics engine | `4_Operation/Physic/src/` |
| Graphics rendering + OpenGL | `4_Operation/Graphic/src/` + `1_Presentation/Extension/Graphic/*/src/` |
| Audio system | `4_Operation/Audio/src/` |
| Main game runtime + components | `2_Application/Alis/src/Core/Ecs/` |
| Sample games | `2_Application/Alis/samples/alis.sample.*/` |
| UI framework | `1_Presentation/Extension/Graphic/Ui/src/` |
| Network client/server | `1_Presentation/Extension/Network/src/` |
| Math primitives (Vector, Matrix, Shapes) | `6_Ideation/Math/src/` |
| Logging | `6_Ideation/Logging/src/` |
| Fluent API builders | `6_Ideation/Fluent/src/` + `2_Application/Alis/src/Builder/` |
| Data/JSON serialization | `6_Ideation/Data/src/` |
| Thread pool / scheduling | `1_Presentation/Extension/Thread/src/` |
| Source generators | `4_Operation/Ecs/generator/`, `4_Operation/Graphic/generator/`, `6_Ideation/*/generator/` |
| Benchmarks | `1_Presentation/Benchmark/src/` |
| Extensions | `1_Presentation/Extension/*/src/` |
| App entry points | `1_Presentation/{Engine,Hub,Agent,Installer}/src/Program.cs` |
| Test files | `*.Test/` folders or `*/*/test/` |

## "I want to modify X" — Quick Steps

1. Find the module in `solution-inventory.md`
2. Check dependencies (below) — don't break downward-only rule
3. Target the right `.slnx` to keep solution scope tight
4. Make changes locally, run `dotnet build <slnx>`
5. Run tests for that layer: `dotnet test --filter "FullyQualifiedName~<module>"`

## Dependency Rules (STRICT — downward only)

| Module | Can reference... | Cannot reference... |
|--------|-----------------|---------------------|
| 1_Presentation | 2, 3, 4, 5, 6 | — |
| 2_Application | 3, 4, 5, 6 | 1 |
| 3_Structuration | 5, 6 | 1, 2, 4 |
| 4_Operation | 3, 5, 6 | 1, 2 |
| 5_Declaration | 6 | 1, 2, 3, 4 |
| 6_Ideation | — (leaf) | 1, 2, 3, 4, 5 |

### Dependency Chain

```
1_Presentation ──→ 2_Application ──→ 3_Structuration ──→ 4_Operation
                                                        └─→ 5_Declaration ──→ 6_Ideation
                                                                                ↑
                                                  5_Declaration ──→            │
                                                  3_Structuration ──→          │
                                                  4_Operation ──→              │
                                                  2_Application ──→            │
                                                  1_Presentation ──→           │
```

Layer 6 is the absolute leaf. Nothing in the solution depends on 1_Presentation, 2_Application, 3_Structuration, 4_Operation, or 5_Declaration.

## Namespace → Layer Map

| Root Namespace | Layer | Purpose |
|---------------|-------|---------|
| `Alis.App.*` | 1 (Presentation) | Application entry points |
| `Alis.Benchmark` | 1 (Presentation) | Performance benchmarks |
| `Alis.Extension.*` | 1 (Presentation) | Extension libraries |
| `Alis.Builder.Core.Ecs.*` | 2 (Application) | Builder pattern for entities/components |
| `Alis.Sample.*` | 2 (Application) | Sample games |
| `Alis.Core.*` | 3 (Structuration) | Core abstractions |
| `Alis.Core.Ecs.*` | 4 (Operation) | ECS runtime |
| `Alis.Core.Audio.*` | 4 (Operation) | Audio system |
| `Alis.Core.Graphic.*` | 4 (Operation) | Graphics rendering |
| `Alis.Core.Physic.*` | 4 (Operation) | Physics engine |
| `Alis.Core.Aspect.*` | 5 (Declaration) | Aspect-oriented plumbing |
| `Alis.Core.Aspect.Data.*` | 6 (Ideation) | Data/JSON aspects |
| `Alis.Core.Aspect.Fluent.*` | 6 (Ideation) | Fluent API aspects |
| `Alis.Core.Aspect.Logging.*` | 6 (Ideation) | Logging aspects |
| `Alis.Core.Aspect.Math.*` | 6 (Ideation) | Math primitives |
| `Alis.Core.Aspect.Memory.*` | 6 (Ideation) | Memory management aspects |
| `Alis.Core.Aspect.Time.*` | 6 (Ideation) | Time utilities |

## Key Types by Layer

### Layer 4 — Operation (Engine Systems)
- **ECS**: `GameObject`, `Scene`, `EntityData`, `EntityWorldInfoAccess`, `IArchetypeGraphEdge`
- **Components** (in Alis app): `Transform`, `Sprite`, `Camera`, `Animation`, `Animator`, `RigidBody`, `BoxCollider`, `CircleCollider`, `AudioSource`, `PointLight`, `DirectionalLight`, `SpotLight`, `AreaLight`, `Canvas`
- **Systems/Managers**: `SceneManager`, `GraphicManager`, `AudioManager`, `PhysicManager`, `NetworkManager`, `TimeManager`, `InputManager`
- **Configuration**: `ISetting`, `AudioSetting`, `GraphicSetting`, `InputSetting`, `NetworkSetting`, `PhysicSetting`, `TimeSetting`, `GeneralSetting`
- **Executions**: `IRuntime`, `InternalRuntime`, `IRunteable`
- **Scope**: `IContext`, `Context`, `IContextHandler`, `ContextHandler`

### Layer 3 — Structuration (Core)
- Abstractions shared across all engine systems
- Test-heavy module (206 test files, 6 source files)

### Layer 6 — Ideation (Utility Aspects)
- **Math**: `Vector`, `Matrix`, `Circle`, `Line`, `Point`, `Rectangle`, `Square`
- **Data**: JSON serialization/deserialization, parsing, file operations
- **Fluent**: Fluent API components, word builders
- **Logging**: Abstractions, filters, formatters, outputs
- **Memory**: Memory management with generators
- **Time**: Time utilities

### Layer 1 — Presentation (Extensions)
- **Graphic.Ui**: UI framework with GuizMo, Node system, Plot, Fonts
- **Graphic.Sdl2/Sfml/Glfw**: Platform backend bindings
- **Network**: Client/server architecture
- **Media.FFmpeg**: Audio/video encoding models and builders
- **Math.ProceduralDungeon**: Dungeon generation helpers, services, validators
- **Math.HighSpeedPriorityQueue**: Priority queue for pathfinding/scheduling
- **Thread**: Thread pool, scheduling, strategies
- **Payment.Stripe**: Stripe integration
- **Cloud.DropBox/GoogleDrive**: Cloud storage
- **Ads.GoogleAds**: Ad monetization
- **Language.Dialogue/Translator**: Dialogue systems and translation
- **Io.FileDialog**: Native file dialogs
- **Security**: Security utilities
- **Profile**: Profiling system
- **Updater**: Auto-updater service

## Build Commands by Task

| Task | Command |
|------|---------|
| Full debug build | `dotnet build alis.slnx -c Debug` |
| Full release build (pack-ready) | `dotnet build alis.slnx -c Release` |
| All tests | `dotnet test alis.slnx` |
| Core libs only | `dotnet build alis.core.slnx -c Release` |
| All samples | `dotnet build alis.samples.slnx` |
| Benchmarks | `dotnet build alis.benchmark.slnx && dotnet run --project alis.benchmark.slnx` |
| Tests only | `dotnet test alis.test.slnx` |
| Apps | `dotnet build alis.apps.slnx` |
| Extensions | `dotnet build alis.extensions.slnx` |
| Aspect layer | `dotnet build alis.core.aspect.slnx` |
| Single project | `dotnet build <path/to/project.csproj>` |
| Single test | `dotnet test --filter "FullyQualifiedName~<namespace|class>"` |

## Platform/TFM Quick Reference

| TFM Range | When Used |
|-----------|-----------|
| `net461`–`net481` | Legacy .NET Framework support |
| `netcoreapp2.0`–`netcoreapp3.1` | Legacy .NET Core |
| `netstandard2.0`/`2.1` | Cross-platform library target |
| `net5.0`–`net10.0` | Modern .NET (primary target range) |
| `net10.0-android`/`net10.0-ios` | Asteroid mobile targets |
| `browser-wasm` | Web platform (via blazor/wasm runtime) |

Extension projects use implicit multi-targeting via `Config.props`. App/sample projects target `net8.0` (apps) or `net10.0` (samples). Test projects use `net8.0`. Generator projects use `netstandard2.0;net8.0;net10.0`.
