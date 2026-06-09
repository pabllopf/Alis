---
title: Dependency Constraints
tags:
  - project
  - documentation
  - reference

status: Draft

license: GPLv3

---


## Layer Rules Summary

```
Presentation ──> Application ──> Structuration ──> Operation ──> Declaration ──> Ideation
    │                                                                                │
    └──────────────────── (NO reverse dependencies) ─────────────────────────────────┘
```

## Module-Level Rules

### 4_Operation projects
- **Alis.Core.Ecs**: Has `src/`, `test/`, `sample/`, `generator/` subdirectories (108 source files)
- **Alis.Core.Graphic**: Same structure (147 source files) — depends on ECS for rendering
- **Alis.Core.Audio**: `src/`, `test/`, `sample/` — no generator (5 source files)
- **Alis.Core.Physic**: `src/`, `test/`, `sample/` — no generator (39+ source files)

### 6_Ideation aspects
- **Memory**: Core storage — generators produce memory-mapped code
- **Fluent**: Builder pattern — generators produce fluent API code
- **Data**: JSON/Data serialization
- **Math**: Vector/matrix operations
- **Time**: High-resolution clock
- **Logging**: Logging system

## Project Reference Patterns

- **Extensions** → reference `Alis.App.Core` (2_Application) only
- **Samples** → reference `Alis.Core` (3_Structuration) directly
- **Benchmark** → references `Alis.App.Core` plus NuGet packages
- **Generators** → target `netstandard2.0`, referenced as `Analyzer` with `PrivateAssets=all` and `ReferenceOutputAssembly=false`
- **Tests** → same layer as the project they test

## Related
- [[architecture/dependency-graph]] — Full dependency rules
- [[diagrams/dependency-graph]] — Visual dependency diagram
- [[dependencies/dependency-index]] — Raw dependency data
