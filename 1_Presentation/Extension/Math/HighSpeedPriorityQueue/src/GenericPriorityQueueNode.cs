namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     The generic priority queue node class
    /// </summary>
    public class GenericPriorityQueueNode<TPriority>
    {
        /// <summary>
        ///     The Priority to insert this node at.
        ///     Cannot be manually edited - see queue.Enqueue() and queue.UpdatePriority() instead
        /// </summary>
        public TPriority Priority { get; protected internal set; }

        /// <summary>
        ///     Represents the current position in the queue
        /// </summary>
        public int QueueIndex { get; internal set; }

        /// <summary>
        ///     Represents the order the node was inserted in
        /// </summary>
        public long InsertionIndex { get; internal set; }
    }
}