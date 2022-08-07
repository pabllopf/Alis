// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.CollideEdge.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions.Shapes;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     The collision class
    /// </summary>
    public static partial class Collision
    {
        // This implements 2-sided edge vs circle collision.
        /// <summary>
        ///     Collides the edge and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edge">The edge</param>
        /// <param name="transformA">The transform</param>
        /// <param name="circle">The circle</param>
        /// <param name="transformB">The transform</param>
        public static void CollideEdgeAndCircle(ref Manifold manifold, EdgeShape edge, XForm transformA,
            CircleShape circle, XForm transformB)
        {
            manifold.PointCount = 0;
            Vector2 cLocal = Math.MulT(transformA, Math.Mul(transformB, circle.Position));
            Vector2 normal = edge.NormalVector;
            Vector2 v1 = edge.Vertex1;
            Vector2 v2 = edge.Vertex2;
            float radius = edge.Radius + circle.Radius;

            // Barycentric coordinates
            float u1 = Vector2.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2.Dot(cLocal - v2, v1 - v2);

            if (u1 <= 0.0f)
            {
                // Behind v1
                if (Vector2.DistanceSquared(cLocal, v1) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v1;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v1;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else if (u2 <= 0.0f)
            {
                // Ahead of v2
                if (Vector2.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v2;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v2;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else
            {
                float separation = Vector2.Dot(cLocal - v1, normal);
                if (separation < -radius || radius < separation)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = separation < 0.0f ? -normal : normal;
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
        }

        // Polygon versus 2-sided edge.
        /// <summary>
        ///     Collides the poly and edge using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polygon">The polygon</param>
        /// <param name="transformA">The transform</param>
        /// <param name="edge">The edge</param>
        /// <param name="transformB">The transform</param>
        public static void CollidePolyAndEdge(ref Manifold manifold, PolygonShape polygon, XForm transformA,
            EdgeShape edge, XForm transformB)
        {
            PolygonShape polygonB = new PolygonShape();
            polygonB.SetAsEdge(edge.Vertex1, edge.Vertex2);

            CollidePolygons(ref manifold, polygon, transformA, polygonB, transformB);
        }
    }
}