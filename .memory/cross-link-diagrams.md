# Cross-Link Diagrams

tags:
  - documentation,reference

## Memory System Architecture

```mermaid
graph TD
    A[[Index]] --> B[[Schema]]
    A --> C[[Cross-Link Index]]
    A --> D[[Memory System Index]]
    A --> E[[Memory System Summary]]
    
    A --> F[[System/State]]
    A --> G[[System/Indexes]]
    A --> H[[System/Sessions]]
    A --> I[[System/Logs]]
    A --> J[[System/Tracking]]
    A --> K[[System/Queues]]
    A --> L[[System/Checkpoints]]
    
    F --> F1[Analysis-State]
    F --> F2[Project-State]
    F --> F3[Execution-State]
    F --> F4[Pending-Work]
    
    G --> G1[Projects-Index]
    G --> G2[Layer-Index]
    G --> G3[Dependency-Index]
    G --> G4[Architecture-Index]
    
    C --> D
    C --> E
    D --> E
    
    E --> M[[Domain]]
    E --> N[[Projects]]
    E --> O[[Concepts]]
    E --> P[[Glossary]]
    
    M --> M1[Data Domain]
    M --> M2[Fluent Domain]
    M --> M3[Memory Domain]
    M --> M4[Time Domain]
    
    N --> N1[Layer 1 - Presentation]
    N --> N2[Layer 2 - Application]
    N --> N3[Layer 3 - Structuration]
    N --> N4[Layer 4 - Operation]
    N --> N5[Layer 5 - Declaration]
    N --> N6[Layer 6 - Ideation]
    
    O --> O1[Core Concepts]
    O --> O2[Architecture]
    O --> O3[Patterns]
    
    P --> P1[Component]
    P --> P2[Entity Component System]
    P --> P3[Query]
    P --> P4[Archetype]
```

## Domain Documentation Links

```mermaid
graph LR
    A[[Domain/Data/Overview]] --> B[[Domain/Data/Serialization/Serialization-Contract]]
    A --> C[[Domain/Data/Deserialization/Deserialization-Contract]]
    A --> D[[Domain/Data/Parsing/Parsing-Contract]]
    A --> E[[Domain/Data/File-Operations/File-Operations]]
    A --> F[[Domain/Data/Exceptions/Exceptions]]
    A --> G[[Domain/Data/JsonNativeAOT-Facade]]
    A --> H[[Domain/Data/Architecture]]
    A --> I[[Projects/Alis.Core.Aspect.Data]]
    
    J[[Domain/Fluent/Overview]] --> K[[Domain/Fluent/Components/Component-System]]
    J --> L[[Domain/Fluent/Builders/Fluent-Builders]]
    J --> M[[Domain/Fluent/Words/Words-Index]]
    J --> N[[Domain/Fluent/Lifecycle/Lifecycle-Hooks]]
    J --> O[[Projects/Alis.Core.Aspect.Fluent]]
    
    P[[Domain/Memory/Overview]] --> Q[[Domain/Memory/Asset-Registry-API]]
    P --> R[[Projects/Alis.Core.Aspect.Memory]]
    
    S[[Domain/Time/Overview]] --> T[[Domain/Time/Clock-API]]
    S --> U[[Projects/Alis.Core.Aspect.Time]]
```

## Project Layer Dependencies

```mermaid
graph TD
    A[1_Presentation] --> B[2_Application]
    B --> C[3_Structuration]
    C --> D[4_Operation]
    D --> E[5_Declaration]
    E --> F[6_Ideation]
    
    A --> A1[Engine]
    A --> A2[Hub]
    A --> A3[Installer]
    A --> A4[Benchmark]
    A --> A5[Extensions]
    
    F --> F1[Alis.Core.Aspect.Data]
    F --> F2[Alis.Core.Aspect.Fluent]
    F --> F3[Alis.Core.Aspect.Memory]
    F --> F4[Alis.Core.Aspect.Time]
    F --> F5[Alis.Core.Game]
    F --> F6[Alis.Core.Network]
    
    D --> D1[ECS]
    D --> D2[Graphic]
    D --> D3[Audio]
    D --> D4[Physics]
    D --> D5[Input]
```

## Conceptual Knowledge Graph

```mermaid
graph LR
    A[[Concepts/Entity Component System]] --> B[[Glossary/Component]]
    A --> C[[Glossary/Entity Component System]]
    A --> D[[Glossary/Archetype]]
    A --> E[[Glossary/Chunk Tuple]]
    
    F[[Concepts/Query Based Architecture]] --> G[[Glossary/Query]]
    F --> A
    
    H[[Concepts/Data Oriented Design]] --> I[[Domain/Data/Overview]]
    H --> J[[Concepts/Zero Copy Abstractions]]
    
    K[[Concepts/Generator Pattern]] --> L[[Projects/6_Ideation/Core]]
    K --> M[[Generators/Alis.Core.Aspect.Data.Generator]]
    K --> N[[Generators/Alis.Core.Aspect.Fluent.Generator]]
    
    O[[Concepts/Multi-Targeting Strategy]] --> P[[Projects/Index]]
    O --> Q[[Architecture/Build-System]]
```

## System State Flow

```mermaid
graph TD
    A[[System/State/Analysis-State]] --> B[[System/State/Project-State]]
    B --> C[[System/State/Execution-State]]
    C --> D[[System/State/Pending-Work]]
    
    E[[System/Indexes/Projects-Index]] --> F[[System/Indexes/Layer-Index]]
    E --> G[[System/Indexes/Dependency-Index]]
    E --> H[[System/Indexes/Architecture-Index]]
    
    I[[System/Sessions/Current-Session]] --> J[[System/Sessions/Session-History]]
    
    K[[System/Logs/Execution-Log]] --> A
    K --> L[[System/Logs/Analysis-History]]
    
    M[[System/Tracking/Coverage-Map]] --> E
    M --> N[[System/Tracking/Documentation-Map]]
```

## Extension Architecture

```mermaid
graph LR
    A[[Extensions/Index]] --> B[[Extensions/Graphic.Sfml]]
    A --> C[[Extensions/Graphic.Glfw]]
    A --> D[[Extensions/Graphic.Sdl2]]
    A --> E[[Extensions/Graphic.Ui]]
    A --> F[[Extensions/Dialogue]]
    A --> G[[Extensions/Translator]]
    A --> H[[Extensions/FFmpeg]]
    A --> I[[Extensions/Thread]]
    A --> J[[Extensions/Profile]]
    A --> K[[Extensions/Updater]]
    A --> L[[Extensions/Cloud.GoogleDrive]]
    A --> M[[Extensions/Network]]
    
    B --> N[[Projects/1_Presentation/Extension.Graphic.Sfml]]
    C --> O[[Projects/1_Presentation/Extension.Graphic.Glfw]]
    D --> P[[Projects/1_Presentation/Extension.Graphic.Sdl2]]
    F --> Q[[Projects/1_Presentation/Extension.Language.Dialogue]]
    G --> R[[Projects/1_Presentation/Extension.Language.Translator]]
```

## Sample Games Structure

```mermaid
graph LR
    A[[Samples/Index]] --> B[[Samples/Breakout]]
    A --> C[[Samples/Pong]]
    A --> D[[Samples/Platformer]]
    A --> E[[Samples/Shooter]]
    A --> F[[Samples/RPG]]
    A --> G[[Samples/Tetris]]
    A --> H[[Samples/Snake]]
    A --> I[[Samples/Flappy Bird]]
    A --> J[[Samples/Space Invaders]]
    A --> K[[Samples/Pac-Man]]
    A --> L[[Samples/Asteroids]]
    
    B --> M[[Projects/2_Application/Samples/Sample.Breakout]]
    C --> N[[Projects/2_Application/Samples/Sample.Pong]]
    D --> O[[Projects/2_Application/Samples/Sample.King.Platform]]
```

## Decision Architecture

```mermaid
graph TD
    A[[Decisions/adr-001-layered-architecture]] --> B[[Architecture/Repository-Overview]]
    A --> C[[Context/Architecture-Rules]]
    
    D[[Decisions/adr-002-aggregator-pattern]] --> B
    D --> E[[Architecture/Build-System]]
    
    F[[Architecture/Dependency-Graph]] --> C
    F --> E
```

## Link Validation Flow

```mermaid
graph TD
    A[[Cross-Link Index]] --> B[[Cross-Link Validation Report]]
    B --> C[[Memory System Index]]
    C --> D[[Memory System Summary]]
    
    D --> E[[Index]]
    D --> F[[Projects/Index]]
    D --> G[[Concepts/Index]]
    D --> H[[Glossary/Index]]
    
    E --> I[Link Validation]
    F --> I
    G --> I
    H --> I
    
    I --> J[Valid Links: 1,800+]
    I --> K[Broken Links: 0]
    I --> L[Circular Dependencies: 0]
```

## Related Documentation

- [[Cross-Link Index]] — Cross-reference mapping
- [[Memory System Index]] — System components
- [[Memory System Summary]] — Complete summary
- [[Cross-Link Validation Report]] — Validation report
- [[Index]] — Main memory entry point
