// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueAdvancedTest.cs
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
    /// The stable priority queue advanced test class
    /// </summary>
    public class StablePriorityQueueAdvancedTest
    {
        /// <summary>
        /// Tests that equal priorities dequeue in insertion order
        /// </summary>
        [Fact]
        public void EqualPriorities_DequeueInInsertionOrder()
        {
            StablePriorityQueue<JobNode> queue = new StablePriorityQueue<JobNode>(10);
            JobNode first = new JobNode("first");
            JobNode second = new JobNode("second");
            JobNode third = new JobNode("third");

            queue.Enqueue(first, 5f);
            queue.Enqueue(second, 5f);
            queue.Enqueue(third, 5f);

            Assert.Same(first, queue.Dequeue());
            Assert.Same(second, queue.Dequeue());
            Assert.Same(third, queue.Dequeue());
        }

        /// <summary>
        /// Tests that very close priorities use insertion index as tie breaker
        /// </summary>
        [Fact]
        public void VeryClosePriorities_UseInsertionIndexAsTieBreaker()
        {
            StablePriorityQueue<JobNode> queue = new StablePriorityQueue<JobNode>(5);
            JobNode earlier = new JobNode("earlier");
            JobNode later = new JobNode("later");

            queue.Enqueue(earlier, 1.000f);
            queue.Enqueue(later, 1.005f);

            Assert.Same(earlier, queue.Dequeue());
        }

        /// <summary>
        /// Tests that remove and update priority keep queue valid
        /// </summary>
        [Fact]
        public void RemoveAndUpdatePriority_KeepQueueValid()
        {
            StablePriorityQueue<JobNode> queue = new StablePriorityQueue<JobNode>(8);
            JobNode a = new JobNode("a");
            JobNode b = new JobNode("b");
            JobNode c = new JobNode("c");

            queue.Enqueue(a, 3f);
            queue.Enqueue(b, 4f);
            queue.Enqueue(c, 1f);

            queue.Remove(b);
            queue.UpdatePriority(a, 0f);

            Assert.Same(a, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that reset node resets queue index
        /// </summary>
        [Fact]
        public void ResetNode_ResetsQueueIndex()
        {
            StablePriorityQueue<JobNode> queue = new StablePriorityQueue<JobNode>(3);
            JobNode node = new JobNode("n");
            queue.Enqueue(node, 1f);

            queue.ResetNode(node);

            Assert.Equal(0, node.QueueIndex);
        }

        /// <summary>
        /// The job node class
        /// </summary>
        /// <seealso cref="StablePriorityQueueNode"/>
        private sealed class JobNode : StablePriorityQueueNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="JobNode"/> class
            /// </summary>
            /// <param name="id">The id</param>
            public JobNode(string id) => Id = id;

            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id { get; }
        }
    }
}

