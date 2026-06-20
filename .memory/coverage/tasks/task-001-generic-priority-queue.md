## COVERAGE TASK

### File

1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/GenericPriorityQueue.cs

### Coverage

75.1%

### Uncovered Lines

253, 283-295, 310-334, 360-362, 382-383, 388-389

### Method

Multiple: GetEnumerator (non-generic), CascadeUp while loop, CascadeDown while loop, OnNodeUpdated (CascadeUp path), IsValidQueue branch conditions

### Existing Tests

- GenericPriorityQueueTest.cs — basic operations: init, enqueue, dequeue, clear, contains, updatepriority, remove, resize, IsValidQueue
- GenericPriorityQueueAdvancedTest.cs — custom comparer, stable priority, remove non-last node, ResetNode

### Source Code

```csharp
public sealed class GenericPriorityQueue<TItem, TPriority> : IFixedSizePriorityQueue<TItem, TPriority>
    where TItem : GenericPriorityQueueNode<TPriority>
{
    // 8 public methods + 4 private methods
    // See full source in src/GenericPriorityQueue.cs
}
```

### Scenarios to Cover

1. CascadeUp while loop — enqueue 8 descending-priority nodes, forcing multi-level bubble-up
2. CascadeDown while loop — dequeue from queue with 8 nodes, forcing multi-level push-down
3. OnNodeUpdated CascadeUp — UpdatePriority on non-root node to higher priority than parent
4. Non-generic GetEnumerator — enumerate via non-generic IEnumerable
