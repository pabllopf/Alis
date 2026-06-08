# Rule

## Definition

A **Rule** is a component presence/absence constraint used in [[Query]] filtering. Rules specify which components an entity must have, must not have, or can optionally have to match a query.

## Rule Types

### With<T>

Requires component presence:

```csharp
Rule.With<Transform>()           // Entity must have Transform
Rule.With<Health>()              // Entity must have Health
```

### Without<T>

Requires component absence:

```csharp
Rule.Without<Velocity>()         // Entity must NOT have Velocity
Rule.Without<Dead>()             // Entity must NOT have Dead component
```

### Or<T>

Allows component presence (OR logic):

```csharp
Rule.With<Transform>().Or<Health>()  // Entity has Transform OR Health
```

## Rule Composition

### AND Logic (Default)

Multiple `With` rules imply AND:

```csharp
Rule.With<Transform>().And<Health>()
// Entity must have BOTH Transform AND Health
```

### OR Logic

Use `Or` for alternative components:

```csharp
Rule.With<Transform>().Or<Health>()
// Entity has Transform OR Health (or both)
```

### Mixed Logic

Combine rules for complex queries:

```csharp
var query = scene.CreateQuery(
    Rule.With<Transform>(),
    Rule.Without<Dead>(),
    Rule.With<Health>().Without<Velocity>());

// Entity must have: Transform AND Health
// Entity must NOT have: Dead OR Velocity
```

## Rule Implementation

### Rule Class

```csharp
public class Rule
{
    public ComponentId? ComponentId { get; }
    public bool MustHave { get; }
    public bool MustNotHave { get; }
    
    public static Rule With<T>() where T : struct;
    public static Rule Without<T>() where T : struct;
}
```

### Rule Hashing

Rules combined into query hash:

```csharp
QueryHash queryHash = QueryHash.New();
foreach (Rule rule in rules)
{
    queryHash.AddRule(rule);
}

int hashCode = queryHash.ToHashCode();
```

## Rule Validation

### Component Type Check

Rules validated at compile-time:

```csharp
// Valid
Rule.With<Transform>()

// Invalid - compilation error if T is not struct
Rule.With<string>()  // Error: T must be struct
```

### Archetype Matching

Rules checked against archetype types:

```csharp
public bool Matches(Archetype archetype)
{
    foreach (var rule in Rules)
    {
        if (rule.MustHave && !archetype.Types.Contains(rule.ComponentId))
            return false;
            
        if (rule.MustNotHave && archetype.Types.Contains(rule.ComponentId))
            return false;
    }
    
    return true;
}
```

## Performance

| Operation | Complexity |
|-----------|------------|
| **Rule Creation** | O(1) |
| **Rule Hashing** | O(n) where n = rules count |
| **Archetype Matching** | O(m) where m = archetype types |
| **Query Execution** | O(k) where k = matching entities |

## Related

- [[Query]] - Entity filtering
- [[Archetype]] - Component type optimization
- [[Scene]] - World container
