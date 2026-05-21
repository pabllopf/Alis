

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Tracks the best separating axis found during the EPA (Expanding Polytope Algorithm) process.
    /// </summary>
    /// <remarks>
    ///     Used by the EPA algorithm to identify the face with the greatest penetration depth
    ///     when GJK determines that two convex shapes are overlapping. This axis becomes the
    ///     contact normal for the collision manifold.
    /// </remarks>
    public struct EpAxis
    {
        /// <summary>
        ///     Gets or sets the index of the vertex or edge associated with this separating axis.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the vertex/edge index in the polytope.
        /// </value>
        public int Index;

        /// <summary>
        ///     Gets or sets the separation distance along this axis.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the penetration depth. Negative values indicate overlap.
        /// </value>
        /// <remarks>
        ///     The axis with the most negative (deepest) separation is selected as the contact normal.
        /// </remarks>
        public float Separation;

        /// <summary>
        ///     Gets or sets the type of this separating axis.
        /// </summary>
        /// <value>
        ///     A <see cref="EpAxisType"/> indicating whether the axis belongs to shape A or shape B.
        /// </value>
        public EpAxisType Type;
    }
}