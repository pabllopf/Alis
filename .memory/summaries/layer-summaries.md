---
title: Layer Summaries
tags:
  - summary
  - layers
  - architecture
status: Draft
license: GPLv3
---

# Layer Summaries

## Layer 1: Presentation

**Purpose**: User-facing applications, extensions, and benchmarks.

**Projects**: 23 main projects + 30 sample projects + 6 network samples

| Category | Projects |
|---|---|
| Applications | Engine, Hub, Installer |
| Benchmark | Benchmark (13 benchmark categories) |
| Graphics Extensions | SDL2, SFML, GLFW, UI (ImGui) |
| Cloud Extensions | GoogleDrive, DropBox |
| Payment | Stripe |
| Ads | GoogleAds |
| Media | FFmpeg |
| IO | FileDialog |
| Network | WebSocket client-server |
| Language | Dialogue, Translator |
| Math Extensions | HighSpeedPriorityQueue, ProceduralDungeon |
| System | Security, Thread, Profile, Updater |

**Key patterns**: Native bindings, P/Invoke, platform abstraction

---

## Layer 2: Application

**Purpose**: Application composition root.

**Projects**: 1 main project (Alis) + 13 sample games

**Role**: Assembles all engine systems into a cohesive application. Provides the `VideoGame` fluent builder API.

**Samples**: Asteroid, Dino, Egg, Empty, FlappyBird, Inefable, KingPlatform, Pong, Rogue, RuinsOfTartarus, Snake, SpaceSimulator, SplitCamera

---

## Layer 3: Structuration

**Purpose**: Core structuration bridging Application and Operation layers.

**Projects**: 1 project (Alis.Core)

**Role**: In Debug mode, references Layer 4 operations. In Release mode, compiles Layer 4 source files directly into its assembly.

---

## Layer 4: Operation

**Purpose**: Runtime game systems.

**Projects**: 4 projects (ECS, Audio, Graphic, Physic) — ~356 source files total

| Project | Files | Key Pattern |
|---|---|---|
| **Ecs** | 101 | Archetype-based ECS, 8-byte entity handles, SIMD chunk processing |
| **Audio** | - | Audio service abstraction |
| **Graphic** | ~130 | OpenGL function-pointer binding, 5-platform abstraction |
| **Physic** | ~125 | Box2D-derived, 11 joint types, dynamic tree broadphase |

---

## Layer 5: Declaration

**Purpose**: Aspect-oriented contract declarations.

**Projects**: 1 project (Alis.Core.Aspect)

**Role**: Declares the aspect framework contracts. Empty src/ — source files linked from Layer 6 in Release mode.

---

## Layer 6: Ideation

**Purpose**: Foundational utility modules.

**Projects**: 6 projects — ~60+ source files total

| Project | Files | Purpose |
|---|---|---|
| **Data** | - | JSON serialization |
| **Fluent** | - | Fluent API builders |
| **Logging** | 24 | Pipeline-based logging (5 outputs, 3 formatters, 6 filters) |
| **Math** | - | Vectors, matrices, shapes |
| **Memory** | - | Asset registry, ZIP caching |
| **Time** | - | Clock and timing |

## Source Generators

**12 generator projects** across all layers, generating boilerplate at compile time via Roslyn analyzers.

## Related

- [[Repository Overview]]
- [[Architecture Overview]]
- [[Projects Index]]
- [[Engine Services Overview]]
