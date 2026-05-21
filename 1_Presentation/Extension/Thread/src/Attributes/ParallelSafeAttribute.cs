

using System;

namespace Alis.Extension.Thread.Attributes
{
    /// <summary>
    ///     Marks a component as safe for parallel execution.
    ///     Components marked with this attribute can be processed simultaneously across multiple threads.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public sealed class ParallelSafeAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelSafeAttribute" /> class
        /// </summary>
        public ParallelSafeAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelSafeAttribute" /> class
        /// </summary>
        /// <param name="minBatchSize">The minimum batch size for parallel execution</param>
        public ParallelSafeAttribute(int minBatchSize) => MinBatchSize = minBatchSize;

        /// <summary>
        ///     Gets the minimum batch size for parallel execution.
        ///     If entity count is below this threshold, sequential execution will be used.
        /// </summary>
        public int MinBatchSize { get; } = 128;
    }
}