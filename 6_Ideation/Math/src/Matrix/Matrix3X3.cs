// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X3.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     A 3x3 matrix stored in column-major order using three <see cref="Vector3F" /> columns.
    ///     Provides linear system solving and inverse operations for 2D/3D transformations.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Matrix3X3
    {
        /// <summary>
        ///     The epsilon tolerance used for near-zero determinant checks.
        /// </summary>
        private const float Epsilon = 0.00001f;

        /// <summary>
        ///     The first column vector of the matrix.
        /// </summary>
        public Vector3F Ex, Ey, Ez;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix3X3" /> struct using three column vectors.
        /// </summary>
        /// <param name="c1">The first column vector.</param>
        /// <param name="c2">The second column vector.</param>
        /// <param name="c3">The third column vector.</param>
        public Matrix3X3(Vector3F c1, Vector3F c2, Vector3F c3)
        {
            Ex = c1;
            Ey = c2;
            Ez = c3;
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix3X3" /> struct using nine scalar values in row-major order.
        /// </summary>
        /// <param name="a00">The value at row 0, column 0.</param>
        /// <param name="a01">The value at row 0, column 1.</param>
        /// <param name="a02">The value at row 0, column 2.</param>
        /// <param name="a10">The value at row 1, column 0.</param>
        /// <param name="a11">The value at row 1, column 1.</param>
        /// <param name="a12">The value at row 1, column 2.</param>
        /// <param name="a20">The value at row 2, column 0.</param>
        /// <param name="a21">The value at row 2, column 1.</param>
        /// <param name="a22">The value at row 2, column 2.</param>
        public Matrix3X3(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
            float[] array = new float[9];

            array[0] = a00;
            array[3] = a01;
            array[6] = a02;
            array[1] = a10;
            array[4] = a11;
            array[7] = a12;
            array[2] = a20;
            array[5] = a21;
            array[8] = a22;

            Ex = new Vector3F(a00, a01, a02);
            Ey = new Vector3F(a10, a11, a12);
            Ez = new Vector3F(a20, a21, a22);
        }

        /// <summary>
        ///     Solves the 3x3 linear system A * x = b where A is this matrix.
        /// </summary>
        /// <param name="b">The right-hand side vector.</param>
        /// <returns>The solution vector x.</returns>
        [ExcludeFromCodeCoverage]
        public Vector3F Solve33(Vector3F b)
        {
            float det = Vector3F.Dot(Ex, Vector3F.Cross(Ey, Ez));
            if (System.Math.Abs(det) > Epsilon)
            {
                det = 1.0f / det;
            }

            return new Vector3F(det * Vector3F.Dot(b, Vector3F.Cross(Ey, Ez)), det * Vector3F.Dot(Ex, Vector3F.Cross(b, Ez)),
                det * Vector3F.Dot(Ex, Vector3F.Cross(Ey, b)));
        }


        /// <summary>
        ///     Solves the 2x2 subsystem (upper-left 2x2 portion) for the given right-hand side vector.
        /// </summary>
        /// <param name="b">The right-hand side 2D vector.</param>
        /// <returns>The solution 2D vector.</returns>
        public Vector2F Solve22(Vector2F b)
        {
            float a11 = Ex.X, a12 = Ey.X, a21 = Ex.Y, a22 = Ey.Y;
            float det = a11 * a22 - a12 * a21;

            if (System.Math.Abs(det) > Epsilon)
            {
                det = 1.0f / det;
            }

            return new Vector2F(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }


        /// <summary>
        ///     Computes the inverse of the upper-left 2x2 submatrix and stores it in the provided output matrix.
        /// </summary>
        /// <param name="m">The output matrix that will receive the inverse of the 2x2 submatrix.</param>
        [ExcludeFromCodeCoverage]
        public void GetInverse22(ref Matrix3X3 m)
        {
            float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
            float det = a * d - b * c;

            if (System.Math.Abs(det) > Epsilon)
            {
                det = 1.0f / det;
            }

            m.Ex = new Vector3F(
                det * d,
                -det * b,
                0.0f
            );

            m.Ey = new Vector3F(
                -det * b,
                det * a,
                0.0f
            );

            m.Ez = new Vector3F(
                0.0f,
                0.0f,
                0.0f
            );
        }

        /// <summary>
        ///     Computes the symmetric inverse of the full 3x3 matrix and stores it in the provided output matrix.
        /// </summary>
        /// <param name="m">The output matrix that will receive the symmetric inverse.</param>
        [ExcludeFromCodeCoverage]
        public void GetSymInverse33(ref Matrix3X3 m)
        {
            float det = Dot(Ex, Cross(Ey, Ez));
            if (System.Math.Abs(det) > Epsilon)
            {
                det = 1.0f / det;
            }

            float a11 = Ex.X, a12 = Ey.X, a13 = Ez.X;
            float a22 = Ey.Y, a23 = Ez.Y;
            float a33 = Ez.Z;

            m.Ex = new Vector3F(
                det * (a22 * a33 - a23 * a23),
                det * (a13 * a23 - a12 * a33),
                det * (a12 * a23 - a13 * a22)
            );

            m.Ey = new Vector3F(
                det * (a13 * a23 - a12 * a33),
                det * (a11 * a33 - a13 * a13),
                det * (a13 * a12 - a11 * a23)
            );

            m.Ez = new Vector3F(
                det * (a12 * a23 - a13 * a22),
                det * (a13 * a12 - a11 * a23),
                det * (a11 * a22 - a12 * a12)
            );
        }


        /// <summary>
        ///     Computes the dot product of two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The dot product.</returns>
        private static float Dot(Vector3F a, Vector3F b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;


        /// <summary>
        ///     Computes the cross product of two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The cross product vector.</returns>
        private static Vector3F Cross(Vector3F a, Vector3F b) =>
            new Vector3F(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
    }
}
