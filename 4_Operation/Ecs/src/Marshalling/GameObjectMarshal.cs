using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting scene state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class GameObjectMarshal
    {
        /// <summary>
        ///     Gets the <see cref="Scene" /> for an <see cref="GameObject" />. Does not check if the <see cref="GameObject" /> or
        ///     <see cref="Scene" /> is alive.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject" /> to get the <see cref="Scene" /> for.</param>
        /// <returns>The <see cref="Scene" /> the <paramref name="gameObject" /> belongs to, if it still exists.</returns>
        public static Scene GetWorld(GameObject gameObject)
        {
            return GlobalWorldTables.Worlds.UnsafeIndexNoResize(gameObject.EntityID);
        }

        /// <summary>
        ///     Gets the raw entityID from an <see cref="GameObject" />
        /// </summary>
        /// <returns>The integer entityID</returns>
        public static int EntityId(GameObject gameObject)
        {
            return gameObject.EntityID;
        }
    }
}