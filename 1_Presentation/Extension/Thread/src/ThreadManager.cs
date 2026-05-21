

using System;
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Execution;

namespace Alis.Extension.Thread
{
    /// <summary>
    ///     Modern thread manager for parallel execution of ECS component updates.
    ///     Provides automatic work partitioning and efficient thread pool management.
    /// </summary>
    public sealed class ThreadManager : IDisposable
    {
        /// <summary>
        ///     The parallel update executor
        /// </summary>
        private readonly ParallelUpdateExecutor parallelExecutor;

        /// <summary>
        ///     Whether the manager has been disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class with default configuration
        /// </summary>
        public ThreadManager() : this(new ParallelExtensionConfiguration())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class
        /// </summary>
        /// <param name="configuration">The parallel execution configuration</param>
        /// <exception cref="ArgumentNullException">Thrown when configuration is null</exception>
        public ThreadManager(ParallelExtensionConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            parallelExecutor = configuration.CreateExecutor();
        }

        /// <summary>
        ///     Gets the parallel update executor for executing component updates
        /// </summary>
        public ParallelUpdateExecutor ParallelExecutor => parallelExecutor;

        /// <summary>
        ///     Disposes the thread manager and releases all resources
        /// </summary>
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            parallelExecutor?.Clear();
            disposed = true;
        }
    }
}