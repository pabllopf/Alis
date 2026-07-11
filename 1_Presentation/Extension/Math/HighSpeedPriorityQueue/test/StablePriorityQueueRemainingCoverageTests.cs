// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for <see cref="StablePriorityQueue{T}" />.
    ///     Targets uncovered lines and branches in CascadeUp while-loop break
    ///     and IsValidQueue right-child violation.
    /// </summary>
    public class StablePriorityQueueRemainingCoverageTests
    {
        /// <summary>
        ///     Node subclass that exposes the protected internal Priority setter
        ///     so tests can corrupt the heap for validation checks.
        /// </summary>
        private class MutableStableNode : StablePriorityQueueNode
        {
            /// <summary>
            /// Sets the priority using the specified priority
            /// </summary>
            /// <param name="priority">The priority</param>
            public void SetPriority(float priority) => Priority = priority;
        }

        /// <summary>
        ///     Tests that CascadeUp's while-loop break (lines 294-296) is hit when
        ///     a node bubbles up past its immediate parent but stops at a grandparent
        ///     with higher priority.
        ///     After UpdatePriority makes nodeD(8→3), it bubbles up past nodeB(4)
        ///     but stops at nodeA(1) in the while loop via the break path.
        /// </summary>
        [Fact]
        public void UpdatePriority_CascadeUp_PartialBubbleUp_WhileLoopBreak()
        {
            StablePriorityQueue<StablePriorityQueueNode> queue = new StablePriorityQueue<StablePriorityQueueNode>(10);
            StablePriorityQueueNode nodeA = new StablePriorityQueueNode();
            StablePriorityQueueNode nodeB = new StablePriorityQueueNode();
            StablePriorityQueueNode nodeC = new StablePriorityQueueNode();
            StablePriorityQueueNode nodeD = new StablePriorityQueueNode();
            StablePriorityQueueNode nodeE = new StablePriorityQueueNode();

            // Build heap: [A(1), B(4), C(2), D(8), E(9)]
            queue.Enqueue(nodeA, 1f);
            queue.Enqueue(nodeB, 4f);
            queue.Enqueue(nodeC, 2f);
            queue.Enqueue(nodeD, 8f);
            queue.Enqueue(nodeE, 9f);

            // Update D's priority from 8 to 3: it will bubble up past B(4)
            // but stop at A(1), hitting the while-loop break.
            queue.UpdatePriority(nodeD, 3f);

            Assert.Equal(5, queue.Count);
            Assert.Same(nodeA, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns false when a right child has higher
        ///     priority than its parent but the left child does NOT.
        ///     Covers the right-child violation branch in IsValidQueue (lines 434-436).
        /// </summary>
        [Fact]
        public void IsValidQueue_RightChildViolation_ReturnsFalse()
        {
            StablePriorityQueue<MutableStableNode> queue = new StablePriorityQueue<MutableStableNode>(10);
            MutableStableNode node1 = new MutableStableNode();
            MutableStableNode node2 = new MutableStableNode();
            MutableStableNode node3 = new MutableStableNode();

            queue.Enqueue(node1, 2f);
            queue.Enqueue(node2, 4f);
            queue.Enqueue(node3, 3f);

            // Corrupt: make node3 (right child) have higher priority than node1 (root).
            // Left child node2 (priority 4) is still valid (lower priority than root).
            node3.SetPriority(1f);

            Assert.False(queue.IsValidQueue());
        }
    }
}
