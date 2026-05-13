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
        ///     Gets the inverse of this matrix.
        /// </summary>
        /// <value>
        ///     A new <see cref="Mat22"/> representing the inverse of this matrix.
        ///     Returns a zero matrix if the determinant is near zero (singular matrix).
        /// </value>
        /// <remarks>
        ///     The inverse of a 2x2 matrix is computed as:
        ///     1/det * | d   -b |
        ///              | -c   a |
        ///     where det = a*d - b*c
        ///     If the determinant is zero or nearly zero, the returned matrix contains zeros.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     Mat22 m = new Mat22(1, 2, 3, 4);
        ///     Mat22 inv = m.Inverse; // Returns inverse matrix
        ///     </code>
        /// </example>
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
        ///     Sets this matrix using two column vectors.
        /// </summary>
        /// <param name="c1">The first column vector (X-axis basis) to set.</param>
        /// <param name="c2">The second column vector (Y-axis basis) to set.</param>
        /// <remarks>
        ///     This method modifies the existing matrix in place, updating both column vectors.
        /// </remarks>
        public void Set(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>
        ///     Sets this matrix to the identity matrix.
        /// </summary>
        /// <remarks>
        ///     The identity matrix has 1s on the main diagonal and 0s elsewhere:
        ///     | 1  0 |
        ///     | 0  1 |
        ///     This is the multiplicative identity for matrix multiplication.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     Mat22 m = new Mat22(2, 3, 4, 5);
        ///     m.SetIdentity(); // m is now the identity matrix
        ///     </code>
        /// </example>
        public void SetIdentity()
        {
            Ex.X = 1.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 1.0f;
        }

        /// <summary>
        ///     Sets all elements of this matrix to zero.
        /// </summary>
        /// <remarks>
        ///     The resulting matrix is a zero matrix with all elements set to 0:
        ///     | 0  0 |
        ///     | 0  0 |
        /// </remarks>
        /// <example>
        ///     <code>
        ///     Mat22 m = new Mat22(1, 2, 3, 4);
        ///     m.SetZero(); // m is now a zero matrix
        ///     </code>
        /// </example>
        public void SetZero()
        {
            Ex.X = 0.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 0.0f;
        }

        /// <summary>
        ///     Solves the linear system A * x = b, where A is this matrix and b is a column vector.
        /// </summary>
        /// <param name="b">The right-hand side column vector to solve for.</param>
        /// <returns>
        ///     The solution vector x that satisfies A * x = b.
        ///     Returns a zero vector if the matrix is singular (determinant near zero).
        /// </returns>
        /// <remarks>
        ///     This method uses Cramer's rule to solve the 2x2 system directly,
        ///     which is more numerically stable and efficient than computing the inverse
        ///     for single-shot solves. For multiple solves with the same matrix,
        ///     compute the inverse once and multiply.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     Mat22 A = new Mat22(1, 2, 3, 4);
        ///     Vector2F b = new Vector2F(5, 6);
        ///     Vector2F x = A.Solve(b); // Solves A*x = b
        ///     </code>
        /// </example>
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
        ///     Adds two matrices together and stores the result in a output parameter.
        /// </summary>
        /// <param name="a">The first matrix to add. This is passed by reference to avoid copying.</param>
        /// <param name="b">The second matrix to add. This is passed by reference to avoid copying.</param>
        /// <param name="r">The output parameter that will contain the sum of the two matrices (a + b).</param>
        /// <remarks>
        ///     Matrix addition is performed element-wise:
        ///     r[i,j] = a[i,j] + b[i,j]
        ///     Both matrices must have the same dimensions.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     Mat22 a = new Mat22(1, 2, 3, 4);
        ///     Mat22 b = new Mat22(5, 6, 7, 8);
        ///     Mat22 result;
        ///     Mat22.Add(ref a, ref b, out result); // result = {{6, 8}, {10, 12}}
        ///     </code>
        /// </example>
        public static void Add(ref Mat22 a, ref Mat22 b, out Mat22 r)
        {
            r.Ex = a.Ex + b.Ex;
            r.Ey = a.Ey + b.Ey;
        }
    }
}