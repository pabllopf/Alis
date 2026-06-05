# Exploration: CS File Structure Map

**Date**: 2026-06-05
**Scope**: All `.cs` files across the 6-layer monorepo
**Total .cs files**: 4,278 (2,848 non-test, 1,430 test)

---

## Executive Summary

Alis is a .NET C# 13 monorepo with **4,278 `.cs` source files** distributed across 6 architectural layers. The codebase follows a strict `Alis.*` namespace hierarchy across all layers. The two largest layers are **1_Presentation** (2,150 files, 50.2%) and **4_Operation** (1,109 files, 25.9%), together accounting for 76% of all source. Layer 6_Ideation (589 files) provides foundational abstractions. Layers 3_Structuration and 5_Declaration are thin bridging layers with minimal code (< 20 files each). Tests are embedded within each layer directory and represent 33.4% of all `.cs` files.

---

## Type Distribution by Layer

| Layer | .cs Files | Non-test | Test | Namespaces | Public Types | class | interface | struct | record | enum | Dominant Patterns |
|-------|-----------|----------|------|------------|-------------|-------|-----------|--------|--------|------|-------------------|
| 1_Presentation | 2,150 | 1,496 | 654 | 170+ | 1,454 | 927 | 53 | 280 | 1 | 193 | Extension wrappers, benchmark harnesses, WinAPI/SDL/SFML interop, UI widgets, installer logic |
| 2_Application | 394 | 357 | 37 | 60+ | 188 | 141 | 20 | 24 | 3 | 0 | ECS builder pattern, sample games (Asteroid, Pong, Snake, etc.), system configuration builders |
| 3_Structuration | 18 | 12 | 6 | 2 | 2 | 2 | 0 | 0 | 0 | 0 | Thin structural bridge (Core.Sample, Core.Test) |
| 4_Operation | 1,109 | 619 | 490 | 90+ | 832 | 615 | 12 | 131 | 10 | 64 | ECS kernel (archetypes, events, marshalling), physics engine, OpenGL bindings, audio subsystem |
| 5_Declaration | 18 | 12 | 6 | 3 | 4 | 4 | 0 | 0 | 0 | 0 | Thin aspect declaration bridge (Core.Aspect.Sample, Test) |
| 6_Ideation | 589 | 352 | 237 | 50+ | 404 | 243 | 123 | 34 | 0 | 4 | Data/JSON handling, fluent builder, logging framework, math library (vectors, matrices, shapes), memory management, time/clock |
| **Total** | **4,278** | **2,848** | **1,430** | **375+** | **2,884** | **1,932** | **208** | **469** | **14** | **261** | |

> **Note**: The "Public Types" count uses individual type keyword patterns and may differ slightly from a broader regex scan (2,974 found with expanded modifiers). The 90-type gap likely includes `sealed class`, `static class`, `abstract class`, and `readonly struct` that were already counted under `class`/`struct` in the detailed breakdown.

---

## Namespace Hierarchy

All layers share the **`Alis`** root namespace. No layer uses a custom root prefix.

### Layer Structure

| Layer | Root Namespaces | Key Sub-namespace Patterns |
|-------|----------------|---------------------------|
| 1_Presentation | `Alis.App.*` — apps (Engine, Hub, Installer) | `Alis.App.Engine.{Core,Entity,Fonts,Menus,Windows}` |
| | `Alis.Benchmark.*` — perf benchmarks | `Alis.Benchmark.{ClassVsStruct,EntityComponentSystem,CustomEcs,...}` |
| | `Alis.Extension.*` — third-party integrations | `Alis.Extension.{Graphic.{Glfw,Sdl2,Sfml,Ui},Media.FFmpeg,Network,Thread,Profile,Security,...}` |
| 2_Application | `Alis.Builder.Core.Ecs.*` — ECS builder API | `Alis.Builder.Core.Ecs.{Components.{Audio,Body,Light,...},System.ConfigurationBuilders}` |
| | `Alis.Core.Ecs.*` — ECS core implementations | `Alis.Core.Ecs.{Components.{Audio,Body,Collider,...},Systems.{Configuration,Execution,Manager,Scope}}` |
| | `Alis.Sample.*` — game samples | `Alis.Sample.{Asteroid,Dino,Egg,Empty,FlappyBird,Pong,Snake,...}.{Desktop,Web,IOS,Android}` |
| 3_Structuration | `Alis.Core.Sample` | Minimal — 2 sample namespaces |
| | `Alis.Core.Test` | |
| 4_Operation | `Alis.Core.{Audio,Ecs,Graphic,Physic}.*` | `Alis.Core.Ecs.{Kernel.{Archetypes,Events},Collections,Generator,Marshalling,Updating}` |
| | | `Alis.Core.Graphic.{OpenGL.{Constructs,Delegates,Enums},Platforms.{Android,Linux,Osx,Web,Win},Ui}` |
| | | `Alis.Core.Physic.{Collisions.{Shapes},Common.{ConvexHull,Decomposition,Logic,...},Controllers,Dynamics.{Contacts,Joints}}` |
| | `System.Numerics` | Extra-file namespace (partial struct extensions) |
| | `System.Runtime.{CompilerServices,InteropServices}` | |
| 5_Declaration | `Alis.Core.Aspect.*` | Thin aspect bridge namespace |
| 6_Ideation | `Alis.Core.Aspect.{Data,Fluent,Logging,Math,Memory,Time}.*` | `Alis.Core.Aspect.Data.{Json.{Deserialization,Serialization,Parsing,...}}` |
| | | `Alis.Core.Aspect.Fluent.{Components,Words}` |
| | | `Alis.Core.Aspect.Math.{Vector,Matrix,Shapes.{Circle,Line,Point,Rectangle,Square},Collections}` |
| | | `Alis.Core.Aspect.Logging.{Abstractions,Core,Filters,Formatters,Outputs}` |

### Naming Conventions
- **Root**: `Alis.*` across all layers — clean and uniform
- **Sub-namespace depth**: Typically 3-5 levels deep (e.g., `Alis.Core.Ecs.Kernel.Archetypes`)
- **Test namespaces**: Mirror source namespaces with `.Test` suffix (e.g., `Alis.Core.Ecs.Test.Kernel.Archetypes`)
- **Sample namespaces**: Use `.Sample` suffix alongside source and test

---

## Key Architectural Findings

### 1. Dominance of 1_Presentation (50.2% of all .cs files)
This layer contains:
- **App-level code**: Engine, Hub, Installer
- **Extension integrations**: 18+ extension modules (Graphics: Glfw/Sdl2/Sfml/Ui, Media: FFmpeg, Network client/server, Thread pool, Profile, Security, Cloud storage, Payments, Language translation, Math extensions, Updater)
- **Benchmarks**: 15+ benchmark suites comparing performance characteristics (class vs struct, collections, ECS implementations, iterators)
- **193 enums** (74% of all enums in the project) — mostly in extension wrappers for C interop and OpenGL/API bindings
- **280 structs** (60% of all structs) — consistent with heavy interop/PInvoke patterns

### 2. Interface Concentration in 6_Ideation (59% of all interfaces)
Layer 6_Ideation defines **123 out of 208 interfaces** (59%). This confirms the pattern where foundational abstractions are defined in the lowest layer and consumed by higher layers. Logging alone has a rich abstraction hierarchy (Abstractions namespace with multiple interfaces).

### 3. Lightweight Structural Layers (3 & 5)
Layers 3_Structuration (18 files) and 5_Declaration (18 files) are bridging/glue layers. They contain almost no types — just sample and test scaffolding. This suggests either:
- These layers are intentionally thin (pure structural/declaration contracts imported from NuGet or source generators)
- Or they are still WIP/placeholder layers

### 4. Heavy Struct Usage (469 total — 16% of all public types)
Structs are heavily used in:
- **1_Presentation**: 280 structs (interop structs for Glfw, Sdl2, Sfml, WinAPI)
- **4_Operation**: 131 structs (physics math types, ECS internal data structures)
- **6_Ideation**: 34 structs (Vector, Matrix, math primitives)
- This suggests a performance-conscious codebase that favors value types for hot paths

### 5. Partial Classes (504 instances)
Significant use of `partial` modifier (504 instances) — primarily in:
- ECS generator/archetype code
- Source-generated interop bindings
- Large extension wrapper classes split across files

### 6. No DI Container Registration
No `IServiceCollection`, `AddSingleton`, `AddScoped`, or `AddTransient` patterns found. The project does **not** use a DI container — dependencies appear to be composed manually or via the ECS pattern.

### 7. ECS Architecture in 4_Operation
The ECS subsystem (`Alis.Core.Ecs.*`) is substantial with:
- **Kernel** with archetypes and event system
- **Collections** (custom collections for ECS)
- **Generator** (code generation for ECS components)
- **Marshalling** layer
- **Updating** with runner strategies
- **Systems** base classes

### 8. Physics Engine (4_Operation/Physic)
A comprehensive physics engine with:
- Collision detection with shapes
- Convex hull and decomposition algorithms (CDT — Constrained Delaunay Triangulation)
- Seidel triangulation
- Controllers, joints, and contact dynamics
- Texture tools and polygon manipulation

### 9. Test Density Varies Widely
- **4_Operation**: 44% of files are tests (490/1,109) — strong test coverage
- **1_Presentation**: 30% test density (654/2,150)
- **6_Ideation**: 40% test density (237/589)
- **2_Application**: Only 9% test density (37/394) — lowest among major layers

---

## Risks / Observations

### Consistency Risk
- Layers 3_Structuration and 5_Declaration are near-empty (18 files each). Their purpose vs. 4_Operation and 6_Ideation needs clarification — are they intentionally thin or incomplete?
- The boundary between 2_Application (ECS builder/config logic) and 4_Operation (ECS kernel) has namespace overlap (`Alis.Core.Ecs.*` appears in both), which could create confusion about where new ECS code belongs.

### Maintainability Observations
- 1_Presentation has grown large (2,150 files) with 18+ extension modules. Consider whether module boundaries could be clearer or if some extensions should be separated.
- 261 enums across the codebase, 193 of which are in 1_Presentation — mostly for interop/API constants. These are well-organized within their respective module namespaces.
- 504 `partial` class usages suggest active use of code generation, especially in the ECS and interop layers.

### Test Coverage
- 33.4% overall test file density is reasonable but uneven. The 2_Application layer at 9% test density (37/394) is a blind spot for the most integration-critical code (game samples and builder pipeline).

### No Modern DI or Hosting Patterns
- Absence of DI container or Microsoft.Extensions.Hosting patterns suggests the project follows a custom composition model (likely ECS-driven or manual). This is a deliberate architectural choice but means standard .NET dependency injection conventions don't apply.

---

## Files Created

- `openspec/specs/exploration-cs-structure.md`
- Engram observation (topic_key: `sdd/explore/cs-structure`)
