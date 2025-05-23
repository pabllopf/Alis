using System;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting scene state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class SceneMarshal
    {
        /// <summary>
        ///     Gets a component of an gameObject, without checking if the gameObject has the component or if the scene belongs to the
        ///     gameObject.
        /// </summary>
        /// <returns>A reference to the component in memory.</returns>
        public static ref T GetComponent<T>(Scene scene, GameObject gameObject)
        {
            return ref Get<T>(scene, gameObject.EntityID);
        }

        /// <summary>
        ///     Gets raw span over the entire buffer of a component type for an archetype.
        /// </summary>
        /// <typeparam name="T">The type of component to get.</typeparam>
        /// <param name="scene">The scene that the gameObject belongs to.</param>
        /// <param name="gameObject">The gameObject whose component buffer to get.</param>
        /// <param name="index">The index of the gameObject's component.</param>
        /// <returns>The entire sliced raw buffer. May be larger than the number of entities in an archetype.</returns>
        public static Span<T> GetRawBuffer<T>(Scene scene, GameObject gameObject, out int index)
        {
            GameObjectLocation location = scene.EntityTable.UnsafeIndexNoResize(gameObject.EntityID);
            index = location.Index;
            return UnsafeExtensions
                .UnsafeCast<ComponentStorage<T>>(
                    location.Archetype.Components.UnsafeArrayIndex(location.Archetype.GetComponentIndex<T>())).AsSpan();
        }

        /// <summary>
        ///     Gets a component of an gameObject from a raw entityID.
        /// </summary>
        /// <returns>A reference to the component in memory.</returns>
        public static ref T Get<T>(Scene scene, int entityId)
        {
            GameObjectLocation location = scene.EntityTable.UnsafeIndexNoResize(entityId);

            Archetype archetype = location.Archetype;

            int compIndex = archetype.GetComponentIndex<T>();

            //Components[0] null; trap
            ComponentStorage<T> storage =
                UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(archetype.Components.UnsafeArrayIndex(compIndex));
            return ref storage[location.Index];
        }
    }
}