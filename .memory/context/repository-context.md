---
title: Repository Context
tags:
  - context
  - ai
  - repository-map
  - summary
status: Draft
license: GPLv3
---

# Repository Context (AI-Optimized)

## Identity

- **Name**: Alis
- **Type**: Cross-platform C# game framework
- **License**: GPL-3.0
- **Language**: C# 13 (.NET 10.0)
- **Architecture**: 6-layer strict dependency

## Quick Facts

- 81+ projects, 11 solutions
- 200k+ estimated LOC
- 170+ test classes across 13 test projects
- Zero external NuGet deps in core (SourceLink only)
- Multi-targets: `net461` → `net10.0`, `netstandard2.0/2.1`, platform-specific
- Source generators (Roslyn) for JSON serialization, ECS, logging, math, memory, time, fluent
- Cross-platform: Windows, macOS, Linux, WebAssembly, Android, iOS

## Layer Stack

```
1_Presentation (apps, extensions)
    → 2_Application (main Alis assembly)
    → 3_Structuration (Core abstractions)
    → 4_Operation (Audio, ECS, Graphics, Physics)
    → 5_Declaration (Aspect contracts)
    → 6_Ideation (Data, Math, Memory, Time, Logging, Fluent)
```

## Key Source Locations

| Area | Path |
|---|---|
| Main assembly | `2_Application/Alis/src/` |
| ECS engine | `4_Operation/Ecs/src/` |
| Physics engine | `4_Operation/Physic/src/` |
| Graphics engine | `4_Operation/Graphic/src/` |
| Audio engine | `4_Operation/Audio/src/` |
| JSON serialization | `6_Ideation/Data/src/` |
| Math library | `6_Ideation/Math/src/` |
| Logging framework | `6_Ideation/Logging/src/` |
| Editor app | `1_Presentation/Engine/src/` |
| Installer | `1_Presentation/Installer/src/` |
| Hub/launcher | `1_Presentation/Hub/src/` |
| Benchmarks | `1_Presentation/Benchmark/src/` |

## Related Documents

- [[repository-overview]]
- [[architecture-overview]]
- [[conventions-overview]]
