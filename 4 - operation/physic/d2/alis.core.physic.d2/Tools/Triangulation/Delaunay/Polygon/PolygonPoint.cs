// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonPoint.cs
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

// Changes from the Java version
//   Replaced get/set GetNext/Previous with attributes
// Future possibilities
//   Documentation!

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay.Polygon
{
    /// <summary>
    ///     The polygon point class
    /// </summary>
    /// <seealso cref="TriangulationPoint" />
    internal class PolygonPoint : TriangulationPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonPoint" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public PolygonPoint(double x, double y) : base(x, y)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the next
        /// </summary>
        public PolygonPoint Next { get; set; }

        /// <summary>
        ///     Gets or sets the value of the previous
        /// </summary>
        public PolygonPoint Previous { get; set; }
    }
}