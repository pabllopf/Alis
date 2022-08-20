// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix33.cs
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
    ///     A 3-by-3 matrix. Stored in column-major order.
    /// </summary>
    public struct Matrix33
    {
        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        public Matrix33(Vector3 c1, Vector3 c2, Vector3 c3)
        {
            Col1 = c1;
            Col2 = c2;
            Col3 = c3;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            Col1.SetZero();
            Col2.SetZero();
            Col3.SetZero();
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        public Vector3 Solve33(Vector3 b)
        {
            float det = Vector3.Dot(Col1, Vector3.Cross(Col2, Col3));
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            Vector3 x = new Vector3();
            x.X = det * Vector3.Dot(b, Vector3.Cross(Col2, Col3));
            x.Y = det * Vector3.Dot(Col1, Vector3.Cross(b, Col3));
            x.Z = det * Vector3.Dot(Col1, Vector3.Cross(Col2, b));
            return x;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases. Solve only the upper
        ///     2-by-2 matrix equation.
        /// </summary>
        public Vector2 Solve22(Vector2 b)
        {
            float a11 = Col1.X, a12 = Col2.X, a21 = Col1.Y, a22 = Col2.Y;
            float det = a11 * a22 - a12 * a21;
            //Box2DxDebug.Assert(det != 0.0f);
            det = 1.0f / det;
            Vector2 x = new Vector2();
            x.X = det * (a22 * b.X - a12 * b.Y);
            x.Y = det * (a11 * b.Y - a21 * b.X);
            return x;
        }

        /// <summary>
        ///     The col
        /// </summary>
        public Vector3 Col1 { get; set; }

        /// <summary>
        ///     The col
        /// </summary>
        public Vector3 Col2 { get; set; }

        /// <summary>
        ///     The col
        /// </summary>
        public Vector3 Col3 { get; set; }
    }
}