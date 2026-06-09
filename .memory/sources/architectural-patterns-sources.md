---
title: Architectural Patterns in Source Code
tags:
  - source
  - reference
  - documentation

status: draft
---


Design patterns and architectural approaches used throughout the Alis solution.

## Core Patterns

### Entity Component System (ECS)
- **Pattern**: Data-oriented design
- **Location**: `4_Operation/Ecs/src/`
- **Benefits**: Cache efficiency, scalability, deterministic execution

### Dependency Injection
- **Pattern**: Service locator + factory
- **Location**: All layers
- **Usage**: `IServiceCollection`, `IServiceProvider`

### Source Generation
- **Pattern**: Compile-time code generation
- **Location**: `*/generator/` subdirectories
- **Benefits**: AOT compatibility, type safety, performance

### Builder Pattern
- **Pattern**: Fluent API builders
- **Location**: `6_Ideation/Fluent/src/`
- **Usage**: Query builders, configuration builders

### Observer Pattern
- **Pattern**: Event-driven architecture
- **Location**: ECS entity events, logging system
- **Usage**: `PerEntityEvents`, `ILogger`

## Architecture Layers

### Layer Dependencies (strict, never reverse)
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

### Bounded Contexts

| Context | Location | Responsibility |
|---------|----------|----------------|
| **Engine** | `1_Presentation/Engine/` | Runtime execution, game loop |
| **ECS** | `4_Operation/Ecs/` | Entity management, component queries |
| **Graphics** | `4_Operation/Graphic/` | Rendering, graphics APIs |
| **Memory** | `6_Ideation/Memory/` | Resource management, caching |
| **Fluent** | `6_Ideation/Fluent/` | Fluent APIs, builders |

## Design Principles

### SOLID Principles
- **S**ingle Responsibility - Each class has one reason to change
- **O**pen/Closed - Open for extension, closed for modification
- **L**iskov Substitution - Subtypes must be substitutable
- **I**nterface Segregation - Many specific interfaces preferred
- **D**ependency Inversion - Depend on abstractions, not concretions

### DDD (Domain-Driven Design)
- **Bounded Contexts** - Clear context boundaries
- **Value Objects** - Immutable data types (Position, Vector2, etc.)
- **Entities** - ECS entities with identity
- **Aggregates** - Entity groups with consistency boundaries

## See Also
- [[Layered Architecture]]
- [[Aspect-Oriented Design]]
- [[Entity Component System]]
