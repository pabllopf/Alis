

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A compact struct representing the core identity data of an entity in the ECS system.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     This struct holds the fundamental identifying information for any entity: its unique
    ///     ID within a scene, a version counter for detecting stale references, and the scene
    ///     it belongs to.
    ///     </para>
    ///     <para>
    ///     Memory layout: 8 bytes total (int + ushort + ushort), packed with no padding
    ///     for optimal memory efficiency in bulk storage scenarios.
    ///     </para>
    ///     <para>
    ///     The version field enables safe entity ID recycling - when an entity is deleted,
    ///     its ID may be reassigned to a new entity with an incremented version, allowing
    ///     systems to detect and reject operations on invalidated references.
    ///     </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityData
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the entity within its scene.
        /// </summary>
        /// <value>
        ///     An integer that uniquely identifies this entity. This ID may be recycled
        ///     after the entity is deleted.
        /// </value>
        internal int EntityID;

        /// <summary>
        ///     Gets or sets the version number of this entity.
        /// </summary>
        /// <value>
        ///     A counter that increments each time the entity is created, allowing detection
        ///     of stale references to deleted entities.
        /// </value>
        internal ushort EntityVersion;

        /// <summary>
        ///     Gets or sets the identifier of the scene that owns this entity.
        /// </summary>
        /// <value>
        ///     The ID of the <see cref="Scene"/> that contains this entity.
        /// </value>
        internal ushort WorldID;
    }
}