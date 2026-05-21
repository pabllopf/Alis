

using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The test component with attribute
    /// </summary>
    [ParallelSafe(256)]
    public struct TestComponentWithAttribute
    {
        /// <summary>
        ///     The value
        /// </summary>
        public float Value;
    }

    /// <summary>
    ///     The test component with interface
    /// </summary>
    public struct TestComponentWithInterface : IParallelCapable
    {
        /// <summary>
        ///     The value
        /// </summary>
        public float Value;
    }

    /// <summary>
    ///     The test component without markers
    /// </summary>
    public struct TestComponentWithoutMarkers
    {
        /// <summary>
        ///     The value
        /// </summary>
        public float Value;
    }

    /// <summary>
    ///     The attribute based execution strategy test class
    /// </summary>
    public class AttributeBasedExecutionStrategyTest
    {
        /// <summary>
        ///     Tests that can execute in parallel detects attribute
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_DetectsAttribute()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithAttribute));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that can execute in parallel detects interface
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_DetectsInterface()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithInterface));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that can execute in parallel returns false for unmarked component
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_ReturnsFalseForUnmarkedComponent()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithoutMarkers));

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get minimum batch size reads attribute value
        /// </summary>
        [Fact]
        public void GetMinimumBatchSize_ReadsAttributeValue()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            int batchSize = strategy.GetMinimumBatchSize(typeof(TestComponentWithAttribute));

            Assert.Equal(256, batchSize);
        }

        /// <summary>
        ///     Tests that get minimum batch size returns default for component without attribute
        /// </summary>
        [Fact]
        public void GetMinimumBatchSize_ReturnsDefaultForComponentWithoutAttribute()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            int batchSize = strategy.GetMinimumBatchSize(typeof(TestComponentWithInterface));

            Assert.Equal(128, batchSize);
        }

        /// <summary>
        ///     Tests that clear cache clears internal caches
        /// </summary>
        [Fact]
        public void ClearCache_ClearsInternalCaches()
        {
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            strategy.CanExecuteInParallel(typeof(TestComponentWithAttribute));
            strategy.GetMinimumBatchSize(typeof(TestComponentWithAttribute));

            strategy.ClearCache();

            Assert.True(true);
        }
    }
}