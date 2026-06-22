// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplePriorityQueueTest.cs
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
using System.Collections.Generic;
using Alis.Extension.Math.HighSpeedPriorityQueue;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The simple priority queue test class
    /// </summary>
    public class SimplePriorityQueueTest
    {
        /// <summary>
        ///     Tests that default constructor creates an empty queue
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateEmptyQueue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor with priority comparer works
        /// </summary>
        [Fact]
        public void Constructor_WithPriorityComparer_ShouldCreateQueue()
        {
            IComparer<int> comparer = Comparer<int>.Default;

            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>(comparer);

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor with item equality works
        /// </summary>
        [Fact]
        public void Constructor_WithItemEquality_ShouldCreateQueue()
        {
            IEqualityComparer<string> equalityComparer = EqualityComparer<string>.Default;

            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>(equalityComparer);

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that Enqueue adds an item to the queue
        /// </summary>
        [Fact]
        public void Enqueue_ShouldAddItemToQueue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that Enqueue with higher priority puts item first
        /// </summary>
        [Fact]
        public void Enqueue_HigherPriority_ShouldBeFirst()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("low", 10);
            queue.Enqueue("high", 1);

            Assert.Equal("high", queue.First);
        }

        /// <summary>
        ///     Tests that Dequeue removes and returns the highest priority item
        /// </summary>
        [Fact]
        public void Dequeue_ShouldRemoveAndReturnHighestPriorityItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("low", 10);
            queue.Enqueue("high", 1);
            queue.Enqueue("medium", 5);

            string first = queue.Dequeue();
            Assert.Equal("high", first);
            Assert.Equal(2, queue.Count);
        }

        /// <summary>
        ///     Tests that Dequeue on empty queue throws
        /// </summary>
        [Fact]
        public void Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        /// <summary>
        ///     Tests that First on empty queue throws
        /// </summary>
        [Fact]
        public void First_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => _ = queue.First);
        }

        /// <summary>
        ///     Tests that Contains returns true for item in queue
        /// </summary>
        [Fact]
        public void Contains_WhenItemInQueue_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            Assert.True(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that Contains returns false for item not in queue
        /// </summary>
        [Fact]
        public void Contains_WhenItemNotInQueue_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            Assert.False(queue.Contains("item2"));
        }

        /// <summary>
        ///     Tests that Remove removes an item from the queue
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveItemFromQueue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);
            queue.Enqueue("item2", 2);

            queue.Remove("item1");

            Assert.Equal(1, queue.Count);
            Assert.False(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that Remove on item not in queue throws
        /// </summary>
        [Fact]
        public void Remove_WhenItemNotInQueue_ShouldThrowInvalidOperationException()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.Remove("item1"));
        }

        /// <summary>
        ///     Tests that UpdatePriority changes an item's priority
        /// </summary>
        [Fact]
        public void UpdatePriority_ShouldChangeItemPriority()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 5);
            queue.Enqueue("item2", 1);

            queue.UpdatePriority("item1", 0);

            Assert.Equal("item1", queue.First);
        }

        /// <summary>
        ///     Tests that UpdatePriority on item not in queue throws
        /// </summary>
        [Fact]
        public void UpdatePriority_WhenItemNotInQueue_ShouldThrowInvalidOperationException()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.UpdatePriority("item1", 1));
        }

        /// <summary>
        ///     Tests that Clear removes all items from the queue
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);
            queue.Enqueue("item2", 2);
            queue.Enqueue("item3", 3);

            queue.Clear();

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that GetEnumerator returns all items
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldReturnAllItems()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);
            queue.Enqueue("item2", 2);
            queue.Enqueue("item3", 3);

            List<string> items = new List<string>(queue);

            Assert.Equal(3, items.Count);
            Assert.Contains("item1", items);
            Assert.Contains("item2", items);
            Assert.Contains("item3", items);
        }

        /// <summary>
        ///     Tests that EnqueueWithoutDuplicates returns true for new item
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_WhenNewItem_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.EnqueueWithoutDuplicates("item1", 1);

            Assert.True(result);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that EnqueueWithoutDuplicates returns false for duplicate item
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_WhenDuplicate_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.EnqueueWithoutDuplicates("item1", 1);
            bool result = queue.EnqueueWithoutDuplicates("item1", 2);

            Assert.False(result);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that GetPriority returns the priority of an item
        /// </summary>
        [Fact]
        public void GetPriority_ShouldReturnCorrectPriority()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 42);

            int priority = queue.GetPriority("item1");

            Assert.Equal(42, priority);
        }

        /// <summary>
        ///     Tests that GetPriority on item not in queue throws
        /// </summary>
        [Fact]
        public void GetPriority_WhenItemNotInQueue_ShouldThrowInvalidOperationException()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.GetPriority("item1"));
        }

        /// <summary>
        ///     Tests that IsValidQueue returns true for valid queue
        /// </summary>
        [Fact]
        public void IsValidQueue_WhenValid_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);
            queue.Enqueue("item2", 2);

            bool result = queue.IsValidQueue();

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsValidQueue returns true for empty queue
        /// </summary>
        [Fact]
        public void IsValidQueue_WhenEmpty_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.IsValidQueue();

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that TryFirst returns true when queue has items
        /// </summary>
        [Fact]
        public void TryFirst_WhenQueueHasItems_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            bool result = queue.TryFirst(out string first);

            Assert.True(result);
            Assert.Equal("item1", first);
        }

        /// <summary>
        ///     Tests that TryFirst returns false when queue is empty
        /// </summary>
        [Fact]
        public void TryFirst_WhenQueueEmpty_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.TryFirst(out string first);

            Assert.False(result);
            Assert.Null(first);
        }

        /// <summary>
        ///     Tests that TryDequeue returns true when queue has items
        /// </summary>
        [Fact]
        public void TryDequeue_WhenQueueHasItems_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            bool result = queue.TryDequeue(out string first);

            Assert.True(result);
            Assert.Equal("item1", first);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that TryDequeue returns false when queue is empty
        /// </summary>
        [Fact]
        public void TryDequeue_WhenQueueEmpty_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.TryDequeue(out string first);

            Assert.False(result);
            Assert.Null(first);
        }

        /// <summary>
        ///     Tests that TryRemove returns true when item is in queue
        /// </summary>
        [Fact]
        public void TryRemove_WhenItemInQueue_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);

            bool result = queue.TryRemove("item1");

            Assert.True(result);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that TryRemove returns false when item is not in queue
        /// </summary>
        [Fact]
        public void TryRemove_WhenItemNotInQueue_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.TryRemove("item1");

            Assert.False(result);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that TryUpdatePriority returns true when item is in queue
        /// </summary>
        [Fact]
        public void TryUpdatePriority_WhenItemInQueue_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 5);

            bool result = queue.TryUpdatePriority("item1", 1);

            Assert.True(result);
            Assert.Equal("item1", queue.First);
        }

        /// <summary>
        ///     Tests that TryUpdatePriority returns false when item is not in queue
        /// </summary>
        [Fact]
        public void TryUpdatePriority_WhenItemNotInQueue_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.TryUpdatePriority("item1", 1);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryGetPriority returns true when item is in queue
        /// </summary>
        [Fact]
        public void TryGetPriority_WhenItemInQueue_ShouldReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 42);

            bool result = queue.TryGetPriority("item1", out int priority);

            Assert.True(result);
            Assert.Equal(42, priority);
        }

        /// <summary>
        ///     Tests that TryGetPriority returns false when item is not in queue
        /// </summary>
        [Fact]
        public void TryGetPriority_WhenItemNotInQueue_ShouldReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool result = queue.TryGetPriority("item1", out int priority);

            Assert.False(result);
            Assert.Equal(0, priority);
        }

        /// <summary>
        ///     Tests that the non-generic version works with float priority
        /// </summary>
        [Fact]
        public void NonGenericQueue_ShouldWorkWithFloatPriority()
        {
            SimplePriorityQueue<string> queue = new SimplePriorityQueue<string>();

            queue.Enqueue("low", 10f);
            queue.Enqueue("high", 1f);

            Assert.Equal("high", queue.First);
        }

        /// <summary>
        ///     Tests that FIFO order is maintained for equal priorities
        /// </summary>
        [Fact]
        public void EnqueueEqualPriorities_ShouldMaintainFIFO()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("first", 1);
            queue.Enqueue("second", 1);
            queue.Enqueue("third", 1);

            Assert.Equal("first", queue.Dequeue());
            Assert.Equal("second", queue.Dequeue());
            Assert.Equal("third", queue.Dequeue());
        }

        /// <summary>
        ///     Tests that null items are handled correctly
        /// </summary>
        [Fact]
        public void NullItem_ShouldBeHandledCorrectly()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue(null, 1);

            Assert.True(queue.Contains(null));
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that removing null item works
        /// </summary>
        [Fact]
        public void RemoveNullItem_ShouldWork()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue(null, 1);
            queue.Remove(null);

            Assert.False(queue.Contains(null));
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that multiple enqueues of same item work
        /// </summary>
        [Fact]
        public void MultipleEnqueuesOfSameItem_ShouldWork()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("item1", 1);
            queue.Enqueue("item1", 2);

            Assert.Equal(2, queue.Count);
        }
    }
}
