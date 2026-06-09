---
Extension: Thread
tags:
  - extension
  - plugin
  - thread
  - concurrency
  - documentation

status: draft
---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Thread` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, System.Threading |

## Purpose

The Thread extension provides advanced threading utilities for game development, including thread pools, task schedulers, and synchronization primitives optimized for real-time applications.

## Core Components

### ThreadManager

```csharp
public class ThreadManager
```

Central manager for thread lifecycle and task scheduling.

**Responsibilities:**
- Create and manage worker threads
- Schedule tasks with priorities
- Load balance across cores
- Monitor thread health
- Handle thread exceptions

**Key Methods:**
- `Schedule(Action action, ThreadPriority priority)` — Schedule work on thread pool
- `ScheduleAsync(Func<Task> func, ThreadPriority priority)` — Schedule async work
- `WaitForAll()` — Block until all scheduled tasks complete
- `CancelAll()` — Cancel all pending tasks
- `GetWorkerCount()` — Returns number of active workers

### ThreadPriority

```csharp
public enum ThreadPriority
{
    Lowest = 0,
    BelowNormal = 1,
    Normal = 2,
    AboveNormal = 3,
    Highest = 4,
    Critical = 5 // Game logic priority
}
```

Priority levels for task scheduling.

### WorkerPool

```csharp
public class WorkerPool : IDisposable
```

Fixed-size thread pool for parallel work.

**Features:**
- Configurable pool size
- Work-stealing algorithm
- Task queues per worker
- Automatic load balancing

## Usage Patterns

### Basic Task Scheduling

```csharp
var threadManager = new ThreadManager();

// Schedule work on thread pool
threadManager.Schedule(() =>
{
    // Parallel computation
    var result = ComputeExpensiveOperation();
    return result;
}, ThreadPriority.Normal);

// Wait for completion
threadManager.WaitForAll();
```

### Parallel For Loop

```csharp
// Process array in parallel
threadManager.ParallelFor(0, dataArray.Length, (i) =>
{
    results[i] = ProcessItem(dataArray[i]);
});
```

### Producer-Consumer Pattern

```csharp
var channel = new ThreadedChannel<Item>(capacity: 100);

// Producer
threadManager.Schedule(() =>
{
    while (hasWork)
    {
        var item = GetNextItem();
        channel.Write(item);
    }
});

// Consumer
threadManager.Schedule(() =>
{
    foreach (var item in channel.ReadAll())
    {
        ProcessItem(item);
    }
});
```

## Synchronization Primitives

### GameLock

```csharp
public class GameLock : IDisposable
```

Lock optimized for game loops (short critical sections).

**Features:**
- Spin-wait for short locks
- Automatic timeout
- Deadlock detection in debug builds

### ReadWriteLock

```csharp
public class ReadWriteLock
```

Reader-writer lock for shared data.

**Usage:**
```csharp
var rwLock = new ReadWriteLock();

// Multiple readers can access simultaneously
using (rwLock.ReadLock())
{
    var data = sharedData.Get();
}

// Only one writer at a time
using (rwLock.WriteLock())
{
    sharedData.Update(newValue);
}
```

## Thread Safety Patterns

### Double-Checked Locking

```csharp
private Singleton _instance;
private readonly object _lock = new object();

public Singleton GetInstance()
{
    if (_instance == null)
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
        }
    }
    return _instance;
}
```

### Lock-Free Queue

```csharp
public class LockFreeQueue<T>
{
    private LinkedNode<T> _head;
    private LinkedNode<T> _tail;

    public void Enqueue(T item)
    {
        var node = new LinkedNode<T>(item);
        while (true)
        {
            var tail = _tail;
            var next = tail.Next;
            if (tail == _tail)
            {
                if (next == null)
                {
                    if (Interlocked.CompareExchange(ref tail.Next, node, null) == null)
                    {
                        Interlocked.CompareExchange(ref _tail, node, tail);
                        break;
                    }
                }
                else
                {
                    Interlocked.CompareExchange(ref _tail, next, tail);
                }
            }
        }
    }
}
```

## Performance Considerations

| Operation | Complexity | Notes |
|-----------|------------|-------|
| Task Scheduling | O(1) | Lock-free queue |
| Thread Creation | O(n) | Pool-based |
| Context Switch | O(1) | Managed by OS |
| Lock Acquisition | O(1) | Spin-wait optimized |

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |
| Web (WASM) | ⚠️ | Single-threaded |

## Related

- [[extensions/index|Extensions Index]]
- [[system/indexes/handlers-index|Handlers Index]]
- [[architecture/repository-overview|Repository Overview]]
