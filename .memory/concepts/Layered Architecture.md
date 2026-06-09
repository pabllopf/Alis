# Layered Architecture

tags:
  - concept,theory,documentation

Alis uses a 6-layer numbered directory structure that progresses from concrete to abstract, following dependency inversion principles.

## Layer Dependency Order (strict, never reverse)

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

## Detailed Layer Breakdown

### 1_Presentation - Most Concrete
**Purpose**: User-facing applications and runtime engine

**Contents**:
- **Engine/** - Main game engine runtime
- **Hub/** - Hub application for management
- **Installer/** - Installation application
- **Extension/** - 18+ modular extensions:
  - Graphics: Ui, Sfml, Glfw, Sdl2
  - Cloud: DropBox, GoogleDrive
  - Payment: Stripe
  - Math: ProceduralDungeon, HighSpeedPriorityQueue
  - Media: FFmpeg
  - Network, Thread, Security, Ads, Io, Language, Profile, Updater

### 2_Application - Application Layer
**Purpose**: Main application composition and sample games

**Contents**:
- **Alis/src/** - Main application entry point
- **samples/** - 12 sample games (each with Web + Desktop variants)

### 3_Structuration - Core Abstractions
**Purpose**: Foundational libraries and core abstractions

**Contents**:
- **Core/** - Core library with foundational types

### 4_Operation - Operational Systems
**Purpose**: Platform operations and systems

**Contents**:
- **Ecs/** - Entity Component System (with source generator)
- **Graphic/** - Graphics rendering (with source generator)
- **Audio/** - Audio processing
- **Physic/** - Physics engine

### 5_Declaration - Declarative Foundation
**Purpose**: Declarative programming constructs

**Contents**:
- **Aspect/** - Core.Aspect - declarative programming foundation

### 6_Ideation - Most Abstract
**Purpose**: Experimental and innovative aspects

**Contents**:
- **Memory/** - Memory abstractions (with source generator)
- **Fluent/** - Fluent APIs (with source generator)
- **Math/** - Mathematical utilities
- **Time/** - Time management
- **Data/** - Data structures (with source generator)
- **Logging/** - Logging infrastructure

## Project Structure Per Module

Each module typically contains:
- `src/` - Source code
- `test/` - Unit and integration tests
- `sample/` - Sample applications (where applicable)
- `generator/` - Source generators (where applicable)

## See Also
- [[Alis Architecture Overview]]
- [[Aspect-Oriented Design]]
- [[Solution Composition]]
- [[Generator Pattern]]
- [[Extension System]]
- [[Entity Component System]]
- [[Multi-Targeting Strategy]]
- [[Platform-Specific Build Constants]]

## Related Architecture

- [[repository-overview]] — Full architecture overview
- [[architecture/dependency-graph]] — Layer dependency rules
- [[adr-001-layered-architecture]] — ADR for this architecture
- [[adr-002-aggregator-pattern]] — Aggregator design
- [[build-system]] — Build configuration
- [[layer-index]] — Layer breakdown index

## Related Glossary

- [[entity-component-system-ecs]] — ECS architecture
- [[archetype]] — Component type optimization
- [[component]] — Data-only struct pattern
- [[layer-dependency-order]] — Strict dependency rules
