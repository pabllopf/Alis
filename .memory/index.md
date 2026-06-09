# ALIS Memory Index

> **Version**: 1.0.6 | **Author**: Pablo Perdomo Falcón | **License**: GPLv3
> **Repository**: https://github.com/pabllopf/Alis | **Website**: www.alisengine.com

## Welcome

This directory contains the complete Obsidian-compatible memory system for the **ALIS Game Engine Framework** — a cross-platform C# game engine with 140+ projects organized across 6 architectural layers.

## Quick Navigation

### For AI Agents
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
| Extensions | 19 |
| Game Samples | 13 |
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
│   └── architecture-overview.md      ← Layer + generator diagrams
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
