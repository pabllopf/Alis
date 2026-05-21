// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mat33.cs
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
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Represents a 3-by-3 matrix stored in column-major order.
    /// </summary>
    /// <remarks>
    ///     This matrix is commonly used for 3D transformations in the physics engine,
    ///     including inertia tensor calculations and mass matrix operations.
    ///     The matrix layout is as follows:
    ///     | Ex.X  Ey.X  Ez.X |
    ///     | Ex.Y  Ey.Y  Ez.Y |
    ///     | Ex.Z  Ey.Z  Ez.Z |
    ///     Where Ex, Ey, and Ez are column vectors representing the matrix columns.
    /// </remarks>
    public struct Mat33
    {
        /// <summary>
        ///     Gets or sets the first column vector (X-axis basis vector).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector3F"/> representing the first column of the matrix.
        /// </value>
        public Vector3F Ex, Ey, Ez;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mat33"/> struct using three column vectors.
        /// </summary>
        /// <param name="c1">The first column vector (X-axis basis).</param>
        /// <param name="c2">The second column vector (Y-axis basis).</param>
        /// <param name="c3">The third column vector (Z-axis basis).</param>
        public Mat33(Vector3F c1, Vector3F c2, Vector3F c3)
        {
            Ex = c1;
            Ey = c2;
            Ez = c3;
        }

        /// <summary>
        ///     Sets all elements of this matrix to zero.
        /// </summary>
        /// <remarks>
        ///     The resulting matrix is a zero matrix with all elements set to 0:
        ///     | 0  0  0 |
        ///     | 0  0  0 |
        ///     | 0  0  0 |
        /// </remarks>
        public void SetZero()
        {
            Ex = Vector3F.Zero;
            Ey = Vector3F.Zero;
            Ez = Vector3F.Zero;
        }

        /// <summary>
        ///     Solves the linear system A * x = b for a 3x3 matrix.
        /// </summary>
        /// <param name="b">The right-hand side 3D vector to solve for.</param>
        /// <returns>
        ///     The solution vector x that satisfies A * x = b.
        ///     Returns a zero vector if the matrix is singular.
        /// </returns>
        /// <remarks>
        ///     This uses Cramer's rule via cross products for efficient solution
        ///     without computing the full matrix inverse.
        /// </remarks>
        public Vector3F Solve33(Vector3F b)
        {
            float det = Vector3F.Dot(Ex, Vector3F.Cross(Ey, Ez));
            if (Math.Abs(det) > float.Epsilon)
            {
                det = 1.0f / det;
            }

            return new Vector3F(det * Vector3F.Dot(b, Vector3F.Cross(Ey, Ez)), det * Vector3F.Dot(Ex, Vector3F.Cross(b, Ez)), det * Vector3F.Dot(Ex, Vector3F.Cross(Ey, b)));
        }

        /// <summary>
        ///     Solves the linear system A * x = b for the upper 2x2 submatrix.
        /// </summary>
        /// <param name="b">The right-hand side 2D vector to solve for.</param>
        /// <returns>
        ///     The 2D solution vector x that satisfies the 2x2 system.
        ///     Returns a zero vector if the matrix is singular.
        /// </returns>
        /// <remarks>
        ///     This only considers the upper-left 2x2 portion of the matrix,
        ///     ignoring the third row and column. Useful for 2D physics subproblems.
        /// </remarks>
        public Vector2F Solve22(Vector2F b)
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
        ///     Computes the inverse of the 2x2 top-left submatrix and stores the result.
        /// </summary>
        /// <param name="m">The output parameter that receives the 2x2 inverse (padded to 3x3 with zeros).</param>
        /// <remarks>
        ///     Only the upper-left 2x2 portion is inverted. The third row and column
        ///     are set to zero. Returns the zero matrix if the 2x2 submatrix is singular.
        /// </remarks>
        public void GetInverse22(ref Mat33 m)
        {
            float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
            float det = a * d - b * c;
            if (Math.Abs(det) > float.Epsilon)
            {
                det = 1.0f / det;
            }

            m.Ex.X = det * d;
            m.Ey.X = -det * b;
            m.Ex.Z = 0.0f;
            m.Ex.Y = -det * c;
            m.Ey.Y = det * a;
            m.Ey.Z = 0.0f;
            m.Ez.X = 0.0f;
            m.Ez.Y = 0.0f;
            m.Ez.Z = 0.0f;
        }

        /// <summary>
        ///     Computes the symmetric inverse of this 3x3 matrix.
        /// </summary>
        /// <param name="m">The output parameter that receives the symmetric inverse.</param>
        /// <remarks>
        ///     The result is always symmetric (m = m^T). This is useful for
        ///     inverting mass matrices and inertia tensors which are guaranteed
        ///     to be symmetric positive definite. Returns zero matrix if singular.
        /// </remarks>
        public void GetSymInverse33(ref Mat33 m)
        {
            float det = MathUtils.Dot(Ex, MathUtils.Cross(ref Ey, ref Ez));
            if (Math.Abs(det) > float.Epsilon)
            {
                det = 1.0f / det;
            }

            float a11 = Ex.X, a12 = Ey.X, a13 = Ez.X;
            float a22 = Ey.Y, a23 = Ez.Y;
            float a33 = Ez.Z;

            m.Ex.X = det * (a22 * a33 - a23 * a23);
            m.Ex.Y = det * (a13 * a23 - a12 * a33);
            m.Ex.Z = det * (a12 * a23 - a13 * a22);

            m.Ey.X = m.Ex.Y;
            m.Ey.Y = det * (a11 * a33 - a13 * a13);
            m.Ey.Z = det * (a13 * a12 - a11 * a23);

            m.Ez.X = m.Ex.Z;
            m.Ez.Y = m.Ey.Z;
            m.Ez.Z = det * (a11 * a22 - a12 * a12);
        }
    }
}