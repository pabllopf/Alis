---
title: Repository Overview
tags:
  - overview
  - architecture
  - game-engine
  - monorepo
status: Draft
license: GPLv3
---

# Alis Repository Overview

## Summary

**Alis** is a cross-platform game engine and development framework built entirely in C# .NET. It follows a strict 6-layer clean architecture with 140 projects, 3319 C# source files, and comprehensive multi-targeting across 15+ .NET frameworks.

## Repository Statistics

| Metric | Value |
|---|---|
| Total Projects | 140 |
| Solution Files | 10 |
| C# Source Files | 3319 |
| Test Projects | 35 |
| Source Generators | 5 |
| Architectural Layers | 6 |
| Target Frameworks (Release) | 19 |
| Target Frameworks (Debug) | 6 |
| Runtime Identifiers | 15 |

## Architectural Layers

```
1_Presentation (69 projects) → 2_Application (30) → 3_Structuration (3) → 4_Operation (14) → 5_Declaration (3) → 6_Ideation (21)
```

### Layer 1: Presentation (69 projects)

The engine and extension layer. Contains executable applications, UI extensions, and platform integrations.

| Submodule | Description |
|---|---|
| Engine | Core game engine executable with asset packing, platform-specific bundling (macOS .app, Linux zip, Windows zip) |
| Extension/Ads | Google Ads integration |
| Extension/Cloud | Dropbox, Google Drive cloud storage |
| Extension/Graphic | GLFW, SDL2, SFML, UI rendering backends |
| Extension/Io | File dialog integration |
| Extension/Language | Dialogue system, translation |
| Extension/Math | Priority queue, procedural dungeon generation |
| Extension/Media | FFmpeg multimedia |
| Extension/Network | Networking (servers/clients for games and chat) |
| Extension/Payment | Stripe payment integration |
| Extension/Profile | User profile management |
| Extension/Security | Security utilities |
| Extension/Thread | Threading utilities |
| Extension/Updater | Application update mechanism |
| Hub | Application hub/editor with IDE-like functionality |
| Installer | Cross-platform installer |
| Benchmark | Performance benchmarks (ECS comparisons: SveltoECS vs Myriad) |

### Layer 2: Application (30 projects)

Application composition layer. Contains the main `Alis` library and sample games.

| Submodule | Description |
|---|---|
| Alis/src | Core application library (main entry point for all samples) |
| Alis/samples | 16+ sample games (Flappy Bird, Pong, Snake, Space Simulator, King Platform, Rogue, etc.) |

### Layer 3: Structuration (3 projects)

Core abstractions and base infrastructure.

| Project | Description |
|---|---|
| Alis.Core | Foundation core with base types, patterns, and abstractions |

### Layer 4: Operation (14 projects)

Platform operations: graphics, audio, physics, ECS.

| Submodule | Description |
|---|---|
| Audio | Audio operations and manipulation |
| Ecs | Entity Component System with source generator |
| Graphic | Graphics rendering operations with source generator |
| Physic | Physics simulation operations |

### Layer 5: Declaration (3 projects)

Contracts, interfaces, and metadata declarations.

| Submodule | Description |
|---|---|
| Aspect | Aspect declarations and contracts |

### Layer 6: Ideation (21 projects)

Experimental modules with test/sample/generator/src structure.

| Module | Description |
|---|---|
| Data | Data operations and manipulation |
| Fluent | Fluent API builders |
| Logging | Logging infrastructure |
| Math | Mathematical operations |
| Memory | Memory management, asset registry, zip caching |
| Time | Time operations and scheduling |

## Key Technical Characteristics

- **No external NuGet packages** — only standard .NET and native APIs
- **Multi-targeting** — 19 frameworks in Release (netcoreapp2.0–10.0, netstandard2.0–2.1, net461–481)
- **AOT compatible** — no reflection emit or dynamic IL generation
- **Source generators** — 5 generator projects produce AOT-safe code with ALIS0xxx diagnostic IDs
- **C# 13** with nullable disabled, warnings as errors
- **Cross-platform** — Windows, Linux, macOS, WebAssembly, mobile (Android/iOS planned)
- **Asset packing** — custom SHA256-based asset manifest with base64 embedding
- **Platform-specific build targets** — macOS .app bundles, Linux/Windows zip bundling, DMG creation

## Solution Files

| Solution | Purpose |
|---|---|
| alis.slnx | Main solution (335 projects) |
| alis.sln | Legacy solution |
| alis.core.slnx | Core projects only |
| alis.extensions.slnx | Extension projects |
| alis.apps.slnx | Application projects |
| alis.test.slnx | Test projects |
| alis.samples.slnx | Sample projects |
| alis.benchmark.slnx | Benchmark projects |
| alis.core.aspect.slnx | Aspect projects |

## Technology Stack

- **Language**: C# 13
- **Runtime**: .NET Core 2.0–3.1, .NET 5–10, .NET Framework 4.61–4.81
- **Testing**: xUnit + Xunit.StaFact + Moq
- **ECS**: Custom ECS with SveltoECS and Myriad benchmarks
- **Graphics**: GLFW, SDL2, SFML
- **Media**: FFmpeg
- **Payment**: Stripe
- **Cloud**: Dropbox, Google Drive
- **Ads**: Google Ads

## Related

- [[architecture-overview]]
- [[project-structure]]
- [[conventions-and-standards]]
- [[onboarding-guide]]
