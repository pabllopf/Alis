---
title: Onboarding
tags: [project,documentation,reference]
---


## Quick Start

```bash
# Restore dependencies
dotnet restore alis.slnx

# Build (Debug)
dotnet build alis.slnx -c Debug

# Run all tests
dotnet test alis.slnx -c Debug
```

## Repository Structure

```
alis.slnx — Solution file (335 projects across 6 layers)
├── 1_Presentation/ — Engine, Extensions, UI, Benchmark
│   ├── Alis.App.Engine/
│   ├── Alis.App.Hub/
│   ├── Alis.App.Installer/
│   ├── Benchmark/  (BenchmarkDotNet runner)
│   └── Extension/  (19 extension projects)
├── 2_Application/ — Alis core, samples
│   ├── Alis/       (App.Core)
│   └── samples/    (14 game samples)
├── 3_Structuration/ — Core abstractions
│   └── Alis.Core/
├── 4_Operation/ — Engine operations
│   ├── Alis.Core.Ecs/
│   ├── Alis.Core.Graphic/
│   ├── Alis.Core.Audio/
│   └── Alis.Core.Physic/
├── 5_Declaration/ — Contracts, interfaces
│   └── Alis.Core.Aspect/
├── 6_Ideation/ — Experimental aspects
│   ├── Memory/
│   ├── Fluent/
│   ├── Data/
│   ├── Math/
│   ├── Time/
│   └── Logging/
└── .config/ — Shared build config
```

## Key Principles

1. **Dependency order is strict**: never reverse 1→2→3→4→5→6
2. **AOT compatible**: no `System.Reflection.Emit` or runtime IL emit
3. **Multi-targeting**: 15+ .NET frameworks per project
4. **Source generators**: produce AOT-safe code at compile time
5. **No external NuGet**: only standard .NET, system libs, native APIs

## .memory Navigation

| Area | Contents |
|---|---|
| `.memory/projects/` | Per-project documentation (by layer) |
| `.memory/diagrams/` | Mermaid architecture diagrams |
| `.memory/context/` | AI context / onboarding files |
| `.memory/glossary/` | Domain-specific terminology |
| `.memory/conventions/` | Coding standards, rules |
| `.memory/decisions/` | Architecture decision records |
| `.memory/system/` | Execution state, tracking, queues |

## Related
- [[architecture-rules]] — Layer dependency rules
- [[coding-conventions]] — Coding standards
- [[dependency-constraints]] — Module dependency rules
- [[project-map]] — Project quick reference
