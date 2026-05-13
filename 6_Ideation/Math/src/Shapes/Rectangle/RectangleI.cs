// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleI.cs
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
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Shapes.Rectangle
{
    /// <summary>
    ///     Represents a rectangle defined by its top-left corner position, width, and height using integer coordinates. Implements <see cref="IShape" /> and <see cref="ISerializable" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleI : IShape, ISerializable
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the top-left corner.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the top-left corner.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the width of the rectangle.
        /// </summary>
        public int W { get; set; }

        /// <summary>
        ///     Gets or sets the height of the rectangle.
        /// </summary>
        public int H { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RectangleI" /> struct.
        /// </summary>
        /// <param name="x">The X coordinate of the top-left corner.</param>
        /// <param name="y">The Y coordinate of the top-left corner.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public RectangleI(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            H = h;
            W = w;
        }

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the rectangle's data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
            info.AddValue("w", W);
            info.AddValue("h", H);
        }
    }
}
