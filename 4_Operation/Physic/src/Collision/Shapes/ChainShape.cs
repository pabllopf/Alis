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


using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A chain shape is a free form sequence of line segments.
    ///     The chain has two-sided collision, so you can use inside and outside collision.
    ///     Therefore, you may use any winding order.
    ///     Connectivity information is used to create smooth collisions.
    ///     WARNING: The chain will not collide properly if there are self-intersections.
    /// </summary>
    public class ChainShape : Shape
    {
        /// <summary>
        ///     The edge shape
        /// </summary>
        private static readonly EdgeShape EdgeShape = new EdgeShape();

        /// <summary>
        ///     The has next vertex
        /// </summary>
        private bool _hasNextVertex;

        /// <summary>
        ///     The has next vertex
        /// </summary>
        private bool _hasPrevVertex;

        /// <summary>
        ///     The next vertex
        /// </summary>
        private Vector2F _nextVertex;

        /// <summary>
        ///     The next vertex
        /// </summary>
        private Vector2F _prevVertex;

        /// <summary>
        ///     The vertices. These are not owned/freed by the chain Shape.
        /// </summary>
        public Vertices Vertices;

        /// <summary>
        ///     Constructor for ChainShape. By default have 0 in density.
        /// </summary>
        public ChainShape()
            : base(0)
        {
            ShapeType = ShapeType.Chain;
            Radius = SettingEnv.PolygonRadius;
        }

        /// <summary>
        ///     Create a new chainshape from the vertices.
        /// </summary>
        /// <param name="vertices">The vertices to use. Must contain 2 or more vertices.</param>
        /// <param name="createLoop">
        ///     Set to true to create a closed loop. It connects the first vertice to the last, and
        ///     automatically adjusts connectivity to create smooth collisions along the chain.
        /// </param>
        public ChainShape(Vertices vertices, bool createLoop = false)
            : base(0)
        {
            ShapeType = ShapeType.Chain;
            Radius = SettingEnv.PolygonRadius;

            // FPE. See http://www.box2d.org/forum/viewtopic.php?f=4&t=7973&p=35363

            for (int i = 1; i < vertices.Count; ++i)
            {
                Vector2F v1 = vertices[i - 1];
                Vector2F v2 = vertices[i];

                // If the code crashes here, it means your vertices are too close together.
                }

            Vertices = new Vertices(vertices);

            if (createLoop)
            {
                Vertices.Add(vertices[0]);
                PrevVertex = Vertices[Vertices.Count - 2]; //FPE: We use the properties instead of the private fields here.
                NextVertex = Vertices[1]; //FPE: We use the properties instead of the private fields here.
            }
        }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount =>
            // edge count = vertex count - 1
            Vertices.Count - 1;

        /// <summary>
        ///     Establish connectivity to a vertex that precedes the first vertex.
        ///     Don't call this for loops.
        /// </summary>
        public Vector2F PrevVertex
        {
            get => _prevVertex;
            set
            {
                _prevVertex = value;
                _hasPrevVertex = true;
            }
        }

        /// <summary>
        ///     Establish connectivity to a vertex that follows the last vertex.
        ///     Don't call this for loops.
        /// </summary>
        public Vector2F NextVertex
        {
            get => _nextVertex;
            set
            {
                _nextVertex = value;
                _hasNextVertex = true;
            }
        }

        /// <summary>
        ///     This method has been optimized to reduce garbage.
        /// </summary>
        /// <param name="edge">The cached edge to set properties on.</param>
        /// <param name="index">The index.</param>
        internal void GetChildEdge(EdgeShape edge, int index)
        {
            edge.ShapeType = ShapeType.Edge;
            edge.Radius = Radius;

            edge.Vertex1 = Vertices[index + 0];
            edge.Vertex2 = Vertices[index + 1];

            if (index > 0)
            {
                edge.Vertex0 = Vertices[index - 1];
                edge.HasVertex0 = true;
            }
            else
            {
                edge.Vertex0 = _prevVertex;
                edge.HasVertex0 = _hasPrevVertex;
            }

            if (index < Vertices.Count - 2)
            {
                edge.Vertex3 = Vertices[index + 2];
                edge.HasVertex3 = true;
            }
            else
            {
                edge.Vertex3 = _nextVertex;
                edge.HasVertex3 = _hasNextVertex;
            }
        }

        /// <summary>
        ///     Get a child edge.
        /// </summary>
        /// <param name="index">The index.</param>
        public EdgeShape GetChildEdge(int index)
        {
            EdgeShape edgeShape = new EdgeShape();
            GetChildEdge(edgeShape, index);
            return edgeShape;
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="controllerTransform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref ControllerTransform controllerTransform, ref Vector2F point) => false;

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="controllerTransform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(out RayCastOutput output, ref RayCastInput input, ref ControllerTransform controllerTransform, int childIndex)
        {
            int i1 = childIndex;
            int i2 = childIndex + 1;
            if (i2 == Vertices.Count)
            {
                i2 = 0;
            }

            EdgeShape.Vertex1 = Vertices[i1];
            EdgeShape.Vertex2 = Vertices[i2];

            return EdgeShape.RayCast(out output, ref input, ref controllerTransform, 0);
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="controllerTransform">The transform</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAabb(out Aabb aabb, ref ControllerTransform controllerTransform, int childIndex)
        {
            int i1 = childIndex;
            int i2 = childIndex + 1;
            if (i2 == Vertices.Count)
            {
                i2 = 0;
            }

            Vector2F v1 = ControllerTransform.Multiply(Vertices[i1], ref controllerTransform);
            Vector2F v2 = ControllerTransform.Multiply(Vertices[i2], ref controllerTransform);

            Vector2F.Min(ref v1, ref v2, out aabb.LowerBound);
            Vector2F.Max(ref v1, ref v2, out aabb.UpperBound);
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected override void ComputeProperties()
        {
            //Does nothing. Chain shapes don't have properties.
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="sc">The sc</param>
        /// <returns>The float</returns>
        public override float ComputeSubmergedArea(ref Vector2F normal, float offset, ref ControllerTransform xf, out Vector2F sc)
        {
            sc = Vector2F.Zero;
            return 0;
        }

        /// <summary>
        ///     Compare the chain to another chain
        /// </summary>
        /// <param name="shape">The other chain</param>
        /// <returns>True if the two chain shapes are the same</returns>
        public bool CompareTo(ChainShape shape)
        {
            if (Vertices.Count != shape.Vertices.Count)
            {
                return false;
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] != shape.Vertices[i])
                {
                    return false;
                }
            }

            return (PrevVertex == shape.PrevVertex) && (NextVertex == shape.NextVertex);
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            ChainShape clone = new ChainShape();
            clone.ShapeType = ShapeType;
            clone.Density = Density;
            clone.Radius = Radius;
            clone.PrevVertex = _prevVertex;
            clone.NextVertex = _nextVertex;
            clone._hasNextVertex = _hasNextVertex;
            clone._hasPrevVertex = _hasPrevVertex;
            clone.Vertices = new Vertices(Vertices);
            clone.MassData = MassData;
            return clone;
        }
    }
}