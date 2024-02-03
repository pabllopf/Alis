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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The matrix
    /// </summary>
    public struct Matrix3X3
    {
        /// <summary>
        ///     The ez
        /// </summary>
        public Vector3 Ex, Ey, Ez;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix3X3" /> class
        /// </summary>
        /// <param name="c1">The </param>
        /// <param name="c2">The </param>
        /// <param name="c3">The </param>
        public Matrix3X3(Vector3 c1, Vector3 c2, Vector3 c3)
        {
            Ex = c1;
            Ey = c2;
            Ez = c3;
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix3X3" /> class
        /// </summary>
        /// <param name="a00">The 00</param>
        /// <param name="a01">The 01</param>
        /// <param name="a02">The 02</param>
        /// <param name="a10">The 10</param>
        /// <param name="a11">The 11</param>
        /// <param name="a12">The 12</param>
        /// <param name="a20">The 20</param>
        /// <param name="a21">The 21</param>
        /// <param name="a22">The 22</param>
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

            Ex = new Vector3(a00, a01, a02);
            Ey = new Vector3(a10, a11, a12);
            Ez = new Vector3(a20, a21, a22);
        }

        /// <summary>
        ///     Solves the 33 using the specified b
        /// </summary>
        /// <param name="b">The </param>
        /// <returns>The vector</returns>
        [ExcludeFromCodeCoverage]
        public Vector3 Solve33(Vector3 b)
        {
            float det = Vector3.Dot(Ex, Vector3.Cross(Ey, Ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector3(det * Vector3.Dot(b, Vector3.Cross(Ey, Ez)), det * Vector3.Dot(Ex, Vector3.Cross(b, Ez)),
                det * Vector3.Dot(Ex, Vector3.Cross(Ey, b)));
        }


        /// <summary>
        ///     Solves the 22 using the specified b
        /// </summary>
        /// <param name="b">The </param>
        /// <returns>The vector</returns>
        public Vector2 Solve22(Vector2 b)
        {
            float a11 = Ex.X, a12 = Ey.X, a21 = Ex.Y, a22 = Ey.Y;
            float det = a11 * a22 - a12 * a21;

            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector2(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }


        /// <summary>
        ///     Gets the inverse 22 using the specified m
        /// </summary>
        /// <param name="m">The </param>
        public void GetInverse22(ref Matrix3X3 m)
        {
            float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
            float det = a * d - b * c;
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            m.Ex = new Vector3(
                det * d,
                -det * b,
                0.0f
            );

            m.Ey = new Vector3(
                -det * b,
                det * a,
                0.0f
            );

            m.Ez = new Vector3(
                0.0f,
                0.0f,
                0.0f
            );
        }


        /// <summary>
        ///     Gets the sym inverse 33 using the specified m
        /// </summary>
        /// <param name="m">The </param>
        [ExcludeFromCodeCoverage]
        public void GetSymInverse33(ref Matrix3X3 m)
        {
            float det = Dot(Ex, Cross(Ey, Ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            float a11 = Ex.X, a12 = Ey.X, a13 = Ez.X;
            float a22 = Ey.Y, a23 = Ez.Y;
            float a33 = Ez.Z;

            m.Ex = new Vector3(
                det * (a22 * a33 - a23 * a23),
                det * (a13 * a23 - a12 * a33),
                det * (a12 * a23 - a13 * a22)
            );

            m.Ey = new Vector3(
                det * (a13 * a23 - a12 * a33),
                det * (a11 * a33 - a13 * a13),
                det * (a13 * a12 - a11 * a23)
            );

            m.Ez = new Vector3(
                det * (a12 * a23 - a13 * a22),
                det * (a13 * a12 - a11 * a23),
                det * (a11 * a22 - a12 * a12)
            );
        }


        /// <summary>
        ///     Dots the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        private static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;


        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The vector</returns>
        private static Vector3 Cross(Vector3 a, Vector3 b) =>
            new Vector3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
    }
}