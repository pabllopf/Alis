---
title: Stability State
tags:
  - system
  - state
  - tracking
  - management

status: Draft

license: GPLv3

---


## Document Classification

### Stable (immutable / rarely changes)
| Document | Classification |
|---|---|
| Architecture docs | Stable |
| Core engine docs | Stable |
| Ideation aspect docs | Stable |
| Dependency graphs | Stable |
| ADR documents | Stable |
| entities/Component.md | Immutable (status: Done) |
| entities/Alis.md | Immutable (status: Done) |

### Volatile (may change frequently)
| Document | Classification |
|---|---|
| Indexes | Updated per batch |
| State files | Updated per session |
| Queue files | Updated per batch |
| Log files | Updated per session |
| Checkpoint files | Updated per batch |

### Generated
All markdown in .memory/ is auto-generated unless marked with MANUAL NOTES markers or status: Done.

## Related

- [[stability-state]] — Stability state
- [[analysis-state]] — Analysis state
