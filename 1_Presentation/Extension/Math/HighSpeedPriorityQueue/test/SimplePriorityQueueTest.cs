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
using System.Linq;
using Alis.Extension.Math.HighSpeedPriorityQueue;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     Tests for the SimplePriorityQueue class
    /// </summary>
    public class SimplePriorityQueueTest
    {
        /// <summary>
        ///     Tests that default constructor should create an empty queue with Count=0
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateEmptyQueue()
        {
            var queue = new SimplePriorityQueue<string>();

            Assert.Equal(0, queue.Count);
            Assert.Empty(queue);
        }

        /// <summary>
        ///     Tests that constructor with priorityComparer should create a valid queue
        /// </summary>
        [Fact]
        public void Constructor_WithPriorityComparer_ShouldCreateValidQueue()
        {
            var comparer = Comparer<int>.Descending();
            var queue = new SimplePriorityQueue<string, int>(comparer);

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor with comparison function should create a valid queue
        /// </summary>
        [Fact]
        public void Constructor_WithComparison_ShouldCreateValidQueue()
        {
            var queue = new SimplePriorityQueue<string, int>((x, y) => y.CompareTo(x));

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that Enqueue and Dequeue should return items in priority order
        /// </summary>
        [Fact]
        public void EnqueueAndDequeue_ShouldReturnItemsInPriorityOrder()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Low", 3);
            queue.Enqueue("High", 1);
            queue.Enqueue("Medium", 2);

            Assert.Equal(3, queue.Count);
            Assert.Equal("High", queue.Dequeue());
            Assert.Equal("Medium", queue.Dequeue());
            Assert.Equal("Low", queue.Dequeue());
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that First should return the highest priority item without removing it
        /// </summary>
        [Fact]
        public void First_ShouldReturnHighestPriorityWithoutRemoving()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Item1", 5);
            queue.Enqueue("Item2", 1);
            queue.Enqueue("Item3", 3);

            Assert.Equal(3, queue.Count);
            Assert.Equal("Item2", queue.First);
            Assert.Equal(3, queue.Count); // Count unchanged
        }

        /// <summary>
        ///     Tests that First should throw on empty queue
        /// </summary>
        [Fact]
        public void First_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => { var _ = queue.First; });
        }

        /// <summary>
        ///     Tests that Contains should return true for enqueued items
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrueForEnqueuedItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Exists", 1);

            Assert.True(queue.Contains("Exists"));
            Assert.False(queue.Contains("NotExists"));
        }

        /// <summary>
        ///     Tests that Contains should return false for removed items
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnFalseForRemovedItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("ToRemove", 1);
            queue.Remove("ToRemove");

            Assert.False(queue.Contains("ToRemove"));
        }

        /// <summary>
        ///     Tests that Clear should remove all items
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 3);

            queue.Clear();

            Assert.Equal(0, queue.Count);
            Assert.Empty(queue);
        }

        /// <summary>
        ///     Tests that Dequeue on empty queue should throw
        /// </summary>
        [Fact]
        public void Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        /// <summary>
        ///     Tests that Remove should remove an item from the queue
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveItemFromQueue()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Keep", 2);
            queue.Enqueue("Remove", 1);
            queue.Enqueue("AlsoKeep", 3);

            queue.Remove("Remove");

            Assert.Equal(2, queue.Count);
            Assert.False(queue.Contains("Remove"));
            Assert.True(queue.Contains("Keep"));
            Assert.True(queue.Contains("AlsoKeep"));
        }

        /// <summary>
        ///     Tests that Remove on non-existent item should throw
        /// </summary>
        [Fact]
        public void Remove_OnNonExistentItem_ShouldThrowInvalidOperationException()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.Remove("DoesNotExist"));
        }

        /// <summary>
        ///     Tests that UpdatePriority should change the priority of an item
        /// </summary>
        [Fact]
        public void UpdatePriority_ShouldChangePriorityOfItem()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Item", 5);
            queue.UpdatePriority("Item", 1);

            Assert.Equal(1, queue.GetPriority("Item"));
        }

        /// <summary>
        ///     Tests that UpdatePriority on non-existent item should throw
        /// </summary>
        [Fact]
        public void UpdatePriority_OnNonExistentItem_ShouldThrowInvalidOperationException()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.UpdatePriority("DoesNotExist", 1));
        }

        /// <summary>
        ///     Tests that GetPriority should return the priority of an enqueued item
        /// </summary>
        [Fact]
        public void GetPriority_ShouldReturnPriorityOfEnqueuedItem()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Item", 42);

            Assert.Equal(42, queue.GetPriority("Item"));
        }

        /// <summary>
        ///     Tests that GetPriority on non-existent item should throw
        /// </summary>
        [Fact]
        public void GetPriority_OnNonExistentItem_ShouldThrowInvalidOperationException()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.Throws<InvalidOperationException>(() => queue.GetPriority("DoesNotExist"));
        }

        /// <summary>
        ///     Tests that TryFirst returns false for empty queue and true for non-empty
        /// </summary>
        [Fact]
        public void TryFirst_ReturnsCorrectValueForEmptyAndNonEmptyQueues()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.False(queue.TryFirst(out _));

            queue.Enqueue("Item", 1);
            Assert.True(queue.TryFirst(out var first));
            Assert.Equal("Item", first);
        }

        /// <summary>
        ///     Tests that TryDequeue returns false for empty queue and true for non-empty
        /// </summary>
        [Fact]
        public void TryDequeue_ReturnsCorrectValueForEmptyAndNonEmptyQueues()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.False(queue.TryDequeue(out _));
            Assert.Equal(0, queue.Count);

            queue.Enqueue("Item", 1);
            Assert.True(queue.TryDequeue(out var item));
            Assert.Equal("Item", item);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that TryRemove returns false for non-existent and true for existing items
        /// </summary>
        [Fact]
        public void TryRemove_ReturnsCorrectValueForExistingAndNonExistingItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.False(queue.TryRemove("DoesNotExist"));

            queue.Enqueue("Item", 1);
            Assert.True(queue.TryRemove("Item"));
            Assert.False(queue.Contains("Item"));
        }

        /// <summary>
        ///     Tests that TryUpdatePriority returns false for non-existent and true for existing items
        /// </summary>
        [Fact]
        public void TryUpdatePriority_ReturnsCorrectValueForExistingAndNonExistingItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.False(queue.TryUpdatePriority("DoesNotExist", 1));

            queue.Enqueue("Item", 5);
            Assert.True(queue.TryUpdatePriority("Item", 1));
            Assert.Equal(1, queue.GetPriority("Item"));
        }

        /// <summary>
        ///     Tests that TryGetPriority returns false for non-existent and true for existing items
        /// </summary>
        [Fact]
        public void TryGetPriority_ReturnsCorrectValueForExistingAndNonExistingItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.False(queue.TryGetPriority("DoesNotExist", out _));

            queue.Enqueue("Item", 42);
            Assert.True(queue.TryGetPriority("Item", out var priority));
            Assert.Equal(42, priority);
        }

        /// <summary>
        ///     Tests that EnqueueWithoutDuplicates returns true for new items and false for duplicates
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_ReturnsTrueForNewAndFalseForDuplicates()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.True(queue.EnqueueWithoutDuplicates("Item", 1));
            Assert.False(queue.EnqueueWithoutDuplicates("Item", 2));
            Assert.True(queue.EnqueueWithoutDuplicates("Other", 3));

            Assert.Equal(2, queue.Count);
        }

        /// <summary>
        ///     Tests that GetEnumerator should iterate over all items
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldIterateOverAllItems()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 3);

            var items = queue.ToList();

            Assert.Equal(3, items.Count);
            Assert.Contains("A", items);
            Assert.Contains("B", items);
            Assert.Contains("C", items);
        }

        /// <summary>
        ///     Tests that IsValidQueue returns true for a valid queue
        /// </summary>
        [Fact]
        public void IsValidQueue_ReturnsTrueForValidQueue()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 3);

            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that IsValidQueue returns true for empty queue
        /// </summary>
        [Fact]
        public void IsValidQueue_ReturnsTrueForEmptyQueue()
        {
            var queue = new SimplePriorityQueue<string, int>();

            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that null items are handled correctly
        /// </summary>
        [Fact]
        public void NullItems_ShouldBeHandledCorrectly()
        {
            var queue = new SimplePriorityQueue<string?, int>();

            queue.Enqueue(null!, 1);
            queue.Enqueue("Item", 2);

            Assert.True(queue.Contains(null!));
            Assert.Equal(2, queue.Count);

            var dequeued = queue.Dequeue();
            Assert.Null(dequeued);
        }

        /// <summary>
        ///     Tests that multiple enqueue of same item works correctly
        /// </summary>
        [Fact]
        public void MultipleEnqueueOfSameItem_ShouldWorkCorrectly()
        {
            var queue = new SimplePriorityQueue<string, int>();

            queue.Enqueue("Item", 3);
            queue.Enqueue("Item", 1);
            queue.Enqueue("Item", 2);

            Assert.Equal(3, queue.Count);

            // Dequeue all
            var items = new List<string?>();
            while (queue.TryDequeue(out var item))
            {
                items.Add(item);
            }

            Assert.Equal(3, items.Count);
        }

        /// <summary>
        ///     Tests that the queue auto-resizes when exceeding initial capacity
        /// </summary>
        [Fact]
        public void Queue_AutoResizesWhenExceedingInitialCapacity()
        {
            var queue = new SimplePriorityQueue<int, int>();

            // Enqueue more than initial capacity (10)
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i, i);
            }

            Assert.Equal(100, queue.Count);

            // Verify all items can be dequeued in order
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, queue.Dequeue());
            }

            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that the SimplePriorityQueue<TItem> (single type param) works as expected
        /// </summary>
        [Fact]
        public void SingleTypeParamQueue_ShouldWorkAsExpected()
        {
            var queue = new SimplePriorityQueue<string>();

            queue.Enqueue("Low", 3);
            queue.Enqueue("High", 1);
            queue.Enqueue("Medium", 2);

            Assert.Equal(3, queue.Count);
            Assert.Equal("High", queue.Dequeue());
            Assert.Equal("Medium", queue.Dequeue());
            Assert.Equal("Low", queue.Dequeue());
        }

        /// <summary>
        ///     Tests that the single-type queue with custom comparer works
        /// </summary>
        [Fact]
        public void SingleTypeParamQueue_WithCustomComparer_ShouldWork()
        {
            var comparer = Comparer<float>.Descending();
            var queue = new SimplePriorityQueue<string>(comparer);

            queue.Enqueue("Low", 3.0f);
            queue.Enqueue("High", 1.0f);

            Assert.Equal(2, queue.Count);
            Assert.Equal("High", queue.Dequeue());
            Assert.Equal("Low", queue.Dequeue());
        }
    }
}
