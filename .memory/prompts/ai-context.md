# AI Context — ALIS Game Engine Framework

## Quick Reference for AI Agents

### Repository Structure
```
Alis/
├── 1_Presentation/     # Extensions, Apps (Engine, Hub, Installer), Benchmark
├── 2_Application/      # Core app + 13 game samples
├── 3_Structuration/    # Core engine aggregator
├── 4_Operation/        # ECS, Graphic, Audio, Physic (each with src/test/sample/Generator)
├── 5_Declaration/      # Aspect system aggregator (zero hand-written code)
├── 6_Ideation/         # Memory, Fluent, Math, Time, Data, Logging (each with src/test/sample/Generator)
├── .config/            # Config.props (version, author, license)
├── Directory.Build.props  # Centralized build config (C# 13, net8.0, SonarQube)
├── alis.slnx           # Structured solution
└── alis_design.sln     # Full design solution (75 projects)
```

### Key Facts
- **140 total projects** across 6 architectural layers
- **Dependency flow**: 1 → 2 → 3 → 4 → 5 → 6 (strict layering)
- **Generator flow**: 6_Ideation.Generator → 5_Declaration → 4_Operation → ...
- **Test framework**: xUnit 2.6.6 + Moq 4.20.70
- **Code analysis**: SonarQube (tests excluded)
- **Target frameworks**: net8.0, netstandard2.0 (project-dependent)
- **C# version**: 13

### Naming Conventions
- **Projects**: `Alis.{LayerContext}.{Module}.{SubModule}`
- **Namespaces**: Mirror project structure (e.g., `Alis.Core.Ecs`)
- **Test projects**: `{ProjectName}.Test`
- **Extensions**: `Alis.Extension.{Category}.{Name}`
- **Samples**: `Alis.Sample.{GameName}`

### Aggregator Pattern
Projects with zero hand-written code:
- `Alis.Core` (3_Structuration) — aggregates 4_Operation projects
- `Alis.Core.Aspect` (5_Declaration) — aggregates generated code from 6_Ideation

### Source Generator Architecture
Each Ideation aspect has 4 sub-projects:
1. `src/` — Aspect definition + generator implementation
2. `test/` — Tests for generator output
3. `sample/` — Usage examples
4. `Generator/` — Roslyn ISourceGenerator

Generators cascade: Ideation → Declaration → Operation → Structuration → Application → Presentation

### Build Commands
```bash
dotnet restore                    # Restore all dependencies
dotnet build alis.slnx            # Build all projects
dotnet test                       # Run all tests
dotnet pack -c Release           # Create NuGet packages
```

### Common Tasks
- **Adding a new extension**: Create in `1_Presentation/Extension.{Name}/`
- **Adding a game sample**: Create in `2_Application/Alis/Sample.{Name}/`
- **Adding an aspect**: Create in `6_Ideation/Aspect.{Name}/` with src/test/sample/Generator
- **Adding engine subsystem**: Create in `4_Operation/{Name}/` with src/test/sample/Generator

### Files to Check
- `Directory.Build.props` — Build configuration
- `.config/Config.props` — Project metadata
- `alis.slnx` — Solution structure
- `2_Application/Alis/src/.docs/arquitecture.md` — Canonical architecture reference

### Anti-Patterns to Avoid
- ❌ Cross-layer references (e.g., 1_Presentation → 3_Structuration)
- ❌ Upward references (e.g., 4_Operation → 3_Structuration)
- ❌ Hand-written code in aggregator projects (Alis.Core, Alis.Core.Aspect)
- ❌ Modifying generated code directly (edit the generator instead)
