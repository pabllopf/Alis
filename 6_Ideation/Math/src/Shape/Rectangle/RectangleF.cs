// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleF.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Shape.Rectangle
{
    /// <summary>
    ///     The sdl f rect
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleF : IShape
    {
        /// <summary>
        ///     The
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float W { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float H { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RectangleF" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public RectangleF(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <returns>The bool</returns>
        public bool Contains(Vector2F pos) => (pos.X >= X) && (pos.X <= X + W) && (pos.Y >= Y) && (pos.Y <= Y + H);
    }
}