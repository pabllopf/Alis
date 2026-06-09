---
title: Alis.Core
tags:
  - structuration
  - core
  - abstraction
  - documentation
status: Draft
license: GPLv3

---


## Overview
Core aggregator library in the Structuration layer. Re-exports all types from 4_Operation (ECS, Graphic, Audio, Physic) into a single assembly for consumption by higher layers. Zero hand-written C# code — pure infrastructure project.

## Project Details
- **Layer**: 3_Structuration
- **Type**: Aggregator Library (Core Engine)
- **Framework**: Multi-targeting via Config.props (all 15+ frameworks)
- **Output**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`
- **Source Code**: Zero `.cs` files — re-exports only

## Purpose
| Role | Description |
|---|---|
| Aggregation | Re-exports all 4_Operation subsystem types as a single assembly |
| Abstractions | Provides unified namespace for engine consumers |
| Decoupling | Higher layers depend only on Alis.Core, not individual subsystems |

## Architecture
```
2_Application / 1_Presentation
        │
        ▼
3_Structuration ─── Alis.Core (aggregator)
        │
        ▼
4_Operation ─── Alis.Core.Ecs, Graphic, Audio, Physic
```

## Re-exported Subsystems
| Subsystem | Type Count | Source Layer |
|---|---|---|
| Alis.Core.Ecs | ~108 files | 4_Operation |
| Alis.Core.Graphic | ~147 files | 4_Operation |
| Alis.Core.Audio | ~7 files | 4_Operation |
| Alis.Core.Physic | ~194 files | 4_Operation |

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: Inherited from Config.props
- **Multi-targeting**: Full range (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- **CI/CD**: 41 workflows (shared from Config.props)

## Notes
- No source code, tests, or samples in the project itself — only project reference aggregation
- Sub-project components (`test/`, `sample/`) exist as separate `.csproj` files
- In Release mode, source files from lower layers are compiled directly into this assembly via `<Compile Include>` directives
- Follows the Aggregator pattern (see [[decisions/adr-002-aggregator-pattern]])

## Related
- [[projects/4_Operation/Ecs]] — ECS subsystem
- [[projects/4_Operation/Graphic]] — Graphic subsystem
- [[projects/4_Operation/Audio]] — Audio subsystem
- [[projects/4_Operation/Physic]] — Physic subsystem
- [[system/indexes/dependency-index]] — Dependency relationships
- [[diagrams/architecture-overview]] — Layer architecture
