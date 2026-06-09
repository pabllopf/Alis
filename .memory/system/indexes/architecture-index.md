---
title: Architecture Index — ALIS
tags: [index,catalog,reference]
---


## Architectural Patterns

### 1. Entity Component System (ECS)
- **Location**: `4_Operation/Ecs/`
- **Description**: Archetype-based ECS with cache-optimized storage, deferred structural changes, and zero-allocation queries
- **Key Types**: Scene, Entity, GameObject, Component, Query, Archetype, SparseSet, Chunk
- **Patterns**: Update/FixedUpdate/Render runners, event-driven component changes

### 2. Aspect-Oriented Programming (AOP)
- **Location**: `6_Ideation/`
- **Description**: Cross-cutting concerns implemented as aspects with Roslyn source generators
- **Key Aspects**: Memory, Fluent, Data, Math, Time, Logging
- **Generator Pattern**: Each aspect has `src/` (definition + generator) and `generator/` (Roslyn ISourceGenerator)

### 3. Screaming Architecture
- **Location**: All layers
- **Description**: Directory structure reveals intent — numbered layers (1_Presentation through 6_Ideation) enforce dependency direction
- **Enforcement**: Config.props automatically adds project references based on layer

### 4. Aggregator Pattern
- **Location**: `3_Structuration/Core/`, `5_Declaration/Aspect/`
- **Description**: Zero hand-written code projects that re-export types from lower layers
- **Benefit**: Single project reference for consumers, clean dependency graph

### 5. Source Generator Cascading
- **Location**: `6_Ideation/*/generator/`, `4_Operation/*/generator/`
- **Description**: Generators in Ideation produce code that flows down through all layers
- **Mechanism**: `<ProjectReference OutputItemType="Analyzer">` with `netstandard2.0` target

### 6. Value-Type Performance
- **Location**: `6_Ideation/Math/`, `4_Operation/Ecs/`
- **Description**: Heavy use of structs, `StructLayout(Pack=1)`, `Span<T>`, `Memory<T>` for zero GC pressure
- **AOT**: No reflection at runtime, source generators for compile-time code

### 7. Release-Mode Source Inlining
- **Location**: `.config/Config.props` (Release configuration)
- **Description**: In Release builds, source files from lower layers are compiled directly into higher layers via `<Compile Include>` directives, producing single assemblies

---

## Key Components

| Component | Location | Purpose |
|-----------|----------|---------|
| Scene Manager | 4_Operation/Ecs/src/ | Entity and component management |
| Graphics Renderer | 4_Operation/Graphic/src/ | 2D/3D rendering pipeline |
| Physics Engine | 4_Operation/Physic/src/ | 2D physics simulation |
| Audio Player | 4_Operation/Audio/src/ | Cross-platform audio |
| Asset Registry | 6_Ideation/Memory/src/ | ZIP-based asset management |
| Fluent Builder | 6_Ideation/Fluent/src/ | Builder API with 120+ marker interfaces |
| JSON Parser | 6_Ideation/Data/src/ | Custom AOT-compatible JSON |
| Math Library | 6_Ideation/Math/src/ | Value-type vectors, matrices, shapes |
| Logging Pipeline | 6_Ideation/Logging/src/ | Structured logging |

---

## Build Configuration

| Setting | Value |
|---------|-------|
| C# Version | 13 |
| SDK | .NET 10.0+ (rollForward: latestMajor) |
| Debug TFMs | netcoreapp2.0, net5.0, net8.0, net10.0, netstandard2.0, net461 |
| Release TFMs | 21 frameworks (netcoreapp2.0–3.1, net5.0–10.0, netstandard2.0–2.1, net461–481) |
| RIDs | browser-wasm, win-x64/x86, linux-x64/arm64/arm, osx-x64/arm64, android-arm64/x64, ios-arm64 |
| Analyzers | .NET Analyzers (AllEnabledByDefault), SonarQube |
| Warnings | TreatWarningsAsErrors=true, extensive NoWarn list |
| Source Link | Microsoft.SourceLink.GitHub 8.0.0 |

---

## CI/CD Workflows (41 total)

| Workflow | Purpose |
|----------|---------|
| [ALIS][CODE] | Code quality checks |
| [ALIS][TEST] | Test execution |
| [ALIS][PUBLISH] | NuGet package publishing |
| [ALIS][BENCHMARK] | Performance benchmarks |
| [ALIS][SONARCLOUD] | Main SonarCloud analysis |
| [ALIS][*][SONARCLOUD] | Per-project SonarCloud analysis (35+ workflows) |
| [ALIS][DEPENDENCY][REVIEW] | Dependency review |
| [ALIS][CONTRIBUTORS] | Contributor management |
| [ALIS][NEW][CONTRIBUTORS] | New contributor onboarding |
| [ALIS][CHECK][ISSUES] | Issue tracking |

---

## Architecture Decisions

- [[decisions/adr-001-layered-architecture]] — Six-layer screaming architecture
- [[decisions/adr-002-aggregator-pattern]] — Aggregator pattern for core projects

---

## Related Documentation

- [[architecture/repository-overview]] — Full architecture overview
- [[architecture/dependency-graph]] — Dependency maps
- [[architecture/build-system]] — Build configuration
