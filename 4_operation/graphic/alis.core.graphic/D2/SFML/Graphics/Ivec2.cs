// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec2.cs
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

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Ivec2" /> is a struct represent a glsl ivec2 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec2
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector2I" /> to <see cref="Ivec2" />
        /// </summary>
        public static implicit operator Ivec2(Vector2I vec) => new Ivec2(vec);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from a standard SFML <see cref="Vector2I" />
        /// </summary>
        /// <param name="vec">A standard SFML 2D integer vector</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(Vector2I vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;
    }
}