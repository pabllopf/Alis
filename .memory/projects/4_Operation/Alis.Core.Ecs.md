# Alis.Core.Ecs

tags:
  - operation,runtime,implementation,documentation

## Overview
Entity Component System (ECS) library for ALIS game engine. Provides high-performance ECS architecture with structurally-oriented design.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: 108 C# files

## Project Details

| Property | Value |
|---|---|
| **Layer** | 4_Operation |
| **Type** | Library (ECS Engine) |
| **Framework** | net8.0 (multi-targeted) |
| **Output Type** | Class Library |
| **Namespace** | Alis.Core.Ecs |

## Purpose
Implements a complete Entity Component System architecture for game development. Provides high-performance entity management, component systems, scene management, and query capabilities. Core engine subsystem for ALIS.

## Architecture

### Core Concepts

#### Scene
The central container for all entities and systems in the ECS architecture.

**Key Features:**
- Entity creation with arbitrary component combinations
- Component add/remove operations with event notifications
- Custom queries using rule-based filtering
- Update systems by attribute type or component type
- Structural change safety during update cycles
- Bulk entity creation for performance
- Deferred structural changes (applied after update cycle)

**Implementation Details:**
- Uses archetype-based storage for cache efficiency
- Implements deferred structural changes to prevent crashes during updates
- Provides entity creation with typed components
- Supports bulk entity creation for performance
- Manages archetype graph edges for component transitions

**Key Fields:**
- `DefaultArchetype` - Base archetype with zero components
- `DefaultWorldGameObject` - GameObject handle for scene itself
- `Id` - Unique scene identifier (ushort)
- `ArchetypeGraphEdges` - Dictionary of archetype transitions
- `_allowStructuralChanges` - Recursion limit for structural changes (default: 200)

**Events:**
- `ComponentAddedEvent` - Fired when component is added
- `ComponentRemovedEvent` - Fired when component is removed
- `EntityCreatedEvent` - Fired when entity is created

#### GameObject
A lightweight identifier representing an entity in the ECS architecture.

**Memory Layout:**
```csharp
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GameObject : IEquatable<GameObject>
{
    internal int EntityID;        // 4 bytes - entity identifier
    internal ushort EntityVersion; // 2 bytes - version counter
    internal ushort WorldID;       // 2 bytes - scene identifier
    // Total: 8 bytes, no padding
}
```

**Key Features:**
- 8-byte value type (no allocation)
- Version counter prevents access to deleted entities
- Safe handling of recycled entity IDs
- Direct component access via `Get<T>()`
- Component add/remove operations

**Usage Example:**
```csharp
// Create entity with components
var player = scene.Create(new Transform { X = 0, Y = 0 }, new Health { Value = 100 });

// Add component
player.Add(new Velocity { X = 5, Y = 10 });

// Get component (returns ref)
ref var health = ref player.Get<Health>();

// Check if alive
if (player.IsAlive()) { /* modify */ }
```

#### Component
Base class and pattern for all component data.

**Pattern:**
```csharp
// Tag component (no data)
public struct Render {}

// Data component
public struct Transform
{
    public float X, Y, Z;
}

// Component with lifecycle
public struct Health : IOnDestroy
{
    public int Value;
    
    public void OnDestroy()
    {
        // Cleanup when component removed
    }
}
```

**Component<T> Static Class:**
- Provides type-safe component access
- Auto-registers component types via source generator
- Manages component storage and lifecycle
- Creates component handles for storage

### Archetype System

**Archetype:** Groups entities with identical component types.

**Benefits:**
- Cache-friendly memory layout
- Fast entity queries
- Efficient component access
- Automatic archetype graph management

**Archetype Graph:**
- Tracks component transitions
- Manages archetype edges
- Enables structural change safety

**ArchetypeData:**
```csharp
public record struct ArchetypeData(ArchetypeID Id, FastImmutableArray<ComponentId> ComponentTypes);
```

### Query System

**Query:** Rule-based entity filtering.

**Query Patterns:**
```csharp
// With components
var query = scene.CreateQuery(Rule.With<Transform>().And<Health>());

// Without components
var query = scene.CreateQuery(Rule.With<Transform>().Not<Disabled>());

// Bulk query
var entities = query.ToList();
```

**Query Types:**
- `Query` - Main query class
- `QueryEnumerator` - Entity iteration
- `ChunkQueryEnumerator` - Chunk-based iteration (performance)
- `GameObjectQueryEnumerator` - GameObject-based iteration

**Rule System:**
- `With<T>` - Must have component
- `And<T>` - Additional required components
- `Not<T>` - Must not have component
- `Or<T>` - Either component

### Update Systems

**Update Types:**
- `Update` - Standard update cycle
- `FixedUpdate` - Fixed timestep update
- `LateUpdate` - Late update cycle
- `NoneUpdate` - No update (tag components)

**Update Registration:**
```csharp
[UpdateOrder(1)]
public struct TransformUpdate : IComponentUpdateFilter<Transform>
{
    public void Update(in GameObject entity, ref Transform transform)
    {
        // Update logic
    }
}
```

**Update Flow:**
1. Scene calls `Update<T>()`
2. Query finds entities with component
3. Update runner executes on each entity
4. Structural changes queued
5. Changes applied after cycle

## Key Components

### Collections (14 files)

High-performance data structures optimized for ECS:

| Class | Purpose |
|---|---|
| `ArchetypeNeighborCache` | Archetype transition cache |
| `Chunk` | Entity chunk storage |
| `FastestArrayPool` | Object pooling |
| `FastestStack` | High-performance stack |
| `FastestTable` | Fast lookup table |
| `FastLookup` | Component lookup |
| `FrugalStack` | Memory-efficient stack |
| `IDTable` | Component ID table |
| `InlineArray8` | Inline array struct |
| `ShortSparseSet` | Sparse set with short keys |
| `SparseSet` - Entity lookup |

### Kernel (30+ files)

Core ECS infrastructure:

| Folder | Contents |
|---|---|
| `Archetypes` | Archetype management |
| `Events` | Component events |
| `Updating` | Update system |
| `Runners` | Update runners |

### Systems (24 files)

Query and system infrastructure:

| Class | Purpose |
|---|---|
| `Query` | Query definition |
| `QueryEnumerator` | Entity iteration |
| `ChunkQueryEnumerator` | Chunk iteration |
| `Rule` | Query rules |
| `QueryHash` | Query hashing |

### Updating (15 files)

Update system infrastructure:

| Class | Purpose |
|---|---|
| `SceneUpdateFilter` | Scene update filtering |
| `SingleComponentUpdateFilter` | Single component updates |
| `UpdateRunnerFactory` | Update runner creation |
| `GameObjectUpdate` | GameObject update |

### Marshalling (2 files)

Serialization support:

| Class | Purpose |
|---|---|
| `SceneMarshal` | Scene serialization |
| `GameObjectMarshal` | Entity serialization |

### Redifinition (9 files)

.NET API redefinitions for compatibility:

| Class | Purpose |
|---|---|
| `MemoryMarshal` | Memory operations |
| `BitOperations` | Bit operations |
| `MemoryTrimming` | Memory management |
| `Gen2GcCallback` - GC callback |

### Exceptions (2 files)

Error handling:

| Exception | Purpose |
|---|---|
| `ComponentAlreadyExistsException` | Duplicate component |
| `ComponentNotFoundException` | Missing component |

## Dependencies

### Internal
- [[Alis.Core.Aspect.Math.Collections]] - Collections
- [[Alis.Core.Ecs.Kernel]] - ECS kernel
- [[Alis.Core.Ecs.Redifinition]] - Redefinition support

### External
- None (pure .NET)

## Build Configuration

| Property | Value |
|---|---|
| **LangVersion** | 13 |
| **Nullable** | enabled |
| **AllowUnsafeBlocks** | true |
| **Target Frameworks** | 15+ (netstandard2.0–net10.0, net461–net481) |

## Performance Features

1. **Archetype-based Storage**
   - Cache-efficient entity grouping
   - Contiguous memory for components
   - Fast component access

2. **Structural Queries**
   - Compile-time rule validation
   - Type-safe component filtering
   - Zero-allocation queries

3. **Deferred Structural Changes**
   - Prevents crashes during updates
   - Queues modifications
   - Applies after cycle completes

4. **Bulk Entity Creation**
   - Batch entity creation
   - Reduced overhead
   - Performance optimization

5. **Value-Type Entities**
   - 8-byte GameObject struct
   - No heap allocation
   - Fast comparisons

6. **Component Storage**
   - Fast lookup tables
   - Sparse sets for entity-component mapping
   - Chunk-based iteration

## Public APIs

### Scene Class
```csharp
public class Scene : IDisposable
{
    // Entity creation
    GameObject Create(params object[] components);
    GameObject Create(ComponentHandle[] handles);
    
    // Component operations
    void AddComponent(GameObject entity, ComponentHandle handle);
    void RemoveComponent<T>(GameObject entity);
    ref T Get<T>(GameObject entity);
    
    // Queries
    Query CreateQuery(Rule rule);
    Query CreateQuery<T1>() where T1 : unmanaged;
    Query CreateQuery<T1, T2>() where T1 : unmanaged where T2 : unmanaged;
    
    // Updates
    void Update<T>() where T : IComponentUpdateFilter;
    void Update<T>(UpdateType type) where T : IComponentUpdateFilter;
    
    // Lifecycle
    void Dispose();
}
```

### GameObject Struct
```csharp
public struct GameObject : IEquatable<GameObject>
{
    // Component access
    ref T Get<T>() where T : unmanaged;
    void Add<T>(in T component) where T : unmanaged;
    void Remove<T>() where T : unmanaged;
    
    // State
    bool IsAlive();
    ushort WorldID { get; }
    int EntityID { get; }
}
```

### Query System
```csharp
public class Query
{
    IEnumerable<GameObject> ToEnumerable();
    List<GameObject> ToList();
    void ForEach(Action<GameObject> action);
}

public static class Rule
{
    public static Query With<T>() where T : unmanaged;
    public static Query Not<T>() where T : unmanaged;
}
```

## Namespaces

| Namespace | Purpose |
|---|---|
| `Alis.Core.Ecs` | Core ECS types |
| `Alis.Core.Ecs.Kernel` | Kernel infrastructure |
| `Alis.Core.Ecs.Kernel.Archetypes` | Archetype management |
| `Alis.Core.Ecs.Kernel.Events` | Component events |
| `Alis.Core.Ecs.Collections` | High-performance collections |
| `Alis.Core.Ecs.Systems` | Query and system infrastructure |
| `Alis.Core.Ecs.Updating` | Update system |
| `Alis.Core.Ecs.Exceptions` | Error handling |
| `Alis.Core.Ecs.Marshalling` | Serialization |
| `Alis.Core.Ecs.Redifinition` - .NET API redefinitions |

## Data Access

### Component Storage
- **IDTable<T>** - Component ID lookup table
- **SparseSet** - Entity-component sparse set
- **FastestTable** - Fast component storage
- **Chunk** - Entity chunk storage

### Entity Lookup
- **FastLookup** - Component lookup optimization
- **ShortSparseSet** - Memory-efficient sparse set
- **FastestStack** - High-performance stack

## Messaging Usage

### Events
- `ComponentAddedEvent<ComponentId>` - Component addition
- `ComponentRemovedEvent<ComponentId>` - Component removal
- `GameObjectOnlyEvent` - Entity creation
- `Event<T>` - Generic event system

### Update Notifications
- `IComponentUpdateFilter<T>` - Update filtering
- `UpdateOrderAttribute` - Update ordering
- `UpdateTypeAttribute` - Update type specification

## DI Registrations

**Auto-Registration:**
- Component types auto-registered via source generator
- Update runners auto-discovered
- Archetype graph auto-managed

**Manual Registration:**
- Custom update runners implement `IComponentUpdateFilter<T>`
- Component lifecycle via `IOnDestroy`

## Configuration Usage

**Scene Configuration:**
```csharp
var scene = new Scene();

// Configure update order
[UpdateOrder(1)]
[UpdateType(UpdateType.Update)]
public struct TransformUpdate : IComponentUpdateFilter<Transform>
{
    // Update logic
}
```

## EF Core Usage

**None** - Pure ECS implementation, no ORM usage.

## Testing Status

| Test Type | Status |
|---|---|
| **Unit Tests** | Limited - needs expansion |
| **Integration Tests** | Game sample tests |
| **Performance Tests** | Benchmark suite |
| **Coverage** | Medium - core paths covered |

## Security-Sensitive Areas

1. **Unsafe Code**
   - `AllowUnsafeBlocks: true` for performance
   - Direct memory access via `MemoryMarshal`
   - Struct layout control via `StructLayout`

2. **Memory Management**
   - Manual memory pooling via `FastestArrayPool`
   - No garbage allocation in hot paths
   - `Gen2GcCallback` for large object heap management

3. **Type Safety**
   - Source generator validates component types
   - Compile-time rule checking
   - Runtime version checking for entities

## Performance-Sensitive Areas

1. **Entity Structure**
   - 8-byte value type (no allocation)
   - Pack=1 for tight memory layout
   - Version counter for safety

2. **Component Storage**
   - Archetype-based grouping
   - Chunk-based iteration
   - Sparse set lookups

3. **Query Performance**
   - Compile-time rule validation
   - Zero-allocation enumeration
   - Chunk-based bulk operations

4. **Update Cycle**
   - Deferred structural changes
   - Batch entity processing
   - Update ordering system

## Risks

1. **Memory Leaks**
   - Manual memory management requires care
   - Pool exhaustion possible under heavy load
   - `Dispose()` must be called on Scene

2. **Version Conflicts**
   - Entity version overflow possible (ushort)
   - Need to handle entity recycling carefully

3. **Thread Safety**
   - Scene not thread-safe
   - Requires external synchronization for multi-threaded access

4. **Stack Overflow**
   - Recursive entity operations limited to 200
   - Deep entity hierarchies may hit limit

5. **Source Generator Dependency**
   - Requires source generator to be working
   - Build errors if generator fails

## TODOs

- [ ] Expand unit test coverage
- [ ] Add multi-threading support
- [ ] Profile and optimize hot paths
- [ ] Add memory profiling tools
- [ ] Create visual debugging tools
- [ ] Document performance benchmarks
- [ ] Add serialization tests

## Complexity Observations

- **High**: Archetype graph management
- **Medium**: Query system compilation
- **Medium**: Update cycle orchestration
- **Low**: Basic entity operations

## Related

- [[4_Operation/Alis.Core.Graphic]] - Graphics system
- [[4_Operation/Alis.Core.Audio]] - Audio system
- [[4_Operation/Alis.Core.Physics]] - Physics system
- [[6_Ideation/Alis.Core.Game]] - Game logic
- [[context/data-oriented-design]] - DOD principles
- [[concepts/entity-component-system]] - ECS pattern

## See Also

- [[projects/4_Operation/Core]] - Core operations
- [[architecture/repository-overview]] - Repository architecture
- [[glossary/entity]] - Entity definition
- [[glossary/component]] - Component definition
- [[glossary/archetype]] - Archetype definition
