# Alis - Quick Reference Guide

## Overview
Quick reference cards for common tasks and lookups. Designed for fast access without reading multiple files.

## Navigation Quick Reference

### "I want to find X"
| Looking For | Go To | Cache File |
|-------------|-------|------------|
| Entity/Component system | `4_Operation/Ecs/src/` | symbols.md |
| Physics engine | `4_Operation/Physic/src/` | symbols.md |
| Graphics rendering | `4_Operation/Graphic/src/` + `1_Presentation/Extension/Graphic/*/src/` | symbols.md |
| Audio system | `4_Operation/Audio/src/` | symbols.md |
| Main app logic | `2_Application/Alis/src/` | index.md |
| Sample games | `2_Application/Alis/samples/` | projects.md |
| UI framework | `1_Presentation/Extension/Graphic/Ui/src/` | symbols.md |
| Network code | `1_Presentation/Extension/Network/src/` | symbols.md |
| Math utilities | `6_Ideation/Math/src/` | symbols.md |
| Logging | `6_Ideation/Logging/src/` | symbols.md |
| Time utilities | `6_Ideation/Time/src/` | symbols.md |
| Benchmarks | `1_Presentation/Benchmark/src/` | index.md |

### "I want to modify X"
1. Find the module in `.info/projects.md` or `cache-extensions.md`
2. Check dependencies in `.info/dependencies.md` or `cache-config.md`
3. Read the symbol index in `.info/symbols.md`
4. Make changes locally (keep changes local per AGENTS.md)

## Build Commands Quick Reference

### Standard Operations
```bash
# Restore dependencies
dotnet restore alis.slnx

# Build entire solution (Debug)
dotnet build alis.slnx -c Debug

# Build entire solution (Release)
dotnet build alis.slnx -c Release

# Run all tests
dotnet test alis.slnx

# Run tests for specific module
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

# Clean build
dotnet clean alis.slnx
dotnet build alis.slnx -c Debug --no-incremental
```

### Run Specific Projects
```bash
# Run a sample game (desktop)
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj

# Run a sample game (web)
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/web/Alis.Sample.Pong.Web.csproj

# Run benchmarks
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj

# Build specific module
dotnet build 4_Operation/Ecs/src/Alis.Core.Ecs.csproj
```

### Test Output
- **Location:** `.test/{TargetFramework}/{ProjectName}.trx`
- **Format:** TRX (Visual Studio test results)
- **Logger:** `trx;LogFileName={ProjectName}.trx`

## Sample Games Quick Reference

### All 13 Sample Games
| Game | Desktop Path | Web Path | Complexity | Key Features |
|------|-------------|----------|------------|--------------|
| **Asteroid** | `samples/alis.sample.asteroid/desktop` | `.../web` | Medium | Shooter, collisions, particle effects |
| **Dino** | `samples/alis.sample.dino/desktop` | `.../web` | Simple | Runner, obstacle avoidance |
| **Egg** | `samples/alis.sample.egg/desktop` | `.../web` | Simple | Puzzle, physics |
| **Empty** | `samples/alis.sample.empty/desktop` | `.../web` | Minimal | Template/boilerplate |
| **Flappy.Bird** | `samples/alis.sample.flappy.bird/desktop` | `.../web` | Simple | Tap-to-fly, procedural obstacles |
| **Inefable** | `samples/alis.sample.inefable/desktop` | `.../web` | Medium | Atmospheric, narrative |
| **King.Platform** | `samples/alis.sample.king.platform/desktop` | `.../web` | Medium | Platformer, AI |
| **Pong** | `samples/alis.sample.pong/desktop` | `.../web` | Simple | Classic Pong, multiplayer |
| **Rogue** | `samples/alis.sample.rogue/desktop` | `.../web` | Complex | Roguelike, procedural, AI |
| **RuinsOfTartarus** | `samples/alis.sample.ruinsoftartarus/desktop` | `.../web` | Complex | Dungeon crawler, combat |
| **Snake** | `samples/alis.sample.snake/desktop` | `.../web` | Simple | Classic Snake |
| **Space.Simulator** | `samples/alis.sample.space.simulator/desktop` | `.../web` | Complex | Space sim, physics, AI |
| **SplitCamera** | `samples/alis.sample.splitcamera/desktop` | `.../web` | Medium | Multi-view, camera management |

## Extension Quick Reference

### By Category
| Category | Extensions | Use Case |
|----------|-----------|----------|
| **Graphic** | Sdl2, Glfw, Sfml, Ui | Rendering backends, UI framework |
| **Network** | Network | Client/server, multiplayer |
| **Media** | FFmpeg | Audio/video processing |
| **Cloud** | DropBox, GoogleDrive | Cloud storage |
| **Language** | Translator, Dialogue | Localization, conversations |
| **Math** | ProceduralDungeon, HighSpeedPriorityQueue | Level gen, scheduling |
| **Payment** | Stripe | Commerce |
| **Ads** | GoogleAds | Monetization |
| **I/O** | FileDialog | File operations |
| **Profile** | Profile | Profiling, user data |
| **Security** | Security | Hardening |
| **Thread** | Thread | Concurrency |
| **Updater** | Updater | Auto-updates |

### Quick Extension Install
```bash
# Most common extensions
dotnet add package Alis.Extension.Network
dotnet add package Alis.Extension.Graphic.Ui
dotnet add package Alis.Extension.Media.FFmpeg
dotnet add package Alis.Extension.Graphic.Sdl2
```

## ECS Component Quick Reference

### Core Components
| Component | Purpose |
|-----------|---------|
| `Info` | Component metadata |
| `Transform` | Position, rotation, scale |
| `Canvas` | UI canvas container |
| `RigidBody` | Physics body |
| `Animation` | Animation playback |
| `Animator` | Animation controller |
| `Sprite` | Sprite renderer |
| `Camera` | Camera component |
| `Frame` | Frame data |
| `AudioSource` | Audio playback source |
| `PointLight` | Point light source |
| `DirectionalLight` | Directional light source |
| `SpotLight` | Spot light source |
| `AreaLight` | Area light source |
| `BoxCollider` | Box collision shape |
| `CircleCollider` | Circle collision shape |

### ECS Entry Point
```csharp
using Alis;
using Alis.Core.Ecs.System;

class Program
{
    static void Main()
    {
        VideoGame.Create().Run();
    }
}
```

## Build Order (Topological)
Always build in this order to resolve dependencies:
1. **6_Ideation** (leaf modules - no internal deps)
2. **5_Declaration** (depends on 6_Ideation)
3. **3_Structuration** (depends on 5_Declaration, 6_Ideation)
4. **4_Operation** (depends on 3_Structuration, 5_Declaration)
5. **2_Application** (depends on 3_Structuration, 4_Operation)
6. **1_Presentation** (depends on everything above)

## Key File Locations

### Configuration
| File | Purpose |
|------|---------|
| `alis.slnx` | Main solution file |
| `Directory.Build.props` | Shared build properties (v1.0.6) |
| `.config/Config.props` | TFMs, RIDs, analyzers, project references |
| `.config/default/*.props` | Per-project-type profiles (9 files) |
| `.config/target/alis.targets` | Custom build targets |
| `NuGet.Config` | NuGet package sources |

### CI/CD
| Location | Purpose |
|----------|---------|
| `.github/workflows/[ALIS]*.yml` | 41 GitHub Actions workflows |
| `docs/scripts/macos/` | 21 macOS build/test scripts |
| `docs/scripts/linux/` | 6 Linux scripts |
| `docs/scripts/windows/` | 8 Windows scripts |

### Documentation
| File | Purpose |
|------|---------|
| `readme.md` | Public package map, platform scope |
| `AGENTS.md` | Agent workflow rules |
| `CLAUDE.md` | Additional agent rules |
| `.github/copilot-instructions.md` | Copilot-specific instructions |

### Cache System
| File | Purpose |
|------|---------|
| `.info/index.md` | Master index (original) |
| `.info/architecture.md` | Architecture overview (original) |
| `.info/projects.md` | Project inventory (original) |
| `.info/dependencies.md` | Dependency graph (original) |
| `.info/namespaces.md` | Namespace hierarchy (original) |
| `.info/symbols.md` | Key types index (original) |
| `.info/plan.md` | Navigation guide (original) |
| `.info/cache-manifest.md` | Cache versioning (new v3) |
| `.info/cache-config.md` | Build configuration (new) |
| `.info/cache-extensions.md` | Extension catalog (new) |
| `.info/cache-generators.md` | Generator projects (new) |
| `.info/cache-ci-cd.md` | CI/CD pipeline (new) |
| `.info/cache-nuget.md` | NuGet packages (new) |
| `.info/cache-patterns.md` | Code patterns (new) |
| `.info/cache-solution-files.md` | Solution file mapping (new) |
| `.info/cache-module-status.md` | Module progress tracking (new) |

## SonarCloud Metrics
Tracked per module: Coverage, LOC, Maintainability, Code Smells, Technical Debt, Security Rating, Bugs, Reliability Rating, Duplicated Lines, Vulnerabilities.

View at: https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis

## Version Information
| Property | Value |
|----------|-------|
| **Solution Version** | 1.0.6 |
| **Author** | Pablo Perdomo Falcón |
| **License** | GNU GPL v3.0 |
| **NuGet Profile** | https://www.nuget.org/profiles/pabllopf |
| **Repository** | https://github.com/pabllopf/Alis |

## Common Task Templates

### Add a New Extension
```
1. Create: 1_Presentation/Extension/<Category>/<Name>/
2. Add subdirs: src/, sample/, test/
3. Create csproj files (follow existing pattern)
4. Reference: 2_Application/Alis/src/Alis.csproj
5. Add to alis.slnx
6. Add SonarCloud workflow (if needed)
```

### Add a New Sample Game
```
1. Create: 2_Application/Alis/samples/alis.sample.<name>/
2. Add platform dirs: desktop/, web/
3. Follow pattern of existing samples (e.g., pong/)
4. Reference: 2_Application/Alis/src/Alis.csproj
5. Add to alis.slnx
```

### Add a New Aspect (6_Ideation)
```
1. Create: 6_Ideation/<Name>/
2. Add subdirs: src/, test/, sample/, generator/ (optional)
3. Create csproj files
4. Reference: 5_Declaration/Aspect/src/Alis.Core.Aspect.csproj
5. Add to alis.slnx
6. Follow naming: Alis.Core.Aspect.<Name>
```

### Run Specific ECS Benchmark
```bash
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj --filter FullyQualifiedName~CustomEcs
```

### Build Time Module Only
```bash
dotnet build 6_Ideation/Time/src/Alis.Core.Aspect.Time.csproj
dotnet test 6_Ideation/Time/test/Alis.Core.Aspect.Time.Test.csproj
```

## Troubleshooting

### Build Fails - Check:
1. Build order (follow topological order above)
2. TFMs match between referencing and referenced projects
3. Generator projects target netstandard2.0
4. External dependencies installed (FFmpeg, SDL2, SFML, GLFW)

### Tests Fail - Check:
1. Test project references the correct source project
2. InternalsVisibleTo is auto-injected for `{AssemblyName}.Test`
3. Test output goes to `.test/{TargetFramework}/`

### Generator Not Running - Check:
1. Generator project is in `*/generator/` directory
2. Generator targets netstandard2.0
3. Generator is referenced as Analyzer in Config.props
4. `EmitCompilerGeneratedFiles=true` in Directory.Build.props