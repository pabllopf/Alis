---
title: Dependency Index
tags:
  - index
  - dependencies
  - tracking
status: Draft
license: GPLv3
---

# Dependency Index

## Layer Dependency Matrix

| Layer | Depends On | Depended By |
|---|---|---|
| 6_Ideation | (BCL only) | 5_Declaration |
| 5_Declaration | 6_Ideation | 4_Operation |
| 4_Operation | 5_Declaration | 3_Structuration |
| 3_Structuration | 4_Operation | 2_Application |
| 2_Application | 3_Structuration | 1_Presentation |
| 1_Presentation | 2_Application | (external) |

## Project Dependency Counts

| Project | Direct Dependencies | Dependents |
|---|---|---|
| Alis.Core.Aspect.Data | 0 | 5+ |
| Alis.Core.Aspect.Math | 0 | 5+ |
| Alis.Core.Aspect (5_Declaration) | 6 | 4+ |
| Alis.Core (3_Structuration) | 5 | 1+ |
| Alis (2_Application) | 1+ | 9+ |

## External Dependency Count

| Type | Count |
|---|---|
| NuGet packages (conditional) | 4 |
| Legacy compatibility packages | 4 |
| SourceLink | 1 |
| **Total unique external packages** | **5** |

## Related Documents

- [[dependency-graph]]
- [[layer-violations]]
- [[projects-index]]
