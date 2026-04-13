# API Guide

## `FastPriorityQueue<TNode>`

Use when:

- You can pre-allocate capacity.
- You use `float` priorities.
- You want maximum speed.

Important methods:

- `Enqueue(node, priority)`
- `Dequeue()`
- `UpdatePriority(node, priority)`
- `Remove(node)`
- `Contains(node)`
- `Clear()`
- `Resize(maxNodes)`

Requirements:

- `TNode : FastPriorityQueueNode`
- Nodes should belong to one queue at a time, or call `ResetNode(node)` before reuse.

## `StablePriorityQueue<TNode>`

Adds deterministic FIFO behavior when priorities are equal.

Requirements:

- `TNode : StablePriorityQueueNode`

Recommended when deterministic replay or predictable tie behavior matters.

## `GenericPriorityQueue<TNode, TPriority>`

Same fixed-size model but with generic priorities.

Use when:

- Priority is `DateTime`, `int`, custom struct, etc.
- You need a custom comparer.

Requirements:

- `TNode : GenericPriorityQueueNode<TPriority>`

Constructors:

- `GenericPriorityQueue(int maxNodes)`
- `GenericPriorityQueue(int maxNodes, IComparer<TPriority> comparer)`
- `GenericPriorityQueue(int maxNodes, Comparison<TPriority> comparer)`

## `SimplePriorityQueue<TItem, TPriority>`

Convenience API on top of `GenericPriorityQueue`.

Features:

- Auto-resize.
- Supports duplicates and null items.
- Thread-safe operations via internal lock.
- Safe `Try*` methods.

Notable extras:

- `EnqueueWithoutDuplicates(item, priority)`
- `GetPriority(item)`
- `TryFirst(out item)`
- `TryDequeue(out item)`
- `TryRemove(item)`
- `TryUpdatePriority(item, priority)`
- `TryGetPriority(item, out priority)`

