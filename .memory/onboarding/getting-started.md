---
Getting Started with ALIS
tags:
  - onboarding
  - guide
  - getting-started
  - documentation

status: draft

license: GPLv3
---



## Prerequisites

- **.NET SDK**: 10.0.0+ (rollForward: latestMajor)
- **IDE**: Rider, Visual Studio 2022+, or VS Code with C# Dev Kit
- **OS**: Windows, macOS, or Linux

## Quick Start

### 1. Clone and Build
```bash
git clone https://github.com/pabllopf/Alis.git
cd Alis
dotnet restore
dotnet build alis.slnx
```

### 2. Run a Game Sample
```bash
# Navigate to a game sample
cd 2_Application/Alis/samples/alis.sample.flappy.bird/desktop

# Run the game
dotnet run
```

### 3. Run Tests
```bash
# All tests
dotnet test

# Specific layer
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

# With coverage
dotnet test /p:CollectCoverage=true
```

## Understanding the Architecture

### The Six Layers (Strict Dependency Flow)
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration ← 6_Ideation
```

1. **1_Presentation** — Extensions, Apps (Engine, Hub, Installer), Benchmark
2. **2_Application** — Core app + 13 game samples
3. **3_Structuration** — Core engine aggregator (zero hand-written code)
4. **4_Operation** — ECS, Graphic, Audio, Physic (each with src/test/sample/Generator)
5. **5_Declaration** — Aspect system aggregator (zero hand-written code)
6. **6_Ideation** — Memory, Fluent, Math, Time, Data, Logging (each with src/test/sample/Generator)

### Key Concepts

- **ECS (Entity Component System)**: Core game object management with archetype-based storage
- **AOP (Aspect-Oriented Programming)**: Cross-cutting concerns via source generators
- **Aggregator Pattern**: Zero-code re-export projects (Alis.Core, Alis.Core.Aspect)
- **Source Generator Cascading**: Generators in 6_Ideation produce code flowing through all layers

## Adding a New Extension

1. Create folder: `1_Presentation/Extension/{Category}/{Name}/`
2. Create three sub-projects: `src/`, `test/`, `sample/`
3. Each csproj should reference `Alis` (the core app)
4. Implement extension code in `src/`
5. Add xUnit tests in `test/`
6. Add usage examples in `sample/`

## Adding a New Game Sample

1. Create folder: `2_Application/Alis/samples/alis.sample.{Name}/`
2. Create two sub-projects: `desktop/` and `web/`
3. Each csproj should target `net8.0` and reference `Alis`
4. Implement game code
5. Add test project if needed

## Adding a New Aspect

1. Create folder: `6_Ideation/{Name}/`
2. Create four sub-projects: `src/`, `test/`, `sample/`, `generator/`
3. `generator/` must target `netstandard2.0` and implement `ISourceGenerator`
4. Register generator in `Config.props` for cascade
5. Add tests for generator output

## Build Configurations

| Configuration | Frameworks | Use Case |
|--------------|-----------|----------|
| Debug | 6 TFMs | Development |
| Release | 21 TFMs | Production/NuGet |

## IDE Setup

### Rider
1. Open `alis.slnx`
2. Rider will auto-detect the solution structure
3. Set startup project to a game sample

### Visual Studio
1. Open `alis.slnx` (VS 2022+)
2. Enable .NET 10 SDK support
3. Set build configuration to Debug

### VS Code
1. Install C# Dev Kit extension
2. Open the repository root
3. Use integrated terminal for build commands

---

## Related Documentation

- [[architecture/repository-overview]] — Architecture overview
- [[architecture/build-system]] — Build configuration
- [[conventions/naming-conventions]] — Naming rules
- [[prompts/ai-context]] — AI context card
