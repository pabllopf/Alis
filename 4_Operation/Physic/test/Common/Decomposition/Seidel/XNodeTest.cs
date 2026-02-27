// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XNodeTest.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The x node test class
    /// </summary>
    public class XNodeTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with point and children
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithPointAndChildren()
        {
            Point point = new Point(5, 5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            XNode xNode = new XNode(point, leftChild, rightChild);
            
            Assert.NotNull(xNode);
        }

        /// <summary>
        ///     Tests that locate should return right child when edge point x greater or equal
        /// </summary>
        [Fact]
        public void Locate_ShouldReturnRightChild_WhenEdgePointXGreaterOrEqual()
        {
            Point splitPoint = new Point(5, 5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            XNode xNode = new XNode(splitPoint, leftChild, rightChild);
            
            Point edgeStart = new Point(10, 0);
            Point edgeEnd = new Point(20, 10);
            Edge edge = new Edge(edgeStart, edgeEnd);
            
            Sink result = xNode.Locate(edge);
            
            Assert.Equal(rightChild, result);
        }

        /// <summary>
        ///     Tests that locate should return left child when edge point x less than split point
        /// </summary>
        [Fact]
        public void Locate_ShouldReturnLeftChild_WhenEdgePointXLessThanSplitPoint()
        {
            Point splitPoint = new Point(15, 5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            XNode xNode = new XNode(splitPoint, leftChild, rightChild);
            
            Point edgeStart = new Point(5, 0);
            Point edgeEnd = new Point(10, 10);
            Edge edge = new Edge(edgeStart, edgeEnd);
            
            Sink result = xNode.Locate(edge);
            
            Assert.Equal(leftChild, result);
        }

        /// <summary>
        ///     Tests that x node should inherit from node
        /// </summary>
        [Fact]
        public void XNode_ShouldInheritFromNode()
        {
            Point point = new Point(5, 5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            XNode xNode = new XNode(point, leftChild, rightChild);
            
            Assert.IsAssignableFrom<Node>(xNode);
        }

        /// <summary>
        ///     Tests that x node should handle edge at split point
        /// </summary>
        [Fact]
        public void XNode_ShouldHandleEdgeAtSplitPoint()
        {
            Point splitPoint = new Point(10, 5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            XNode xNode = new XNode(splitPoint, leftChild, rightChild);
            
            Point edgeStart = new Point(10, 0);
            Point edgeEnd = new Point(10, 10);
            Edge edge = new Edge(edgeStart, edgeEnd);
            
            Sink result = xNode.Locate(edge);
            
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that x node should handle negative coordinates
        /// </summary>
        [Fact]
        public void XNode_ShouldHandleNegativeCoordinates()
        {
            Point splitPoint = new Point(-5, -5);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            XNode xNode = new XNode(splitPoint, leftChild, rightChild);
            
            Assert.NotNull(xNode);
        }

        /// <summary>
        ///     Tests that x node should support nested structure
        /// </summary>
        [Fact]
        public void XNode_ShouldSupportNestedStructure()
        {
            Point point1 = new Point(5, 5);
            Point point2 = new Point(15, 5);
            Trapezoid trap1 = CreateTestTrapezoid();
            Trapezoid trap2 = CreateTestTrapezoid();
            Trapezoid trap3 = CreateTestTrapezoid();
            Sink sink1 = Sink.Isink(trap1);
            Sink sink2 = Sink.Isink(trap2);
            Sink sink3 = Sink.Isink(trap3);
            
            XNode innerNode = new XNode(point2, sink2, sink3);
            XNode outerNode = new XNode(point1, sink1, innerNode);
            
            Assert.NotNull(outerNode);
        }

        /// <summary>
        ///     Creates the test trapezoid
        /// </summary>
        /// <returns>The trapezoid</returns>
        private Trapezoid CreateTestTrapezoid()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            return new Trapezoid(leftPoint, rightPoint, top, bottom);
        }
    }
}

