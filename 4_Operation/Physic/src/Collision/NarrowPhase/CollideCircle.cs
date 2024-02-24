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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.NarrowPhase
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

            Vector2 pA = MathUtils.Mul(ref xfA, circleA.Position);
            Vector2 pB = MathUtils.Mul(ref xfB, circleB.Position);

            Vector2 d = pB - pA;
            float distSqr = Vector2.Dot(d, d);
            float rA = circleA.RadiusPrivate, rB = circleB.RadiusPrivate;
            float radius = rA + rB;
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.Type = ManifoldType.Circles;
            manifold.LocalPoint = circleA.Position;
            manifold.LocalNormal = Vector2.Zero;
            manifold.PointCount = 1;

            ManifoldPoint p0 = manifold.Points[0];
            p0.LocalPoint = circleB.Position;
            p0.Id.Key = 0;
            manifold.Points[0] = p0;
        }

        /// <summary>
        ///     Collides the polygon and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polygonA">The polygon</param>
        /// <param name="xfA">The xf</param>
        /// <param name="circleB">The circle</param>
        /// <param name="xfB">The xf</param>
        public static void CollidePolygonAndCircle(ref Manifold manifold, PolygonShape polygonA, ref Transform xfA,
            CircleShape circleB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            Vector2 c = ComputeCirclePositionInPolygonFrame(ref xfB, circleB.Position);
            Vector2 cLocal = c;

            float radius = polygonA.RadiusPrivate + circleB.RadiusPrivate;
            int vertexCount = polygonA.VerticesPrivate.Count;
            Vertices vertices = polygonA.VerticesPrivate;
            Vertices normals = polygonA.NormalsPrivate;

            int normalIndex = FindMinSeparatingEdge(cLocal, radius, vertexCount, vertices, normals);
            if (normalIndex == -1) return;

            int vertIndex1 = normalIndex;
            int vertIndex2 = vertIndex1 + 1 < vertexCount ? vertIndex1 + 1 : 0;
            Vector2 v1 = vertices[vertIndex1];
            Vector2 v2 = vertices[vertIndex2];

            float separation = Vector2.Distance(c, v1);

            if (IsCenterInsidePolygon(separation, v1, v2, normals, normalIndex, circleB.Position, ref manifold)) return;

            ComputeBarycentricCoordinates(cLocal, v1, v2, radius, circleB.Position, ref manifold, normals, vertIndex1);
        }

        /// <summary>
        ///     Computes the circle position in polygon frame using the specified xf b
        /// </summary>
        /// <param name="xfB">The xf</param>
        /// <param name="circleBPosition">The circle position</param>
        /// <returns>The vector</returns>
        private static Vector2 ComputeCirclePositionInPolygonFrame(ref Transform xfB, Vector2 circleBPosition) => MathUtils.Mul(ref xfB, circleBPosition);

        /// <summary>
        ///     Finds the min separating edge using the specified c local
        /// </summary>
        /// <param name="cLocal">The local</param>
        /// <param name="radius">The radius</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="normals">The normals</param>
        /// <returns>The normal index</returns>
        private static int FindMinSeparatingEdge(Vector2 cLocal, float radius, int vertexCount, Vertices vertices, Vertices normals)
        {
            int normalIndex = 0;
            float separation = -float.MaxValue;

            for (int i = 0; i < vertexCount; ++i)
            {
                float s = Vector2.Dot(normals[i], cLocal - vertices[i]);

                if (s > radius)
                {
                    // Early out.
                    return -1;
                }

                if (s > separation)
                {
                    separation = s;
                    normalIndex = i;
                }
            }

            return normalIndex;
        }

        /// <summary>
        ///     Describes whether is center inside polygon
        /// </summary>
        /// <param name="separation">The separation</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="normals">The normals</param>
        /// <param name="normalIndex">The normal index</param>
        /// <param name="circleBPosition">The circle position</param>
        /// <param name="manifold">The manifold</param>
        /// <returns>The bool</returns>
        private static bool IsCenterInsidePolygon(float separation, Vector2 v1, Vector2 v2, Vertices normals, int normalIndex, Vector2 circleBPosition, ref Manifold manifold)
        {
            if (separation < Constant.Epsilon)
            {
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = normals[normalIndex];
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points.Value0.LocalPoint = circleBPosition;
                manifold.Points.Value0.Id.Key = 0;
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Computes the barycentric coordinates using the specified c local
        /// </summary>
        /// <param name="cLocal">The local</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="circleBPosition">The circle position</param>
        /// <param name="manifold">The manifold</param>
        /// <param name="normals">The normals</param>
        /// <param name="vertIndex1">The vert index</param>
        private static void ComputeBarycentricCoordinates(Vector2 cLocal, Vector2 v1, Vector2 v2, float radius, Vector2 circleBPosition, ref Manifold manifold, Vertices normals, int vertIndex1)
        {
            float u1 = Vector2.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2.Dot(cLocal - v2, v1 - v2);

            if (u1 <= 0.0f)
            {
                if (Vector2.DistanceSquared(cLocal, v1) > radius * radius)
                {
                    return;
                }

                SetManifoldForVertex(ref manifold, cLocal, v1, circleBPosition);
            }
            else if (u2 <= 0.0f)
            {
                if (Vector2.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                SetManifoldForVertex(ref manifold, cLocal, v2, circleBPosition);
            }
            else
            {
                Vector2 faceCenter = 0.5f * (v1 + v2);
                float s = Vector2.Dot(cLocal - faceCenter, normals[vertIndex1]);
                if (s > radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = normals[vertIndex1];
                manifold.LocalPoint = faceCenter;
                manifold.Points.Value0.LocalPoint = circleBPosition;
                manifold.Points.Value0.Id.Key = 0;
            }
        }

        /// <summary>
        ///     Sets the manifold for vertex using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="cLocal">The local</param>
        /// <param name="vertex">The vertex</param>
        /// <param name="circleBPosition">The circle position</param>
        private static void SetManifoldForVertex(ref Manifold manifold, Vector2 cLocal, Vector2 vertex, Vector2 circleBPosition)
        {
            manifold.PointCount = 1;
            manifold.Type = ManifoldType.FaceA;
            manifold.LocalNormal = cLocal - vertex;
            manifold.LocalNormal = Vector2.Normalize(manifold.LocalNormal);
            manifold.LocalPoint = vertex;
            manifold.Points.Value0.LocalPoint = circleBPosition;
            manifold.Points.Value0.Id.Key = 0;
        }
    }
}