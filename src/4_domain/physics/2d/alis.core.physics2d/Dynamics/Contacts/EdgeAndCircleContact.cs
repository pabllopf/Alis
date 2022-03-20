// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EdgeAndCircleContact.cs
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
    /// The edge and circle contact class
    /// </summary>
    /// <seealso cref="Contact"/>
    internal class EdgeAndCircleContact : Contact
    {
        /// <summary>
        /// The circle
        /// </summary>
        private readonly CircleShape circleB;

        /// <summary>
        /// The edge
        /// </summary>
        protected EdgeShape edgeA;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeAndCircleContact"/> class
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        internal EdgeAndCircleContact(Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
            : base(fixtureA, indexA, fixtureB, indexB)
        {
            //Debug.Assert(fixtureA.Type == ShapeType.Edge);
            //Debug.Assert(fixtureB.Type == ShapeType.Circle);
            m_manifold.pointCount = 0;
            m_manifold.points[0] = new ManifoldPoint();
            m_manifold.points[0].normalImpulse = 0.0f;
            m_manifold.points[0].tangentImpulse = 0.0f;

            edgeA = m_fixtureA.Shape is EdgeShape ? (EdgeShape) m_fixtureA.Shape : null;
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

            Vector2 Q = Math.MulT(xfA, Math.Mul(xfB, circleB.m_p));

            Vector2 A = edgeA.m_vertex1, B = edgeA.m_vertex2;
            Vector2 e = B - A;

            float u = Vector2.Dot(e, B - Q);
            float v = Vector2.Dot(e, Q - A);

            float radius = edgeA.m_radius + circleB.m_radius;

            ContactFeature cf;
            cf.indexB = 0;
            cf.typeB = (byte) ContactFeatureType.Vertex;


            // Region A
            if (v <= 0.0f)
            {
                Vector2 P = A;
                Vector2 d = Q - P;
                float dd = Vector2.Dot(d, d);
                if (dd > radius * radius)
                {
                    return;
                }

                // Is there an edge connected to A?
                if (edgeA.m_vertex0.HasValue)
                {
                    Vector2 A1 = edgeA.m_vertex0.Value;
                    Vector2 B1 = A;
                    Vector2 e1 = B1 - A1;
                    float u1 = Vector2.Dot(e1, B1 - Q);

                    // Is the circle in Region AB of the previous edge?
                    if (u1 > 0.0f)
                    {
                        return;
                    }
                }

                cf.indexA = 0;
                cf.typeA = (byte) ContactFeatureType.Vertex;
                manifold.pointCount = 1;
                manifold.type = ManifoldType.Circles;
                manifold.localNormal = Vector2.Zero;
                manifold.localPoint = P;
                manifold.points[0] = new ManifoldPoint();
                manifold.points[0].id.key = 0;
                manifold.points[0].id.cf = cf;
                manifold.points[0].localPoint = circleB.m_p;
                return;
            }

            // Region B
            if (u <= 0.0f)
            {
                Vector2 P = B;
                Vector2 d = Q - P;
                float dd = Vector2.Dot(d, d);
                if (dd > radius * radius)
                {
                    return;
                }

                // Is there an edge connected to B?
                if (edgeA.m_vertex3.HasValue)
                {
                    Vector2 B2 = edgeA.m_vertex3.Value;
                    Vector2 A2 = B;
                    Vector2 e2 = B2 - A2;
                    float v2 = Vector2.Dot(e2, Q - A2);

                    // Is the circle in Region AB of the next edge?
                    if (v2 > 0.0f)
                    {
                        return;
                    }
                }

                cf.indexA = 1;
                cf.typeA = (byte) ContactFeatureType.Vertex;
                manifold.pointCount = 1;
                manifold.type = ManifoldType.Circles;
                manifold.localNormal = Vector2.Zero;
                manifold.localPoint = P;
                manifold.points[0] = new ManifoldPoint();
                manifold.points[0].id.key = 0;
                manifold.points[0].id.cf = cf;
                manifold.points[0].localPoint = circleB.m_p;
                return;
            }

            {
                // Region AB
                float den = Vector2.Dot(e, e);
                //Debug.Assert(den > 0.0f);
                Vector2 P = 1.0f / den * (u * A + v * B);
                Vector2 d = Q - P;
                float dd = Vector2.Dot(d, d);
                if (dd > radius * radius)
                {
                    return;
                }

                Vector2 n = new Vector2(-e.Y, e.X);
                if (Vector2.Dot(n, Q - A) < 0.0f)
                {
                    n = new Vector2(-n.X, -n.Y);
                }

                n = Vector2.Normalize(n);

                cf.indexA = 0;
                cf.typeA = (byte) ContactFeatureType.Face;
                manifold.pointCount = 1;
                manifold.type = ManifoldType.FaceA;
                manifold.localNormal = n;
                manifold.localPoint = A;
                manifold.points[0] = new ManifoldPoint();
                manifold.points[0].id.key = 0;
                manifold.points[0].id.cf = cf;
                manifold.points[0].localPoint = circleB.m_p;
            }
        }
    }
}