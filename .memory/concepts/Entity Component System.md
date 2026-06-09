# Entity Component System (ECS)

Alis implements an ECS architecture for game logic with source code generation.

## ECS Architecture

### Core Concepts
- **Entities**: Unique identifiers for game objects
- **Components**: Data-only structs attached to entities
- **Systems**: Logic processors that operate on component groups

### Generator Pattern

`Alis.Core.Ecs.Generator` produces:
- Component registration code
- System iteration logic
- Entity management helpers

## Benefits

1. **Performance**: Cache-friendly data layout
2. **Scalability**: Handle thousands of entities efficiently
3. **Determinism**: Predictable execution order
4. **Testability**: Isolated system logic

## Usage Pattern

```csharp
// Define component (data-only struct)
public struct Position : IComponent { }

// Define system (logic processor)
public class MovementSystem : ISystem
{
    public void Update(float deltaTime) { /* ... */ }
}

// Register in generator
[GenerateComponent(typeof(Position))]
[GenerateSystem(typeof(MovementSystem))]
public class GameModule { }
```

## See Also
- [[Generator Pattern]]
- [[Layered Architecture]]
