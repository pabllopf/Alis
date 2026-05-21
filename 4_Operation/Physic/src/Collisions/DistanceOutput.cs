

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Output results from the GJK distance computation between two convex shapes.
    /// </summary>
    /// <remarks>
    ///     Contains the minimum distance between shapes, the number of iterations required,
    ///     and the two witness points that represent the closest points on each shape.
    ///     When shapes overlap, the distance may be zero or negative depending on configuration.
    /// </remarks>
    public struct DistanceOutput
    {
        /// <summary>
        ///     Gets or sets the minimum distance between the two shapes.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the distance. Zero or negative indicates overlap.
        /// </value>
        /// <remarks>
        ///     When <see cref="DistanceInput.UseRadii"/> is <c>true</c>, this value has been adjusted
        ///     by subtracting the sum of both shape radii.
        /// </remarks>
        public float Distance;

        /// <summary>
        ///     Gets or sets the number of GJK iterations performed during distance computation.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the iteration count. Lower values indicate faster convergence.
        /// </value>
        /// <remarks>
        ///     Typical values range from 1 to 7 iterations for well-conditioned shapes.
        ///     Higher values may indicate near-tangent or degenerate shape configurations.
        /// </remarks>
        public int Iterations;

        /// <summary>
        ///     Gets or sets the closest point on the first shape (ShapeA).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> in world coordinates representing the closest point on ShapeA.
        /// </value>
        /// <remarks>
        ///     When <see cref="DistanceInput.UseRadii"/> is <c>true</c>, this point lies on the outer surface
        ///     of ShapeA including its radius offset.
        /// </remarks>
        public Vector2F PointA;

        /// <summary>
        ///     Gets or sets the closest point on the second shape (ShapeB).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> in world coordinates representing the closest point on ShapeB.
        /// </value>
        /// <remarks>
        ///     When <see cref="DistanceInput.UseRadii"/> is <c>true</c>, this point lies on the outer surface
        ///     of ShapeB including its radius offset.
        /// </remarks>
        public Vector2F PointB;
    }
}