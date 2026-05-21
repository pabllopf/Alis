

using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The generic priority queue node test class
    /// </summary>
    public class GenericPriorityQueueNodeTest
    {
        /// <summary>
        ///     Tests that priority set and get returns correct value
        /// </summary>
        [Fact]
        public void Priority_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.Priority = 5;
            Assert.Equal(5, node.Priority);
        }

        /// <summary>
        ///     Tests that queue index set and get returns correct value
        /// </summary>
        [Fact]
        public void QueueIndex_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.QueueIndex = 2;
            Assert.Equal(2, node.QueueIndex);
        }

        /// <summary>
        ///     Tests that insertion index set and get returns correct value
        /// </summary>
        [Fact]
        public void InsertionIndex_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.InsertionIndex = 10;
            Assert.Equal(10, node.InsertionIndex);
        }
    }
}