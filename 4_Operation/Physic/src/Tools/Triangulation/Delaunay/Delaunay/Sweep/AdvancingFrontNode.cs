// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancingFrontNode.cs
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

// Changes from the Java version
//   Removed getters
//   Has* turned into attributes
// Future possibilities
//   Comments!

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep
{
    /// <summary>
    ///     The advancing front node class
    /// </summary>
    internal class AdvancingFrontNode
    {
        /// <summary>
        ///     The next
        /// </summary>
        public AdvancingFrontNode Next;

        /// <summary>
        ///     The point
        /// </summary>
        public TriangulationPoint Point;

        /// <summary>
        ///     The prev
        /// </summary>
        public AdvancingFrontNode Prev;

        /// <summary>
        ///     The triangle
        /// </summary>
        public DelaunayTriangle Triangle;

        /// <summary>
        ///     The value
        /// </summary>
        public double Value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdvancingFrontNode" /> class
        /// </summary>
        /// <param name="point">The point</param>
        public AdvancingFrontNode(TriangulationPoint point)
        {
            Point = point;
            Value = point.X;
        }

        /// <summary>
        ///     Gets the value of the has next
        /// </summary>
        public bool HasNext => Next != null;

        /// <summary>
        ///     Gets the value of the has prev
        /// </summary>
        public bool HasPrev => Prev != null;
    }
}