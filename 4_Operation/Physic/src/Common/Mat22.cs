// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mat22.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Represents a 2-by-2 matrix stored in column-major order.
    ///     This matrix is commonly used for 2D transformations including rotation,
    ///     scaling, and shearing operations in the physics engine.
    /// </summary>
    /// <remarks>
    ///     The matrix layout is as follows:
    ///     | Ex.X  Ey.X |
    ///     | Ex.Y  Ey.Y |
    ///     Where Ex and Ey are column vectors representing the matrix columns.
    /// </remarks>
    public struct Mat22
    {
        /// <summary>
        ///     Gets or sets the first column vector (X-axis basis vector).
        ///     Represents the X-direction transformation coefficients (a11, a21).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the first column of the matrix.
        /// </value>
        public Vector2F Ex;

        /// <summary>
        ///     Gets or sets the second column vector (Y-axis basis vector).
        ///     Represents the Y-direction transformation coefficients (a12, a22).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the second column of the matrix.
        /// </value>
        public Vector2F Ey;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mat22"/> struct using two column vectors.
        /// </summary>
        /// <param name="c1">The first column vector (X-axis basis). Specifies the values for the first column of the matrix.</param>
        /// <param name="c2">The second column vector (Y-axis basis). Specifies the values for the second column of the matrix.</param>
        /// <example>
        ///     <code>
        ///     Vector2F xAxis = new Vector2F(1, 0);
        ///     Vector2F yAxis = new Vector2F(0, 1);
        ///     Mat22 identity = new Mat22(xAxis, yAxis);
        ///     </code>
        /// </example>
        public Mat22(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mat22"/> struct using four scalar values in row-major order.
        /// </summary>
        /// <param name="a11">The element at row 1, column 1 (first row, first column). This becomes the X-component of the first column vector.</param>
        /// <param name="a12">The element at row 1, column 2 (first row, second column). This becomes the X-component of the second column vector.</param>
        /// <param name="a21">The element at row 2, column 1 (second row, first column). This becomes the Y-component of the first column vector.</param>
        /// <param name="a22">The element at row 2, column 2 (second row, second column). This becomes the Y-component of the second column vector.</param>
        /// <example>
        ///     <code>
        ///     // Create a 90-degree rotation matrix
        ///     Mat22 rotation = new Mat22(0, -1, 1, 0);
        ///     </code>
        /// </example>
        public Mat22(float a11, float a12, float a21, float a22)
        {
            Ex = new Vector2F(a11, a21);
            Ey = new Vector2F(a12, a22);
        }

        /// <summary>
        ///     Gets the value of the inverse
        /// </summary>
        public Mat22 Inverse
        {
            get
            {
                float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
                float det = a * d - b * c;
                if (Math.Abs(det) > float.Epsilon)
                {
                    det = 1.0f / det;
                }

                Mat22 result;
                result.Ex = new Vector2F(det * d, -det * c);
                result.Ey = new Vector2F(-det * b, det * a);

                return result;
            }
        }

        /// <summary>
        ///     Initialize this matrix using columns.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        public void Set(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Set this to the identity matrix.
        /// </summary>
        public void SetIdentity()
        {
            Ex.X = 1.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 1.0f;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            Ex.X = 0.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 0.0f;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector2F Solve(Vector2F b)
        {
            float a11 = Ex.X, a12 = Ey.X, a21 = Ex.Y, a22 = Ey.Y;
            float det = a11 * a22 - a12 * a21;
            if (Math.Abs(det) > float.Epsilon)
            {
                det = 1.0f / det;
            }

            return new Vector2F(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }

        /// <summary>
        ///     Adds the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="r">The </param>
        public static void Add(ref Mat22 a, ref Mat22 b, out Mat22 r)
        {
            r.Ex = a.Ex + b.Ex;
            r.Ey = a.Ey + b.Ey;
        }
    }
}