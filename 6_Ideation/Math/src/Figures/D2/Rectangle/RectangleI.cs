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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Figures.D2.Rectangle
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     RectangleI is an utility class for manipulating 2D rectangles
    ///     with integer coordinates
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleI : IEquatable<RectangleI>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the rectangle from its coordinates
        /// </summary>
        /// <param name="left">Left coordinate of the rectangle</param>
        /// <param name="top">Top coordinate of the rectangle</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        ////////////////////////////////////////////////////////////
        public RectangleI(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the rectangle from position and size
        /// </summary>
        /// <param name="position">Position of the top-left corner of the rectangle</param>
        /// <param name="size">Size of the rectangle</param>
        ////////////////////////////////////////////////////////////
        public RectangleI(Vector2I position, Vector2I size)
            : this(position.X, position.Y, size.X, size.Y)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check if a point is inside the rectangle's area
        /// </summary>
        /// <param name="x">X coordinate of the point to test</param>
        /// <param name="y">Y coordinate of the point to test</param>
        /// <returns>True if the point is inside</returns>
        ////////////////////////////////////////////////////////////
        public bool Contains(int x, int y)
        {
            int minX = System.Math.Min(Left, Left + Width);
            int maxX = System.Math.Max(Left, Left + Width);
            int minY = System.Math.Min(Top, Top + Height);
            int maxY = System.Math.Max(Top, Top + Height);

            return (x >= minX) && (x < maxX) && (y >= minY) && (y < maxY);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check intersection between two rectangles
        /// </summary>
        /// <param name="rect"> Rectangle to test</param>
        /// <returns>True if rectangles overlap</returns>
        ////////////////////////////////////////////////////////////
        public bool Intersects(RectangleI rect)
        {
            RectangleI overlap;
            return Intersects(rect, out overlap);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check intersection between two rectangles
        /// </summary>
        /// <param name="rect"> Rectangle to test</param>
        /// <param name="overlap">Rectangle to be filled with overlapping rect</param>
        /// <returns>True if rectangles overlap</returns>
        ////////////////////////////////////////////////////////////
        public bool Intersects(RectangleI rect, out RectangleI overlap)
        {
            // Rectangles with negative dimensions are allowed, so we must handle them correctly

            // Compute the min and max of the first rectangle on both axes
            int r1MinX = System.Math.Min(Left, Left + Width);
            int r1MaxX = System.Math.Max(Left, Left + Width);
            int r1MinY = System.Math.Min(Top, Top + Height);
            int r1MaxY = System.Math.Max(Top, Top + Height);

            // Compute the min and max of the second rectangle on both axes
            int r2MinX = System.Math.Min(rect.Left, rect.Left + rect.Width);
            int r2MaxX = System.Math.Max(rect.Left, rect.Left + rect.Width);
            int r2MinY = System.Math.Min(rect.Top, rect.Top + rect.Height);
            int r2MaxY = System.Math.Max(rect.Top, rect.Top + rect.Height);

            // Compute the intersection boundaries
            int interLeft = System.Math.Max(r1MinX, r2MinX);
            int interTop = System.Math.Max(r1MinY, r2MinY);
            int interRight = System.Math.Min(r1MaxX, r2MaxX);
            int interBottom = System.Math.Min(r1MaxY, r2MaxY);

            // If the intersection is valid (positive non zero area), then there is an intersection
            if ((interLeft < interRight) && (interTop < interBottom))
            {
                overlap.Left = interLeft;
                overlap.Top = interTop;
                overlap.Width = interRight - interLeft;
                overlap.Height = interBottom - interTop;
                return true;
            }

            overlap.Left = 0;
            overlap.Top = 0;
            overlap.Width = 0;
            overlap.Height = 0;
            return false;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[RectangleI] Left({Left}) Top({Top}) Width({Width}) Height({Height})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare rectangle and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and rectangle are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => obj is RectangleI && Equals((RectangleI) obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two rectangles and checks if they are equal
        /// </summary>
        /// <param name="other">Rectangle to check</param>
        /// <returns>Rectangles are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(RectangleI other) => (Left == other.Left) &&
                                             (Top == other.Top) &&
                                             (Width == other.Width) &&
                                             (Height == other.Height);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => unchecked((int) ((uint) Left ^
                                                              (((uint) Top << 13) | ((uint) Top >> 19)) ^
                                                              (((uint) Width << 26) | ((uint) Width >> 6)) ^
                                                              (((uint) Height << 7) | ((uint) Height >> 25))));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator == overload ; check rect equality
        /// </summary>
        /// <param name="r1">First rect</param>
        /// <param name="r2">Second rect</param>
        /// <returns>r1 == r2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(RectangleI r1, RectangleI r2) => r1.Equals(r2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator != overload ; check rect inequality
        /// </summary>
        /// <param name="r1">First rect</param>
        /// <param name="r2">Second rect</param>
        /// <returns>r1 != r2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(RectangleI r1, RectangleI r2) => !r1.Equals(r2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Explicit casting to another rectangle type
        /// </summary>
        /// <param name="r">Rectangle being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator RectangleF(RectangleI r) => new RectangleF(r.Left,
            r.Top,
            r.Width,
            r.Height);

        /// <summary>Left coordinate of the rectangle</summary>
        public int Left;

        /// <summary>Top coordinate of the rectangle</summary>
        public int Top;

        /// <summary>Width of the rectangle</summary>
        public int Width;

        /// <summary>Height of the rectangle</summary>
        public int Height;
    }

    ////////////////////////////////////////////////////////////
}