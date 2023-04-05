// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeShape.cs
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
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A line segment (edge) shape. These can be connected in chains or loops to other edge shapes. Edges created
    ///     independently are two-sided and do no provide smooth movement across junctions.
    /// </summary>
    public class EdgeShape : Shape
    {
        /// <summary>
        ///     The one sided
        /// </summary>
        private bool oneSided;

        /// <summary>
        ///     The vertex
        /// </summary>
        private Vector2F vertex0;

        /// <summary>
        ///     The vertex
        /// </summary>
        private Vector2F vertex1;

        /// <summary>
        ///     The vertex
        /// </summary>
        private Vector2F vertex2;

        /// <summary>
        ///     The vertex
        /// </summary>
        private Vector2F vertex3;

        /// <summary>Create a new EdgeShape with the specified start and end. This edge supports two-sided collision.</summary>
        /// <param name="start">The start of the edge.</param>
        /// <param name="end">The end of the edge.</param>
        public EdgeShape(Vector2F start, Vector2F end) : base(ShapeType.Edge, Settings.PolygonRadius)
        {
            SetTwoSided(start, end);
        }

        /// <summary>Create a new EdgeShape with ghost vertices for smooth collision. This edge only supports one-sided collision.</summary>
        public EdgeShape(Vector2F v0, Vector2F v1, Vector2F v2, Vector2F v3) : base(ShapeType.Edge, Settings.PolygonRadius)
        {
            SetOneSided(v0, v1, v2, v3);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShape" /> class
        /// </summary>
        public EdgeShape() : base(ShapeType.Edge, Settings.PolygonRadius)
        {
        }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount => 1;

        /// <summary>Is true if the edge is connected to an adjacent vertex before vertex 1.</summary>
        public bool OneSided
        {
            get => oneSided;
            set => oneSided = value;
        }

        /// <summary>Optional adjacent vertices. These are used for smooth collision.</summary>
        public Vector2F Vertex0
        {
            get => vertex0;
            set => vertex0 = value;
        }

        /// <summary>Optional adjacent vertices. These are used for smooth collision.</summary>
        public Vector2F Vertex3
        {
            get => vertex3;
            set => vertex3 = value;
        }

        /// <summary>These are the edge vertices</summary>
        public Vector2F Vertex1
        {
            get => vertex1;
            set
            {
                vertex1 = value;
                ComputeProperties();
            }
        }

        /// <summary>These are the edge vertices</summary>
        public Vector2F Vertex2
        {
            get => vertex2;
            set
            {
                vertex2 = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Sets the one sided using the specified v 0
        /// </summary>
        /// <param name="v0">The </param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="v3">The </param>
        public void SetOneSided(Vector2F v0, Vector2F v1, Vector2F v2, Vector2F v3)
        {
            Vertex0 = v0;
            Vertex1 = v1;
            Vertex2 = v2;
            Vertex3 = v3;
            OneSided = true;

            ComputeProperties();
        }

        /// <summary>
        ///     Sets the two sided using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        public void SetTwoSided(Vector2F start, Vector2F end)
        {
            Vertex1 = start;
            Vertex2 = end;
            OneSided = false;

            ComputeProperties();
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2F point) => false;

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output) =>
            RayCastHelper.RayCastEdge(ref vertex1, ref vertex2, OneSided, ref input,
                ref transform, out output);

        /// <summary>
        ///     Computes the aabb using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="aabb">The aabb</param>
        public override void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb)
        {
            AabbHelper.ComputeEdgeAabb(ref vertex1, ref vertex2, ref transform, out aabb);
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected sealed override void ComputeProperties()
        {
            MassDataPrivate.Centroid = 0.5f * (Vertex1 + Vertex2);
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            EdgeShape clone = new EdgeShape
            {
                ShapeTypePrivate = ShapeTypePrivate,
                RadiusPrivate = RadiusPrivate,
                DensityPrivate = DensityPrivate,
                OneSided = OneSided,
                Vertex0 = Vertex0,
                Vertex1 = Vertex1,
                Vertex2 = Vertex2,
                Vertex3 = Vertex3,
                MassDataPrivate = MassDataPrivate
            };
            return clone;
        }
    }
}