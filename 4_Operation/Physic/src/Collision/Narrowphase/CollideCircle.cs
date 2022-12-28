// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollideCircle.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.Narrowphase
{
    /// <summary>
    ///     The collide circle class
    /// </summary>
    public static class CollideCircle
    {
        /// <summary>Compute the collision manifold between two circles.</summary>
        public static void CollideCircles(ref Manifold manifold, CircleShape circleA, ref Transform xfA,
            CircleShape circleB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            Vector2F pA = MathUtils.Mul(ref xfA, circleA.Position);
            Vector2F pB = MathUtils.Mul(ref xfB, circleB.Position);

            Vector2F d = pB - pA;
            float distSqr = Vector2F.Dot(d, d);
            float rA = circleA.RadiusPrivate, rB = circleB.RadiusPrivate;
            float radius = rA + rB;
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.Type = ManifoldType.Circles;
            manifold.LocalPoint = circleA.Position;
            manifold.LocalNormal = Vector2F.Zero;
            manifold.PointCount = 1;

            ManifoldPoint p0 = manifold.Points[0];
            p0.LocalPoint = circleB.Position;
            p0.Id.Key = 0;
            manifold.Points[0] = p0;
        }

        /// <summary>Compute the collision manifold between a polygon and a circle.</summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="polygonA">The polygon A.</param>
        /// <param name="xfA">The transform of A.</param>
        /// <param name="circleB">The circle B.</param>
        /// <param name="xfB">The transform of B.</param>
        public static void CollidePolygonAndCircle(ref Manifold manifold, PolygonShape polygonA, ref Transform xfA,
            CircleShape circleB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            // Compute circle position in the frame of the polygon.
            Vector2F c = MathUtils.Mul(ref xfB, circleB.Position);
            Vector2F cLocal = MathUtils.MulT(ref xfA, c);

            // Find the min separating edge.
            int normalIndex = 0;
            float separation = -MathConstants.MaxFloat;
            float radius = polygonA.RadiusPrivate + circleB.RadiusPrivate;
            int vertexCount = polygonA.VerticesPrivate.Count;
            Vertices vertices = polygonA.VerticesPrivate;
            Vertices normals = polygonA.NormalsPrivate;

            for (int i = 0; i < vertexCount; ++i)
            {
                float s = Vector2F.Dot(normals[i], cLocal - vertices[i]);

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
            Vector2F v1 = vertices[vertIndex1];
            Vector2F v2 = vertices[vertIndex2];

            // If the center is inside the polygon ...
            if (separation < MathConstants.Epsilon)
            {
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = normals[normalIndex];
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points.Value0.LocalPoint = circleB.Position;
                manifold.Points.Value0.Id.Key = 0;
                return;
            }

            // Compute barycentric coordinates
            float u1 = Vector2F.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2F.Dot(cLocal - v2, v1 - v2);

            if (u1 <= 0.0f)
            {
                if (Vector2F.DistanceSquared(cLocal, v1) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = cLocal - v1;
                manifold.LocalNormal = Vector2F.Normalize(manifold.LocalNormal);
                manifold.LocalPoint = v1;
                manifold.Points.Value0.LocalPoint = circleB.Position;
                manifold.Points.Value0.Id.Key = 0;
            }
            else if (u2 <= 0.0f)
            {
                if (Vector2F.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = cLocal - v2;
                manifold.LocalNormal = Vector2F.Normalize(manifold.LocalNormal);
                manifold.LocalPoint = v2;
                manifold.Points.Value0.LocalPoint = circleB.Position;
                manifold.Points.Value0.Id.Key = 0;
            }
            else
            {
                Vector2F faceCenter = 0.5f * (v1 + v2);
                float s = Vector2F.Dot(cLocal - faceCenter, normals[vertIndex1]);
                if (s > radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = normals[vertIndex1];
                manifold.LocalPoint = faceCenter;
                manifold.Points.Value0.LocalPoint = circleB.Position;
                manifold.Points.Value0.Id.Key = 0;
            }
        }
    }
}