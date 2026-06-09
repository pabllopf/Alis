---
title: Source Generator Diagrams
tags:
  - diagram
  - visualization
  - mermaid

status: draft

license: GPLv3
---


Mermaid diagrams illustrating source generator architecture and code generation flow.

## Generator Architecture Overview

```mermaid
flowchart TD
    subgraph "Source Generators"
        G1[ECS.Generator]
        G2[Graphic.Generator]
        G3[Memory.Generator]
        G4[Data.Generator]
        G5[Fluent.Generator]
    end
    
    subgraph "Attributes"
        A1[GenerateComponent]
        A2[GenerateSystem]
        A3[GenerateResource]
        A4[GenerateFluent]
    end
    
    subgraph "Generated Code"
        GC1[ComponentRegistry.g.cs]
        GC2[SystemRegistry.g.cs]
        GC3[ResourceLoader.g.cs]
        GC4[FluentBuilder.g.cs]
    end
    
    A1 --> G1
    A2 --> G1
    G1 --> GC1
    G1 --> GC2
    
    A3 --> G3
    G3 --> GC3
    
    A4 --> G5
    G5 --> GC4
    
    style G1 fill:#e3f2fd
    style G2 fill:#e3f2fd
    style G3 fill:#e3f2fd
    style G4 fill:#e3f2fd
    style G5 fill:#e3f2fd
```

## Code Generation Flow

```mermaid
flowchart LR
    subgraph "Input"
        I1[C# Source Files]
        I2[Attribute Annotations]
    end
    
    subgraph "Generator Process"
        P1[Parse Syntax Tree]
        P2[Extract Attributes]
        P3[Generate Code]
        P4[Emit Syntax Tree]
    end
    
    subgraph "Output"
        O1[Generated .g.cs Files]
        O2[Compile-Time Integration]
    end
    
    I1 --> P1
    I2 --> P2
    P1 --> P3
    P2 --> P3
    P3 --> P4
    P4 --> O1
    O1 --> O2
    
    style P3 fill:#c8e6c9
```

## Generator Diagnostics

| ID | Severity | Description |
|----|----------|-------------|
| ALIS001 | Error | Invalid component attribute |
| ALIS002 | Error | Missing required interface |
| ALIS003 | Warning | Unused generated type |
| ALIS004 | Error | Circular dependency detected |
| ALIS005 | Error | Invalid resource marker |

```mermaid
flowchart TD
    subgraph "Diagnostics"
        D1[ALIS001: Invalid Attribute<br/>Error]
        D2[ALIS002: Missing Interface<br/>Error]
        D3[ALIS003: Unused Type<br/>Warning]
        D4[ALIS004: Circular Dependency<br/>Error]
    end
    
    D1 --> Status[✅ All Diagnostics Working]
    D2 --> Status
    D3 --> Status
    D4 --> Status
```

## AOT Compatibility

```mermaid
flowchart LR
    subgraph "AOT Requirements"
        R1[No Runtime IL Emit<br/>✅]
        R2[No Reflection-Based Generation<br/>✅]
        R3[Compile-Time Code Generation<br/>✅]
        R4[Static Generated Code<br/>✅]
    end
    
    subgraph "Result"
        RES[Native AOT Compatible<br/>✅]
    end
    
    R1 --> RES
    R2 --> RES
    R3 --> RES
    R4 --> RES
    
    style RES fill:#c8e6c9
```

## See Also
- [[Generator Pattern]]
- [[Multi-Targeting Strategy]]
