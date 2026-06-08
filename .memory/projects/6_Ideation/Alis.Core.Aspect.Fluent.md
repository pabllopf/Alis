# Alis.Core.Aspect.Fluent

## Overview
Fluent builder library for ALIS game engine. Provides fluent API interfaces for entity and component configuration.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 6_Ideation
- **Type**: Library (Fluent Aspect)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides fluent builder pattern interfaces for configuring game entities and components. Enables chainable, readable API for entity creation and component configuration throughout the ALIS engine.

## Key Components

### Core Interfaces
- **IHasBuilder<TOut>** - Builder access interface
  - Generic builder pattern for fluent configuration
  
### Words (Configuration Interfaces)
- **ITransform<TBuilder, TArgument>** - Transform configuration
  - Position, rotation, scale setup
  - Fluent chaining support
  
- **IFriction<TBuilder, TArgument>** - Physics friction configuration
  
- **IAuthor<TBuilder>** - Author/metadata configuration

- **IAdd<TBuilder, TArgument>** - Component addition

### Fluent Pattern
1. Type-safe fluent interfaces
2. Builder pattern for complex object creation
3. Chainable configuration methods
4. Compile-time interface validation

## Dependencies
- [[Alis.Core.Aspect.Math]] (6_Ideation) - Vector types for transforms

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: false

## Architecture Notes
1. Interface-based fluent APIs
2. Generic type parameters for type safety
3. Out variance for builder interfaces
4. In variance for argument types

## Testing Status
- **Unit Tests**: Present (Alis.Core.Aspect.Fluent.Test)
- **Sample Apps**: Included (Alis.Core.Aspect.Fluent.Sample)

## Related Projects
- [[Alis.Core.Ecs]] (4_Operation) - Uses fluent builders for entity creation
- [[Alis.Core.Aspect.Math]] (6_Ideation) - Math types for transforms

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
