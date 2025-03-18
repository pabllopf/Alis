using System;
using Frent.Core;
using Frent.Updating.Runners;

namespace Frent.Marshalling;

/// <summary>
/// Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can result in corrupting world state and segfaults.
/// </summary>
/// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
public static class WorldMarshal
{
    /// <summary>
    /// Gets the component using the specified world
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="world">The world</param>
    /// <param name="entity">The entity</param>
    /// <returns>The ref</returns>
    public static ref T GetComponent<T>(World world, Entity entity)
    {
        EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entity.EntityID);
        return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(location.Archetype.Components.UnsafeArrayIndex(location.Archetype.GetComponentIndex<T>()))[location.Index];
    }

    /// <summary>
    /// Gets the raw buffer using the specified world
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="world">The world</param>
    /// <param name="entity">The entity</param>
    /// <returns>A span of t</returns>
    public static Span<T> GetRawBuffer<T>(World world, Entity entity)
    {
        EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entity.EntityID);
        return UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(location.Archetype.Components.UnsafeArrayIndex(location.Archetype.GetComponentIndex<T>())).AsSpan();
    }

    /// <summary>
    /// Gets the world
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="world">The world</param>
    /// <param name="entityID">The entity id</param>
    /// <returns>The ref</returns>
    public static ref T Get<T>(World world, int entityID)
    {

        EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entityID);

        Archetype archetype = location.Archetype;

        int compIndex = archetype.GetComponentIndex<T>();

        //Components[0] null; trap
        ComponentStorage<T> storage = UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(archetype.Components.UnsafeArrayIndex(compIndex));
        return ref storage[location.Index];
    }
}
