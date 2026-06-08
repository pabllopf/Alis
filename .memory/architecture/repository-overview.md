# ALIS Repository Overview

## What is ALIS?
ALIS is a **cross-platform game engine framework** for .NET that supports:
- **Desktop**: Windows, macOS, Linux
- **Web**: WASM
- **Mobile**: Android, iOS

## Architecture Summary

ALIS uses a **6-layer screaming architecture** with strict dependency flow:

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

**Dependency Rule**: Each layer may only reference the layer immediately below it. No cross-layer or upward references are allowed.

**Generator Flow**: Source generators in `6_Ideation` cascade code generation down through all layers:
```
6_Ideation.Generator → 5_Declaration.Aspect → 4_Operation → 3_Structuration → 2_Application → 1_Presentation
```

## Repository Statistics

| Metric | Value |
|--------|-------|
| Total Projects | 140 |
| Solution Files | 2 (alis.slnx, alis_design.sln) |
| Architectural Layers | 6 |
| Target Frameworks | 22 (net461 → net10.0) |
| Test Framework | xUnit 2.6.6 + Moq 4.20.70 |
| Code Analysis | SonarQube |
| Packaging | NuGet with native runtime support |

## Layer Breakdown

### 1_Presentation (Extensions, Apps, Hub)
- **Purpose**: User-facing applications and extensions
- **Subfolders**: Benchmark, Engine, Extension, Hub, Installer
- **Key Projects**:
  - `Alis.App.Engine` — Game engine runtime
  - `Alis.App.Hub` — Game hub/launcher
  - `Alis.App.Installer` — Installer application
  - 19+ extensions (Ads, Security, Payment, Network, Cloud, Media, etc.)

### 2_Application (Core App + Game Samples)
- **Purpose**: Application layer with game samples
- **Subfolders**: Alis (core app + 14 game samples)
- **Game Samples**: Flappy Bird, Pong, Dino, Space Simulator, King Platform, Snake, Rogue, Asteroid, Ruins of Tartarus, Egg, Inefable, Split Camera, Empty, etc.

### 3_Structuration (Core Engine)
- **Purpose**: Core engine aggregation and structuring
- **Subfolders**: Core
- **Key Projects**:
  - `Alis.Core` — Core engine aggregator (zero hand-written code)
  - `Alis.Core.Ecs` — Entity Component System
  - `Alis.Core.Graphic` — Graphics engine
  - `Alis.Core.Audio` — Audio engine
  - `Alis.Core.Physic` — Physics engine

### 4_Operation (Engine Operations)
- **Purpose**: Core engine operations (ECS, Graphics, Audio, Physics)
- **Subfolders**: Audio, Ecs, Graphic, Physic
- **Key Projects**: Each has src/test/sample/generator sub-projects

### 5_Declaration (Aspect System)
- **Purpose**: Aspect-oriented programming system
- **Subfolders**: Aspect
- **Key Projects**: `Alis.Core.Aspect` — Zero hand-written code, pure aggregator

### 6_Ideation (Aspects)
- **Purpose**: High-level aspect definitions with source generators
- **Subfolders**: Data, Fluent, Logging, Math, Memory, Time
- **Pattern**: Each aspect has src/test/sample/generator (4 projects per aspect × 6 aspects = 24 projects)

## Build System

### Directory.Build.props
- **C# Version**: 13
- **Target Frameworks**: net8.0, netstandard2.0 (project-dependent)
- **SDK**: .NET 10.0.0 (rollForward: latestMajor)
- **Features**:
  - SonarQube code analysis with custom NoWarn rules
  - InternalsVisibleTo for test projects
  - Global package references (coverlet, SonarQube analyzer)
  - Custom analyzers: ALIS001-ALIS010
  - AOT compilation support (PublishAot, EnableTrimAnalyzer)
  - Native runtime support for 12+ platform/architecture combos

### NuGet Packaging
- **Native Runtimes**: linux-arm64, linux-arm, linux-x64, linux-musl-x64, linux-musl-arm, linux-musl-arm64, osx-arm64, osx-x64, win-arm64, win-x64, win-x86
- **Assets**: SFML native libraries bundled
- **Publish Ready**: Self-contained, framework-dependent, and cross-platform builds

## Testing Strategy
- All test projects follow naming: `{ProjectName}.Test`
- Framework: xUnit 2.6.6 with Moq 4.20.70
- Coverage: coverlet.collector 6.0.4
- Isolation: Xunit.StaFact for STA tests
- Convention: Test projects excluded from SonarQube (`SonarQubeExclude=true`)

## Source Generator Architecture
ALIS uses Roslyn source generators extensively:
- `Alis.Core.Ecs.Generator` — ECS component/system generation
- `Alis.Core.Graphic.Generator` — Graphics shader/resource generation
- `Alis.Core.Aspect.Memory.Generator` — Memory aspect generation
- `Alis.Core.Aspect.Fluent.Generator` — Fluent API generation
- `Alis.Core.Aspect.Data.Generator` — Data model generation

Generators cascade: Ideation → Declaration → Operation → Structuration → Application → Presentation

## Key Conventions
1. **Namespace Convention**: `Alis.{LayerContext}.{Module}.{SubModule}`
2. **Project Reference Pattern**: Projects reference only their immediate lower layer
3. **Aggregator Pattern**: Core and Aspect projects contain zero hand-written code — they aggregate and expose other projects
4. **Generator Pattern**: Each Ideation aspect has src/test/sample/generator sub-projects
5. **Test Isolation**: Tests are in separate projects with InternalsVisibleTo access
6. **No RootNamespace**: Individual csproj files don't specify RootNamespace — inferred from folder structure
