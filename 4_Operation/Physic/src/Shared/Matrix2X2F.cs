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

namespace Alis.Core.Physic.Shared
{
    /// <summary>A 2-by-2 matrix. Stored in column-major order.</summary>
    public struct Matrix2X2F
    {
        /// <summary>
        ///     The ey
        /// </summary>
        public Vector2F Ex, Ey;

        /// <summary>Construct this matrix using columns.</summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        public Matrix2X2F(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>Construct this matrix using scalars.</summary>
        /// <param name="a11">The a11.</param>
        /// <param name="a12">The a12.</param>
        /// <param name="a21">The a21.</param>
        /// <param name="a22">The a22.</param>
        public Matrix2X2F(float a11, float a12, float a21, float a22)
        {
            Ex = new Vector2F(a11, a21);
            Ey = new Vector2F(a12, a22);
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

                Matrix2X2F result = new Matrix2X2F();
                result.Ex.X = det * d;
                result.Ex.Y = -det * c;

                result.Ey.X = -det * b;
                result.Ey.Y = det * a;

                return result;
            }
        }

        /// <summary>Initialize this matrix using columns.</summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        public void Set(Vector2F c1, Vector2F c2)
        {
            Ex = c1;
            Ey = c2;
        }

        /// <summary>Set this to the identity matrix.</summary>
        public void SetIdentity()
        {
            Ex.X = 1.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 1.0f;
        }

        /// <summary>Set this matrix to all zeros.</summary>
        public void SetZero()
        {
            Ex.X = 0.0f;
            Ey.X = 0.0f;
            Ex.Y = 0.0f;
            Ey.Y = 0.0f;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient than computing the inverse in one-shot
        ///     cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector2F Solve(Vector2F b)
        {
            float a11 = Ex.X, a12 = Ey.X, a21 = Ex.Y, a22 = Ey.Y;
            float det = a11 * a22 - a12 * a21;
            if (det != 0.0f)
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
        public static void Add(ref Matrix2X2F a, ref Matrix2X2F b, out Matrix2X2F r)
        {
            r.Ex = a.Ex + b.Ex;
            r.Ey = a.Ey + b.Ey;
        }
    }
}