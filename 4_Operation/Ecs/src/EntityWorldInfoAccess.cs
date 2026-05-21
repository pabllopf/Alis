

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A compact representation of an entity's identification and ownership information.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     This struct provides a memory-optimized view (8 bytes total) combining entity ID
    ///     and scene identifier for efficient lookup operations in the ECS architecture.
    ///     </para>
    ///     <para>
    ///     Memory layout: <c>GameObjectIdOnly</c> (6 bytes) + <c>WorldID</c> (2 bytes) = 8 bytes total.
    ///     Uses <c>Pack = 1</c> to eliminate padding and minimize memory footprint.
    ///     </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityWorldInfoAccess
    {
        /// <summary>
        ///     Gets or sets the combined entity ID and version.
        /// </summary>
        /// <value>
        ///     A <see cref="GameObjectIdOnly"/> containing the entity's unique identifier and
        ///     version counter for stale reference detection.
        /// </value>
        internal GameObjectIdOnly EntityIDOnly;

        /// <summary>
        ///     Gets or sets the identifier of the scene that owns this entity.
        /// </summary>
        /// <value>
        ///     The unique identifier of the <see cref="Scene"/> that contains the entity.
        /// </value>
        internal ushort WorldID;
    }
}