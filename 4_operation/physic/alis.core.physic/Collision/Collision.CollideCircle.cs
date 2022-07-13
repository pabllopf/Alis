// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.CollideCircle.cs
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
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The collision class
    /// </summary>
    public static partial class Collision
    {
        /// <summary>
        ///     Collides the circles using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="circle1">The circle</param>
        /// <param name="xf1">The xf</param>
        /// <param name="circle2">The circle</param>
        /// <param name="xf2">The xf</param>
        public static void CollideCircles(ref Manifold manifold,
            CircleShape circle1, XForm xf1, CircleShape circle2, XForm xf2)
        {
            manifold.PointCount = 0;

            Vector2 p1 = Math.Mul(xf1, circle1.Position);
            Vector2 p2 = Math.Mul(xf2, circle2.Position);

            Vector2 d = p2 - p1;
            float distSqr = Vector2.Dot(d, d);
            float radius = circle1.Radius + circle2.Radius;
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.Type = ManifoldType.Circles;
            manifold.LocalPoint = circle1.Position;
            manifold.LocalPlaneNormal.SetZero();
            manifold.PointCount = 1;

            manifold.Points[0].LocalPoint = circle2.Position;
            manifold.Points[0].Id.Key = 0;
        }

        /// <summary>
        ///     Collides the polygon and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polygon">The polygon</param>
        /// <param name="xf1">The xf</param>
        /// <param name="circle">The circle</param>
        /// <param name="xf2">The xf</param>
        public static void CollidePolygonAndCircle(ref Manifold manifold,
            PolygonShape polygon, XForm xf1, CircleShape circle, XForm xf2)
        {
            manifold.PointCount = 0;

            // Compute circle position in the frame of the polygon.
            Vector2 c = Math.Mul(xf2, circle.Position);
            Vector2 cLocal = Math.MulT(xf1, c);

            // Find the min separating edge.
            int normalIndex = 0;
            float separation = -Settings.FltMax;
            float radius = polygon.Radius + circle.Radius;
            int vertexCount = polygon.VertexCount;
            Vector2[] vertices = polygon.Vertices;
            Vector2[] normals = polygon.Normals;

            for (int i = 0; i < vertexCount; ++i)
            {
                float s = Vector2.Dot(normals[i], cLocal - vertices[i]);
                if (s > radius)
                {
                    // Early out.
                    return;
                }

                if (s > separation)
                {
                    separation = s;
                    normalIndex = i;
                }
            }

            // Vertices that subtend the incident face.
            int vertIndex1 = normalIndex;
            int vertIndex2 = vertIndex1 + 1 < vertexCount ? vertIndex1 + 1 : 0;
            Vector2 v1 = vertices[vertIndex1];
            Vector2 v2 = vertices[vertIndex2];

            // If the center is inside the polygon ...
            if (separation < Settings.FltEpsilon)
            {
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = normals[normalIndex];
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
                return;
            }

            // Compute barycentric coordinates
            float u1 = Vector2.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2.Dot(cLocal - v2, v1 - v2);
            if (u1 <= 0.0f)
            {
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
                Vector2 faceCenter = 0.5f * (v1 + v2);
                float dot = Vector2.Dot(cLocal - faceCenter, normals[vertIndex1]);
                if (dot > radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = normals[vertIndex1];
                manifold.LocalPoint = faceCenter;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
        }
    }
}