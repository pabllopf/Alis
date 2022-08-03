// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ConvexShape.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Specialized shape representing a convex polygon
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class ConvexShape : Shape
    {
        /// <summary>
        ///     The my points
        /// </summary>
        private Vector2f[] myPoints;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ConvexShape() : this(0)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shape with an initial point count
        /// </summary>
        /// <param name="pointCount">Number of points of the shape</param>
        ////////////////////////////////////////////////////////////
        public ConvexShape(uint pointCount)
        {
            SetPointCount(pointCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shape from another shape
        /// </summary>
        /// <param name="copy">Shape to copy</param>
        ////////////////////////////////////////////////////////////
        public ConvexShape(ConvexShape copy) : base(copy)
        {
            SetPointCount(copy.GetPointCount());
            for (uint i = 0; i < copy.GetPointCount(); ++i)
            {
                SetPoint(i, copy.GetPoint(i));
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the total number of points of the polygon
        /// </summary>
        /// <returns>The total point count</returns>
        ////////////////////////////////////////////////////////////
        public override uint GetPointCount()
        {
            return (uint)myPoints.Length;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the number of points of the polygon.
        ///     The count must be greater than 2 to define a valid shape.
        /// </summary>
        /// <param name="count">New number of points of the polygon</param>
        ////////////////////////////////////////////////////////////
        public void SetPointCount(uint count)
        {
            Array.Resize(ref myPoints, (int)count);
            Update();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the position of a point
        ///     The returned point is in local coordinates, that is,
        ///     the shape's transforms (position, rotation, scale) are
        ///     not taken into account.
        ///     The result is undefined if index is out of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to get, in range [0 .. PointCount - 1]</param>
        /// <returns>index-th point of the shape</returns>
        ////////////////////////////////////////////////////////////
        public override Vector2f GetPoint(uint index)
        {
            return myPoints[index];
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the position of a point.
        ///     Don't forget that the polygon must remain convex, and
        ///     the points need to stay ordered!
        ///     PointCount must be set first in order to set the total
        ///     number of points. The result is undefined if index is out
        ///     of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to change, in range [0 .. PointCount - 1]</param>
        /// <param name="point">New position of the point</param>
        ////////////////////////////////////////////////////////////
        public void SetPoint(uint index, Vector2f point)
        {
            myPoints[index] = point;
            Update();
        }
    }
}