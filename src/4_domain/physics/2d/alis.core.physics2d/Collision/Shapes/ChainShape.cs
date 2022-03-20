// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ChainShape.cs
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
using Alis.Core.Physics2D.Common;
using Math = Alis.Core.Physics2D.Common.Math;

namespace Alis.Core.Physics2D.Collision.Shapes
{
    /// <summary>
    ///     /// The chain has one-sided collision, with the surface normal pointing to the right of the edge.
    ///     This provides a counter-clockwise winding like the polygon shape.
    ///     Connectivity information is used to create smooth collisions.
    /// </summary>
    /// <warning>The chain will not collide properly if there are self-intersections.</warning>
    public class ChainShape : Shape
    {
        /// <summary>
        /// The count
        /// </summary>
        internal int m_count;
        /// <summary>
        /// The nextvertex
        /// </summary>
        internal Vector2 m_prevVertex, m_nextVertex;
        /// <summary>
        /// The vertices
        /// </summary>
        internal Vector2[] m_vertices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainShape"/> class
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ChainShape() => m_radius = Settings.PolygonRadius;

        /// <summary>
        /// Gets the value of the vertices
        /// </summary>
        public Vector2[] Vertices
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_vertices;
        }

        /// <summary>
        /// Gets the value of the contact match
        /// </summary>
        internal override byte ContactMatch => contactMatch;
        /// <summary>
        /// The contact match
        /// </summary>
        internal const byte contactMatch = 3;

        /// <summary>
        ///     Create a loop. This automatically adjusts connectivity.
        /// </summary>
        /// <param name="vertices">An array of vertices. These are copied</param>
        public void CreateLoop(in Vector2[] vertices)
        {
            int count = vertices.Length;
            if (count < 3)
            {
                return;
            }

            m_count = count + 1;
            m_vertices = new Vector2[m_count];
            Array.Copy(vertices, m_vertices, count);
            m_vertices[count] = m_vertices[0];
            m_prevVertex = m_vertices[m_count - 2];
            m_nextVertex = m_vertices[1];
        }

        /// <summary>
        ///     Create a chain with ghost vertices to connect multiple chains together.
        /// </summary>
        /// <param name="vertices">An array of vertices. These are copied</param>
        public void CreateChain(in Vector2[] vertices, in Vector2 prevVertex, in Vector2 nextVertex)
        {
            int count = vertices.Length;

            m_count = count;
            m_vertices = new Vector2[m_count];
            Array.Copy(vertices, m_vertices, m_count);

            m_prevVertex = prevVertex;
            m_nextVertex = nextVertex;
        }

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The shape</returns>
        public override Shape Clone() => (ChainShape) MemberwiseClone();

        /// <summary>
        /// Gets the child count
        /// </summary>
        /// <returns>The int</returns>
        public override int GetChildCount() => m_count - 1;

        /// <summary>
        /// Gets the child edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="index">The index</param>
        public void GetChildEdge(out EdgeShape edge, int index)
        {
            edge = new EdgeShape
            {
                m_radius = m_radius,
                m_vertex0 = index > 0 ? m_vertices[index - 1] : m_prevVertex,
                m_vertex1 = m_vertices[index + 0],
                m_vertex2 = m_vertices[index + 1],
                m_vertex3 = index < m_count - 2 ? m_vertices[index + 2] : m_nextVertex,
                m_oneSided = true
            };
        }

        /// <summary>
        /// Describes whether this instance test point
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public override bool TestPoint(in Transform xf, in Vector2 p) => false;

        /// <summary>
        /// Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(
            out RayCastOutput output,
            in RayCastInput input,
            in Transform transform,
            int childIndex)
        {
            EdgeShape edgeShape = new EdgeShape();

            int i1 = childIndex;
            int i2 = childIndex + 1;
            if (i2 == m_count)
            {
                i2 = 0;
            }

            edgeShape.m_vertex1 = m_vertices[i1];
            edgeShape.m_vertex2 = m_vertices[i2];

            return edgeShape.RayCast(out output, input, transform, 0);
        }

        /// <summary>
        /// Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="xf">The xf</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAABB(out AABB aabb, in Transform xf, int childIndex)
        {
            int i1 = childIndex;
            int i2 = childIndex + 1;
            if (i2 == m_count)
            {
                i2 = 0;
            }

            Vector2 v1 = Math.Mul(xf, m_vertices[i1]);
            Vector2 v2 = Math.Mul(xf, m_vertices[i2]);

            aabb.lowerBound = Vector2.Min(v1, v2);
            aabb.upperBound = Vector2.Max(v1, v2);
        }

        /// <summary>
        /// Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="density">The density</param>
        public override void ComputeMass(out MassData massData, float density)
        {
            massData = default(MassData);
        }
    }
}