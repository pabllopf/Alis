// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationPointTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulation point test class
    /// </summary>
    public class TriangulationPointTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with coordinates
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithCoordinates()
        {
            double x = 5.0;
            double y = 10.0;
            
            TriangulationPoint point = new TriangulationPoint(x, y);
            
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        /// <summary>
        ///     Tests that xf property should get and set correctly
        /// </summary>
        [Fact]
        public void XfProperty_ShouldGetAndSetCorrectly()
        {
            TriangulationPoint point = new TriangulationPoint(5.0, 10.0);
            
            point.Xf = 15.0f;
            
            Assert.Equal(15.0f, point.Xf);
            Assert.Equal(15.0, point.X);
        }

        /// <summary>
        ///     Tests that yf property should get and set correctly
        /// </summary>
        [Fact]
        public void YfProperty_ShouldGetAndSetCorrectly()
        {
            TriangulationPoint point = new TriangulationPoint(5.0, 10.0);
            
            point.Yf = 20.0f;
            
            Assert.Equal(20.0f, point.Yf);
            Assert.Equal(20.0, point.Y);
        }

        /// <summary>
        ///     Tests that has edges should return false initially
        /// </summary>
        [Fact]
        public void HasEdges_ShouldReturnFalseInitially()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            
            Assert.False(point.HasEdges);
        }

        /// <summary>
        ///     Tests that add edge should initialize edges list
        /// </summary>
        [Fact]
        public void AddEdge_ShouldInitializeEdgesList()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            TriangulationPoint p1 = new TriangulationPoint(1, 0);
            TriangulationPoint p2 = new TriangulationPoint(0, 1);
            DtSweepConstraint edge = new DtSweepConstraint(p1, p2);
            
            point.AddEdge(edge);
            
            Assert.True(point.HasEdges);
            Assert.NotNull(point.Edges);
            Assert.Single(point.Edges);
        }

        /// <summary>
        ///     Tests that add edge should add multiple edges
        /// </summary>
        [Fact]
        public void AddEdge_ShouldAddMultipleEdges()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            TriangulationPoint p1 = new TriangulationPoint(1, 0);
            TriangulationPoint p2 = new TriangulationPoint(0, 1);
            DtSweepConstraint edge1 = new DtSweepConstraint(p1, p2);
            DtSweepConstraint edge2 = new DtSweepConstraint(p2, p1);
            
            point.AddEdge(edge1);
            point.AddEdge(edge2);
            
            Assert.Equal(2, point.Edges.Count);
        }

        /// <summary>
        ///     Tests that to string should return formatted string
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            TriangulationPoint point = new TriangulationPoint(5.5, 10.5);
            
            string result = point.ToString();
            
            Assert.Contains("5", result);
            Assert.Contains("10", result);
        }

        /// <summary>
        ///     Tests that triangulation point should handle negative coordinates
        /// </summary>
        [Fact]
        public void TriangulationPoint_ShouldHandleNegativeCoordinates()
        {
            TriangulationPoint point = new TriangulationPoint(-5.0, -10.0);
            
            Assert.Equal(-5.0, point.X);
            Assert.Equal(-10.0, point.Y);
        }

        /// <summary>
        ///     Tests that triangulation point should handle zero coordinates
        /// </summary>
        [Fact]
        public void TriangulationPoint_ShouldHandleZeroCoordinates()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            
            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
        }

        /// <summary>
        ///     Tests that triangulation point should handle large coordinates
        /// </summary>
        [Fact]
        public void TriangulationPoint_ShouldHandleLargeCoordinates()
        {
            TriangulationPoint point = new TriangulationPoint(10000.0, 20000.0);
            
            Assert.Equal(10000.0, point.X);
            Assert.Equal(20000.0, point.Y);
        }

        /// <summary>
        ///     Tests that xf and yf should convert between double and float
        /// </summary>
        [Fact]
        public void XfAndYf_ShouldConvertBetweenDoubleAndFloat()
        {
            TriangulationPoint point = new TriangulationPoint(5.5, 10.5);
            
            float xf = point.Xf;
            float yf = point.Yf;
            
            Assert.Equal(5.5f, xf);
            Assert.Equal(10.5f, yf);
        }

        /// <summary>
        ///     Tests that edges property should be null initially
        /// </summary>
        [Fact]
        public void EdgesProperty_ShouldBeNullInitially()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            
            Assert.Null(point.Edges);
        }
    }
}

