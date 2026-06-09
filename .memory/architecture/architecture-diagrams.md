# Architecture Diagrams

Mermaid diagrams illustrating the Alis solution architecture.

## Layer Dependency Flow

```mermaid
graph TD
    subgraph "1_Presentation"
        P1[Engine<br/>Main Runtime]
        P2[Hub<br/>Launcher]
        P3[Installer<br/>Setup App]
        P4[Extensions<br/>18+ modules]
    end
    
    subgraph "2_Application"
        A1[Alis<br/>Core App]
        A2[Samples<br/>12+ games]
    end
    
    subgraph "3_Structuration"
        S1[Core<br/>Foundations]
    end
    
    subgraph "4_Operation"
        O1[ECS<br/>Entity System]
        O2[Graphics<br/>Rendering]
        O3[Audio<br/>Sound Engine]
        O4[Physics<br/>Simulation]
    end
    
    subgraph "5_Declaration"
        D1[Contracts<br/>Data Contracts]
    end
    
    subgraph "6_Ideation"
        I1[Memory<br/>State Management]
        I2[Fluent<br/>APIs]
        I3[Data<br/>Structures]
    end
    
    P1 --> S1
    P1 --> O1
    P1 --> O2
    
    A1 --> S1
    A2 --> S1
    
    O1 --> S1
    I1 --> S1
    
    style S1 fill:#e8f5e9
```

## Build System Flow

```mermaid
flowchart TD
    subgraph "Build Process"
        B1[dotnet restore]
        B2[dotnet build]
        B3[dotnet test]
        B4[dotnet publish]
    end
    
    subgraph "Targets"
        T1[.NET Core 2.0-3.1]
        T2[.NET 5.0-10.0]
        T3[.NET Standard 2.0-2.1]
        T4[.NET Framework 4.61-4.81]
    end
    
    subgraph "Platforms"
        P1[Windows x64/x86]
        P2[Linux x64/arm64]
        P3[macOS x64/arm64]
        P4[WebAssembly]
    end
    
    B1 --> B2
    B2 --> B3
    B2 --> B4
    
    B4 --> T1
    B4 --> T2
    B4 --> T3
    B4 --> T4
    
    B4 --> P1
    B4 --> P2
    B4 --> P3
    B4 --> P4
```

## Dependency Graph

| Layer | Dependencies | Direction |
|-------|--------------|-----------|
| 1_Presentation | 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation | ✅ Valid |
| 2_Application | 3_Structuration, 4_Operation | ✅ Valid |
| 3_Structuration | None (Base Layer) | ✅ Valid |
| 4_Operation | 3_Structuration, 5_Declaration | ✅ Valid |
| 5_Declaration | 3_Structuration | ✅ Valid |
| 6_Ideation | 3_Structuration, 5_Declaration | ✅ Valid |

## See Also
- [[Repository Overview]]
- [[Dependency Graph]]
- [[Build System]]
