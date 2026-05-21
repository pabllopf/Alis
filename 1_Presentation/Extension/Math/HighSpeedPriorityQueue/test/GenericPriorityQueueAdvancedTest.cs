// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueAdvancedTest.cs
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
    /// The generic priority queue advanced test class
    /// </summary>
    public class GenericPriorityQueueAdvancedTest
    {
        /// <summary>
        /// Tests that constructor with custom comparer changes ordering
        /// </summary>
        [Fact]
        public void Constructor_WithCustomComparer_ChangesOrdering()
        {
            GenericPriorityQueue<TimestampNode, int> queue =
                new GenericPriorityQueue<TimestampNode, int>(10, Comparer<int>.Create((left, right) => right.CompareTo(left)));

            TimestampNode low = new TimestampNode("low");
            TimestampNode high = new TimestampNode("high");

            queue.Enqueue(low, 1);
            queue.Enqueue(high, 10);

            Assert.Same(high, queue.First);
        }

        /// <summary>
        /// Tests that equal priorities are stable by insertion order
        /// </summary>
        [Fact]
        public void EqualPriorities_AreStableByInsertionOrder()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(10);
            TimestampNode first = new TimestampNode("first");
            TimestampNode second = new TimestampNode("second");

            queue.Enqueue(first, 7);
            queue.Enqueue(second, 7);

            Assert.Same(first, queue.Dequeue());
            Assert.Same(second, queue.Dequeue());
        }

        /// <summary>
        /// Tests that remove non last and last node keep queue consistent
        /// </summary>
        [Fact]
        public void Remove_NonLastAndLastNode_KeepQueueConsistent()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(8);
            TimestampNode a = new TimestampNode("a");
            TimestampNode b = new TimestampNode("b");
            TimestampNode c = new TimestampNode("c");

            queue.Enqueue(a, 3);
            queue.Enqueue(b, 1);
            queue.Enqueue(c, 2);

            queue.Remove(a);
            queue.Remove(c);

            Assert.Equal(1, queue.Count);
            Assert.Same(b, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that reset node sets queue index to zero
        /// </summary>
        [Fact]
        public void ResetNode_SetsQueueIndexToZero()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(3);
            TimestampNode node = new TimestampNode("node");

            queue.Enqueue(node, 1);
            queue.ResetNode(node);

            Assert.Equal(0, node.QueueIndex);
        }

        /// <summary>
        /// The timestamp node class
        /// </summary>
        /// <seealso cref="GenericPriorityQueueNode{int}"/>
        private sealed class TimestampNode : GenericPriorityQueueNode<int>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TimestampNode"/> class
            /// </summary>
            /// <param name="id">The id</param>
            public TimestampNode(string id) => Id = id;

            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id { get; }
        }
    }
}


