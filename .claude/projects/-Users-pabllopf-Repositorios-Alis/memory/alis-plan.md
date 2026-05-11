---
name: Alis navigation guide
description: How to navigate, find code, build, and modify the Alis solution
type: project
---

## Quick Navigation

### Find X by topic
- Entity/Component system → `.info/projects.md` → 4_Operation/Ecs
- Physics → `.info/projects.md` → 4_Operation/Physic
- Graphics → `.info/projects.md` → 4_Operation/Graphic + 1_Presentation/Extension/Graphic
- Main app → `.info/projects.md` → 2_Application/Alis
- Sample games → `.info/projects.md` → 2_Application/Alis/samples/ (13 games)
- Extensions → `.info/projects.md` → 1_Presentation/Extension/ (25+ extensions)
- Benchmarks → `.info/projects.md` → 1_Presentation/Benchmark

### Find X by file
- `.info/symbols.md` - All key types with file paths
- `.info/namespaces.md` - Full namespace hierarchy (50+ namespaces)
- `.info/index.md` - Quick stats and entry points

## Build Order (always follow this)
6_Ideation → 5_Declaration → 3_Structuration → 4_Operation → 2_Application → 1_Presentation

## Common Commands
```bash
# Build all
dotnet build alis.sln

# Tests
dotnet test

# Benchmarks
dotnet run --project 1_Presentation/Benchmark/src/Alis.Benchmark.csproj

# Sample game
dotnet run --project 2_Application/Alis/samples/alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj
```

## Adding New Code
1. New extension: `1_Presentation/Extension/<Category>/<Name>/{src,sample,test}/`
2. New sample: `2_Application/Alis/samples/alis.sample.<name>/{desktop,web}/`
3. New aspect: `6_Ideation/<Name>/{src,generator,sample,test}/`

## File Size Leaders
1. Extension.Network (303 files)
2. Extension.Media.FFmpeg (276)
3. Extension.Graphic.Ui (251)
4. Core.Physic (239)
5. Extension.Math.ProceduralDungeon (215)
6. Benchmark (210)
7. Core.Graphic (195)

## Config
- Version: 1.0.6 (Directory.Build.props)
- Test output: .test/$(TargetFramework)/
- Generated files: emitted (EmitCompilerGeneratedFiles=true)
