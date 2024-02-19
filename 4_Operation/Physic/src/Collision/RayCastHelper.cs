// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastHelper.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The ray cast helper class
    /// </summary>
    public static class RayCastHelper
    {
        /// <summary>
        ///     Describes whether ray cast edge
        ///     p = p1 + t * d
        ///     v = v1 + s * e
        ///     p1 + t * d = v1 + s * e
        ///     s * e - t * d = p1 - v1
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <param name="oneSided">The one sided</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public static bool RayCastEdge(ref Vector2 start, ref Vector2 end, bool oneSided, ref RayCastInput input,
            ref Transform transform, out RayCastOutput output)
        {
            output = new RayCastOutput();

            // Put the ray into the edge's frame of reference.
            Vector2 p1 = MathUtils.MulT(transform.Rotation, input.Point1 - transform.Position);
            Vector2 p2 = MathUtils.MulT(transform.Rotation, input.Point2 - transform.Position);
            Vector2 d = p2 - p1;

            Vector2 v1 = start;
            Vector2 v2 = end;
            Vector2 e = v2 - v1;

            // Normal points to the right, looking from v1 at v2
            Vector2 normal = new Vector2(e.Y, -e.X);
            normal = Vector2.Normalize(normal);

            // q = p1 + t * d
            // dot(normal, q - v1) = 0
            // dot(normal, p1 - v1) + t * dot(normal, d) = 0
            float numerator = Vector2.Dot(normal, v1 - p1);
            if (oneSided && (numerator > 0.0f))
            {
                return false;
            }

            float denominator = Vector2.Dot(normal, d);

            if (denominator == 0.0f)
            {
                return false;
            }

            float t = numerator / denominator;
            if (t < 0.0f || input.Fraction < t)
            {
                return false;
            }

            Vector2 q = p1 + t * d;

            // q = v1 + s * r
            // s = dot(q - v1, r) / dot(r, r)
            Vector2 r = v2 - v1;
            float rr = Vector2.Dot(r, r);
            if (rr == 0.0f)
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
                output.Normal = -MathUtils.MulT(transform.Rotation, normal);
            }
            else
            {
                output.Normal = MathUtils.MulT(transform.Rotation, normal);
            }

            return true;
        }

        /// <summary>
        ///     Describes whether ray cast circle
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="radius">The radius</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public static bool RayCastCircle(ref Vector2 pos, float radius, ref RayCastInput input, ref Transform transform,
            out RayCastOutput output)
        {
            // Collision Detection in Interactive 3D Environments by Gino van den Bergen
            // From Section 3.1.2
            // x = s + a * r
            // norm(x) = radius

            output = new RayCastOutput();

            Vector2 position = transform.Position + MathUtils.Mul(transform.Rotation, pos);
            Vector2 s = input.Point1 - position;
            float b = Vector2.Dot(s, s) - radius * radius;

            // Solve quadratic equation.
            Vector2 r = input.Point2 - input.Point1;
            float c = Vector2.Dot(s, r);
            float rr = Vector2.Dot(r, r);
            float sigma = c * c - rr * b;

            // Check for negative discriminant and short segment.
            if (sigma < 0.0f || rr < Constant.Epsilon)
            {
                return false;
            }

            // Find the point of intersection of the line with the circle.
            float a = -(c + (float) Math.Sqrt(sigma));

            // Is the intersection point on the segment?
            if ((0.0f <= a) && (a <= input.Fraction * rr))
            {
                a /= rr;
                output.Fraction = a;
                output.Normal = s + a * r;
                output.Normal = Vector2.Normalize(output.Normal);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether ray cast polygon
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="normals">The normals</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public static bool RayCastPolygon(Vertices vertices, Vertices normals, ref RayCastInput input,
            ref Transform transform, out RayCastOutput output)
        {
            output = new RayCastOutput();

            Vector2 p1 = TransformPoint(input.Point1, transform);
            Vector2 p2 = TransformPoint(input.Point2, transform);
            Vector2 d = p2 - p1;

            float lower = 0.0f, upper = input.Fraction;
            int index = -1;

            for (int i = 0; i < vertices.Count; ++i)
            {
                float numerator = CalculateNumerator(i, vertices, normals, p1);
                float denominator = CalculateDenominator(i, normals, d);

                if (!ProcessDenominator(ref lower, ref upper, ref index, i, numerator, denominator))
                {
                    return false;
                }
            }

            Debug.Assert((0.0f <= lower) && (lower <= input.Fraction));

            if (index >= 0)
            {
                output.Fraction = lower;
                output.Normal = MathUtils.Mul(transform.Rotation, normals[index]);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Transforms the point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="transform">The transform</param>
        /// <returns>The vector</returns>
        private static Vector2 TransformPoint(Vector2 point, Transform transform) => MathUtils.MulT(transform.Rotation, point - transform.Position);

        /// <summary>
        ///     Calculates the numerator using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="vertices">The vertices</param>
        /// <param name="normals">The normals</param>
        /// <param name="p1">The </param>
        /// <returns>The float</returns>
        private static float CalculateNumerator(int i, Vertices vertices, Vertices normals, Vector2 p1) => Vector2.Dot(normals[i], vertices[i] - p1);

        /// <summary>
        ///     Calculates the denominator using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="normals">The normals</param>
        /// <param name="d">The </param>
        /// <returns>The float</returns>
        private static float CalculateDenominator(int i, Vertices normals, Vector2 d) => Vector2.Dot(normals[i], d);

        /// <summary>
        ///     Describes whether process denominator
        /// </summary>
        /// <param name="lower">The lower</param>
        /// <param name="upper">The upper</param>
        /// <param name="index">The index</param>
        /// <param name="i">The </param>
        /// <param name="numerator">The numerator</param>
        /// <param name="denominator">The denominator</param>
        /// <returns>The bool</returns>
        private static bool ProcessDenominator(ref float lower, ref float upper, ref int index, int i, float numerator, float denominator)
        {
            if (denominator == 0.0f)
            {
                if (numerator < 0.0f)
                {
                    return false;
                }
            }
            else
            {
                if ((denominator < 0.0f) && (numerator < lower * denominator))
                {
                    lower = numerator / denominator;
                    index = i;
                }
                else if ((denominator > 0.0f) && (numerator < upper * denominator))
                {
                    upper = numerator / denominator;
                }
            }

            return upper >= lower;
        }
    }
}