# Documentation Map

## Memory System Structure

```
.memory/
├── index.md                              ← Master index
├── schema.md                             ← Schema definition
├── log.md                                ← Session log
│
├── architecture/                         ← Architecture docs
│   ├── repository-overview.md            ← Full architecture overview
│   ├── dependency-graph.md              ← Dependency graph + Mermaid
│   └── build-system.md                  ← Build configuration
│
├── projects/                             ← Per-project docs
│   ├── Index.md                         ← Projects index (legacy)
│   ├── 1_Presentation/                  ← Extension + App docs
│   ├── 2_Application/                   ← Sample docs
│   ├── 4_Operation/                     ← Core engine docs
│   └── 5_Declaration/                   ← Aspect docs
│
├── system/                               ← System state
│   ├── state/                           ← Execution state
│   ├── indexes/                         ← Navigation indexes
│   ├── tracking/                        ← Documentation tracking
│   ├── logs/                            ← Execution logs
│   ├── sessions/                        ← Session management
│   ├── queues/                          ← Work queues
│   ├── checkpoints/                     ← Execution checkpoints
│   └── metadata/                        ← System metadata
│
├── prompts/                              ← AI context files
│   ├── ai-context.md                    ← Quick reference
│   ├── conversation-starters.md         ← Context questions
│   └── code-review-checklist.md         ← Review guidelines
│
├── diagrams/                             ← Architecture diagrams
│   └── architecture-overview.md         ← Mermaid diagrams
│
├── testing/                              ← Testing analysis
│   └── analysis.md                      ← Testing framework
│
├── security/                             ← Security analysis
│   └── analysis.md                      ← Security overview
│
├── glossary/                             ← Terminology
│   └── index.md                         ← Terms
│
├── conventions/                          ← Coding conventions
│   └── naming-conventions.md            ← Naming rules
│
├── decisions/                            ← Architecture decisions
│   ├── adr-001-layered-architecture.md
│   └── adr-002-aggregator-pattern.md
│
├── onboarding/                           ← Onboarding
│   └── getting-started.md               ← Quick start
│
├── summaries/                            ← Summaries
│   ├── build-summary.md
│   └── session-summary.md
│
├── concepts/                             ← (Pre-existing)
├── entities/                             ← (Pre-existing)
├── raw/                                  ← (Pre-existing)
└── sources/                              ← (Pre-existing)
```

## Index Files

| Index | Location | Purpose |
|-------|----------|---------|
| Master Index | index.md | Top-level navigation |
| Projects Index | system/indexes/projects-index.md | All projects |
| Layer Index | system/indexes/layer-index.md | Layer breakdown |
| Dependency Index | system/indexes/dependency-index.md | Dependencies |
| Architecture Index | system/indexes/architecture-index.md | Patterns |
| Services Index | system/indexes/services-index.md | Services |
| Handlers Index | system/indexes/handlers-index.md | Handlers |
| Events Index | system/indexes/events-index.md | Events |
| Domains Index | system/indexes/domains-index.md | Bounded contexts |
| Security Index | system/indexes/security-index.md | Security |
| Tests Index | system/indexes/tests-index.md | Tests |
| Commands Index | system/indexes/commands-index.md | Commands |
| Queries Index | system/indexes/queries-index.md | Queries |
