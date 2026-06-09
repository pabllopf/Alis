---
title: Alis.Core.Aspect
tags:
  - declaration
  - contract
  - interface
  - documentation

status: draft
---


## Overview
Aspect-oriented declaration library in the Declaration layer. Pure aggregator project — zero hand-written C# code. Receives all generated types from 6_Ideation source generators (Memory, Fluent, Data, Math, Time, Logging) and 4_Operation generators (ECS, Graphic) into a single assembly.

## Project Details
- **Layer**: 5_Declaration
- **Type**: Aggregator Library (Aspect System)
- **Framework**: `netstandard2.0` (single-target)
- **Output**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`
- **Source Code**: Zero `.cs` files — aggregator only

## Purpose
| Role | Description |
|---|---|
| Aggregation | Re-exports all generated aspect types into one assembly |
| Declaration | Defines type contracts consumed by all higher layers |
| AOT Safety | Generated code avoids `System.Reflection.Emit` and runtime IL |

## Architecture
```
3_Structuration ─── Alis.Core
        │
        ▼
5_Declaration ─── Alis.Core.Aspect (aggregator)
        ▲
        │
6_Ideation Generators ─── Memory, Fluent, Data, Math, Time, Logging
4_Operation Generators ─── Ecs, Graphic
```

## Consumed Generators
| Generator | Generated Types | Source |
|---|---|---|
| Memory.Generator | Resource accessors, `assets.pack` registry | 6_Ideation |
| Fluent.Generator | Builder interfaces (120+ marker interfaces) | 6_Ideation |
| Data.Generator | JSON serialization (IJsonSerializable) | 6_Ideation |
| Ecs.Generator | Component type registry, type metadata | 4_Operation |
| Graphic.Generator | Resource `.gitattributes` generation | 4_Operation |

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: Inherited
- **Multi-targeting**: `netstandard2.0` (same as all generators)
- **Generators referenced as**: `Analyzer` with `PrivateAssets=all`, `ReferenceOutputAssembly=false`

## Related
- [[projects/Generators]] — Generator overview
- [[projects/6_Ideation/Memory]] — Memory aspect
- [[projects/6_Ideation/Fluent]] — Fluent aspect
- [[projects/6_Ideation/Data]] — Data aspect
- [[system/indexes/dependency-index]] — Generator cascade
- [[diagrams/architecture-overview]] — Layer architecture with generators
- [[decisions/adr-002-aggregator-pattern]] — Aggregator pattern
