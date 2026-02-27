// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancingFrontNodeTest.cs
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

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The advancing front node test class
    /// </summary>
    public class AdvancingFrontNodeTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with point
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithPoint()
        {
            TriangulationPoint point = new TriangulationPoint(5.0, 10.0);
            
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.Equal(point, node.Point);
            Assert.Equal(point.X, node.Value);
            Assert.Null(node.Next);
            Assert.Null(node.Prev);
            Assert.Null(node.Triangle);
        }

        /// <summary>
        ///     Tests that value should equal point x coordinate
        /// </summary>
        [Fact]
        public void Value_ShouldEqualPointXCoordinate()
        {
            TriangulationPoint point = new TriangulationPoint(15.5, 20.0);
            
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.Equal(15.5, node.Value);
        }

        /// <summary>
        ///     Tests that has next should return false initially
        /// </summary>
        [Fact]
        public void HasNext_ShouldReturnFalseInitially()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.False(node.HasNext);
        }

        /// <summary>
        ///     Tests that has prev should return false initially
        /// </summary>
        [Fact]
        public void HasPrev_ShouldReturnFalseInitially()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.False(node.HasPrev);
        }

        /// <summary>
        ///     Tests that next property should set and get correctly
        /// </summary>
        [Fact]
        public void NextProperty_ShouldSetAndGetCorrectly()
        {
            AdvancingFrontNode node1 = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode node2 = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            
            node1.Next = node2;
            
            Assert.Equal(node2, node1.Next);
            Assert.True(node1.HasNext);
        }

        /// <summary>
        ///     Tests that prev property should set and get correctly
        /// </summary>
        [Fact]
        public void PrevProperty_ShouldSetAndGetCorrectly()
        {
            AdvancingFrontNode node1 = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode node2 = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            
            node2.Prev = node1;
            
            Assert.Equal(node1, node2.Prev);
            Assert.True(node2.HasPrev);
        }

        /// <summary>
        ///     Tests that triangle property should set and get correctly
        /// </summary>
        [Fact]
        public void TriangleProperty_ShouldSetAndGetCorrectly()
        {
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            
            node.Triangle = triangle;
            
            Assert.Equal(triangle, node.Triangle);
        }

        /// <summary>
        ///     Tests that advancing front node should support linked list structure
        /// </summary>
        [Fact]
        public void AdvancingFrontNode_ShouldSupportLinkedListStructure()
        {
            AdvancingFrontNode node1 = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode node2 = new AdvancingFrontNode(new TriangulationPoint(5, 0));
            AdvancingFrontNode node3 = new AdvancingFrontNode(new TriangulationPoint(10, 0));
            
            node1.Next = node2;
            node2.Prev = node1;
            node2.Next = node3;
            node3.Prev = node2;
            
            Assert.Equal(node2, node1.Next);
            Assert.Equal(node1, node2.Prev);
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node2, node3.Prev);
        }

        /// <summary>
        ///     Tests that advancing front node should handle negative coordinates
        /// </summary>
        [Fact]
        public void AdvancingFrontNode_ShouldHandleNegativeCoordinates()
        {
            TriangulationPoint point = new TriangulationPoint(-10.5, -20.5);
            
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.Equal(-10.5, node.Value);
        }

        /// <summary>
        ///     Tests that advancing front node should handle zero coordinates
        /// </summary>
        [Fact]
        public void AdvancingFrontNode_ShouldHandleZeroCoordinates()
        {
            TriangulationPoint point = new TriangulationPoint(0, 0);
            
            AdvancingFrontNode node = new AdvancingFrontNode(point);
            
            Assert.Equal(0, node.Value);
        }
    }
}

