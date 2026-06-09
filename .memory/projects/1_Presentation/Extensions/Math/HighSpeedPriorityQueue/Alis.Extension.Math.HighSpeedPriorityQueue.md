---
title: Alis.Extension.Math.HighSpeedPriorityQueue
tags: [presentation,application,extension,documentation]
---


## Overview

The **Alis.Extension.Math.HighSpeedPriorityQueue** project provides high-performance priority queue implementations for ALIS, optimized for game loop operations and real-time systems.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 9 source files

## Purpose

This extension offers multiple priority queue implementations with different trade-offs between speed, memory usage, and feature support, enabling developers to choose the optimal structure for their specific use case.

## Architecture

### Implementation Variants

| Queue Type | Speed | Memory | Features |
|------------|-------|--------|----------|
| `FastPriorityQueue` | Fastest | Moderate | Basic priority queue |
| `GenericPriorityQueue` | Fast | Low | Full feature set |
| `StablePriorityQueue` | Moderate | Moderate | Stable ordering |
| `SimplePriorityQueue` | Fastest | Lowest | Simple operations only |

### Data Structure

Implements **Binary Heap** with additional optimizations:

```
GenericPriorityQueue<TItem, TPriority>
├── Items array (TItem[])
├── Priorities array (TPriority[])
├── Node indices mapping
└── Size tracking
```

### Performance Characteristics

| Operation | FastPriorityQueue | GenericPriorityQueue |
|-----------|-------------------|---------------------|
| Enqueue | O(log n) | O(log n) |
| Dequeue | O(log n) | O(log n) |
| Peek | O(1) | O(1) |
| Update Priority | O(log n) | O(log n) |
| Remove Item | O(log n) | O(log n) |

## Components

### Core Classes

| Class | Description | Type |
|-------|-------------|------|
| `FastPriorityQueue` | High-speed basic queue | Class |
| `GenericPriorityQueue` | Full-featured generic queue | Class |
| `StablePriorityQueue` | Stable ordering queue | Class |
| `SimplePriorityQueue` | Minimal overhead queue | Class |

### Node Classes

| Class | Description |
|-------|-------------|
| `FastPriorityQueueNode` | Fast queue node |
| `GenericPriorityQueueNode` | Generic queue node |
| `StablePriorityQueueNode` | Stable queue node |

### Interfaces

| Interface | Description |
|-----------|-------------|
| `IPriorityQueue` | Basic priority queue interface |
| `IFixedSizePriorityQueue` | Fixed-size constraint |

## Public API

### FastPriorityQueue

```csharp
// Create queue
var queue = new FastPriorityQueue<int>(maxSize: 1000);

// Enqueue with priority
queue.Enqueue(item: 5, priority: 3);
queue.Enqueue(item: 10, priority: 1);
queue.Enqueue(item: 15, priority: 2);

// Dequeue highest priority
int item = queue.Dequeue(); // Returns 5 (priority 3)

// Peek without removing
int highest = queue.Peek(); // Returns 5

// Check if empty
bool isEmpty = queue.Count == 0;
```

### GenericPriorityQueue

```csharp
// Create queue with custom priority type
var queue = new GenericPriorityQueue<string, int>(maxSize: 1000);

// Enqueue
queue.Enqueue("Low priority task", priority: 1);
queue.Enqueue("High priority task", priority: 10);
queue.Enqueue("Medium priority task", priority: 5);

// Dequeue
string task = queue.Dequeue(); // Returns "High priority task"

// Update priority
queue.UpdatePriority("Medium priority task", priority: 8);

// Remove specific item
bool removed = queue.Remove("Low priority task");

// Check contains
bool hasItem = queue.Contains("High priority task");
```

### StablePriorityQueue

```csharp
// Creates stable ordering for equal priorities
var queue = new StablePriorityQueue<int>(maxSize: 1000);

queue.Enqueue(1, priority: 5);
queue.Enqueue(2, priority: 5); // Same priority as above
queue.Enqueue(3, priority: 5);

// Dequeue maintains insertion order for equal priorities
int first = queue.Dequeue(); // Returns 1 (first inserted)
int second = queue.Dequeue(); // Returns 2
```

### SimplePriorityQueue

```csharp
// Minimal overhead queue
var queue = new SimplePriorityQueue<int>(maxSize: 1000);

queue.Enqueue(42, priority: 3);
queue.Enqueue(17, priority: 7);

int item = queue.Dequeue(); // Returns 17 (higher priority)
```

## Usage Examples

### Game Entity Management

```csharp
// Manage game entities by update priority
var entityQueue = new GenericPriorityQueue<GameEntity, float>(maxSize: 1000);

// Add entities with update timing
foreach (var entity in gameEntities)
{
    float updateTime = entity.NextUpdateTime;
    entityQueue.Enqueue(entity, priority: updateTime);
}

// Process entities in priority order
while (entityQueue.Count > 0)
{
    GameEntity entity = entityQueue.Dequeue();
    entity.Update();
    
    // Re-queue for next update
    float nextTime = SystemTime.Now + entity.UpdateInterval;
    entityQueue.Enqueue(entity, priority: nextTime);
}
```

### AI Behavior Tree

```csharp
// Prioritize AI decisions
var decisionQueue = new FastPriorityQueue<AIDecision>(maxSize: 100);

foreach (var decision in availableDecisions)
{
    float urgency = CalculateDecisionUrgency(decision);
    decisionQueue.Enqueue(decision, priority: urgency);
}

// Execute most urgent decisions first
while (decisionQueue.Count > 0)
{
    AIDecision decision = decisionQueue.Dequeue();
    ExecuteDecision(decision);
}
```

### Event System

```csharp
// Process events by priority
var eventQueue = new StablePriorityQueue<GameEvent, int>(maxSize: 500);

// Queue events
eventQueue.Enqueue(new PlayerDeathEvent(), priority: 10);
eventQueue.Enqueue(new ChatMessageEvent(), priority: 2);
eventQueue.Enqueue(new WeatherChangeEvent(), priority: 5);

// Process in order
while (eventQueue.Count > 0)
{
    GameEvent evt = eventQueue.Dequeue();
    
    switch (evt)
    {
        case PlayerDeathEvent death:
            HandlePlayerDeath(death);
            break;
        case ChatMessageEvent chat:
            HandleChatMessage(chat);
            break;
    }
}
```

### Resource Management

```csharp
// Manage resource requests by priority
var resourceQueue = new GenericPriorityQueue<ResourceRequest, int>(maxSize: 200);

// Add requests
resourceQueue.Enqueue(new ResourceRequest { Type = "ammo", Quantity = 100 }, priority: 8);
resourceQueue.Enqueue(new ResourceRequest { Type = "health", Quantity = 50 }, priority: 10);
resourceQueue.Enqueue(new ResourceRequest { Type = "fuel", Quantity = 200 }, priority: 3);

// Process highest priority requests first
while (resourceQueue.Count > 0)
{
    ResourceRequest request = resourceQueue.Dequeue();
    
    if (CanSatisfyRequest(request))
    {
        FulfillRequest(request);
    }
    else
    {
        // Re-queue with lower priority
        resourceQueue.Enqueue(request, priority: 1);
    }
}
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**Internal Dependencies**:
- None (pure algorithmic implementation)

**External Dependencies**:
- None

## Performance Tips

### Choosing the Right Queue

| Use Case | Recommended Queue |
|-----------|-------------------|
| Maximum speed, simple operations | `FastPriorityQueue` |
| Full feature set needed | `GenericPriorityQueue` |
| Stable ordering required | `StablePriorityQueue` |
| Minimal memory footprint | `SimplePriorityQueue` |

### Memory Optimization

```csharp
// Pre-allocate capacity to avoid resizing
var queue = new GenericPriorityQueue<Entity, float>(maxSize: 1000);

// Clear without reallocating
queue.Clear(); // Maintains capacity
```

### Update Priority Performance

```csharp
// Efficient priority updates
var queue = new GenericPriorityQueue<Player, float>(maxSize: 500);

// Add player
queue.Enqueue(player, priority: 10.0f);

// Update priority without re-enqueueing
queue.UpdatePriority(player, priority: 5.0f); // O(log n)
```

## Testing

**Test Project**: `Alis.Extension.Math.HighSpeedPriorityQueue.Test`  
**Sample Project**: `Alis.Extension.Math.HighSpeedPriorityQueue.Sample`

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | ✓ Unit tests exist |
| Samples | Pending |

## Related Projects

- [[Alis.Extension.Math.ProceduralDungeon]] - Dungeon generation
- [[Alis.Core.Ecs]] - ECS engine for entity management

## TODO

- [ ] Add concurrent priority queue variant
- [ ] Implement custom comparators
- [ ] Add performance benchmarks
- [ ] Create memory profiler integration
