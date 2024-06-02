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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Shared
{
    /// <summary>An axis aligned bounding box.</summary>
    public struct Aabb
    {
        /// <summary>The lower vertex</summary>
        public Vector2 LowerBound;
        
        /// <summary>The upper vertex</summary>
        public Vector2 UpperBound;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        public Aabb(Vector2 min, Vector2 max)
            : this(ref min, ref max)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Aabb(Vector2 center, float width, float height)
            : this(center - new Vector2(width / 2, height / 2), center + new Vector2(width / 2, height / 2))
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Aabb" /> class
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        public Aabb(ref Vector2 min, ref Vector2 max)
        {
            LowerBound = new Vector2(Math.Min(min.X, max.X), Math.Min(min.Y, max.Y));
            UpperBound = new Vector2(Math.Max(min.X, max.X), Math.Max(min.Y, max.Y));
        }
        
        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        public float Width => UpperBound.X - LowerBound.X;
        
        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        public float Height => UpperBound.Y - LowerBound.Y;
        
        /// <summary>Get the center of the AABB.</summary>
        public Vector2 Center => 0.5f * (LowerBound + UpperBound);
        
        /// <summary>Get the extents of the AABB (half-widths).</summary>
        public Vector2 Extents => 0.5f * (UpperBound - LowerBound);
        
        /// <summary>Get the perimeter length</summary>
        public float Perimeter
        {
            get
            {
                float wx = UpperBound.X - LowerBound.X;
                float wy = UpperBound.Y - LowerBound.Y;
                return 2.0f * (wx + wy);
            }
        }
        
        /// <summary>Gets the vertices of the AABB.</summary>
        /// <value>The corners of the AABB</value>
        public Vertices Vertices
        {
            get
            {
                Vertices vertices = new Vertices(4)
                {
                    UpperBound,
                    new Vector2(UpperBound.X, LowerBound.Y),
                    LowerBound,
                    new Vector2(LowerBound.X, UpperBound.Y)
                };
                return vertices;
            }
        }
        
        /// <summary>First quadrant</summary>
        public Aabb Q1 => new Aabb(Center, UpperBound);
        
        /// <summary>Second quadrant</summary>
        public Aabb Q2 => new Aabb(new Vector2(LowerBound.X, Center.Y), new Vector2(Center.X, UpperBound.Y));
        
        /// <summary>Third quadrant</summary>
        public Aabb Q3 => new Aabb(LowerBound, Center);
        
        /// <summary>Forth quadrant</summary>
        public Aabb Q4 => new Aabb(new Vector2(Center.X, LowerBound.Y), new Vector2(UpperBound.X, Center.Y));
        
        /// <summary>Verify that the bounds are sorted. And the bounds are valid numbers (not NaN).</summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public bool IsValid()
        {
            Vector2 d = UpperBound - LowerBound;
            bool valid = (d.X >= 0.0f) && (d.Y >= 0.0f);
            return valid && LowerBound.IsValid() && UpperBound.IsValid();
        }
        
        /// <summary>Combine an AABB into this one.</summary>
        /// <param name="aabb">The AABB.</param>
        public void Combine(ref Aabb aabb)
        {
            LowerBound = Vector2.Min(LowerBound, aabb.LowerBound);
            UpperBound = Vector2.Max(UpperBound, aabb.UpperBound);
        }
        
        /// <summary>Combine two AABBs into this one.</summary>
        /// <param name="aabb1">The aabb1.</param>
        /// <param name="aabb2">The aabb2.</param>
        public void Combine(ref Aabb aabb1, ref Aabb aabb2)
        {
            LowerBound = Vector2.Min(aabb1.LowerBound, aabb2.LowerBound);
            UpperBound = Vector2.Max(aabb1.UpperBound, aabb2.UpperBound);
        }
        
        /// <summary>Does this AABB contain the provided AABB.</summary>
        /// <param name="aabb">The AABB.</param>
        /// <returns><c>true</c> if it contains the specified AABB; otherwise, <c>false</c>.</returns>
        public bool Contains(ref Aabb aabb)
        {
            bool result = LowerBound.X <= aabb.LowerBound.X;
            result = result && (LowerBound.Y <= aabb.LowerBound.Y);
            result = result && (aabb.UpperBound.X <= UpperBound.X);
            result = result && (aabb.UpperBound.Y <= UpperBound.Y);
            return result;
        }
        
        /// <summary>Determines whether the AABB contains the specified point.</summary>
        /// <param name="point">The point.</param>
        /// <returns><c>true</c> if it contains the specified point; otherwise, <c>false</c>.</returns>
        public bool Contains(ref Vector2 point) =>
            //using epsilon to try and guard against float rounding errors.
            (point.X > LowerBound.X + float.Epsilon) && (point.X < UpperBound.X - float.Epsilon) &&
            (point.Y > LowerBound.Y + float.Epsilon) && (point.Y < UpperBound.Y - float.Epsilon);
        
        /// <summary>Test if the two AABBs overlap.</summary>
        /// <param name="a">The first AABB.</param>
        /// <param name="b">The second AABB.</param>
        /// <returns>True if they are overlapping.</returns>
        public static bool TestOverlap(ref Aabb a, ref Aabb b)
        {
            Vector2 d1 = b.LowerBound - a.UpperBound;
            Vector2 d2 = a.LowerBound - b.UpperBound;
            
            return (d1.X <= 0) && (d1.Y <= 0) && (d2.X <= 0) && (d2.Y <= 0);
        }
    }
}