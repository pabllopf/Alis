// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Matrex.cs
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

namespace Alis.Core.Physics2D.Common
{
    /// <summary>
    ///     Matrix extension methods
    /// </summary>
    public static class Matrex
    {
        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Solve(this Matrix3x2 m, Vector2 b)
        {
            float det = 1f / m.GetDeterminant();
            return new Vector2(
                det * (m.M22 * b.X - m.M12 * b.Y),
                det * (m.M11 * b.Y - m.M21 * b.X));
        }

        /// <summary>
        /// Creates the rotation using the specified angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The result</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2 CreateRotation(float angle)
        {
            float cos = MathF.Cos(angle);
            float sin = MathF.Sin(angle);

            Matrix3x2 result = Matrix3x2.Identity;
            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;
            return result;
        }

        /// <summary>
        /// Inverts the matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="result">The result</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(in Matrix3x2 matrix, out Matrix3x2 result)
        {
            float x = matrix.M11 * matrix.M22 - matrix.M21 * matrix.M12;
            float num = 1f / x;
            result.M11 = matrix.M22 * num;
            result.M12 = -matrix.M12 * num;
            result.M21 = -matrix.M21 * num;
            result.M22 = matrix.M11 * num;
            result.M31 = result.M32 = 0;
        }
    }
}