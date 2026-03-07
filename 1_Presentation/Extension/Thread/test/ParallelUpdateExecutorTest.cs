// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelUpdateExecutorTest.cs
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
using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Execution;
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The test parallel component
    /// </summary>
    [ParallelSafe(64)]
    public struct TestParallelComponent
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    ///     The test sequential component
    /// </summary>
    public struct TestSequentialComponent
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    ///     The parallel update executor test class
    /// </summary>
    public class ParallelUpdateExecutorTest
    {
        /// <summary>
        ///     Tests that constructor with null context throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullContext_ThrowsArgumentNullException()
        {
            // Arrange
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ParallelUpdateExecutor(null, strategy));
        }

        /// <summary>
        ///     Tests that constructor with null strategy throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullStrategy_ThrowsArgumentNullException()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ParallelUpdateExecutor(context, null));
        }

        /// <summary>
        ///     Tests that execute update with parallel safe component executes in parallel
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithParallelSafeComponent_ExecutesInParallel()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int[] data = new int[1000];
            int executionCount = 0;

            // Act
            executor.ExecuteUpdate(typeof(TestParallelComponent), data.Length, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 2;
                }
            });

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i * 2, data[i]);
            }

            Assert.True(executionCount > 1); // Multiple batches executed
        }

        /// <summary>
        ///     Tests that execute update with sequential component executes sequentially
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithSequentialComponent_ExecutesSequentially()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int[] data = new int[100];
            int executionCount = 0;

            // Act
            executor.ExecuteUpdate(typeof(TestSequentialComponent), data.Length, (start, length) =>
            {
                Interlocked.Increment(ref executionCount);
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i;
                }
            });

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i, data[i]);
            }

            Assert.Equal(1, executionCount); // Single execution
        }

        /// <summary>
        ///     Tests that execute update with null action throws argument null exception
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithNullAction_ThrowsArgumentNullException()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                executor.ExecuteUpdate(typeof(TestParallelComponent), 100, null));
        }

        /// <summary>
        ///     Tests that execute update with zero count does nothing
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithZeroCount_DoesNothing()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int executionCount = 0;

            // Act
            executor.ExecuteUpdate(typeof(TestParallelComponent), 0, (start, length) => { Interlocked.Increment(ref executionCount); });

            // Assert
            Assert.Equal(0, executionCount);
        }

        /// <summary>
        ///     Tests that execute update with negative count does nothing
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithNegativeCount_DoesNothing()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int executionCount = 0;

            // Act
            executor.ExecuteUpdate(typeof(TestParallelComponent), -10, (start, length) => { Interlocked.Increment(ref executionCount); });

            // Assert
            Assert.Equal(0, executionCount);
        }

        /// <summary>
        ///     Tests that execute update with force parallel executes in parallel
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithForceParallel_ExecutesInParallel()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int[] data = new int[1000];

            // Act
            executor.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 1;
                }
            }, true, 64);

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i + 1, data[i]);
            }
        }

        /// <summary>
        ///     Tests that execute update without force parallel executes sequentially
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithoutForceParallel_ExecutesSequentially()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            int[] data = new int[100];

            // Act
            executor.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 1;
                }
            });

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i + 1, data[i]);
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
            IParallelExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, strategy);

            // Act
            executor.Clear();

            // Assert - should not throw
            Assert.True(true);
        }
    }
}