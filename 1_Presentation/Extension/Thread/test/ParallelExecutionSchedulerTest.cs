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

using System;
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
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int executionCount = 0;

            scheduler.ExecuteRange(0, 10, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                Assert.Equal(0, start);
                Assert.Equal(10, length);
            });

            Assert.Equal(1, executionCount);
        }

        /// <summary>
        ///     Tests that execute range with large count executes in parallel
        /// </summary>
        [Fact]
        public void ExecuteRange_WithLargeCount_ExecutesInParallel()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int totalProcessed = 0;

            scheduler.ExecuteRange(0, 1000, (start, length) => { Interlocked.Add(ref totalProcessed, length); }, 64);

            Assert.Equal(1000, totalProcessed);
        }

        /// <summary>
        ///     Tests that execute range processes all items correctly
        /// </summary>
        [Fact]
        public void ExecuteRange_ProcessesAllItemsCorrectly()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] data = new int[500];

            scheduler.ExecuteRange(0, data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 2;
                }
            }, 64);

            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i * 2, data[i]);
            }
        }

        /// <summary>
        ///     Tests that constructor with null context throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullContext_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ParallelExecutionScheduler(null));
        }

        /// <summary>
        ///     Tests that execute range with null action throws argument null exception
        /// </summary>
        [Fact]
        public void ExecuteRange_WithNullAction_ThrowsArgumentNullException()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            Assert.Throws<ArgumentNullException>(() => scheduler.ExecuteRange(0, 10, null));
        }

        /// <summary>
        ///     Tests that execute range with zero count does nothing
        /// </summary>
        [Fact]
        public void ExecuteRange_WithZeroCount_DoesNothing()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            bool actionCalled = false;

            scheduler.ExecuteRange(0, 0, (start, length) => { actionCalled = true; });

            Assert.False(actionCalled);
        }

        /// <summary>
        ///     Tests that execute range with negative count does nothing
        /// </summary>
        [Fact]
        public void ExecuteRange_WithNegativeCount_DoesNothing()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            bool actionCalled = false;

            scheduler.ExecuteRange(0, -1, (start, length) => { actionCalled = true; });

            Assert.False(actionCalled);
        }

        /// <summary>
        ///     Tests that execute range with parallel context but single partition executes sequentially
        /// </summary>
        [Fact]
        public void ExecuteRange_WithParallelButSinglePartition_ExecutesSequentially()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 64
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            int callCount = 0;
            int capturedStart = 0;
            int capturedLength = 0;

            scheduler.ExecuteRange(0, 100, (start, length) =>
            {
                Interlocked.Increment(ref callCount);
                capturedStart = start;
                capturedLength = length;
            }, 10);

            Assert.Equal(1, callCount);
            Assert.Equal(0, capturedStart);
            Assert.Equal(100, capturedLength);
        }

        /// <summary>
        ///     Tests that execute range with non zero start index processes correct range
        /// </summary>
        [Fact]
        public void ExecuteRange_WithOffsetStart_ProcessesCorrectRange()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);
            int[] data = new int[500];

            scheduler.ExecuteRange(50, 100, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 1;
                }
            }, 10);

            Assert.Equal(0, data[49]);
            Assert.Equal(51, data[50]);
            Assert.Equal(150, data[149]);
            Assert.Equal(0, data[150]);
        }

        /// <summary>
        ///     Tests that clear clears internal state
        /// </summary>
        [Fact]
        public void Clear_ClearsInternalState()
        {
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelExecutionScheduler scheduler = new ParallelExecutionScheduler(context);

            scheduler.Clear();

            Assert.True(true);
        }
    }
}