---
title: ADR-001: Six-Layer Screaming Architecture
tags:
  - decision
  - adr
  - architecture

status: draft
---


## Status
Accepted

## Context
ALIS needed a clear architectural structure that:
1. Enforces strict dependency rules
2. Supports source generator cascading
3. Scales to 140+ projects
4. Makes the purpose of each component obvious

## Decision
We adopted a six-layer screaming architecture:
1. **Presentation** — User-facing apps and extensions
2. **Application** — Game samples and core app
3. **Structuration** — Core engine aggregator
4. **Operation** — Engine subsystems (ECS, Graphic, Audio, Physic)
5. **Declaration** — Aspect system aggregator
6. **Ideation** — Aspect definitions and source generators

### Dependency Rules
- Each layer may only reference the immediate lower layer
- No cross-layer or upward references allowed
- Source generators cascade: Ideation → Declaration → Operation → ...

### Generator Flow
Source generators in 6_Ideation produce code that flows down through all layers, enabling aspect-oriented programming.

## Consequences
- **Positive**: Clear boundaries, easy to understand, enforces separation of concerns
- **Negative**: More projects to navigate, some indirection through aggregators
- **Mitigation**: Aggregator projects make the dependency graph explicit and reduce reference count

## References
- `Directory.Build.props` — Centralized build config
- `2_Application/Alis/src/.docs/arquitecture.md` — Canonical architecture reference

## Related

- [[adr-002-aggregator-pattern]] — Related aggregator decision
- [[Layered Architecture]] — Layer structure details
- [[Alis Architecture Overview]] — Full architecture overview
- [[repository-overview]] — Architecture overview
- [[architecture/dependency-graph]] — Dependency rules
- [[build-system]] — Build configuration
- [[layer-index]] — Layer breakdown
- [[projects/Architecture]] — Project-level architecture
- [[architecture-index]] — Architectural patterns index
