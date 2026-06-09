---
title: Cross-Link Index
tags: [project,documentation,reference]
---


## Overview

This document provides a complete mapping of all cross-references between documentation files in the ALIS memory system. It ensures proper navigation and relationship tracking across all 154+ documentation files.

## Link Types

| Type | Description | Example |
|---|---|---|
| **See Also** | Related documentation | [[Architecture]] |
| **Parent** | Parent category | [[Domain/Time]] |
| **Child** | Child documentation | [[Domain/Time/Clock-API]] |
| **Reference** | External reference | [[Alis.Core.Aspect.Time]] |
| **Dependency** | Project dependency | [[Alis.Core.Aspect.Fluent]] |
| **Concept** | Conceptual link | [[Entity Component System]] |
| **Decision** | ADR reference | [[adr-001-layered-architecture]] |

## Cross-Link Matrix

### Architecture Links

| From | To | Type |
|---|---|---|
| All project docs | [[architecture/repository-overview]] | Reference |
| All project docs | [[context/architecture-rules]] | Reference |
| All project docs | [[context/dependency-constraints]] | Reference |
| [[projects/Index]] | [[architecture/dependency-graph]] | Reference |
| [[architecture/dependency-graph]] | [[context/dependency-constraints]] | Reference |
| [[decisions/adr-001-layered-architecture]] | [[architecture/repository-overview]] | Reference |

### Domain Links

| From | To | Type |
|---|---|---|
| [[Domain/Data/Overview]] | [[Domain/Data/Serialization/Serialization-Contract]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/Deserialization/Deserialization-Contract]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/Parsing/Parsing-Contract]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/File-Operations/File-Operations]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/Exceptions/Exceptions]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/JsonNativeAOT-Facade]] | Child |
| [[Domain/Data/Overview]] | [[Domain/Data/Architecture]] | Child |
| [[Domain/Data/Overview]] | [[Dependencies/Data-Aspect-Dependencies]] | Reference |
| [[Domain/Data/Overview]] | [[Projects/Alis.Core.Aspect.Data]] | Reference |
| [[Domain/Fluent/Overview]] | [[Domain/Fluent/Components/Component-System]] | Child |
| [[Domain/Fluent/Overview]] | [[Domain/Fluent/Builders/Fluent-Builders]] | Child |
| [[Domain/Fluent/Overview]] | [[Domain/Fluent/Words/Words-Index]] | Child |
| [[Domain/Fluent/Overview]] | [[Domain/Fluent/Lifecycle/Lifecycle-Hooks]] | Child |
| [[Domain/Fluent/Overview]] | [[Domain/Fluent/Architecture]] | Child |
| [[Domain/Fluent/Overview]] | [[Projects/Alis.Core.Aspect.Fluent]] | Reference |
| [[Domain/Memory/Overview]] | [[Domain/Memory/Asset-Registry-API]] | Child |
| [[Domain/Memory/Overview]] | [[Projects/Alis.Core.Aspect.Memory]] | Reference |
| [[Domain/Time/Overview]] | [[Domain/Time/Clock-API]] | Child |
| [[Domain/Time/Overview]] | [[Projects/Alis.Core.Aspect.Time]] | Reference |

### Project Links

| From | To | Type |
|---|---|---|
| [[Projects/Alis.Core.Aspect.Data]] | [[Domain/Data/Overview]] | Reference |
| [[Projects/Alis.Core.Aspect.Fluent]] | [[Domain/Fluent/Overview]] | Reference |
| [[Projects/Alis.Core.Aspect.Memory]] | [[Domain/Memory/Overview]] | Reference |
| [[Projects/Alis.Core.Aspect.Time]] | [[Domain/Time/Overview]] | Reference |
| [[Projects/6_Ideation/Core]] | [[Projects/Alis.Core.Game]] | Reference |
| [[Projects/6_Ideation/Core]] | [[Projects/Alis.Core.Network]] | Reference |
| [[Projects/4_Operation/Core]] | [[Projects/4_Operation/Ecs]] | Reference |
| [[Projects/4_Operation/Core]] | [[Projects/4_Operation/Graphic]] | Reference |
| [[Projects/4_Operation/Core]] | [[Projects/4_Operation/Audio]] | Reference |
| [[Projects/4_Operation/Core]] | [[Projects/4_Operation/Physic]] | Reference |

### Concept Links

| From | To | Type |
|---|---|---|
| [[Domain/Fluent/Components/Component-System]] | [[Concepts/Entity Component System]] | Concept |
| [[Domain/Fluent/Lifecycle/Lifecycle-Hooks]] | [[Concepts/Update Loop Game Loop]] | Concept |
| [[Domain/Data/Overview]] | [[Concepts/Data Oriented Design]] | Concept |
| [[Domain/Data/Overview]] | [[Concepts/Zero Copy Abstractions]] | Concept |
| [[Domain/Memory/Overview]] | [[Concepts/Resource Management Patterns]] | Concept |
| [[Domain/Time/Overview]] | [[Concepts/High Speed Priority Queue]] | Concept |
| [[Projects/6_Ideation/Alis.Core.Game]] | [[Concepts/Entity Component System]] | Concept |
| [[Projects/6_Ideation/Alis.Core.Network]] | [[Concepts/Event Driven Entity System]] | Concept |

### Extension Links

| From | To | Type |
|---|---|---|
| [[Extensions/Graphic.Sfml]] | [[Projects/1_Presentation/Extension.Graphic.Sfml]] | Reference |
| [[Extensions/Graphic.Glfw]] | [[Projects/1_Presentation/Extension.Graphic.Glfw]] | Reference |
| [[Extensions/Graphic.Sdl2]] | [[Projects/1_Presentation/Extension.Graphic.Sdl2]] | Reference |
| [[Extensions/Dialogue]] | [[Projects/1_Presentation/Extension.Language.Dialogue]] | Reference |
| [[Extensions/Translator]] | [[Projects/1_Presentation/Extension.Language.Translator]] | Reference |
| [[Extensions/FFmpeg]] | [[Projects/1_Presentation/Extension.Media.FFmpeg]] | Reference |
| [[Extensions/Thread]] | [[Projects/1_Presentation/Extension.Thread]] | Reference |
| [[Extensions/Profile]] | [[Projects/1_Presentation/Extension.Profile]] | Reference |
| [[Extensions/Updater]] | [[Projects/1_Presentation/Extension.Updater]] | Reference |
| [[Extensions/Cloud.GoogleDrive]] | [[Projects/1_Presentation/Extension.Cloud.GoogleDrive]] | Reference |

### Sample Links

| From | To | Type |
|---|---|---|
| [[Samples/Breakout]] | [[Projects/2_Application/Samples/Sample.Breakout]] | Reference |
| [[Samples/Pong]] | [[Projects/2_Application/Samples/Sample.Pong]] | Reference |
| [[Samples/Platformer]] | [[Projects/2_Application/Samples/Sample.King.Platform]] | Reference |
| [[Samples/Shooter]] | [[Projects/2_Application/Samples/Sample.Space.Simulator]] | Reference |
| [[Samples/RPG]] | [[Projects/2_Application/Samples/Sample.RuinsOfTartarus]] | Reference |
| [[Samples/Tetris]] | [[Projects/2_Application/Samples/Sample.Tetris]] | Reference |
| [[Samples/Snake]] | [[Projects/2_Application/Samples/Sample.Snake]] | Reference |
| [[Samples/Flappy Bird]] | [[Projects/2_Application/Samples/Sample.Flappy.Bird]] | Reference |
| [[Samples/Space Invaders]] | [[Projects/2_Application/Samples/Sample.Space.Invaders]] | Reference |
| [[Samples/Pac-Man]] | [[Projects/2_Application/Samples/Sample.Pac-Man]] | Reference |
| [[Samples/Asteroids]] | [[Projects/2_Application/Samples/Sample.Asteroid]] | Reference |

### System Links

| From | To | Type |
|---|---|---|
| [[System/State/Analysis-State]] | [[System/State/Project-State]] | Reference |
| [[System/State/Project-State]] | [[System/State/Execution-State]] | Reference |
| [[System/State/Execution-State]] | [[System/State/Pending-Work]] | Reference |
| [[System/Indexes/Projects-Index]] | [[System/Indexes/Layer-Index]] | Reference |
| [[System/Indexes/Projects-Index]] | [[System/Indexes/Dependency-Index]] | Reference |
| [[System/Indexes/Projects-Index]] | [[System/Indexes/Architecture-Index]] | Reference |
| [[System/Sessions/Current-Session]] | [[System/Sessions/Session-History]] | Reference |
| [[System/Logs/Execution-Log]] | [[System/State/Analysis-State]] | Reference |

### Decision Links

| From | To | Type |
|---|---|---|
| [[Decisions/adr-001-layered-architecture]] | [[Architecture/Repository-Overview]] | Reference |
| [[Decisions/adr-002-aggregator-pattern]] | [[Architecture/Repository-Overview]] | Reference |
| [[Architecture/Build-System]] | [[Decisions/adr-001-layered-architecture]] | Reference |
| [[Context/Architecture-Rules]] | [[Decisions/adr-001-layered-architecture]] | Reference |

### Glossary Links

| From | To | Type |
|---|---|---|
| [[Glossary/Component]] | [[Concepts/Entity Component System]] | Reference |
| [[Glossary/Entity Component System]] | [[Concepts/Entity Component System]] | Reference |
| [[Glossary/Query]] | [[Concepts/Query Based Architecture]] | Reference |
| [[Glossary/Archetype]] | [[Concepts/Entity Component System]] | Reference |
| [[Glossary/Chunk Tuple]] | [[Concepts/Entity Component System]] | Reference |
| [[Glossary/GameObject]] | [[Entities/GameObject]] | Reference |
| [[Glossary/Scene]] | [[Entities/Scene]] | Reference |
| [[Glossary/System]] | [[Concepts/Entity Component System]] | Reference |

## Auto-Generated Links

These links are automatically generated based on project structure:

### Layer Dependencies

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

### Generator References

- [[Generators/Alis.Core.Aspect.Data.Generator]] → [[Projects/6_Ideation/Alis.Core.Aspect.Data]]
- [[Generators/Alis.Core.Aspect.Fluent.Generator]] → [[Projects/6_Ideation/Alis.Core.Aspect.Fluent]]
- [[Generators/Alis.Core.Ecs.Generator]] → [[Projects/4_Operation/Ecs]]
- [[Generators/Alis.Core.Graphic.Generator]] → [[Projects/4_Operation/Graphic]]

### Test References

- [[Projects/1_Presentation/Extension.Graphic.Sfml.Test]] → [[Projects/1_Presentation/Extension.Graphic.Sfml]]
- [[Projects/1_Presentation/Extension.Language.Dialogue.Test]] → [[Projects/1_Presentation/Extension.Language.Dialogue]]
- [[Projects/1_Presentation/Extension.Network.Test]] → [[Projects/1_Presentation/Extension.Network]]

## Link Validation

All links validated on:
- File existence
- Cross-reference integrity
- Circular dependency detection
- Orphaned file detection

## Maintenance

Update this file when:
- Adding new documentation files
- Restructuring directories
- Creating new relationships
- Removing deprecated content

## Related

- [[Index]] — Main memory index
- [[Projects/Index]] — Project documentation
- [[Architecture/Dependency-Graph]] — Dependency diagrams
- [[Concepts/Index]] — Conceptual knowledge
- [[Glossary/Index]] — Terminology
