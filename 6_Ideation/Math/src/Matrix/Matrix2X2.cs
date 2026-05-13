// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix2X2.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     A 2-by-2 matrix stored in column-major order using two <see cref="Vector2F" /> columns.
    ///     Provides common matrix operations such as inversion, rotation, scaling, and solving linear systems.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Matrix2X2
    {
        /// <summary>
        ///     Gets or sets the first column vector of the matrix.
        /// </summary>
        public Vector2F Ex { get; set; }

        /// <summary>
        ///     Gets or sets the second column vector of the matrix.
        /// </summary>
        public Vector2F Ey { get; set; }

        /// <summary>
        ///     Constructs this matrix from four scalar values in column-major order.
        /// </summary>
        /// <param name="a11">The value at row 1, column 1.</param>
        /// <param name="a12">The value at row 1, column 2.</param>
        /// <param name="a21">The value at row 2, column 1.</param>
        /// <param name="a22">The value at row 2, column 2.</param>
        public Matrix2X2(float a11, float a12, float a21, float a22)
        {
            Ex = new Vector2F(a11, a21);
            Ey = new Vector2F(a12, a22);
        }

        /// <summary>
        ///     Constructs this matrix as an orthonormal rotation matrix from a specified angle.
        /// </summary>
        /// <param name="angle">The rotation angle in radians.</param>
        public Matrix2X2(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            Ex = new Vector2F(c, -s);
            Ey = new Vector2F(s, c);
        }

        /// <summary>
        ///     Sets both column vectors of the matrix to the specified values.
        /// </summary>
        /// <param name="c1">The new first column vector to assign to <see cref="Ex" />.</param>
        /// <param name="c2">The new second column vector to assign to <see cref="Ey" />.</param>
        public void Set(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Resets this matrix to the identity matrix, where <see cref="Ex" /> = (1, 0) and <see cref="Ey" /> = (0, 1).
        /// </summary>
        public void SetIdentity()
        {
            Ex = new Vector2F(1.0f, 0.0f);
            Ey = new Vector2F(0.0f, 1.0f);
        }

        /// <summary>
        ///     Sets all elements of this matrix to zero, where both <see cref="Ex" /> and <see cref="Ey" /> become (0, 0).
        /// </summary>
        public void SetZero()
        {
            Ex = new Vector2F(0.0f, 0.0f);
            Ey = new Vector2F(0.0f, 0.0f);
        }

        /// <summary>
        ///     Extracts the rotation angle from this matrix, assuming it is an orthonormal rotation matrix.
        /// </summary>
        /// <returns>The rotation angle in radians.</returns>
        public float GetAngle() => (float) System.Math.Atan2(Ex.Y, Ex.X);

        /// <summary>
        ///     Computes the inverse of this matrix such that inv(A) * A = identity.
        /// </summary>
        /// <returns>The inverse matrix.</returns>
        public Matrix2X2 GetInverse()
        {
            float col1X = Ex.X;
            float col2X = Ey.X;
            float col1Y = Ex.Y;
            float col2Y = Ey.Y;

            float det = col1X * col2Y - col2X * col1Y;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;

            Matrix2X2 matrix2X2 = new Matrix2X2(
                det * col2Y,
                -det * col2X,
                -det * col1Y,
                det * col1X
            );
            return matrix2X2;
        }

        /// <summary>
        ///     Solves the linear system A * x = b where A is this matrix and b is a column vector.
        ///     This is more efficient than computing the inverse in one-shot cases.
        /// </summary>
        /// <param name="b">The right-hand side column vector.</param>
        /// <returns>The solution vector x.</returns>
        public Vector2F Solve(Vector2F b)
        {
            float col1X = Ex.X;
            float col2X = Ey.X;
            float col1Y = Ex.Y;
            float col2Y = Ey.Y;
            float det = col1X * col2Y - col2X * col1Y;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            Vector2F x = new Vector2F(
                det * (col2Y * b.X - col2X * b.Y),
                det * (col1X * b.Y - col1Y * b.X)
            );
            return x;
        }

        /// <summary>
        ///     Adds two matrices component-wise.
        /// </summary>
        /// <param name="a">The first matrix.</param>
        /// <param name="b">The second matrix.</param>
        /// <returns>The sum of the two matrices.</returns>
        public static Matrix2X2 operator +(Matrix2X2 a, Matrix2X2 b)
        {
            Matrix2X2 c = new Matrix2X2();
            c.Set(a.Ex + b.Ex, a.Ey + b.Ey);
            return c;
        }

        /// <summary>
        ///     Gets the inverse of this matrix such that the result multiplied by the original equals the identity.
        /// </summary>
        /// <value>The inverse matrix if the determinant is non-zero; otherwise, a default matrix.</value>
        public Matrix2X2 Inverse
        {
            get
            {
                float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
                float det = a * d - b * c;
                if (System.Math.Abs(det) > float.Epsilon || System.Math.Abs(det) < -float.Epsilon)
                {
                    det = 1.0f / det;
                }

                Matrix2X2 result = new Matrix2X2(
                    det * d,
                    -det * c,
                    -det * b,
                    det * a
                );
                return result;
            }
        }
    }
}
