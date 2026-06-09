---
title: ALIS Architecture
tags:
  - project
  - documentation
  - reference

status: Draft

license: GPLv3

---


## Overview
ALIS follows a layered architecture with 6 distinct layers, each with increasing specificity. Dependencies flow upward only — lower layers never depend on higher ones.

## Layer Structure
```
1_Presentation  ← Applications, Extensions, Samples (user-facing)
2_Application   ← Core application library
3_Structuration ← Foundational abstractions (Core, ECS, Graphic)
4_Operation     ← Runtime implementations (Audio, Input, Physics, etc.)
5_Declaration   ← Data contracts and DTOs
6_Ideation      ← Game-specific domain logic
```

## Dependency Flow
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

Each layer depends only on layers below it. No cross-layer or upward dependencies.

## Layer Responsibilities

### 1_Presentation
- **Purpose**: User-facing applications and reusable extensions
- **Projects**: Engine, Hub, Installer, Benchmark, all Extensions
- **Characteristics**: Platform-specific builds, AOT compilation, asset bundling

### 2_Application
- **Purpose**: Core application library consumed by all Presentation projects
- **Projects**: Alis, Alis.Test, Alis.Sample
- **Characteristics**: Central dependency, no framework dependencies

### 3_Structuration
- **Purpose**: Foundational abstractions and utilities
- **Projects**: Alis.Core, Alis.Core.Ecs, Alis.Core.Graphic
- **Characteristics**: Pure domain logic, no Presentation dependencies

### 4_Operation
- **Purpose**: Concrete runtime implementations
- **Projects**: Alis.Core.Audio, Input, Physics, Resource, Scene, Serialization, Window
- **Characteristics**: Runtime services, builds upon Structuration abstractions

### 5_Declaration
- **Purpose**: Data contracts and interface definitions
- **Projects**: Alis.Core.Data, Alis.Core.Log
- **Characteristics**: Pure DTOs and interfaces, no implementation

### 6_Ideation
- **Purpose**: High-level game-specific functionality
- **Projects**: Alis.Core.Game, Alis.Core.Network
- **Characteristics**: Most specialized libraries, game domain logic

## Generator Pattern
All layers (except 1_Presentation) include a `Generator/` subdirectory containing code generation projects. These are dynamically referenced by all consuming projects using glob-based project references.

## Build System
- **Framework**: .NET 8.0/10.0
- **Shared Configuration**: `Config.props` imported by all projects
- **Asset Pipeline**: SHA256 hash-based change detection → zip → base64 encode
- **Platform Detection**: Conditional compilation symbols (LINUX, OSX, WIN)
- **AOT**: Enabled for Engine and Hub (both Debug and Release)

## Testing Strategy
- Each project has a corresponding `.Test` project
- Test projects auto-discover source project via regex pattern
- All test projects excluded from SonarQube analysis

## Cross-Cutting Concerns
- **SonarQube**: Excluded for all test projects and benchmark
- **Warnings**: Extensive NoWarn configuration (ALIS001-ALIS010, CA rules)
- **LangVersion**: Consistently set to 13 across all projects
- **Nullable**: Disabled across all projects
- **AllowUnsafeBlocks**: Disabled across all projects

## Related

- [[architecture/repository-overview]] — High-level architecture
- [[architecture/dependency-graph]] — Dependency rules
- [[Alis Architecture Overview]] — Concept architecture
- [[Layered Architecture]] — Layer structure
- [[adr-001-layered-architecture]] — Architecture decision
- [[adr-002-aggregator-pattern]] — Aggregator decision
- [[build-system]] — Build configuration
- [[projects/Index]] — All project docs index
- [[project-index]] — Complete project list
- [[layer-index]] — Layer breakdown
- [[Generator Pattern]] — Generator architecture
- [[Testing-Strategy]] — Testing approach
- [[Cross-Cutting-Concerns]] — Cross-cutting docs
