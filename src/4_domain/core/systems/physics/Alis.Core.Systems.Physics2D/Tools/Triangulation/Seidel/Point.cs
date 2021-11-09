// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Point.cs
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

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Seidel
{
    /// <summary>
    ///     The point class
    /// </summary>
    internal class Point
    {
        // Pointers to next and previous points in Monontone Mountain
        /// <summary>
        ///     The prev
        /// </summary>
        public Point Next, Prev;

        /// <summary>
        ///     The
        /// </summary>
        public float X, Y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Point" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
            Next = null;
            Prev = null;
        }

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator -(Point p1, float f) => new Point(p1.X - f, p1.Y - f);

        public static Point operator +(Point p1, float f) => new Point(p1.X + f, p1.Y + f);

        /// <summary>
        ///     Crosses the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The float</returns>
        public float Cross(Point p) => X * p.Y - Y * p.X;

        /// <summary>
        ///     Dots the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The float</returns>
        public float Dot(Point p) => X * p.X + Y * p.Y;

        /// <summary>
        ///     Describes whether this instance neq
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool Neq(Point p) => p.X != X || p.Y != Y;

        /// <summary>
        ///     Orients the 2 d using the specified pb
        /// </summary>
        /// <param name="pb">The pb</param>
        /// <param name="pc">The pc</param>
        /// <returns>The float</returns>
        public float Orient2D(Point pb, Point pc)
        {
            float acx = X - pc.X;
            float bcx = pb.X - pc.X;
            float acy = Y - pc.Y;
            float bcy = pb.Y - pc.Y;
            return acx * bcy - acy * bcx;
        }
    }
}