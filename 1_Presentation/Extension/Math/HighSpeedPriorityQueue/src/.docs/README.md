# HighSpeedPriorityQueue Module

`Alis.Extension.Math.HighSpeedPriorityQueue` provides heap-based priority queues optimized for different use cases.

## Why this module exists

Use this module when you need to repeatedly pick the next item with the *lowest* priority value (min-heap semantics), with strong performance and predictable behavior.

Typical scenarios:

- Pathfinding (A*, Dijkstra).
- Task scheduling.
- Event processing.
- Simulation systems where priorities change over time.

## Queue variants

- `FastPriorityQueue<TNode>`: fastest option for `float` priorities and fixed max size.
- `StablePriorityQueue<TNode>`: fixed-size queue with FIFO ordering when priorities tie.
- `GenericPriorityQueue<TNode, TPriority>`: fixed-size queue with custom priority type and comparer.
- `SimplePriorityQueue<TItem, TPriority>`: easier API, auto-resize, duplicate/null support, Try* methods.

## Complexity (average/typical)

- `Enqueue`: `O(log n)`
- `Dequeue`: `O(log n)`
- `UpdatePriority`: `O(log n)`
- `First`: `O(1)`
- `Contains`: `O(1)` for node-based queues and cached checks in simple queue

## Quick guidance

- Choose `FastPriorityQueue<TNode>` when you need max throughput and can manage node lifecycle manually.
- Choose `StablePriorityQueue<TNode>` when ties must preserve insertion order.
- Choose `GenericPriorityQueue<TNode, TPriority>` when priority is not `float` or requires custom comparison.
- Choose `SimplePriorityQueue<TItem, TPriority>` when ergonomics and safe APIs are more important than raw speed.

## Related docs

- `src/docs/architecture.md`
- `src/docs/api-guide.md`
- `src/docs/samples.md`

