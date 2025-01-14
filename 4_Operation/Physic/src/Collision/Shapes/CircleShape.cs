// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleShape.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A circle shape.
    /// </summary>
    public class CircleShape : Shape
    {
        /// <summary>
        ///     The position
        /// </summary>
        internal Vector2F PositionInternal;

        /// <summary>
        ///     Create a new circle with the desired radius and density.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="density">The density of the circle.</param>
        public CircleShape(float radius, float density)
            : base(density)
        {
            Debug.Assert(radius >= 0);
            Debug.Assert(density >= 0);

            ShapeType = ShapeType.Circle;
            PositionInternal = Vector2F.Zero;
            GetRadius = radius; // The Radius property cache 2radius and calls ComputeProperties(). So no need to call ComputeProperties() here.
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShape" /> class
        /// </summary>
        internal CircleShape()
            : base(0)
        {
            ShapeType = ShapeType.Circle;
            Radius = 0.0f;
            PositionInternal = Vector2F.Zero;
        }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount => 1;

        /// <summary>
        ///     Get or set the position of the circle
        /// </summary>
        public Vector2F Position
        {
            get => PositionInternal;
            set
            {
                PositionInternal = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2F point)
        {
            Vector2F center = transform.p + Complex.Multiply(ref PositionInternal, ref transform.q);
            Vector2F d = point - center;
            return Vector2F.Dot(d, d) <= _2radius;
        }

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
            // Collision Detection in Interactive 3D Environments by Gino van den Bergen
            // From Section 3.1.2
            // x = s + a * r
            // norm(x) = radius

            output = new RayCastOutput();

            Vector2F position = transform.p + Complex.Multiply(ref PositionInternal, ref transform.q);
            Vector2F s = input.Point1 - position;
            float b = Vector2F.Dot(s, s) - _2radius;

            // Solve quadratic equation.
            Vector2F r = input.Point2 - input.Point1;
            float c = Vector2F.Dot(s, r);
            float rr = Vector2F.Dot(r, r);
            float sigma = c * c - rr * b;

            // Check for negative discriminant and short segment.
            if (sigma < 0.0f || rr < SettingEnv.Epsilon)
            {
                return false;
            }

            // Find the point of intersection of the line with the circle.
            float a = -(c + (float) Math.Sqrt(sigma));

            // Is the intersection point on the segment?
            if ((0.0f <= a) && (a <= input.MaxFraction * rr))
            {
                a /= rr;
                output.Fraction = a;


                output.Normal = s + a * r;
                output.Normal.Normalize();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAabb(out Aabb aabb, ref Transform transform, int childIndex)
        {
            // OPT: Vector2F p = transform.p + Complex.Multiply(ref _position, ref transform.q);
            float pX = PositionInternal.X * transform.q.R - PositionInternal.Y * transform.q.I + transform.p.X;
            float pY = PositionInternal.Y * transform.q.R + PositionInternal.X * transform.q.I + transform.p.Y;

            // OPT: aabb.LowerBound = new Vector2F(p.X - Radius, p.Y - Radius);
            // OPT: aabb.UpperBound = new Vector2F(p.X + Radius, p.Y + Radius);
            aabb.LowerBound = new Vector2F(pX - GetRadius, pY - GetRadius);

            aabb.UpperBound = new Vector2F(pX + GetRadius, pY + GetRadius);
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected sealed override void ComputeProperties()
        {
            float area = Constant.Pi * _2radius;
            MassData.Area = area;
            MassData.Mass = GetDensity * area;
            MassData.Centroid = Position;

            // inertia about the local origin
            MassData.Inertia = MassData.Mass * (0.5f * _2radius + Vector2F.Dot(Position, Position));
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="sc">The sc</param>
        /// <returns>The area</returns>
        public override float ComputeSubmergedArea(ref Vector2F normal, float offset, ref Transform xf, out Vector2F sc)
        {
            sc = Vector2F.Zero;

            Vector2F p = Transform.Multiply(ref PositionInternal, ref xf);
            float l = -(Vector2F.Dot(normal, p) - offset);
            if (l < -GetRadius + SettingEnv.Epsilon)
            {
                //Completely dry
                return 0;
            }

            if (l > GetRadius)
            {
                //Completely wet
                sc = p;
                return Constant.Pi * _2radius;
            }

            //Magic
            float l2 = l * l;
            float area = _2radius * (float) (Math.Asin(l / GetRadius) + Constant.Pi / 2 + l * Math.Sqrt(_2radius - l2));
            float com = -2.0f / 3.0f * (float) Math.Pow(_2radius - l2, 1.5f) / area;

            sc.X = p.X + normal.X * com;
            sc.Y = p.Y + normal.Y * com;

            return area;
        }

        /// <summary>
        ///     Compare the circle to another circle
        /// </summary>
        /// <param name="shape">The other circle</param>
        /// <returns>True if the two circles are the same size and have the same position</returns>
        public bool CompareTo(CircleShape shape) => (Math.Abs(GetRadius - shape.GetRadius) < MathUtils.Epsilon) && (Position == shape.Position);

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            CircleShape clone = new CircleShape();
            clone.ShapeType = ShapeType;
            clone.Radius = GetRadius;
            clone._2radius = _2radius; //FPE note: We also copy the cache
            clone.Density = Density;
            clone.PositionInternal = PositionInternal;
            clone.MassData = MassData;
            return clone;
        }
    }
}