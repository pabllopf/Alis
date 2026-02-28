// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExtensionConfiguration.cs
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

using System;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Execution;
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Strategies;

namespace Alis.Extension.Thread.Configuration
{
    /// <summary>
    ///     Configuration for parallel extension
    /// </summary>
    public sealed class ParallelExtensionConfiguration
    {
        /// <summary>
        ///     Gets or sets whether parallel execution is enabled
        /// </summary>
        public bool EnableParallelExecution { get; set; } = true;

        /// <summary>
        ///     Gets or sets the maximum degree of parallelism
        /// </summary>
        public int? MaxDegreeOfParallelism { get; set; }

        /// <summary>
        ///     Gets or sets the minimum batch size per thread
        /// </summary>
        public int MinBatchSizePerThread { get; set; } = 64;

        /// <summary>
        ///     Gets or sets the default minimum batch size
        /// </summary>
        public int DefaultMinBatchSize { get; set; } = 128;

        /// <summary>
        ///     Gets or sets the execution strategy
        /// </summary>
        public IParallelExecutionStrategy ExecutionStrategy { get; set; }

        /// <summary>
        ///     Creates a new parallel execution context from this configuration
        /// </summary>
        /// <returns>A new parallel execution context</returns>
        internal ParallelExecutionContext CreateContext()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = EnableParallelExecution,
                MinBatchSizePerThread = MinBatchSizePerThread
            };

            if (MaxDegreeOfParallelism.HasValue)
            {
                context.MaxDegreeOfParallelism = MaxDegreeOfParallelism.Value;
            }

            return context;
        }

        /// <summary>
        ///     Creates a new parallel update executor from this configuration
        /// </summary>
        /// <returns>A new parallel update executor</returns>
        internal ParallelUpdateExecutor CreateExecutor()
        {
            ParallelExecutionContext context = CreateContext();
            IParallelExecutionStrategy strategy = ExecutionStrategy ?? new AttributeBasedExecutionStrategy();
            return new ParallelUpdateExecutor(context, strategy);
        }
    }

    /// <summary>
    ///     Builder for parallel extension configuration
    /// </summary>
    public sealed class ParallelExtensionConfigurationBuilder
    {
        /// <summary>
        ///     The configuration being built
        /// </summary>
        private readonly ParallelExtensionConfiguration configuration = new ParallelExtensionConfiguration();

        /// <summary>
        ///     Enables or disables parallel execution
        /// </summary>
        /// <param name="enabled">Whether to enable parallel execution</param>
        /// <returns>This builder</returns>
        public ParallelExtensionConfigurationBuilder WithParallelExecution(bool enabled)
        {
            configuration.EnableParallelExecution = enabled;
            return this;
        }

        /// <summary>
        ///     Sets the maximum degree of parallelism
        /// </summary>
        /// <param name="maxDegree">The maximum degree of parallelism</param>
        /// <returns>This builder</returns>
        public ParallelExtensionConfigurationBuilder WithMaxDegreeOfParallelism(int maxDegree)
        {
            if (maxDegree < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxDegree), "Max degree of parallelism must be at least 1");
            }

            configuration.MaxDegreeOfParallelism = maxDegree;
            return this;
        }

        /// <summary>
        ///     Sets the minimum batch size per thread
        /// </summary>
        /// <param name="minBatchSize">The minimum batch size per thread</param>
        /// <returns>This builder</returns>
        public ParallelExtensionConfigurationBuilder WithMinBatchSizePerThread(int minBatchSize)
        {
            if (minBatchSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(minBatchSize), "Min batch size per thread must be at least 1");
            }

            configuration.MinBatchSizePerThread = minBatchSize;
            return this;
        }

        /// <summary>
        ///     Sets the default minimum batch size
        /// </summary>
        /// <param name="defaultMinBatchSize">The default minimum batch size</param>
        /// <returns>This builder</returns>
        public ParallelExtensionConfigurationBuilder WithDefaultMinBatchSize(int defaultMinBatchSize)
        {
            if (defaultMinBatchSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(defaultMinBatchSize), "Default min batch size must be at least 1");
            }

            configuration.DefaultMinBatchSize = defaultMinBatchSize;
            return this;
        }

        /// <summary>
        ///     Sets the execution strategy
        /// </summary>
        /// <param name="strategy">The execution strategy</param>
        /// <returns>This builder</returns>
        public ParallelExtensionConfigurationBuilder WithExecutionStrategy(IParallelExecutionStrategy strategy)
        {
            configuration.ExecutionStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            return this;
        }

        /// <summary>
        ///     Builds the configuration
        /// </summary>
        /// <returns>The built configuration</returns>
        public ParallelExtensionConfiguration Build()
        {
            return configuration;
        }
    }
}

