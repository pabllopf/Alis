// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastPriorityQueueRemainingCoverageTests.cs
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
    /// The fast priority queue remaining coverage test class
    /// </summary>
    public class FastPriorityQueueRemainingCoverageTests
    {
        /// <summary>
        ///     Node subclass that exposes the protected internal Priority setter.
        /// </summary>
        private class MutableNode : FastPriorityQueueNode
        {
            /// <summary>
            /// Sets the priority using the specified priority
            /// </summary>
            /// <param name="priority">The priority</param>
            public void SetPriority(float priority) => Priority = priority;
        }

        /// <summary>
        ///     Tests that CascadeUp while loop break is hit when a node bubbles up
        ///     and finds a grandparent with higher or equal priority.
        ///     Covers the break branch inside the CascadeUp while loop (lines 254-256).
        /// </summary>
        [Fact]
        public void UpdatePriority_CascadeUp_PartialBubbleUp_WhileLoopBreak()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode nodeA = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeB = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeC = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeD = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeE = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeF = new FastPriorityQueueNode();
            FastPriorityQueueNode nodeG = new FastPriorityQueueNode();

            queue.Enqueue(nodeA, 1f);
            queue.Enqueue(nodeB, 4f);
            queue.Enqueue(nodeC, 2f);
            queue.Enqueue(nodeD, 8f);
            queue.Enqueue(nodeE, 9f);
            queue.Enqueue(nodeF, 10f);
            queue.Enqueue(nodeG, 11f);

            // nodeD is at depth 3 (index 4), parent is nodeB (index 2), grandparent is nodeA (index 1)
            // Update nodeD's priority to 3 so it has higher priority than nodeB but lower than nodeA
            // This causes CascadeUp to bubble past nodeB (index 4→2) but then stop at nodeA (while loop break)
            queue.UpdatePriority(nodeD, 3f);

            Assert.Equal(7, queue.Count);
            Assert.Same(nodeA, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a left child has higher priority than its parent.
        ///     Covers the left child validation branch in IsValidQueue (lines 388-390).
        /// </summary>
        [Fact]
        public void IsValidQueue_LeftChildViolation_ReturnsFalse()
        {
            FastPriorityQueue<MutableNode> queue = new FastPriorityQueue<MutableNode>(10);
            MutableNode node1 = new MutableNode();
            MutableNode node2 = new MutableNode();

            queue.Enqueue(node1, 2f);
            queue.Enqueue(node2, 3f);

            // node1 is root (priority 2), node2 is left child (priority 3)
            // Corrupt: set node2's priority higher than node1 WITHOUT re-heapifying
            node2.SetPriority(1f);

            Assert.False(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a right child has higher priority than its parent
        ///     but the left child does NOT.
        ///     Covers the right child validation branch in IsValidQueue (lines 394-396).
        /// </summary>
        [Fact]
        public void IsValidQueue_RightChildViolation_ReturnsFalse()
        {
            FastPriorityQueue<MutableNode> queue = new FastPriorityQueue<MutableNode>(10);
            MutableNode node1 = new MutableNode();
            MutableNode node2 = new MutableNode();
            MutableNode node3 = new MutableNode();

            queue.Enqueue(node1, 2f);
            queue.Enqueue(node2, 4f);
            queue.Enqueue(node3, 3f);

            // node1@1(2f) root, node2@2(4f) left child, node3@3(3f) right child
            // Corrupt: make node3 (right child) have higher priority than node1
            // Left child's priority (4) is kept valid (higher value = lower priority)
            node3.SetPriority(1f);

            Assert.False(queue.IsValidQueue());
        }
    }
}
