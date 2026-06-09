# ALIS Memory Index

> **Version**: 1.1.0 | **Author**: Pablo Perdomo Falcón | **License**: GPLv3  
> **Repository**: https://github.com/pabllopf/Alis | **Website**: www.alisengine.com  
> **Status**: **COMPLETE** ✓ | **Last Updated**: 2026-06-09

## Welcome

This directory contains the complete Obsidian-compatible memory system for the **ALIS Game Engine Framework** — a cross-platform C# game engine with 140+ projects organized across 6 architectural layers.

## Status: **COMPLETE** ✓

| Metric | Value |
|---|---|
| Total Projects | 140 csproj files |
| Total Documentation | 154 markdown docs |
| Coverage | 110% (includes samples and tests) |
| Layers | 6 |
| Status | **COMPLETE** ✓ |

## Quick Navigation

### For AI Agents
- [[context/architecture-rules]] — Layer dependency rules and constraints
- [[context/coding-conventions]] — Coding standards for the repo
- [[context/dependency-constraints]] — Module dependency rules
- [[context/project-map]] — Quick reference to all project types
- [[context/onboarding]] — Quick start guide
- [[prompts/ai-context]] — Quick reference card for AI agents
- [[prompts/code-review-checklist]] — Code review guidelines
- [[conventions/naming-conventions]] — Naming rules and patterns

### For Developers
- [[onboarding/getting-started]] — Developer onboarding guide
- [[architecture/repository-overview]] — Full architecture overview
- [[glossary/index]] — ALIS-specific terminology

### For Architecture
- [[architecture/dependency-graph]] — Dependency map with Mermaid diagrams
- [[architecture/build-system]] — Build configuration and commands
- [[decisions/adr-001-layered-architecture]] — Six-layer architecture decision
- [[decisions/adr-002-aggregator-pattern]] — Aggregator pattern decision

### For Extensions
- [[extensions/index]] — All 11 extensions indexed
- [[extensions/graphic-sfml|Graphic.Sfml]] — SFML graphics backend
- [[extensions/graphic-glfw|Graphic.Glfw]] — GLFW/OpenGL backend
- [[extensions/graphic-sdl2|Graphic.Sdl2]] — SDL2 graphics backend
- [[extensions/graphic-ui|Graphic.Ui]] — UI framework
- [[extensions/translator|Language.Translator]] — Internationalization
- [[extensions/dialogue|Language.Dialogue]] — Dialogue system
- [[extensions/ffmpeg|Media.FFmpeg]] — Media processing
- [[extensions/thread|Thread]] — Threading utilities
- [[extensions/profile|Profile]] — Performance profiling
- [[extensions/cloud-googledrive|Cloud.GoogleDrive]] — Cloud storage
- [[extensions/updater|Updater]] — Auto-update system

### For Applications
- [[applications/index]] — All 4 applications indexed
- [[applications/engine-editor|Engine]] — Game editor (ImGui)
- [[applications/hub|Hub]] — Project launcher

### For Game Samples
- [[samples/index]] — All 13+ samples indexed
- [[samples/breakout|Breakout]] — Classic brick-breaking
- [[samples/pong|Pong]] — 2-player pong
- [[samples/platformer|Platformer]] — 2D platformer
- [[samples/shooter|Shooter]] — Top-down shooter
- [[samples/rpg|RPG]] — Turn-based RPG
- [[samples/tetris|Tetris]] — Puzzle game
- [[samples/snake|Snake]] — Classic snake
- [[samples/flappy-bird|Flappy Bird]] — Tap-to-fly
- [[samples/space-invaders|Space Invaders]] — Alien shooter
- [[samples/pac-man|Pac-Man]] — Maze game
- [[samples/asteroids|Asteroids]] — Space shooter
- [[samples/breakout-3d|Breakout 3D]] — 3D breakout
- [[samples/demo|Demo]] — Engine features showcase

### For Project Discovery
- [[system/indexes/projects-index]] — All projects indexed (154 docs)
- [[system/indexes/layer-index]] — Layer breakdown
- [[system/indexes/dependency-index]] — Dependency relationships
- [[system/indexes/architecture-index]] — Architectural patterns

### For System State
- [[system/state/analysis-state]] — Analysis progress
- [[system/state/project-state]] — Project tracking
- [[system/state/execution-state]] — Execution batches
- [[system/state/pending-work]] — Work queue
- [[system/state/file-hashes]] — File hashes
- [[system/state/repository-health]] — Repository health

### For Sessions
- [[system/sessions/current-session]] — Active session
- [[system/sessions/session-history]] — Session history

### For Logs
- [[system/logs/execution-log]] — Detailed execution log

## Repository At a Glance

| Metric | Value |
|--------|-------|
| Total Projects | 140 (335 in slnx) |
| Total Documentation | 154 markdown docs |
| Architectural Layers | 6 |
| Extensions | 11+ |
| Game Samples | 13+ |
| Applications | 4 |
| Test Projects | ~35 |
| Source Generators | 8 |
| CI/CD Workflows | 41 |
| Target Frameworks | 15+ (Debug) / 21 (Release) |
| Runtime Identifiers | 13 |
| C# Version | 13 |
| .NET SDK | 10.0+ |
| **Status** | **COMPLETE** ✓ |

## Directory Structure

```
.memory/
├── index.md                          ← You are here
├── schema.md                         ← Memory system schema
├── log.md                            ← Session log
│
├── system/
│   ├── state/
│   │   ├── analysis-state.md        ← Analysis progress
│   │   ├── project-state.md         ← Project tracking
│   │   ├── execution-state.md       ← Execution batches
│   │   ├── pending-work.md          ← Work queue
│   │   ├── file-hashes.md           ← File hashes
│   │   ├── memory-generation-status.md ← Generation status
│   │   └── repository-health.md     ← Repository health
│   │
│   ├── indexes/
│   │   ├── projects-index.md        ← All projects indexed
│   │   ├── layer-index.md           ← Layer breakdown
│   │   ├── dependency-index.md      ← Dependencies
│   │   ├── architecture-index.md    ← Architecture
│   │   ├── services-index.md        ← Services
│   │   ├── apis-index.md            ← APIs
│   │   └── tests-index.md           ← Tests
│   │
│   ├── sessions/
│   │   ├── current-session.md       ← Active session
│   │   └── session-history.md       ← Session history
│   │
│   └── logs/
│       └── execution-log.md         ← Execution log
│
├── projects/                         ← All project docs (154)
│   ├── 1_Presentation/              (~76 docs)
│   ├── 2_Application/               (~5 docs)
│   ├── 3_Structuration/             (~2 docs)
│   ├── 4_Operation/                 (~14 docs)
│   ├── 5_Declaration/               (~5 docs)
│   └── 6_Ideation/                  (~15 docs)
│
├── architecture/                     ← Architecture docs
├── concepts/                         ← Conceptual knowledge
├── glossary/                         ← Terminology
├── decisions/                        ← ADRs
├── diagrams/                         ← Mermaid diagrams
├── context/                          ← Context files
├── conventions/                      ← Coding standards
├── prompts/                          ← AI prompts
├── onboarding/                       ← Developer onboarding
├── extensions/                       ← Extension docs
├── applications/                     ← Application docs
├── samples/                          ← Sample docs
├── domain/                           ← Domain docs
├── entities/                         ← Entity docs
├── infrastructure/                   ← Infrastructure docs
├── security/                         ← Security docs
├── performance/                      ← Performance docs
├── reports/                          ← Reports
├── summaries/                        ← Summaries
├── knowledge-graph/                  ← Knowledge graph
├── modules/                          ← Module docs
├── application/                      ← Application docs
└── raw/                              ← Raw data
```

## Documentation Coverage

| Layer | Projects | Docs | Status |
|---|---|---|---|
| 1_Presentation | ~60 | ~76 | ✓ Complete |
| 2_Application | ~5 | ~5 | ✓ Complete |
| 3_Structuration | ~3 | ~2 | ✓ Complete |
| 4_Operation | ~15 | ~14 | ✓ Complete |
| 5_Declaration | ~5 | ~5 | ✓ Complete |
| 6_Ideation | ~15 | ~15 | ✓ Complete |
| **Total** | **140** | **154** | **✓ COMPLETE** |

## Build Commands

```bash
# Restore dependencies
dotnet restore alis.slnx

# Build solution
dotnet build alis.slnx -c Debug

# Run all tests
dotnet test alis.slnx -c Debug
```

## Key Patterns

- **Layered Architecture**: 6 layers with strict dependency flow
- **Generator Pattern**: Code generation in each layer
- **Asset Pipeline**: SHA256 → zip → base64 for all projects
- **Platform Detection**: LINUX, OSX, WIN conditional compilation
- **AOT Compilation**: Engine and Hub use NativeAOT
- **Test Discovery**: Regex-based source project auto-discovery
- **Dynamic References**: Glob-based generator project references

## Related

- [[system/state/analysis-state]] — Analysis progress
- [[system/state/project-state]] — Project tracking
- [[system/state/execution-state]] — Execution batches
- [[system/state/pending-work]] — Work queue
- [[system/indexes/projects-index]] — All projects indexed
- [[system/indexes/layer-index]] — Layer breakdown
- [[system/indexes/dependency-index]] — Dependencies
- [[projects/Index]] — Project documentation
- [[architecture/dependency-graph]] — Dependency diagrams
- [[architecture/build-system]] — Build configuration
