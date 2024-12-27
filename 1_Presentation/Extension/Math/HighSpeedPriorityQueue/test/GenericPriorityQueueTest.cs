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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The generic priority queue test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
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
    }
}