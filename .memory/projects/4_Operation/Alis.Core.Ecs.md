# Alis.Core.Ecs

## Overview
Entity Component System (ECS) library for ALIS game engine. Provides high-performance ECS architecture with structurally-oriented design.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~108 C# files

## Project Details
- **Layer**: 4_Operation
- **Type**: Library (ECS Engine)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Implements a complete Entity Component System architecture for game development. Provides high-performance entity management, component systems, scene management, and query capabilities. Core engine subsystem for ALIS.

## Key Components

### Scene Class
- Central container for all entities and systems
- Entity creation with typed components
- Component add/remove with event notifications
- Custom queries using rule-based filtering
- Update systems by attribute/component type
- Structural change safety during update cycles
- Bulk entity creation for performance

### Core Types
- **Entity** - Entity handle/identifier
- **EntityUpdate** - Update lifecycle management
- **GameObjectFlags** - Entity state flags
- **GameObjectRefTuple** - Reference tuple for entities
- **SceneQueryExtensions** - Query helpers

### Collections
- Archetype-based component storage
- Efficient entity-component lookups
- Memory-optimized data structures

### Systems
- Update systems by attribute type
- Event-driven architecture
- Deferred structural changes

## Dependencies
- [[Alis.Core.Aspect.Math.Collections]] (6_Ideation) - Collections
- [[Alis.Core.Ecs.Kernel]] (4_Operation) - ECS kernel
- [[Alis.Core.Ecs.Redifinition]] (4_Operation) - Redefinition support

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (performance-critical code)

## Performance Features
1. Archetype-based storage for cache efficiency
2. Structured queries with compile-time rules
3. Deferred structural changes for safety
4. Bulk operations for high-performance scenarios

## Testing Status
- **Unit Tests**: Present (Alis.Core.Ecs.Test)
- **Sample Apps**: Included (Alis.Core.Ecs.Sample)

## Architecture Notes
1. ECS pattern with structurally-oriented design
2. Zero-allocation queries where possible
3. Event-driven component changes
4. Thread-safe entity management

## Related Projects
- [[Alis.Core.Ecs.Generator]] (4_Operation) - Source generator for ECS
- [[Alis]] (2_Application) - Core application
- [[Alis.Core.Graphic]] (4_Operation) - Graphics subsystem

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
