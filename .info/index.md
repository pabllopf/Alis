# Alis Solution - Master Index

## Quick Stats

| Metric | Value |
|--------|-------|
| Total Projects | 142 |
| Total .cs Files | 6,253 |
| Repository Size | ~15GB |
| Modules | 6 (numbered 1-6) |
| Solution Files | 5 |
| Target Frameworks | .NET 4.7.1 → .NET 9.0 |
| Sample Games | 13 |
| Extensions | 25+ |
| ECS Implementations Benchmarked | 10+ |

## Documentation Files

| File | Content |
|------|---------|
| [architecture.md](architecture.md) | Full architecture overview, layers, patterns |
| [projects.md](projects.md) | Complete project inventory with paths |
| [symbols.md](symbols.md) | Key types, classes, interfaces by module |
| [dependencies.md](dependencies.md) | Dependency graph, build order, cross-refs |
| [namespaces.md](namespaces.md) | Complete namespace hierarchy |

## Module Quick Reference

| # | Module | csproj | .cs | Purpose |
|---|--------|-------|-----|---------|
| 1 | Presentation | 71 | 3,330 | Apps + Extensions |
| 2 | Application | 30 | 485 | Main app + samples |
| 3 | Structuration | 3 | 264 | Core ECS foundation |
| 4 | Operation | 14 | 1,264 | Engine systems |
| 5 | Declaration | 3 | 59 | Aspect declarations |
| 6 | Ideation | 21 | 851 | Utility aspects |

## Entry Points

| Application | Project Path | Main Entry |
|-------------|-------------|------------|
| Game Engine | `1_Presentation/Engine/src/` | Program.cs |
| Hub | `1_Presentation/Hub/src/` | Program.cs |
| Agent | `1_Presentation/Agent/src/` | Program.cs |
| Installer | `1_Presentation/Installer/src/` | Program.cs |
| Query | `1_Presentation/Agent/query/` | Program.cs |
| Benchmarks | `1_Presentation/Benchmark/src/` | CustomEcs, FrentEcs |

## Key Source Files

### ECS Core
- `4_Operation/Ecs/src/GameObject.cs` - Main entity type
- `4_Operation/Ecs/src/Scene.cs` - Scene container
- `4_Operation/Ecs/src/EntityData.cs` - Entity data storage
- `4_Operation/Ecs/src/EntityWorldInfoAccess.cs` - World access

### Application Core
- `2_Application/Alis/src/Core/Ecs/Systems/VideoGame.cs` - Main game runtime
- `2_Application/Alis/src/Core/Ecs/Systems/IGame.cs` - Game interface
- `2_Application/Alis/src/Core/Ecs/Systems/Manager/SceneManager.cs` - Scene manager

### Builders
- `2_Application/Alis/src/Builder/Core/Ecs/Entity/GameObjectBuilder.cs`
- `2_Application/Alis/src/Builder/Core/Ecs/System/VideoGameBuilder.cs`

### Extensions (Largest)
- `1_Presentation/Extension/Network/src/` - 303 files (largest extension)
- `1_Presentation/Extension/Media/FFmpeg/src/` - 276 files
- `1_Presentation/Extension/Graphic/Ui/src/` - 251 files
- `4_Operation/Physic/src/` - 239 files
- `1_Presentation/Extension/Math/ProceduralDungeon/src/` - 215 files

## Build Commands

```bash
# Build entire solution
dotnet build alis.sln

# Build specific module
dotnet build 4_Operation/Ecs/src/Alis.Core.Ecs.csproj

# Run tests
dotnet test

# Run benchmarks
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj

# Run a sample game
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj
```

## Configuration Files

| File | Purpose |
|------|---------|
| `Directory.Build.props` | Shared build properties (version 1.0.6, test output) |
| `NuGet.Config` | NuGet package sources |
| `.config/default/*.props` | Per-project-type profiles (9 profiles) |
| `.config/target/alis.targets` | Custom build targets |

## CI/CD (GitHub Actions)

| Workflow | Purpose |
|----------|---------|
| `[ALIS][BENCHMARK]` | Run benchmarks |
| `[ALIS][CHECK][ISSUES]` | Issue checking |
| `[ALIS][CODE]` | Code quality |
| `[ALIS][CONTRIBUTORS]` | Track contributors |
| `[ALIS][DEPENDENCY][REVIEW]` | Dependency review |
| `[ALIS][NEW][CONTRIBUTORS]` | New contributor workflow |
| `[ALIS][PUBLISH]` | Publish packages |
| `[ALIS][TEST]` | Run tests |

## Script Categories

| Platform | Location | Scripts |
|----------|----------|---------|
| macOS | `docs/scripts/macos/` | 21 scripts (build, test, clean, pack, etc.) |
| Linux | `docs/scripts/linux/` | 6 scripts (install, generate, test) |
| Windows | `docs/scripts/windows/` | 8 scripts (batch equivalents) |

## Architecture Patterns Used

| Pattern | Where |
|---------|-------|
| **Builder** | `2_Application/Alis/src/Builder/` - GameObject, Scene, Components |
| **Manager** | `Core/Ecs/Systems/Manager/` - All subsystem managers |
| **Context/Scope** | `Core/Ecs/Systems/Scope/` - IContext, ContextHandler |
| **Runtime** | `Core/Ecs/Systems/Execution/` - IRuntime, InternalRuntime |
| **Setting** | `Core/Ecs/Systems/Configuration/` - Typed settings |
| **Source Generation** | `*/*/generator/` projects |
| **Aspect-Oriented** | `5_Declaration/`, `6_Ideation/` |
| **Client/Server** | `1_Presentation/Extension/Network/` |

## ECS Implementations in Benchmark

1. Alis.Core.Ecs (custom)
2. Arch
3. DefaultEcs
4. Flecs.NET
5. Friflo.Engine.ECS
6. HypEcs
7. Scellecs.Morpeh
8. Svelto.ECS
9. myECS
10. fennecs
11. MonoGame.Extended.Entities
12. Leopotam.Ecs / EcsLite
