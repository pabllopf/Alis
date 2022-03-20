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

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Common;

namespace Alis.Core.Physics2D.Collision.Shapes
{
    /// <summary>
    ///     A circle shape.
    /// </summary>
    public class CircleShape : Shape
    {
        /// <summary>
        /// The 
        /// </summary>
        internal Vector2 m_p;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleShape"/> class
        /// </summary>
        public CircleShape()
        {
            m_radius = 0;
            m_p = Vector2.Zero;
        }

        /// <summary>
        /// Gets or sets the value of the center
        /// </summary>
        public Vector2 Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_p;
            set => m_p = value;
        }

        /// <summary>
        /// Gets or sets the value of the radius
        /// </summary>
        public float Radius
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_radius;
            set => m_radius = value;
        }

        /// <summary>
        /// Gets the value of the contact match
        /// </summary>
        internal override byte ContactMatch => contactMatch;
        /// <summary>
        /// The contact match
        /// </summary>
        internal const byte contactMatch = 0;

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The shape</returns>
        public override Shape Clone() => (CircleShape) MemberwiseClone();

        /// <summary>
        /// Gets the child count
        /// </summary>
        /// <returns>The int</returns>
        public override int GetChildCount() => 1;

        /// <summary>
        /// Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public override bool TestPoint(in Transform transform, in Vector2 p)
        {
            Vector2 center = transform.p + Vector2.Transform(m_p, transform.q); //   Math.Mul(transform.q, m_p);
            Vector2 d = p - center;
            return Vector2.Dot(d, d) <= m_radius * m_radius;
        }

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
            output = default(RayCastOutput);

            Vector2 position = transform.p + Vector2.Transform(m_p, transform.q); // Math.Mul(transform.q, m_p);
            Vector2 s = input.p1 - position;
            float b = Vector2.Dot(s, s) - m_radius * m_radius;

            // Solve quadratic equation.
            Vector2 r = input.p2 - input.p1;
            float c = Vector2.Dot(s, r);
            float rr = Vector2.Dot(r, r);
            float sigma = c * c - rr * b;

            // Check for negative discriminant and short segment.
            if (sigma < 0.0f || rr < Settings.FLT_EPSILON)
            {
                return false;
            }

            // Find the point of intersection of the line with the circle.
            float a = -(c + MathF.Sqrt(sigma));

            // Is the intersection point on the segment?
            if (0.0f <= a && a <= input.maxFraction * rr)
            {
                a /= rr;
                output.fraction = a;
                output.normal = Vector2.Normalize(s + a * r);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        public override void ComputeAABB(out AABB aabb, in Transform transform, int childIndex)
        {
            Vector2 p = transform.p + Vector2.Transform(m_p, transform.q); // Math.Mul(transform.q, m_p);
            aabb.lowerBound = new Vector2(p.X - m_radius, p.Y - m_radius);
            aabb.upperBound = new Vector2(p.X + m_radius, p.Y + m_radius);
        }

        /// <summary>
        /// Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="density">The density</param>
        public override void ComputeMass(out MassData massData, float density)
        {
            massData.mass = density * Settings.Pi * m_radius * m_radius;
            massData.center = m_p;

            // inertia about the local origin
            massData.I = massData.mass * (0.5f * m_radius * m_radius + Vector2.Dot(m_p, m_p));
        }

        /// <summary>
        /// Sets the center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        public void Set(in Vector2 center, in float radius)
        {
            m_p = center;
            m_radius = radius;
        }
    }
}