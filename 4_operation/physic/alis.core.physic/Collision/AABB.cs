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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     An axis aligned bounding box.
    /// </summary>
    public struct Aabb
    {
        /// <summary>
        ///     The lower vertex.
        /// </summary>
        public Vector2 LowerBound;

        /// <summary>
        ///     The upper vertex.
        /// </summary>
        public Vector2 UpperBound;

        /// Verify that the bounds are sorted.
        public bool IsValid
        {
            get
            {
                Vector2 d = UpperBound - LowerBound;
                bool valid = d.X >= 0.0f && d.Y >= 0.0f;
                valid = valid && LowerBound.IsValid && UpperBound.IsValid;
                return valid;
            }
        }

        /// Get the center of the AABB.
        public Vector2 Center => 0.5f * (LowerBound + UpperBound);

        /// Get the extents of the AABB (half-widths).
        public Vector2 Extents => 0.5f * (UpperBound - LowerBound);

        /// Combine two AABBs into this one.
        public void Combine(Aabb aabb1, Aabb aabb2)
        {
            LowerBound = Math.Min(aabb1.LowerBound, aabb2.LowerBound);
            UpperBound = Math.Max(aabb1.UpperBound, aabb2.UpperBound);
        }

        /// Does this aabb contain the provided AABB.
        public bool Contains(Aabb aabb)
        {
            bool result = LowerBound.X <= aabb.LowerBound.X;
            result = result && LowerBound.Y <= aabb.LowerBound.Y;
            result = result && aabb.UpperBound.X <= UpperBound.X;
            result = result && aabb.UpperBound.Y <= UpperBound.Y;
            return result;
        }

        /// <summary>
        ///     hello
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        public void RayCast(out RayCastOutput output, RayCastInput input)
        {
            float tmin = -Settings.FltMax;
            float tmax = Settings.FltMax;

            output = new RayCastOutput();

            output.Hit = false;

            Vector2 p = input.P1;
            Vector2 d = input.P2 - input.P1;
            Vector2 absD = Math.Abs(d);

            Vector2 normal = new Vector2(0);

            for (int i = 0; i < 2; ++i)
            {
                if (absD[i] < Settings.FltEpsilon)
                {
                    // Parallel.
                    if (p[i] < LowerBound[i] || UpperBound[i] < p[i])
                    {
                        return;
                    }
                }
                else
                {
                    float invD = 1.0f / d[i];
                    float t1 = (LowerBound[i] - p[i]) * invD;
                    float t2 = (UpperBound[i] - p[i]) * invD;

                    // Sign of the normal vector.
                    float s = -1.0f;

                    if (t1 > t2)
                    {
                        Math.Swap(ref t1, ref t2);
                        s = 1.0f;
                    }

                    // Push the min up
                    if (t1 > tmin)
                    {
                        normal.SetZero();
                        normal[i] = s;
                        tmin = t1;
                    }

                    // Pull the max down
                    tmax = Math.Min(tmax, t2);

                    if (tmin > tmax)
                    {
                        return;
                    }
                }
            }

            // Does the ray start inside the box?
            // Does the ray intersect beyond the max fraction?
            if (tmin < 0.0f || input.MaxFraction < tmin)
            {
                return;
            }

            // Intersection.
            output.Fraction = tmin;
            output.Normal = normal;
            output.Hit = true;
        }
    }
}