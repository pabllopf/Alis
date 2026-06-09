---
title: Architecture Rules
tags:
  - project
  - documentation
  - reference

status: Draft

license: GPLv3

---


## Layer Dependency (Strict, Never Reverse)

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

| Layer | Role | Depends On |
|---|---|---|
| 1_Presentation | Engine, Extensions, UI, Benchmark | 2_Application, 3_Structuration |
| 2_Application | Alis app core, game samples | 3_Structuration |
| 3_Structuration | Core abstractions, base infrastructure | 4_Operation |
| 4_Operation | Graphics, Audio, ECS, Physics | 5_Declaration, 6_Ideation |
| 5_Declaration | Contracts, interfaces, metadata | 6_Ideation |
| 6_Ideation | Experimental aspects (Memory, Fluent, Data, Math, Time, Logging) | nothing (lowest) |

## Critical Constraints

- **No new projects/solutions** — repository structure is fixed at 335 projects
- **No external NuGet packages** — only standard .NET, system libraries, native APIs
- **No `System.Reflection.Emit`** — AOT incompatible. Use source generators instead.
- **No runtime IL emit or dynamic method generation** — AOT compatible code only
- **Source generators must produce AOT-safe code** with ALIS0xxx diagnostic IDs for invalid configurations
- **Dependency direction**: lower layers never depend on higher layers

## Build Constraints

- **Multi-targeting mandatory**: All Release builds target 15+ frameworks (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- **Shared config**: `.config/Config.props` — multi-targeting, runtime identifiers, analyzers
- **Default project props**: `.config/default/`

## Related
- [[diagrams/architecture-overview]] — Visual layer diagram
- [[conventions/dependency-rules]] — Detailed dependency rules
- [[decisions/adr-001-layered-architecture]] — Architecture decision record
