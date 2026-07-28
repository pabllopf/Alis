using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    /// The simple priority queue remaining coverage tests class
    /// </summary>
    public class SimplePriorityQueueRemainingCoverageTests
    {
        /// <summary>
        /// Tests that remove default item when null cache empty throws
        /// </summary>
        [Fact]
        public void Remove_DefaultItemWhenNullCacheEmpty_Throws()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Throws<InvalidOperationException>(() => queue.Remove(default(string)));
        }

        /// <summary>
        /// Tests that get enumerator non generic returns enumerator
        /// </summary>
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

        /// <summary>
        /// Tests that try first with items returns true
        /// </summary>
        [Fact]
        public void TryFirst_WithItems_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("first", 1);
            bool result = queue.TryFirst(out string item);
            Assert.True(result);
            Assert.Equal("first", item);
        }

        /// <summary>
        /// Tests that try dequeue with items returns true
        /// </summary>
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

        /// <summary>
        /// Tests that try remove default item when null cache empty returns false
        /// </summary>
        [Fact]
        public void TryRemove_DefaultItemWhenNullCacheEmpty_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            bool result = queue.TryRemove(default(string));
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try remove item not found returns false
        /// </summary>
        [Fact]
        public void TryRemove_ItemNotFound_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            bool result = queue.TryRemove("nonexistent");
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is valid queue with items returns true
        /// </summary>
        [Fact]
        public void IsValidQueue_WithItems_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 3);
            queue.Enqueue("b", 1);
            queue.Enqueue("c", 2);
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that simple priority queue constructor with comparer creates queue
        /// </summary>
        [Fact]
        public void SimplePriorityQueue_ConstructorWithComparer_CreatesQueue()
        {
            SimplePriorityQueue<string> queue = new SimplePriorityQueue<string>(Comparer<float>.Default);
            Assert.Equal(0, queue.Count);
            queue.Enqueue("x", 1.0f);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        /// Tests that simple priority queue constructor with comparison creates queue
        /// </summary>
        [Fact]
        public void SimplePriorityQueue_ConstructorWithComparison_CreatesQueue()
        {
            SimplePriorityQueue<string> queue = new SimplePriorityQueue<string>((a, b) => a.CompareTo(b));
            Assert.Equal(0, queue.Count);
            queue.Enqueue("x", 2.0f);
            Assert.Equal("x", queue.Dequeue());
        }

        /// <summary>
        /// Tests that enqueue multiple items causes resize
        /// </summary>
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

        /// <summary>
        /// Tests that contains null item returns false
        /// </summary>
        [Fact]
        public void Contains_NullItem_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 1);
            Assert.False(queue.Contains(default(string)));
        }

        /// <summary>
        /// Tests that contains null item returns true when enqueued
        /// </summary>
        [Fact]
        public void Contains_NullItem_ReturnsTrueWhenEnqueued()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue(null, 1);
            Assert.True(queue.Contains(default(string)));
        }

        /// <summary>
        /// Tests that get existing node null item returns null
        /// </summary>
        [Fact]
        public void GetExistingNode_NullItem_ReturnsNull()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("a", 1);
            Assert.False(queue.TryGetPriority(default(string), out int priority));
            Assert.Equal(0, priority);
        }

        /// <summary>
        /// Tests that enqueue without duplicates null item first time returns true
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_NullItem_FirstTimeReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.True(queue.EnqueueWithoutDuplicates(null, 1));
        }

        /// <summary>
        /// Tests that try remove null item when null cache not empty removes item
        /// </summary>
        [Fact]
        public void TryRemove_NullItem_WhenNullCacheNotEmpty_RemovesItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue(null, 1);
            bool result = queue.TryRemove(default(string));
            Assert.True(result);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        /// Tests that remove from node cache when item not in cache does not throw
        /// </summary>
        [Fact]
        public void RemoveFromNodeCache_WhenItemNotInCache_DoesNotThrow()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("test", 1);
            queue._itemToNodesCache.Remove("test");
            queue.Dequeue();
        }

        /// <summary>
        /// Tests that is valid queue when cache has extra nodes returns false
        /// </summary>
        [Fact]
        public void IsValidQueue_WhenCacheHasExtraNodes_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("valid", 1);
            SimplePriorityQueue<string, int>.SimpleNode fakeNode = new SimplePriorityQueue<string, int>.SimpleNode("fake");
            queue._itemToNodesCache["fake"] = new List<SimplePriorityQueue<string, int>.SimpleNode> { fakeNode };
            Assert.False(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that is valid queue when queue has extra nodes returns false
        /// </summary>
        [Fact]
        public void IsValidQueue_WhenQueueHasExtraNodes_ReturnsFalse()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("valid", 1);
            SimplePriorityQueue<string, int>.SimpleNode extraNode = new SimplePriorityQueue<string, int>.SimpleNode("extra");
            queue._queue.Enqueue(extraNode, 2);
            Assert.False(queue.IsValidQueue());
        }

        /// <summary>
        /// Tests that try first when queue emptied between checks should cover braces
        /// </summary>
        [Fact]
        public void TryFirst_WhenQueueEmptiedBetweenChecks_ShouldCoverBraces()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item", 1);

            bool result = true;
            Thread thread = new Thread(() => result = queue.TryFirst(out _))
            {
                IsBackground = true
            };

            lock (queue._queue)
            {
                thread.Start();
                Thread.Sleep(100);
                queue.Clear();
            }

            thread.Join();
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try dequeue when queue emptied between checks should cover braces
        /// </summary>
        [Fact]
        public void TryDequeue_WhenQueueEmptiedBetweenChecks_ShouldCoverBraces()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item", 1);

            bool result = true;
            Thread thread = new Thread(() => result = queue.TryDequeue(out _))
            {
                IsBackground = true
            };

            lock (queue._queue)
            {
                thread.Start();
                Thread.Sleep(100);
                queue.Clear();
            }

            thread.Join();
            Assert.False(result);
        }
    }
}
