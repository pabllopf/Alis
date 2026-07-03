// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueTest.cs
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
    ///     The generic priority queue test class
    /// </summary>
    public class GenericPriorityQueueTest
    {
        /// <summary>
        ///     Tests that queue initializes with correct max size
        /// </summary>
        [Fact]
        public void Queue_InitializesWithCorrectMaxSize()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            Assert.Equal(10, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that enqueue increases count
        /// </summary>
        [Fact]
        public void Enqueue_IncreasesCount()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that dequeue decreases count
        /// </summary>
        [Fact]
        public void Dequeue_DecreasesCount()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);
            queue.Dequeue();
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that first returns correct node
        /// </summary>
        [Fact]
        public void First_ReturnsCorrectNode()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node1 = new TestNode();
            TestNode node2 = new TestNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);
            Assert.Same(node1, queue.First);
        }

        /// <summary>
        ///     Tests that clear resets queue
        /// </summary>
        [Fact]
        public void Clear_ResetsQueue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
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
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);
            Assert.True(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that contains returns false for not enqueued node
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForNotEnqueuedNode()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            Assert.False(queue.Contains(node));
        }

        /// <summary>
        ///     Tests that update priority changes node priority
        /// </summary>
        [Fact]
        public void UpdatePriority_ChangesNodePriority()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
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
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
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
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            queue.Resize(20);
            Assert.Equal(20, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that is valid queue after operations returns true
        /// </summary>
        [Fact]
        public void IsValidQueue_AfterOperations_ReturnsTrue()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node1 = new TestNode();
            TestNode node2 = new TestNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);
            queue.Remove(node1);
            queue.UpdatePriority(node2, 3);
            queue.Dequeue();
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that dequeue with many nodes triggers CascadeDown with right-child swaps
        ///     and multi-level sinking, covering the full CascadeDown while loop.
        /// </summary>
        [Fact]
        public void Dequeue_WithManyNodes_TriggersCascadeDownWithRightChild()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(20);
            var nodes = new TestNode[5];
            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new TestNode();
                queue.Enqueue(nodes[i], i + 1);
            }

            // Dequeue all nodes — each dequeue (after the first) triggers CascadeDown
            // which must compare both left and right children and potentially swap with the right child.
            for (int i = 0; i < 5; i++)
            {
                TestNode removed = queue.Dequeue();
                Assert.NotNull(removed);
            }

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that enqueue with decreasing priorities triggers multi-level CascadeUp.
        ///     When a node with very high priority is enqueued, it bubbles up through
        ///     multiple levels of the heap.
        /// </summary>
        [Fact]
        public void Enqueue_WithDecreasingPriority_TriggersMultiLevelCascadeUp()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(20);

            // Enqueue nodes with low priority first
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            queue.Enqueue(n1, 10);
            queue.Enqueue(n2, 20);
            queue.Enqueue(n3, 30);

            // Now enqueue a node with very high priority (low number) — should bubble to root
            TestNode highPriority = new TestNode();
            queue.Enqueue(highPriority, 1);

            // The highest priority node should be at the root
            Assert.Same(highPriority, queue.First);
        }

        /// <summary>
        ///     Tests that reset node sets queue index to zero, allowing re-enqueue.
        /// </summary>
        [Fact]
        public void ResetNode_SetsQueueIndexToZero()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);
            Assert.NotEqual(0, node.QueueIndex);

            queue.ResetNode(node);
            Assert.Equal(0, node.QueueIndex);
        }

        /// <summary>
        ///     Tests that enumerator iterates through all nodes in heap order.
        /// </summary>
        [Fact]
        public void Enumerator_IteratesAllNodes()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            var node1 = new TestNode();
            var node2 = new TestNode();
            var node3 = new TestNode();
            queue.Enqueue(node1, 3);
            queue.Enqueue(node3, 1);
            queue.Enqueue(node2, 2);

            var collected = new System.Collections.Generic.List<TestNode>();
            foreach (TestNode node in queue)
            {
                collected.Add(node);
            }

            Assert.Equal(3, collected.Count);
            // First element should be the highest priority (lowest number)
            Assert.Same(node3, collected[0]);
        }

        /// <summary>
        ///     Tests that update priority on root node does not trigger CascadeUp
        ///     (parentIndex == 0, the if-guard prevents unnecessary work).
        /// </summary>
        [Fact]
        public void UpdatePriority_OnRootNode_SkipsCascadeUp()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node = new TestNode();
            queue.Enqueue(node, 1);

            // Update root's priority to a lower value — should not break the heap
            queue.UpdatePriority(node, 100);
            Assert.Same(node, queue.First);
        }

        /// <summary>
        ///     Tests that remove the last node (QueueIndex == _numNodes) takes the O(1) path.
        /// </summary>
        [Fact]
        public void Remove_LastNode_TakesO1Path()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode node1 = new TestNode();
            TestNode node2 = new TestNode();
            queue.Enqueue(node1, 1);
            queue.Enqueue(node2, 2);

            // node2 should be at QueueIndex == _numNodes (the last position)
            queue.Remove(node2);
            Assert.Equal(1, queue.Count);
            Assert.Same(node1, queue.First);
        }

        /// <summary>
        ///     Tests that has higher priority with equal priorities uses insertion order.
        /// </summary>
        [Fact]
        public void Enqueue_SamePriority_RespectsInsertionOrder()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode first = new TestNode();
            TestNode second = new TestNode();
            queue.Enqueue(first, 5);
            queue.Enqueue(second, 5); // Same priority

            // First enqueued should come out first (FIFO for equal priorities)
            Assert.Same(first, queue.First);
        }
    }
}