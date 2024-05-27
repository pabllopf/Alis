// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainShape.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A chain shape is a free form sequence of line segments. The chain has one-sided collision, with the surface
    ///     normal pointing to the right of the edge. This provides a counter-clockwise winding like the polygon shape.
    ///     Connectivity information is used to create smooth collisions. Warning: the chain will not collide properly if there
    ///     are
    ///     self-intersections.
    /// </summary>
    public sealed class ChainShape : AShape
    {
        /// <summary>Create a new ChainShape from the vertices.</summary>
        /// <param name="vertices">The vertices to use. Must contain 2 or more vertices.</param>
        /// <param name="createLoop">
        ///     Set to true to create a closed loop. It connects the first vertex to the last, and
        ///     automatically adjusts connectivity to create smooth collisions along the chain.
        /// </param>
        public ChainShape(Vertices vertices, bool createLoop = false) : base(ShapeType.Chain, Settings.PolygonRadius)
        {
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
        public Vertices Vertices { get; internal set; }
        
        /// <summary>Edge count = vertex count - 1</summary>
        public override int ChildCount => Vertices.Count - 1;
        
        /// <summary>Establish connectivity to a vertex that precedes the first vertex. Don't call this for loops.</summary>
        internal Vector2 PrevVertex { get; set; }
        
        /// <summary>Establish connectivity to a vertex that follows the last vertex. Don't call this for loops.</summary>
        internal Vector2 NextVertex { get; set; }
        
        //Velcro: The original code returned an EdgeShape for each call. To reduce garbage we merge the properties onto an existing EdgeShape
        /// <summary>
        ///     Gets the child edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="index">The index</param>
        internal void GetChildEdge(EdgeShape edge, int index)
        {
            edge.RadiusPrivate = RadiusPrivate;
            
            edge.Vertex1 = Vertices[index + 0];
            edge.Vertex2 = Vertices[index + 1];
            edge.OneSided = true;
            
            edge.Vertex0 = index > 0 ? Vertices[index - 1] : PrevVertex;
            
            edge.Vertex3 = index < Vertices.Count - 2 ? Vertices[index + 2] : NextVertex;
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
        [ExcludeFromCodeCoverage]
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output)
        {
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
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override AShape Clone()
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