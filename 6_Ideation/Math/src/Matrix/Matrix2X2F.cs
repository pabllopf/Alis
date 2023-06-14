// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix2X2F.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     A 2-by-2 matrix. Stored in column-major order.
    /// </summary>
    public struct Matrix2X2F
    {
        /// <summary>
        ///     The col
        /// </summary>
        public Vector2F Ex;

        /// <summary>
        ///     The col
        /// </summary>
        public Vector2F Ey;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        public Matrix2X2F(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Construct this matrix using scalars.
        /// </summary>
        public Matrix2X2F(float a11, float a12, float a21, float a22)
        {
            Ex = new Vector2F(a11, a21);
            Ey = new Vector2F(a12, a22);
        }

        /// <summary>
        ///     Construct this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public Matrix2X2F(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            Ex = new Vector2F(c, -s);
            Ey = new Vector2F(s, c);
        }

        /// <summary>
        ///     Initialize this matrix using columns.
        /// </summary>
        public void Set(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Initialize this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public void Set(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            Ex = new Vector2F(c, -s);
            Ey = new Vector2F(s, c);
        }

        /// <summary>
        ///     Set this to the identity matrix.
        /// </summary>
        public void SetIdentity()
        {
            Ex = new Vector2F(1.0f, 0.0f);
            Ey = new Vector2F(0.0f, 1.0f);
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            Ex = new Vector2F(0.0f, 0.0f);
            Ey = new Vector2F(0.0f, 0.0f);
        }

        /// <summary>
        ///     Extract the angle from this matrix (assumed to be a rotation matrix).
        /// </summary>
        public float GetAngle() => (float) System.Math.Atan2(Ex.Y, Ex.X);

        /// <summary>
        ///     Compute the inverse of this matrix, such that inv(A) * A = identity.
        /// </summary>
        public Matrix2X2F GetInverse()
        {
            float col1X = Ex.X;
            float col2X = Ey.X;
            float col1Y = Ex.Y;
            float col2Y = Ey.Y;

            float det = col1X * col2Y - col2X * col1Y;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;

            Matrix2X2F matrix2X2F = new Matrix2X2F(
                det * col2Y,
                -det * col2X,
                -det * col1Y,
                det * col1X
            );
            return matrix2X2F;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
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
        ///     Gets the value of the identity
        /// </summary>
        public static Matrix2X2F Identity => new Matrix2X2F(1, 0, 0, 1);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix2X2F operator +(Matrix2X2F a, Matrix2X2F b)
        {
            Matrix2X2F c = new Matrix2X2F();
            c.Set(a.Ex + b.Ex, a.Ey + b.Ey);
            return c;
        }

        /// <summary>
        ///     Gets the value of the inverse
        /// </summary>
        public Matrix2X2F Inverse
        {
            get
            {
                float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
                float det = a * d - b * c;
                if (det != 0.0f)
                {
                    det = 1.0f / det;
                }

                Matrix2X2F result = new Matrix2X2F(
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