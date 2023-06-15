// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldManifold.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared.Optimization;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.Narrowphase
{
    /// <summary>
    ///     The world manifold class
    /// </summary>
    public static class WorldManifold
    {
        /// <summary>
        ///     Evaluate the manifold with supplied transforms. This assumes modest motion from the original state. This does
        ///     not change the point count, impulses, etc. The radii must come from the Shapes that generated the manifold.
        /// </summary>
        public static void Initialize(ref Manifold manifold, ref Transform xfA, float radiusA, ref Transform xfB,
            float radiusB, out Vector2 normal, out FixedArray2<Vector2> points, out FixedArray2<float> separations)
        {
            normal = Vector2.Zero;
            points = new FixedArray2<Vector2>();
            separations = new FixedArray2<float>();

            if (manifold.PointCount == 0)
            {
                return;
            }

            switch (manifold.Type)
            {
                case ManifoldType.Circles:
                {
                    normal = new Vector2(1.0f, 0.0f);
                    Vector2 pointA = MathUtils.Mul(ref xfA, manifold.LocalPoint);
                    Vector2 pointB = MathUtils.Mul(ref xfB, manifold.Points.Value0.LocalPoint);
                    if (Vector2.DistanceSquared(pointA, pointB) > Constant.Epsilon * Constant.Epsilon)
                    {
                        normal = pointB - pointA;
                        normal = Vector2.Normalize(normal);
                    }

                    Vector2 cA = pointA + radiusA * normal;
                    Vector2 cB = pointB - radiusB * normal;
                    points.Value0 = 0.5f * (cA + cB);
                    separations.Value0 = Vector2.Dot(cB - cA, normal);
                }
                    break;

                case ManifoldType.FaceA:
                {
                    normal = MathUtils.Mul(xfA.Rotation, manifold.LocalNormal);
                    Vector2 planePoint = MathUtils.Mul(ref xfA, manifold.LocalPoint);

                    for (int i = 0; i < manifold.PointCount; ++i)
                    {
                        Vector2 clipPoint = MathUtils.Mul(ref xfB, manifold.Points[i].LocalPoint);
                        Vector2 cA = clipPoint + (radiusA - Vector2.Dot(clipPoint - planePoint, normal)) * normal;
                        Vector2 cB = clipPoint - radiusB * normal;
                        points[i] = 0.5f * (cA + cB);
                        separations[i] = Vector2.Dot(cB - cA, normal);
                    }
                }
                    break;

                case ManifoldType.FaceB:
                {
                    normal = MathUtils.Mul(xfB.Rotation, manifold.LocalNormal);
                    Vector2 planePoint = MathUtils.Mul(ref xfB, manifold.LocalPoint);

                    for (int i = 0; i < manifold.PointCount; ++i)
                    {
                        Vector2 clipPoint = MathUtils.Mul(ref xfA, manifold.Points[i].LocalPoint);
                        Vector2 cB = clipPoint + (radiusB - Vector2.Dot(clipPoint - planePoint, normal)) * normal;
                        Vector2 cA = clipPoint - radiusA * normal;
                        points[i] = 0.5f * (cA + cB);
                        separations[i] = Vector2.Dot(cA - cB, normal);
                    }

                    // Ensure normal points from A to B.
                    normal = -normal;
                }
                    break;
            }
        }
    }
}