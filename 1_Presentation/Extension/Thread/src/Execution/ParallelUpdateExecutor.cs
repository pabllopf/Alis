

using System;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Scheduling;

namespace Alis.Extension.Thread.Execution
{
    /// <summary>
    ///     Executor for parallel component updates
    /// </summary>
    public sealed class ParallelUpdateExecutor
    {
        /// <summary>
        ///     The scheduler
        /// </summary>
        private readonly ParallelExecutionScheduler scheduler;

        /// <summary>
        ///     The execution strategy
        /// </summary>
        private readonly IParallelExecutionStrategy strategy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelUpdateExecutor" /> class
        /// </summary>
        /// <param name="context">The execution context</param>
        /// <param name="strategy">The execution strategy</param>
        public ParallelUpdateExecutor(ParallelExecutionContext context, IParallelExecutionStrategy strategy)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            this.strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            scheduler = new ParallelExecutionScheduler(context);
        }

        /// <summary>
        ///     Executes the update action for the given component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <param name="entityCount">The number of entities</param>
        /// <param name="updateAction">The update action to execute</param>
        public void ExecuteUpdate(Type componentType, int entityCount, Action<int, int> updateAction)
        {
            if (updateAction == null)
            {
                throw new ArgumentNullException(nameof(updateAction));
            }

            if (entityCount <= 0)
            {
                return;
            }

            bool canParallelize = strategy.CanExecuteInParallel(componentType);
            int minBatchSize = strategy.GetMinimumBatchSize(componentType);

            if (canParallelize)
            {
                scheduler.ExecuteRange(0, entityCount, updateAction, minBatchSize);
            }
            else
            {
                updateAction(0, entityCount);
            }
        }

        /// <summary>
        ///     Executes the update action with explicit parallel control
        /// </summary>
        /// <param name="entityCount">The number of entities</param>
        /// <param name="updateAction">The update action to execute</param>
        /// <param name="forceParallel">Force parallel execution</param>
        /// <param name="minBatchSize">The minimum batch size</param>
        [ExcludeFromCodeCoverage]
        public void ExecuteUpdate(int entityCount, Action<int, int> updateAction, bool forceParallel = false, int minBatchSize = 128)
        {
            if (updateAction == null)
            {
                throw new ArgumentNullException(nameof(updateAction));
            }

            if (entityCount <= 0)
            {
                return;
            }

            if (forceParallel)
            {
                scheduler.ExecuteRange(0, entityCount, updateAction, minBatchSize);
            }
            else
            {
                updateAction(0, entityCount);
            }
        }

        /// <summary>
        ///     Clears the internal caches
        /// </summary>
        public void Clear()
        {
            scheduler.Clear();
        }
    }
}