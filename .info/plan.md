# Alis - Global Plan & Navigation Guide

## How to Navigate This Solution

### "I want to find X"

| If you're looking for... | Go to... |
|--------------------------|----------|
| Entity/Component system | `4_Operation/Ecs/src/` |
| Physics engine | `4_Operation/Physic/src/` |
| Graphics rendering | `4_Operation/Graphic/src/` + `1_Presentation/Extension/Graphic/*/src/` |
| Audio system | `4_Operation/Audio/src/` |
| Main app logic | `2_Application/Alis/src/` |
| Sample games | `2_Application/Alis/samples/` |
| UI framework | `1_Presentation/Extension/Graphic/Ui/src/` |
| Network code | `1_Presentation/Extension/Network/src/` |
| Math utilities | `6_Ideation/Math/src/` |
| Logging | `6_Ideation/Logging/src/` |
| Benchmarks | `1_Presentation/Benchmark/src/` |
| Extensions list | `.info/projects.md` |

### "I want to modify X"

1. Find the module in `.info/projects.md`
2. Check dependencies in `.info/dependencies.md`
3. Read the symbol index in `.info/symbols.md`
4. Make changes locally (keep changes local per CLAUDE.md)

## Build Order

Always build in this order to resolve dependencies:

1. **6_Ideation** (leaf modules - no internal deps)
2. **5_Declaration** (depends on 6_Ideation)
3. **3_Structuration** (depends on 5_Declaration, 6_Ideation)
4. **4_Operation** (depends on 3_Structuration, 5_Declaration)
5. **2_Application** (depends on 3_Structuration, 4_Operation)
6. **1_Presentation** (depends on everything above)

## Key Architectural Decisions

### Why 6 numbered modules?
- **1_Presentation**: User-facing code (apps + plugins)
- **2_Application**: Business logic and samples
- **3_Structuration**: Core abstractions
- **4_Operation**: Concrete implementations (engine systems)
- **5_Declaration**: Meta-programming aspects
- **6_Ideation**: Utility/math primitives

### Why so many ECS implementations?
The benchmark suite (`1_Presentation/Benchmark`) compares 10+ ECS backends to evaluate performance characteristics. This is research-driven development for the optimal ECS choice.

### Why src/sample/test pattern?
Most library projects follow a consistent triad:
- `src/` - Production code
- `sample/` - Usage examples
- `test/` - Unit tests

Generator projects add a 4th: `generator/` for source generators.

## Common Tasks

### Add a new extension
1. Create directory under `1_Presentation/Extension/<Category>/<Name>/`
2. Add `src/`, `sample/`, `test/` subdirectories
3. Create csproj files following the pattern of existing extensions
4. Add to solution (alis.sln)
5. Reference `2_Application/Alis/src/Alis.csproj`

### Add a new sample game
1. Create directory under `2_Application/Alis/samples/alis.sample.<name>/`
2. Add platform subdirectories (`desktop/`, `web/`, etc.)
3. Follow the pattern of existing samples (e.g., `alis.sample.pong/`)
4. Reference `2_Application/Alis/src/Alis.csproj`

### Run benchmarks
```bash
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj
```

### Run tests
```bash
dotnet test
# Or per module:
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj
```

## File Size Leaders (by .cs count in src/)

| Rank | Project | Files |
|------|---------|-------|
| 1 | Extension.Network | 303 |
| 2 | Extension.Media.FFmpeg | 276 |
| 3 | Extension.Graphic.Ui | 251 |
| 4 | Core.Physic | 239 |
| 5 | Extension.Math.ProceduralDungeon | 215 |
| 6 | Benchmark | 210 |
| 7 | Core.Graphic | 195 |
| 8 | Extension.Graphic.Sdl2 | 179 |
| 9 | Core.Aspect.Fluent | 178 |
| 10 | Alis (app core) | 163 |

## Quick File Locations

| File | Path |
|------|------|
| Main solution | `alis.sln` |
| Shared props | `Directory.Build.props` |
| NuGet config | `NuGet.Config` |
| CI workflows | `.github/workflows/` |
| macOS scripts | `docs/scripts/macos/` |
| Linux scripts | `docs/scripts/linux/` |
| Windows scripts | `docs/scripts/windows/` |
| Docs | `docs/` |

## Git History Notes

- Recent commits focus on CLAUDE.md, agent team docs, and docs improvements
- The codebase has significant history with many ECS iterations
- Benchmarks are actively maintained for performance tracking
