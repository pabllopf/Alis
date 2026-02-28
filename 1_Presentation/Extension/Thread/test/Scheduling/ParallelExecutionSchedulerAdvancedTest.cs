// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExecutionSchedulerAdvancedTest.cs
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
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test.Scheduling
{
    /// <summary>
    ///     Advanced tests for parallel execution scheduler
    /// </summary>
    public class ParallelExecutionSchedulerAdvancedTest
    {
        /// <summary>
        ///     Tests that scheduler handles concurrent executions safely
        /// </summary>
        [Fact]
        public void Scheduler_HandlesConcurrentExecutions_Safely()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            ConcurrentBag<int> results = new ConcurrentBag<int>();

            // Act
            Parallel.For(0, 10, i =>
            {
                scheduler.ExecuteRange(0, 100, (start, length) =>
                {
                    for (int j = start; j < start + length; j++)
                    {
                        results.Add(j);
                    }
                }, 10);
            });

            // Assert
            Assert.Equal(1000, results.Count);
        }

        /// <summary>
        ///     Tests that execute range with exception in action handles gracefully
        /// </summary>
        [Fact]
        public void ExecuteRange_WithExceptionInAction_ThrowsException()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { scheduler.ExecuteRange(0, 100, (start, length) => { throw new InvalidOperationException("Test exception"); }, 10); });
        }

        /// <summary>
        ///     Tests that scheduler with very large count partitions correctly
        /// </summary>
        [Fact]
        public void Scheduler_WithVeryLargeCount_PartitionsCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 8
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int totalProcessed = 0;
            object lockObj = new object();

            // Act
            scheduler.ExecuteRange(0, 100000, (start, length) =>
            {
                lock (lockObj)
                {
                    totalProcessed += length;
                }
            }, 64);

            // Assert
            Assert.Equal(100000, totalProcessed);
        }

        /// <summary>
        ///     Tests that scheduler with minimum batch size boundary
        /// </summary>
        [Fact]
        public void Scheduler_WithMinBatchSizeBoundary_WorksCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            // Test with count exactly equal to minBatchSize
            int[] data = new int[128];
            int executionCount = 0;

            // Act
            scheduler.ExecuteRange(0, 128, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i;
                }
            }, 128);

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i, data[i]);
            }
        }

        /// <summary>
        ///     Tests that scheduler with prime number count
        /// </summary>
        [Fact]
        public void Scheduler_WithPrimeNumberCount_PartitionsCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] data = new int[997]; // Prime number

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
        ///     Tests that clear after multiple executions works
        /// </summary>
        [Fact]
        public void Clear_AfterMultipleExecutions_Works()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            // Act
            for (int i = 0; i < 10; i++)
            {
                scheduler.ExecuteRange(0, 100, (start, length) => { }, 10);
            }

            scheduler.Clear();

            // Assert - should not throw
            scheduler.ExecuteRange(0, 100, (start, length) => { }, 10);
        }

        /// <summary>
        ///     Tests that scheduler with disabled parallelism uses single thread
        /// </summary>
        [Fact]
        public void Scheduler_WithDisabledParallelism_UsesSingleThread()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            ConcurrentBag<int> threadIds = new ConcurrentBag<int>();

            // Act
            scheduler.ExecuteRange(0, 1000, (start, length) => { threadIds.Add(System.Threading.Thread.CurrentThread.ManagedThreadId); }, 10);

            // Assert - should use only one thread
            Assert.Single(threadIds);
        }

        /// <summary>
        ///     Tests that scheduler maintains order in sequential mode
        /// </summary>
        [Fact]
        public void Scheduler_MaintainsOrder_InSequentialMode()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = false
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] results = new int[100];
            int currentIndex = 0;

            // Act
            scheduler.ExecuteRange(0, 100, (start, length) =>
            {
                Assert.Equal(currentIndex, start);
                for (int i = start; i < start + length; i++)
                {
                    results[i] = i;
                    currentIndex++;
                }
            }, 10);

            // Assert
            for (int i = 0; i < results.Length; i++)
            {
                Assert.Equal(i, results[i]);
            }
        }

        /// <summary>
        ///     Tests that scheduler with one item executes correctly
        /// </summary>
        [Fact]
        public void Scheduler_WithOneItem_ExecutesCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            bool executed = false;

            // Act
            scheduler.ExecuteRange(0, 1, (start, length) =>
            {
                executed = true;
                Assert.Equal(0, start);
                Assert.Equal(1, length);
            }, 128);

            // Assert
            Assert.True(executed);
        }

        /// <summary>
        ///     Tests that scheduler can handle rapid clear and execute cycles
        /// </summary>
        [Fact]
        public void Scheduler_CanHandleRapidClearAndExecuteCycles()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            // Act & Assert
            for (int cycle = 0; cycle < 100; cycle++)
            {
                scheduler.ExecuteRange(0, 50, (start, length) => { }, 10);
                scheduler.Clear();
            }
        }

        /// <summary>
        ///     Tests that scheduler with max degree of parallelism one behaves sequentially
        /// </summary>
        [Fact]
        public void Scheduler_WithMaxDegreeOne_BehavesSequentially()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 1
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int executionCount = 0;

            // Act
            scheduler.ExecuteRange(0, 1000, (start, length) => { Interlocked.Increment(ref executionCount); }, 64);

            // Assert
            Assert.Equal(1, executionCount);
        }
    }
}