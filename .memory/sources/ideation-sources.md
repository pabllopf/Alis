# Ideation Sources

Experimental aspects in `6_Ideation/`.

## Aspect Projects

| Aspect | Files | Generator | Purpose |
|--------|-------|-----------|---------|
| **Memory** | 50+ | Yes | Memory abstractions, resource management |
| **Fluent** | 40+ | Yes | Fluent APIs, builder patterns |
| **Data** | 45+ | Yes | Data structures, collections |
| **Math** | 30+ | No | Mathematical utilities, algorithms |
| **Time** | 25+ | No | Time management, scheduling |
| **Logging** | 35+ | No | Logging infrastructure, diagnostics |

## Memory Source Files

| File | Purpose |
|------|---------|
| `Memory/src/Resource.cs` | Resource abstraction |
| `Memory/src/ResourceLoader.cs` | Resource loading logic |
| `Memory/src/CacheEntry.cs` | Cache entry management |
| `Memory/generator/ResourceAccessorGenerator.cs` | Resource accessor code generation |

### Key Classes
- **Resource<T>** - Generic resource wrapper
- **ResourceLoader** - Async resource loading
- **CacheEntry<T>** - Cached resource with expiry
- **ZipCacheEntry** - Compressed cache entries

## Fluent Source Files

| File | Purpose |
|------|---------|
| `Fluent/src/IFluent.cs` | Fluent interface marker |
| `Fluent/src/Builder.cs` | Builder pattern base |
| `Fluent/generator/FluentGenerator.cs` | Fluent API code generation |

### Usage Pattern
```csharp
public class QueryBuilder : IQueryBuilder
{
    public QueryBuilder Where<T>(Expression<Func<T, bool>> predicate)
    {
        // Fluent chaining
        return this;
    }
    
    public QueryBuilder OrderBy<T>(Expression<Func<T, string>> selector)
    {
        return this;
    }
}
```

## Data Source Files

| File | Purpose |
|------|---------|
| `Data/src/Collection.cs` | Collection abstractions |
| `Data/src/Dictionary.cs` | Dictionary implementations |
| `Data/generator/DataGenerator.cs` | Data structure generation |

## Math Source Files

| File | Purpose |
|------|---------|
| `Math/src/Vector2.cs` | 2D vector operations |
| `Math/src/Vector3.cs` | 3D vector operations |
| `Math/src/Matrix.cs` | Matrix transformations |
| `Math/src/Random.cs` | Procedural generation utilities |

## Time Source Files

| File | Purpose |
|------|---------|
| `Time/src/Timer.cs` | Timer abstractions |
| `Time/src/Scheduler.cs` | Task scheduling |
| `Time/src/Interval.cs` | Time interval management |

## Logging Source Files

| File | Purpose |
|------|---------|
| `Logging/src/ILogger.cs` | Logging interface |
| `Logging/src/Logger.cs` | Default logger implementation |
| `Logging/src/LogEntry.cs` | Log entry structure |

## See Also
- [[Aspect-Oriented Design]]
- [[Generator Pattern]]
- [[Layered Architecture]]
