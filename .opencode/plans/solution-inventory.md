# Alis - Global Solution Inventory

## Quick Stats

| Metric | Value |
|--------|-------|
| Total Projects | 134 |
| Total .cs Files | ~6,886 (src: 1,717, test: 1,227, other: 3,942 [samples/generators]) |
| Assembly Version | 1.0.6 |
| Languages | C# 13, Nullable: disabled, Unsafe: disabled |
| Solution Files | 8 (.slnx, XML format) |
| Target Frameworks | net461–net481, netcoreapp2.0–3.1, netstandard2.0/2.1, net5.0–net10.0 |
| Runtime Identifiers | win-x64/x86/arm64, linux-x64/arm/arm64/musl-x64/musl-arm/musl-arm64, osx-x64/arm64, browser-wasm, android-arm64/x64, ios-arm64/simulator-arm64/x64 |
| Sample Games | 13 (Asteroid, Dino, Egg, Empty, Flappy.Bird, Inefable, King.Platform, Pong, Rogue, RuinsOfTartarus, Snake, Space.Simulator, SplitCamera) |
| Platform Reach | Asteroid: desktop/web/android/ios; others: desktop/web |
| Extensions | 19 library projects across 9 categories |
| Test Projects | 35 |
| Source Generators | 5 (Ecs, Graphic, Data, Fluent, Memory) |
| External NuGet Packages | ~25 unique third-party packages |
| CI Workflows | 8 GitHub Actions |
| Script Sets | macOS (21), Linux (6), Windows (8) |

## Solution File Matrix

| .slnx | Projects | Scope | Core Src | Tests | Samples | Extensions | Apps | Generators |
|-------|----------|-------|----------|-------|---------|------------|------|------------|
| **alis.slnx** | 134 | Full solution | Yes | Yes | Yes | Yes | Yes | Yes |
| **alis.samples.slnx** | 56 | Samples + core | Yes | No | Yes | No | No | Yes |
| **alis.benchmark.slnx** | 1 | Benchmark only | No | No | No | No | No | No |
| **alis.core.slnx** | 18 | Core libs only | Yes | No | No | No | No | Yes |
| **alis.test.slnx** | 31 | Tests + core src | Yes | Yes | No | No | No | No |
| **alis.apps.slnx** | 21 | Apps + all core | Yes | No | No | No | Yes | Yes |
| **alis.extensions.slnx** | 37 | Extensions + core | Yes | No | No | Yes | No | Yes |
| **alis.core.aspect.slnx** | 10 | Layer 5+6 only | Yes | Yes | Yes | No | No | Yes |

## 6-Layer Architecture

```
Layer 6: Ideation ── Utility aspects (Data, Fluent, Logging, Math, Memory, Time)
Layer 5: Declaration ── Aspect-oriented plumbing
Layer 4: Operation ── Engine systems (ECS, Audio, Graphic, Physic)
Layer 3: Structuration ── Core abstractions (Alis.Core)
Layer 2: Application ── Main app (Alis) + 13 sample games
Layer 1: Presentation ── Apps (Engine/Hub/Agent/Installer) + 19 extensions + Benchmark
```

**Dependency flow (strict, downward only):**
`1 → 2 → 3 → 4 → 5 → 6`
(1_Presentation references 2_Application, which references 3_Structuration, etc.)
Layer 6 (Ideation) is the leaf — no internal dependencies.

## Source File Distribution by Module

| Module | Total .cs | src/ | test/ | other (samples/generators) |
|--------|-----------|------|-------|---------------------------|
| 1_Presentation | ~1,539 | 968 | 484 | ~87 (samples + Engine/Hub assets) |
| 2_Application | ~177 | 88 | 2 | ~87 (samples + builder code) |
| 3_Structuration | ~208 | 6 | 206 | ~2 (samples) |
| 4_Operation | ~995 | 453 | 457 | ~85 (samples + generators) |
| 5_Declaration | ~5 | 6 | 2 | ~3 (samples) |
| 6_Ideation | ~447 | 203 | 218 | ~26 (samples + generators) |

## Extension Inventory (19 Libraries)

| Category | Library | Source Files (src) | External Dep |
|----------|---------|-------------------|--------------|
| **Ads** | GoogleAds | 4 | Google.Ads.Common 9.5.3 |
| **Cloud** | DropBox | 4 | Dropbox.Api 7.0.0 |
| **Cloud** | GoogleDrive | 4 | Google.Apis.Drive.v3 1.68.0.3601 |
| **Graphic** | Glfw | 30+ | MonoGame.Framework.DesktopGL |
| **Graphic** | Sdl2 | 179+ | SDL2 native bindings |
| **Graphic** | Sfml | ~115 | SFML native bindings |
| **Graphic** | Ui | 109+ | — |
| **Io** | FileDialog | 12 | — |
| **Language** | Dialogue | 17 | — |
| **Language** | Translator | ~20 | — |
| **Math** | HighSpeedPriorityQueue | 9 | — |
| **Math** | ProceduralDungeon | ~50 | — |
| **Media** | FFmpeg | ~50 | FFmpeg native binaries |
| **Network** | Network | 34 | — |
| **Payment** | Stripe | 16 | Stripe.net 49.2.0 |
| **Profile** | Profile | ~45 | — |
| **Security** | Security | 9 | — |
| **Thread** | Thread | ~30 | — |
| **Updater** | Updater | ~15 | — |

## Sample Games (13 Games, 28–30 Projects)

| Game | Desktop | Web | Android | iOS |
|------|---------|-----|---------|-----|
| Asteroid | Alis.Sample.Asteroid.Desktop | Alis.Sample.Asteroid.Web | Alis.Sample.Asteroid.Android | Alis.Sample.Asteroid.IOS |
| Dino | Alis.Sample.Dino.Desktop | Alis.Sample.Dino.Web | — | — |
| Egg | Alis.Sample.Egg.Desktop | Alis.Sample.Egg.Web | — | — |
| Empty | Alis.Sample.Empty.Desktop | Alis.Sample.Empty.Web | — | — |
| Flappy.Bird | Alis.Sample.Flappy.Bird.Desktop | Alis.Sample.Flappy.Bird.Web | — | — |
| Inefable | Alis.Sample.Inefable.Desktop | Alis.Sample.Inefable.Web | — | — |
| King.Platform | Alis.Sample.King.Platform.Desktop | Alis.Sample.King.Platform.Web | — | — |
| Pong | Alis.Sample.Pong.Desktop | Alis.Sample.Pong.Web | — | — |
| Rogue | Alis.Sample.Rogue.Desktop | Alis.Sample.Rogue.Web | — | — |
| RuinsOfTartarus | Alis.Sample.RuinsOfTartarus.Desktop | Alis.Sample.RuinsOfTartarus.Web | — | — |
| Snake | Alis.Sample.Snake.Desktop | Alis.Sample.Snake.Web | — | — |
| Space.Simulator | Alis.Sample.Space.Simulator.Desktop | Alis.Sample.Space.Simulator.Web | — | — |
| SplitCamera | Alis.Sample.SplitCamera.Desktop | Alis.Sample.SplitCamera.Web | — | — |

**Pattern:** Each game has a desktop project (.NET 10.0, references Alis.csproj). Web games use `CoroutineScheduler 0.3.0` instead of full platform deps. Asteroid is the only game with Android/iOS targets.

## Source Generators (5 Projects)

| Generator | Host Project | Target Frameworks | Purpose |
|-----------|-------------|-------------------|---------|
| Alis.Core.Ecs.Generator | ECS | netstandard2.0, net8.0, net10.0 | ECS code generation |
| Alis.Core.Graphic.Generator | Graphic | netstandard2.0, net8.0, net10.0 | Graphic code generation |
| Alis.Core.Aspect.Data.Generator | Data aspect | netstandard2.0, net8.0, net10.0 | Data/JSON serialization |
| Alis.Core.Aspect.Fluent.Generator | Fluent aspect | netstandard2.0, net8.0, net10.0 | Fluent API generation |
| Alis.Core.Aspect.Memory.Generator | Memory aspect | netstandard2.0, net8.0, net10.0 | Memory management |

All generators use `Microsoft.CodeAnalysis.CSharp 4.3.0` + `Microsoft.CodeAnalysis.Analyzers 3.3.4`, target netstandard2.0 for IDE compatibility, with net8.0/net10.0 for testing. They are referenced as analyzers (`PrivateAssets="all"`, `ReferenceOutputAssembly="false"`).

## External NuGet Dependencies

| Package | Version | Used By |
|---------|---------|---------|
| BenchmarkDotNet | 0.14.0 | Alis.Benchmark |
| Google.Ads.Common | 9.5.3 | Extension.Ads.GoogleAds |
| Google.Apis.Drive.v3 | 1.68.0.3601 | Extension.Cloud.GoogleDrive |
| Dropbox.Api | 7.0.0 | Extension.Cloud.DropBox |
| Stripe.net | 49.2.0 (47.1.0 in Installer/Engine tests) | Extension.Payment.Stripe, Installer/Engine tests |
| Microsoft.CodeAnalysis.CSharp | 4.3.0 | All 5 generators |
| Microsoft.CodeAnalysis.Analyzers | 3.3.4 | All 5 generators |
| MonoGame.Framework.DesktopGL | 3.8.2.1105 | Benchmark, Glfw extension |
| Microsoft.NET.Test.Sdk | 16.7.1 | All 35 test projects |
| xunit | 2.6.6 | All 35 test projects |
| xunit.runner.visualstudio | 2.4.3 | All 35 test projects |
| Xunit.StaFact | 1.1.11 | All 35 test projects |
| coverlet.collector | 6.0.4 | All 35 test projects |
| Moq | 4.20.70 | All 35 test projects |
| CoroutineScheduler | 0.3.0 | Web sample games |
| Roslynator.Analyzers | 4.13.1 | Benchmark |
| Roslynator.CodeAnalysis.Analyzers | 4.13.1 | Benchmark |
| Roslynator.Formatting.Analyzers | 4.13.1 | Benchmark |
| Microsoft.CodeAnalysis.NetAnalyzers | 9.0.0 | Benchmark |
| DefaultEcs.Analyzer | 0.17.0 | Benchmark |
| **Benchmark ECS frameworks (10+):** | | |
| Arch | 1.2.8 | Benchmark |
| Arch.System | 1.0.5 | Benchmark |
| Arch.System.SourceGenerator | 1.2.1 | Benchmark |
| DefaultEcs | 0.17.2 | Benchmark |
| Flecs.NET.Release | 3.2.11 | Benchmark |
| Friflo.Engine.ECS | 3.2.3 | Benchmark |
| HypEcs | 1.2.1 | Benchmark |
| Leopotam.Ecs | 1.0.1 | Benchmark |
| Leopotam.EcsLite | 1.0.1 | Benchmark |
| MonoGame.Extended.Entities | 3.8.0 | Benchmark |
| Myriad.ECS | 34.6.0 | Benchmark |
| RelEcs | 1.5.1 | Benchmark |
| Scellecs.Morpeh | 2024.1.0 | Benchmark |
| Svelto.ECS | 3.5.2 | Benchmark |
| Svelto.Common | 3.5.2 | Benchmark |
| fennecs | 0.1.1-beta | Benchmark |
| Frent | 0.5.4.3-beta | Benchmark |

## Build Configuration

| Setting | Value |
|---------|-------|
| Language Version | C# 13 |
| Nullable | disabled |
| AllowUnsafeBlocks | false (for library projects) |
| WarningsAsErrors | true |
| TreatWarningsAsErrors | true |
| EnableNETAnalyzers | true |
| AnalysisMode | AllEnabledByDefault |
| AnalysisLevel | latest |
| EmitCompilerGeneratedFiles | true |
| AssemblyVersion | 1.0.6 |
| Test Results Directory | `.test/$(TargetFramework)/` |
| VSTest Logger | TRX format |

### .csproj Pattern

Most library `.csproj` files are minimal 8-line files that:
1. Import `$(SolutionDir).config/Config.props`
2. Set `OutDir` to `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

Executable projects (apps, samples, benchmarks) have ~8–367 lines with explicit `TargetFramework`, `OutputType=Exe`, cross-platform defines (`LINUX`, `OSX`, `WIN`), and custom MSBuild targets (asset packing, DMG creation, zip packaging).

## CI/CD Workflows (8 GitHub Actions)

| Workflow | Purpose |
|----------|---------|
| `[ALIS][BENCHMARK]` | Run benchmarks |
| `[ALIS][CHECK][ISSUES]` | Issue checking |
| `[ALIS][CODE]` | Code quality |
| `[ALIS][CONTRIBUTORS]` | Track contributors |
| `[ALIS][DEPENDENCY][REVIEW]` | Dependency review |
| `[ALIS][NEW][CONTRIBUTORS]` | New contributor workflow |
| `[ALIS][PUBLISH]` | Publish NuGet packages |
| `[ALIS][TEST]` | Run tests |

## Script Categories

| Platform | Location | Script Count |
|----------|----------|--------------|
| macOS | `docs/scripts/macos/` | 21 (build, test, clean, pack, etc.) |
| Linux | `docs/scripts/linux/` | 6 (install, generate, test) |
| Windows | `docs/scripts/windows/` | 8 (batch equivalents) |

## Key Entry Points

| Entry | Project | File |
|-------|---------|------|
| Game Engine | Alis.App.Engine | `1_Presentation/Engine/src/Program.cs` |
| Hub | Alis.App.Hub | `1_Presentation/Hub/src/Program.cs` |
| Agent | Alis.App.Agent | `1_Presentation/Agent/src/Program.cs` |
| Query | Alis.App.Query | `1_Presentation/Agent/query/Program.cs` |
| Installer | Alis.App.Installer | `1_Presentation/Installer/src/Program.cs` |
| Benchmark | Alis.Benchmark | `1_Presentation/Benchmark/src/` (CustomEcs, FrentEcs) |
| Main Game Runtime | Alis | `2_Application/Alis/src/Core/Ecs/Systems/VideoGame.cs` |

## Build Order (Topological)

```
Step 1: 6_Ideation/*           (leaf modules - no internal deps)
Step 2: 5_Declaration/Aspect   (depends on 6_Ideation)
Step 3: 3_Structuration/Core   (depends on 5+6)
Step 4: 4_Operation/*          (depends on 3+5)
Step 5: 2_Application/Alis     (depends on 3+4)
Step 6: 1_Presentation/*       (depends on 2+3+4+6)
```

When building the full solution, MSBuild resolves this automatically. When building subsets (.slnx), build in this order.

## File Architecture Patterns

| Pattern | Where | Description |
|---------|-------|-------------|
| **Library** | All layer 3–6 `src/` | Minimal .csproj, imports Config.props, multi-targets |
| **Executable** | Layer 1 apps, samples, benchmarks | Explicit TFMs, cross-platform conditions, build targets |
| **Test** | `*.Test/` | xunit + Moq + coverlet, net8.0, references src project |
| **Sample** | `*.Sample/` | net10.0 executable, references Alis.csproj |
| **Generator** | `*/generator/` | Microsoft.CodeAnalysis analyzers, netstandard2.0 |
| **Web Sample** | `*/web/` | Same as desktop + `CoroutineScheduler` for WASM async |
| **Network Samples** | Network extension | Client/server pairs — ConsoleGame, SimpleChat, SimpleGame |

## Network Extension — Sample Projects (6)

| Sample | Client | Server |
|--------|--------|--------|
| ConsoleGame | Alis.Extension.Network.Sample.ConsoleGame.Client | Alis.Extension.Network.Sample.ConsoleGame.Server |
| SimpleChat | Alis.Extension.Network.Sample.SimpleChat.Client | Alis.Extension.Network.Sample.SimpleChat.Server |
| SimpleGame | Alis.Extension.Network.Sample.SimpleGame.Client | Alis.Extension.Network.Sample.SimpleGame.Server |

## Size Rankings (by .cs count in `*/src/`)

| Rank | Path | Files |
|------|------|-------|
| 1 | Extension/Graphic/Ui/src | 109 |
| 2 | Extension/Graphic/Sdl2/src/Structs | 56 |
| 3 | Extension/Graphic/Sdl2/src/Enums | 50 |
| 4 | Operation/Graphic/src/OpenGL/Delegates | 60 |
| 5 | Ideation/Fluent/src/Words | 87 |
| 6 | Extension/Graphic/Ui/src/Extras/Plot | 64 |
| 7 | Operation/Physic/src/Dynamics | 37 |
| 8 | Extension/Graphic/Sfml/src/Windows | 39 |
| 9 | Operation/Ecs/test/Collections | 37 |
| 10 | Extension/Graphic/Sfml/src/Render | 37 |
