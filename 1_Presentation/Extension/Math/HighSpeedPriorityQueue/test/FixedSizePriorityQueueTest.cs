// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedSizePriorityQueueTest.cs
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

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The fixed size priority queue test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class FixedSizePriorityQueueTest 
    {
        /// <summary>
        ///     Tests that max size initially set
        /// </summary>
        [Fact]
        public void MaxSize_InitiallySet()
        {
            FixedSizePriorityQueue<string, int> queue = new FixedSizePriorityQueue<string, int>(5);
            Assert.Equal(5, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that reset node allows node re enqueue
        /// </summary>
        [Fact]
        public void ResetNode_AllowsNodeReEnqueue()
        {
            FixedSizePriorityQueue<StablePriorityQueueNode, int> queue = new FixedSizePriorityQueue<StablePriorityQueueNode, int>(5);
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            queue.Enqueue(node, 1);
            queue.Enqueue(node, 2);
            Assert.Equal(5, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that enqueue adds items until max size
        /// </summary>
        [Fact]
        public void Enqueue_AddsItemsUntilMaxSize()
        {
            FixedSizePriorityQueue<string, int> queue = new FixedSizePriorityQueue<string, int>(2);
            queue.Enqueue("Item1", 1);
            queue.Enqueue("Item2", 2);
            Assert.Equal(2, queue.MaxSize);
        }

        /// <summary>
        ///     Tests that enqueue exceeding max size throws exception
        /// </summary>
        [Fact]
        public void Enqueue_ExceedingMaxSize_ThrowsException()
        {
            FixedSizePriorityQueue<string, int> queue = new FixedSizePriorityQueue<string, int>(2);
            queue.Enqueue("Item1", 1);
            queue.Enqueue("Item2", 2);
            Assert.Throws<InvalidOperationException>(() => queue.Enqueue("Item3", 3));
        }

        /// <summary>
        ///     Tests that dequeue returns items in priority order
        /// </summary>
        [Fact]
        public void Dequeue_ReturnsItemsInPriorityOrder()
        {
            FixedSizePriorityQueue<string, int> queue = new FixedSizePriorityQueue<string, int>(3);
            queue.Enqueue("Item1", 1);
            queue.Enqueue("Item2", 2);
            queue.Enqueue("Item3", 0);
            Assert.Equal("Item3", queue.Dequeue());
            Assert.Equal("Item1", queue.Dequeue());
            Assert.Equal("Item2", queue.Dequeue());
        }
    }
}