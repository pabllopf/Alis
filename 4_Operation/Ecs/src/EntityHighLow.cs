

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Represents an entity identifier split into high and low integer components.
    /// </summary>
    /// <remarks>
    ///     This struct is used internally for efficient entity ID storage and comparison.
    ///     Memory layout optimized: 8 bytes total (two ints, 4 bytes each).
    ///     Pack = 1 for minimal memory footprint, naturally aligned.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityHighLow
    {
        /// <summary>
        ///     The high part of the entity identifier, typically containing the entity index or ID.
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The low part of the entity identifier, typically containing a version or secondary index.
        /// </summary>
        internal int EntityLow;
    }
}