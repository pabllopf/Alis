---
title: Repository Overview
tags:
  - overview
  - architecture
  - repository
status: Draft
license: GPLv3
---

# Repository Overview

> ALIS Game Engine - Cross-platform C# game engine framework

## High-Level Architecture

The repository is organized as a **6-layer clean architecture** monorepo with **140+ projects**:

| Layer | Directory | Projects | Purpose |
|---|---|---|---|
| 1 - Presentation | `1_Presentation/` | 22+ | User-facing apps, extensions, samples |
| 2 - Application | `2_Application/` | 1+ | Application composition |
| 3 - Structuration | `3_Structuration/` | 1+ | Core structuration |
| 4 - Operation | `4_Operation/` | 4 | Runtime operations |
| 5 - Declaration | `5_Declaration/` | 1 | Aspect-oriented contracts |
| 6 - Ideation | `6_Ideation/` | 6 | Experimental/utility modules |

## Technology Stack

| Component | Technology |
|---|---|
| Language | C# (.NET) |
| Frameworks | net461 through net10.0, netstandard2.0-2.1, netcoreapp2.0-3.1 |
| Architecture Patterns | ECS, Aspect-Oriented, CQRS, Clean Architecture |
| Source Generators | Roslyn-based (14 generator projects) |
| Graphics Backends | SDL2, SFML, GLFW, Custom UI, Vulkan |
| Build System | MSBuild with custom .props/.targets |
| Testing | xUnit (34 test projects) |
| CI/CD | GitHub Actions |

## Bounded Contexts

| Context | Layer | Key Projects |
|---|---|---|
| Engine Core | Presentation | Alis.App.Engine, Alis.App.Hub |
| Runtime | Operation | ECS, Audio, Graphic, Physic |
| Aspect Framework | Declaration | Alis.Core.Aspect |
| Utility | Ideation | Data, Fluent, Logging, Math, Memory, Time |
| Extensions | Presentation | Network, Security, Graphic.*, Payment.*, etc. |
| Samples | Application | 12 sample games |

## Architectural Rules

1. **Strict Layer Dependency**: Each layer depends only on the layer directly below it
2. **Aspect Foundation**: Layer 6 (Ideation) provides fundamental aspects used by all layers
3. **Generator Pattern**: Each module has a paired source generator project
4. **Multi-Platform**: Built for Windows, macOS, Linux, Web (WASM), Android, iOS
5. **Multi-Framework**: Targets 15+ .NET frameworks simultaneously

## Key Architectural Patterns

- **Entity-Component System (ECS)**: Core architectural pattern in `Alis.Core.Ecs`
- **Aspect-Oriented Programming**: Cross-cutting concerns via `Alis.Core.Aspect`
- **Source Generators**: Roslyn generators for code generation at compile time
- **Service Pattern**: Modular services for audio, graphics, physics, networking
- **Extension Pattern**: Pluggable extensions for graphics backends, cloud services, payments

## Risk Areas

| Risk | Severity | Description |
|---|---|---|
| Build Complexity | High | Complex MSBuild props/targets with conditional compilation |
| Multi-Framework | High | Supporting 15+ frameworks simultaneously |
| Cross-Platform | High | Supporting 8+ platforms with native bindings |
| Test Coverage | Medium | 34 test projects but need coverage analysis |
| Generator Coupling | Medium | Source generators tightly coupled to their modules |

## Related

- [[Architecture Overview]]
- [[Projects Index]]
- [[Dependency Index]]
- [[Technology Stack]]
