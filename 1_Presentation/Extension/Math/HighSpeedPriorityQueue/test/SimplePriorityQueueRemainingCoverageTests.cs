using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    public class SimplePriorityQueueRemainingCoverageTests
    {
        [Fact]
        public void Remove_DefaultItemWhenNullCacheEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Remove(default(string)));
        }

        [Fact]
        public void GetEnumerator_NonGeneric_ReturnsEnumerator()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 1);
            IEnumerable enumerable = queue;
            IEnumerator enumerator = enumerable.GetEnumerator();
            Assert.NotNull(enumerator);
            Assert.True(enumerator.MoveNext());
            Assert.Equal("a", enumerator.Current);
        }

        [Fact]
        public void TryFirst_WithItems_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("first", 1);
            bool result = queue.TryFirst(out string item);
            Assert.True(result);
            Assert.Equal("first", item);
        }

        [Fact]
        public void TryDequeue_WithItems_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item", 1);
            bool result = queue.TryDequeue(out string item);
            Assert.True(result);
            Assert.Equal("item", item);
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void TryRemove_DefaultItemWhenNullCacheEmpty_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            bool result = queue.TryRemove(default(string));
            Assert.False(result);
        }

        [Fact]
        public void TryRemove_ItemNotFound_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            bool result = queue.TryRemove("nonexistent");
            Assert.False(result);
        }

        [Fact]
        public void IsValidQueue_WithItems_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 3);
            queue.Enqueue("b", 1);
            queue.Enqueue("c", 2);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void SimplePriorityQueue_ConstructorWithComparer_CreatesQueue()
        {
            SimplePriorityQueue<string> queue = new SimplePriorityQueue<string>(Comparer<float>.Default);
            Assert.Equal(0, queue.Count);
            queue.Enqueue("x", 1.0f);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void SimplePriorityQueue_ConstructorWithComparison_CreatesQueue()
        {
            SimplePriorityQueue<string> queue = new SimplePriorityQueue<string>((a, b) => a.CompareTo(b));
            Assert.Equal(0, queue.Count);
            queue.Enqueue("x", 2.0f);
            Assert.Equal("x", queue.Dequeue());
        }

        [Fact]
        public void Enqueue_MultipleItems_CausesResize()
        {
            SimplePriorityQueue<int, int> queue = new SimplePriorityQueue<int, int>();
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i, i);
            }
            Assert.Equal(100, queue.Count);
            Assert.Equal(0, queue.Dequeue());
        }

        [Fact]
        public void Contains_NullItem_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 1);
            Assert.False(queue.Contains(default(string)));
        }

        [Fact]
        public void Contains_NullItem_ReturnsTrueWhenEnqueued()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue(null, 1);
            Assert.True(queue.Contains(default(string)));
        }

        [Fact]
        public void GetExistingNode_NullItem_ReturnsNull()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 1);
            Assert.False(queue.TryGetPriority(default(string), out int priority));
            Assert.Equal(0, priority);
        }

        [Fact]
        public void EnqueueWithoutDuplicates_NullItem_FirstTimeReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.True(queue.EnqueueWithoutDuplicates(null, 1));
        }
    }
}
