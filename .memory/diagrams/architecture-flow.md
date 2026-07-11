---
title: Architecture Flow Diagrams
tags:
  - diagram
  - visualization
  - mermaid
  - architecture
status: Draft
license: GPLv3
---

# Architecture Flow Diagrams

## Build Process Flow

```mermaid
flowchart LR
    subgraph "Build Process"
        Solution[alis.slnx] --> Config[Config.props]
        Config --> Platform[Platform Resolution]
        Platform --> Debug[Debug Build]
        Platform --> Release[Release Build]
    end
    
    subgraph "Debug Mode"
        Debug --> Ref[ProjectReference Chain]
        Ref --> Generators[Source Generators]
        Generators --> Compile[Standard Compilation]
    end
    
    subgraph "Release Mode"
        Release --> Merge[Source File Merging]
        Merge --> SingleAssembly[Single Assembly]
        SingleAssembly --> RuntimeCopy[Runtime Native Copy]
        RuntimeCopy --> Pack[NuGet Pack]
    end
```

## ECS Architecture Flow

```mermaid
flowchart TD
    subgraph "ECS Core"
        Entity[Entity] --> Component[Component]
        System[System] --> Entity
        World[World] --> Entity
        World --> System
    end
    
    subgraph "Query Pipeline"
        Query[Query] --> Filter[Archetype Filter]
        Filter --> Enumerate[Entity Enumeration]
        Enumerate --> Execute[System Execution]
    end
    
    subgraph "Update Loop"
        Engine[Engine] --> Tick[Frame Tick]
        Tick --> Update[ECS Update]
        Update --> Physics[Physics Step]
        Physics --> Render[Graphics Render]
        Render --> Tick
    end
```

## Extension Architecture

```mermaid
flowchart TD
    subgraph "Core Engine"
        Engine[Alis.App.Engine]
    end
    
    subgraph "Extension Layer"
        Sdl2[SDL2 Extension]
        Sfml[SFML Extension]
        Glfw[GLFW Extension]
        Ui[UI Extension]
        Network[Network Extension]
    end
    
    subgraph "Common Abstraction"
        Graphic[Alis.Core.Graphic]
    end
    
    Engine --> Graphic
    Graphic --> Sdl2
    Graphic --> Sfml
    Graphic --> Glfw
    Graphic --> Ui
    Engine --> Network
```

## Multi-Platform Targets

```mermaid
flowchart TD
    subgraph "Source Code"
        CSharp[C# Source Files]
    end
    
    subgraph "Build Matrix"
        Windows[win-x64/win-x86/win-arm64]
        MacOS[osx-x64/osx-arm64]
        Linux[linux-x64/linux-arm64/linux-arm]
        Browser[browser-wasm]
    end
    
    subgraph "Framework Targets"
        Net10[net10.0]
        Net8[net8.0]
        Net5[net5.0]
        NetCore[netcoreapp2.0-3.1]
        NetStd[netstandard2.0-2.1]
        NetFx[net461-481]
    end
    
    CSharp --> Windows
    CSharp --> MacOS
    CSharp --> Linux
    CSharp --> Browser
    
    Windows --> Net10
    Windows --> Net8
    Windows --> NetFx
    MacOS --> Net10
    MacOS --> Net8
    Linux --> Net10
    Linux --> Net8
    Linux --> NetCore
    Browser --> Net8
```

## Related

- [[Architecture Overview]]
- [[Dependency Graph]]
- [[Repository Overview]]
