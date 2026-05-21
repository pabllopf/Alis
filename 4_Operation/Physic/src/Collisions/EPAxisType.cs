

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies which shape's edge defines the separating axis in EPA.
    /// </summary>
    public enum EpAxisType
    {
        /// <summary>
        ///     The separating axis type is unknown or uninitialized.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The separating axis is defined by an edge on shape A.
        /// </summary>
        EdgeA,

        /// <summary>
        ///     The separating axis is defined by an edge on shape B.
        /// </summary>
        EdgeB
    }
}