// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Bvec3.cs
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

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     <see cref="Bvec3" /> is a struct represent a glsl bvec3 value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec3
    {
        /// <summary>
        ///     Construct the <see cref="Bvec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Bvec3(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;

        /// <summary>Depth component of the vector</summary>
        public bool Z;
    }
}