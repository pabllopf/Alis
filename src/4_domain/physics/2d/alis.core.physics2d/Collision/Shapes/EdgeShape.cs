// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EdgeShape.cs
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

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D.Shapes
{
    /// <summary>
    ///     A line segment (edge) shape. These can be connected in chains or loops
    ///     to other edge shapes. Edges created independently are two-sided and do
    ///     no provide smooth movement across junctions.
    /// </summary>
    public class EdgeShape : Shape
    {
        /// <summary>
        ///     The onesided
        /// </summary>
        internal bool m_oneSided;

        /// <summary>
        ///     The vertex0
        /// </summary>
        internal Vector2? m_vertex0;

        /// <summary>
        ///     The vertex1
        /// </summary>
        internal Vector2 m_vertex1;

        /// <summary>
        ///     The vertex2
        /// </summary>
        internal Vector2 m_vertex2;

        /// <summary>
        ///     The vertex3
        /// </summary>
        internal Vector2? m_vertex3;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShape" /> class
        /// </summary>
        public EdgeShape() => m_radius = Settings.PolygonRadius;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShape" /> class
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        public EdgeShape(Vector2 v1, Vector2 v2) : this()
        {
            SetTwoSided(v1, v2);
        }

        /// <summary>
        ///     Gets the value of the vertex 1
        /// </summary>
        public Vector2 Vertex1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_vertex1;
        }

        /// <summary>
        ///     Gets the value of the vertex 2
        /// </summary>
        public Vector2 Vertex2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_vertex2;
        }

        /// <summary>
        ///     Gets the value of the contact match
        /// </summary>
        internal override byte ContactMatch => contactMatch;

        /// <summary>
        ///     The contact match
        /// </summary>
        internal const byte contactMatch = 1;

        /// <summary>
        ///     Set this as a part of a sequence. Vertex v0 precedes the edge and vertex v3
        ///     follows. These extra vertices are used to provide smooth movement
        ///     across junctions. This also makes the collision one-sided. The edge
        ///     normal points to the right looking from v1 to v2.
        /// </summary>
        public void SetOneSided(in Vector2 v0, in Vector2 v1, in Vector2 v2, in Vector2 v3)
        {
            m_vertex0 = v0;
            m_vertex1 = v1;
            m_vertex2 = v2;
            m_vertex3 = v3;
            m_oneSided = true;
        }

        /// <summary>
        ///     Sets the two sided using the specified v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        public void SetTwoSided(in Vector2 v1, in Vector2 v2)
        {
            m_vertex1 = v1;
            m_vertex2 = v2;
            m_oneSided = false;
        }

        /// <summary>
        ///     Sets the v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        [Obsolete("Use SetTwoSided instead", true)]
        public void Set(in Vector2 v1, in Vector2 v2)
        {
            m_vertex1 = v1;
            m_vertex2 = v2;
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The shape</returns>
        public override Shape Clone() => (EdgeShape) MemberwiseClone();

        /// <summary>
        ///     Gets the child count
        /// </summary>
        /// <returns>The int</returns>
        public override int GetChildCount() => 1;

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public override bool TestPoint(in Transform xf, in Vector2 p) => false;

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="xf">The xf</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(
            out RayCastOutput output,
            in RayCastInput input,
            in Transform xf,
            int childIndex)
        {
            output = default(RayCastOutput);
            // Put the ray into the edge's frame of reference.
            Vector2 p1 = Math.MulT(xf.q, input.p1 - xf.p);
            Vector2 p2 = Math.MulT(xf.q, input.p2 - xf.p);
            Vector2 d = p2 - p1;

            Vector2 v1 = m_vertex1;
            Vector2 v2 = m_vertex2;
            Vector2 e = v2 - v1;

            // Normal points to the right, looking from v1 at v2
            Vector2 normal = Vector2.Normalize(new Vector2(e.Y, -e.X));

            // q = p1 + t * d
            // dot(normal, q - v1) = 0
            // dot(normal, p1 - v1) + t * dot(normal, d) = 0
            float numerator = Vector2.Dot(normal, v1 - p1);
            if (m_oneSided && numerator > 0.0f)
            {
                return false;
            }

            float denominator = Vector2.Dot(normal, d);

            if (denominator == 0.0f)
            {
                return false;
            }

            float t = numerator / denominator;
            if (t < 0.0f || input.maxFraction < t)
            {
                return false;
            }

            Vector2 q = p1 + t * d;

            // q = v1 + s * r
            // s = dot(q - v1, r) / dot(r, r)
            Vector2 r = v2 - v1;
            float rr = Vector2.Dot(r, r);
            if (rr == 0.0f)
            {
                return false;
            }

            float s = Vector2.Dot(q - v1, r) / rr;
            if (s < 0.0f || 1.0f < s)
            {
                return false;
            }

            output.fraction = t;
            if (numerator > 0.0f)
            {
                output.normal = -Vector2.Transform(normal, xf.q); //   Math.Mul(xf.q, normal);
            }
            else
            {
                output.normal = Vector2.Transform(normal, xf.q); //Math.Mul(xf.q, normal);
            }

            return true;
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="xf">The xf</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAABB(out AABB aabb, in Transform xf, int childIndex)
        {
            Vector2 v1 = Math.Mul(xf, m_vertex1);
            Vector2 v2 = Math.Mul(xf, m_vertex2);

            Vector2 lower = Vector2.Min(v1, v2);
            Vector2 upper = Vector2.Max(v1, v2);

            Vector2 r = new Vector2(m_radius, m_radius);
            aabb.lowerBound = lower - r;
            aabb.upperBound = upper + r;
        }

        /// <summary>
        ///     Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="density">The density</param>
        public override void ComputeMass(out MassData massData, float density)
        {
            massData.mass = 0.0f;
            massData.center = 0.5f * (m_vertex1 + m_vertex2);
            massData.I = 0.0f;
        }

        /// <summary>
        ///     Sets the v 0
        /// </summary>
        /// <param name="v0">The </param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="v3">The </param>
        public void Set(Vector2 v0, Vector2 v1, Vector2 v2, Vector2 v3)
        {
            m_vertex0 = v0;
            m_vertex1 = v1;
            m_vertex2 = v2;
            m_vertex3 = v3;
        }
    }
}