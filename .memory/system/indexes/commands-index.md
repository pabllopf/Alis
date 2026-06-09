---
title: Commands Index — ALIS
tags:
  - index
  - catalog
  - reference

status: draft

license: GPLv3
---


## Build Commands

| Command | Description |
|---------|-------------|
| `dotnet restore` | Restore all NuGet dependencies |
| `dotnet build alis.slnx` | Build all projects (Debug) |
| `dotnet build alis.slnx -c Release` | Build all projects (Release) |
| `dotnet test alis.slnx` | Run all tests |
| `dotnet test /p:CollectCoverage=true` | Run tests with coverage |
| `dotnet pack -c Release` | Create NuGet packages |

## Memory System Commands

| Command | Description |
|---------|-------------|
| `dotnet restore` | Restore dependencies |
| `dotnet build alis.slnx -c Debug` | Build solution |
| `dotnet test alis.slnx -c Debug` | Run tests |

## Development Commands

```bash
# Run a game sample
cd 2_Application/Alis/samples/alis.sample.flappy.bird/desktop
dotnet run

# Run specific test project
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

# Build specific project
dotnet build 4_Operation/Ecs/src/Alis.Core.Ecs.csproj
```

---

## Related Documentation

- [[architecture/build-system]] — Build configuration
- [[onboarding/getting-started]] — Getting started guide
