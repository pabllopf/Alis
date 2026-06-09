---
title: ADR-002: Aggregator Pattern for Core Projects
tags: [decision,adr,architecture]
---


## Status
Accepted

## Context
Alis.Core and Alis.Core.Aspect need to expose types from many lower-layer projects without duplicating code or creating complex reference chains.

## Decision
Use the aggregator pattern: these projects contain zero hand-written code and exist solely to re-export types from lower layers.

## Consequences
- **Positive**: Single project reference for consumers, clean dependency graph
- **Negative**: No business logic in these projects (by design)
- **Benefit**: Adding a new subsystem only requires adding a project reference to the aggregator

## References
- `3_Structuration/Core` — Alis.Core aggregator
- `5_Declaration/Aspect` — Alis.Core.Aspect aggregator

## Related

- [[adr-001-layered-architecture]] — Layer architecture decision
- [[Layered Architecture]] — Layer structure
- [[Aspect-Oriented Design]] — Aspect aggregation
- [[Alis Architecture Overview]] — Full architecture
- [[repository-overview]] — Architecture overview
- [[projects/Architecture]] — Project-level details
- [[Alis.Core]] — Core aggregator project
- [[Alis.Core.Aspect]] — Aspect aggregator project
- [[architecture-index]] — Patterns index
