# Task 001 — GenericPriorityQueue.cs Tests

## File Added

`1_Presentation/Extension/Math/HighSpeedPriorityQueue/test/GenericPriorityQueueEdgeTests.cs`

## Tests Added

1. `CascadeUp_WhileLoop_BubblesNodePastMultipleLevels` — enqueue 8 descending-priority nodes
2. `CascadeDown_WhileLoop_PushesNodeDownMultipleLevels` — dequeue from 8-node queue
3. `UpdatePriority_TriggersOnNodeUpdatedCascadeUp` — update to higher than parent
4. `GetEnumerator_NonGeneric_EnumeratesAllNodes` — non-generic IEnumerable
5. `Dequeue_SingleItem_ReturnsNodeAndEmptiesQueue` — single element dequeue path
6. `Resize_ToLargerArray_IncreasesCapacity` — resize with active elements
7. `Contains_AfterResetNode_ReturnsFalse` — reset node check
8. `Remove_LastNode_DoesNotCorruptQueue` — remove last node edge case
9. `IsValidQueue_EmptyQueue_ReturnsTrue` — empty queue validation
10. `IsValidQueue_SingleElement_ReturnsTrue` — single element validation

## Lines Covered

- 253: non-generic GetEnumerator
- 283-295: CascadeUp while loop
- 310-334: CascadeDown while loop body
- 360-362: OnNodeUpdated CascadeUp path
