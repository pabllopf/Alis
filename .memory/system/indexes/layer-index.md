---
title: Layer Index
tags:
  - index
  - catalog
  - reference

status: draft
---


## Overview
Complete documentation of all 6 architectural layers in the ALIS repository.

## Layer Dependency Order (Strict)

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

**Never reverse!** Lower layers never depend on higher layers.

## Layer Details

### 1_Presentation (Layer 1)

**Purpose**: Engine, extensions, UI, runtime frontends

**Projects**: ~60 projects

#### Applications (4)
- **Engine** — Main game engine runtime (net10.0, AOT)
- **Hub** — Game hub/launcher application
- **Installer** — Installation wizard
- **Benchmark** — ECS performance comparisons

#### Extensions (19+)
- **Graphic** — SFML, GLFW, SDL2, UI backends
- **Io** — FileDialog and FilePicker
- **Language** — Translator and Dialogue
- **Math** — ProceduralDungeon and PriorityQueue
- **Media** — FFmpeg media processing
- **Network** — Client/Server networking
- **Profile** — User profile management
- **Thread** — Threading utilities
- **Updater** — Application update mechanism
- **Security** — Security utilities
- **Ads** — Google Ads integration
- **Cloud** — Dropbox, Google Drive
- **Payment** — Stripe payment processing

#### Samples (28+)
- Breakout, Pong, Platformer, Shooter, RPG, Tetris, Snake, Flappy Bird, Space Invaders, Pac-Man, Asteroids, Breakout 3D, Demo

**Documentation**: ~76 docs ✓

### 2_Application (Layer 2)

**Purpose**: Alis, samples, executable compositions

**Projects**: ~5 projects

- **Alis** — Core application library
- **Alis.Test** — Unit tests for core library
- **Samples** — Sample applications

**Documentation**: ~5 docs ✓

### 3_Structuration (Layer 3)

**Purpose**: Core abstractions, base infrastructure

**Projects**: ~3 projects

- **Core** — Foundational abstractions
- **Alis.Core** — Core engine abstractions

**Documentation**: ~2 docs ✓

### 4_Operation (Layer 4)

**Purpose**: Graphics, audio, media, platform operations

**Projects**: ~15 projects

- **Core** — Runtime implementations overview
- **Alis.Core.Audio** — Audio engine (7 files)
- **Alis.Core.Ecs** — Entity Component System (108 files)
- **Alis.Core.Graphic** — Graphics rendering (147 files)
- **Alis.Core.Input** — Input handling
- **Alis.Core.Physics** — Physics simulation (194 files)
- **Alis.Core.Resource** — Resource management
- **Alis.Core.Scene** — Scene management
- **Alis.Core.Serialization** — Data serialization
- **Alis.Core.Window** — Window management

**Documentation**: ~14 docs ✓

### 5_Declaration (Layer 5)

**Purpose**: Contracts, interfaces, metadata

**Projects**: ~5 projects

- **Core** — Data contracts overview
- **Alis.Core.Data** — Data contracts and DTOs
- **Alis.Core.Log** — Logging infrastructure
- **Aspect** — Aspect contracts

**Documentation**: ~5 docs ✓

### 6_Ideation (Layer 6)

**Purpose**: Experimental modules

**Projects**: ~15 projects

- **Core** — Game-specific functionality overview
- **Alis.Core.Game** — Game logic and state management
- **Alis.Core.Network** — Networked game functionality
- **Alis.Core.Aspect.Memory** — Memory aspect (3 files)
- **Alis.Core.Aspect.Fluent** — Fluent aspect (128+ files)
- **Alis.Core.Aspect.Data** — Data aspect (18 files)
- **Alis.Core.Aspect.Math** — Math aspect (29 files)
- **Alis.Core.Aspect.Time** — Time aspect (1 file)
- **Alis.Core.Aspect.Logging** — Logging aspect (24 files)

**Documentation**: ~15 docs ✓

## Documentation Coverage

| Layer | Projects | Docs | Status |
|---|---|---|---|
| 1_Presentation | ~60 | ~76 | ✓ Complete |
| 2_Application | ~5 | ~5 | ✓ Complete |
| 3_Structuration | ~3 | ~2 | ✓ Complete |
| 4_Operation | ~15 | ~14 | ✓ Complete |
| 5_Declaration | ~5 | ~5 | ✓ Complete |
| 6_Ideation | ~15 | ~15 | ✓ Complete |
| **Total** | **140** | **154** | **✓ Complete** |

## Build Configuration

All layers use:
- **LangVersion**: 13
- **Nullable**: enabled/disabled per project
- **AllowUnsafeBlocks**: true for performance-critical code
- **SonarQubeExclude**: true for test projects

## Asset Pipeline

All projects use:
- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Related

- [[architecture/dependency-graph]] — Dependency diagrams
- [[system/state/analysis-state]] — Analysis state
- [[system/state/project-state]] — Project state
- [[projects-index]] — All projects indexed
