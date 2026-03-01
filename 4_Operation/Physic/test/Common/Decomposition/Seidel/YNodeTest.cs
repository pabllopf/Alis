// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YNodeTest.cs
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
    ///     The y node test class
    /// </summary>
    public class YNodeTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with edge and children
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithEdgeAndChildren()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Edge edge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            YNode yNode = new YNode(edge, leftChild, rightChild);
            
            Assert.NotNull(yNode);
        }

        /// <summary>
        ///     Tests that locate should return right child when edge is above
        /// </summary>
        [Fact]
        public void Locate_ShouldReturnRightChild_WhenEdgeIsAbove()
        {
            Point p1 = new Point(0, 5);
            Point p2 = new Point(10, 5);
            Edge splitEdge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            YNode yNode = new YNode(splitEdge, leftChild, rightChild);
            
            Point testStart = new Point(5, 0);
            Point testEnd = new Point(6, 1);
            Edge testEdge = new Edge(testStart, testEnd);
            
            Sink result = yNode.Locate(testEdge);
            
            Assert.Equal(rightChild, result);
        }

        /// <summary>
        ///     Tests that locate should return left child when edge is below
        /// </summary>
        [Fact]
        public void Locate_ShouldReturnLeftChild_WhenEdgeIsBelow()
        {
            Point p1 = new Point(0, 5);
            Point p2 = new Point(10, 5);
            Edge splitEdge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            YNode yNode = new YNode(splitEdge, leftChild, rightChild);
            
            Point testStart = new Point(5, 10);
            Point testEnd = new Point(6, 11);
            Edge testEdge = new Edge(testStart, testEnd);
            
            Sink result = yNode.Locate(testEdge);
            
            Assert.Equal(leftChild, result);
        }

        /// <summary>
        ///     Tests that locate should handle edge with lower slope
        /// </summary>
        [Fact]
        public void Locate_ShouldHandleEdgeWithLowerSlope()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Edge splitEdge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            YNode yNode = new YNode(splitEdge, leftChild, rightChild);
            
            Point testStart = new Point(0, 0);
            Point testEnd = new Point(10, 5);
            Edge testEdge = new Edge(testStart, testEnd);
            
            Sink result = yNode.Locate(testEdge);
            
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that y node should inherit from node
        /// </summary>
        [Fact]
        public void YNode_ShouldInheritFromNode()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Edge edge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            YNode yNode = new YNode(edge, leftChild, rightChild);
            
            Assert.IsAssignableFrom<Node>(yNode);
        }

        /// <summary>
        ///     Tests that y node should handle horizontal edge
        /// </summary>
        [Fact]
        public void YNode_ShouldHandleHorizontalEdge()
        {
            Point p1 = new Point(0, 5);
            Point p2 = new Point(10, 5);
            Edge splitEdge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            YNode yNode = new YNode(splitEdge, leftChild, rightChild);
            
            Assert.NotNull(yNode);
        }

        /// <summary>
        ///     Tests that y node should handle vertical edge
        /// </summary>
        [Fact]
        public void YNode_ShouldHandleVerticalEdge()
        {
            Point p1 = new Point(5, 0);
            Point p2 = new Point(5, 10);
            Edge splitEdge = new Edge(p1, p2);
            Trapezoid leftTrap = CreateTestTrapezoid();
            Trapezoid rightTrap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(leftTrap);
            Sink rightChild = Sink.Isink(rightTrap);
            
            YNode yNode = new YNode(splitEdge, leftChild, rightChild);
            
            Assert.NotNull(yNode);
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

