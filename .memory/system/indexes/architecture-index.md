---
title: Architecture Index
tags:
  - index
  - architecture
  - navigation
status: Draft
license: GPLv3
---

# Architecture Index

## Core Architecture Documents

| Document | Description |
|---|---|
| [[architecture-overview]] | 6-layer architecture, dependency flow, build pipeline |
| [[layer-architecture]] | Per-layer details and responsibilities |
| [[module-structure]] | Standard module template and structure |
| [[multi-targeting-strategy]] | Framework targeting and platform support |
| [[build-pipeline]] | Build configuration and output structure |

## Dependency Documents

| Document | Description |
|---|---|
| [[dependency-graph]] | Full dependency graph with Mermaid diagram |
| [[layer-violations]] | Architecture violation analysis |

## Key Architectural Decisions

1. **6-layer strict dependency** enforced by MSBuild
2. **Source generators as analyzers** — consumed as `OutputItemType="Analyzer"` targeting `netstandard2.0`
3. **Conditional compilation** via RuntimeIdentifier-based DefineConstants
4. **Multi-targeting** — Debug (5 TFMs), Release (19+ TFMs), Platform-specific (6 configs)
5. **Release mode** — uses `Compile` includes to inline lower-layer source files into the Application project
6. **Test convention** — `InternalsVisibleTo` for each assembly's test project
7. **No external NuGet dependencies** in core (except SourceLink)
8. **All projects packable** — NuGet packaging with analyzer and runtime asset inclusion

## Architectural Patterns

| Pattern | Usage Location |
|---|---|
| CQRS | Application layer (via MediatR) |
| Entity Component System | Operation/Ecs |
| Source Generators | All layers (IDE-0078 Roslyn) |
| Builder Pattern | Application/Alis builder infrastructure |
| Fluent API | Ideation/Fluent interface chain |
| Strategy | Logging outputs and formatters |
| Adapter | Platform-specific implementations (Audio, Graphic) |
| Facade | Declaration/Aspect re-exports |

## Related Documents

- [[repository-overview]]
- [[projects-index]]
- [[conventions-overview]]
