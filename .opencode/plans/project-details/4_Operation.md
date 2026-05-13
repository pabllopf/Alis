# Alis — Layer 4: Operation (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `4_Operation/`
- **Total .cs files**: ~995 (src: 453, test: 457, samples: ~85)
- **Total projects**: 14 (4 subsystems: ECS, Audio, Graphic, Physic; each with src, test, sample; ECS and Graphic also have generators)
- **Build target**: Multi-target via Config.props
- **Outputs**: Library (src), EXE (sample), Analyzer (generator)

## Subsystems (4)

### 1. ECS (Entity Component System)

| Project | Path | Type | Source Files | Key Types |
|---------|------|------|-------------|-----------|
| Alis.Core.Ecs | `Ecs/src/` | Library | ~155 | `GameObject`, `Scene`, `EntityData`, `EntityWorldInfoAccess`, `EntityUpdate`, `EntityHighLow`, `GameObjectRefTuple`, `GameObjectLocation`, `GameObjectFlags`, `GameObjectQueryEnumerator`, `GameObjectExtensions` |
| Alis.Core.Ecs.Generator | `Ecs/generator/` | Generator | ~6 | ECS code generators (namespace: `Alis.Core.Ecs.Generator.` + sub-ns: `Collections/`, `Models/`, `Structures/`) |
| Alis.Core.Ecs.Sample | `Ecs/sample/` | Executable | ~35+35 Samples | ECS usage samples |
| Alis.Core.Ecs.Test | `Ecs/test/` | Test | 87 | ECS unit tests |

**ECS Namespace Structure**:
```
Alis.Core.Ecs/
├── Collections/           — Entity collections
├── Components/
│   ├── Audio/, Body/, Collider/, Light/, Render/, Ui/ — ECS component definitions
├── Exceptions/            — ECS-specific exceptions
├── Generator/
│   ├── Collections/, Models/, Structures/ — generator internals
├── Kernel/
│   ├── Archetypes/        — Archetype system, WorldArchetypeTableItem, IArchetypeGraphEdge
│   └── Events/            — ECS event system
├── Marshalling/           — SceneMarshal, GameObjectMarshal (serialization)
├── Redifinition/          — (9 files) Redefinitions/overrides
├── Systems/
│   ├── Configuration/     — Audio, General, Graphic, Input, Network, Physic, Time settings
│   ├── Execution/         — IRuntime, InternalRuntime
│   ├── Manager/           — Scene, Graphic, Audio, Physic, Network, Time, Input managers
│   └── Scope/             — IContext, Context, IContextHandler, ContextHandler
└── Updating/
    └── Runners/           — Update runner implementations
```

**Key ECS Architecture Notes**:
- Archetype-based entity system (common in high-performance ECS)
- Separate `EntityData` from `GameObject` for data-oriented design
- High/low entity ID splitting for ID management
- Query enumerators (`GameObjectQueryEnumerator`)
- Marshalling for scene/entity serialization

### 2. Audio

| Project | Path | Type | Source Files |
|---------|------|------|-------------|
| Alis.Core.Audio | `Audio/src/` | Library | ~56 |
| Alis.Core.Audio.Sample | `Audio/sample/` | Executable | ~9 |
| Alis.Core.Audio.Test | `Audio/test/` | Test | 6 + nested (Players: 6, Interfaces: 1) |

**Namespace**: `Alis.Core.Audio.*`
- `Players/` — Audio playback, sample handling
- `Interfaces/` — Audio system interfaces

### 3. Graphic

| Project | Path | Type | Source Files |
|---------|------|------|-------------|
| Alis.Core.Graphic | `Graphic/src/` | Library | ~195 |
| Alis.Core.Graphic.Generator | `Graphic/generator/` | Generator | ~1 |
| Alis.Core.Graphic.Sample | `Graphic/sample/` | Executable | ~9 |
| Alis.Core.Graphic.Test | `Graphic/test/` | Test | 11 + nested |

**Namespace**: `Alis.Core.Graphic.*`
- `OpenGL/` — OpenGL bindings
  - `Delegates/` (60 files) — P/Invoke delegates
  - `Enums/` (26 files) — OpenGL enums
  - `Constructs/` (4 files) — Struct/union definitions
- `Platforms/` — Platform-specific implementations
  - `Win/Native/` (16 files) — Windows native bindings
  - `Linux/Native/` (9 files) — Linux native bindings
  - `Osx/Native/` (7 files) — macOS native bindings
  - `Web/` (11 files) — WebAssembly bindings
  - `Android/` (1 file) — Android bindings
- `Ui/` (2 files) — UI primitives
- Test: `Enums/`, `Attributes/`, `Constructs/`, `Platforms/Web/`, `Platforms/Osx/`, `Delegates/`, `Ui/`

**Key Graphic Architecture Notes**:
- OpenGL-based rendering core
- Heavy P/Invoke (60 delegates) for native OpenGL/GLFW/GLSL interop
- Platform-specific native bindings for Win/Linux/macOS/Web/Android
- Source generator for graphic code generation

### 4. Physic

| Project | Path | Type | Source Files |
|---------|------|------|-------------|
| Alis.Core.Physic | `Physic/src/` | Library | ~239 |
| Alis.Core.Physic.Sample | `Physic/sample/` | Executable | ~11 |
| Alis.Core.Physic.Test | `Physic/test/` | Test | ~104 |

**Namespace**: `Alis.Core.Physic.*`
- `Collisions/` — Collision detection
  - `Shapes/` (7 files) — Circle, Box, Polygon shapes
- `Common/` — Shared utilities
  - `ConvexHull/` (4 files) — Convex hull computation
  - `Decomposition/` — Polygon decomposition
    - `CDT/` (7+7+3+4+1+1) — Constrained Delaunay triangulation (full implementation: sweep, polygon, sets, utility)
    - `Seidel/` (11+11) — Seidel decomposition algorithm
  - `Logic/` (10+10) — Physics logic
  - `PolygonManipulation/` (6+6) — Polygon operations
  - `TextureTools/` (4) — Texture utilities
- `Controllers/` (5+5) — Physics controllers
- `Dynamics/` (37+37) — Dynamics simulation
  - `Contacts/` (7+7) — Contact management
  - `Joints/` (17+17) — Joint system (17 files each in src/test)

**Key Physic Architecture Notes**:
- 2D physics engine (shapes: Circle, Box, Polygon)
- Constrained Delaunay Triangulation for polygon decomposition
- Seidel algorithm for polygon decomposition
- Convex hull computation
- Full rigid body dynamics with contacts and joints
- Test-heavy: 104 test files for 239 source files (~30% test coverage by file count)

## Size Rankings (by src/ .cs count)

| Rank | Subsystem | Files |
|------|-----------|-------|
| 1 | Graphic | ~195 |
| 2 | Physic | ~239 |
| 3 | ECS | ~155 |
| 4 | Audio | ~56 |

## Dependencies

### Internal Dependencies
| Subsystem | Depends On |
|-----------|-----------|
| ECS | 3_Structuration/Core, 5_Declaration/Aspect, 6_Ideation/* |
| Audio | 3_Structuration/Core, 4_Operation/Ecs |
| Graphic | 3_Structuration/Core, 4_Operation/Ecs |
| Physic | 3_Structuration/Core, 4_Operation/Ecs |

### Generator Dependencies (ECS + Graphic)
| Generator | Host Project | Packages |
|-----------|-------------|----------|
| Alis.Core.Ecs.Generator | Alis.Core.Ecs | Microsoft.CodeAnalysis.CSharp 4.3.0, Microsoft.CodeAnalysis.Analyzers 3.3.4 |
| Alis.Core.Graphic.Generator | Alis.Core.Graphic | Microsoft.CodeAnalysis.CSharp 4.3.0, Microsoft.CodeAnalysis.Analyzers 3.3.4 |

Generators target: `netstandard2.0;net8.0;net10.0`

## Test Project Details

| Subsystem | Test Files | Test Framework | External Deps in Tests |
|-----------|-----------|----------------|----------------------|
| ECS | 87 | xunit 2.6.6 | Moq 4.20.70, xunit.runner.visualstudio 2.4.3, coverlet 6.0.4, Stripe.net 47.1.0, Google.Ads 9.5.3, Google drive 1.68, Dropbox 7.0 |
| Audio | ~7 | xunit 2.6.6 | Same shared deps |
| Graphic | ~15 | xunit 2.6.6 | Same shared deps |
| Physic | ~104 | xunit 2.6.6 | Same shared deps |

**Note**: Test projects include conditional project references to ALL presentation layer packages — this is a shared template pattern, not actual dependencies.

## Build Notes

- All subsystems import Config.props for multi-targeting
- Samples target `net10.0`
- Tests target `net8.0`
- Generators are build separately with `netstandard2.0` first
- ECS is the largest subsystem and depends on the most internal packages
