// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangleNeighborTests.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    ///     Tests the neighbor-matching branches of <see cref="DelaunayTriangle" />.
    /// </summary>
    public class DelaunayTriangleNeighborTests
    {
        /// <summary>
        ///     Tests that mark neighbor with a triangle sharing the (1,2) edge links both directions.
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithEdge12Shared_LinksBoth()
        {
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(4, 0);
            TriangulationPoint c = new TriangulationPoint(0, 4);
            TriangulationPoint d = new TriangulationPoint(4, 4);
            DelaunayTriangle first = new DelaunayTriangle(a, b, c);
            DelaunayTriangle second = new DelaunayTriangle(b, d, c);

            first.MarkNeighbor(second);

            Assert.Same(second, first.Neighbors[0]);
        }

        /// <summary>
        ///     Tests that clearing a neighbor stored at index one removes it.
        /// </summary>
        [Fact]
        public void ClearNeighbors_WithNeighborAtIndexOne_ClearsIt()
        {
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(4, 0);
            TriangulationPoint c = new TriangulationPoint(0, 4);
            DelaunayTriangle first = new DelaunayTriangle(a, b, c);
            DelaunayTriangle second = new DelaunayTriangle(a, c, b);

            first.MarkNeighbor(second);

            first.ClearNeighbors(second);

            Assert.Null(first.Neighbors[1]);
        }
    }
}
