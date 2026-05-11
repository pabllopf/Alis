---
name: Alis architecture
description: Complete architecture of the Alis game engine solution - 6 modules, 142 projects, ECS framework
type: project
---

## Solution Overview
- **Size**: 142 csproj, 6,253 .cs files, ~15GB
- **Solution files**: alis.sln (main), Alis.slnx, alis_benchmarks.sln, alis_design.sln
- **Target frameworks**: .NET 4.7.1 through .NET 9.0

## 6-Module Structure
```
1_Presentation/   (71 csproj, 3,330 cs) - Apps + 25+ Extensions
2_Application/    (30 csproj, 485 cs)   - Main app + 13 sample games
3_Structuration/  (3 csproj, 264 cs)    - Core ECS abstractions
4_Operation/      (14 csproj, 1,264 cs) - Engine systems (ECS, Audio, Graphic, Physic)
5_Declaration/    (3 csproj, 59 cs)     - Aspect-oriented programming
6_Ideation/       (21 csproj, 851 cs)   - Utility aspects (Data, Fluent, Logging, Math, Memory, Time)
```

## Architectural Layers
- **Layer 1 (Presentation)**: User-facing apps (Engine, Hub, Agent, Installer, Benchmark) + extension plugins
- **Layer 2 (Application)**: Business logic with Builder pattern, Manager pattern, 13 sample games
- **Layer 3 (Structuration)**: Core ECS foundation, multi-target
- **Layer 4 (Operation)**: Concrete engine systems - custom ECS, Audio, OpenGL Graphic, Physics
- **Layer 5 (Declaration)**: Meta-programming aspects
- **Layer 6 (Ideation)**: Math primitives, JSON, fluent APIs, logging, memory, time

## Key Patterns
- Builder pattern (GameObject, Scene, Component builders)
- Manager pattern (Scene, Graphic, Audio, Physic, Network, Time managers)
- Context/Scope pattern (IContext, ContextHandler)
- Runtime pattern (IRuntime, InternalRuntime)
- Source generators (Ecs.Generator, Graphic.Generator, Memory.Generator, etc.)
- Aspect-oriented programming (Data, Fluent aspects)
- Client/Server (Network extension)

## ECS Ecosystem
Benchmarks compare 10+ ECS implementations: Alis.Core.Ecs, Arch, DefaultEcs, Flecs.NET, Friflo.Engine.ECS, HypEcs, Morpeh, Svelto.ECS, myECS, fennecs, MonoGame.Extended.Entities, Leopotam.Ecs

## Dependency Flow
6_Ideation → 5_Declaration → 3_Structuration → 4_Operation → 2_Application → 1_Presentation

## Key Files
- `Directory.Build.props` - AssemblyVersion 1.0.6, EmitCompilerGeneratedFiles=true
- `2_Application/Alis/src/Core/Ecs/Systems/VideoGame.cs` - Main game runtime
- `4_Operation/Ecs/src/GameObject.cs` - Core entity type
- `1_Presentation/Extension/Network/src/` - Largest extension (303 files)

## Documentation Location
All docs in `.info/`: architecture.md, projects.md, symbols.md, dependencies.md, namespaces.md, index.md, plan.md
