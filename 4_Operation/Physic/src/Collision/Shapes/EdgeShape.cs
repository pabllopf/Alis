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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Transform = Alis.Core.Physic.Common.Transform;


namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A line segment (edge) shape. These can be connected in chains or loops
    ///     to other edge shapes.
    ///     The connectivity information is used to ensure correct contact normals.
    /// </summary>
    public class EdgeShape : Shape
    {
        /// <summary>
        ///     Edge start vertex
        /// </summary>
        internal Vector2 _vertex1;

        /// <summary>
        ///     Edge end vertex
        /// </summary>
        internal Vector2 _vertex2;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShape" /> class
        /// </summary>
        internal EdgeShape()
            : base(0)
        {
            ShapeType = ShapeType.Edge;
            _radius = SettingEnv.PolygonRadius;
        }

        /// <summary>
        ///     Create a new EdgeShape with the specified start and end.
        /// </summary>
        /// <param name="start">The start of the edge.</param>
        /// <param name="end">The end of the edge.</param>
        public EdgeShape(Vector2 start, Vector2 end)
            : base(0)
        {
            ShapeType = ShapeType.Edge;
            _radius = SettingEnv.PolygonRadius;
            Set(start, end);
        }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount => 1;

        /// <summary>
        ///     Is true if the edge is connected to an adjacent vertex before vertex 1.
        /// </summary>
        public bool HasVertex0 { get; set; }

        /// <summary>
        ///     Is true if the edge is connected to an adjacent vertex after vertex2.
        /// </summary>
        public bool HasVertex3 { get; set; }

        /// <summary>
        ///     Optional adjacent vertices. These are used for smooth collision.
        /// </summary>
        public Vector2 Vertex0 { get; set; }

        /// <summary>
        ///     Optional adjacent vertices. These are used for smooth collision.
        /// </summary>
        public Vector2 Vertex3 { get; set; }

        /// <summary>
        ///     These are the edge vertices
        /// </summary>
        public Vector2 Vertex1
        {
            get => _vertex1;
            set
            {
                _vertex1 = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     These are the edge vertices
        /// </summary>
        public Vector2 Vertex2
        {
            get => _vertex2;
            set
            {
                _vertex2 = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Set this as an isolated edge.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void Set(Vector2 start, Vector2 end)
        {
            _vertex1 = start;
            _vertex2 = end;
            HasVertex0 = false;
            HasVertex3 = false;

            ComputeProperties();
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
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(out RayCastOutput output, ref RayCastInput input, ref Transform transform, int childIndex)
        {
            // p = p1 + t * d
            // v = v1 + s * e
            // p1 + t * d = v1 + s * e
            // s * e - t * d = p1 - v1

            output = new RayCastOutput();

            // Put the ray into the edge's frame of reference.
            Vector2 p1 = Complex.Divide(input.Point1 - transform.p, ref transform.q);
            Vector2 p2 = Complex.Divide(input.Point2 - transform.p, ref transform.q);
            Vector2 d = p2 - p1;

            Vector2 v1 = _vertex1;
            Vector2 v2 = _vertex2;
            Vector2 e = v2 - v1;
            Vector2 normal = new Vector2(e.Y, -e.X);
            normal.Normalize();

            // q = p1 + t * d
            // dot(normal, q - v1) = 0
            // dot(normal, p1 - v1) + t * dot(normal, d) = 0
            float numerator = Vector2.Dot(normal, v1 - p1);
            float denominator = Vector2.Dot(normal, d);

            if (Math.Abs(denominator) < MathUtils.Epsilon)
            {
                return false;
            }

            float t = numerator / denominator;
            if (t < 0.0f || input.MaxFraction < t)
            {
                return false;
            }

            Vector2 q = p1 + t * d;

            // q = v1 + s * r
            // s = dot(q - v1, r) / dot(r, r)
            Vector2 r = v2 - v1;
            float rr = Vector2.Dot(r, r);
            if (Math.Abs(rr) < MathUtils.Epsilon)
            {
                return false;
            }

            float s = Vector2.Dot(q - v1, r) / rr;
            if (s < 0.0f || 1.0f < s)
            {
                return false;
            }

            output.Fraction = t;
            if (numerator > 0.0f)
            {
                output.Normal = -normal;
            }
            else
            {
                output.Normal = normal;
            }

            return true;
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAABB(out AABB aabb, ref Transform transform, int childIndex)
        {
            // Initialize aabb
            aabb = new AABB();

            // OPT: Vector2 v1 = Transform.Multiply(ref _vertex1, ref transform);
            float v1X = _vertex1.X * transform.q.R - _vertex1.Y * transform.q.i + transform.p.X;
            float v1Y = _vertex1.Y * transform.q.R + _vertex1.X * transform.q.i + transform.p.Y;
            // OPT: Vector2 v2 = Transform.Multiply(ref _vertex2, ref transform);
            float v2X = _vertex2.X * transform.q.R - _vertex2.Y * transform.q.i + transform.p.X;
            float v2Y = _vertex2.Y * transform.q.R + _vertex2.X * transform.q.i + transform.p.Y;

            // OPT: aabb.LowerBound = Vector2.Min(v1, v2);
            // OPT: aabb.UpperBound = Vector2.Max(v1, v2);
            if (v1X < v2X)
            {
                aabb.LowerBound.X = v1X;
                aabb.UpperBound.X = v2X;
            }
            else
            {
                aabb.LowerBound.X = v2X;
                aabb.UpperBound.X = v1X;
            }

            if (v1Y < v2Y)
            {
                aabb.LowerBound.Y = v1Y;
                aabb.UpperBound.Y = v2Y;
            }
            else
            {
                aabb.LowerBound.Y = v2Y;
                aabb.UpperBound.Y = v1Y;
            }

            // OPT: Vector2 r = new Vector2(Radius, Radius);
            // OPT: aabb.LowerBound = aabb.LowerBound - r;
            // OPT: aabb.UpperBound = aabb.LowerBound + r;
            aabb.LowerBound.X -= Radius;
            aabb.LowerBound.Y -= Radius;
            aabb.UpperBound.X += Radius;
            aabb.UpperBound.Y += Radius;
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected override void ComputeProperties()
        {
            MassData.Centroid = 0.5f * (_vertex1 + _vertex2);
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="sc">The sc</param>
        /// <returns>The float</returns>
        public override float ComputeSubmergedArea(ref Vector2 normal, float offset, ref Transform xf, out Vector2 sc)
        {
            sc = Vector2.Zero;
            return 0;
        }

        /// <summary>
        ///     Describes whether this instance compare to
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <returns>The bool</returns>
        public bool CompareTo(EdgeShape shape) => (HasVertex0 == shape.HasVertex0) &&
                                                  (HasVertex3 == shape.HasVertex3) &&
                                                  (Vertex0 == shape.Vertex0) &&
                                                  (Vertex1 == shape.Vertex1) &&
                                                  (Vertex2 == shape.Vertex2) &&
                                                  (Vertex3 == shape.Vertex3);

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            EdgeShape clone = new EdgeShape();
            clone.ShapeType = ShapeType;
            clone._radius = _radius;
            clone._density = _density;
            clone.HasVertex0 = HasVertex0;
            clone.HasVertex3 = HasVertex3;
            clone.Vertex0 = Vertex0;
            clone._vertex1 = _vertex1;
            clone._vertex2 = _vertex2;
            clone.Vertex3 = Vertex3;
            clone.MassData = MassData;
            return clone;
        }
    }
}