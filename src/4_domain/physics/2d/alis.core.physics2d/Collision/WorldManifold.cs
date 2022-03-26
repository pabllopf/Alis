// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WorldManifold.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     This is used to compute the current state of a contact manifold.
    /// </summary>
    internal class WorldManifold
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        private readonly float[] separations = new float[Settings.MaxManifoldPoints];

        /// <summary>
        ///     World vector pointing from A to B.
        /// </summary>
        internal Vector2 normal;

        /// <summary>
        ///     World contact point (point of intersection).
        /// </summary>
        internal Vector2[] points = new Vector2[Settings.MaxManifoldPoints];

        /// Evaluate the manifold with supplied transforms. This assumes
        /// modest motion from the original state. This does not change the
        /// point count, impulses, etc. The radii must come from the shapes
        /// that generated the manifold.
        internal void Initialize(
            Manifold manifold,
            Transform xfA,
            float radiusA,
            Transform xfB,
            float radiusB)
        {
            if (manifold.pointCount == 0)
            {
                return;
            }

            switch (manifold.type)
            {
                case ManifoldType.Circles:
                {
                    normal = new Vector2(1.0f, 0.0f);
                    Vector2 pointA = Math.Mul(xfA, manifold.localPoint);
                    Vector2 pointB = Math.Mul(xfB, manifold.points[0].localPoint);
                    if (Vector2.DistanceSquared(pointA, pointB) > Settings.FLT_EPSILON_SQUARED)
                    {
                        normal = Vector2.Normalize(pointB - pointA);
                    }

                    Vector2 cA = pointA + radiusA * normal;
                    Vector2 cB = pointB - radiusB * normal;
                    points[0] = 0.5f * (cA + cB);
                    separations[0] = Vector2.Dot(cB - cA, normal);
                }
                    break;

                case ManifoldType.FaceA:
                {
                    normal = Vector2.Transform(manifold.localNormal, xfA.q); // Math.Mul(xfA.q, manifold.localNormal);
                    Vector2 planePoint = Math.Mul(xfA, manifold.localPoint);

                    for (int i = 0; i < manifold.pointCount; ++i)
                    {
                        Vector2 clipPoint = Math.Mul(xfB, manifold.points[i].localPoint);
                        Vector2 cA = clipPoint + (radiusA - Vector2.Dot(clipPoint - planePoint, normal)) * normal;
                        Vector2 cB = clipPoint - radiusB * normal;
                        points[i] = 0.5f * (cA + cB);
                        separations[i] = Vector2.Dot(cB - cA, normal);
                    }
                }
                    break;

                case ManifoldType.FaceB:
                {
                    normal = Vector2.Transform(manifold.localNormal, xfB.q); // Math.Mul(xfB.q, manifold.localNormal);
                    Vector2 planePoint = Math.Mul(xfB, manifold.localPoint);

                    for (int i = 0; i < manifold.pointCount; ++i)
                    {
                        Vector2 clipPoint = Math.Mul(xfA, manifold.points[i].localPoint);
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