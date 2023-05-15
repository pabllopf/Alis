// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3Ext.cs
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

using System.Numerics;

namespace Alis.Core.Graphic.OpenGL.NumericsExtensions
{
    /// <summary>
    ///     The vector ext class
    /// </summary>
    public static class Vector3Ext
    {
        /// <summary>
        ///     Store the minimum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMin on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMin(this Vector3 tv, Vector3 v)
        {
            if (v.X < tv.X)
            {
                tv.X = v.X;
            }

            if (v.Y < tv.Y)
            {
                tv.Y = v.Y;
            }

            if (v.Z < tv.Z)
            {
                tv.Z = v.Z;
            }
        }

        /// <summary>
        ///     Store the maximum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMax on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMax(this Vector3 tv, Vector3 v)
        {
            if (v.X > tv.X)
            {
                tv.X = v.X;
            }

            if (v.Y > tv.Y)
            {
                tv.Y = v.Y;
            }

            if (v.Z > tv.Z)
            {
                tv.Z = v.Z;
            }
        }

        /// <summary>
        ///     Normalizes the Vector3 structure to have a peak value of one.
        /// </summary>
        /// <param name="v">The Vector3 to perform the Normalize on.</param>
        /// <returns>if (Length = 0) return Zero; else return Vector3(x,y,z)/Length.</returns>
        public static Vector3 Normalize(this Vector3 v)
        {
            if (v.Length() == 0)
            {
                return Vector3.Zero;
            }

            return new Vector3(v.X, v.Y, v.Z) / v.Length();
        }

        /// <summary>
        ///     Performs the Vector3 scalar dot product.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the dot product on.</param>
        /// <param name="v">Second dot product term.</param>
        /// <returns>Vector3.Dot(this, v).</returns>
        public static float Dot(this Vector3 tv, Vector3 v) => Vector3.Dot(tv, v);

        /// <summary>
        ///     Provide an accessor for each of the elements of the Vector structure.
        /// </summary>
        /// <param name="v">The Vector3 to access.</param>
        /// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z).</param>
        /// <returns>The element of the Vector3 as indexed by i.</returns>
        public static float Get(this Vector3 v, int index) => index == 0 ? v.X : index == 1 ? v.Y : v.Z;
    }
}