using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Output for Distance.ComputeDistance().
    /// </summary>
    public struct DistanceOutput
    {
        /// <summary>
        /// The distance
        /// </summary>
        public float Distance;

        /// <summary>
        ///     Number of GJK iterations used
        /// </summary>
        public int Iterations;

        /// <summary>
        ///     Closest point on shapeA
        /// </summary>
        public Vector2 PointA;

        /// <summary>
        ///     Closest point on shapeB
        /// </summary>
        public Vector2 PointB;
    }
}