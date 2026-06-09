# ALIS Game Engine Framework - Repository Overview

## High-Level Architecture

ALIS is a high-performance 2D game engine framework written in C# with the following architectural layers:

### Layer 1: Presentation (1_Presentation)
- **Extensions**: ~20 cross-platform extensions (Graphics, Audio, Cloud, Payment, etc.)
- **Applications**: Engine, Hub, Installer
- **Samples**: Console game samples for network extensions

### Layer 2: Application (2_Application)
- **Alis Core**: Main application library
- **Game Samples**: ~14 complete game samples (Flappy Bird, Pong, Space Simulator, etc.)

### Layer 3: Structuration (3_Structuration)
- **Alis.Core**: Core abstractions and base classes
- Foundation for all other layers

### Layer 4: Operation (4_Operation)
- **ECS**: Entity Component System (108 files) - High-performance ECS with custom memory management
- **Graphic**: Graphics rendering (147 files) - Cross-platform graphics with SFML/OpenGL
- **Audio**: Audio playback system (5 files) - Platform-specific audio backends
- **Physic**: 2D physics engine (39+ files) - Rigid body dynamics and collision detection

### Layer 5: Declaration (5_Declaration)
- **Aspect System**: Core aspect infrastructure

### Layer 6: Ideation (6_Ideation)
- **Memory**: Asset registry and management system (6 files) - Thread-safe caching with ZIP handling
- **Fluent**: Builder pattern implementation
- **Data**: JSON serialization/deserialization (AOT-friendly)
- **Math**: Custom mathematical operations with Taylor series approximations
- **Time**: High-resolution clock for timing measurements
- **Logging**: Flexible logging system with multiple outputs

## Technology Stack

### Core Technologies
- **.NET 8**: Target framework (net8.0)
- **C# 13**: Latest language features
- **Unsafe Code**: Low-level memory operations for performance

### External Dependencies
- **System.Memory**: Span<T> and Memory<T> for zero-copy operations
- **System.Runtime.CompilerServices.Unsafe**: Low-level memory operations
- **SFML/OpenGL**: Cross-platform graphics
- **Platform-specific tools**: aplay, mpg123, afplay for audio

## Architectural Patterns

### Design Patterns
- **ECS**: Entity Component System with archetype-based storage
- **Builder Pattern**: Fluent API for object construction
- **Factory Pattern**: LoggerFactory and asset registry
- **Strategy Pattern**: Platform-specific implementations
- **Observer Pattern**: Event-based communication

### Architecture Principles
- **Clean Architecture**: Clear separation of concerns
- **Layered Architecture**: Well-defined layer boundaries
- **Dependency Inversion**: Abstractions over implementations
- **Performance-first**: Zero-copy operations, custom memory management

## Project Statistics

| Metric | Value |
|---|---|
| Total Projects | 140 |
| Source Files | ~3,319 |
| Documented Projects | 10 |
| Documentation Coverage | ~7% |

## Key Features

### ECS System
- High-performance entity management
- Archetype-based component storage
- Custom memory pooling
- GameObject hierarchy

### Graphics System
- Cross-platform rendering (Windows, Linux, macOS, Web)
- SFML and OpenGL backends
- Hardware acceleration

### Physics Engine
- 2D rigid body dynamics
- Collision detection (GJK, EPA, SAT)
- Continuous collision detection (CCD)
- Dynamic tree broadphase optimization

### Asset Management
- Thread-safe asset registry
- ZIP file handling with lazy extraction
- SHA256-based change detection
- Per-assembly caching

## Testing Status

- **Unit Tests**: Partial coverage across all projects
- **Integration Tests**: Sample programs demonstrate usage
- **Coverage**: Needs improvement (target: 80%+)

## Quality Plans

Each project includes a `QualityPlan.md` file with:
- Code quality goals
- Test coverage targets
- Sample program expansion
- Documentation improvements

## Repository Structure

```
Alis/
├── 1_Presentation/     # Extensions, Apps, Samples
├── 2_Application/      # Core app + game samples
├── 3_Structuration/    # Core engine aggregator
├── 4_Operation/        # ECS, Graphic, Audio, Physic
├── 5_Declaration/      # Aspect system
├── 6_Ideation/         # Aspects + generators
├── .memory/            # Generated documentation
└── docs/               # Project documentation
```

## Documentation System

The `.memory/` directory contains:
- **projects/**: Per-project documentation
- **system/**: State tracking, indexes, logs
- **diagrams/**: Mermaid architecture diagrams
- **indexes/**: Project and dependency indexes
- **summaries/**: Repository overview and summaries

## Next Steps for Memory Generation

1. ✅ Document ECS system (108 files)
2. ✅ Document Graphic system (147 files)
3. ✅ Document Audio system (5 files)
4. ✅ Document Physic system (39+ files)
5. ✅ Document Memory aspect (6 files)
6. ✅ Document Fluent, Data, Math, Time, Logging aspects
7. ⏳ Document Extensions (~20 projects)
8. ⏳ Document Applications and Samples
9. ⏳ Generate architecture decision records

## Cross-References

- [[projects/Index]] - Complete project index
- [[system/state/analysis-state]] - Current analysis state
- [[diagrams/dependency-graph]] - Dependency visualization
- [[summaries/repository-overview]] - This document

## License

GNU General Public License v3.0 (GPLv3)

## Related Architecture

- [[architecture/repository-overview]] — Detailed architecture
- [[architecture/dependency-graph]] — Dependency map
- [[architecture/build-system]] — Build configuration
- [[build-system]] — Build docs

## Related Concepts

- [[Alis Architecture Overview]] — Full concept overview
- [[Layered Architecture]] — Layer details
- [[Aspect-Oriented Design]] — AOP foundation
- [[Generator Pattern]] — Source generators

## Related Indexes

- [[project-index]] — All 140 projects
- [[layer-index]] — Layer breakdown
- [[architecture-index]] — Patterns index
- [[domains-index]] — Bounded contexts
- [[services-index]] — Service catalog

## Related Analysis

- [[testing-overview]] — Test coverage status
- [[security-overview]] — Security analysis
- [[performance-index]] — Performance optimizations

## Related Documentation

- [[onboarding/getting-started]] — Developer onboarding
- [[ai-context]] — AI agent reference
- [[adr-001-layered-architecture]] — Architecture decisions
- [[adr-002-aggregator-pattern]] — Aggregator decision
- [[session-summary]] — Memory generation session

