# Queries Index

## ECS Query System

### Rule-Based Queries

```csharp
// Query entities with Transform and Position components
var query = scene.CreateQuery(Rule.With<Transform>().And<Position>());

// Query entities with Transform, excluding Physics components
var query = scene.CreateQuery(Rule.With<Transform>().Without<Physics>());

// Query entities with any of multiple components
var query = scene.CreateQuery(Rule.AnyOf<Lightweight, FastMoving>());
```

### Query Results

- **Query<TComponent>**: Typed query results
- **QueryEnumerable<T>**: LINQ-compatible query results
- **Chunk-based iteration**: Cache-friendly entity processing

### Performance Characteristics

- O(1) query creation
- O(n) query execution (n = matching entities)
- Chunk-based iteration for cache efficiency
