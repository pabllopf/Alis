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
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Shared
{
    /// <summary>A 3-by-3 matrix. Stored in column-major order.</summary>
    public struct Mat33
    {
        /// <summary>
        ///     The ez
        /// </summary>
        public Vector3 Ex, Ey, Ez;

        /// <summary>Construct this matrix using columns.</summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        public Mat33(Vector3 c1, Vector3 c2, Vector3 c3)
        {
            Ex = c1;
            Ey = c2;
            Ez = c3;
        }

        /// <summary>Set this matrix to all zeros.</summary>
        public void SetZero()
        {
            Ex = Vector3.Zero;
            Ey = Vector3.Zero;
            Ez = Vector3.Zero;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient than computing the inverse in one-shot
        ///     cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
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
        ///     Solve A * x = b, where b is a column vector. This is more efficient than computing the inverse in one-shot
        ///     cases. Solve only the upper 2-by-2 matrix equation.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
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

        /// Get the inverse of this matrix as a 2-by-2.
        /// Returns the zero matrix if singular.
        public void GetInverse22(ref Mat33 m)
        {
            float a = Ex.X, b = Ey.X, c = Ex.Y, d = Ey.Y;
            float det = a * d - b * c;
            if (det != 0.0f)
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

        /// Get the symmetric inverse of this matrix as a 3-by-3.
        /// Returns the zero matrix if singular.
        public void GetSymInverse33(ref Mat33 m)
        {
            float det = MathUtils.Dot(Ex, MathUtils.Cross(Ey, Ez));
            if (det != 0.0f)
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