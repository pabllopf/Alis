using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Ray-cast output data.
    /// </summary>
    public struct RayCastOutput
    {
        /// <summary>
        ///     The ray hits at p1 + fraction * (p2 - p1), where p1 and p2 come from RayCastInput.
        ///     Contains the actual fraction of the ray where it has the intersection point.
        /// </summary>
        public float Fraction;

        /// <summary>
        ///     The normal of the face of the shape the ray has hit.
        /// </summary>
        public Vector2 Normal;
    }
}