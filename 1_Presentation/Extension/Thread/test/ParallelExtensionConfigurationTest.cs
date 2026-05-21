

using System;
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Execution;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel extension configuration test class
    /// </summary>
    public class ParallelExtensionConfigurationTest
    {
        /// <summary>
        ///     Tests that default configuration has correct values
        /// </summary>
        [Fact]
        public void DefaultConfiguration_HasCorrectValues()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration();

            Assert.True(config.EnableParallelExecution);
            Assert.Null(config.MaxDegreeOfParallelism);
            Assert.Equal(64, config.MinBatchSizePerThread);
            Assert.Equal(128, config.DefaultMinBatchSize);
            Assert.Null(config.ExecutionStrategy);
        }

        /// <summary>
        ///     Tests that create context creates valid context
        /// </summary>
        [Fact]
        public void CreateContext_CreatesValidContext()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 32
            };

            ParallelExecutionContext context = config.CreateContext();

            Assert.NotNull(context);
            Assert.True(context.EnableParallelExecution);
            Assert.Equal(4, context.MaxDegreeOfParallelism);
            Assert.Equal(32, context.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that create executor creates valid executor
        /// </summary>
        [Fact]
        public void CreateExecutor_CreatesValidExecutor()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration();

            ParallelUpdateExecutor executor = config.CreateExecutor();

            Assert.NotNull(executor);
        }

        /// <summary>
        ///     Tests that create executor with custom strategy uses custom strategy
        /// </summary>
        [Fact]
        public void CreateExecutor_WithCustomStrategy_UsesCustomStrategy()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration
            {
                ExecutionStrategy = new AttributeBasedExecutionStrategy()
            };

            ParallelUpdateExecutor executor = config.CreateExecutor();

            Assert.NotNull(executor);
        }
    }

    /// <summary>
    ///     The parallel extension configuration builder test class
    /// </summary>
    public class ParallelExtensionConfigurationBuilderTest
    {
        /// <summary>
        ///     Tests that with parallel execution sets property correctly
        /// </summary>
        [Fact]
        public void WithParallelExecution_SetsPropertyCorrectly()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            ParallelExtensionConfiguration config = builder
                .WithParallelExecution(false)
                .Build();

            Assert.False(config.EnableParallelExecution);
        }

        /// <summary>
        ///     Tests that with max degree of parallelism sets property correctly
        /// </summary>
        [Fact]
        public void WithMaxDegreeOfParallelism_SetsPropertyCorrectly()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            ParallelExtensionConfiguration config = builder
                .WithMaxDegreeOfParallelism(8)
                .Build();

            Assert.Equal(8, config.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that with max degree of parallelism with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithMaxDegreeOfParallelism_WithInvalidValue_ThrowsException()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                builder.WithMaxDegreeOfParallelism(0));
        }

        /// <summary>
        ///     Tests that with min batch size per thread sets property correctly
        /// </summary>
        [Fact]
        public void WithMinBatchSizePerThread_SetsPropertyCorrectly()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            ParallelExtensionConfiguration config = builder
                .WithMinBatchSizePerThread(128)
                .Build();

            Assert.Equal(128, config.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that with min batch size per thread with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithMinBatchSizePerThread_WithInvalidValue_ThrowsException()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                builder.WithMinBatchSizePerThread(0));
        }

        /// <summary>
        ///     Tests that with default min batch size sets property correctly
        /// </summary>
        [Fact]
        public void WithDefaultMinBatchSize_SetsPropertyCorrectly()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            ParallelExtensionConfiguration config = builder
                .WithDefaultMinBatchSize(256)
                .Build();

            Assert.Equal(256, config.DefaultMinBatchSize);
        }

        /// <summary>
        ///     Tests that with default min batch size with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithDefaultMinBatchSize_WithInvalidValue_ThrowsException()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                builder.WithDefaultMinBatchSize(-1));
        }

        /// <summary>
        ///     Tests that with execution strategy sets property correctly
        /// </summary>
        [Fact]
        public void WithExecutionStrategy_SetsPropertyCorrectly()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            ParallelExtensionConfiguration config = builder
                .WithExecutionStrategy(strategy)
                .Build();

            Assert.Same(strategy, config.ExecutionStrategy);
        }

        /// <summary>
        ///     Tests that with execution strategy with null value throws exception
        /// </summary>
        [Fact]
        public void WithExecutionStrategy_WithNullValue_ThrowsException()
        {
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            Assert.Throws<ArgumentNullException>(() =>
                builder.WithExecutionStrategy(null));
        }

        /// <summary>
        ///     Tests that fluent interface works correctly
        /// </summary>
        [Fact]
        public void FluentInterface_WorksCorrectly()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
                .WithParallelExecution(true)
                .WithMaxDegreeOfParallelism(4)
                .WithMinBatchSizePerThread(32)
                .WithDefaultMinBatchSize(64)
                .Build();

            Assert.True(config.EnableParallelExecution);
            Assert.Equal(4, config.MaxDegreeOfParallelism);
            Assert.Equal(32, config.MinBatchSizePerThread);
            Assert.Equal(64, config.DefaultMinBatchSize);
        }
    }
}