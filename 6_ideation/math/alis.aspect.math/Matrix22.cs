// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix22.cs
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

namespace Alis.Aspect.Math
{
    /// <summary>
    ///     A 2-by-2 matrix. Stored in column-major order.
    /// </summary>
    public struct Matrix22
    {
        /// <summary>
        ///     The col
        /// </summary>
        public Vector2 Col1;

        /// <summary>
        ///     The col
        /// </summary>
        public Vector2 Col2;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        public Matrix22(Vector2 c1, Vector2 c2)
        {
            Col1 = c1;
            Col2 = c2;
        }

        /// <summary>
        ///     Construct this matrix using scalars.
        /// </summary>
        public Matrix22(float a11, float a12, float a21, float a22)
        {
            Col1.X = a11;
            Col1.Y = a21;
            Col2.X = a12;
            Col2.Y = a22;
        }

        /// <summary>
        ///     Construct this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public Matrix22(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            Col1.X = c;
            Col2.X = -s;
            Col1.Y = s;
            Col2.Y = c;
        }

        /// <summary>
        ///     Initialize this matrix using columns.
        /// </summary>
        public void Set(Vector2 c1, Vector2 c2)
        {
            Col1 = c1;
            Col2 = c2;
        }

        /// <summary>
        ///     Initialize this matrix using an angle.
        ///     This matrix becomes an orthonormal rotation matrix.
        /// </summary>
        public void Set(float angle)
        {
            float c = (float) System.Math.Cos(angle), s = (float) System.Math.Sin(angle);
            Col1.X = c;
            Col2.X = -s;
            Col1.Y = s;
            Col2.Y = c;
        }

        /// <summary>
        ///     Set this to the identity matrix.
        /// </summary>
        public void SetIdentity()
        {
            Col1.X = 1.0f;
            Col2.X = 0.0f;
            Col1.Y = 0.0f;
            Col2.Y = 1.0f;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            Col1.X = 0.0f;
            Col2.X = 0.0f;
            Col1.Y = 0.0f;
            Col2.Y = 0.0f;
        }

        /// <summary>
        ///     Extract the angle from this matrix (assumed to be a rotation matrix).
        /// </summary>
        public float GetAngle() => (float) System.Math.Atan2(Col1.Y, Col1.X);

        /// <summary>
        ///     Compute the inverse of this matrix, such that inv(A) * A = identity.
        /// </summary>
        public Matrix22 GetInverse()
        {
            float col1X = Col1.X;
            float col2X = Col2.X;
            float col1Y = Col1.Y;
            float col2Y = Col2.Y;
            Matrix22 matrix22 = new Matrix22();
            float det = col1X * col2Y - col2X * col1Y;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            matrix22.Col1.X = det * col2Y;
            matrix22.Col2.X = -det * col2X;
            matrix22.Col1.Y = -det * col1Y;
            matrix22.Col2.Y = det * col1X;
            return matrix22;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        public Vector2 Solve(Vector2 b)
        {
            float col1X = Col1.X;
            float col2X = Col2.X;
            float col1Y = Col1.Y;
            float col2Y = Col2.Y;
            float det = col1X * col2Y - col2X * col1Y;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            Vector2 x = new Vector2();
            x.X = det * (col2Y * b.X - col2X * b.Y);
            x.Y = det * (col1X * b.Y - col1Y * b.X);
            return x;
        }

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static Matrix22 Identity => new Matrix22(1, 0, 0, 1);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix22 operator +(Matrix22 a, Matrix22 b)
        {
            Matrix22 c = new Matrix22();
            c.Set(a.Col1 + b.Col1, a.Col2 + b.Col2);
            return c;
        }
    }
}