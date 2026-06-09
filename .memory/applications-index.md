---
title: Applications Index
tags:
  - application
  - software
  - tool
lastUpdated: 2026-06-09

status: draft

license: GPLv3
---


## Overview

Alis provides 4 applications that serve as tools, editors, and launchers for the game engine ecosystem.

## Applications

### [[engine-editor|Alis.App.Engine]]

| Property | Value |
|----------|-------|
| **Type** | Game Editor |
| **Layer** | 1_Presentation |
| **UI Framework** | ImGui |
| **Features** | Scene editing, asset management, debugging |

The primary game editor for Alis. Provides a comprehensive visual development environment with multiple windows for scene editing, asset management, and runtime debugging.

**Key Features:**
- Scene editor with entity hierarchy
- Inspector for component properties
- Console for logging
- Asset browser
- Audio player
- Solution/project management
- Built-in demos

### [[hub|Alis.App.Hub]]

| Property | Value |
|----------|-------|
| **Type** | Project Launcher |
| **Layer** | 1_Presentation |
| **UI Framework** | SDL2 |
| **Features** | Project management, updates, community |

Standalone launcher for managing Alis projects, accessing documentation, and community resources. Serves as the central entry point for users.

**Key Features:**
- Project creation and management
- Release downloads and updates
- Community links
- Documentation access
- Editor installation

### [[installer|Alis.App.Installer]]

| Property | Value |
|----------|-------|
| **Type** | Installation Wizard |
| **Layer** | 1_Presentation |
| **UI Framework** | Console/GUI |
| **Features** | Installation, updates, uninstallation |

Provides installation, update, and uninstallation capabilities for the Alis game engine and related components.

**Key Features:**
- Component selection
- Progress tracking
- Rollback support
- Registry management (Windows)
- Uninstallation

### [[benchmark|Alis.Benchmark]]

| Property | Value |
|----------|-------|
| **Type** | Performance Testing |
| **Layer** | 2_Application |
| **Framework** | BenchmarkDotNet |
| **Features** | ECS comparisons, memory diagnostics |

Comprehensive performance comparisons between Alis ECS and other popular Entity Component System libraries.

**Key Features:**
- Entity creation benchmarks
- Component access benchmarks
- System execution benchmarks
- Memory allocation analysis
- Multi-library comparison

## Application Architecture

```
┌─────────────────────────────────────────────────────────┐
│                  Presentation Layer (1)                  │
├─────────────┬─────────────┬─────────────┬───────────────┤
│    Engine   │     Hub     │  Installer  │   Benchmark   │
│   (ImGui)   │   (SDL2)    │  (Console)  │(BenchmarkDotNet)│
└─────────────┴─────────────┴─────────────┴───────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────┐
│                  Application Layer (2)                  │
├─────────────────────────────────────────────────────────┤
│                    Alis.Core                            │
└─────────────────────────────────────────────────────────┘
```

## Build Targets

| Application | Desktop | Web | Notes |
|-------------|---------|-----|-------|
| Engine | ✅ | ❌ | ImGui requires native |
| Hub | ✅ | ❌ | SDL2 desktop only |
| Installer | ✅ | ❌ | System access required |
| Benchmark | ✅ | ❌ | BenchmarkDotNet required |

## Running Applications

```bash
# Run Engine Editor
dotnet run --project Alis.App.Engine

# Run Hub
dotnet run --project Alis.App.Hub

# Run Installer
dotnet run --project Alis.App.Installer

# Run Benchmark
dotnet run -c Release --project Alis.Benchmark
```

## Related

- [[extensions-index|Extensions Index]]
- [[samples-index|Samples Index]]
- [[architecture/repository-overview|Repository Overview]]
- [[onboarding/getting-started|Getting Started]]

## Cross-References

- [[concepts-index|Concepts Index]] - Core architectural concepts
- [[glossary-index|Glossary Index]] - Terminology for applications
- [[projects-index|Projects Index]] - Project documentation
