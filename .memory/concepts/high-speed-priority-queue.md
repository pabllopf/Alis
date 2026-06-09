---
title: High-Speed Priority Queue
tags:
  - concept
  - theory
  - documentation

status: draft

license: GPLv3
---


High-speed priority queues provide O(log n) operations with minimal memory allocation, optimized for ECS scheduling and real-time systems.

## Core Algorithm

### Binary Heap Implementation
- **Pattern**: Array-based binary heap
- **Location**: `1_Presentation/Extension/Math.HighSpeedPriorityQueue/`
- **Complexity**: O(log n) insert, O(log n) extract-min/max

## Implementation Example

```csharp
public class HighSpeedPriorityQueue<T> where T : IComparable<T>
{
    private T[] _heap;
    private int _count;
    
    public HighSpeedPriorityQueue(int capacity = 64)
    {
        _heap = new T[capacity];
        _count = 0;
    }
    
    public void Enqueue(T item, double priority)
    {
        if (_count == _heap.Length)
            Resize(_heap.Length * 2);
        
        _heap[_count] = new PriorityItem(item, priority);
        SiftUp(_count);
        _count++;
    }
    
    public T Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Queue is empty");
        
        var result = _heap[0].Item;
        _count--;
        _heap[0] = _heap[_count];
        SiftDown(0);
        
        return result;
    }
    
    private void SiftUp(int index)
    {
        while (index > 0)
        {
            var parent = (index - 1) / 2;
            if (_heap[parent].Priority <= _heap[index].Priority)
                break;
            
            Swap(parent, index);
            index = parent;
        }
    }
    
    private void SiftDown(int index)
    {
        while (true)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var smallest = index;
            
            if (left < _count && _heap[left].Priority < _heap[smallest].Priority)
                smallest = left;
            
            if (right < _count && _heap[right].Priority < _heap[smallest].Priority)
                smallest = right;
            
            if (smallest == index) break;
            
            Swap(smallest, index);
            index = smallest;
        }
    }
}

private record struct PriorityItem(T Item, double Priority);
```

## Benefits in Alis

| Benefit | Description |
|---------|-------------|
| **O(log n) Operations** | Fast insert and extract |
| **Memory Efficient** | Array-based, no node allocations |
| **Cache Friendly** | Sequential memory access |
| **No GC Pressure** | Can use struct-based items |

## Performance Comparison

| Operation | Array List | LinkedList | Binary Heap |
|-----------|------------|------------|-------------|
| **Insert** | O(n) | O(1) | O(log n) |
| **Extract Min** | O(n) | O(n) | O(log n) |
| **Memory** | O(n) | O(2n) | O(n) |
| **Cache Hits** | High | Low | High |

## Use Cases in Alis

### ECS Scheduling
```csharp
var systemQueue = new HighSpeedPriorityQueue<ISystem>();

// Add systems with execution priority
systemQueue.Enqueue(movementSystem, 0.1);
systemQueue.Enqueue(renderingSystem, 0.9);

// Execute in priority order
while (systemQueue.Count > 0)
{
    var system = systemQueue.Dequeue();
    system.Update(deltaTime);
}
```

### Event Processing
```csharp
var eventQueue = new HighSpeedPriorityQueue<GameEvent>();

// Schedule events with timestamps
eventQueue.Enqueue(damageEvent, currentTime + 0.5);
eventQueue.Enqueue(spawnEvent, currentTime + 1.0);

// Process events in order
while (eventQueue.Count > 0 && eventQueue.Peek().Timestamp <= currentTime)
{
    var event = eventQueue.Dequeue();
    Process(event);
}
```

## When to Use High-Speed Priority Queue

### Suitable For
- ECS system scheduling
- Event queues with timestamps
- Pathfinding (A* algorithm)
- Task scheduling

### Not Suitable For
- Simple FIFO queues
- LIFO stacks
- Unordered collections

## See Also
- [`.memory/sources/ecs-sources.md`] - Entity Component System
