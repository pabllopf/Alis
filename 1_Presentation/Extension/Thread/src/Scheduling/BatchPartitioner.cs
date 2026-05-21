

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Extension.Thread.Scheduling
{
    /// <summary>
    ///     Represents a batch of work
    /// </summary>
    public readonly struct BatchPartition
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BatchPartition" /> struct
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="length">The length</param>
        public BatchPartition(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }

        /// <summary>
        ///     Gets the start index
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        ///     Gets the length
        /// </summary>
        public int Length { get; }

        /// <summary>
        ///     Gets the end index (exclusive)
        /// </summary>
        public int EndIndex => StartIndex + Length;
    }

    /// <summary>
    ///     Partitioner for dividing work into batches
    /// </summary>
    public static class BatchPartitioner
    {
        /// <summary>
        ///     Creates partitions for the given total count
        /// </summary>
        /// <param name="totalCount">The total number of items</param>
        /// <param name="partitionCount">The desired number of partitions</param>
        /// <returns>A span of batch partitions</returns>
        [ExcludeFromCodeCoverage]
        public static BatchPartition[] CreatePartitions(int totalCount, int partitionCount)
        {
            if (totalCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalCount));
            }

            if (partitionCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(partitionCount));
            }

            int actualPartitions = Math.Min(partitionCount, totalCount);
            BatchPartition[] partitions = new BatchPartition[actualPartitions];

            int itemsPerPartition = totalCount / actualPartitions;
            int remainder = totalCount % actualPartitions;

            int currentIndex = 0;
            for (int i = 0; i < actualPartitions; i++)
            {
                int length = itemsPerPartition + (i < remainder ? 1 : 0);
                partitions[i] = new BatchPartition(currentIndex, length);
                currentIndex += length;
            }

            return partitions;
        }

        /// <summary>
        ///     Creates balanced partitions with a minimum size constraint
        /// </summary>
        /// <param name="totalCount">The total number of items</param>
        /// <param name="maxPartitionCount">The maximum number of partitions</param>
        /// <param name="minPartitionSize">The minimum size per partition</param>
        /// <returns>A span of batch partitions</returns>
        public static BatchPartition[] CreateBalancedPartitions(int totalCount, int maxPartitionCount, int minPartitionSize)
        {
            if (totalCount < minPartitionSize)
            {
                return new[] {new BatchPartition(0, totalCount)};
            }

            int actualPartitions = Math.Min(maxPartitionCount, totalCount / minPartitionSize);
            actualPartitions = Math.Max(1, actualPartitions);

            return CreatePartitions(totalCount, actualPartitions);
        }
    }
}