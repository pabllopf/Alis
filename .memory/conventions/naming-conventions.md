---
title: Naming Conventions — ALIS
tags:
  - convention
  - standard
  - naming

status: draft
---


## Project Naming
- **Pattern**: `Alis.{LayerContext}.{Module}.{SubModule}`
- **Examples**:
  - `Alis.Core.Ecs` — ECS engine subsystem
  - `Alis.Extension.Security` — Security extension
  - `Alis.Sample.Flappy.Bird` — Flappy Bird game sample
  - `Alis.Core.Aspect.Memory` — Memory aspect

## Namespace Naming
- **Pattern**: `Alis.{LayerContext}.{Module}.{SubModule}`
- **Examples**:
  - `Alis.Core.Ecs` — ECS namespace
  - `Alis.Extension.Security` — Security extension namespace
  - `Alis.Sample.Flappy.Bird` — Flappy Bird game namespace

## File Naming
- **C# Files**: PascalCase (e.g., `GameLoop.cs`, `EcsSystem.cs`)
- **Interfaces**: I-prefix (e.g., `IEcsSystem.cs`) — though C# 10+ convention often omits I
- **Generators**: *Generator.cs suffix (e.g., `EcsGenerator.cs`)
- **Test Files**: {Subject}Test.cs pattern (e.g., `EcsSystemTest.cs`)

## Folder Naming
- **Layers**: Numbered with underscore (1_Presentation, 2_Application, etc.)
- **Sub-projects**: src/, test/, sample/, Generator/
- **Extensions**: Extension.{Category}.{Name} (e.g., Extension.Graphic.Sfml)
- **Samples**: Sample.{GameName} (e.g., Sample.Flappy.Bird)

## Solution Naming
- **Primary**: alis.slnx (structured solution)
- **Design**: alis_design.sln (full design solution)

## Variable Naming
- **Local variables**: camelCase (e.g., `gameLoop`)
- **Parameters**: camelCase with underscore prefix if needed (e.g., `_gameLoop`)
- **Private fields**: _camelCase (e.g., `_engine`)
- **Constants**: PascalCase or UPPER_SNAKE_CASE (context-dependent)
- **Async methods**: *Async suffix (e.g., `LoadAsync`)

## Event Naming
- **Events**: PascalCase (e.g., `GameStarted`)
- **Delegates**: Action/Func or PascalCase with EventHandler suffix

## Enum Naming
- **Enums**: PascalCase (e.g., `GameState`, `ExtensionType`)
- **Enum values**: PascalCase (e.g., `Running`, `Paused`, `Stopped`)

## Related

- [[ai-context]] — AI agent naming reference
- [[code-review-checklist]] — Naming review items
- [[projects/Index]] — Project naming examples
- [[adr-001-layered-architecture]] — Layer naming convention
- [[layer-index]] — Layer naming
- [[project-index]] — All project names
- [[Alis Architecture Overview]] — Naming context
