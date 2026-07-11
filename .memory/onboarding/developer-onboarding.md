---
title: Developer Onboarding
tags:
  - onboarding
  - guide
  - getting-started
status: Draft
license: GPLv3
---

# Developer Onboarding

## Prerequisites

- .NET SDK 10.0+ (`global.json` enforces version)
- Git
- For graphics development: `brew install sdl2 sdl2_image sdl2_ttf ffmpeg` (macOS)
- IDE: Visual Studio 2022+, JetBrains Rider, or VS Code

## Quick Start

```bash
# Clone and restore
git clone https://github.com/pabllopf/Alis
cd Alis
dotnet restore alis.slnx

# Build
dotnet build alis.slnx -c Debug

# Run tests (quick mode)
dotnet test alis_design.sln -c Release -f net8.0
```

## Repository Layout

The repository is organized into 6 architectural layers:

| Directory | Layer | Description |
|---|---|---|
| `1_Presentation/` | Presentation | Apps, benchmarks, extensions |
| `2_Application/` | Application | Composition root |
| `3_Structuration/` | Structuration | Core foundation |
| `4_Operation/` | Operation | ECS, Audio, Graphic, Physic |
| `5_Declaration/` | Declaration | Aspect contracts |
| `6_Ideation/` | Ideation | Utility modules |

## Key Concepts

### 6-Layer Architecture
Dependencies flow strictly downward. Each layer depends only on the layer below it.

### ECS Pattern
Entity-Component-System architecture for game logic. Entities are lightweight IDs, Components store data, Systems contain logic.

### Source Generators
Many projects have paired generator projects that produce code at compile time using Roslyn.

### Multi-Framework Builds
The same code builds for 15+ .NET frameworks simultaneously.

## Common Workflows

### Adding a New Project
1. Create directory under the appropriate layer: `{Layer}/{Module}/src/`
2. Create `.csproj` importing `Config.props`
3. Add project reference to solution file
4. Create test project: `{Layer}/{Module}/test/`

### Running Specific Tests
```bash
dotnet test <test-project>.csproj -c Release -f net8.0
```

### Building for Release
```bash
dotnet build alis.slnx -c Release
```

## Important Files

| File | Purpose |
|---|---|
| `alis.slnx` | Main solution file |
| `.config/Config.props` | Shared build configuration |
| `Directory.Build.props` | Root build properties |
| `.editorconfig` | Code style rules |
| `global.json` | .NET SDK version |

## Related

- [[Repository Overview]]
- [[Architecture Overview]]
- [[Coding Conventions]]
- [[Projects Index]]
