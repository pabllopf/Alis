---
title: Performance Index
tags:
  - index
  - catalog
  - reference

status: draft
---


## Performance-Critical Systems

| System | Optimization | Status |
|---|---|---|
| ECS Query | Chunk-based iteration | Implemented |
| Memory Pooling | ArrayPool<T> usage | Implemented |
| Graphics Rendering | Batch rendering | Partial |
| Asset Loading | Async loading + caching | Implemented |

## Benchmarks

- **ECS Update**: ~1M entities at 60 FPS (single thread)
- **Query Execution**: O(n) with low constant factor
- **Memory Allocation**: Zero-allocation queries

## Optimization Techniques

1. **Struct-based components**: Value types for cache efficiency
2. **Chunked storage**: Contiguous memory for entity arrays
3. **Query caching**: Pre-computed query results
4. **Memory pooling**: Reuse buffers to avoid GC

## Hot Paths

- Entity creation/destruction
- Component access in update loop
- Graphics draw calls

## Related

- [[Alis.Core.Ecs]] — ECS performance
- [[Alis.Core.Aspect.Memory]] — Memory pooling
- [[Alis.Core.Graphic]] — Rendering performance
- [[Alis.Benchmark]] — Benchmarking app
- [[architecture-index]] — Performance patterns
- [[tests-index]] — Performance tests
- [[project-index]] — Performance-critical projects
- [[memory-management]] — Memory optimization
- [[glossary/index]] — Performance-related terms
- [[indexes-summary]] — All indexes
