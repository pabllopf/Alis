# Repository Overview

tags:
  - summary,overview,documentation

Comprehensive overview of the Alis solution architecture and structure.

## Solution Summary

**Alis** is a C# game engine/framework with:
- **140+ projects** across 6 architectural layers
- **8 modular .slnx solution files** for focused builds
- **15+ target frameworks** (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- **Multi-platform support** (Windows, Linux, macOS, WebAssembly, iOS, Android)
- **Source generators** for AOT-safe code generation

## Architecture Layers

### 1_Presentation - User-Facing Applications
- **Engine** - Main game engine runtime
- **Hub** - Hub application for management
- **Installer** - Installation application
- **Extension/** - 18+ modular extensions (Graphics, Cloud, Payment, etc.)
- **Benchmark** - Performance benchmarks

### 2_Application - Main Application & Samples
- **Alis/src** - Main application entry point
- **samples/** - 12+ sample games (Web + Desktop variants)

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
- **Data/** - Data structures with source generator
- **Math/** - Mathematical utilities
- **Time/** - Time management
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

## Technology Stack

- **Language**: C# 13
- **Testing**: xUnit + Xunit.StaFact + Moq
- **Static Analysis**: SonarQube + .NET Analyzers
- **Source Link**: Microsoft.SourceLink.GitHub
- **Coverage**: Coverlet

## Key Features

1. **Multi-Targeting** - 15+ framework configurations
2. **Multi-Platform** - Desktop, Web, Mobile support
3. **Source Generators** - AOT-safe compile-time code generation
4. **ECS Architecture** - Entity Component System for game logic
5. **Aspect-Oriented Design** - Core.Aspect as declarative foundation
6. **Modular Solutions** - 8 .slnx files for focused builds
7. **No External NuGet** - Only standard .NET and native APIs

## Documentation Coverage

| Category | Files | Status |
|----------|-------|--------|
| Concepts | 21 | ✅ Complete |
| Sources | 12 | ✅ Complete |
| Architecture | 7+ | ✅ Complete |
| Projects | 150+ | 🔄 In Progress |
| Dependencies | 15+ | ✅ Complete |

## See Also
- [[Layered Architecture]]
- [[Multi-Targeting Strategy]]
- [[Generator Pattern]]
