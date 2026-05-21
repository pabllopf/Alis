

using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Integration;

namespace Alis.Extension.Thread.Builder
{
    /// <summary>
    ///     Fluent builder for configuring parallel extension
    /// </summary>
    public sealed class ParallelExtensionBuilder
    {
        /// <summary>
        ///     The configuration builder
        /// </summary>
        private readonly ParallelExtensionConfigurationBuilder configBuilder;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelExtensionBuilder" /> class
        /// </summary>
        public ParallelExtensionBuilder() => configBuilder = new ParallelExtensionConfigurationBuilder();

        /// <summary>
        ///     Creates a new builder instance
        /// </summary>
        /// <returns>A new builder</returns>
        public static ParallelExtensionBuilder Create() => new ParallelExtensionBuilder();

        /// <summary>
        ///     Enables parallel execution
        /// </summary>
        /// <returns>This builder</returns>
        public ParallelExtensionBuilder EnableParallelExecution()
        {
            configBuilder.WithParallelExecution(true);
            return this;
        }

        /// <summary>
        ///     Disables parallel execution
        /// </summary>
        /// <returns>This builder</returns>
        public ParallelExtensionBuilder DisableParallelExecution()
        {
            configBuilder.WithParallelExecution(false);
            return this;
        }

        /// <summary>
        ///     Sets the maximum number of threads to use
        /// </summary>
        /// <param name="maxThreads">The maximum number of threads</param>
        /// <returns>This builder</returns>
        public ParallelExtensionBuilder WithMaxThreads(int maxThreads)
        {
            configBuilder.WithMaxDegreeOfParallelism(maxThreads);
            return this;
        }

        /// <summary>
        ///     Uses automatic thread count based on processor count
        /// </summary>
        /// <returns>This builder</returns>
        public ParallelExtensionBuilder WithAutoThreadCount() =>
            this;

        /// <summary>
        ///     Sets the minimum batch size per thread
        /// </summary>
        /// <param name="minBatchSize">The minimum batch size</param>
        /// <returns>This builder</returns>
        public ParallelExtensionBuilder WithMinBatchSize(int minBatchSize)
        {
            configBuilder.WithMinBatchSizePerThread(minBatchSize);
            return this;
        }

        /// <summary>
        ///     Builds the thread manager
        /// </summary>
        /// <returns>A configured thread manager</returns>
        public ThreadManager BuildManager()
        {
            ParallelExtensionConfiguration config = configBuilder.Build();
            return new ThreadManager(config);
        }

        /// <summary>
        ///     Builds a component update parallelizer
        /// </summary>
        /// <returns>A configured component update parallelizer</returns>
        public ComponentUpdateParallelizer BuildParallelizer()
        {
            ParallelExtensionConfiguration config = configBuilder.Build();
            ThreadManager manager = new ThreadManager(config);
            return new ComponentUpdateParallelizer(manager.ParallelExecutor);
        }
    }
}