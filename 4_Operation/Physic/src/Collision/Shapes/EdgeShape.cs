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
using Alis.Core.Physic.Dynamics;

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
        internal Vector2F Vertex11;

        /// <summary>
        ///     Edge end vertex
        /// </summary>
        internal Vector2F Vertex22;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShape" /> class
        /// </summary>
        internal EdgeShape()
            : base(0)
        {
            ShapeType = ShapeType.Edge;
            Radius = SettingEnv.PolygonRadius;
        }

        /// <summary>
        ///     Create a new EdgeShape with the specified start and end.
        /// </summary>
        /// <param name="start">The start of the edge.</param>
        /// <param name="end">The end of the edge.</param>
        public EdgeShape(Vector2F start, Vector2F end)
            : base(0)
        {
            ShapeType = ShapeType.Edge;
            Radius = SettingEnv.PolygonRadius;
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
        public Vector2F Vertex0 { get; set; }

        /// <summary>
        ///     Optional adjacent vertices. These are used for smooth collision.
        /// </summary>
        public Vector2F Vertex3 { get; set; }

        /// <summary>
        ///     These are the edge vertices
        /// </summary>
        public Vector2F Vertex1
        {
            get => Vertex11;
            set
            {
                Vertex11 = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     These are the edge vertices
        /// </summary>
        public Vector2F Vertex2
        {
            get => Vertex22;
            set
            {
                Vertex22 = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Set this as an isolated edge.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void Set(Vector2F start, Vector2F end)
        {
            Vertex11 = start;
            Vertex22 = end;
            HasVertex0 = false;
            HasVertex3 = false;

            ComputeProperties();
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
            // p = p1 + t * d
            // v = v1 + s * e
            // p1 + t * d = v1 + s * e
            // s * e - t * d = p1 - v1

            output = new RayCastOutput();

            // Put the ray into the edge's frame of reference.
            Vector2F p1 = Complex.Divide(input.Point1 - controllerTransform.Position, ref controllerTransform.Rotation);
            Vector2F p2 = Complex.Divide(input.Point2 - controllerTransform.Position, ref controllerTransform.Rotation);
            Vector2F d = p2 - p1;

            Vector2F v1 = Vertex11;
            Vector2F v2 = Vertex22;
            Vector2F e = v2 - v1;
            Vector2F normal = new Vector2F(e.Y, -e.X);
            normal.Normalize();

            // q = p1 + t * d
            // dot(normal, q - v1) = 0
            // dot(normal, p1 - v1) + t * dot(normal, d) = 0
            float numerator = Vector2F.Dot(normal, v1 - p1);
            float denominator = Vector2F.Dot(normal, d);

            if (Math.Abs(denominator) < MathUtils.Epsilon)
            {
                return false;
            }

            float t = numerator / denominator;
            if (t < 0.0f || input.MaxFraction < t)
            {
                return false;
            }

            Vector2F q = p1 + t * d;

            // q = v1 + s * r
            // s = dot(q - v1, r) / dot(r, r)
            Vector2F r = v2 - v1;
            float rr = Vector2F.Dot(r, r);
            if (Math.Abs(rr) < MathUtils.Epsilon)
            {
                return false;
            }

            float s = Vector2F.Dot(q - v1, r) / rr;
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
        /// <param name="controllerTransform">The transform</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAabb(out Aabb aabb, ref ControllerTransform controllerTransform, int childIndex)
        {
            // Initialize aabb
            aabb = new Aabb();

            // OPT: Vector2F v1 = Transform.Multiply(ref _vertex1, ref transform);
            float v1X = Vertex11.X * controllerTransform.Rotation.R - Vertex11.Y * controllerTransform.Rotation.I + controllerTransform.Position.X;
            float v1Y = Vertex11.Y * controllerTransform.Rotation.R + Vertex11.X * controllerTransform.Rotation.I + controllerTransform.Position.Y;
            // OPT: Vector2F v2 = Transform.Multiply(ref _vertex2, ref transform);
            float v2X = Vertex22.X * controllerTransform.Rotation.R - Vertex22.Y * controllerTransform.Rotation.I + controllerTransform.Position.X;
            float v2Y = Vertex22.Y * controllerTransform.Rotation.R + Vertex22.X * controllerTransform.Rotation.I + controllerTransform.Position.Y;

            // OPT: aabb.LowerBound = Vector2F.Min(v1, v2);
            // OPT: aabb.UpperBound = Vector2F.Max(v1, v2);
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

            // OPT: Vector2F r = new Vector2F(Radius, Radius);
            // OPT: aabb.LowerBound = aabb.LowerBound - r;
            // OPT: aabb.UpperBound = aabb.LowerBound + r;
            aabb.LowerBound.X -= GetRadius;
            aabb.LowerBound.Y -= GetRadius;
            aabb.UpperBound.X += GetRadius;
            aabb.UpperBound.Y += GetRadius;
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected override void ComputeProperties()
        {
            MassData.Centroid = 0.5f * (Vertex11 + Vertex22);
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
            clone.Radius = Radius;
            clone.Density = Density;
            clone.HasVertex0 = HasVertex0;
            clone.HasVertex3 = HasVertex3;
            clone.Vertex0 = Vertex0;
            clone.Vertex11 = Vertex11;
            clone.Vertex22 = Vertex22;
            clone.Vertex3 = Vertex3;
            clone.MassData = MassData;
            return clone;
        }
    }
}