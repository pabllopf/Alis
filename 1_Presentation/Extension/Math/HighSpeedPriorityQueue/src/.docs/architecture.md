# Architecture and Design Notes

## Core model

All implementations are min-heaps backed by arrays.

- Parent index: `i / 2`
- Left child: `2 * i`
- Right child: `2 * i + 1`

Node-based queues store metadata in node objects:

- `QueueIndex`: current heap position.
- `Priority`: current priority value.
- `InsertionIndex`: tie-break order (stable variants).

## Stability behavior

- `FastPriorityQueue<TNode>` does **not** guarantee FIFO for equal priorities.
- `StablePriorityQueue<TNode>` and `GenericPriorityQueue<TNode, TPriority>` are stable via `InsertionIndex`.
- `SimplePriorityQueue<TItem, TPriority>` is stable because it wraps `GenericPriorityQueue`.

## Resizing model

- Fixed-size queues (`Fast`, `Stable`, `Generic`) expose `MaxSize` and `Resize`.
- `SimplePriorityQueue` grows automatically when internal storage reaches capacity.

## Threading model

- `SimplePriorityQueue` uses internal locking and provides `Try*` methods to avoid exception-driven flows.
- Node-based queues (`Fast`, `Stable`, `Generic`) are not synchronized by default.

## Practical trade-offs

- `Fast` is best for hot paths with strict performance budgets.
- `Stable` and `Generic` add tie-order guarantees and flexible comparisons.
- `Simple` is easiest to integrate and safest for common application logic.

