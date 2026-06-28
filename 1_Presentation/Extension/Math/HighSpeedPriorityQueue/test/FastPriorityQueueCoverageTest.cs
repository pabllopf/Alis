// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastPriorityQueueCoverageTest.cs
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
    public class FastPriorityQueueCoverageTest
    {
        [Fact]
        public void Clear_WithMultipleNodes_RemovesAll()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            queue.Enqueue(new FastPriorityQueueNode(), 3f);
            queue.Enqueue(new FastPriorityQueueNode(), 1f);
            queue.Enqueue(new FastPriorityQueueNode(), 2f);
            Assert.Equal(3, queue.Count);

            queue.Clear();

            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void Resize_ToLargerCapacity_PreservesElements()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(5);
            FastPriorityQueueNode node1 = new FastPriorityQueueNode();
            FastPriorityQueueNode node2 = new FastPriorityQueueNode();
            queue.Enqueue(node1, 2f);
            queue.Enqueue(node2, 1f);
            Assert.Equal(2, queue.Count);
            Assert.Same(node2, queue.First);

            queue.Resize(20);

            Assert.Equal(2, queue.Count);
            Assert.Same(node2, queue.First);
            Assert.Same(node2, queue.Dequeue());
            Assert.Same(node1, queue.Dequeue());
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void Dequeue_MultipleLevels_CascadesDownCorrectly()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode[] nodes = new FastPriorityQueueNode[7];
            for (int i = 0; i < 7; i++)
            {
                nodes[i] = new FastPriorityQueueNode();
                queue.Enqueue(nodes[i], i + 1);
            }

            FastPriorityQueueNode first = queue.Dequeue();
            Assert.Same(nodes[0], first);
            Assert.Equal(6, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void GetSwapIndex_OnlyRightChildHigher_SwapsWithRight()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode[] nodes = new FastPriorityQueueNode[4];
            for (int i = 0; i < 4; i++)
            {
                nodes[i] = new FastPriorityQueueNode();
            }

            queue.Enqueue(nodes[0], 1f);
            queue.Enqueue(nodes[1], 10f);
            queue.Enqueue(nodes[2], 3f);
            queue.Enqueue(nodes[3], 10f);

            FastPriorityQueueNode first = queue.Dequeue();
            Assert.Same(nodes[0], first);
            Assert.Equal(3, queue.Count);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void GetSwapIndex_BothChildrenHigherLeftWins_SwapsWithLeft()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode[] nodes = new FastPriorityQueueNode[7];
            for (int i = 0; i < 7; i++)
            {
                nodes[i] = new FastPriorityQueueNode();
                queue.Enqueue(nodes[i], i + 1);
            }

            FastPriorityQueueNode first = queue.Dequeue();
            Assert.Same(nodes[0], first);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void GetSwapIndex_BothChildrenHigherRightWins_SwapsWithRight()
        {
            FastPriorityQueue<FastPriorityQueueNode> queue = new FastPriorityQueue<FastPriorityQueueNode>(10);
            FastPriorityQueueNode[] nodes = new FastPriorityQueueNode[5];
            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new FastPriorityQueueNode();
            }

            queue.Enqueue(nodes[0], 1f);
            queue.Enqueue(nodes[1], 100f);
            queue.Enqueue(nodes[2], 2f);
            queue.Enqueue(nodes[3], 101f);
            queue.Enqueue(nodes[4], 102f);

            FastPriorityQueueNode first = queue.Dequeue();
            Assert.Same(nodes[0], first);
            Assert.Equal(4, queue.Count);
            Assert.True(queue.IsValidQueue());
        }
    }
}
