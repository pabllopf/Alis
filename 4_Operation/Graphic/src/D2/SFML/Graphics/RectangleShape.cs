// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleShape.cs
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

using Alis.Core.Aspect.Math;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Specialized shape representing a rectangle
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class RectangleShape : Shape
    {
        /// <summary>
        ///     The my size
        /// </summary>
        private Vector2F mySize;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public RectangleShape() :
            this(new Vector2F(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shape with an initial size
        /// </summary>
        /// <param name="size">Size of the shape</param>
        ////////////////////////////////////////////////////////////
        public RectangleShape(Vector2F size) => Size = size;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shape from another shape
        /// </summary>
        /// <param name="copy">Shape to copy</param>
        ////////////////////////////////////////////////////////////
        public RectangleShape(RectangleShape copy) :
            base(copy)
            => Size = copy.Size;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The size of the rectangle
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Size
        {
            get => mySize;
            set
            {
                mySize = value;
                Update();
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the total number of points of the rectangle.
        /// </summary>
        /// <returns>
        ///     The total point count. For rectangle shapes,
        ///     this number is always 4.
        /// </returns>
        ////////////////////////////////////////////////////////////
        public override uint GetPointCount() => 4;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the position of a point
        ///     The returned point is in local coordinates, that is,
        ///     the shape's transforms (position, rotation, scale) are
        ///     not taken into account.
        ///     The result is undefined if index is out of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to get, in range [0 .. 3]</param>
        /// <returns>index-th point of the shape</returns>
        ////////////////////////////////////////////////////////////
        public override Vector2F GetPoint(uint index)
        {
            switch (index)
            {
                default:
                case 0:
                    return new Vector2F(0, 0);
                case 1:
                    return new Vector2F(mySize.X, 0);
                case 2:
                    return new Vector2F(mySize.X, mySize.Y);
                case 3:
                    return new Vector2F(0, mySize.Y);
            }
        }
    }
}