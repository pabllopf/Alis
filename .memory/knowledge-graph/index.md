---
title: Knowledge Graph Index
tags:
  - knowledge-graph
  - index
  - relationships
status: Draft
license: GPLv3
---

# Knowledge Graph Index

## Core Relationships

```mermaid
graph TD
    subgraph "Documentation Structure"
        Overview[Repository Overview] --> Architecture[Architecture Overview]
        Overview --> Projects[Projects Index]
        Overview --> Dependencies[Dependency Index]
        
        Architecture --> Build[Build System]
        Architecture --> ADRs[ADR Records]
        Architecture --> Rules[Architecture Rules]
        
        Projects --> Core[Alis.Core]
        Projects --> ECS[Alis.Core.Ecs]
        Projects --> Engine[Alis.App.Engine]
        Projects --> Aspect[Alis.Core.Aspect]
        
        Dependencies --> Graph[Dependency Graph]
        Dependencies --> Constraints[Dependency Constraints]
        
        ECS --> ECSArch[ECS Architecture]
        Aspect --> Data[Alis.Core.Aspect.Data]
        Aspect --> Logging[Alis.Core.Aspect.Logging]
        Aspect --> Math[Alis.Core.Aspect.Math]
    end
    
    subgraph "Cross-Links"
        Security[Security Overview] --> All
        Testing[Testing Overview] --> All
        Performance[Performance Overview] --> All
        Onboarding[Developer Onboarding] --> All
    end
```

## Architectural Clusters

### Core Engine Cluster
- [[Alis.App.Engine]] - Main engine application
- [[Alis.Core.Ecs]] - ECS architecture
- [[Alis.Core.Graphic]] - Graphics rendering
- [[Alis.Core.Physic]] - Physics simulation
- [[Alis.Core.Audio]] - Audio system
- [[Alis.Core.Aspect]] - Aspect framework

### Extension Cluster
- [[Alis.Extension.Graphic.Sdl2]]
- [[Alis.Extension.Graphic.Sfml]]
- [[Alis.Extension.Graphic.Glfw]]
- [[Alis.Extension.Graphic.Ui]]
- [[Alis.Extension.Network]]
- [[Alis.Extension.Security]]

### Build & Configuration Cluster
- [[Build System]]
- [[Config.props Reference]]
- [[Generators]]
- [[Technology Stack]]

### Sample Games Cluster
- [[Alis.Sample.Asteroid]]
- [[Alis.Sample.FlappyBird]]
- [[Alis.Sample.Pong]]
- [[Alis.Sample.KingPlatform]]
- [[Samples Index]]

## Semantic Tags

| Tag | Documents |
|---|---|
| #architecture | Architecture, Build, Config |
| #ecs | ECS, Samples |
| #security | Security Overview |
| #performance | Performance Overview |
| #testing | Testing Overview |
| #samples | All sample docs |
| #generator | All generator docs |
| #layer-1 | All presentation projects |
| #layer-6 | All ideation projects |

## Related

- [[Glossary Index]]
- [[Concepts Index]]
- [[System Metadata Index]]
