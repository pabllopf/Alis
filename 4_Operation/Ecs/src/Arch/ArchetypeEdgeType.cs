namespace Alis.Core.Ecs.Arch
{
    /// <summary>
    ///     The archetype edge type enum
    /// </summary>
    internal enum ArchetypeEdgeType : ushort
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