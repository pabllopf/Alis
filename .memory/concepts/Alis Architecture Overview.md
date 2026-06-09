---
title: Alis Architecture Overview
tags:
  - concept
  - theory
  - documentation

status: draft

license: GPLv3
---


Alis is a C# game engine/framework with a modular 6-layer architecture, aspect-oriented design, and aggressive multi-targeting strategy.

## Architecture Layers

### 1_Presentation - User-Facing Applications
- **Engine** - Main runtime engine
- **Hub** - Hub application
- **Installer** - Installation application
- **Extension/** - 18+ modular extensions:
  - Graphics (Ui, Sfml, Glfw, Sdl2)
  - Cloud (DropBox, GoogleDrive)
  - Payment (Stripe)
  - Math (ProceduralDungeon, HighSpeedPriorityQueue)
  - Media (FFmpeg)
  - Network, Thread, Security, Ads, etc.

### 2_Application - Main Application & Samples
- **Alis/src** - Main application entry point
- **samples/** - 12 sample games (Web + Desktop variants, some with mobile)

### 3_Structuration - Core Foundations
- **Core/** - Foundational abstractions and libraries

### 4_Operation - Operational Systems
- **Ecs/** - Entity Component System with source generator
- **Graphic/** - Graphics rendering with source generator
- **Audio/** - Audio processing
- **Physic/** - Physics engine

### 5_Declaration - Declarative Foundation
- **Aspect/** - Core.Aspect - declarative programming foundation

### 6_Ideation - Experimental Aspects
- **Memory/** - Memory abstractions with source generator
- **Fluent/** - Fluent APIs with source generator
- **Math/** - Mathematical utilities
- **Time/** - Time management
- **Data/** - Data structures with source generator
- **Logging/** - Logging infrastructure

## Solution Files (8 .slnx)

| File | Purpose |
|------|---------|
| `alis.slnx` | Full solution - all projects |
| `alis.core.slnx` | Core libraries only |
| `alis.apps.slnx` | Applications (Engine, Hub, Installer) |
| `alis.extensions.slnx` | All extensions |
| `alis.test.slnx` | Test projects |
| `alis.samples.slnx` | Sample games |
| `alis.core.aspect.slnx` | Declaration + Ideation layers |
| `alis.benchmark.slnx` | Benchmark project |

## Key Design Principles

1. **Layered by abstraction**: Presentation (concrete) → Ideation (abstract)
2. **Aspect-oriented**: Core.Aspect as foundation, experimental aspects on top
3. **Modular solutions**: 8 different .slnx for different build targets
4. **Multi-targeting**: 15+ framework configurations (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
5. **Multi-platform**: Web (browser-wasm), Desktop (win/linux/osx), Mobile (iOS/Android)
6. **Source generators**: ECS, Graphic, Memory, Data, Fluent use compile-time code generation
7. **Centralized configuration**: `.config/Config.props` for all build settings

## Technology Stack

- **Language**: C# 13
- **Testing**: xUnit + Xunit.StaFact + Moq
- **Static Analysis**: SonarQube + .NET Analyzers
- **Source Link**: Microsoft.SourceLink.GitHub for debugging
- **Coverage**: Coverlet

## See Also
- [[Layered Architecture]]
- [[Aspect-Oriented Design]]
- [[Solution Composition]]
- [[Generator Pattern]]
- [[Multi-Platform Samples]]
- [[Multi-Targeting Strategy]]
- [[Extension System]]
- [[Entity Component System]]
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]
- [[Platform-Specific Build Constants]]

## Related Architecture

- [[repository-overview]] — Full architecture overview
- [[architecture/dependency-graph]] — Dependency rules and flow
- [[build-system]] — Build configuration details
- [[adr-001-layered-architecture]] — Six-layer ADR
- [[adr-002-aggregator-pattern]] — Aggregator ADR

## Related Projects

- [[projects/Index]] — Project documentation index
- [[projects/Architecture]] — Detailed layer documentation

## Related Analysis

- [[testing-overview]] — Testing strategy
- [[security-overview]] — Security risks
- [[onboarding/getting-started]] — Developer onboarding
- [[ai-context]] — AI agent reference
