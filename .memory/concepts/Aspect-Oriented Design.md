---
title: Aspect-Oriented Design
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Alis uses aspect-oriented programming with Core.Aspect as the declarative foundation, building experimental aspects on top.

## Architecture

```
5_Declaration/
└── Aspect/  ← Core.Aspect - declarative foundation

6_Ideation/  ← Built on top of Core.Aspect
├── Memory/     ← Memory abstractions (with generator)
├── Fluent/     ← Fluent APIs (with generator)
├── Math/       ← Mathematical utilities
├── Time/       ← Time management
├── Data/       ← Data structures (with generator)
└── Logging/    ← Logging infrastructure
```

## Aspects Overview

| Aspect | Purpose | Generator | Complexity |
|--------|---------|-----------|------------|
| **Memory** | Memory abstractions, serialization | Yes (Alis.Core.Aspect.Memory.Generator) | High |
| **Fluent** | Fluent APIs, builder patterns | Yes (Alis.Core.Aspect.Fluent.Generator) | High |
| **Math** | Mathematical utilities, algorithms | No | Medium |
| **Time** | Time management, scheduling | No | Medium |
| **Data** | Data structures, collections | Yes (Alis.Core.Aspect.Data.Generator) | High |
| **Logging** | Logging infrastructure, diagnostics | No | Medium |

## Aspect-Oriented Benefits

1. **Cross-cutting concerns** - Logging, validation, error handling
2. **Modularity** - Separate orthogonal features
3. **Reusability** - Aspects can be composed
4. **Maintainability** - Clear separation of concerns

## Generator Integration

Aspects marked "Yes" use source generators:
- Compile-time code generation
- AOT-safe execution
- Type-safe APIs
- Clear diagnostics (ALIS0xxx IDs)

## See Also
- [[Layered Architecture]]
- [[Generator Pattern]]
- [[Alis Architecture Overview]]
- [[Alis Architecture Overview]]
- [[Solution Composition]]

## Related Projects

- [[Alis.Core.Aspect.Fluent]] — Fluent builder aspect
- [[Alis.Core.Aspect.Memory]] — Memory management aspect
- [[Alis.Core.Aspect.Data]] — JSON serialization aspect
- [[Alis.Core.Aspect.Math]] — Math primitives aspect
- [[Alis.Core.Aspect.Time]] — High-res clock aspect
- [[Alis.Core.Aspect.Logging]] — Structured logging aspect

## Related Architecture

- [[projects/Architecture]] — Project-level architecture
- [[layer-index]] — Layer 5 & 6 details
- [[architecture-index]] — AOP pattern documentation
- [[services-index]] — Aspect services
- [[domains-index]] — AOP domain
