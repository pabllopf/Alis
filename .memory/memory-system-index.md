# Memory System Index

Comprehensive index of the entire `.memory/` system for the Alis solution.

## Quick Navigation

### Core Documentation
- [`.memory/sources/sources-overview.md`] - Master documentation of all source files
- [`.memory/concepts/concepts-index.md`] - All architectural and design concepts
- [`.memory/memory-system-update-summary.md`] - Latest update summary

### Source Documentation
- [`.memory/sources/index.md`] - Master sources index
- [`.memory/sources/sources-overview.md`] - Comprehensive sources overview
- [`.memory/sources/architectural-patterns-sources.md`] - Design patterns
- [`.memory/sources/conventions-sources.md`] - Coding standards
- [`.memory/sources/ecs-sources.md`] - ECS runtime and generator
- [`.memory/sources/generator-sources.md`] - Source generators
- [`.memory/sources/extension-sources.md`] - 18+ modular extensions
- [`.memory/sources/ideation-sources.md`] - Experimental aspects
- [`.memory/sources/benchmark-sources.md`] - Performance benchmarks
- [`.memory/sources/test-sources.md`] - Unit and integration tests
- [`.memory/sources/generated-code-sources.md`] - Source-generated code

### Concept Documentation (NEW - 15 concepts)
- [`.memory/concepts/concepts-index.md`] - Master concepts index with quick navigation
- [`.memory/concepts/data-oriented-design.md`] - Cache-first ECS optimization
- [`.memory/concepts/value-object-pattern.md`] - Immutable data types
- [`.memory/concepts/zero-copy-abstractions.md`] - Memory-efficient queries
- [`.memory/concepts/compile-time-polymorphism.md`] - Source generator dispatch
- [`.memory/concepts/resource-management-patterns.md`] - RAII + async loading
- [`.memory/concepts/query-based-architecture.md`] - Type-safe filtering
- [`.memory/concepts/event-driven-entity-system.md`] - Per-entity events
- [`.memory/concepts/cross-platform-abstraction-layer.md`] - Platform-agnostic APIs
- [`.memory/concepts/procedural-generation-framework.md`] - Algorithmic generation
- [`.memory/concepts/high-speed-priority-queue.md`] - O(log n) heap operations
- [`.memory/concepts/dialogue-system-architecture.md`] - Branching narrative
- [`.memory/concepts/update-loop-game-loop.md`] - Fixed timestep simulation
- [`.memory/concepts/service-registration-discovery.md`] - Compile-time DI registry
- [`.memory/concepts/compression-memory-optimization.md`] - Zip-based caching
- [`.memory/concepts/multi-targeting-strategy.md`] - .NET 2.0 to .NET 10 support

### Update Tracking
- [`.memory/memory-system-update-summary.md`] - Latest update summary
- [`.memory/memory-system-tracking.md`] - Update tracking metadata

## Detailed Index

### 1. Sources Documentation

#### Overview Files
- **`sources/index.md`** - Master navigation index for all sources
- **`sources/sources-overview.md`** - Comprehensive documentation of 500+ source files

#### Category Documentation
- **`sources/architectural-patterns-sources.md`** - Design patterns and architecture
- **`sources/conventions-sources.md`** - Coding standards and conventions
- **`sources/ecs-sources.md`** - ECS runtime and source generator
- **`sources/generator-sources.md`** - AOT-safe source generators
- **`sources/extension-sources.md`** - 18+ modular extensions
- **`sources/ideation-sources.md`** - Experimental aspects (Memory, Fluent, Data, Math, Time, Logging)
- **`sources/benchmark-sources.md`** - Performance benchmarks
- **`sources/test-sources.md`** - Unit and integration tests
- **`sources/generated-code-sources.md`** - Source-generated code

### 2. Concepts Documentation (NEW)

#### Performance Optimization
- **`concepts/data-oriented-design.md`** - Cache-first ECS optimization (+3-5x performance)
- **`concepts/zero-copy-abstractions.md`** - Memory-efficient queries without allocation
- **`concepts/query-based-architecture.md`** - Type-safe component filtering
- **`concepts/high-speed-priority-queue.md`** - O(log n) heap operations for scheduling
- **`concepts/compression-memory-optimization.md`** - Zip-based cache entries (-60-80% memory)

#### Architecture Patterns
- **`concepts/value-object-pattern.md`** - Immutable data types with equality by value
- **`concepts/compile-time-polymorphism.md`** - Static dispatch via source generators
- **`concepts/event-driven-entity-system.md`** - Per-entity lifecycle events
- **`concepts/update-loop-game-loop.md`** - Fixed timestep simulation with delta time

#### Resource Management
- **`concepts/resource-management-patterns.md`** - RAII + async loading with caching
- **`concepts/service-registration-discovery.md`** - Compile-time DI registry

#### Extension Framework
- **`concepts/cross-platform-abstraction-layer.md`** - Platform-agnostic APIs (Win/Linux/macOS/Web)
- **`concepts/procedural-generation-framework.md`** - Algorithmic content generation
- **`concepts/dialogue-system-architecture.md`** - Branching narrative with localization
- **`concepts/multi-targeting-strategy.md`** - .NET 2.0 to .NET 10 support

### 3. Update Tracking

- **`memory-system-update-summary.md`** - Comprehensive update summary
- **`memory-system-tracking.md`** - Tracking metadata and quality checks

## Usage Guidelines

### For Developers
1. Start with `sources/sources-overview.md` for general overview
2. Read specific source category documentation as needed
3. Study concepts for design patterns and best practices
4. Follow conventions in `sources/conventions-sources.md`

### For AI Agents
1. Use documentation as context for code generation
2. Reference architectural patterns for design decisions
3. Check generated code locations for understanding compile-time generation
4. Apply new concepts to ECS systems and extensions

### For Documentation Maintenance
1. Update sources when new modules are added
2. Add new concepts for emerging patterns
3. Maintain cross-links between documents
4. Keep statistics table current

## Statistics

| Metric | Value |
|--------|-------|
| **Source files documented** | 500+ |
| **Test files documented** | 200+ |
| **Generated files tracked** | 300+ |
| **Documentation files** | 28+ (11 sources + 17 concepts) |
| **Total lines documented** | ~5,000+ |
| **New concepts added** | 15 |

## See Also

- [`.memory/sources/`] - Source file documentation
- [`.memory/concepts/`] - Architectural and design concepts (NEW)
- [`.memory/architecture/`] - Architecture documentation (if exists)
- [`.memory/projects/`] - Project-specific documentation (if exists)
