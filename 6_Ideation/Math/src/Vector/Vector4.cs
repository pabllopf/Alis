// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Vector4.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     <see cref="Vector4" /> is a struct represent a glsl vec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vector4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }


        /// <summary>
        ///     Gets the v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="index">The index</param>
        /// <returns>The float</returns>
        public static float Get(Vector4 v, int index)
        {
            switch (index)
            {
                case 0: return v.X;
                case 1: return v.Y;
                case 2: return v.Z;
                case 3: return v.W;
                default: return 0; // error case
            }
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;

        /// <summary>Depth component of the vector</summary>
        public float Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public float W;
    }
}