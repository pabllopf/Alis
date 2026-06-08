# GameObject

## Definition

A **GameObject** is a lightweight 8-byte struct that serves as an entity handle in the ECS architecture. It's NOT a game object with embedded logic—it's simply an identifier for accessing components attached to an entity.

## Structure

```csharp
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GameObject : IEquatable<GameObject>
{
    internal int EntityID;        // 4 bytes - unique entity identifier
    internal ushort EntityVersion; // 2 bytes - version for safe deletion handling
    internal ushort WorldID;       // 2 bytes - scene/world identifier
    
    // Total: 8 bytes, no padding
}
```

## Key Features

### Versioning

The **EntityVersion** field enables safe handling of recycled entity IDs:

- When an entity is deleted, its ID may be reused
- The version increments each time the entity is recreated
- Stale references detect version mismatch and throw `InvalidOperationException`

### Safety Checks

```csharp
// Check if entity is still alive
if (player.IsAlive(out Scene scene, out GameObjectLocation location))
{
    // Safe to access components
}

// Throws if entity is deleted
ref var transform = ref player.Get<Transform>();
```

### Component Access

```csharp
// Try get (safe, returns default if not present)
Ref<Transform> transformRef = player.TryGetCore<Transform>(out bool exists);

// Get (throws if component doesn't exist)
ref Transform t = ref player.Get<Transform>();

// Add component
player.Add(new Velocity { X = 5, Y = 10 });

// Remove component
player.Remove<Transform>();
```

## Lifecycle

1. **Creation**: `scene.Create(new Transform(), new Health())`
2. **Access**: Use [[GameObject]] methods to interact with components
3. **Deletion**: `scene.Destroy(player)` - ID recycled, version incremented
4. **Stale Detection**: Accessing deleted entity throws exception

## Performance Characteristics

- **Size**: 8 bytes (packed struct)
- **Equality**: Value-based comparison via `PackedValue`
- **Hash**: Based on packed representation
- **Access**: Zero-copy via `Ref<T>` wrapper

## Related

- [[Scene]] - World container
- [[Component Storage]] - Typed component data
- [[Archetype]] - Component type optimization
- [[GameObjectFlags]] - Entity state flags
