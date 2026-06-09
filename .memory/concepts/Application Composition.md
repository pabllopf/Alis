---
title: Application Composition
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Alis organizes applications and samples across multiple layers with clear separation of concerns.

## Application Layers

### 1_Presentation - User-Facing Applications
| Application | Purpose |
|-------------|---------|
| **Engine** | Main game engine runtime |
| **Hub** | Hub application for management and coordination |
| **Installer** | Installation application for deployment |

### 2_Application - Main Application & Samples
| Component | Purpose |
|-----------|---------|
| **Alis/src** | Main application entry point and composition |
| **samples/** | 12 sample games demonstrating capabilities |

## Sample Games Overview

| Sample | Type | Platforms | Key Features |
|--------|------|-----------|--------------|
| King.Platform | Platformer | Web, Desktop | Platform mechanics, physics |
| Flappy.Bird | Arcade | Web, Desktop | Simple arcade gameplay |
| Space.Simulator | Simulation | Web, Desktop | Space simulation, physics |
| Dino | Runner | Web, Desktop | Endless runner mechanics |
| Empty | Template | Web, Desktop | Minimal template project |
| Pong | Arcade | Web, Desktop | Classic Pong implementation |
| SplitCamera | Camera Demo | Web, Desktop | Advanced camera system |
| Asteroid | Shooter | Web, Desktop, iOS, Android | Space shooter, mobile support |
| Rogue | Roguelike | Web, Desktop | Procedural generation, turn-based |
| Snake | Arcade | Web, Desktop | Classic Snake game |
| RuinsOfTartarus | RPG Demo | Web, Desktop | RPG mechanics, dungeon exploration |
| Egg | Abstract | Web, Desktop | Abstract game mechanics |
| Inefable | Abstract | Web, Desktop | Experimental gameplay |

## Platform Variants

Each sample includes:
- `web/` - Blazor WebAssembly version for browsers
- `desktop/` - Desktop application version (Windows, Linux, macOS)
- Some include mobile variants:
  - `ios/` - iOS native version
  - `android/` - Android native version

## Platform-Specific Features

Samples demonstrate:
- Cross-platform input handling
- Platform-specific optimizations
- Mobile touch controls
- Desktop keyboard/mouse controls
- WebAssembly limitations and workarounds

## See Also
- [[Multi-Platform Samples]]
- [[Layered Architecture]]
- [[Repository Structure]]

## Related
- [[Alis Architecture Overview]] — Full architecture
- [[Extension System]] — Extensions in application layer
- [[Solution Files Strategy]] — Solution organization
- [[Developer Onboarding]] — Running samples
- [[projects/Index]] — All project docs
- [[onboarding/getting-started]] — Quick start guide
