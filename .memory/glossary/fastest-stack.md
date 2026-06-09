# FastestStack

tags:
  - glossary,terminology,reference

## Definition

**FastestStack** is a memory-efficient stack implementation optimized for ECS operations, providing O(1) push/pop operations with minimal allocation overhead.

## Core Characteristics

### Performance

- **Push**: O(1) amortized
- **Pop**: O(1)
- **Peek**: O(1)
- **Memory**: Pre-allocated buffer with dynamic resizing

### Type Safety

```csharp
public class FastestStack<T> where T : struct
{
    public int Count { get; }
    public int Capacity { get; }
    
    public void Push(T item);
    public T Pop();
    public T Peek();
    public bool CanPop();
    public void Clear();
}
```

## Usage in ECS

### Deferred Operations

Queue deferred entity operations:

```csharp
public FastestStack<ArchetypeDeferredUpdateRecord> 
    DeferredCreationArchetypes = 
    FastestStack<ArchetypeDeferredUpdateRecord>.Create(4);

// Queue deferred creation
DeferredCreationArchetypes.Push(archetypeRecord);

// Process deferred operations
while (DeferredCreationArchetypes.Count > 0)
{
    var record = DeferredCreationArchetypes.Pop();
    // Apply deferred operation
}
```

### Recycled Entity IDs

Track recycled entity identifiers:

```csharp
public FastestStack<GameObjectIdOnly> RecycledEntityIds = 
    new FastestStack<GameObjectIdOnly>(256);

// Push recycled ID
RecycledEntityIds.Push(recycledId);

// Pop for reuse
if (RecycledEntityIds.CanPop())
{
    var id = RecycledEntityIds.Pop();
    // Reuse entity ID
}
```

### Archetype Management

Manage archetype stack during updates:

```csharp
public FastestStack<GameObjectType> EnabledArchetypes = 
    FastestStack<GameObjectType>.Create(16);

// Push archetype for processing
EnabledArchetypes.Push(archetypeId);

// Process all enabled archetypes
while (EnabledArchetypes.Count > 0)
{
    var archetype = EnabledArchetypes.Pop();
    // Update archetype
}
```

## Implementation Details

### Pre-allocated Buffer

Initial capacity specified at construction:

```csharp
public FastestStack(int initialCapacity)
{
    _buffer = new T[initialCapacity];
    _count = 0;
}

// Create with default capacity
public static FastestStack<T> Create(int capacity = 16)
{
    return new FastestStack<T>(capacity);
}
```

### Dynamic Resizing

Automatic buffer expansion:

```csharp
public void Push(T item)
{
    if (_count == _buffer.Length)
    {
        // Resize buffer (double capacity)
        Array.Resize(ref _buffer, _buffer.Length * 2);
    }
    
    _buffer[_count++] = item;
}
```

### Memory Reuse

Minimize allocations:

- Reuse existing buffer when possible
- Only resize when necessary
- Clear without reallocation

## Performance Optimizations

### No Garbage Allocation

Stack operations avoid allocations:

- Reuse existing buffer
- No temporary objects created
- Minimal GC pressure

### Cache Efficiency

Contiguous memory layout:

- Single array for all elements
- Sequential access patterns
- CPU cache-friendly

### Thread Safety

- Not thread-safe by default
- External synchronization required
- Lock-free reads possible with memory barriers

## Related

- [[FastestTable]] - High-performance lookup table
- [[GameObjectIdOnly]] - Entity ID wrapper
- [[ArchetypeDeferredUpdateRecord]] - Deferred operation record
- [[GameObject]] - Entity handle
- [[Scene]] - World container
- [[memory-management]] — Memory strategy

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Performance optimizations
- [[architecture-index]] — Patterns
