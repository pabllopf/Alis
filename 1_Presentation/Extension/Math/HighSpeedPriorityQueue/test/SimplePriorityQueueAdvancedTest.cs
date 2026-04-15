using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    /// The simple priority queue advanced test class
    /// </summary>
    public class SimplePriorityQueueAdvancedTest
    {
        /// <summary>
        /// Tests that first when empty throws
        /// </summary>
        [Fact]
        public void First_WhenEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => _ = queue.First);
        }

        /// <summary>
        /// Tests that dequeue when empty throws
        /// </summary>
        [Fact]
        public void Dequeue_WhenEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        /// <summary>
        /// Tests that remove when missing throws
        /// </summary>
        [Fact]
        public void Remove_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Remove("missing"));
        }

        /// <summary>
        /// Tests that update priority when missing throws
        /// </summary>
        [Fact]
        public void UpdatePriority_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.UpdatePriority("missing", 3));
        }

        /// <summary>
        /// Tests that get priority when missing throws
        /// </summary>
        [Fact]
        public void GetPriority_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.GetPriority("missing"));
        }

        /// <summary>
        /// Tests that try methods on empty queue return false
        /// </summary>
        [Fact]
        public void TryMethods_OnEmptyQueue_ReturnFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool firstResult = queue.TryFirst(out string first);
            bool dequeueResult = queue.TryDequeue(out string dequeued);
            bool removeResult = queue.TryRemove("x");
            bool updateResult = queue.TryUpdatePriority("x", 10);
            bool priorityResult = queue.TryGetPriority("x", out int priority);

            Assert.False(firstResult);
            Assert.False(dequeueResult);
            Assert.False(removeResult);
            Assert.False(updateResult);
            Assert.False(priorityResult);
            Assert.Null(first);
            Assert.Null(dequeued);
            Assert.Equal(0, priority);
        }

        /// <summary>
        /// Tests that try methods on existing item return true
        /// </summary>
        [Fact]
        public void TryMethods_OnExistingItem_ReturnTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("work", 10);

            Assert.True(queue.TryUpdatePriority("work", 1));
            Assert.True(queue.TryGetPriority("work", out int priority));
            Assert.Equal(1, priority);

            Assert.True(queue.TryFirst(out string first));
            Assert.Equal("work", first);

            Assert.True(queue.TryRemove("work"));
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        /// Tests that enqueue without duplicates with null allows single entry
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_WithNull_AllowsSingleEntry()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();

            bool first = queue.EnqueueWithoutDuplicates(null, 1);
            bool second = queue.EnqueueWithoutDuplicates(null, 2);

            Assert.True(first);
            Assert.False(second);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        /// Tests that duplicate items remove only one occurrence
        /// </summary>
        [Fact]
        public void DuplicateItems_RemoveOnlyOneOccurrence()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("dup", 2);
            queue.Enqueue("dup", 1);

            queue.Remove("dup");

            Assert.True(queue.Contains("dup"));
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        /// Tests that custom equality comparer is used for contains and updates
        /// </summary>
        [Fact]
        public void CustomEqualityComparer_IsUsedForContainsAndUpdates()
        {
            SimplePriorityQueue<string, int> queue =
                new SimplePriorityQueue<string, int>(Comparer<int>.Default, StringComparer.OrdinalIgnoreCase);

            queue.Enqueue("Task", 2);

            Assert.True(queue.Contains("task"));
            queue.UpdatePriority("task", 0);
            Assert.Equal("Task", queue.Dequeue());
        }

        /// <summary>
        /// Tests that enumerator returns snapshot of items
        /// </summary>
        [Fact]
        public void Enumerator_ReturnsSnapshotOfItems()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 3);
            queue.Enqueue("b", 1);
            queue.Enqueue("c", 2);

            string[] snapshot = queue.ToArray();

            Assert.Equal(3, snapshot.Length);
            Assert.Contains("a", snapshot);
            Assert.Contains("b", snapshot);
            Assert.Contains("c", snapshot);
        }
    }
}

