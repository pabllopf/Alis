// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AABB.cs
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

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     An axis aligned bounding box.
    /// </summary>
    public struct Aabb
    {
        /// <summary>
        ///     The lower vertex
        /// </summary>
        public Vector2F LowerBound;

        /// <summary>
        ///     The upper vertex
        /// </summary>
        public Vector2F UpperBound;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        public Aabb(Vector2F min, Vector2F max)
            : this(ref min, ref max)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        public Aabb(ref Vector2F min, ref Vector2F max)
        {
            LowerBound = min;
            UpperBound = max;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Aabb(Vector2F center, float width, float height)
        {
            LowerBound = center - new Vector2F(width / 2, height / 2);
            UpperBound = center + new Vector2F(width / 2, height / 2);
        }

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        public float Width => UpperBound.X - LowerBound.X;

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        public float Height => UpperBound.Y - LowerBound.Y;

        /// <summary>
        ///     Get the center of the AABB.
        /// </summary>
        public Vector2F Center => 0.5f * (LowerBound + UpperBound);

        /// <summary>
        ///     Get the extents of the AABB (half-widths).
        /// </summary>
        public Vector2F Extents => 0.5f * (UpperBound - LowerBound);

        /// <summary>
        ///     Get the perimeter length
        /// </summary>
        public float Perimeter
        {
            get
            {
                float wx = UpperBound.X - LowerBound.X;
                float wy = UpperBound.Y - LowerBound.Y;
                return 2.0f * (wx + wy);
            }
        }

        /// <summary>
        ///     Gets the vertices of the AABB.
        /// </summary>
        /// <value>The corners of the AABB</value>
        public Vertices Vertices
        {
            get
            {
                Vertices vertices = new Vertices(4);
                vertices.Add(UpperBound);
                vertices.Add(new Vector2F(UpperBound.X, LowerBound.Y));
                vertices.Add(LowerBound);
                vertices.Add(new Vector2F(LowerBound.X, UpperBound.Y));
                return vertices;
            }
        }

        /// <summary>
        ///     First quadrant
        /// </summary>
        public Aabb Q1 => new Aabb(Center, UpperBound);

        /// <summary>
        ///     Second quadrant
        /// </summary>
        public Aabb Q2 => new Aabb(new Vector2F(LowerBound.X, Center.Y), new Vector2F(Center.X, UpperBound.Y));

        /// <summary>
        ///     Third quadrant
        /// </summary>
        public Aabb Q3 => new Aabb(LowerBound, Center);

        /// <summary>
        ///     Forth quadrant
        /// </summary>
        public Aabb Q4 => new Aabb(new Vector2F(Center.X, LowerBound.Y), new Vector2F(UpperBound.X, Center.Y));

        /// <summary>
        ///     Verify that the bounds are sorted. And the bounds are valid numbers (not NaN).
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            Vector2F d = UpperBound - LowerBound;
            bool valid = (d.X >= 0.0f) && (d.Y >= 0.0f);
            valid = valid && LowerBound.IsValid() && UpperBound.IsValid();
            return valid;
        }

        /// <summary>
        ///     Combine an AABB into this one.
        /// </summary>
        /// <param name="aabb">The aabb.</param>
        public void Combine(ref Aabb aabb)
        {
            Vector2F.Min(ref LowerBound, ref aabb.LowerBound, out LowerBound);
            Vector2F.Max(ref UpperBound, ref aabb.UpperBound, out UpperBound);
        }

        /// <summary>
        ///     Combine two AABBs into this one.
        /// </summary>
        /// <param name="aabb1">The aabb1.</param>
        /// <param name="aabb2">The aabb2.</param>
        public void Combine(ref Aabb aabb1, ref Aabb aabb2)
        {
            Vector2F.Min(ref aabb1.LowerBound, ref aabb2.LowerBound, out LowerBound);
            Vector2F.Max(ref aabb1.UpperBound, ref aabb2.UpperBound, out UpperBound);
        }

        /// <summary>
        ///     Does this aabb contain the provided AABB.
        /// </summary>
        /// <param name="aabb">The aabb.</param>
        /// <returns>
        ///     <c>true</c> if it contains the specified aabb; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(ref Aabb aabb)
        {
            bool result = true;
            result = result && (LowerBound.X <= aabb.LowerBound.X);
            result = result && (LowerBound.Y <= aabb.LowerBound.Y);
            result = result && (aabb.UpperBound.X <= UpperBound.X);
            result = result && (aabb.UpperBound.Y <= UpperBound.Y);
            return result;
        }

        /// <summary>
        ///     Determines whether the AAABB contains the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///     <c>true</c> if it contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(ref Vector2F point) =>
            //using epsilon to try and gaurd against float rounding errors.
            (point.X > LowerBound.X + SettingEnv.Epsilon) && (point.X < UpperBound.X - SettingEnv.Epsilon) &&
            (point.Y > LowerBound.Y + SettingEnv.Epsilon) && (point.Y < UpperBound.Y - SettingEnv.Epsilon);

        /// <summary>
        ///     Test if the two AABBs overlap.
        /// </summary>
        /// <param name="a">The first AABB.</param>
        /// <param name="b">The second AABB.</param>
        /// <returns>True if they are overlapping.</returns>
        public static bool TestOverlap(ref Aabb a, ref Aabb b)
        {
            if (b.LowerBound.X > a.UpperBound.X || b.LowerBound.Y > a.UpperBound.Y)
            {
                return false;
            }

            if (a.LowerBound.X > b.UpperBound.X || a.LowerBound.Y > b.UpperBound.Y)
            {
                return false;
            }

            return true;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="output"></param>
      /// <param name="input"></param>
      /// <param name="doInteriorCheck"></param>
      /// <returns></returns>
        public bool RayCast(out RayCastOutput output, ref RayCastInput input, bool doInteriorCheck = true)
        {
            // From Real-time Collision Detection, p179.

            output = new RayCastOutput();

            float tmin = -SettingEnv.MaxFloat;
            float tmax = SettingEnv.MaxFloat;

            Vector2F p = input.Point1;
            Vector2F d = input.Point2 - input.Point1;
            Vector2F absD = MathUtils.Abs(d);

            Vector2F normal = Vector2F.Zero;

            for (int i = 0; i < 2; ++i)
            {
                float absDi = i == 0 ? absD.X : absD.Y;
                float lowerBoundI = i == 0 ? LowerBound.X : LowerBound.Y;
                float upperBoundI = i == 0 ? UpperBound.X : UpperBound.Y;
                float pI = i == 0 ? p.X : p.Y;

                if (absDi < SettingEnv.Epsilon)
                {
                    // Parallel.
                    if (pI < lowerBoundI || upperBoundI < pI)
                    {
                        return false;
                    }
                }
                else
                {
                    float dI = i == 0 ? d.X : d.Y;

                    float invD = 1.0f / dI;
                    float t1 = (lowerBoundI - pI) * invD;
                    float t2 = (upperBoundI - pI) * invD;

                    // Sign of the normal vector.
                    float s = -1.0f;

                    if (t1 > t2)
                    {
                        MathUtils.Swap(ref t1, ref t2);
                        s = 1.0f;
                    }

                    // Push the min up
                    if (t1 > tmin)
                    {
                        if (i == 0)
                        {
                            normal.X = s;
                        }
                        else
                        {
                            normal.Y = s;
                        }

                        tmin = t1;
                    }

                    // Pull the max down
                    tmax = Math.Min(tmax, t2);

                    if (tmin > tmax)
                    {
                        return false;
                    }
                }
            }

            // Does the ray start inside the box?
            // Does the ray intersect beyond the max fraction?
            if (doInteriorCheck && (tmin < 0.0f || input.MaxFraction < tmin))
            {
                return false;
            }

            // Intersection.
            output.Fraction = tmin;
            output.Normal = normal;
            return true;
        }
    }
}