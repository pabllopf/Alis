using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// A manifold for two touching convex shapes.
    /// </summary>
    public class Manifold
    {
        /// <summary>
        /// The points of contact.
        /// </summary>
        public ManifoldPoint[/*Settings.MaxManifoldPoints*/] Points = new ManifoldPoint[Settings.MaxManifoldPoints];

        /// <summary>
        /// The local plane normal
        /// </summary>
        public Vec2 LocalPlaneNormal;

        /// <summary>
        /// Usage depends on manifold type.
        /// </summary>
        public Vec2 LocalPoint;

        /// <summary>
        /// The type
        /// </summary>
        public ManifoldType Type;

        /// <summary>
        /// The number of manifold points.
        /// </summary>
        public int PointCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manifold"/> class
        /// </summary>
        public Manifold()
        {
            for (int i = 0; i < Settings.MaxManifoldPoints; i++)
                Points[i] = new ManifoldPoint();
        }

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The new manifold</returns>
        public Manifold Clone()
        {
            Manifold newManifold = new Manifold();
            newManifold.LocalPlaneNormal = LocalPlaneNormal;
            newManifold.LocalPoint = LocalPoint;
            newManifold.Type = Type;
            newManifold.PointCount = PointCount;
            int pointCount = Points.Length;
            ManifoldPoint[] tmp = new ManifoldPoint[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                tmp[i] = Points[i].Clone();
            }
            newManifold.Points = tmp;
            return newManifold;
        }
    }
}