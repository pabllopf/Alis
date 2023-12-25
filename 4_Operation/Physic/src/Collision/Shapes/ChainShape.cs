// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ChainShape.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A chain shape is a free form sequence of line segments. The chain has one-sided collision, with the surface
    ///     normal pointing to the right of the edge. This provides a counter-clockwise winding like the polygon shape.
    ///     Connectivity information is used to create smooth collisions. Warning: the chain will not collide properly if there
    ///     are
    ///     self-intersections.
    /// </summary>
    public class ChainShape : Shape
    {
        /// <summary>
        ///     The next vertex
        /// </summary>
        private Vector2 nextVertex;

        /// <summary>
        ///     The next vertex
        /// </summary>
        private Vector2 prevVertex;

        /// <summary>
        ///     The vertices
        /// </summary>
        private Vertices vertices;

        /// <summary>Create a new ChainShape from the vertices.</summary>
        /// <param name="vertices">The vertices to use. Must contain 2 or more vertices.</param>
        /// <param name="createLoop">
        ///     Set to true to create a closed loop. It connects the first vertex to the last, and
        ///     automatically adjusts connectivity to create smooth collisions along the chain.
        /// </param>
        public ChainShape(Vertices vertices, bool createLoop = false) : base(ShapeType.Chain, Settings.PolygonRadius)
        {
            Debug.Assert((vertices != null) && (vertices.Count >= 3));
            Debug.Assert(vertices[0] !=
                         vertices[
                             vertices.Count -
                             1]); //Velcro. See http://www.box2d.org/forum/viewtopic.php?f=4&t=7973&p=35363

            for (int i = 1; i < vertices.Count; ++i)
            {
                // If the code crashes here, it means your vertices are too close together.
                Vector2 current = vertices[i];
                Vector2 prev = vertices[i - 1];
                Debug.Assert(MathUtils.DistanceSquared(ref prev, ref current) >
                             Settings.LinearSlop * Settings.LinearSlop);
            }

            Vertices = new Vertices(vertices);

            //Velcro: Merged CreateLoop() and CreateChain() to this
            if (createLoop)
            {
                Vertices.Add(vertices[0]);
                PrevVertex = Vertices[Vertices.Count - 2];
                NextVertex = Vertices[1];
            }

            ComputeProperties();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChainShape" /> class
        /// </summary>
        private ChainShape() : base(ShapeType.Chain, Settings.PolygonRadius)
        {
        }

        /// <summary>The vertices. These are not owned/freed by the chain Shape.</summary>
        public Vertices Vertices
        {
            get => vertices;
            set => vertices = value;
        }

        /// <summary>Edge count = vertex count - 1</summary>
        public override int ChildCount => Vertices.Count - 1;

        /// <summary>Establish connectivity to a vertex that precedes the first vertex. Don't call this for loops.</summary>
        public Vector2 PrevVertex
        {
            get => prevVertex;
            set => prevVertex = value;
        }

        /// <summary>Establish connectivity to a vertex that follows the last vertex. Don't call this for loops.</summary>
        public Vector2 NextVertex
        {
            get => nextVertex;
            set => nextVertex = value;
        }

        //Velcro: The original code returned an EdgeShape for each call. To reduce garbage we merge the properties onto an existing EdgeShape
        /// <summary>
        ///     Gets the child edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="index">The index</param>
        internal void GetChildEdge(EdgeShape edge, int index)
        {
            Debug.Assert((0 <= index) && (index < Vertices.Count - 1));
            Debug.Assert(edge != null);

            //Velcro: It is already an edge shape
            //edge._shapeTypePrivate = ShapeType.Edge;
            edge.RadiusPrivate = RadiusPrivate;

            edge.Vertex1 = Vertices[index + 0];
            edge.Vertex2 = Vertices[index + 1];
            edge.OneSided = true;

            if (index > 0)
            {
                edge.Vertex0 = Vertices[index - 1];
            }
            else
            {
                edge.Vertex0 = PrevVertex;
            }

            if (index < Vertices.Count - 2)
            {
                edge.Vertex3 = Vertices[index + 2];
            }
            else
            {
                edge.Vertex3 = NextVertex;
            }
        }

        /// <summary>
        ///     Gets the child edge using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The edge shape</returns>
        public EdgeShape GetChildEdge(int index)
        {
            EdgeShape edgeShape = new EdgeShape();
            GetChildEdge(edgeShape, index);
            return edgeShape;
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2 point) => false;

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output)
        {
            Debug.Assert(childIndex < Vertices.Count);

            int i1 = childIndex;
            int i2 = childIndex + 1;

            if (i2 == Vertices.Count)
            {
                i2 = 0;
            }

            Vector2 v1 = Vertices[i1];
            Vector2 v2 = Vertices[i2];

            return RayCastHelper.RayCastEdge(ref v1, ref v2, false, ref input, ref transform, out output);
        }

        /// <summary>
        ///     Computes the aabb using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="aabb">The aabb</param>
        public override void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb)
        {
            Debug.Assert(childIndex < Vertices.Count);

            int i1 = childIndex;
            int i2 = childIndex + 1;

            if (i2 == Vertices.Count)
            {
                i2 = 0;
            }

            Vector2 v1 = Vertices[i1];
            Vector2 v2 = Vertices[i2];

            AabbHelper.ComputeEdgeAabb(ref v1, ref v2, ref transform, out aabb);
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected sealed override void ComputeProperties()
        {
            //Does nothing. Chain shapes don't have properties.
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            ChainShape clone = new ChainShape
            {
                ShapeTypePrivate = ShapeTypePrivate,
                DensityPrivate = DensityPrivate,
                RadiusPrivate = RadiusPrivate,
                PrevVertex = PrevVertex,
                NextVertex = NextVertex,
                Vertices = new Vertices(Vertices)
            };
            return clone;
        }
    }
}