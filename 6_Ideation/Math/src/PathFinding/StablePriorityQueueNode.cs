﻿namespace Alis.Core.Aspect.Math.PathFinding
{
    public class StablePriorityQueueNode : FastPriorityQueueNode
    {
        /// <summary>
        /// Represents the order the node was inserted in
        /// </summary>
        public long InsertionIndex { get; internal set; }
    }
}
