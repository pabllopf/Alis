using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    public class GenericPriorityQueueAdvancedTest
    {
        [Fact]
        public void Constructor_WithCustomComparer_ChangesOrdering()
        {
            GenericPriorityQueue<TimestampNode, int> queue =
                new GenericPriorityQueue<TimestampNode, int>(10, Comparer<int>.Create((left, right) => right.CompareTo(left)));

            TimestampNode low = new TimestampNode("low");
            TimestampNode high = new TimestampNode("high");

            queue.Enqueue(low, 1);
            queue.Enqueue(high, 10);

            Assert.Same(high, queue.First);
        }

        [Fact]
        public void EqualPriorities_AreStableByInsertionOrder()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(10);
            TimestampNode first = new TimestampNode("first");
            TimestampNode second = new TimestampNode("second");

            queue.Enqueue(first, 7);
            queue.Enqueue(second, 7);

            Assert.Same(first, queue.Dequeue());
            Assert.Same(second, queue.Dequeue());
        }

        [Fact]
        public void Remove_NonLastAndLastNode_KeepQueueConsistent()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(8);
            TimestampNode a = new TimestampNode("a");
            TimestampNode b = new TimestampNode("b");
            TimestampNode c = new TimestampNode("c");

            queue.Enqueue(a, 3);
            queue.Enqueue(b, 1);
            queue.Enqueue(c, 2);

            queue.Remove(a);
            queue.Remove(c);

            Assert.Equal(1, queue.Count);
            Assert.Same(b, queue.First);
            Assert.True(queue.IsValidQueue());
        }

        [Fact]
        public void ResetNode_SetsQueueIndexToZero()
        {
            GenericPriorityQueue<TimestampNode, int> queue = new GenericPriorityQueue<TimestampNode, int>(3);
            TimestampNode node = new TimestampNode("node");

            queue.Enqueue(node, 1);
            queue.ResetNode(node);

            Assert.Equal(0, node.QueueIndex);
        }

        private sealed class TimestampNode : GenericPriorityQueueNode<int>
        {
            public TimestampNode(string id) => Id = id;

            public string Id { get; }
        }
    }
}


