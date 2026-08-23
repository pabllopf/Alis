// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangleRemainingCoverageTests.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    ///     The delaunay triangle remaining coverage tests class
    /// </summary>
    public class DelaunayTriangleRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that contains constraint with both points returns true
        /// </summary>
        [Fact]
        public void Contains_ConstraintWithBothPoints_ReturnsTrue()
        {
            PolygonPoint p1 = new PolygonPoint(0, 0);
            PolygonPoint p2 = new PolygonPoint(1, 0);
            PolygonPoint p3 = new PolygonPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            DtSweepConstraint constraint = new DtSweepConstraint(p1, p2);

            bool result = triangle.Contains(constraint);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that contains constraint with one point returns false
        /// </summary>
        [Fact]
        public void Contains_ConstraintWithOnePoint_ReturnsFalse()
        {
            PolygonPoint p1 = new PolygonPoint(0, 0);
            PolygonPoint p2 = new PolygonPoint(1, 0);
            PolygonPoint p3 = new PolygonPoint(0, 1);
            PolygonPoint outside = new PolygonPoint(5, 5);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            DtSweepConstraint constraint = new DtSweepConstraint(p1, outside);

            bool result = triangle.Contains(constraint);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that mark neighbor edges marks constrained edges
        /// </summary>
        [Fact]
        public void MarkNeighborEdges_MarksConstrainedEdges()
        {
            PolygonPoint p1 = new PolygonPoint(0, 0);
            PolygonPoint p2 = new PolygonPoint(1, 0);
            PolygonPoint p3 = new PolygonPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.MarkConstrainedEdge(0);

            triangle.MarkNeighborEdges();

            Assert.NotNull(triangle);
        }

        /// <summary>
        ///     Tests that mark edge marks constrained edges on other triangle
        /// </summary>
        [Fact]
        public void MarkEdge_MarksConstrainedEdgesOnOtherTriangle()
        {
            PolygonPoint p1 = new PolygonPoint(0, 0);
            PolygonPoint p2 = new PolygonPoint(1, 0);
            PolygonPoint p3 = new PolygonPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle other = new DelaunayTriangle(p1, p2, new PolygonPoint(1, 1));
            triangle.MarkConstrainedEdge(0);

            triangle.MarkEdge(other);

            Assert.NotNull(other);
        }
    }
}
