using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// A manifold point is a contact point belonging to a contact
    /// manifold. It holds details related to the geometry and dynamics
    /// of the contact points.
    /// The local point usage depends on the manifold type:
    /// -Circles: the local center of circleB
    /// -FaceA: the local center of cirlceB or the clip point of polygonB
    /// -FaceB: the clip point of polygonA
    /// This structure is stored across time steps, so we keep it small.
    /// Note: the impulses are used for internal caching and may not
    /// provide reliable contact forces, especially for high speed collisions.
    /// </summary>
    public class ManifoldPoint
    {
        /// <summary>
        /// Usage depends on manifold type.
        /// </summary>
        public Vec2 LocalPoint;

        /// <summary>
        /// The non-penetration impulse.
        /// </summary>
        public float NormalImpulse;

        /// <summary>
        /// The friction impulse.
        /// </summary>
        public float TangentImpulse;

        /// <summary>
        /// Uniquely identifies a contact point between two shapes.
        /// </summary>
        public ContactID ID;

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The new point</returns>
        public ManifoldPoint Clone()
        {
            ManifoldPoint newPoint = new ManifoldPoint();
            newPoint.LocalPoint = LocalPoint;
            newPoint.NormalImpulse = NormalImpulse;
            newPoint.TangentImpulse = TangentImpulse;
            newPoint.ID = ID;
            return newPoint;
        }
    }
}