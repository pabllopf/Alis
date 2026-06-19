// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExecutionContextTest.cs
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

using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel execution context test class
    /// </summary>
    public class ParallelExecutionContextTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            Assert.True(context.ProcessorCount > 0);
            Assert.True(context.MaxDegreeOfParallelism >= 1);
            Assert.Equal(64, context.MinBatchSizePerThread);
            Assert.True(context.EnableParallelExecution || context.ProcessorCount == 1);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions returns one for small count
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithSmallCount_ReturnsOne()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            int partitions = context.CalculateOptimalPartitions(50, 128);

            Assert.Equal(1, partitions);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions returns multiple for large count
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithLargeCount_ReturnsMultiple()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 64
            };

            int partitions = context.CalculateOptimalPartitions(1000, 64);

            Assert.True(partitions > 1);
            Assert.True(partitions <= context.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions respects max degree
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_RespectsMaxDegree()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 2,
                MinBatchSizePerThread = 10
            };

            int partitions = context.CalculateOptimalPartitions(10000, 10);

            Assert.True(partitions <= 2);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns false when disabled
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WhenDisabled_ReturnsFalse()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };

            bool result = context.ShouldExecuteInParallel(1000, 64);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns false for small count
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WithSmallCount_ReturnsFalse()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true
            };

            bool result = context.ShouldExecuteInParallel(50, 128);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that should execute in parallel returns true for large count
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WithLargeCount_ReturnsTrue()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };

            bool result = context.ShouldExecuteInParallel(1000, 64);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that max degree of parallelism can be set
        /// </summary>
        [Fact]
        public void MaxDegreeOfParallelism_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.MaxDegreeOfParallelism = 8;

            Assert.Equal(8, context.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that min batch size per thread can be set
        /// </summary>
        [Fact]
        public void MinBatchSizePerThread_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.MinBatchSizePerThread = 32;

            Assert.Equal(32, context.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that enable parallel execution can be set
        /// </summary>
        [Fact]
        public void EnableParallelExecution_CanBeSet()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();

            context.EnableParallelExecution = false;

            Assert.False(context.EnableParallelExecution);
        }

        /// <summary>
        ///     Tests that calculate optimal partitions with disabled parallelism returns one
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WithDisabledParallelism_ReturnsOne()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };

            int partitions = context.CalculateOptimalPartitions(10000, 64);

            Assert.Equal(1, partitions);
        }

        /// <summary>
        ///     Tests that CalculateOptimalPartitions returns one when count less than min batch per thread
        /// </summary>
        [Fact]
        public void CalculateOptimalPartitions_WhenCountLessThanMinBatchPerThread_ReturnsOne()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 128
            };

            int partitions = context.CalculateOptimalPartitions(50, 10);

            Assert.Equal(1, partitions);
        }

        /// <summary>
        ///     Tests that ShouldExecuteInParallel returns false when max degree is one
        /// </summary>
        [Fact]
        public void ShouldExecuteInParallel_WhenMaxDegreeIsOne_ReturnsFalse()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 1
            };

            bool result = context.ShouldExecuteInParallel(1000, 10);

            Assert.False(result);
        }
    }
}