

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Output results from a ray cast operation against the physics world.
    /// </summary>
    /// <remarks>
    ///     Contains the intersection fraction and surface normal when a ray hits a shape.
    ///     The intersection point can be computed as: Point1 + Fraction * (Point2 - Point1).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RayCastOutput
    {
        /// <summary>
        ///     Gets or sets the fraction along the ray where the intersection occurs.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> between 0.0 and 1.0 (or beyond) representing the parametric
        ///     position of the intersection point along the ray.
        /// </value>
        /// <remarks>
        ///     The actual intersection point is computed as: Point1 + Fraction * (Point2 - Point1),
        ///     where Point1 and Point2 come from the corresponding <see cref="RayCastInput"/>.
        /// </remarks>
        public float Fraction;

        /// <summary>
        ///     Gets or sets the normal of the face that the ray hit.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the outward-facing normal of the hit surface,
        ///     expressed in world coordinates.
        /// </value>
        /// <remarks>
        ///     The normal points away from the hit shape's surface. For ray casting, this indicates
        ///     the direction perpendicular to the surface at the intersection point.
        /// </remarks>
        public Vector2F Normal;
    }
}