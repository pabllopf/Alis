---
title: Dependency Index
tags:
  - index
  - catalog
  - reference

status: draft
---


## Overview
Complete dependency mapping for all 140+ projects in the ALIS repository.

## Dependency Rules

### Layer Dependency Order (Strict)

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

**Rules**:
- Lower layers NEVER depend on higher layers
- Dependencies flow from Presentation → Ideation
- Cross-layer dependencies must follow this order

## Layer Dependencies

### 1_Presentation Depends On

- 2_Application (Alis)
- 3_Structuration (Core abstractions)
- 4_Operation (Runtime implementations)
- 5_Declaration (Contracts)
- 6_Ideation (Game-specific logic)

### 2_Application Depends On

- 3_Structuration (Core abstractions)
- 4_Operation (Runtime implementations)
- 5_Declaration (Contracts)
- 6_Ideation (Game-specific logic)

### 3_Structuration Depends On

- None (foundation layer)

### 4_Operation Depends On

- 3_Structuration (Core abstractions)
- 5_Declaration (Contracts)
- 6_Ideation (Aspects)

### 5_Declaration Depends On

- 3_Structuration (Core abstractions)
- 4_Operation (Runtime implementations)

### 6_Ideation Depends On

- 3_Structuration (Core abstractions)
- 4_Operation (Runtime implementations)
- 5_Declaration (Contracts)

## Project Dependencies

### Core Engine (4_Operation)

| Project | Dependencies |
|---|---|
| Alis.Core.Ecs | Alis.Core.Aspect.Math.Collections, Alis.Core.Ecs.Kernel, Alis.Core.Ecs.Redifinition |
| Alis.Core.Graphic | Alis.Core.Aspect (all aspects) |
| Alis.Core.Audio | Alis.Core.Aspect (all aspects) |
| Alis.Core.Physic | Alis.Core.Aspect (all aspects) |

### Ideation Aspects (6_Ideation)

| Project | Dependencies |
|---|---|
| Alis.Core.Aspect.Memory | Alis.Core, Alis.Core.Aspect |
| Alis.Core.Aspect.Fluent | Alis.Core, Alis.Core.Aspect |
| Alis.Core.Aspect.Data | Alis.Core, Alis.Core.Aspect |
| Alis.Core.Aspect.Math | Alis.Core, Alis.Core.Aspect |
| Alis.Core.Aspect.Time | Alis.Core, Alis.Core.Aspect |
| Alis.Core.Aspect.Logging | Alis.Core, Alis.Core.Aspect |

### Extensions (1_Presentation)

| Project | Dependencies |
|---|---|
| Alis.Extension.Security | Alis.Core, Alis.Core.Aspect |
| Alis.Extension.Network | Alis.Core, Alis.Core.Aspect |
| Alis.Extension.Media.FFmpeg | Alis.Core, Alis.Core.Aspect |
| Alis.Extension.Language.Translator | Alis.Core, Alis.Core.Aspect |
| Alis.Extension.Language.Dialogue | Alis.Core, Alis.Core.Aspect |

## Build System Dependencies

### Config.props

- Multi-targeting: 15+ frameworks (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- Runtime identifiers: Windows, Linux, macOS, Web
- Analyzers: Enabled for all projects

### Asset Pipeline

- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Platform Targets

- **Windows**: win-x64, win-x86, win-arm64
- **Linux**: linux-x64, linux-musl-x64, linux-arm, linux-arm64, linux-musl-arm, linux-musl-arm64
- **macOS**: osx-x64, osx-arm64
- **Web**: browser-wasm

## Framework Targets

- .NET Core 2.0–3.1
- .NET 5–10
- .NET Standard 2.0–2.1
- .NET Framework 4.61–4.81

## AOT Compatibility

- No `System.Reflection.Emit`
- No runtime IL emit
- No dynamic method generation
- Source generators produce AOT-safe code

## Related

- [[architecture/dependency-graph]] — Dependency diagrams
- [[system/state/analysis-state]] — Analysis state
- [[projects-index]] — All projects indexed
- [[layer-index]] — Layer breakdown
