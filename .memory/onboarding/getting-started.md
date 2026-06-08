# Getting Started with ALIS

## Prerequisites
- .NET SDK 10.0.0+ (rollForward: latestMajor)
- IDE: Rider

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

## Adding a New Extension

1. Create folder: `1_Presentation/Extension.{Name}/`
2. Create csproj with appropriate target framework
3. Add project reference to `Alis`
4. Implement extension code
5. Add test project: `Extension.{Name}.Test/`
6. Update solution file if needed

## Adding a New Game Sample

1. Create folder: `2_Application/Alis/samples/alis.sample.{Name}/alis.sample.{Name}.csproj`
2. Create csproj targeting net8.0
3. Add project references to `Alis`
4. Implement game code
5. Add test project if needed
