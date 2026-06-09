# Rule

## Definition

**Rule** defines component requirements and constraints for entity processing, used by queries to filter entities and systems to determine which entities to process.

## Core Purpose

Rule enables:

- Component type requirement specification
- Entity filtering based on component presence
- Query optimization and validation

## Structure

```csharp
public struct Rule<T1, T2> where T1 : struct where T2 : struct
{
    public ComponentId[] RequiredComponents { get; }
    public ComponentId[] OptionalComponents { get; }
    
    public bool Matches(GameObjectType archetype);
    public Query<T1, T2> CreateQuery(Scene scene);
}

// Component requirement validation
public struct Rule<T1, T2, T3> where T1 : struct where T2 : struct where T3 : struct
{
    public FastestTable<T1> Table1 { get; }
    public FastestTable<T2> Table2 { get; }
    public FastestTable<T3> Table3 { get; }
}
```

## Usage in ECS

### Component Requirements

Define required component types:

```csharp
public struct Rule<T1, T2> where T1 : struct where T2 : struct
{
    public ComponentId[] RequiredComponents 
    { 
        get => new ComponentId[] 
        {
            ComponentId<T1>,
            ComponentId<T2>
        };
    }
    
    public bool Matches(GameObjectType archetype)
    {
        foreach (var compId in RequiredComponents)
        {
            if (!archetype.HasComponent(compId))
            {
                return false;
            }
        }
        
        return true;
    }
}

// Usage
Rule<Transform, Health> rule = new Rule<Transform, Health>();

if (rule.Matches(archetype.Type))
{
    // Archetype has both Transform and Health components
}
```

### Query Creation

Create query from rule:

```csharp
public Query<T1, T2> CreateQuery(Scene scene)
{
    return new Query<T1, T2>(scene);
}

// Usage
Rule<Transform, Velocity> rule = new Rule<Transform, Velocity>();
Query<Transform, Velocity> query = rule.CreateQuery(scene);

foreach (var entity in query.Entities)
{
    // Process entities with Transform and Velocity
}
```

### Optional Components

Define optional component requirements:

```csharp
public struct Rule<T1, T2, T3> where T1 : struct where T2 : struct where T3 : struct
{
    public ComponentId[] RequiredComponents 
    { 
        get => new ComponentId[] { ComponentId<T1> };
    }
    
    public ComponentId[] OptionalComponents 
    { 
        get => new ComponentId[] 
        {
            ComponentId<T2>,
            ComponentId<T3>
        };
    }
    
    public bool Matches(GameObjectType archetype)
    {
        // Check required components
        foreach (var compId in RequiredComponents)
        {
            if (!archetype.HasComponent(compId))
            {
                return false;
            }
        }
        
        // Optional components are not required for match
        return true;
    }
}

// Usage
Rule<Transform, Health, Render> rule = new Rule<Transform, Health, Render>();

// Matches archetypes with Transform only
// Also matches archetypes with Transform + Health
// Also matches archetypes with Transform + Health + Render
```

### Rule Validation

Validate archetype against rule:

```csharp
public bool Matches(GameObjectType archetype)
{
    foreach (var compId in RequiredComponents)
    {
        if (!archetype.HasComponent(compId))
        {
            return false;
        }
    }
    
    return true;
}

// Rule matching scenarios:
// - Archetype has all required components → Match
// - Archetype missing required component → No match
// - Archetype has optional components → Match (optional)
```

## Rule Types

### Strict Rule

Require all specified components:

```csharp
public struct StrictRule<T1, T2> where T1 : struct where T2 : struct
{
    public ComponentId[] RequiredComponents 
    { 
        get => new ComponentId[] 
        {
            ComponentId<T1>,
            ComponentId<T2>
        };
    }
}

// Must have both components to match
```

### Flexible Rule

Allow optional components:

```csharp
public struct FlexibleRule<T1, T2> where T1 : struct where T2 : struct
{
    public ComponentId[] RequiredComponents 
    { 
        get => new ComponentId[] { ComponentId<T1> };
    }
    
    public ComponentId[] OptionalComponents 
    { 
        get => new ComponentId[] { ComponentId<T2> };
    }
}

// Must have T1, T2 is optional
```

## Performance Characteristics

| Operation | Complexity |
|-----------|------------|
| **Rule Creation** | O(1) component ID array |
| **Match Check** | O(n) where n = required components |
| **Query Creation** | O(a) where a = archetype count |

## Related

- [[Query]] - Component-based entity filtering
- [[Archetype]] - Component type optimization
- [[System]] - Processing unit using rules
- [[Component]] - Data-only struct
- [[Scene]] - World container
- [[GameObject]] - Entity handle
- [[entity-component-system-ecs]] — ECS overview

## Related Architecture

- [[Alis.Core.Ecs]] — ECS project
- [[queries-index]] — Query index
- [[architecture-index]] — Patterns
