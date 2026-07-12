---
title: Architecture Overview
tags:
  - architecture
  - overview
  - layers
status: Draft
license: GPLv3
---

# Architecture Overview

## 6-Layer Architecture

Alis enforces a strict 6-layer dependency architecture via MSBuild configuration.

```mermaid
graph TD
    subgraph "1_Presentation"
        Engine
        Hub
        Installer
        Benchmark
        Extension_Network
        Extension_Profile
        Extension_Security
        Extension_Thread
        Extension_Updater
    end
    
    subgraph "2_Application"
        Alis["Alis (Main Assembly)"]
    end
    
    subgraph "3_Structuration"
        Core["Alis.Core"]
    end
    
    subgraph "4_Operation"
        Audio
        Ecs
        Graphic
        Physic
    end
    
    subgraph "5_Declaration"
        Aspect["Alis.Core.Aspect"]
    end
    
    subgraph "6_Ideation"
        Data
        Fluent
        Logging
        Math
        Memory
        Time
    end
    
    Engine --> Alis
    Hub --> Alis
    Installer --> Alis
    Benchmark --> Alis
    Extension_Network --> Alis
    Extension_Profile --> Alis
    Extension_Security --> Alis
    Extension_Thread --> Alis
    Extension_Updater --> Alis
    
    Alis --> Core
    
    Core --> Audio
    Core --> Ecs
    Core --> Graphic
    Core --> Physic
    
    Audio --> Aspect
    Ecs --> Aspect
    Graphic --> Aspect
    Physic --> Aspect
    
    Aspect --> Data
    Aspect --> Fluent
    Aspect --> Logging
    Aspect --> Math
    Aspect --> Memory
    Aspect --> Time
```

## Dependency Flow

Each layer can only reference the layer immediately below it (and transitively, all layers below).

```
Presentation (apps, extensions)
    ↓
Application (main Alis assembly)
    ↓
Structuration (Core abstractions)
    ↓
Operation (Audio, ECS, Graphics, Physics)
    ↓
Declaration (Aspect contracts)
    ↓
Ideation (Data, Math, Memory, Time, Logging, Fluent)
```

## Source Generator Flow

Source generators (netstandard2.0 analyzers) are referenced from higher layers down:

```
Presentation → all generators
Application → generators from layers 3-6
Structuration → generators from layers 4-6
Operation → generators from layers 5-6
Declaration → generators from layer 6
```

## Project Template Pattern

Every module follows the same structure:

```
<module>/
├── generator/     (Roslyn source generator, netstandard2.0)
├── sample/        (usage example project)
├── src/           (main library source)
└── test/          (xUnit test project)
```

## Build Pipeline

```mermaid
graph LR
    A[Source Files] --> B[Roslyn Compiler]
    B --> C[Source Generators]
    C --> B
    B --> D[Multi-target Build]
    D --> E[Debug TFMs]
    D --> F[Release TFMs]
    D --> G[Platform-specific]
    E --> H[Unit Tests]
    H --> I[Test Results .test/]
```

## Architectural Constraints

1. **No reverse layer dependencies** - enforced by MSBuild Config.props
2. **No external NuGet dependencies in core** - only SourceLink
3. **No LINQ in hot paths**
4. **No boxing, reflection, runtime emit in hot paths**
5. **AOT compatibility required** - no Reflection.Emit
6. **Prefer Span<T>, SIMD, data-oriented design**
7. **Expression-bodied members preferred**
8. **No `var` for built-in types**
9. **No comments** - only XML doc comments
10. **Block-scoped namespaces**

## Related Documents

- [[repository-overview]]
- [[dependency-graph]]
- [[source-generator-architecture]]
- [[multi-targeting-strategy]]
- [[build-pipeline]]
