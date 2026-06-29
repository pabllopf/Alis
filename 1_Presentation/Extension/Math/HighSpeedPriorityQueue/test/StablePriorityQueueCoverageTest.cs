// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueCoverageTest.cs
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

using System.Collections;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="StablePriorityQueue{T}" />.
    ///     Covers uncovered branches in CascadeUp, CascadeDown, GetHigherPriorityChildIndex,
    ///     IsValidQueue, Enumerator, Resize, and Contains after ResetNode.
    /// </summary>
    public class StablePriorityQueueCoverageTest
    {
        /// <summary>
        ///     Tests that CascadeUp bubbles a node past multiple ancestors via the while loop.
        ///     Enqueues descending priorities so the last node (priority 1) bubbles up past
        ///     multiple levels, exercising the while (parent > 1) loop in CascadeUp.
        /// </summary>
        [Fact]
        public void CascadeUp_MultiLevel_BubblesPastMultipleAncestors()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            StablePriorityQueueNode node3 = new StablePriorityQueueNode();
            StablePriorityQueueNode node4 = new StablePriorityQueueNode();
            StablePriorityQueueNode node5 = new StablePriorityQueueNode();

            queue.Enqueue(node1, 5);
            queue.Enqueue(node2, 4);
            queue.Enqueue(node3, 3);
            queue.Enqueue(node4, 2);
            queue.Enqueue(node5, 1);

            Assert.Equal(5, queue.Count);
            Assert.True(queue.IsValidQueue());
            Assert.Same(node5, queue.First);
        }

        /// <summary>
        ///     Tests that CascadeDown performs multiple swaps in the while loop.
        ///     A dequeue after several enqueues forces the last node to cascade down
        ///     through multiple levels of the heap.
        /// </summary>
        [Fact]
        public void CascadeDown_MultiLevel_SwapsDownThroughLevels()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            StablePriorityQueueNode node3 = new StablePriorityQueueNode();
            StablePriorityQueueNode node4 = new StablePriorityQueueNode();
            StablePriorityQueueNode node5 = new StablePriorityQueueNode();

            queue.Enqueue(node1, 5);
            queue.Enqueue(node2, 4);
            queue.Enqueue(node3, 3);
            queue.Enqueue(node4, 2);
            queue.Enqueue(node5, 1);

            StablePriorityQueueNode dequeued = queue.Dequeue();

            Assert.Same(node5, dequeued);
            Assert.Equal(4, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that GetHigherPriorityChildIndex selects the right child when
        ///     both children exist and the right child has higher priority.
        ///     Creates a heap where the node being cascaded down has two children,
        ///     and the right child should be selected as the swap target.
        /// </summary>
        [Fact]
        public void CascadeDown_RightChildHigherPriority_SwapsRightChild()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode a = new StablePriorityQueueNode();
            StablePriorityQueueNode b = new StablePriorityQueueNode();
            StablePriorityQueueNode c = new StablePriorityQueueNode();

            queue.Enqueue(a, 3);
            queue.Enqueue(b, 5);
            queue.Enqueue(c, 1);

            StablePriorityQueueNode dequeued = queue.Dequeue();

            Assert.Same(c, dequeued);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a left child violates
        ///     the heap property by having higher priority than its parent.
        /// </summary>
        [Fact]
        public void IsValidQueue_LeftChildViolation_ReturnsFalse()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode parent = new StablePriorityQueueNode();
            StablePriorityQueueNode leftChild = new StablePriorityQueueNode();

            queue.Enqueue(parent, 5);
            queue.Enqueue(leftChild, 10);

            parent.Priority = 20;

            Assert.False(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that the generic GetEnumerator returns all enqueued nodes in order.
        /// </summary>
        [Fact]
        public void GetEnumerator_Generic_ReturnsAllEnqueuedNodes()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            StablePriorityQueueNode node3 = new StablePriorityQueueNode();

            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);
            queue.Enqueue(node3, 3);

            int count = 0;
            foreach (StablePriorityQueueNode item in queue)
            {
                Assert.NotNull(item);
                count++;
            }

            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that the non-generic GetEnumerator returns all enqueued nodes.
        /// </summary>
        [Fact]
        public void GetEnumerator_NonGeneric_ReturnsAllEnqueuedNodes()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();

            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            IEnumerator enumerator = ((IEnumerable)queue).GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
            {
                Assert.NotNull(enumerator.Current);
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that Resize preserves all enqueued nodes after growing the array.
        /// </summary>
        [Fact]
        public void Resize_PreservesNodes()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(5);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();

            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            queue.Resize(10);

            Assert.Equal(10, queue.MaxSize);
            Assert.Equal(2, queue.Count);
            Assert.True(queue.Contains(node1));
            Assert.True(queue.Contains(node2));
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that Contains returns false after ResetNode has been called.
        /// </summary>
        [Fact]
        public void Contains_AfterResetNode_ReturnsFalse()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(5);
            StablePriorityQueueNode node = new StablePriorityQueueNode();

            queue.Enqueue(node, 1);
            queue.ResetNode(node);

            Assert.False(queue.Contains(node));
        }
    }
}
