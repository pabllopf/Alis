// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:FastPriorityQueueEdgeTests.cs
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
    ///     The fast priority queue edge tests class
    /// </summary>
    public class FastPriorityQueueEdgeTests
    {
        /// <summary>
        ///     Tests that cascade up while loop bubbles node past multiple levels
        /// </summary>
        [Fact]
        public void CascadeUp_WhileLoop_BubblesNodePastMultipleLevels()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode[] nodes = new FastPriorityQueueNode[8];
            for (int i = 0; i < 8; i++)
            {
                nodes[i] = new FastPriorityQueueNode();
                queue.Enqueue(nodes[i], 8 - i);
            }

            Assert.Equal(8, queue.Count);
            Assert.Same(nodes[7], queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that dequeue with no swap needed handles already-correct node position
        /// </summary>
        [Fact]
        public void Dequeue_NoSwapNeeded_LeavesNodeInPlace()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            FastPriorityQueueNode node3 = new FastPriorityQueueNode();

            queue.Enqueue(node1, 1f);
            queue.Enqueue(node2, 3f);
            queue.Enqueue(node3, 2f);

            FastPriorityQueueNode dequeued = queue.Dequeue();

            Assert.Same(node1, dequeued);
            Assert.Equal(2, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that get enumerator non generic enumerates all nodes
        /// </summary>
        [Fact]
        public void GetEnumerator_NonGeneric_EnumeratesAllNodes()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 1f);
            queue.Enqueue(node2, 2f);

            IEnumerable enumerable = queue;
            int count = 0;
            foreach (object _ in enumerable)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that update priority cascades up when priority becomes higher than parent
        /// </summary>
        [Fact]
        public void UpdatePriority_CascadesUp_WhenPriorityHigherThanParent()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(6);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            FastPriorityQueueNode node3 = new FastPriorityQueueNode();

            queue.Enqueue(node1, 3f);
            queue.Enqueue(node2, 5f);
            queue.Enqueue(node3, 4f);

            queue.UpdatePriority(node3, 1f);

            Assert.Same(node3, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that remove non-last node maintains queue integrity
        /// </summary>
        [Fact]
        public void Remove_NonLastNode_MaintainsQueueIntegrity()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(6);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            FastPriorityQueueNode node3 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 1f);
            queue.Enqueue(node2, 3f);
            queue.Enqueue(node3, 2f);

            queue.Remove(node2);

            Assert.Equal(2, queue.Count);
            Assert.Same(node1, queue.Dequeue());
            Assert.Same(node3, queue.Dequeue());
        }

        /// <summary>
        ///     Tests that contains returns false after reset
        /// </summary>
        [Fact]
        public void Contains_AfterReset_ReturnsFalse()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1f);
            queue.ResetNode(node);

            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that is valid queue returns true for empty queue
        /// </summary>
        [Fact]
        public void IsValidQueue_EmptyQueue_ReturnsTrue()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);

            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that is valid queue returns true for single element
        /// </summary>
        [Fact]
        public void IsValidQueue_SingleElement_ReturnsTrue()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            queue.Enqueue(new FastPriorityQueueNode(), 1f);

            Assert.True(queue.IsValidQueue());
        }
    }
}
