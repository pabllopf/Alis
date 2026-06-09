# Concepts Index

tags:
  - concept,theory,documentation

Comprehensive index of all architectural and design concepts used throughout the Alis solution.

## Quick Navigation

### Performance Optimization
- [`.memory/concepts/data-oriented-design.md`] - Cache-first ECS optimization
- [`.memory/concepts/zero-copy-abstractions.md`] - Memory-efficient queries without allocation
- [`.memory/concepts/query-based-architecture.md`] - Type-safe component filtering
- [`.memory/concepts/high-speed-priority-queue.md`] - O(log n) heap operations for scheduling
- [`.memory/concepts/compression-memory-optimization.md`] - Zip-based cache entries

### Architecture Patterns
- [`.memory/concepts/value-object-pattern.md`] - Immutable data types with equality by value
- [`.memory/concepts/compile-time-polymorphism.md`] - Static dispatch via source generators
- [`.memory/concepts/event-driven-entity-system.md`] - Per-entity lifecycle events
- [`.memory/concepts/update-loop-game-loop.md`] - Fixed timestep simulation

### Resource Management
- [`.memory/concepts/resource-management-patterns.md`] - RAII + async loading with caching
- [`.memory/concepts/service-registration-discovery.md`] - Compile-time DI registry

### Extension Framework
- [`.memory/concepts/cross-platform-abstraction-layer.md`] - Platform-agnostic APIs
- [`.memory/concepts/procedural-generation-framework.md`] - Algorithmic content generation
- [`.memory/concepts/dialogue-system-architecture.md`] - Branching narrative with localization
- [`.memory/concepts/multi-targeting-strategy.md`] - .NET 2.0 to .NET 10 support

## Detailed Index

### 1. Data-Oriented Design (DOD)
**File**: `data-oriented-design.md`  
**Category**: Performance Optimization  
**Purpose**: Cache-first optimization for high-performance ECS systems  
**Key Features**:
- Component-based architecture with struct types
- Batch processing for SIMD optimization
- Memory contiguity for cache efficiency

**Related**: [`.memory/sources/ecs-sources.md`], [[Value Object Pattern]]

### 2. Value Object Pattern
**File**: `value-object-pattern.md`  
**Category**: Architecture Patterns  
**Purpose**: Immutable data types with equality by value  
**Key Features**:
- Record types with init-only setters
- No null references, thread-safe
- Mathematical types (Vector2, Vector3, Position)

**Related**: [`.memory/concepts/data-oriented-design.md`], [`.memory/concepts/resource-management-patterns.md`]

### 3. Zero-Copy Abstractions
**File**: `zero-copy-abstractions.md`  
**Category**: Performance Optimization  
**Purpose**: Memory-efficient data access without allocation  
**Key Features**:
- Span<T>, Memory<T>, ref struct usage
- Query iterators with zero allocations
- 10-100x faster than LINQ for ECS queries

**Related**: [[Query-Based Architecture]], [[Data-Oriented Design]]

### 4. Compile-Time Polymorphism
**File**: `compile-time-polymorphism.md`  
**Category**: Architecture Patterns  
**Purpose**: Static dispatch via source generators instead of virtual methods  
**Key Features**:
- AOT-compatible service registry
- ALIS0xxx diagnostic error codes
- No runtime reflection needed

**Related**: [`.memory/concepts/compile-time-polymorphism.md`], [[Service Registration & Discovery]]

### 5. Resource Management Patterns
**File**: `resource-management-patterns.md`  
**Category**: Resource Management  
**Purpose**: Safe handling of external resources with automatic cleanup  
**Key Features**:
- RAII pattern with IDisposable
- Async resource loading
- CacheEntry with expiry and ZipCacheEntry compression

**Related**: [`.memory/concepts/resource-management-patterns.md`], [[Compression & Memory Optimization]]

### 6. Query-Based Architecture
**File**: `query-based-architecture.md`  
**Category**: Performance Optimization  
**Purpose**: Declarative component filtering replacing inheritance hierarchies  
**Key Features**:
- Type-safe component queries
- LINQ-like syntax for ECS
- Zero-copy iteration

**Related**: [`.memory/sources/ecs-sources.md`], [[Zero-Copy Abstractions]]

### 7. Event-Driven Entity System
**File**: `event-driven-entity-system.md`  
**Category**: Architecture Patterns  
**Purpose**: Per-entity event notifications for lifecycle management  
**Key Features**:
- EntityCreated, EntityDestroyed events
- ComponentAdded<T>, ComponentRemoved<T> handlers
- Decoupled system communication

**Related**: [`.memory/sources/ecs-sources.md`], [`.memory/concepts/event-driven-entity-system.md`]

### 8. Cross-Platform Abstraction Layer
**File**: `cross-platform-abstraction-layer.md`  
**Category**: Extension Framework  
**Purpose**: Platform-agnostic APIs with native implementations  
**Key Features**:
- Graphics extensions (Sfml, Glfw, Sdl2)
- Network and I/O abstractions
- Platform detection and optimization

**Related**: [`.memory/concepts/cross-platform-abstraction-layer.md`], [`.memory/sources/extension-sources.md`]

### 9. Procedural Generation Framework
**File**: `procedural-generation-framework.md`  
**Category**: Extension Framework  
**Purpose**: Algorithmic content generation for games and simulations  
**Key Features**:
- BSP tree dungeon generation
- Perlin noise terrain generation
- Random content creation

**Related**: [`.memory/concepts/procedural-generation-framework.md`], [`.memory/concepts/high-speed-priority-queue.md`]

### 10. High-Speed Priority Queue
**File**: `high-speed-priority-queue.md`  
**Category**: Performance Optimization  
**Purpose**: O(log n) heap-based priority queue for ECS scheduling  
**Key Features**:
- Array-based binary heap
- Memory-efficient, no node allocations
- O(log n) insert and extract-min

**Related**: [`.memory/sources/ecs-sources.md`], [`.memory/concepts/high-speed-priority-queue.md`]

### 11. Dialogue System Architecture
**File**: `dialogue-system-architecture.md`  
**Category**: Extension Framework  
**Purpose**: Scripted narrative with branching paths and localization  
**Key Features**:
- Node-based dialogue trees
- Conditional choices and variables
- Multi-language support

**Related**: [`.memory/concepts/dialogue-system-architecture.md`], [`.memory/sources/extension-sources.md`]

### 12. Update Loop & Game Loop
**File**: `update-loop-game-loop.md`  
**Category**: Architecture Patterns  
**Purpose**: Fixed timestep simulation with delta time for frame-rate independence  
**Key Features**:
- Separate update and render loops
- Interpolation for smooth animation
- Time scaling support

**Related**: [`.memory/sources/ecs-sources.md`], [`.memory/concepts/update-loop-game-loop.md`]

### 13. Service Registration & Discovery
**File**: `service-registration-discovery.md`  
**Category**: Resource Management  
**Purpose**: Compile-time service registry via source generators  
**Key Features**:
- GenerateService attribute
- Singleton, Scoped, Transient lifecycles
- Type-safe dependency injection

**Related**: [`.memory/concepts/service-registration-discovery.md`], [`.memory/concepts/compile-time-polymorphism.md`]

### 14. Compression & Memory Optimization
**File**: `compression-memory-optimization.md`  
**Category**: Performance Optimization  
**Purpose**: Zip-based cache entries for memory efficiency  
**Key Features**:
- 60-80% memory reduction
- Object pooling for reduced GC pressure
- Save game compression

**Related**: [`.memory/concepts/resource-management-patterns.md`], [`.memory/concepts/compression-memory-optimization.md`]

### 15. Multi-Targeting Strategy
**File**: `multi-targeting-strategy.md`  
**Category**: Extension Framework  
**Purpose**: Compile once, deploy everywhere (.NET 2.0 to .NET 10)  
**Key Features**:
- Support for 15+ target frameworks
- Platform-specific conditional compilation
- AOT compatibility with Native AOT

**Related**: [`.memory/sources/sources-overview.md`], [`.memory/concepts/multi-targeting-strategy.md`]

## See Also

- `.memory/sources/` - Source file documentation
- `.memory/architecture/` - Architecture documentation
- `.memory/projects/` - Project-specific documentation
- `.memory/diagrams/` - Architecture diagrams
