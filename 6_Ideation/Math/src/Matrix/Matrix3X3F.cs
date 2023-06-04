// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X3F.cs
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
    ///     <see cref="Matrix3X3F" /> is a struct representing a glsl mat3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3X3F
    {
        /// <summary>
        ///     The ez
        /// </summary>
        public Vector3F Ex, Ey, Ez;

        /// <summary>Construct this matrix using columns.</summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        public Matrix3X3F(Vector3F c1, Vector3F c2, Vector3F c3)
        {
            Ex = c1;
            Ey = c2;
            Ez = c3;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Matrix3X3F" /> from its components
        /// </summary>
        /// <remarks>
        ///     Arguments are in row-major order
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public Matrix3X3F(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
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

        // column-major!
        /// <summary>
        ///     The array
        /// </summary>
        private float[] array = new float[9];

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient than computing the inverse in one-shot
        ///     cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector3F Solve33(Vector3F b)
        {
            float det = Vector3F.Dot(Ex, Vector3F.Cross(Ey, Ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector3F(det * Vector3F.Dot(b, Vector3F.Cross(Ey, Ez)), det * Vector3F.Dot(Ex, Vector3F.Cross(b, Ez)),
                det * Vector3F.Dot(Ex, Vector3F.Cross(Ey, b)));
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient than computing the inverse in one-shot
        ///     cases. Solve only the upper 2-by-2 matrix equation.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector2F Solve22(Vector2F b)
        {
            float a11 = Ex.X, a12 = Ey.X, a21 = Ex.Y, a22 = Ey.Y;
            float det = a11 * a22 - a12 * a21;

            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector2F(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }

        /// Get the inverse of this matrix as a 2-by-2.
        /// Returns the zero matrix if singular.
        public void GetInverse22(ref Matrix3X3F m)
        {
            float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
            float det = a * d - b * c;
            if (det != 0.0f)
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

        /// Get the symmetric inverse of this matrix as a 3-by-3.
        /// Returns the zero matrix if singular.
        public void GetSymInverse33(ref Matrix3X3F m)
        {
            float det = Dot(Ex, Cross(Ey, Ez));
            if (det != 0.0f)
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
        ///     Dots the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Dot(Vector3F a, Vector3F b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The vector</returns>
        public static Vector3F Cross(Vector3F a, Vector3F b) =>
            new Vector3F(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
    }
}