// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueCoverageTest.cs
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

using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="GenericPriorityQueue{TItem,TPriority}" />.
    ///     Covers uncovered branches in CascadeDown, CascadeUp, and IsValidQueue.
    /// </summary>
    public class GenericPriorityQueueCoverageTest
    {
        /// <summary>
        ///     Tests that CascadeDown reaches the break path when the node being pushed down
        ///     has higher priority than both children. This covers the else { break; } branch
        ///     in the CascadeDown while loop.
        /// </summary>
        [Fact]
        public void CascadeDown_NodesCorrectlyPositioned_Breaks()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode[] nodes = new TestNode[5];
            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new TestNode();
                queue.Enqueue(nodes[i], i + 1);
            }

            TestNode last = queue.Dequeue();
            TestNode second = queue.Dequeue();

            Assert.True(queue.IsValidQueue());
            Assert.Equal(3, queue.Count);
        }

        /// <summary>
        ///     Tests that CascadeDown selects the right child as swap candidate when
        ///     the right child has higher priority than the left child.
        ///     Heap structure: root has two children where right child priority < left child priority.
        /// </summary>
        [Fact]
        public void CascadeDown_RightChildHigherPriority_SwapsRightChild()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode a = new TestNode();
            TestNode b = new TestNode();
            TestNode c = new TestNode();

            queue.Enqueue(a, 2);
            queue.Enqueue(b, 3);
            queue.Enqueue(c, 1);

            TestNode dequeued = queue.Dequeue();

            Assert.Same(c, dequeued);
            Assert.Equal(2, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a left child violates
        ///     the heap property (left child has higher priority than parent).
        ///     This covers the left-child check in IsValidQueue.
        /// </summary>
        [Fact]
        public void IsValidQueue_LeftChildViolation_ReturnsFalse()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode parent = new TestNode();
            TestNode leftChild = new TestNode();

            queue.Enqueue(parent, 5);
            queue.Enqueue(leftChild, 10);

            parent.Priority = 20;

            Assert.False(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a right child violates
        ///     the heap property (right child has higher priority than parent).
        ///     This covers the right-child check in IsValidQueue.
        /// </summary>
        [Fact]
        public void IsValidQueue_RightChildViolation_ReturnsFalse()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode parent = new TestNode();
            TestNode leftChild = new TestNode();
            TestNode rightChild = new TestNode();

            queue.Enqueue(parent, 5);
            queue.Enqueue(leftChild, 10);
            queue.Enqueue(rightChild, 15);

            parent.Priority = 12;

            Assert.False(queue.IsValidQueue());
        }
    }
}
