// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangleTest.cs
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
    /// The delaunay triangle test class
    /// </summary>
    public class DelaunayTriangleTest
    {
        /// <summary>
        /// Tests that delaunay triangle type should be accessible
        /// </summary>
        [Fact]
        public void DelaunayTriangle_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DelaunayTriangle));
        }

        /// <summary>
        /// Tests that constructor should set three points
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetThreePoints()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Contains(p1, triangle.Points);
            Assert.Contains(p2, triangle.Points);
            Assert.Contains(p3, triangle.Points);
        }

        /// <summary>
        /// Tests that contains should return true for contained point
        /// </summary>
        [Fact]
        public void Contains_WithContainedPoint_ShouldReturnTrue()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.True(triangle.Contains(p1));
            Assert.True(triangle.Contains(p2));
            Assert.True(triangle.Contains(p3));
        }

        /// <summary>
        /// Tests that contains should return false for unknown point
        /// </summary>
        [Fact]
        public void Contains_WithUnknownPoint_ShouldReturnFalse()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.False(triangle.Contains(p4));
        }

        /// <summary>
        /// Tests that index of should find point index
        /// </summary>
        [Fact]
        public void IndexOf_ShouldFindPointIndex()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(0, triangle.IndexOf(p1));
            Assert.Equal(1, triangle.IndexOf(p2));
            Assert.Equal(2, triangle.IndexOf(p3));
        }
    }
}
