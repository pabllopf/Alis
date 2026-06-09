# Generator Pattern

Several aspects use source generators to produce code at compile time:

## Generators

| Generator | Produces For |
|-----------|-------------|
| `Alis.Core.Ecs.Generator` | ECS components/systems |
| `Alis.Core.Graphic.Generator` | Graphic primitives |
| `Alis.Core.Aspect.Memory.Generator` | Memory abstractions |
| `Alis.Core.Aspect.Data.Generator` | Data structures |
| `Alis.Core.Aspect.Fluent.Generator` | Fluent APIs |

## See Also
- [[Aspect-Oriented Design]]
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
