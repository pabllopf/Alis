# Alis — Build Graph & Commands

## Topological Build Order

When building from scratch, projects must be compiled in dependency order:

```
Phase 1 — Leaf Modules (no internal dependencies):
  6_Ideation/Data/src
  6_Ideation/Fluent/src
  6_Ideation/Logging/src
  6_Ideation/Math/src
  6_Ideation/Memory/src
  6_Ideation/Time/src

Phase 2 — Aspect Declarations (depends on 6_Ideation):
  5_Declaration/Aspect/src

Phase 3 — Core Structuration (depends on 5+6):
  3_Structuration/Core/src

Phase 4 — Operation Systems (depends on 3+5):
  4_Operation/Ecs/src + generator
  4_Operation/Audio/src
  4_Operation/Graphic/src + generator
  4_Operation/Physic/src

Phase 5 — Application Core (depends on 3+4):
  2_Application/Alis/src

Phase 6 — Presentation Layer (depends on 2+3+4+6):
  1_Presentation/Engine/src
  1_Presentation/Hub/src
  1_Presentation/Agent/src
  1_Presentation/Installer/src
  1_Presentation/Extension/*/src/*    (all 19 extensions)
  1_Presentation/Benchmark/src
  1_Presentation/Extension/*/sample/* (all samples)
  1_Presentation/Extension/*/test/*   (all test projects)

Phase 7 — Sample Games (depends on 2_Application):
  2_Application/Alis/samples/alis.sample.*/desktop/*
  2_Application/Alis/samples/alis.sample.*/web/*
  2_Application/Alis/samples/alis.sample.asteroid/android/*
  2_Application/Alis/samples/alis.sample.asteroid/ios/*

Phase 8 — Test Projects (depends on src projects):
  All *.Test/ projects across layers 2–6
```

## Build Commands by .slnx File

### Full Solution
```bash
# Debug build (fast, for development)
dotnet build alis.slnx -c Debug

# Release build (pack-ready, deterministic, warnings as errors)
dotnet build alis.slnx -c Release

# All tests
dotnet test alis.slnx

# Test + build (no rebuild)
dotnet test alis.slnx --no-build
```

### Core Only (CI, Publishing)
```bash
# Build all core libraries (18 projects, no tests/samples)
dotnet build alis.core.slnx -c Release

# Publish individual package
dotnet publish 3_Structuration/Core/src/Alis.Core.csproj -c Release
dotnet publish 4_Operation/Ecs/src/Alis.Core.Ecs.csproj -c Release
dotnet publish 4_Operation/Audio/src/Alis.Core.Audio.csproj -c Release
dotnet publish 4_Operation/Graphic/src/Alis.Core.Graphic.csproj -c Release
dotnet publish 4_Operation/Physic/src/Alis.Core.Physic.csproj -c Release
dotnet publish 5_Declaration/Aspect/src/Alis.Core.Aspect.csproj -c Release
dotnet publish 6_Ideation/*/src/Alis.Core.Aspect.*.csproj -c Release
```

### Samples
```bash
# Build all sample games
dotnet build alis.samples.slnx

# Run a specific sample
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj
dotnet run --project 2_Application/Alis/samples/alis.sample.asteroid/desktop/Alis.Sample.Asteroid.Desktop.csproj

# Web samples (require wasm workload)
dotnet add 2_Application/Alis/samples/alis.sample.pong/web/Alis.Sample.Pong.Web.csproj workload wasm
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/web/Alis.Sample.Pong.Web.csproj --framework net10.0
```

### Tests
```bash
# All tests
dotnet test alis.test.slnx

# Tests for a specific module
dotnet test 3_Structuration/Core/test/Alis.Core.Test.csproj
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj
dotnet test 4_Operation/Physic/test/Alis.Core.Physic.Test.csproj
dotnet test 4_Operation/Audio/test/Alis.Core.Audio.Test.csproj
dotnet test 4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj
dotnet test 5_Declaration/Aspect/test/Alis.Core.Aspect.Test.csproj
dotnet test 6_Ideation/*/test/Alis.Core.Aspect.*.Test.csproj

# Filter by namespace
dotnet test --filter "FullyQualifiedName~Alis.Core.Ecs"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# TRX results (configured in Directory.Build.props)
dotnet test alis.test.slnx  # Results in .test/$(TargetFramework)/
```

### Apps
```bash
# Build all apps + core
dotnet build alis.apps.slnx

# Run Engine
dotnet run --project 1_Presentation/Engine/src/Alis.App.Engine.csproj

# Run Hub (on macOS, builds DMG after build)
dotnet run --project 1_Presentation/Hub/src/Alis.App.Hub.csproj

# Run Agent
dotnet run --project 1_Presentation/Agent/src/Alis.App.Agent.csproj

# Run Installer
dotnet run --project 1_Presentation/Installer/src/Alis.App.Installer.csproj
```

### Benchmarks
```bash
# Run benchmarks
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj

# Benchmark with specific filter
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj --filter "CustomEcs"
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj --filter "ClassVsStruct"
```

### Extensions
```bash
# Build all extensions
dotnet build alis.extensions.slnx

# Build a specific extension
dotnet build 1_Presentation/Extension/Network/src/Alis.Extension.Network.csproj
dotnet build 1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj
dotnet build 1_Presentation/Extension/Media/FFmpeg/src/Alis.Extension.Media.FFmpeg.csproj

# Run extension sample
dotnet run --project 1_Presentation/Extension/Graphic/Sdl2/sample/Alis.Extension.Graphic.Sdl2.Sample.csproj
dotnet run --project 1_Presentation/Extension/Network/samples/SimpleChat/client/Alis.Extension.Network.Sample.SimpleChat.Client.csproj
```

### Aspect Layer
```bash
# Build aspect layer (5+6)
dotnet build alis.core.aspect.slnx

# Build individual aspect
dotnet build 6_Ideation/Data/src/Alis.Core.Aspect.Data.csproj
dotnet build 6_Ideation/Fluent/src/Alis.Core.Aspect.Fluent.csproj
dotnet build 6_Ideation/Logging/src/Alis.Core.Aspect.Logging.csproj
dotnet build 6_Ideation/Math/src/Alis.Core.Aspect.Math.csproj
dotnet build 6_Ideation/Memory/src/Alis.Core.Aspect.Memory.csproj
dotnet build 6_Ideation/Time/src/Alis.Core.Aspect.Time.csproj
```

## Generator Build Order

Generators must be built before their host projects consume generated code:

```bash
# Build all generators (netstandard2.0 target)
dotnet build 4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj -c Release
dotnet build 4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj -c Release
dotnet build 6_Ideation/Data/generator/Alis.Core.Aspect.Data.Generator.csproj -c Release
dotnet build 6_Ideation/Fluent/generator/Alis.Core.Aspect.Fluent.Generator.csproj -c Release
dotnet build 6_Ideation/Memory/generator/Alis.Core.Aspect.Memory.Generator.csproj -c Release
```

Generators are referenced as analyzers (`ProjectReference` with `OutputItemType="Analyzer"` and `PrivateAssets="all"`), so they build automatically when the host project builds — but for isolated generator development, build them first.

## Common Dev Scenarios

| Scenario | Command |
|----------|---------|
| "I just changed ECS code" | `dotnet build 4_Operation/Ecs/` (src + test) |
| "I'm adding a game sample" | `dotnet build alis.samples.slnx` |
| "I need to run all tests" | `dotnet test alis.test.slnx` |
| "I'm writing a new extension" | `dotnet build alis.extensions.slnx` |
| "I need to run benchmarks" | `dotnet run --project alis.benchmark.slnx` |
| "I'm debugging the engine" | `dotnet build alis.apps.slnx && dotnet run --project 1_Presentation/Engine/src/Alis.App.Engine.csproj` |
| "I'm working on the main app" | `dotnet build alis.core.slnx` |
| "Full CI build" | `dotnet build alis.slnx -c Release` |
| "Clean and rebuild" | `dotnet clean alis.slnx && dotnet build alis.slnx -c Debug` |

## Output Layout

| Project Type | Output Directory |
|-------------|-----------------|
| Library (src/) | `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/` |
| App/Executable | `bin/$(Configuration)/$(RuntimeIdentifier)/lib/` |
| Sample | `bin/$(Configuration)/$(RuntimeIdentifier)/lib/` |
| Generator | `bin/$(Configuration)/$(TargetFramework)/` (default SDK layout) |
| Test | `bin/$(Configuration)/$(TargetFramework)/` (default SDK layout) |
| Test results | `.test/$(TargetFramework)/` (TRX format) |

## Release Build Notes

Release builds (`-c Release`) enable:
- `IncludeBuildOutput=false` — output not included in package
- `IncludeSymbols=false` — no PDB in package
- `DebugType=portable` — portable PDB for SourceLink
- `Deterministic=true` — reproducible builds
- `GenerateDocumentationFile=true` — XML doc comment generation
- `ContinuousIntegrationBuild=true` — SourceLink embeds commit info
- Generator outputs are copied into `analyzers/dotnet/cs/` in the package
