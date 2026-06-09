---
title: FastestTable
tags: [glossary,terminology,reference]
---


## Definition

**FastestTable** is a high-performance lookup table implementation optimized for ECS entity management, providing O(1) average-case lookups with minimal memory overhead.

## Core Characteristics

### Performance

- **Lookup**: O(1) average, O(n) worst case (hash collisions)
- **Insertion**: O(1) amortized
- **Deletion**: O(1) amortized
- **Memory**: Compact storage with minimal padding

### Type Safety

```csharp
public class FastestTable<TValue> where TValue : struct
{
    public TValue this[int index] { get; set; }
    public int Capacity { get; }
    public int Count { get; }
    
    public void EnsureCapacity(int newCapacity);
    public void Clear();
}
```

## Usage in ECS

### Entity Table

Primary use case: entity location tracking

```csharp
public FastestTable<GameObjectLocation> EntityTable = 
    new FastestTable<GameObjectLocation>(256);

// Lookup entity by ID
GameObjectLocation location = EntityTable[entityId];

// Update entity location
EntityTable[entityId] = newLocation;
```

### Component Storage

Component type lookup:

```csharp
public FastestTable<ComponentStorageBase> ComponentTable = 
    new FastestTable<ComponentStorageBase>();

// Register component type
ComponentTable[componentId] = storage;

// Retrieve component storage
ComponentStorageBase storage = ComponentTable[componentId];
```

## Implementation Details

### Hash Table

Internal hash table structure:

- Open addressing for collision resolution
- Linear probing for bucket search
- Dynamic resizing when load factor exceeds threshold

### Capacity Management

```csharp
public void EnsureCapacity(int newCapacity)
{
    if (newCapacity > Capacity)
    {
        // Resize table
        int newTableSize = CalculateNextPowerOfTwo(newCapacity);
        Resize(newTableSize);
    }
}
```

### Thread Safety

- Not thread-safe by default
- External synchronization required for concurrent access
- Lock-free reads possible with proper memory barriers

## Performance Optimizations

### Power of Two Sizing

Table capacity always power of two:

```csharp
private int CalculateNextPowerOfTwo(int capacity)
{
    int power = 1;
    while (power < capacity)
        power *= 2;
    return power;
}
```

### Hash Function

Efficient hash computation:

```csharp
private int Hash(int key)
{
    // Simple but effective hash
    uint h = (uint)key;
    h ^= h >> 15;
    h *= 0x85ebca6bu;
    h ^= h >> 13;
    h *= 0xc2b2ae35u;
    h ^= h >> 16;
    return (int)(h % Capacity);
}
```

### Memory Layout

Compact storage:

- Contiguous array for buckets
- Separate array for values
- No object overhead per entry

## Related

- [[FastestStack]] - Memory-efficient stack
- [[GameObjectLocation]] - Entity location data
- [[Scene]] - World container
- [[GameObject]] - Entity handle
- [[Archetype]] - Component optimization
- [[Component Storage]] - Typed data storage
- [[memory-management]] — Memory strategy

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[performance-index]] — Performance optimizations
- [[architecture-index]] — Patterns
