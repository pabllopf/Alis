// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepPointComparator.cs
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

using System.Collections.Generic;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep point comparator class
    /// </summary>
    /// <seealso cref="IComparer{T}" />
    internal class DtSweepPointComparator : IComparer<TriangulationPoint>
    {
        /// <summary>
        ///     Compares the p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The int</returns>
        public int Compare(TriangulationPoint p1, TriangulationPoint p2)
        {
            if (p2 != null && p1 != null && p1.Y < p2.Y)
            {
                return -1;
            }

            if (p2 != null && p1 != null && p1.Y > p2.Y)
            {
                return 1;
            }

            if (p2 != null && p1 != null && p1.X < p2.X)
            {
                return -1;
            }

            if (p2 != null && p1 != null && p1.X > p2.X)
            {
                return 1;
            }

            return 0;
        }
    }
}