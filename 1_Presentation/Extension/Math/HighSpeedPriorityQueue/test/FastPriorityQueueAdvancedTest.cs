// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastPriorityQueueAdvancedTest.cs
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

using System.Linq;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    /// The fast priority queue advanced test class
    /// </summary>
    public class FastPriorityQueueAdvancedTest
    {
        /// <summary>
        /// Tests that dequeue with single node clears queue
        /// </summary>
        [Fact]
        public void Dequeue_WithSingleNode_ClearsQueue()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(4);
            FastPriorityQueueNode node = new FastPriorityQueueNode();

            queue.Enqueue(node, 3f);
            FastPriorityQueueNode result = queue.Dequeue();

            Assert.Same(node, result);
            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that update priority cascades node up and down
        /// </summary>
        [Fact]
        public void UpdatePriority_CascadesNodeUpAndDown()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(6);
            FastPriorityQueueNode first = new FastPriorityQueueNode();
            FastPriorityQueueNode second = new FastPriorityQueueNode();
            FastPriorityQueueNode third = new FastPriorityQueueNode();

            queue.Enqueue(first, 10f);
            queue.Enqueue(second, 20f);
            queue.Enqueue(third, 30f);

            queue.UpdatePriority(third, 1f);
            Assert.Same(third, queue.First);

            queue.UpdatePriority(third, 40f);
            Assert.NotSame(third, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that remove last element and non last element keeps queue valid
        /// </summary>
        [Fact]
        public void Remove_LastElementAndNonLastElement_KeepsQueueValid()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(6);
            FastPriorityQueueNode a = new FastPriorityQueueNode();
            FastPriorityQueueNode b = new FastPriorityQueueNode();
            FastPriorityQueueNode c = new FastPriorityQueueNode();

            queue.Enqueue(a, 1f);
            queue.Enqueue(b, 2f);
            queue.Enqueue(c, 3f);

            queue.Remove(c);
            queue.Remove(a);

            Assert.Equal(1, queue.Count);
            Assert.Same(b, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that reset node allows clearing queue index
        /// </summary>
        [Fact]
        public void ResetNode_AllowsClearingQueueIndex()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(3);
            FastPriorityQueueNode node = new FastPriorityQueueNode();
            queue.Enqueue(node, 1f);

            queue.ResetNode(node);

            Assert.Equal(0, node.QueueIndex);
        }

        /// <summary>
        /// Tests that enumerator returns all nodes currently in queue
        /// </summary>
        [Fact]
        public void Enumerator_ReturnsAllNodesCurrentlyInQueue()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode a = new FastPriorityQueueNode();
            FastPriorityQueueNode b = new FastPriorityQueueNode();

            queue.Enqueue(a, 2f);
            queue.Enqueue(b, 1f);

            FastPriorityQueueNode[] nodes = queue.ToArray();

            Assert.Equal(2, nodes.Length);
            Assert.Contains(a, nodes);
            Assert.Contains(b, nodes);
        }
    }
}

