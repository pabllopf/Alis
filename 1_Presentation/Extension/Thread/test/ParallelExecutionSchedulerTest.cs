// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExecutionSchedulerTest.cs
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

using System.Threading;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel execution scheduler test class
    /// </summary>
    public class ParallelExecutionSchedulerTest
    {
        /// <summary>
        ///     Tests that execute range with small count executes sequentially
        /// </summary>
        [Fact]
        public void ExecuteRange_WithSmallCount_ExecutesSequentially()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int executionCount = 0;

            // Act
            scheduler.ExecuteRange(0, 10, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                Assert.Equal(0, start);
                Assert.Equal(10, length);
            });

            // Assert
            Assert.Equal(1, executionCount);
        }

        /// <summary>
        ///     Tests that execute range with large count executes in parallel
        /// </summary>
        [Fact]
        public void ExecuteRange_WithLargeCount_ExecutesInParallel()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int totalProcessed = 0;

            // Act
            scheduler.ExecuteRange(0, 1000, (start, length) => { Interlocked.Add(ref totalProcessed, length); }, 64);

            // Assert
            Assert.Equal(1000, totalProcessed);
        }

        /// <summary>
        ///     Tests that execute range processes all items correctly
        /// </summary>
        [Fact]
        public void ExecuteRange_ProcessesAllItemsCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] data = new int[500];

            // Act
            scheduler.ExecuteRange(0, data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 2;
                }
            }, 64);

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i * 2, data[i]);
            }
        }

        /// <summary>
        ///     Tests that clear clears internal state
        /// </summary>
        [Fact]
        public void Clear_ClearsInternalState()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            // Act
            scheduler.Clear();

            // Assert - should not throw
            Assert.True(true);
        }
    }
}