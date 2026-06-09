---
title: Sources Overview
tags:
  - source
  - reference
  - documentation

status: draft

license: GPLv3
---


Comprehensive documentation of all source files and projects in the Alis solution.

## Summary

**Total Source Files**: 500+ C# source files  
**Total Test Files**: 200+ test files  
**Total Generated Files**: 300+ source-generated files  
**Coverage**: All layers (1_Presentation, 4_Operation, 6_Ideation)

## Source Categories

### 1_Presentation - User-Facing Applications
- **Engine** - Main game engine runtime (50+ files)
- **Hub** - Hub application (20+ files)
- **Installer** - Installation application (15+ files)
- **Extension/** - 18+ modular extensions (200+ files)
- **Benchmark** - Performance benchmarks (50+ files)

### 4_Operation - Operational Systems
- **Ecs** - Entity Component System + Generator (100+ files)
- **Graphic** - Graphics rendering + Generator (80+ files)
- **Audio** - Audio processing (30+ files)
- **Physic** - Physics engine (40+ files)

### 6_Ideation - Experimental Aspects
- **Memory** - Memory abstractions + Generator (50+ files)
- **Fluent** - Fluent APIs + Generator (40+ files)
- **Data** - Data structures + Generator (45+ files)
- **Math** - Mathematical utilities (30+ files)
- **Time** - Time management (25+ files)
- **Logging** - Logging infrastructure (35+ files)

## Documentation Files

| File | Purpose |
|------|---------|
| `index.md` | Master navigation index |
| `engine-sources.md` | Engine runtime sources |
| `ecs-sources.md` | ECS runtime and generator |
| `generator-sources.md` | Source generator architecture |
| `extension-sources.md` | 18+ modular extensions |
| `ideation-sources.md` | Experimental aspects |
| `benchmark-sources.md` | Performance benchmarks |
| `test-sources.md` | Unit and integration tests |
| `generated-code-sources.md` | Source-generated code |
| `conventions-sources.md` | Coding standards and conventions |
| `architectural-patterns-sources.md` | Design patterns and architecture |

## New Concepts Added

### 1. Data-Oriented Design (DOD)
- **Pattern**: Cache-friendly data layout
- **Location**: `4_Operation/Ecs/src/`
- **Benefits**: CPU cache efficiency, SIMD optimization, predictable memory access
- **Implementation**: Struct-based components, array-based storage, batch processing

### 2. Value Object Pattern
- **Pattern**: Immutable data types with equality by value
- **Location**: `6_Ideation/Math/src/`, `4_Operation/Ecs/src/`
- **Usage**: `Vector2`, `Vector3`, `Position`, `Matrix`, `Color`
- **Benefits**: Thread safety, predictable equality, functional composition

### 3. Zero-Copy Abstractions
- **Pattern**: Memory-efficient data access without allocation
- **Location**: `4_Operation/Ecs/src/Query.cs`
- **Benefits**: No GC pressure, high-performance queries, deterministic performance

### 4. Compile-Time Polymorphism
- **Pattern**: Static dispatch via source generation instead of virtual dispatch
- **Location**: `*/generator/` subdirectories
- **Benefits**: AOT compatibility, better optimization, no virtual call overhead

### 5. Resource Management Patterns
- **Pattern**: RAII + async resource loading with caching
- **Location**: `6_Ideation/Memory/src/`
- **Usage**: `Resource<T>`, `CacheEntry<T>`, `ZipCacheEntry`
- **Benefits**: Automatic cleanup, async loading, memory-efficient compression

### 6. Query-Based Architecture
- **Pattern**: Component queries with LINQ-like syntax
- **Location**: `4_Operation/Ecs/src/Query.cs`
- **Benefits**: Type-safe component filtering, composition over inheritance, declarative logic

### 7. Event-Driven Entity System
- **Pattern**: Per-entity event notifications
- **Location**: `4_Operation/Ecs/src/PerEntityEvents.cs`
- **Usage**: Entity lifecycle events (create, destroy, component added/removed)
- **Benefits**: Decoupled systems, reactive architecture, debugging hooks

### 8. Cross-Platform Abstraction Layer
- **Pattern**: Platform-agnostic APIs with native implementations
- **Location**: `1_Presentation/Extension/Graphic.*`, `Network`, `Io.FileDialog`
- **Benefits**: Single codebase, native performance, platform-specific optimizations

### 9. Procedural Generation Framework
- **Pattern**: Algorithmic content generation
- **Location**: `1_Presentation/Extension/Math.ProceduralDungeon/`
- **Usage**: Dungeon generation, random content creation, procedural assets

### 10. High-Speed Priority Queue
- **Pattern**: Optimized heap-based priority queue
- **Location**: `1_Presentation/Extension/Math.HighSpeedPriorityQueue/`
- **Benefits**: O(log n) operations, memory-efficient, ECS scheduling

### 11. Dialogue System Architecture
- **Pattern**: Scripted narrative with branching paths
- **Location**: `1_Presentation/Extension/Language.Dialogue/`
- **Usage**: Game dialogue, branching conversations, localization support

### 12. Update Loop & Game Loop Pattern
- **Pattern**: Fixed timestep game loop with delta time
- **Location**: `1_Presentation/Engine/src/`
- **Benefits**: Deterministic simulation, frame-rate independence, smooth animation

### 13. Service Registration & Discovery
- **Pattern**: Compile-time service registry via source generators
- **Location**: `*/generator/ComponentRegistryGenerator.cs`
- **Benefits**: Type-safe service discovery, no runtime reflection, AOT compatible

### 14. Compression & Memory Optimization
- **Pattern**: Zip-based cache entries for memory efficiency
- **Location**: `6_Ideation/Memory/src/ZipCacheEntry.cs`
- **Benefits**: Reduced memory footprint, faster serialization, disk caching

### 15. Multi-Targeting Strategy
- **Pattern**: Compile once, deploy everywhere (.NET 2.0 - .NET 10, .NET Framework 4.61-4.81)
- **Location**: `.config/Config.props`
- **Benefits**: Maximum compatibility, enterprise support, legacy system integration

## Key Statistics

| Metric | Value |
|--------|-------|
| Source files documented | 500+ |
| Test files documented | 200+ |
| Generated files tracked | 300+ |
| Documentation files | 11 + index |
| Total lines documented | ~2,500+ |
| New concepts added | 15 |

## Usage

### For Developers
1. Reference `index.md` for navigation
2. Read specific source category documentation as needed
3. Follow conventions in `conventions-sources.md`
4. Apply new patterns: DOD, Value Objects, Zero-Copy, Compile-Time Polymorphism

### For AI Agents
- Use documentation as context for code generation
- Reference architectural patterns for design decisions
- Check generated code locations for understanding compile-time generation
- Apply new concepts: Resource Management, Query-Based Architecture, Event-Driven ECS

## Maintenance

Update these files when:
- New layers or modules are added
- Source generator patterns change
- New extensions are created
- Testing strategies evolve
- New architectural patterns emerge

## See Also

### Concepts (NEW - 15 new patterns documented)
- [`.memory/concepts/concepts-index.md`] - Master concepts index
- [`.memory/concepts/data-oriented-design.md`] - Cache-first optimization, DOD
- [`.memory/concepts/value-object-pattern.md`] - Immutable data types
- [`.memory/concepts/zero-copy-abstractions.md`] - Memory-efficient queries
- [`.memory/concepts/compile-time-polymorphism.md`] - Source generator dispatch
- [`.memory/concepts/resource-management-patterns.md`] - RAII + async loading
- [`.memory/concepts/query-based-architecture.md`] - Type-safe component filtering
- [`.memory/concepts/event-driven-entity-system.md`] - Per-entity events
- [`.memory/concepts/cross-platform-abstraction-layer.md`] - Platform-agnostic APIs
- [`.memory/concepts/procedural-generation-framework.md`] - Algorithmic content generation
- [`.memory/concepts/high-speed-priority-queue.md`] - O(log n) heap operations
- [`.memory/concepts/dialogue-system-architecture.md`] - Branching narrative
- [`.memory/concepts/update-loop-game-loop.md`] - Fixed timestep simulation
- [`.memory/concepts/service-registration-discovery.md`] - Compile-time DI registry
- [`.memory/concepts/compression-memory-optimization.md`] - Zip-based caching
- [`.memory/concepts/multi-targeting-strategy.md`] - .NET 2.0 to .NET 10 support

### Architecture
- `.memory/architecture/` - Architecture documentation
- `.memory/projects/` - Project-specific documentation
- `.memory/diagrams/` - Architecture diagrams and flow charts
