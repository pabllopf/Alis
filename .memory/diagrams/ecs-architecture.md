---
title: ECS Architecture
tags:
  - diagram
  - visualization
  - mermaid
---


## Core Data Flow

```mermaid
flowchart LR
    subgraph "Storage Layer"
        STORAGE[Archetype Chunks<br/>Contiguous arrays per component type]
    end
    
    subgraph "Creation"
        ENTITY[Entity Created]
        COMP[Components Added]
        ENTITY -->|scene.Create&lt;T&gt;| STORAGE
        COMP -->|archetype assignment| STORAGE
    end
    
    subgraph "Query Layer"
        Q_REG[Query Registration<br/>typeof With&lt;T1, T2&gt;]
        Q_MATCH[Archetype Matching<br/>Bitmask intersection]
        Q_ENUM[Chunk Enumeration<br/>ChunkTuple&lt;T&gt;]
    end
    
    subgraph "System Execution"
        INLINE[Inline Query<br/>IAction&lt;T&gt; struct]
        DELEGATE[Delegate Query<br/>ref T lambda]
        SIMD[SIMD Vectorized<br/>Vector256&lt;T&gt;]
    end
    
    STORAGE --> Q_REG
    Q_REG --> Q_MATCH
    Q_MATCH --> Q_ENUM
    Q_ENUM --> INLINE
    Q_ENUM --> DELEGATE
    Q_ENUM --> SIMD
```

## Chunk-Based Storage

```mermaid
block-beta
    columns 1
    block "Scene" 
        block "Archetype A (1 component)"
            c1_1["Chunk 1<br/>Component1[]"]
            c1_2["Chunk 2<br/>Component1[]"]
        end
        block "Archetype B (2 components)"
            c2_1["Chunk 1<br/>Component1[] + Component2[]"]
        end
    end
    
    style c1_1 fill:#e1f5fe
    style c1_2 fill:#e1f5fe
    style c2_1 fill:#c8e6c9
```

## Entity Component Composition

```mermaid
flowchart LR
    subgraph "Entity"
        ENT[GameObject]
    end
    
    subgraph "Components"
        SPRITE[Sprite]
        COLLIDER[BoxCollider]
        AUDIO[AudioSource]
        SCRIPT[Custom Script<br/>IOnStart, IOnUpdate, ...]
        CAMERA[Camera]
        ANIMATOR[Animator]
        TRANSFORM[Transform]
    end
    
    ENT --> TRANSFORM
    ENT --> SPRITE
    ENT --> COLLIDER
    ENT --> AUDIO
    ENT --> SCRIPT
    ENT --> CAMERA
    ENT --> ANIMATOR
```

## System Execution Comparison

```mermaid
xychart-beta
    title "ECS Query Execution Strategies"
    x-axis ["Inline Struct", "Delegate", "SIMD"]
    y-axis "Performance" 0 --> 100
    bar [75, 60, 95]
```

## Available Queries

```mermaid
flowchart TD
    subgraph "Query Types"
        Q_INLINE[Query.Inline&lt;TAction, T&gt;]
        Q_DELEGATE[Query.Delegate(ref T)]
        Q_SIMD[Manual SIMD<br/>MemoryMarshal.Cast + Vector256]
        Q_CHUNK[Query.EnumerateChunks&lt;T&gt;]
    end
    
    Q_CHUNK --> Q_SIMD
    Q_CHUNK --> Q_INLINE
    
    subgraph "Create Patterns"
        C_SINGLE[scene.Create&lt;T&gt;]
        C_MULTI[scene.CreateMany&lt;T&gt;]
        C_BULK[scene.Create&lt;T1, T2, ...&gt;]
    end
    
    C_SINGLE --> STORAGE[(Chunk Storage)]
    C_MULTI --> STORAGE
    C_BULK --> STORAGE
```

## Related
- [[projects/4_Operation/Alis.Core.Ecs]] — Full ECS documentation
- [[diagrams/architecture-overview]] — Layer context
- [[diagrams/dependency-graph]] — Module dependencies
- [[diagrams/game-pipeline]] — Game bootstrap flow
