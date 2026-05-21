

using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel execution context test class
    /// </summary>
    public class ParallelExecutionContextTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            Assert.True(context.ProcessorCount > 0);
            Assert.True(context.MaxDegreeOfParallelism >= 1);
            Assert.Equal(64, context.MinBatchSizePerThread);
            Assert.True(context.EnableParallelExecution || context.ProcessorCount == 1);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions returns one for small count
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithSmallCount_ReturnsOne()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            int partitions = context.CalculateOptimalPartitions(50, 128);

            Assert.Equal(1, partitions);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions returns multiple for large count
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithLargeCount_ReturnsMultiple()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 64
            };

            int partitions = context.CalculateOptimalPartitions(1000, 64);

            Assert.True(partitions > 1);
            Assert.True(partitions <= context.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions respects max degree
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_RespectsMaxDegree()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 2,
                MinBatchSizePerThread = 10
            };

            int partitions = context.CalculateOptimalPartitions(10000, 10);

            Assert.True(partitions <= 2);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns false when disabled
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WhenDisabled_ReturnsFalse()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };

            bool result = context.ShouldExecuteInParallel(1000, 64);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns false for small count
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WithSmallCount_ReturnsFalse()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true
            };

            bool result = context.ShouldExecuteInParallel(50, 128);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns true for large count
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WithLargeCount_ReturnsTrue()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };

            bool result = context.ShouldExecuteInParallel(1000, 64);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that max degree of parallelism can be set
        /// </summary>
        [Fact]
        public void MaxDegreeOfParallelism_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.MaxDegreeOfParallelism = 8;

            Assert.Equal(8, context.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that min batch size per thread can be set
        /// </summary>
        [Fact]
        public void MinBatchSizePerThread_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.MinBatchSizePerThread = 32;

            Assert.Equal(32, context.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that enable parallel execution can be set
        /// </summary>
        [Fact]
        public void EnableParallelExecution_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.EnableParallelExecution = false;

            Assert.False(context.EnableParallelExecution);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions with disabled parallelism returns one
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithDisabledParallelism_ReturnsOne()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };

            int partitions = context.CalculateOptimalPartitions(10000, 64);

            Assert.Equal(1, partitions);
        }
    }
}