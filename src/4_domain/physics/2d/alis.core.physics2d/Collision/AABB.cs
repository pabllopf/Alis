// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AABB.cs
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

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     An axis aligned bounding box.
    /// </summary>
    public struct AABB
    {
        /// <summary>
        ///     The lower vertex
        /// </summary>
        internal Vector2 lowerBound;

        /// <summary>
        ///     The upper vertex
        /// </summary>
        internal Vector2 upperBound;

        /// <summary>
        ///     Gets the value of the lower bound
        /// </summary>
        public Vector2 LowerBound
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => lowerBound;
        }

        /// <summary>
        ///     Gets the value of the upper bound
        /// </summary>
        public Vector2 UpperBound
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => upperBound;
        }

        /// <summary>
        ///     Gets the value of the size
        /// </summary>
        public Vector2 Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => upperBound - lowerBound;
        }

        /// Get the center of the AABB.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetCenter() => 0.5f * (lowerBound + upperBound);

        /// Get the extents of the AABB (half-widths).
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetExtents() => 0.5f * (upperBound - lowerBound);

        /// Get the perimeter length
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal float GetPerimeter()
        {
            float wx = upperBound.X - lowerBound.X;
            float wy = upperBound.Y - lowerBound.Y;
            return 2.0f * (wx + wy);
        }

        /// Combine an AABB into this one.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Combine(in AABB aabb)
        {
            lowerBound = Vector2.Min(lowerBound, aabb.lowerBound);
            upperBound = Vector2.Max(upperBound, aabb.upperBound);
        }

        /// Combine two AABBs into this one.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static AABB Combine(in AABB aabb1, in AABB aabb2)
        {
            AABB result = default(AABB);
            result.lowerBound = Vector2.Min(aabb1.lowerBound, aabb2.lowerBound);
            result.upperBound = Vector2.Max(aabb1.upperBound, aabb2.upperBound);
            return result;
        }

        /// <summary>
        ///     Enlargeds the amount
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>The aabb</returns>
        internal AABB Enlarged(float amount)
        {
            Vector2 vecAmt = new Vector2(amount);
            return new AABB(lowerBound - vecAmt, upperBound + vecAmt);
        }

        /// <summary>
        ///     Describes whether this instance intersects
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        internal bool Intersects(in AABB other) =>
            other.lowerBound.Y <= upperBound.Y &&
            other.upperBound.Y >= lowerBound.Y &&
            other.upperBound.X >= lowerBound.X &&
            other.lowerBound.X <= upperBound.X;

        /// Does this aabb contain the provided AABB.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool Contains(in AABB aabb)
        {
            bool result = true;
            result = result && lowerBound.X <= aabb.lowerBound.X;
            result = result && lowerBound.Y <= aabb.lowerBound.Y;
            result = result && aabb.upperBound.X <= upperBound.X;
            result = result && aabb.upperBound.Y <= upperBound.Y;
            return result;
        }

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <returns>The bool</returns>
        private bool RayCast(out RayCastOutput output, in RayCastInput input)
        {
            output = default(RayCastOutput);
            float tmin = float.MinValue;
            float tmax = float.MaxValue;

            Vector2 p = input.p1;
            Vector2 d = input.p2 - input.p1;
            Vector2 absD = Vector2.Abs(d);

            Vector2 normal = Vector2.Zero;

            for (int i = 0; i < 2; ++i)
            {
                if (absD.GetIdx(i) < Settings.FLT_EPSILON)
                {
                    // Parallel.
                    if (p.GetIdx(i) < lowerBound.GetIdx(i) || upperBound.GetIdx(i) < p.GetIdx(i))
                    {
                        return false;
                    }
                }
                else
                {
                    float inv_d = 1.0f / d.GetIdx(i);
                    float t1 = (lowerBound.GetIdx(i) - p.GetIdx(i)) * inv_d;
                    float t2 = (upperBound.GetIdx(i) - p.GetIdx(i)) * inv_d;

                    // Sign of the normal vector.
                    float s = -1.0f;

                    if (t1 > t2)
                    {
                        float temp = t1;
                        t1 = t2;
                        t2 = temp;
                        s = 1.0f;
                    }

                    // Push the min up
                    if (t1 > tmin)
                    {
                        normal = new Vector2(i == 0 ? s : 0, i == 1 ? s : 0);
                        tmin = t1;
                    }

                    // Pull the max down
                    tmax = MathF.Min(tmax, t2);

                    if (tmin > tmax)
                    {
                        return false;
                    }
                }
            }

            // Does the ray start inside the box?
            // Does the ray intersect beyond the max fraction?
            if (tmin < 0.0f || input.maxFraction < tmin)
            {
                return false;
            }

            // Intersection.
            output.fraction = tmin;
            output.normal = normal;
            return true;
        }

        /// <summary>
        ///     Describes whether this instance is valid
        /// </summary>
        /// <returns>The valid</returns>
        private bool IsValid()
        {
            Vector2 d = upperBound - lowerBound;
            bool valid = d.X >= 0.0f && d.Y >= 0.0f;
            valid = valid && lowerBound.IsValid() && upperBound.IsValid();
            return valid;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AABB" /> class
        /// </summary>
        /// <param name="lowerBound">The lower bound</param>
        /// <param name="upperBound">The upper bound</param>
        public AABB(Vector2 lowerBound, Vector2 upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }
    }
}