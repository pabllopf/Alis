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

using System.Collections.Generic;
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

        /// <summary>
        ///     Tests that dequeue with many nodes triggers CascadeDown with right-child swaps.
        /// </summary>
        [Fact]
        public void Dequeue_WithManyNodes_TriggersCascadeDownWithRightChild()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(20);
            StablePriorityQueueNode[] nodes = new StablePriorityQueueNode[5];
            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new StablePriorityQueueNode();
                queue.Enqueue(nodes[i], i + 1);
            }

            for (int i = 0; i < 5; i++)
            {
                StablePriorityQueueNode removed = queue.Dequeue();
                Assert.NotNull(removed);
            }

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that enqueue with decreasing priorities triggers multi-level CascadeUp.
        /// </summary>
        [Fact]
        public void Enqueue_WithDecreasingPriority_TriggersMultiLevelCascadeUp()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(20);
            StablePriorityQueueNode n1 = new StablePriorityQueueNode();
            StablePriorityQueueNode n2 = new StablePriorityQueueNode();
            StablePriorityQueueNode n3 = new StablePriorityQueueNode();
            queue.Enqueue(n1, 10);
            queue.Enqueue(n2, 20);
            queue.Enqueue(n3, 30);

            StablePriorityQueueNode highPriority = new StablePriorityQueueNode();
            queue.Enqueue(highPriority, 1);

            Assert.Same(highPriority, queue.First);
        }

        /// <summary>
        ///     Tests that reset node sets queue index to zero.
        /// </summary>
        [Fact]
        public void ResetNode_SetsQueueIndexToZero()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            Assert.NotEqual(0, node.QueueIndex);

            queue.ResetNode(node);
            Assert.Equal(0, node.QueueIndex);
        }

        /// <summary>
        ///     Tests that enumerator iterates through all nodes.
        /// </summary>
        [Fact]
        public void Enumerator_IteratesAllNodes()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            StablePriorityQueueNode node3 = new StablePriorityQueueNode();
            queue.Enqueue(node1, 3);
            queue.Enqueue(node3, 1);
            queue.Enqueue(node2, 2);

            List<StablePriorityQueueNode> collected = new System.Collections.Generic.List<StablePriorityQueueNode>();
            foreach (StablePriorityQueueNode node in queue)
            {
                collected.Add(node);
            }

            Assert.Equal(3, collected.Count);
            Assert.Same(node3, collected[0]);
        }

        /// <summary>
        ///     Tests that update priority on root node does not trigger CascadeUp.
        /// </summary>
        [Fact]
        public void UpdatePriority_OnRootNode_SkipsCascadeUp()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            queue.UpdatePriority(node, 100);
            Assert.Same(node, queue.First);
        }

        /// <summary>
        ///     Tests that remove the last node takes the O(1) path.
        /// </summary>
        [Fact]
        public void Remove_LastNode_TakesO1Path()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode node1 = new StablePriorityQueueNode();
            StablePriorityQueueNode node2 = new StablePriorityQueueNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            queue.Remove(node2);
            Assert.Equal(1, queue.Count);
            Assert.Same(node1, queue.First);
        }

        /// <summary>
        ///     Tests that same-priority nodes are dequeued in FIFO order (stability).
        /// </summary>
        [Fact]
        public void Enqueue_SamePriority_RespectsInsertionOrder()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode first = new StablePriorityQueueNode();
            StablePriorityQueueNode second = new StablePriorityQueueNode();
            queue.Enqueue(first, 5);
            queue.Enqueue(second, 5);

            Assert.Same(first, queue.First);
        }
    }
}