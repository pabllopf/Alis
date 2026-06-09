---
title: Projects Index
tags:
  - index
  - catalog
  - reference

status: draft
---


## Overview
Complete index of all 140+ projects in the ALIS repository, organized by architectural layer.

## Project Statistics

| Metric | Value |
|---|---|
| Total csproj files | 140 |
| Total markdown docs | 154 |
| Coverage | 110% (includes samples and tests) |
| Layers | 6 |
| Status | **COMPLETE** ✓ |

## Layer Breakdown

### 1_Presentation (~60 projects)

#### Applications (4)
- [[1_Presentation/Engine]] — Main game engine runtime (net10.0, AOT)
- [[1_Presentation/Hub]] — Game hub/launcher application
- [[1_Presentation/Installer]] — Installation wizard
- [[1_Presentation/Benchmark]] — ECS performance comparisons

#### Extensions (19+)
- [[1_Presentation/Extension-Graphic]] — SFML, GLFW, SDL2, UI backends
- [[1_Presentation/Extension-Io]] — FileDialog and FilePicker
- [[1_Presentation/Extension-Language]] — Translator and Dialogue
- [[1_Presentation/Extension-Math]] — ProceduralDungeon and PriorityQueue
- [[1_Presentation/Extension-Media]] — FFmpeg media processing
- [[1_Presentation/Extension-Network]] — Client/Server networking
- [[1_Presentation/Extension-Profile]] — User profile management
- [[1_Presentation/Extension-Thread]] — Threading utilities
- [[1_Presentation/Extension-Updater]] — Application update mechanism
- [[1_Presentation/Extension-Security]] — Security utilities
- [[1_Presentation/Extension-Ads]] — Google Ads integration
- [[1_Presentation/Extension-Cloud]] — Dropbox, Google Drive
- [[1_Presentation/Extension-Payment]] — Stripe payment processing

#### Samples (28+)
- [[samples/breakout]] — Classic brick-breaking
- [[samples/pong]] — 2-player pong
- [[samples/platformer]] — 2D platformer
- [[samples/shooter]] — Top-down shooter
- [[samples/rpg]] — Turn-based RPG
- [[samples/tetris]] — Puzzle game
- [[samples/snake]] — Classic snake
- [[samples/flappy-bird]] — Tap-to-fly
- [[samples/space-invaders]] — Alien shooter
- [[samples/pac-man]] — Maze game
- [[samples/asteroids]] — Space shooter
- [[samples/breakout-3d]] — 3D breakout
- [[samples/demo]] — Engine features showcase

### 2_Application (~5 projects)

- [[2_Application/Alis]] — Core application library
- [[2_Application/Alis.Test]] — Unit tests for core library
- [[samples]] — Sample applications

### 3_Structuration (~3 projects)

- [[3_Structuration/Core]] — Foundational abstractions
- [[3_Structuration/Alis.Core]] — Core engine abstractions

### 4_Operation (14 projects)

- [[4_Operation/Core]] — Runtime implementations overview
- [[4_Operation/Alis.Core.Audio]] — Audio engine (7 files)
- [[4_Operation/Alis.Core.Ecs]] — Entity Component System (108 files)
- [[4_Operation/Alis.Core.Graphic]] — Graphics rendering (147 files)
- [[4_Operation/Alis.Core.Input]] — Input handling
- [[4_Operation/Alis.Core.Physics]] — Physics simulation (194 files)
- [[4_Operation/Alis.Core.Resource]] — Resource management
- [[4_Operation/Alis.Core.Scene]] — Scene management
- [[4_Operation/Alis.Core.Serialization]] — Data serialization
- [[4_Operation/Alis.Core.Window]] — Window management

### 5_Declaration (5 projects)

- [[5_Declaration/Core]] — Data contracts overview
- [[5_Declaration/Alis.Core.Data]] — Data contracts and DTOs
- [[5_Declaration/Alis.Core.Log]] — Logging infrastructure
- [[5_Declaration/Aspect]] — Aspect contracts

### 6_Ideation (15 projects)

- [[6_Ideation/Core]] — Game-specific functionality overview
- [[6_Ideation/Alis.Core.Game]] — Game logic and state management
- [[6_Ideation/Alis.Core.Network]] — Networked game functionality
- [[6_Ideation/Alis.Core.Aspect.Memory]] — Memory aspect (3 files)
- [[6_Ideation/Alis.Core.Aspect.Fluent]] — Fluent aspect (128+ files)
- [[6_Ideation/Alis.Core.Aspect.Data]] — Data aspect (18 files)
- [[6_Ideation/Alis.Core.Aspect.Math]] — Math aspect (29 files)
- [[6_Ideation/Alis.Core.Aspect.Time]] — Time aspect (1 file)
- [[6_Ideation/Alis.Core.Aspect.Logging]] — Logging aspect (24 files)

## Documentation Status

| Layer | Projects | Docs | Status |
|---|---|---|---|
| 1_Presentation | ~60 | ~76 | ✓ Complete |
| 2_Application | ~5 | ~5 | ✓ Complete |
| 3_Structuration | ~3 | ~2 | ✓ Complete |
| 4_Operation | ~15 | ~14 | ✓ Complete |
| 5_Declaration | ~5 | ~5 | ✓ Complete |
| 6_Ideation | ~15 | ~15 | ✓ Complete |
| **Total** | **140** | **154** | **✓ Complete** |

## Key Patterns

- **Layered Architecture**: 6 layers with strict dependency flow
- **Generator Pattern**: Code generation in each layer
- **Asset Pipeline**: SHA256 → zip → base64 for all projects
- **Platform Detection**: LINUX, OSX, WIN conditional compilation
- **AOT Compilation**: Engine and Hub use NativeAOT
- **Test Discovery**: Regex-based source project auto-discovery
- **Dynamic References**: Glob-based generator project references

## Build Commands

```bash
# Restore dependencies
dotnet restore alis.slnx

# Build solution
dotnet build alis.slnx -c Debug

# Run all tests
dotnet test alis.slnx -c Debug
```

## Related

- [[projects/Index]] — This index
- [[architecture/dependency-graph]] — Dependency diagrams
- [[system/state/analysis-state]] — Analysis state
- [[system/state/project-state]] — Project state
- [[system/state/execution-state]] — Execution state
- [[system/state/pending-work]] — Pending work queue
