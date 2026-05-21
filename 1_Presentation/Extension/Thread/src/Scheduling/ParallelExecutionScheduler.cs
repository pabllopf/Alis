

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Alis.Extension.Thread.Core;

namespace Alis.Extension.Thread.Scheduling
{
    /// <summary>
    ///     Scheduler for parallel execution of work items
    /// </summary>
    public sealed class ParallelExecutionScheduler
    {
        /// <summary>
        ///     The execution context
        /// </summary>
        private readonly ParallelExecutionContext context;

        /// <summary>
        ///     The work item pool
        /// </summary>
        private readonly WorkItemPool workItemPool;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelExecutionScheduler" /> class
        /// </summary>
        /// <param name="context">The execution context</param>
        public ParallelExecutionScheduler(ParallelExecutionContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            workItemPool = new WorkItemPool();
        }

        /// <summary>
        ///     Executes the action on the given range, potentially in parallel
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="count">The number of items to process</param>
        /// <param name="action">The action to execute for each range</param>
        /// <param name="minBatchSize">The minimum batch size for parallel execution</param>
        [ExcludeFromCodeCoverage]
        public void ExecuteRange(int startIndex, int count, Action<int, int> action, int minBatchSize = 128)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (count <= 0)
            {
                return;
            }

            if (!context.ShouldExecuteInParallel(count, minBatchSize))
            {
                action(startIndex, count);
                return;
            }

            int partitions = context.CalculateOptimalPartitions(count, minBatchSize);
            if (partitions == 1)
            {
                action(startIndex, count);
                return;
            }

            ExecuteParallel(startIndex, count, action, partitions);
        }

        /// <summary>
        ///     Executes the action in parallel
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="count">The number of items</param>
        /// <param name="action">The action to execute</param>
        /// <param name="partitions">The number of partitions</param>
        private void ExecuteParallel(int startIndex, int count, Action<int, int> action, int partitions)
        {
            int itemsPerPartition = count / partitions;
            int remainder = count % partitions;

            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = context.MaxDegreeOfParallelism
            };

            Parallel.For(0, partitions, options, partition =>
            {
                int start = startIndex + partition * itemsPerPartition;
                int length = itemsPerPartition;

                if (partition == partitions - 1)
                {
                    length += remainder;
                }

                action(start, length);
            });
        }

        /// <summary>
        ///     Clears the work item pool
        /// </summary>
        public void Clear()
        {
            workItemPool.Clear();
        }
    }
}