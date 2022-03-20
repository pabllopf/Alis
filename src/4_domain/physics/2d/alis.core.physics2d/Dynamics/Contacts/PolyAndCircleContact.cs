// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolyAndCircleContact.cs
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
using Alis.Core.Physics2D.Collision;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Fixtures;

namespace Alis.Core.Physics2D.Dynamics.Contacts
{
    /// <summary>
    /// The poly and circle contact class
    /// </summary>
    /// <seealso cref="Contact"/>
    internal class PolyAndCircleContact : Contact
    {
        /// <summary>
        /// The circle
        /// </summary>
        private readonly CircleShape circleB;
        /// <summary>
        /// The polygon
        /// </summary>
        private readonly PolygonShape polygonA;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyAndCircleContact"/> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        public PolyAndCircleContact(Fixture fA, int indexA, Fixture fB, int indexB) : base(fA, indexA, fB, indexB)
        {
            polygonA = (PolygonShape) m_fixtureA.Shape;
            circleB = (CircleShape) m_fixtureB.Shape;
        }

        /// <summary>
        /// Evaluates the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        internal override void Evaluate(out Manifold manifold, in Transform xfA, in Transform xfB)
        {
            manifold = new Manifold();

            //manifold.pointCount = 0;

            // Compute circle position in the frame of the polygon.
            Vector2 c = Math.Mul(xfB, circleB.m_p);
            Vector2 cLocal = Math.MulT(xfA, c);

            // Find the min separating edge.
            int normalIndex = 0;
            float separation = float.MinValue;
            float radius = polygonA.m_radius + circleB.m_radius;
            int vertexCount = polygonA.m_count;
            Vector2[] vertices = polygonA.m_vertices;
            Vector2[] normals = polygonA.m_normals;

            for (int i = 0; i < vertexCount; ++i)
            {
                float s = Vector2.Dot(normals[i], cLocal - vertices[i]);
                if (s > radius)
                    // Early out.
                {
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
            manifold.points[0] = new ManifoldPoint();

            // If the center is inside the polygon ...
            if (separation < Settings.FLT_EPSILON)
            {
                manifold.pointCount = 1;
                manifold.type = ManifoldType.FaceA;
                manifold.localNormal = normals[normalIndex];
                manifold.localPoint = 0.5f * (v1 + v2);
                manifold.points[0].localPoint = circleB.m_p;
                manifold.points[0].id.key = 0;
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

                manifold.pointCount = 1;
                manifold.type = ManifoldType.FaceA;
                manifold.localNormal = Vector2.Normalize(cLocal - v1);
                manifold.localPoint = v1;
                manifold.points[0].localPoint = circleB.m_p;
                manifold.points[0].id.key = 0;
            }
            else if (u2 <= 0.0f)
            {
                if (Vector2.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                manifold.pointCount = 1;
                manifold.type = ManifoldType.FaceA;
                manifold.localNormal = Vector2.Normalize(cLocal - v2);
                manifold.localPoint = v2;
                manifold.points[0].localPoint = circleB.m_p;
                manifold.points[0].id.key = 0;
            }
            else
            {
                Vector2 faceCenter = 0.5f * (v1 + v2);
                float s = Vector2.Dot(cLocal - faceCenter, normals[vertIndex1]);
                if (s > radius)
                {
                    return;
                }

                manifold.pointCount = 1;
                manifold.type = ManifoldType.FaceA;
                manifold.localNormal = normals[vertIndex1];
                manifold.localPoint = faceCenter;
                manifold.points[0].localPoint = circleB.m_p;
                manifold.points[0].id.key = 0;
            }
        }
    }
}