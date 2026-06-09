---
title: Project Diagrams
tags:
  - project
  - documentation
  - reference

status: draft
---


Mermaid diagrams illustrating project structure and relationships.

## Layer Structure

```mermaid
graph TD
    subgraph "1_Presentation"
        P1[Engine]
        P2[Hub]
        P3[Installer]
        P4[Extensions<br/>18+ modules]
    end
    
    subgraph "2_Application"
        A1[Alis Main]
        A2[Samples<br/>12+ games]
    end
    
    subgraph "3_Structuration"
        S1[Core Library]
    end
    
    subgraph "4_Operation"
        O1[ECS]
        O2[Graphics]
        O3[Audio]
        O4[Physics]
    end
    
    subgraph "5_Declaration"
        D1[Data Contracts]
        D2[Logging]
    end
    
    subgraph "6_Ideation"
        I1[Memory]
        I2[Fluent]
        I3[Data]
        I4[Math]
        I5[Time]
        I6[Logging]
    end
    
    P1 --> S1
    P1 --> O1
    P1 --> O2
    
    A1 --> S1
    A2 --> S1
    
    style S1 fill:#c8e6c9
```

## Project Count by Layer

| Layer | Projects | Documentation Status |
|-------|----------|---------------------|
| 1_Presentation | 5+ | ✅ Complete |
| 2_Application | 1+ | ✅ Complete |
| 3_Structuration | 1 | ✅ Complete |
| 4_Operation | 4 | ✅ Complete |
| 5_Declaration | 1 | ✅ Complete |
| 6_Ideation | 6 | ✅ Complete |

## Extension Categories

```mermaid
flowchart LR
    subgraph "Extension Types"
        E1[Graphic<br/>Ui, Sfml, Glfw, Sdl2]
        E2[Cloud<br/>DropBox, GoogleDrive]
        E3[Payment<br/>Stripe]
        E4[Math<br/>ProceduralDungeon]
        E5[Media<br/>FFmpeg]
    end
    
    subgraph "Integration"
        DI[Dependency Injection]
        EI[Engine Integration]
    end
    
    E1 --> DI
    E2 --> DI
    E3 --> DI
    E4 --> DI
    E5 --> DI
    
    DI --> EI
```

## See Also
- [[Project Index]]
- [[Layered Architecture]]
