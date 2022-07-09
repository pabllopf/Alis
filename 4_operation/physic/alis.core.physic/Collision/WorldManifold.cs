using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// This is used to compute the current state of a contact manifold.
    /// </summary>
    public class WorldManifold
    {
        /// <summary>
        /// World vector pointing from A to B.
        /// </summary>
        public Vec2 Normal;
        /// <summary>
        /// World contact point (point of intersection).
        /// </summary>
        public Vec2[] Points = new Vec2[Settings.MaxManifoldPoints];

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The new manifold</returns>
        public WorldManifold Clone()
        {
            WorldManifold newManifold = new WorldManifold();
            newManifold.Normal = Normal;
            Points.CopyTo(newManifold.Points, 0);
            return newManifold;
        }

        /// Evaluate the manifold with supplied transforms. This assumes
        /// modest motion from the original state. This does not change the
        /// point count, impulses, etc. The radii must come from the shapes
        /// that generated the manifold.
        public void Initialize(Manifold manifold, XForm xfA, float radiusA, XForm xfB, float radiusB)
        {
            if (manifold.PointCount == 0)
            {
                return;
            }

            switch (manifold.Type)
            {
                case ManifoldType.Circles:
                {
                    Vec2 pointA = Common.Math.Mul(xfA, manifold.LocalPoint);
                    Vec2 pointB = Common.Math.Mul(xfB, manifold.Points[0].LocalPoint);
                    Vec2 normal = new Vec2(1.0f, 0.0f);
                    if (Vec2.DistanceSquared(pointA, pointB) > Settings.FLT_EPSILON_SQUARED)
                    {
                        normal = pointB - pointA;
                        normal.Normalize();
                    }

                    Normal = normal;

                    Vec2 cA = pointA + radiusA * normal;
                    Vec2 cB = pointB - radiusB * normal;
                    Points[0] = 0.5f * (cA + cB);
                }
                    break;

                case ManifoldType.FaceA:
                {
                    Vec2 normal = Common.Math.Mul(xfA.R, manifold.LocalPlaneNormal);
                    Vec2 planePoint = Common.Math.Mul(xfA, manifold.LocalPoint);

                    // Ensure normal points from A to B.
                    Normal = normal;

                    for (int i = 0; i < manifold.PointCount; ++i)
                    {
                        Vec2 clipPoint = Common.Math.Mul(xfB, manifold.Points[i].LocalPoint);
                        Vec2 cA = clipPoint + (radiusA - Vec2.Dot(clipPoint - planePoint, normal)) * normal;
                        Vec2 cB = clipPoint - radiusB * normal;
                        Points[i] = 0.5f * (cA + cB);
                    }
                }
                    break;

                case ManifoldType.FaceB:
                {
                    Vec2 normal = Common.Math.Mul(xfB.R, manifold.LocalPlaneNormal);
                    Vec2 planePoint = Common.Math.Mul(xfB, manifold.LocalPoint);

                    // Ensure normal points from A to B.
                    Normal = -normal;

                    for (int i = 0; i < manifold.PointCount; ++i)
                    {
                        Vec2 clipPoint = Common.Math.Mul(xfA, manifold.Points[i].LocalPoint);
                        Vec2 cA = clipPoint - radiusA * normal;
                        Vec2 cB = clipPoint + (radiusB - Vec2.Dot(clipPoint - planePoint, normal)) * normal;
                        Points[i] = 0.5f * (cA + cB);
                    }
                }
                    break;
            }
        }
    }
}