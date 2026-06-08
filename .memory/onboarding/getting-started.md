# Getting Started with ALIS

## Prerequisites
- .NET SDK 10.0.0+ (rollForward: latestMajor)
- IDE: Visual Studio 2022+, Rider, or VS Code with C# Dev Kit

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
cd 2_Application/alis/samples/alis.sample.flappy.bird/desktop

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

### The Six Layers
1. **1_Presentation** — Extensions, Apps (Engine, Hub, Installer)
2. **2_Application** — Core app + game samples
3. **3_Structuration** — Core engine aggregator
4. **4_Operation** — ECS, Graphic, Audio, Physic
5. **5_Declaration** — Aspect system (generated)
6. **6_Ideation** — Aspect definitions + generators

### Dependency Flow
```
Presentation → Application → Structuration → Operation → Declaration ← Ideation
```

### Source Generator Flow
```
Ideation.Generator → Declaration → Operation → Structuration → Application → Presentation
```

## Adding a New Extension

1. Create folder: `1_Presentation/Extension.{Name}/`
2. Create csproj with appropriate target framework
3. Add project reference to `Alis.App.Core` (or `Alis.Core.Graphic` for graphic extensions)
4. Implement extension code
5. Add test project: `Extension.{Name}.Test/`
6. Update solution file if needed

## Adding a New Game Sample

1. Create folder: `2_Application/Alis/Sample.{Name}/`
2. Create csproj targeting net8.0
3. Add project references to `Alis.App.Core` and `Alis.Core`
4. Implement game code
5. Add test project if needed

## Adding a New Aspect

1. Create folder: `6_Ideation/Aspect.{Name}/`
2. Create sub-projects: src/, test/, sample/, Generator/
3. Implement aspect definition in src/
4. Implement Roslyn source generator in Generator/
5. Add tests for generator output in test/
6. Add usage examples in sample/

## Key Files to Know
- `Directory.Build.props` — Build configuration
- `.config/Config.props` — Project metadata
- `alis.slnx` — Structured solution
- `2_Application/Alis/src/.docs/arquitecture.md` — Architecture reference

## Common Tasks
- See `.memory/prompts/code-review-checklist.md` for review guidelines
- See `.memory/architecture/repository-overview.md` for full architecture details
- See `.memory/glossary/terms.md` for terminology
