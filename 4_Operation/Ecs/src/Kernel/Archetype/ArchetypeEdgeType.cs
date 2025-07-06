namespace Alis.Core.Ecs.Kernel.Archetype
{
    /// <summary>
    ///     The archetype edge type enum
    /// </summary>
    public enum ArchetypeEdgeType : ushort
    {
        /// <summary>
        ///     The add component archetype edge type
        /// </summary>
        AddComponent = 49157,

        /// <summary>
        ///     The remove component archetype edge type
        /// </summary>
        RemoveComponent = 24593,

        /// <summary>
        ///     The add tag archetype edge type
        /// </summary>
        AddTag = 12289,

        /// <summary>
        ///     The remove tag archetype edge type
        /// </summary>
        RemoveTag = 6151
    }
}