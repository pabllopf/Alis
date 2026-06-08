# ALIS Game Engine Framework - Repository Overview

## Executive Summary

**ALIS** is a comprehensive game engine framework written in C# with 140+ projects organized into 6 major layers. This document provides a high-level overview of the architecture, modules, and key components.

## Architecture Layers

### 1_Presentation - User Interface Layer (23 projects)

Applications and extensions for game engines:

| Project | Type | Description |
|---------|------|-------------|
| Alis.App.Engine | Application | Main game engine application |
| Alis.App.Hub | Application | Hub/manager application |
| Alis.App.Installer | Application | Installer utility |
| Alis.Benchmark | Benchmark | Performance benchmarking |
| Alis.Extension.* | Extension | Platform bindings and utilities |

**Extensions**: GoogleAds, Security, Stripe, Network, FileDialog, Updater, Language.Translator, Language.Dialogue, Math.ProceduralDungeon, Math.HighSpeedPriorityQueue, Graphic.Ui, Graphic.Sfml, Graphic.Glfw, Graphic.Sdl2, Profile, Cloud.DropBox, Cloud.GoogleDrive, Thread, Media.FFmpeg

### 2_Application - Game Applications (14 projects)

Sample games and applications built with ALIS:

- Alis.App.Core - Core application framework
- Alis.Sample.* - ~13 sample games (Flappy Bird, Pong, Dino, Space Simulator, etc.)

### 3_Structuration - Core Aggregator (5 projects)

Core engine subsystems:

| Project | Status | Files |
|---------|--------|-------|
| Alis.Core | Aggregator | - |
| Alis.Core.Ecs | Documented | 108 files |
| Alis.Core.Graphic | Documented | 147 files |
| Alis.Core.Audio | Documented | 7 files |
| Alis.Core.Physic | Documented | 194 files |

**ECS (Entity Component System)**: Core game object management with 108 source files including Entity, Scene, GameObject, Query systems

**Graphic**: Rendering subsystem with 147 files including shaders, textures, meshes, materials

### 4_Operation - Engine Subsystems (16 projects)

Low-level engine operations:

- **Ecs**: Entity Component System (documented - 108 files)
- **Graphic**: Rendering engine (documented - 147 files)
- **Audio**: Cross-platform audio player (documented - 7 files)
- **Physic**: 2D physics engine (documented - 194 files)
- **Input**, **Resource**, **Scene**, **Serialization**, **Window**: Other subsystems

### 5_Declaration - Aspect System (1 project)

| Project | Description |
|---------|-------------|
| Alis.Core.Aspect | Aspect-oriented programming aggregator |

### 6_Ideation - Aspect Definitions (24 projects)

Aspect implementations with source generators:

| Project | Type | Status | Files |
|---------|------|--------|-------|
| Alis.Core.Aspect.Memory | Asset management | Documented | 3 files |
| Alis.Core.Aspect.Fluent | Fluent builder API | Documented | 128+ files |
| Alis.Core.Aspect.Data | JSON serialization | Documented | 18 files |
| Alis.Core.Aspect.Math | Math primitives | Documented | 29 files |
| Alis.Core.Aspect.Time | Time measurement | Documented | 1 file |
| Alis.Core.Aspect.Logging | Structured logging | Documented | 24 files |

**Memory**: ZIP-based asset management with dual-cache strategy (in-memory + disk)

**Fluent**: Word pattern with 120+ marker interfaces for fluent builder API

**Data**: Custom JSON parser with source generator for AOT compatibility

**Math**: Value-type vectors, matrices, shapes with zero GC pressure

**Time**: High-resolution clock for timing measurements

**Logging**: Structured logging with pluggable filters/formatters/outputs

## Technology Stack

- **Language**: C# (.NET 4.6.1 - .NET 9.0)
- **Architecture**: Layered + Aspect-Oriented Programming
- **Patterns**: ECS, Builder, Fluent Interface, Source Generators
- **Serialization**: Custom JSON parser (AOT-compatible)
- **Math**: Value types with StructLayout(Pack=1) for cache efficiency

## Key Features

1. **ECS Architecture**: Entity Component System for game object management
2. **Cross-Platform**: Windows, macOS, Linux, WebAssembly support
3. **AOT Compatible**: No reflection at runtime, source generators for compile-time code generation
4. **High Performance**: Value types, zero GC pressure on hot paths
5. **Modular Design**: 140+ projects organized in 6 layers

## Documentation Status

| Layer | Projects | Documented | Pending |
|-------|----------|------------|---------|
| 4_Operation (Core) | 16 | 4 | 12 |
| 6_Ideation (Aspects) | 24 | 6 | 0 |
| 1_Presentation (Extensions) | 23 | 0 | 23 |
| 2_Application (Samples) | 14 | 0 | 14 |
| **Total** | **140** | **10** | **130** |

## Next Steps

1. Process Extensions (1_Presentation/Extension) - ~20 projects
2. Process Applications and Samples (~40 projects)
3. Generate dependency graphs and architecture diagrams
4. Update AI context files for future agents

## Related Documentation

- [[Alis.Core.Ecs]] - Entity Component System
- [[Alis.Core.Graphic]] - Rendering engine
- [[Alis.Core.Audio]] - Cross-platform audio
- [[Alis.Core.Physic]] - 2D physics engine
- [[Alis.Core.Aspect.Fluent]] - Fluent builder API
- [[Alis.Core.Aspect.Math]] - Math primitives
