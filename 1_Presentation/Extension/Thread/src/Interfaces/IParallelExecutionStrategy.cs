

using System;

namespace Alis.Extension.Thread.Interfaces
{
    /// <summary>
    ///     Strategy interface for parallel execution decisions
    /// </summary>
    public interface IParallelExecutionStrategy
    {
        /// <summary>
        ///     Determines if the given type can be executed in parallel
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>True if the component can be executed in parallel</returns>
        bool CanExecuteInParallel(Type componentType);

        /// <summary>
        ///     Gets the minimum batch size for the given type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The minimum batch size</returns>
        int GetMinimumBatchSize(Type componentType);
    }
}