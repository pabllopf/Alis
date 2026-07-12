---
title: Layer Architecture Details
tags:
  - architecture
  - layers
  - dependency
status: Draft
license: GPLv3
---

# Layer Architecture Details

## Layer 1: Presentation

**Path:** `1_Presentation/`

The outermost layer containing user-facing applications and extensions.

| Project | Type | Description |
|---|---|---|
| Alis.App.Engine | Application | Game engine host |
| Alis.App.Hub | Application | Hub/launcher application |
| Alis.App.Installer | Application | Platform installer |
| Alis.Benchmark | Benchmark | Performance benchmarks |
| Alis.Extension.Network | Library | Network extension |
| Alis.Extension.Profile | Library | Profiling extension |
| Alis.Extension.Security | Library | Security extension |
| Alis.Extension.Thread | Library | Threading extension |
| Alis.Extension.Updater | Library | Auto-updater extension |

**Dependencies:** All projects reference `2_Application/Alis` + all generators

## Layer 2: Application

**Path:** `2_Application/Alis/`

The main game framework assembly that orchestrates all subsystems.

**Key components:**
- ECS systems and configuration
- Game object management
- Scene management
- Audio, Graphic, Physics integration
- Input handling

**Dependencies:** Layer 3 (Structuration) + generators from layers 3-6

## Layer 3: Structuration

**Path:** `3_Structuration/Core/`

Core abstractions and foundational types for the ECS and module system.

**Dependencies:** Layer 4 (Operation) + generators from layers 4-6

## Layer 4: Operation

**Path:** `4_Operation/`

Engine subsystems implementing core gameplay functionality.

| Module | Description |
|---|---|
| Audio | Sound playback and management |
| Ecs | Entity Component System |
| Graphic | Rendering pipeline |
| Physic | Physics simulation |

**Dependencies:** Layer 5 (Declaration) + generators from layers 5-6

## Layer 5: Declaration

**Path:** `5_Declaration/Aspect/`

Aspect-oriented contracts and interfaces for cross-cutting concerns.

**Dependencies:** Layer 6 (Ideation) + generators from layer 6

## Layer 6: Ideation

**Path:** `6_Ideation/`

Foundation layer providing core data types, algorithms, and utilities.

| Module | Description |
|---|---|
| Data | JSON serialization/deserialization with source generators |
| Fluent | Fluent API builder patterns |
| Logging | Logging infrastructure |
| Math | Vector, matrix, random utilities |
| Memory | Memory management utilities |
| Time | Time measurement and management |

**Dependencies:** None (leaf layer, depends only on .NET BCL)

## Related Documents

- [[repository-overview]]
- [[architecture-overview]]
- [[dependency-graph]]
- [[module-structure]]
