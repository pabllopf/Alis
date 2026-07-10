// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueRemainingCoverageTests.cs
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
    public class GenericPriorityQueueRemainingCoverageTests
    {
        [Fact]
        public void CascadeUp_WhileLoop_BreaksWhenParentHasHigherPriority()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode[] nodes = new TestNode[8];
            for (int i = 0; i < 8; i++)
            {
                nodes[i] = new TestNode();
                queue.Enqueue(nodes[i], (i + 1) * 10);
            }

            queue.UpdatePriority(nodes[7], 15);

            Assert.Same(nodes[0], queue.First);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void IsValidQueue_RightChildViolation_ReturnsFalse()
        {
            GenericPriorityQueue<TestNode, int> queue = new GenericPriorityQueue<TestNode, int>(10);
            TestNode parent = new TestNode();
            TestNode leftChild = new TestNode();
            TestNode rightChild = new TestNode();

            queue.Enqueue(parent, 10);
            queue.Enqueue(leftChild, 30);
            queue.Enqueue(rightChild, 20);

            parent.Priority = 25;

            Assert.False(queue.IsValidQueue());
        }
    }
}
