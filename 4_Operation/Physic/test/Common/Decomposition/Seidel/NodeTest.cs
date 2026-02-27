// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NodeTest.cs
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
    ///     The node test class
    /// </summary>
    public class NodeTest
    {
        /// <summary>
        ///     The test node class
        /// </summary>
        /// <seealso cref="Node" />
        private class TestNode : Node
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestNode" /> class
            /// </summary>
            /// <param name="left">The left</param>
            /// <param name="right">The right</param>
            public TestNode(Node left, Node right) : base(left, right) { }

            /// <summary>
            ///     Locates the edge
            /// </summary>
            /// <param name="edge">The edge</param>
            /// <returns>The sink</returns>
            public override Sink Locate(Edge edge) => null;
        }

        /// <summary>
        ///     Tests that constructor should initialize with null children
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithNullChildren()
        {
            TestNode node = new TestNode(null, null);
            
            Assert.NotNull(node);
            Assert.NotNull(node.ParentList);
            Assert.Empty(node.ParentList);
        }

        /// <summary>
        ///     Tests that constructor should add this node to children parent lists
        /// </summary>
        [Fact]
        public void Constructor_ShouldAddThisNodeToChildrenParentLists()
        {
            Trapezoid trap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(trap);
            Sink rightChild = Sink.Isink(CreateTestTrapezoid());
            
            TestNode node = new TestNode(leftChild, rightChild);
            
            Assert.Contains(node, leftChild.ParentList);
            Assert.Contains(node, rightChild.ParentList);
        }

        /// <summary>
        ///     Tests that parent list should be initialized
        /// </summary>
        [Fact]
        public void ParentList_ShouldBeInitialized()
        {
            TestNode node = new TestNode(null, null);
            
            Assert.NotNull(node.ParentList);
        }

        /// <summary>
        ///     Tests that node should be abstract class
        /// </summary>
        [Fact]
        public void Node_ShouldBeAbstractClass()
        {
            var type = typeof(Node);
            
            Assert.True(type.IsAbstract);
        }

        /// <summary>
        ///     Tests that node should support child nodes
        /// </summary>
        [Fact]
        public void Node_ShouldSupportChildNodes()
        {
            Trapezoid trap1 = CreateTestTrapezoid();
            Trapezoid trap2 = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(trap1);
            Sink rightChild = Sink.Isink(trap2);
            
            TestNode node = new TestNode(leftChild, rightChild);
            
            Assert.NotNull(node);
            Assert.Equal(2, leftChild.ParentList.Count + rightChild.ParentList.Count);
        }

        /// <summary>
        ///     Tests that node should allow multiple parents
        /// </summary>
        [Fact]
        public void Node_ShouldAllowMultipleParents()
        {
            Trapezoid trap = CreateTestTrapezoid();
            Sink child = Sink.Isink(trap);
            
            TestNode parent1 = new TestNode(child, null);
            TestNode parent2 = new TestNode(child, null);
            
            Assert.Equal(2, child.ParentList.Count);
        }

        /// <summary>
        ///     Tests that node with only left child should initialize correctly
        /// </summary>
        [Fact]
        public void NodeWithOnlyLeftChild_ShouldInitializeCorrectly()
        {
            Trapezoid trap = CreateTestTrapezoid();
            Sink leftChild = Sink.Isink(trap);
            
            TestNode node = new TestNode(leftChild, null);
            
            Assert.Contains(node, leftChild.ParentList);
        }

        /// <summary>
        ///     Tests that node with only right child should initialize correctly
        /// </summary>
        [Fact]
        public void NodeWithOnlyRightChild_ShouldInitializeCorrectly()
        {
            Trapezoid trap = CreateTestTrapezoid();
            Sink rightChild = Sink.Isink(trap);
            
            TestNode node = new TestNode(null, rightChild);
            
            Assert.Contains(node, rightChild.ParentList);
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

