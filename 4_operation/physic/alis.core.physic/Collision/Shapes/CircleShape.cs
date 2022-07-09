// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CircleShape.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A circle shape.
    /// </summary>
    public class CircleShape : Shape
    {
        // Position
        /// <summary>
        ///     The position
        /// </summary>
        internal Vec2 Position;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShape" /> class
        /// </summary>
        public CircleShape()
        {
            Type = ShapeType.CircleShape;
        }

        /// <summary>
        ///     Get the vertex count.
        /// </summary>
        public int VertexCount => 1;

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public override bool TestPoint(XForm transform, Vec2 p)
        {
            Vec2 center = transform.Position + Math.Mul(transform.R, Position);
            Vec2 d = p - center;
            return Vec2.Dot(d, d) <= Radius * Radius;
        }

        // Collision Detection in Interactive 3D Environments by Gino van den Bergen
        // From Section 3.1.2
        // x = s + a * r
        // norm(x) = radius
        /// <summary>
        ///     Tests the segment using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="lambda">The lambda</param>
        /// <param name="normal">The normal</param>
        /// <param name="segment">The segment</param>
        /// <param name="maxLambda">The max lambda</param>
        /// <returns>The segment collide</returns>
        public override SegmentCollide TestSegment(XForm transform, out float lambda, out Vec2 normal, Segment segment,
            float maxLambda)
        {
            lambda = 0f;
            normal = Vec2.Zero;

            Vec2 position = transform.Position + Math.Mul(transform.R, Position);
            Vec2 s = segment.P1 - position;
            float b = Vec2.Dot(s, s) - Radius * Radius;

            // Does the segment start inside the circle?
            if (b < 0.0f)
            {
                lambda = 0f;
                return SegmentCollide.StartInsideCollide;
            }

            // Solve quadratic equation.
            Vec2 r = segment.P2 - segment.P1;
            float c = Vec2.Dot(s, r);
            float rr = Vec2.Dot(r, r);
            float sigma = c * c - rr * b;

            // Check for negative discriminant and short segment.
            if (sigma < 0.0f || rr < Settings.FltEpsilon)
            {
                return SegmentCollide.MissCollide;
            }

            // Find the point of intersection of the line with the circle.
            float a = -(c + Math.Sqrt(sigma));

            // Is the intersection point on the segment?
            if (0.0f <= a && a <= maxLambda * rr)
            {
                a /= rr;
                lambda = a;
                normal = s + a * r;
                normal.Normalize();
                return SegmentCollide.HitCollide;
            }

            return SegmentCollide.MissCollide;
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="transform">The transform</param>
        public override void ComputeAabb(out Aabb aabb, XForm transform)
        {
            aabb = new Aabb();

            Vec2 p = transform.Position + Math.Mul(transform.R, Position);
            aabb.LowerBound.Set(p.X - Radius, p.Y - Radius);
            aabb.UpperBound.Set(p.X + Radius, p.Y + Radius);
        }

        /// <summary>
        ///     Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="density">The density</param>
        public override void ComputeMass(out MassData massData, float density)
        {
            massData = new MassData();

            massData.Mass = density * Settings.Pi * Radius * Radius;
            massData.Center = Position;

            // inertia about the local origin
            massData.I = massData.Mass * (0.5f * Radius * Radius + Vec2.Dot(Position, Position));
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="c">The </param>
        /// <returns>The area</returns>
        public override float ComputeSubmergedArea(Vec2 normal, float offset, XForm xf, out Vec2 c)
        {
            Vec2 p = Math.Mul(xf, Position);
            float l = -(Vec2.Dot(normal, p) - offset);
            if (l < -Radius + Settings.FltEpsilon)
            {
                //Completely dry
                c = new Vec2();
                return 0;
            }

            if (l > Radius)
            {
                //Completely wet
                c = p;
                return Settings.Pi * Radius * Radius;
            }

            //Magic
            float r2 = Radius * Radius;
            float l2 = l * l;
            float area = r2 * ((float) System.Math.Asin(l / Radius) + Settings.Pi / 2) +
                         l * Math.Sqrt(r2 - l2);
            float com = -2.0f / 3.0f * (float) System.Math.Pow(r2 - l2, 1.5f) / area;

            c.X = p.X + normal.X * com;
            c.Y = p.Y + normal.Y * com;

            return area;
        }

        /// <summary>
        ///     Get the supporting vertex index in the given direction.
        /// </summary>
        public override int GetSupport(Vec2 d)
        {
            return 0;
        }

        /// <summary>
        ///     Get the supporting vertex in the given direction.
        /// </summary>
        public override Vec2 GetSupportVertex(Vec2 d)
        {
            return Position;
        }

        /// <summary>
        ///     Get a vertex by index. Used by Distance.
        /// </summary>
        public override Vec2 GetVertex(int index)
        {
            Box2DXDebug.Assert(index == 0);
            return Position;
        }

        /// <summary>
        ///     Computes the sweep radius using the specified pivot
        /// </summary>
        /// <param name="pivot">The pivot</param>
        /// <returns>The float</returns>
        public override float ComputeSweepRadius(Vec2 pivot)
        {
            return Vec2.Distance(Position, pivot);
        }
    }
}