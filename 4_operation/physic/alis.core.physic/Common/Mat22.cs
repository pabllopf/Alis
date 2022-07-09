// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Mat22.cs
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

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A 2-by-2 matrix. Stored in column-major order.
    /// </summary>
    public struct Mat22
    {
        /// <summary>
        ///     The col
        /// </summary>
        public Vec2 col1;

        /// <summary>
        ///     The col
        /// </summary>
        public Vec2 col2;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        public Mat22(Vec2 c1, Vec2 c2)
        {
            col1 = c1;
            col2 = c2;
        }

        /// <summary>
        ///     Construct this matrix using scalars.
        /// </summary>
        public Mat22(float a11, float a12, float a21, float a22)
        {
            col1.X = a11;
            col1.Y = a21;
            col2.X = a12;
            col2.Y = a22;
        }

        /// <summary>
        ///     Construct this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public Mat22(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            col1.X = c;
            col2.X = -s;
            col1.Y = s;
            col2.Y = c;
        }

        /// <summary>
        ///     Initialize this matrix using columns.
        /// </summary>
        public void Set(Vec2 c1, Vec2 c2)
        {
            col1 = c1;
            col2 = c2;
        }

        /// <summary>
        ///     Initialize this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public void Set(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            col1.X = c;
            col2.X = -s;
            col1.Y = s;
            col2.Y = c;
        }

        /// <summary>
        ///     Set this to the identity matrix.
        /// </summary>
        public void SetIdentity()
        {
            col1.X = 1.0f;
            col2.X = 0.0f;
            col1.Y = 0.0f;
            col2.Y = 1.0f;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            col1.X = 0.0f;
            col2.X = 0.0f;
            col1.Y = 0.0f;
            col2.Y = 0.0f;
        }

        /// <summary>
        ///     Extract the angle from this matrix (assumed to be a rotation matrix).
        /// </summary>
        public float GetAngle()
        {
            return (float) System.Math.Atan2(col1.Y, col1.X);
        }

        /// <summary>
        ///     Compute the inverse of this matrix, such that inv(A) * A = identity.
        /// </summary>
        public Mat22 GetInverse()
        {
            float a = col1.X, b = col2.X, c = col1.Y, d = col2.Y;
            Mat22 B = new Mat22();
            float det = a * d - b * c;
            Box2DXDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            B.col1.X = det * d;
            B.col2.X = -det * b;
            B.col1.Y = -det * c;
            B.col2.Y = det * a;
            return B;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        public Vec2 Solve(Vec2 b)
        {
            float a11 = col1.X, a12 = col2.X, a21 = col1.Y, a22 = col2.Y;
            float det = a11 * a22 - a12 * a21;
            Box2DXDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            Vec2 x = new Vec2();
            x.X = det * (a22 * b.X - a12 * b.Y);
            x.Y = det * (a11 * b.Y - a21 * b.X);
            return x;
        }

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static Mat22 Identity => new Mat22(1, 0, 0, 1);

        /// <summary>
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Mat22 operator +(Mat22 A, Mat22 B)
        {
            Mat22 C = new Mat22();
            C.Set(A.col1 + B.col1, A.col2 + B.col2);
            return C;
        }
    }
}