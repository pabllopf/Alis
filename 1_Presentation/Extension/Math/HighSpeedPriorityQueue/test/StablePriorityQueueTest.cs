// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueTest.cs
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
    ///     The stable priority queue test class
    /// </summary>
    public class StablePriorityQueueTest
    {
        /// <summary>
        ///     Tests that queue initializes with zero nodes
        /// </summary>
        [Fact]
        public void Queue_InitializesWithZeroNodes()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that enqueue increases count
        /// </summary>
        [Fact]
        public void Enqueue_IncreasesCount()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that dequeue decreases count
        /// </summary>
        [Fact]
        public void Dequeue_DecreasesCount()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            StablePriorityQueueNode dequeuedNode = queue.Dequeue();
            Assert.Equal(0, queue.Count);
            Assert.Equal(node, dequeuedNode);
        }

        /// <summary>
        ///     Tests that first returns correct node
        /// </summary>
        [Fact]
        public void First_ReturnsCorrectNode()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);
            Assert.Equal(node1, queue.First);
        }

        /// <summary>
        ///     Tests that clear resets queue
        /// </summary>
        [Fact]
        public void Clear_ResetsQueue()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
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
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            Assert.True(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that contains returns false for not enqueued node
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForNotEnqueuedNode()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that update priority changes node priority
        /// </summary>
        [Fact]
        public void UpdatePriority_ChangesNodePriority()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            queue.UpdatePriority(node, 2);
            Assert.Equal(2, node.Priority);
        }

        /// <summary>
        ///     Tests that remove removes node from queue
        /// </summary>
        [Fact]
        public void Remove_RemovesNodeFromQueue()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            queue.Remove(node);
            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that resize increases max size
        /// </summary>
        [Fact]
        public void Resize_IncreasesMaxSize()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            queue.Resize(20);
            Assert.Equal(20, queue.MaxSize);
        }
    }
}