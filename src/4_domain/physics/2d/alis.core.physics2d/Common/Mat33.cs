// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Mat33.cs
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

using System.Numerics;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     A 3-by-3 matrix. Stored in column-major order.
    /// </summary>
    internal struct Mat33
    {
        /// <summary>
        ///     The ez
        /// </summary>
        internal Vector3 ex, ey, ez;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        internal Mat33(Vector3 c1, Vector3 c2, Vector3 c3)
        {
            ex = c1;
            ey = c2;
            ez = c3;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        internal void SetZero()
        {
            ex = Vector3.Zero;
            ey = Vector3.Zero;
            ez = Vector3.Zero;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        internal Vector3 Solve33(Vector3 b)
        {
            float det = Vector3.Dot(ex, Vector3.Cross(ey, ez));
            //Debug.Assert(det != 0.0f);
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            Vector3 x = new Vector3();
            x.X = det * Vector3.Dot(b, Vector3.Cross(ey, ez));
            x.Y = det * Vector3.Dot(ex, Vector3.Cross(b, ez));
            x.Z = det * Vector3.Dot(ex, Vector3.Cross(ey, b));
            return x;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases. Solve only the upper
        ///     2-by-2 matrix equation.
        /// </summary>
        internal Vector2 Solve22(Vector2 b)
        {
            float a11 = ex.X, a12 = ey.X, a21 = ex.Y, a22 = ey.Y;
            float det = a11 * a22 - a12 * a21;
            //Debug.Assert(det != 0.0f);
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            Vector2 x = new Vector2();
            x.X = det * (a22 * b.X - a12 * b.Y);
            x.Y = det * (a11 * b.Y - a21 * b.X);
            return x;
        }

        /// <summary>
        ///     Gets the inverse 22 using the specified m
        /// </summary>
        /// <param name="M">The </param>
        /// <returns>The </returns>
        internal Mat33 GetInverse22(Mat33 M)
        {
            float a = ex.X, b = ey.X, c = ex.Y, d = ey.Y;
            float det = a * d - b * c;
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            M.ex.X = det * d;
            M.ey.X = -det * b;
            M.ex.Z = 0.0f;
            M.ex.Y = -det * c;
            M.ey.Y = det * a;
            M.ey.Z = 0.0f;
            M.ez.X = 0.0f;
            M.ez.Y = 0.0f;
            M.ez.Z = 0.0f;

            return M;
        }

        /// <summary>
        ///     Gets the sym inverse 33 using the specified m
        /// </summary>
        /// <param name="M">The </param>
        /// <returns>The </returns>
        internal Mat33 GetSymInverse33(Mat33 M)
        {
            float det = Vector3.Dot(ex, Vector3.Cross(ey, ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            float a11 = ex.X, a12 = ey.X, a13 = ez.X;
            float a22 = ey.Y, a23 = ez.Y;
            float a33 = ez.Z;

            M.ex.X = det * (a22 * a33 - a23 * a23);
            M.ex.Y = det * (a13 * a23 - a12 * a33);
            M.ex.Z = det * (a12 * a23 - a13 * a22);

            M.ey.X = M.ex.Y;
            M.ey.Y = det * (a11 * a33 - a13 * a13);
            M.ey.Z = det * (a13 * a12 - a11 * a23);

            M.ez.X = M.ex.Z;
            M.ez.Y = M.ey.Z;
            M.ez.Z = det * (a11 * a22 - a12 * a12);

            return M;
        }
    }
}