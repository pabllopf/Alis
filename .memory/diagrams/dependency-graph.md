---
title: Dependency Graph
tags:
  - diagram
  - visualization
  - mermaid

status: draft
---


## Architecture Overview

```mermaid
graph TD
    subgraph "1_Presentation"
        A[Extensions<br/>~20 projects]
        B[Applications<br/>3 projects]
        C[Samples<br/>~30 projects]
    end
    
    subgraph "2_Application"
        D[Alis Core App]
        E[Game Samples<br/>~14 projects]
    end
    
    subgraph "3_Structuration"
        F[Alis.Core<br/>Core abstractions]
    end
    
    subgraph "4_Operation"
        G[ECS<br/>108 files]
        H[Graphic<br/>147 files]
        I[Audio<br/>5 files]
        J[Physic<br/>39+ files]
    end
    
    subgraph "5_Declaration"
        K[Aspect System<br/>Core aspect]
    end
    
    subgraph "6_Ideation"
        L[Memory Aspect<br/>Asset registry]
        M[Fluent Aspect<br/>Builder pattern]
        N[Data Aspect<br/>JSON serialization]
        O[Math Aspect<br/>Math operations]
        P[Time Aspect<br/>High-res clock]
        Q[Logging Aspect<br/>Logging system]
    end
    
    F --> G
    F --> H
    F --> I
    F --> J
    F --> K
    
    G --> L
    H --> L
    I --> L
    J --> L
    
    K --> L
    K --> M
    K --> N
    K --> O
    K --> P
    K --> Q
    
    A --> F
    B --> F
    C --> F
    D --> F
    E --> F
    
    L --> M
    L --> N
    L --> O
    L --> P
    L --> Q
    
    style G fill:#e1f5fe
    style H fill:#e1f5fe
    style I fill:#c8e6c9
    style J fill:#c8e6c9
    style L fill:#fff9c4
    style M fill:#fff9c4
    style N fill:#fff9c4
    style O fill:#fff9c4
    style P fill:#fff9c4
    style Q fill:#fff9c4
```

## Layer Dependencies

### 1_Presentation → 3_Structuration
- All extensions depend on **Alis.Core** for base abstractions

### 4_Operation → 3_Structuration + 6_Ideation
- **ECS, Graphic** depend on **Alis.Core** and **Memory aspect**
- **Audio, Physic** depend on **Alis.Core** and **Memory aspect**

### 6_Ideation → 3_Structuration + External
- All aspects depend on **Alis.Core**
- **Memory aspect** adds external dependencies: System.Buffers, System.IO.Compression

## Documentation Status

| Layer | Total | Documented | Coverage |
|---|---|---|---|
| 4_Operation | 14 | 4 | 29% |
| 6_Ideation | 18 | 6 | 33% |

## Next Steps

1. Document remaining 4_Operation projects (Input, Resource, Scene, Serialization, Window + tests/generators)
2. Document 6_Ideation generators and samples
3. Process Extensions (1_Presentation/Extension)

## Related

- [[diagrams/architecture-overview]] — Full architecture diagrams
- [[architecture/dependency-graph]] — Dependency rules
- [[dependencies/dependency-graph]] — Raw dependency data
- [[architecture/repository-overview]] — Architecture overview
- [[dependency-index]] — Dependency index
- [[layer-index]] — Layer breakdown
- [[project-index]] — All projects
- [[adr-001-layered-architecture]] — Dependency rules decision

