// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastPriorityQueueNodeTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The fast priority queue node test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class FastPriorityQueueNodeTest 
    {
        /// <summary>
        ///     Tests that constructor initializes with correct max nodes
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCorrectMaxNodes()
        {
            int maxNodes = 10;
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(maxNodes);

            Assert.Equal(0, queue.Count);
            Assert.Equal(maxNodes, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that enqueue increases count and sets correct priority
        /// </summary>
        [Fact]
        public void Enqueue_IncreasesCountAndSetsCorrectPriority()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();

            queue.Enqueue(node, 1);

            Assert.Equal(1, queue.Count);
            Assert.Equal(1, node.Priority);
        }

        /// <summary>
        ///     Tests that dequeue returns correct node and decreases count
        /// </summary>
        [Fact]
        public void Dequeue_ReturnsCorrectNodeAndDecreasesCount()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1);

            FastPriorityQueueNode dequeuedNode = queue.Dequeue();

            Assert.Equal(node, dequeuedNode);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that clear resets the queue
        /// </summary>
        [Fact]
        public void Clear_ResetsTheQueue()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1);

            queue.Clear();

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that contains returns true for enqueued node
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueForEnqueuedNode()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1);

            Assert.True(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that contains returns false for not enqueued node
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForNotEnqueuedNode()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();

            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that update priority changes node priority and maintains queue order
        /// </summary>
        [Fact]
        public void UpdatePriority_ChangesNodePriorityAndMaintainsQueueOrder()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            queue.UpdatePriority(node1, 3);

            Assert.Equal(node2, queue.Dequeue());
            Assert.Equal(node1, queue.Dequeue());
            Assert.Equal(3, node1.Priority);
        }

        /// <summary>
        ///     Tests that remove removes node from queue and decreases count
        /// </summary>
        [Fact]
        public void Remove_RemovesNodeFromQueueAndDecreasesCount()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1);

            queue.Remove(node);

            Assert.Equal(0, queue.Count);
            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that first returns the node with highest priority
        /// </summary>
        [Fact]
        public void First_ReturnsTheNodeWithHighestPriority()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 0.5f);

            Assert.Equal(node2, queue.First);
        }

        /// <summary>
        ///     Tests that resize increases max size and preserves nodes
        /// </summary>
        [Fact]
        public void Resize_IncreasesMaxSizeAndPreservesNodes()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(2);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            queue.Resize(4);

            Assert.Equal(2, queue.Count);
            Assert.Equal(4, queue.MaxSize);
            Assert.True(queue.Contains(node1));
            Assert.True(queue.Contains(node2));
        }
    }
}