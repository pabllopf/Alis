using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    public class SimplePriorityQueueAdvancedTest
    {
        [Fact]
        public void First_WhenEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => _ = queue.First);
        }

        [Fact]
        public void Dequeue_WhenEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Remove_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Remove("missing"));
        }

        [Fact]
        public void UpdatePriority_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.UpdatePriority("missing", 3));
        }

        [Fact]
        public void GetPriority_WhenMissing_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.GetPriority("missing"));
        }

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

