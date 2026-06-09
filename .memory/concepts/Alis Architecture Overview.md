# Alis Architecture Overview

Alis is a C# game engine/framework with a modular 6-layer architecture and aspect-oriented design.

## Architecture

```
1_Presentation/          ← User-facing apps + extensions
├── Installer/           ← Installation app
├── Engine/              ← Runtime engine
├── Hub/                 ← Hub application
└── Extension/           ← 18+ modular extensions
    ├── Ads/GoogleAds
    ├── Security
    ├── Payment/Stripe
    ├── Network
    ├── Io/FileDialog
    ├── Updater
    ├── Language/Translator, Dialogue
    ├── Math/ProceduralDungeon, HighSpeedPriorityQueue
    ├── Graphic/Ui, Sfml, Glfw, Sdl2
    ├── Profile
    ├── Cloud/DropBox, GoogleDrive
    ├── Thread
    └── Media/FFmpeg

2_Application/           ← Main app + sample games
├── Alis/src             ← Main application
└── samples/             ← 12 sample games (Web + Desktop each)

3_Structuration/         ← Core foundations
└── Core/

4_Operation/             ← Operational systems
├── Ecs/                 ← Entity Component System (+ generator)
├── Graphic/             ← Graphics (+ generator)
├── Audio/
└── Physic/

5_Declaration/           ← Declarative foundation
└── Aspect/              ← Core.Aspect

6_Ideation/              ← Experimental aspects
├── Memory/              (+ generator)
├── Fluent/              (+ generator)
├── Math/
├── Time/
├── Data/                (+ generator)
└── Logging/
```

## Solution Organization

8 `.slnx` files enable focused builds:
- **alis.slnx** — Full solution
- **alis.core.slnx** — Core libraries
- **alis.apps.slnx** — Applications
- **alis.extensions.slnx** — Extensions
- **alis.test.slnx** — Tests
- **alis.samples.slnx** — Samples
- **alis.core.aspect.slnx** — Aspects only
- **alis.benchmark.slnx** — Benchmarks

## Key Design Principles

1. **Layered by abstraction**: Presentation (concrete) → Ideation (abstract)
2. **Aspect-oriented**: Core.Aspect as foundation, experimental aspects on top
3. **Modular solutions**: Different .slnx for different build targets
4. **Source generators**: ECS, Graphic, Memory, Data, Fluent use code generation
5. **Multi-platform**: Samples target Web, Desktop, iOS, Android

## See Also
- [[Layered Architecture]]
- [[Aspect-Oriented Design]]
- [[Solution Composition]]
- [[Generator Pattern]]
- [[Multi-Platform Samples]]
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]
- [[Platform-Specific Build Constants]]

## Related Architecture

- [[repository-overview]] — Full architecture overview
- [[architecture/dependency-graph]] — Dependency rules and flow
- [[build-system]] — Build configuration details
- [[adr-001-layered-architecture]] — Six-layer ADR
- [[adr-002-aggregator-pattern]] — Aggregator ADR

## Related Projects

- [[projects/Index]] — Project documentation index
- [[projects/Architecture]] — Detailed layer documentation

## Related Analysis

- [[testing-overview]] — Testing strategy
- [[security-overview]] — Security risks
- [[onboarding/getting-started]] — Developer onboarding
- [[ai-context]] — AI agent reference
