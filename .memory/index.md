# ALIS Memory Index

> **Version**: 1.0.6 | **Author**: Pablo Perdomo Falcón | **License**: GPLv3
> **Repository**: https://github.com/pabllopf/Alis | **Website**: www.alisengine.com

## Welcome

This directory contains the complete Obsidian-compatible memory system for the **ALIS Game Engine Framework** — a cross-platform C# game engine with 140+ projects organized across 6 architectural layers.

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
- [[applications/installer|Installer]] — Installation wizard
- [[applications/benchmark|Benchmark]] — ECS performance comparisons

### For Game Samples
- [[samples/index]] — All 13 samples indexed
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
- [[system/indexes/projects-index]] — All projects indexed
- [[system/indexes/layer-index]] — Layer breakdown
- [[system/indexes/dependency-index]] — Dependency relationships
- [[system/indexes/architecture-index]] — Architectural patterns

## Repository At a Glance

| Metric | Value |
|--------|-------|
| Total Projects | ~140 (335 in slnx) |
| Architectural Layers | 6 |
| Extensions | 11 |
| Game Samples | 13 |
| Applications | 4 |
| Test Projects | ~35 |
| Source Generators | 8 |
| CI/CD Workflows | 41 |
| Target Frameworks | 15+ (Debug) / 21 (Release) |
| Runtime Identifiers | 13 |
| C# Version | 13 |
| .NET SDK | 10.0+ |

## Directory Structure

```
.memory/
├── index.md                          ← You are here
├── schema.md                         ← Memory system schema
├── log.md                            ← Session log
│
├── architecture/                     ← Architecture documentation
│   ├── repository-overview.md        ← Full architecture overview
│   ├── dependency-graph.md           ← Dependency graph + Mermaid diagrams
│   └── build-system.md               ← Build configuration and commands
│
├── projects/                         ← Per-project documentation
│   ├── 1_Presentation/               ← Extensions, Apps, Benchmark
│   ├── 2_Application/                ← Core app + game samples
│   ├── 3_Structuration/              ← Core engine aggregator
│   ├── 4_Operation/                  ← ECS, Graphic, Audio, Physic
│   ├── 5_Declaration/                ← Aspect system aggregator
│   └── 6_Ideation/                   ← Aspect definitions + generators
│
├── extensions/                       ← Extension documentation
│   ├── index.md                      ← Extensions overview
│   ├── updater.md                    ← Auto-update system
│   ├── translator.md                 ← Internationalization
│   ├── dialogue.md                   ← Dialogue system
│   ├── graphic-sfml.md               ← SFML backend
│   ├── graphic-glfw.md               ← GLFW/OpenGL backend
│   ├── graphic-sdl2.md               ← SDL2 backend
│   ├── graphic-ui.md                 ← UI framework
│   ├── thread.md                     ← Threading utilities
│   ├── ffmpeg.md                     ← Media processing
│   ├── profile.md                    ← Performance profiling
│   └── cloud-googledrive.md          ← Cloud storage
│
├── applications/                     ← Application documentation
│   ├── index.md                      ← Applications overview
│   ├── engine-editor.md              ← Game editor (ImGui)
│   ├── hub.md                        ← Project launcher
│   ├── installer.md                  ← Installation wizard
│   └── benchmark.md                  ← ECS comparisons
│
├── samples/                          ← Game sample documentation
│   ├── index.md                      ← Samples overview
│   ├── breakout.md                   ← Classic breakout
│   ├── pong.md                       ← 2-player pong
│   ├── platformer.md                 ← 2D platformer
│   ├── shooter.md                    ← Top-down shooter
│   ├── rpg.md                        ← Turn-based RPG
│   ├── tetris.md                     ← Puzzle game
│   ├── snake.md                      ← Classic snake
│   ├── flappy-bird.md                ← Tap-to-fly
│   ├── space-invaders.md             ← Alien shooter
│   ├── pac-man.md                    ← Maze game
│   ├── asteroids.md                  ← Space shooter
│   ├── breakout-3d.md                ← 3D breakout
│   └── demo.md                       ← Engine features showcase
│
├── system/                           ← System state and indexes
│   ├── state/                        ← Execution state (markdown)
│   ├── indexes/                      ← Navigation indexes
│   ├── logs/                         ← Execution logs
│   ├── tracking/                     ← Documentation tracking
│   ├── sessions/                     ← Session management
│   ├── queues/                       ← Work queues
│   ├── checkpoints/                  ← Execution checkpoints
│   └── metadata/                     ← System metadata
│
├── prompts/                          ← AI context files
│   ├── ai-context.md                 ← Quick reference for AI agents
│   ├── conversation-starters.md      ← Context questions
│   └── code-review-checklist.md      ← Review guidelines
│
├── diagrams/                         ← Architecture diagrams (Mermaid)
│   ├── README.md                     ← Diagram index
│   ├── architecture-overview.md      ← 6-layer architecture with generator cascade
│   ├── dependency-graph.md           ← Module dependency relationships
│   ├── game-pipeline.md             ← VideoGame bootstrap flow, script lifecycle
│   ├── ecs-architecture.md          ← ECS data flow, chunk storage, query strategies
│   └── benchmark-comparison.md      ← ECS framework comparison, benchmark map
│
├── context/                          ← AI context files
│   ├── architecture-rules.md         ← Layer dependency rules
│   ├── coding-conventions.md         ← Coding standards
│   ├── dependency-constraints.md     ← Module dependency rules
│   ├── project-map.md               ← Project quick reference
│   └── onboarding.md                ← Quick start guide
│
├── testing/                          ← Testing analysis
│   └── analysis.md                   ← Testing framework and strategy
│
├── security/                         ← Security analysis
│   └── analysis.md                   ← Security extensions and best practices
│
├── glossary/                         ← Terminology
│   └── index.md                      ← ALIS-specific terms
│
├── conventions/                      ← Coding conventions
│   └── naming-conventions.md         ← Naming rules
│
├── decisions/                        ← Architecture decision records
│   ├── adr-001-layered-architecture.md
│   └── adr-002-aggregator-pattern.md
│
├── onboarding/                       ← Onboarding materials
│   └── getting-started.md            ← Quick start guide
│
├── summaries/                        ← Summaries
│   ├── build-summary.md              ← Build system summary
│   └── session-summary.md            ← Session summaries
│
├── concepts/                         ← (Pre-existing)
├── entities/                         ← (Pre-existing)
├── raw/                              ← (Pre-existing)
└── sources/                          ← (Pre-existing)
```

## Related Documentation

- [[readme]] — Project README
- [[contributing]] — Contribution guidelines
- [[security]] — Security policy
- [[changelog]] — Version history

## Memory System Schema

See [[schema]] for the memory system schema and conventions.

## Session Log

See [[log]] for the session execution log.
