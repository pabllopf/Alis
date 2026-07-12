---
title: Module Structure
tags:
  - architecture
  - modules
  - structure
status: Draft
license: GPLv3
---

# Module Structure

## Standard Module Template

Each functional module follows a consistent project structure:

```text
<Module>/
├── generator/        # Roslyn source generator (netstandard2.0)
│   └── <Name>.csproj
├── sample/           # Usage example
│   └── <Name>.csproj
├── src/              # Main library
│   └── <Name>.csproj
└── test/             # Unit tests
    └── <Name>.csproj
```

## Modules Following This Pattern

| Layer | Module | Generator | Sample | Source | Test |
|---|---|---|---|---|---|
| 4_Operation | Audio | ✓ | ✓ | ✓ | ✓ |
| 4_Operation | Ecs | ✓ | ✓ | ✓ | ✓ |
| 4_Operation | Graphic | ✓ | ✓ | ✓ | ✓ |
| 4_Operation | Physic | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Data | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Fluent | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Logging | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Math | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Memory | ✓ | ✓ | ✓ | ✓ |
| 6_Ideation | Time | ✓ | ✓ | ✓ | ✓ |

## Non-Standard Projects

| Project | Pattern | Reason |
|---|---|---|
| Alis (2_Application) | src + test + samples + generator | Main assembly |
| Alis.Core (3_Structuration) | src + test + sample + generator | Core abstractions |
| Alis.Core.Aspect (5_Declaration) | src + test + sample | Aspect interfaces (no generator needed) |
| Presentation projects | src + test (some with sample) | App-specific structure |
| Extension projects | src + test + sample | Independent extensions |

## Related Documents

- [[architecture-overview]]
- [[project-index]]
- [[source-generator-architecture]]
