namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     The fast priority queue node class
    /// </summary>
    public class FastPriorityQueueNode
    {
        /// <summary>
        ///     The Priority to insert this node at.
        ///     Cannot be manually edited - see queue.Enqueue() and queue.UpdatePriority() instead
        /// </summary>
        public float Priority { get; protected internal set; }

        /// <summary>
        ///     Represents the current position in the queue
        /// </summary>
        public int QueueIndex { get; internal set; }
    }
}