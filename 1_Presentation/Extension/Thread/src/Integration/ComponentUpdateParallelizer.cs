

using System;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Thread.Execution;

namespace Alis.Extension.Thread.Integration
{
    /// <summary>
    ///     Helper class to parallelize component updates in ECS systems
    /// </summary>
    public sealed class ComponentUpdateParallelizer
    {
        /// <summary>
        ///     The parallel update executor
        /// </summary>
        private readonly ParallelUpdateExecutor executor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentUpdateParallelizer" /> class
        /// </summary>
        /// <param name="executor">The parallel update executor</param>
        public ComponentUpdateParallelizer(ParallelUpdateExecutor executor) => this.executor = executor ?? throw new ArgumentNullException(nameof(executor));

        /// <summary>
        ///     Executes a component update action, potentially in parallel
        /// </summary>
        /// <typeparam name="TComponent">The component type</typeparam>
        /// <param name="components">The component span</param>
        /// <param name="updateAction">The update action for each component</param>
        [ExcludeFromCodeCoverage]
        public void ExecuteComponentUpdate<TComponent>(Span<TComponent> components, Action<int> updateAction)
        {
            if (updateAction == null)
            {
                throw new ArgumentNullException(nameof(updateAction));
            }

            int count = components.Length;
            Type componentType = typeof(TComponent);

            executor.ExecuteUpdate(componentType, count, (startIndex, length) =>
            {
                for (int i = startIndex; i < startIndex + length; i++)
                {
                    updateAction(i);
                }
            });
        }

        /// <summary>
        ///     Executes a range-based component update action
        /// </summary>
        /// <typeparam name="TComponent">The component type</typeparam>
        /// <param name="componentCount">The number of components</param>
        /// <param name="rangeAction">The range action (startIndex, length)</param>
        public void ExecuteRangeUpdate<TComponent>(int componentCount, Action<int, int> rangeAction)
        {
            if (rangeAction == null)
            {
                throw new ArgumentNullException(nameof(rangeAction));
            }

            Type componentType = typeof(TComponent);
            executor.ExecuteUpdate(componentType, componentCount, rangeAction);
        }

        /// <summary>
        ///     Executes an update with explicit parallel control
        /// </summary>
        /// <param name="entityCount">The number of entities</param>
        /// <param name="updateAction">The update action</param>
        /// <param name="forceParallel">Force parallel execution</param>
        /// <param name="minBatchSize">The minimum batch size</param>
        public void ExecuteUpdate(int entityCount, Action<int, int> updateAction, bool forceParallel = false, int minBatchSize = 128)
        {
            executor.ExecuteUpdate(entityCount, updateAction, forceParallel, minBatchSize);
        }
    }
}