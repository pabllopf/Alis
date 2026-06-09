# ALIS Memory Index

## Welcome
This directory contains the complete memory system for the ALIS game engine framework.

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
│   ├── state/                        ← State files
│   │   ├── analysis-state.json       ← Analysis progress
│   │   ├── file-hashes.json          ← File integrity hashes
│   │   └── project-state.json        ← Project analysis state
│   ├── indexes/                      ← Various indexes
│   │   ├── project-index.md          ← All 140 projects indexed
│   │   ├── dependency-index.md       ← Dependency map
│   │   └── layer-index.md            ← Layer breakdown
│   └── logs/                         ← Execution logs
│       └── execution-log.md          ← Session execution log
│
├── prompts/                          ← AI context files
│   ├── ai-context.md                 ← Quick reference for AI agents
│   ├── conversation-starters.md      ← Context questions
│   └── code-review-checklist.md      ← Review guidelines
│
├── diagrams/                         ← Architecture diagrams
│   └── architecture-overview.md      ← Mermaid diagrams
│
├── testing/                          ← Testing analysis
│   └── analysis.md                   ← Testing framework and strategy
│
├── security/                         ← Security analysis
│   └── analysis.md                   ← Security extensions and best practices
│
├── glossary/                         ← Terminology
│   └── terms.md                      ← ALIS-specific terms
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
│   └── session-summary.md            ← This session's summary
│
├── concepts/                         ← (Pre-existing)
├── entities/                         ← (Pre-existing)
├── raw/                              ← (Pre-existing)
└── sources/                          ← (Pre-existing)
```

## Quick Links

### For AI Agents
- [[ai-context]] — Quick reference card
- [[code-review-checklist]] — Review guidelines

### For Developers
- [[getting-started]] — Onboarding guide
- [[repository-overview]] — Architecture overview
- [[terms]] — Glossary

### For Architecture
- [[dependency-graph]] — Dependency map
- [[build-system]] — Build configuration
- [[adr-001-layered-architecture]] — Architecture decision

### For Projects
- [[project-index]] — All 140 projects indexed
- [[layer-index]] — Layer breakdown
- [[dependency-index]] — Dependency map

## Memory System Schema
See [[schema]] for the memory system schema and conventions.

## Session Log
See [[log]] for the session execution log.

## Related Topics

### Architecture & Design
- [[Layered Architecture]] — Layer structure and dependency rules
- [[Aspect-Oriented Design]] — AOP foundation and aspects
- [[Generator Pattern]] — Source generator architecture
- [[Multi-Targeting Strategy]] — 15+ framework targets
- [[Platform-Specific Build Constants]] — Build-time platform detection

### Decisions
- [[adr-001-layered-architecture]] — Six-layer architecture decision
- [[adr-002-aggregator-pattern]] — Aggregator pattern decision

### Onboarding & Context
- [[ai-context]] — AI agent quick reference
- [[code-review-checklist]] — Review guidelines
- [[conversation-starters]] — Context questions
- [[naming-conventions]] — Project and code naming rules
- [[getting-started]] — Onboarding guide

### Diagrams & Visualizations
- [[architecture-overview]] — Layer architecture Mermaid diagrams
- [[dependency-graph]] — Dependency visualization
- [[build-system]] — Build configuration and commands

### Analysis
- [[testing-overview]] — Test coverage status
- [[testing/analysis]] — Testing framework and patterns
- [[security-overview]] — Security risks and recommendations
- [[security/analysis]] — Security extensions and best practices
- [[analysis-state]] — Current analysis progress

### Summaries
- [[repository-overview]] — Full architecture overview
- [[build-summary]] — Build system summary
- [[session-summary]] — Memory generation session summary
- [[indexes-summary]] — All indexes overview
