// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangleLatestCoverageTests.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    ///     The delaunay triangle latest coverage tests class
    /// </summary>
    public class DelaunayTriangleLatestCoverageTests
    {
        /// <summary>
        ///     Tests that contains with constraint whose start point is outside returns false
        /// </summary>
        [Fact]
        public void Contains_ConstraintWithOutsideStartPoint_ReturnsFalse()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            DtSweepConstraint constraint = new DtSweepConstraint(new TriangulationPoint(0.5, -1.0), p3);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.False(triangle.Contains(constraint));
        }

        /// <summary>
        ///     Tests that mark neighbor with reversed edge zero points sets neighbor at index zero
        /// </summary>
        [Fact]
        public void MarkNeighbor_ReversedEdgeZeroPoints_SetsNeighborAtIndexZero()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle first = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle second = new DelaunayTriangle(p2, p4, p1);

            first.MarkNeighbor(p3, p2, second);

            Assert.Equal(second, first.Neighbors[0]);
        }

        /// <summary>
        ///     Tests that mark neighbor with reversed edge one points sets neighbor at index one
        /// </summary>
        [Fact]
        public void MarkNeighbor_ReversedEdgeOnePoints_SetsNeighborAtIndexOne()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle first = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle second = new DelaunayTriangle(p4, p1, p3);

            first.MarkNeighbor(p3, p1, second);

            Assert.Equal(second, first.Neighbors[1]);
        }

        /// <summary>
        ///     Tests that mark neighbor with reversed edge two points sets neighbor at index two
        /// </summary>
        [Fact]
        public void MarkNeighbor_ReversedEdgeTwoPoints_SetsNeighborAtIndexTwo()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle first = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle second = new DelaunayTriangle(p4, p2, p1);

            first.MarkNeighbor(p2, p1, second);

            Assert.Equal(second, first.Neighbors[2]);
        }

        /// <summary>
        ///     Tests that mark neighbor with second point outside leaves neighbors empty
        /// </summary>
        [Fact]
        public void MarkNeighbor_SecondPointOutside_LeavesNeighborsEmpty()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint outside = new TriangulationPoint(5.0, 5.0);
            TriangulationPoint p5 = new TriangulationPoint(6.0, 6.0);

            DelaunayTriangle first = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle second = new DelaunayTriangle(p2, p3, p5);

            first.MarkNeighbor(p3, outside, second);

            Assert.Null(first.Neighbors[0]);
            Assert.Null(first.Neighbors[1]);
            Assert.Null(first.Neighbors[2]);
        }

        /// <summary>
        ///     Tests that to string after clear returns separated empty values
        /// </summary>
        [Fact]
        public void ToString_AfterClear_ReturnsSeparatedEmptyValues()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.Clear();

            Assert.Equal(",,", triangle.ToString());
        }

        /// <summary>
        ///     Tests that edge index with reversed order returns edge zero
        /// </summary>
        [Fact]
        public void EdgeIndex_ReversedOrder_ReturnsEdgeZero()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(0, triangle.EdgeIndex(p3, p2));
        }
    }
}
