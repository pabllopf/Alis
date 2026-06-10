---
title: Architecture Overview
tags:
  - architecture
  - clean-architecture
  - layered
  - game-engine
  - ecs
status: Draft
license: GPLv3
---

# Architecture Overview

## Architectural Style

Alis uses a strict **6-layer clean architecture** with unidirectional dependencies. Higher layers depend on lower layers only — never the reverse.

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

## Dependency Flow

```
┌─────────────────────────────────────────────────────────────────────────┐
│                        1_Presentation (69 projects)                     │
│  Engine, Extensions (Ads, Cloud, Graphic, Network, Payment, Media...)  │
├─────────────────────────────────────────────────────────────────────────┤
│                        2_Application (30 projects)                      │
│  Alis core library + sample games                                      │
├─────────────────────────────────────────────────────────────────────────┤
│                      3_Structuration (3 projects)                       │
│  Core abstractions, base infrastructure                                │
├─────────────────────────────────────────────────────────────────────────┤
│                      4_Operation (14 projects)                          │
│  Graphics, Audio, Physics, ECS operations                              │
├─────────────────────────────────────────────────────────────────────────┤
│                      5_Declaration (3 projects)                         │
│  Contracts, interfaces, metadata                                       │
├─────────────────────────────────────────────────────────────────────────┤
│                      6_Ideation (21 projects)                           │
│  Experimental modules (Data, Fluent, Logging, Math, Memory, Time)      │
└─────────────────────────────────────────────────────────────────────────┘
```

## Layer Responsibilities

### Layer 1 — Presentation

**Role**: User-facing applications, platform integrations, and extension modules.

**Patterns**:
- Executable applications (Engine, Hub, Installer)
- Platform-specific build targets (macOS bundles, Linux/Windows zips)
- External service integrations (Stripe, Google Ads, Dropbox, FFmpeg)
- Source generator consumers

**Key insight**: The Engine project uses glob-based ProjectReferences to collect all generator projects across layers 4 and 6.

### Layer 2 — Application

**Role**: Application composition and business logic orchestration.

**Patterns**:
- Single main library (`Alis.csproj`) consumed by all samples
- Sample games demonstrate engine capabilities
- Platform-specific sample variants (Web/Desktop)

### Layer 3 — Structuration

**Role**: Foundation core with shared abstractions used across all layers.

**Patterns**:
- Base types and interfaces
- Common utilities
- Cross-cutting concerns

### Layer 4 — Operation

**Role**: Platform-specific operations for graphics, audio, physics, and ECS.

**Patterns**:
- Each module follows test/generator/sample/src structure
- Source generators produce ECS/component code
- Native API bindings for graphics/audio

### Layer 5 — Declaration

**Role**: Contract definitions and interface declarations.

**Patterns**:
- Pure interface definitions
- Metadata contracts
- Aspect declarations

### Layer 6 — Ideation

**Role**: Experimental and research modules.

**Patterns**:
- Standard test/generator/sample/src structure per module
- Source generators for code generation
- Self-contained experimental features

## Source Generator Architecture

Source generators are a first-class architectural element. They:

1. Target `netstandard2.0` exclusively
2. Produce AOT-safe generated code
3. Emit diagnostics with ALIS0xxx IDs
4. Are consumed via Analyzer ProjectReferences

Generator locations:
- `4_Operation/*/generator/` — ECS, Graphic generators
- `6_Ideation/*/generator/` — Memory, Data, Fluent generators

## Asset Pipeline

The Engine implements a custom asset packing system:

1. **Manifest generation**: SHA256 hashes of all assets in `Assets/` folder
2. **ZIP creation**: Assets compressed into `assets.zip`
3. **Base64 embedding**: ZIP converted to base64 string in `assets.pack`
4. **Incremental builds**: MSBuild inputs/outputs prevent unnecessary regeneration

## Platform Abstraction

Platform detection uses MSBuild conditions:

```xml
LINUX defined when: RuntimeIdentifier starts with ubuntu/debian/alpine/etc.
OSX defined when: RuntimeIdentifier starts with osx
WIN defined when: RuntimeIdentifier starts with win
```

Runtime-specific output goes to: `bin/{Configuration}/{RuntimeIdentifier}/lib/`

## Related

- [[repository-overview]]
- [[project-graph]]
- [[dependency-rules]]
- [[conventions-and-standards]]
