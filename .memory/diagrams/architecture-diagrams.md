---
title: Architecture Diagrams
tags:
  - diagram
  - visualization
  - mermaid

status: Draft

license: GPLv3

---


Mermaid diagrams illustrating the Alis solution architecture and relationships.

## Layer Dependency Diagram

```mermaid
graph TD
    subgraph "1_Presentation"
        P1[Engine]
        P2[Hub]
        P3[Installer]
        P4[Extensions]
        P5[Benchmark]
    end
    
    subgraph "2_Application"
        A1[Alis Main App]
        A2[Samples]
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
        D1[Core.Aspect]
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
    P1 --> D1
    P1 --> I1
    P2 --> S1
    P3 --> S1
    P4 --> S1
    P4 --> O1
    P4 --> O2
    P5 --> O1
    
    A1 --> S1
    A1 --> O1
    A1 --> O2
    A2 --> S1
    
    O1 --> S1
    O1 --> D1
    O2 --> S1
    
    I1 --> S1
    I1 --> D1
    I2 --> S1
    I2 --> D1
    I3 --> S1
    I3 --> D1
    I4 --> S1
    I5 --> S1
    I6 --> S1
```

## Solution File Dependencies

```mermaid
graph LR
    subgraph "Solution Files"
        S1[alis.slnx<br/>Full Solution]
        S2[alis.core.slnx<br/>Core Libraries]
        S3[alis.apps.slnx<br/>Applications]
        S4[alis.extensions.slnx<br/>Extensions]
        S5[alis.test.slnx<br/>Tests]
        S6[alis.samples.slnx<br/>Samples]
        S7[alis.core.aspect.slnx<br/>Aspects]
        S8[alis.benchmark.slnx<br/>Benchmarks]
    end
    
    S2 --> S1
    S3 --> S1
    S4 --> S1
    S5 --> S1
    S6 --> S1
    S7 --> S1
    S8 --> S1
    
    S2 -.-> S3
    S2 -.-> S4
    S2 -.-> S7
```

## ECS Architecture Flow

```mermaid
flowchart TD
    subgraph "ECS Core"
        E[Entities<br/>Unique IDs]
        C[Components<br/>Data-only structs]
        S[Systems<br/>Logic processors]
    end
    
    subgraph "Source Generator"
        G[ComponentUpdateTypeRegistryGenerator]
        G2[SystemRegistryGenerator]
    end
    
    subgraph "Generated Code"
        GC[AlisComponentRegistry.g.cs]
        GS[SystemRegistry.g.cs]
    end
    
    E --> C
    C --> S
    S --> E
    
    G --> GC
    G2 --> GS
    
    style E fill:#e1f5fe
    style C fill:#f3e5f5
    style S fill:#e8f5e9
```

## Multi-Platform Build Flow

```mermaid
flowchart LR
    subgraph "Source Code"
        SRC[C# Source Files]
    end
    
    subgraph "Build Configuration"
        CFG[Config.props<br/>Multi-targeting]
    end
    
    subgraph "Target Frameworks"
        TF1[.NET Core<br/>2.0-3.1]
        TF2[.NET<br/>5.0-10.0]
        TF3[.NET Standard<br/>2.0-2.1]
        TF4[.NET Framework<br/>4.61-4.81]
    end
    
    subgraph "Runtime Identifiers"
        RI1[Windows<br/>x64/x86]
        RI2[Linux<br/>x64/arm64]
        RI3[macOS<br/>x64/arm64]
        RI4[WebAssembly]
        RI5[iOS/Android]
    end
    
    SRC --> CFG
    CFG --> TF1
    CFG --> TF2
    CFG --> TF3
    CFG --> TF4
    CFG --> RI1
    CFG --> RI2
    CFG --> RI3
    CFG --> RI4
    CFG --> RI5
```

## Extension System Architecture

```mermaid
flowchart TD
    subgraph "Extension Categories"
        E1[Graphics<br/>Ui, Sfml, Glfw, Sdl2]
        E2[Cloud<br/>DropBox, GoogleDrive]
        E3[Payment<br/>Stripe]
        E4[Math<br/>ProceduralDungeon, HighSpeedPriorityQueue]
        E5[Media<br/>FFmpeg]
        E6[Network, Thread, Security]
        E7[Language<br/>Translator, Dialogue]
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
    E6 --> DI
    E7 --> DI
    
    DI --> EI
    EI --> Engine[Main Engine]
```

## See Also
- [[Layered Architecture]]
- [[Entity Component System]]
- [[Extension System]]
