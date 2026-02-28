// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExecutionContext.cs
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

namespace Alis.Extension.Thread.Core
{
    /// <summary>
    ///     Context for parallel execution containing configuration and system information
    /// </summary>
    public sealed class ParallelExecutionContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelExecutionContext" /> class
        /// </summary>
        public ParallelExecutionContext()
        {
            ProcessorCount = Environment.ProcessorCount;
            MaxDegreeOfParallelism = Math.Max(1, ProcessorCount - 1);
            MinBatchSizePerThread = 64;
            EnableParallelExecution = ProcessorCount > 1;
        }

        /// <summary>
        ///     Gets the number of processors available
        /// </summary>
        public int ProcessorCount { get; }

        /// <summary>
        ///     Gets or sets the maximum degree of parallelism
        /// </summary>
        public int MaxDegreeOfParallelism { get; set; }

        /// <summary>
        ///     Gets or sets the minimum batch size per thread
        /// </summary>
        public int MinBatchSizePerThread { get; set; }

        /// <summary>
        ///     Gets or sets whether parallel execution is enabled
        /// </summary>
        public bool EnableParallelExecution { get; set; }

        /// <summary>
        ///     Calculates the optimal number of partitions for the given total count
        /// </summary>
        /// <param name="totalCount">The total number of items</param>
        /// <param name="minBatchSize">The minimum batch size</param>
        /// <returns>The optimal number of partitions</returns>
        public int CalculateOptimalPartitions(int totalCount, int minBatchSize)
        {
            if (!EnableParallelExecution || totalCount < minBatchSize)
            {
                return 1;
            }

            int maxPartitions = Math.Min(MaxDegreeOfParallelism, totalCount / MinBatchSizePerThread);
            return Math.Max(1, maxPartitions);
        }

        /// <summary>
        ///     Determines if parallel execution should be used for the given count
        /// </summary>
        /// <param name="count">The number of items</param>
        /// <param name="minBatchSize">The minimum batch size</param>
        /// <returns>True if parallel execution should be used</returns>
        public bool ShouldExecuteInParallel(int count, int minBatchSize) => EnableParallelExecution && (count >= minBatchSize) && (MaxDegreeOfParallelism > 1);
    }
}