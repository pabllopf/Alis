using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// Output for Distance.
    /// </summary>
    public struct DistanceOutput
    {
        /// <summary>
        /// Closest point on shapeA.
        /// </summary>
        public Vec2 PointA;
        /// <summary>
        /// Closest point on shapeB.
        /// </summary>
        public Vec2 PointB;
        /// <summary>
        /// The distance
        /// </summary>
        public float Distance;
        /// <summary>
        /// Number of GJK iterations used.
        /// </summary>
        public int Iterations;
    }
}