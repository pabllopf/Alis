// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Vectex.cs
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
    ///     The vectex class
    /// </summary>
    public static class Vectex // vector extensions
    {
        /// <summary>
        ///     Gets the idx using the specified candidate
        /// </summary>
        /// <param name="candidate">The candidate</param>
        /// <param name="n">The </param>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetIdx(in this Vector2 candidate, in int n) => n == 0 ? candidate.X : candidate.Y;

        /// <summary>
        ///     Crosses the s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Cross(float s, Vector2 a) => new Vector2(-s * a.Y, s * a.X);

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="s">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Cross(Vector2 a, float s) => new Vector2(s * a.Y, -s * a.X);

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cross(Vector2 a, Vector2 b) => a.X * b.Y - a.Y * b.X;

        /// <summary>
        ///     Describes whether is valid
        /// </summary>
        /// <param name="candidate">The candidate</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(this Vector2 candidate) => Math.IsValid(candidate.X) && Math.IsValid(candidate.Y);

        /// <summary>
        ///     Sets the v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Obsolete(
            "This is now a System.Numerics.Vector2, and cannot be mutated this way. Please create a new Vector2 and assign it to the property or field you're trying to modify.",
            true)]
        public static void Set(this Vector2 v, float x, float y)
        {
        }

        /// <summary>
        ///     Sets the v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="x">The </param>
        [Obsolete(
            "This is now a System.Numerics.Vector2, and cannot be mutated this way. Please create a new Vector2 and assign it to the property or field you're trying to modify.",
            true)]
        public static void Set(this Vector2 v, float x)
        {
        }

        /// <summary>
        ///     Sets the zero using the specified v
        /// </summary>
        /// <param name="v">The </param>
        [Obsolete(
            "This is now a System.Numerics.Vector2, and cannot be mutated this way. Please create a new Vector2 and assign it to the property or field you're trying to modify.",
            true)]
        public static void SetZero(this Vector2 v)
        {
        }
    }
}