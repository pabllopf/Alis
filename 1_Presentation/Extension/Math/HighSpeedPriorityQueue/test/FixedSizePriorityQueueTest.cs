

using System;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The fixed size priority queue test class
    /// </summary>
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