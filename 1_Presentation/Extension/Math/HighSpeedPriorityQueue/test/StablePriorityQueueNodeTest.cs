

using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The stable priority queue node test class
    /// </summary>
    public class StablePriorityQueueNodeTest
    {
        /// <summary>
        ///     Tests that insertion index initially zero
        /// </summary>
        [Fact]
        public void InsertionIndex_InitiallyZero()
        {
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            Assert.Equal(0, node.InsertionIndex);
        }

        /// <summary>
        ///     Tests that insertion index set correctly
        /// </summary>
        [Fact]
        public void InsertionIndex_SetCorrectly()
        {
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            node.InsertionIndex = 5;
            Assert.Equal(5, node.InsertionIndex);
        }
    }
}