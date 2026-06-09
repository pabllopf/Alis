---
title: Generator Pattern
tags: [concept,theory,documentation]
---


Alis uses Roslyn source generators to produce AOT-safe code at compile time, eliminating runtime reflection requirements.

## Source Generators

| Generator | Produces For | Layer |
|-----------|-------------|-------|
| `Alis.Core.Ecs.Generator` | ECS components, systems, registration code | 4_Operation/Ecs |
| `Alis.Core.Graphic.Generator` | Graphic primitives, rendering code | 4_Operation/Graphic |
| `Alis.Core.Aspect.Memory.Generator` | Memory abstractions, serialization | 6_Ideation/Memory |
| `Alis.Core.Aspect.Data.Generator` | Data structures, collections | 6_Ideation/Data |
| `Alis.Core.Aspect.Fluent.Generator` | Fluent APIs, builder patterns | 6_Ideation/Fluent |

## Generator Benefits

1. **AOT Compatibility** - No runtime IL emit, safe for Native AOT
2. **Type Safety** - Compile-time error detection
3. **Performance** - Generated code is static, no reflection overhead
4. **Diagnostics** - Clear error messages for invalid configurations (ALIS0xxx IDs)

## Usage Pattern

```csharp
[GenerateComponent(typeof(Position))]
[GenerateSystem(typeof(MovementSystem))]
public class GameModule { }

// Generator produces:
// - Component registration code
// - System iteration logic
// - Entity management helpers
```

## AOT Compatibility Requirements

- No `System.Reflection.Emit`
- No runtime IL emit
- No dynamic method generation
- All code must be generated at compile time

## See Also
- [[Entity Component System]]
- [[Multi-Targeting Strategy]]
- [[Alis Architecture Overview]]
- [[Layered Architecture]]
- [[Alis Architecture Overview]]

## Related Architecture

- [[architecture/dependency-graph]] — Generator cascade details
- [[build-system]] — Build pipeline with generators
- [[build-summary]] — Generator flow in build
- [[projects/Generators]] — Generator project docs
- [[adr-001-layered-architecture]] — Generator flow decision

## Related Tests

- [[testing/analysis]] — Generator testing strategy
- [[code-review-checklist]] — Generator review checklist
