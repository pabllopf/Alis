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

namespace Alis.Core.Aspect.Math.Shapes.Rectangle
{
    /// <summary>
    ///     Represents a rectangle defined by its top-left corner position, width, and height using single-precision floating-point coordinates. Implements <see cref="IShape" />.
    ///     Provides a method to test whether a point lies within the rectangle bounds.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RectangleF : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the top-left corner.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the top-left corner.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     Gets or sets the width of the rectangle.
        /// </summary>
        public float W { get; set; }

        /// <summary>
        ///     Gets or sets the height of the rectangle.
        /// </summary>
        public float H { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RectangleF" /> struct.
        /// </summary>
        /// <param name="x">The X coordinate of the top-left corner.</param>
        /// <param name="y">The Y coordinate of the top-left corner.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public RectangleF(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        /// <summary>
        ///     Determines whether the specified point lies within the bounds of this rectangle.
        /// </summary>
        /// <param name="pos">The 2D point to test.</param>
        /// <returns><c>true</c> if the point is inside the rectangle; otherwise, <c>false</c>.</returns>
        public bool Contains(Vector2F pos) => (pos.X >= X) && (pos.X <= X + W) && (pos.Y >= Y) && (pos.Y <= Y + H);
    }
}
