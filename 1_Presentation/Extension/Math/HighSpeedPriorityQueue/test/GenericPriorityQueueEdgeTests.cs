// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueEdgeTests.cs
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
    ///     The generic priority queue edge tests class
    /// </summary>
    public class GenericPriorityQueueEdgeTests
    {
        /// <summary>
        ///     Tests that cascade up while loop bubbles node past multiple levels when priorities are descending
        /// </summary>
        [Fact]
        public void CascadeUp_WhileLoop_BubblesNodePastMultipleLevels()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode[] nodes = new TestNode[8];
            for (int i = 0; i < 8; i++)
            {
                nodes[i] = new TestNode();
                queue.Enqueue(nodes[i], 8 - i);
            }

            Assert.Equal(8, queue.Count);
            Assert.Same(nodes[7], queue.First);
        }

        /// <summary>
        ///     Tests that cascade down while loop pushes node down multiple levels after dequeue
        /// </summary>
        [Fact]
        public void CascadeDown_WhileLoop_PushesNodeDownMultipleLevels()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode[] nodes = new TestNode[8];
            for (int i = 0; i < 8; i++)
            {
                nodes[i] = new TestNode();
                queue.Enqueue(nodes[i], 8 - i);
            }

            TestNode dequeued = queue.Dequeue();

            Assert.Same(nodes[7], dequeued);
            Assert.Equal(7, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that update priority triggers on node updated cascade up when priority becomes higher than parent
        /// </summary>
        [Fact]
        public void UpdatePriority_TriggersOnNodeUpdatedCascadeUp()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode nodeLow = new TestNode();
            TestNode nodeHigh = new TestNode();
            TestNode nodeMid = new TestNode();

            queue.Enqueue(nodeLow, 5);
            queue.Enqueue(nodeHigh, 3);
            queue.Enqueue(nodeMid, 4);

            queue.UpdatePriority(nodeMid, 1);

            Assert.Same(nodeMid, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that non generic get enumerator enumerates all nodes
        /// </summary>
        [Fact]
        public void GetEnumerator_NonGeneric_EnumeratesAllNodes()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node1 = new TestNode();
            TestNode node2 = new TestNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            IEnumerable enumerable = queue;
            int count = 0;
            foreach (object _ in enumerable)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that dequeue single item correctly handles one element in queue
        /// </summary>
        [Fact]
        public void Dequeue_SingleItem_ReturnsNodeAndEmptiesQueue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);

            TestNode result = queue.Dequeue();

            Assert.Same(node, result);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that resize to larger array increases capacity and preserves elements
        /// </summary>
        [Fact]
        public void Resize_ToLargerArray_IncreasesCapacity()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(5);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);

            queue.Resize(20);

            Assert.Equal(20, queue.MaxSize);
            Assert.Equal(1, queue.Count);
            Assert.Same(node, queue.First);
        }

        /// <summary>
        ///     Tests that contains returns false for reset node
        /// </summary>
        [Fact]
        public void Contains_AfterResetNode_ReturnsFalse()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);
            queue.ResetNode(node);

            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that remove last node does not corrupt queue
        /// </summary>
        [Fact]
        public void Remove_LastNode_DoesNotCorruptQueue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node1 = new TestNode();
            TestNode node2 = new TestNode();
            TestNode node3 = new TestNode();
            queue.Enqueue(node1, 3);
            queue.Enqueue(node2, 1);
            queue.Enqueue(node3, 2);

            queue.Remove(node3);

            Assert.Equal(2, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that is valid queue returns true for empty queue
        /// </summary>
        [Fact]
        public void IsValidQueue_EmptyQueue_ReturnsTrue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);

            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that is valid queue returns true for single element
        /// </summary>
        [Fact]
        public void IsValidQueue_SingleElement_ReturnsTrue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            queue.Enqueue(new TestNode(), 1);

            Assert.True(queue.IsValidQueue());
        }
    }
}
