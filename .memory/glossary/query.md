# Query

## Definition

A **Query** is an entity filtering mechanism that selects entities matching specific component presence/absence rules. Queries enable efficient iteration over entities with desired component combinations.

## Core Concept

### Rule-Based Filtering

Queries use rules to specify component requirements:

```csharp
// Entities with Transform AND Health
var query = scene.CreateQuery(
    Rule.With<Transform>().And<Health>());

// Entities with Transform OR Health  
var query = scene.CreateQuery(
    Rule.With<Transform>().Or<Health>());

// Entities with Transform WITHOUT Health
var query = scene.CreateQuery(
    Rule.With<Transform>().Without<Health>());
```

### Query Execution

```csharp
var query = scene.CreateQuery(Rule.With<Transform>().And<Health>());

foreach (ref var entity in query)
{
    ref var transform = ref entity.Get<Transform>();
    ref var health = ref entity.Get<Health>();
    
    // Process entity
}
```

## Query Types

### CustomQuery

User-defined rule combinations:

```csharp
var query = scene.CustomQuery(
    Rule.With<Transform>(),
    Rule.With<Health>().Without<Velocity>());
```

### QueryHash

Query identification via hash:

- Rules combined into hash code
- Cached query results by hash
- Fast lookup for repeated queries

```csharp
QueryHash queryHash = QueryHash.New();
foreach (Rule rule in rules)
{
    queryHash.AddRule(rule);
}

int hashCode = queryHash.ToHashCode();
```

### QueryEnumerable

Entity enumeration:

```csharp
public class QueryEnumerable : IEnumerable<GameObject>
{
    public Enumerator GetEnumerator();
}

public struct Enumerator : IEnumerator<GameObject>
{
    public GameObject Current { get; }
    public bool MoveNext();
}
```

## Query Performance

| Operation | Complexity |
|-----------|------------|
| **Query Creation** | O(n) where n = rules count |
| **Entity Iteration** | O(m) where m = matching entities |
| **Component Access** | O(1) via archetype lookup |
| **Cache Hit** | O(1) for cached queries |

## Query Caching

Queries cached by hash:

```csharp
public Dictionary<int, Query> QueryCache = [];

// Reuse cached query
if (!QueryCache.TryGetValue(hashCode, out Query query))
{
    QueryCache[hashCode] = query = CreateQueryFromSpan(rules);
}
```

## Archetype Attachment

Queries automatically attach to archetypes:

```csharp
public void TryAttachArchetype(Archetype archetype)
{
    if (archetype.Types.ContainsAll(Rules))
    {
        // Add archetype entities to query
    }
}
```

## Query Results

### Single Entity

```csharp
GameObject? entity = query.FirstOrDefault();
```

### Entity Collection

```csharp
List<GameObject> entities = query.ToList();
```

### Chunked Results

```csharp
ChunkTuple<Transform, Health> chunks = query.ToChunks();
```

## Related

- [[Rule]] - Component presence constraint
- [[Archetype]] - Component type optimization
- [[Scene]] - World container
- [[GameObject]] - Entity handle
