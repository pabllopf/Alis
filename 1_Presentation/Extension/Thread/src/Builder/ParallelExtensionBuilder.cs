// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExtensionBuilder.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
            // Don't set max degree, let it use default based on processor count
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