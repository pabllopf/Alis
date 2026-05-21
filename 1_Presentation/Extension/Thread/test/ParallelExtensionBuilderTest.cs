

using Alis.Extension.Thread.Builder;
using Alis.Extension.Thread.Integration;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel extension builder test class
    /// </summary>
    public class ParallelExtensionBuilderTest
    {
        /// <summary>
        ///     Tests that build manager creates valid manager
        /// </summary>
        [Fact]
        public void BuildManager_CreatesValidManager()
        {
            ParallelExtensionBuilder builder = ParallelExtensionBuilder.Create();

            using (ThreadManager manager = builder
                       .EnableParallelExecution()
                       .WithMaxThreads(4)
                       .BuildManager())
            {
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that build parallelizer creates valid parallelizer
        /// </summary>
        [Fact]
        public void BuildParallelizer_CreatesValidParallelizer()
        {
            ParallelExtensionBuilder builder = ParallelExtensionBuilder.Create();

            ComponentUpdateParallelizer parallelizer = builder
                .EnableParallelExecution()
                .WithAutoThreadCount()
                .BuildParallelizer();

            Assert.NotNull(parallelizer);
        }

        /// <summary>
        ///     Tests that fluent interface works correctly
        /// </summary>
        [Fact]
        public void FluentInterface_WorksCorrectly()
        {
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .EnableParallelExecution()
                       .WithMaxThreads(2)
                       .WithMinBatchSize(32)
                       .BuildManager())
            {
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that disable parallel execution creates manager with disabled parallelism
        /// </summary>
        [Fact]
        public void DisableParallelExecution_CreatesManagerWithDisabledParallelism()
        {
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .DisableParallelExecution()
                       .BuildManager())
            {
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }
    }
}