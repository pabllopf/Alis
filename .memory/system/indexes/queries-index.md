# Queries Index — ALIS

tags:
  - index,catalog,reference

## ECS Query System

| Query | Purpose | Location |
|-------|---------|----------|
| SceneQuery | Filter entities by component rules | 4_Operation/Ecs/src/ |
| ComponentQuery | Query entities with specific components | 4_Operation/Ecs/src/ |
| ArchetypeQuery | Query by archetype type | 4_Operation/Ecs/src/ |

## Query Patterns

### Rule-Based Filtering
```csharp
// Example: Query entities with specific components
scene.Query<Position, Velocity>()
```

### Attribute-Based Updates
```csharp
// Update systems by attribute type
scene.UpdateSystemsByAttribute<UpdateAttribute>()
```

## Scene Operations

| Operation | Description |
|-----------|-------------|
| Entity creation | Create entities with typed components |
| Component add/remove | Add/remove components with event notifications |
| Query filtering | Custom queries using rule-based filtering |
| System updates | Update systems by attribute/component type |
| Structural changes | Deferred structural changes during update cycles |
| Bulk creation | Bulk entity creation for performance |

---

## Related Documentation

- [[system/indexes/handlers-index]] — Handler patterns
- [[system/indexes/events-index]] — Event catalog
- [[system/indexes/architecture-index]] — Architecture patterns
