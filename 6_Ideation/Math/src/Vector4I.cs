// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4I.cs
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

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     <see cref="Vector4I" /> is a struct represent a glsl ivec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4I
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vector4I" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector4I(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /*
        /// <summary>
        ///     Construct the <see cref="Vector4I" /> from a <see cref="Color" />
        /// </summary>
        /// <param name="color">A SFML <see cref="Color" /> to be translated to a 4D integer vector</param>
        public Vector4I(Color color)
        {
            X = color.R;
            Y = color.G;
            Z = color.B;
            W = color.A;
        }*/

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;

        /// <summary>Depth component of the vector</summary>
        public int Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public int W;
    }
}