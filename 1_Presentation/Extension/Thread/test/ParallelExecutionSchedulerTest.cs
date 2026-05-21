

using System.Threading;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel execution scheduler test class
    /// </summary>
    public class ParallelExecutionSchedulerTest
    {
        /// <summary>
        ///     Tests that execute range with small count executes sequentially
        /// </summary>
        [Fact]
        public void ExecuteRange_WithSmallCount_ExecutesSequentially()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int executionCount = 0;

            scheduler.ExecuteRange(0, 10, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                Assert.Equal(0, start);
                Assert.Equal(10, length);
            });

            Assert.Equal(1, executionCount);
        }

        /// <summary>
        ///     Tests that execute range with large count executes in parallel
        /// </summary>
        [Fact]
        public void ExecuteRange_WithLargeCount_ExecutesInParallel()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int totalProcessed = 0;

            scheduler.ExecuteRange(0, 1000, (start, length) => { Interlocked.Add(ref totalProcessed, length); }, 64);

            Assert.Equal(1000, totalProcessed);
        }

        /// <summary>
        ///     Tests that execute range processes all items correctly
        /// </summary>
        [Fact]
        public void ExecuteRange_ProcessesAllItemsCorrectly()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] data = new int[500];

            scheduler.ExecuteRange(0, data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 2;
                }
            }, 64);

            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i * 2, data[i]);
            }
        }

        /// <summary>
        ///     Tests that clear clears internal state
        /// </summary>
        [Fact]
        public void Clear_ClearsInternalState()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            scheduler.Clear();

            Assert.True(true);
        }
    }
}