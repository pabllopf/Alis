# Concepts Index

tags:
  - concept,theory,documentation

Comprehensive index of all architectural and design concepts used throughout the Alis solution.

## Core Patterns

### Data-Oriented Design
- [[Data-Oriented Design (DOD)]] - Cache-first optimization, component-based architecture
- **Location**: `4_Operation/Ecs/src/`
- **Benefits**: CPU cache efficiency, SIMD optimization

### Value Object Pattern
- [[Value Object Pattern]] - Immutable data types with equality by value
- **Location**: `6_Ideation/Math/src/`
- **Benefits**: Thread safety, predictable equality

### Zero-Copy Abstractions
- [[Zero-Copy Abstractions]] - Memory-efficient data access without allocation
- **Location**: `4_Operation/Ecs/src/Query.cs`
- **Benefits**: No GC pressure, high-performance queries

### Compile-Time Polymorphism
- [[Compile-Time Polymorphism]] - Static dispatch via source generation
- **Location**: `*/generator/` subdirectories
- **Benefits**: AOT compatibility, better optimization

## System Architecture

### Entity Component System
- [[Entity Component System]] - Data-oriented game engine architecture
- **Location**: `4_Operation/Ecs/src/`
- **Benefits**: Cache efficiency, scalability

### Query-Based Architecture
- [[Query-Based Architecture]] - Type-safe component filtering
- **Location**: `4_Operation/Ecs/src/Query.cs`
- **Benefits**: Declarative logic, composition over inheritance

### Event-Driven Entity System
- [[Event-Driven Entity System]] - Per-entity event notifications
- **Location**: `4_Operation/Ecs/src/PerEntityEvents.cs`
- **Benefits**: Decoupled systems, reactive architecture

### Game Loop Pattern
- [[Update Loop & Game Loop]] - Fixed timestep simulation with delta time
- **Location**: `1_Presentation/Engine/src/`
- **Benefits**: Frame-rate independence, deterministic simulation

## Resource Management

### Resource Management Patterns
- [[Resource Management Patterns]] - RAII + async loading with caching
- **Location**: `6_Ideation/Memory/src/`
- **Benefits**: Automatic cleanup, async loading

### Compression & Memory Optimization
- [[Compression & Memory Optimization]] - Zip-based cache entries
- **Location**: `6_Ideation/Memory/src/ZipCacheEntry.cs`
- **Benefits**: Reduced memory footprint, disk caching

### Service Registration & Discovery
- [[Service Registration & Discovery]] - Compile-time service registry
- **Location**: `*/generator/ComponentRegistryGenerator.cs`
- **Benefits**: Type-safe, AOT compatible

## Extensions & Utilities

### Cross-Platform Abstraction Layer
- [[Cross-Platform Abstraction Layer]] - Platform-agnostic APIs with native implementations
- **Location**: `1_Presentation/Extension/`
- **Benefits**: Single codebase, native performance

### Procedural Generation Framework
- [[Procedural Generation Framework]] - Algorithmic content generation
- **Location**: `1_Presentation/Extension/Math.ProceduralDungeon/`
- **Usage**: Dungeon generation, random content creation

### High-Speed Priority Queue
- [[High-Speed Priority Queue]] - Optimized heap-based priority queue
- **Location**: `1_Presentation/Extension/Math.HighSpeedPriorityQueue/`
- **Benefits**: O(log n) operations, memory-efficient

### Dialogue System Architecture
- [[Dialogue System Architecture]] - Scripted narrative with branching paths
- **Location**: `1_Presentation/Extension/Language.Dialogue/`
- **Usage**: Game dialogue, branching conversations

## Build & Deployment

### Multi-Targeting Strategy
- [[Multi-Targeting Strategy]] - Compile once, deploy everywhere (.NET 2.0 - .NET 10)
- **Location**: `.config/Config.props`
- **Benefits**: Maximum compatibility, enterprise support

### Source Generators
- [[Source Generators]] - AOT-safe compile-time code generation
- **Location**: `*/generator/` subdirectories
- **Benefits**: Type safety, diagnostics (ALIS0xxx)

## See Also

- `.memory/architecture/` - Architecture documentation
- `.memory/projects/` - Project-specific documentation
- `.memory/sources/` - Source file documentation
- `.memory/diagrams/` - Architecture diagrams
