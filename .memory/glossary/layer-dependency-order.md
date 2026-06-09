---
title: Layer Dependency Order
tags:
  - glossary
  - terminology
  - reference

status: draft
---


## Definition

The **Layer Dependency Order** defines the strict dependency hierarchy for the Alis monorepo, ensuring architectural boundaries are maintained and dependencies flow in one direction only.

## Dependency Hierarchy

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

### Layer 1: Presentation

**Purpose**: Engine, extensions, UI, runtime frontends

**Examples**:
- `1_Presentation/Engine` - Core engine implementation
- `1_Presentation/Extension` - Platform extensions
- `1_Presentation/Benchmark` - Performance benchmarks

**Dependencies**: None (lowest layer)

### Layer 2: Application

**Purpose**: Alis core, samples, executable compositions

**Examples**:
- `2_Application/Alis` - Main application
- `2_Application/Samples` - Example applications

**Dependencies**: Layer 1

### Layer 3: Structuration

**Purpose**: Core abstractions, base infrastructure

**Examples**:
- `3_Structuration/Core` - Base abstractions and interfaces

**Dependencies**: Layer 2

### Layer 4: Operation

**Purpose**: Graphics, audio, media, platform operations

**Examples**:
- `4_Operation/Ecs` - Entity Component System
- `4_Operation/Physic` - Physics engine
- `4_Operation/Graphic` - Graphics rendering
- `4_Operation/Audio` - Audio processing

**Dependencies**: Layer 3

### Layer 5: Declaration

**Purpose**: Contracts, interfaces, metadata

**Examples**:
- `5_Declaration/Aspect` - Contract definitions

**Dependencies**: Layer 4

### Layer 6: Ideation

**Purpose**: Experimental modules, research projects

**Examples**:
- `6_Ideation/Memory` - Memory management experiments
- `6_Ideation/Fluent` - Fluent interface implementations
- `6_Ideation/Math` - Mathematical utilities
- `6_Ideation/Time` - Time management

**Dependencies**: Layer 5

## Dependency Rules

### Strict Direction

- Lower layers NEVER depend on higher layers
- Each layer can only reference layers below it
- Circular dependencies are forbidden

### Validation

```csharp
// Valid: Layer 1 → Layer 2
using Alis.Core.Presentation;

// Invalid: Layer 2 → Layer 1 (forbidden)
using Alis.Core.Operation; // Compilation error
```

## Layer Violations

Violations detected:

- Higher layer accessing lower layer APIs directly
- Cross-layer dependencies in project references
- Circular references between layers

## Related

- [[Layered Architecture]] — Layer structure concept
- [[adr-001-layered-architecture]] — Layer architecture decision
- [[architecture/dependency-graph]] — Layer dependency rules
- [[layer-index]] — Layer breakdown
- [[dependency-index]] — Dependency map
- [[architecture-index]] — Patterns index
- [[projects/Architecture]] — Project architecture
- [[naming-conventions]] — Layer naming
