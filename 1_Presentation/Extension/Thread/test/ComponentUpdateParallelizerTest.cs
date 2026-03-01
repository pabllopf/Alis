// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentUpdateParallelizerTest.cs
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
using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Execution;
using Alis.Extension.Thread.Integration;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    /// The test component
    /// </summary>
    [ParallelSafe]
    public struct TestComponent
    {
        /// <summary>
        /// The 
        /// </summary>
        public float X;
        /// <summary>
        /// The 
        /// </summary>
        public float Y;
    }

    /// <summary>
    ///     The component update parallelizer test class
    /// </summary>
    public class ComponentUpdateParallelizerTest
    {
        /// <summary>
        ///     Tests that constructor with null executor throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullExecutor_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComponentUpdateParallelizer(null));
        }

        /// <summary>
        ///     Tests that execute component update processes all components
        /// </summary>
        [Fact]
        public void ExecuteComponentUpdate_ProcessesAllComponents()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true
            };
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            TestComponent[] components = new TestComponent[500];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = new TestComponent {X = i, Y = i * 2};
            }

            Span<TestComponent> span = components.AsSpan();

            // Act
            parallelizer.ExecuteComponentUpdate(span, index =>
            {
                components[index].X *= 2;
                components[index].Y *= 2;
            });

            // Assert
            for (int i = 0; i < components.Length; i++)
            {
                Assert.Equal(i * 2, components[i].X);
                Assert.Equal(i * 4, components[i].Y);
            }
        }

        /// <summary>
        ///     Tests that execute range update with null action throws argument null exception
        /// </summary>
        [Fact]
        public void ExecuteRangeUpdate_WithNullAction_ThrowsArgumentNullException()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                parallelizer.ExecuteRangeUpdate<TestComponent>(100, null));
        }

        /// <summary>
        ///     Tests that execute range update processes all ranges
        /// </summary>
        [Fact]
        public void ExecuteRangeUpdate_ProcessesAllRanges()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[1000];

            // Act
            parallelizer.ExecuteRangeUpdate<TestComponent>(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 10;
                }
            });

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i + 10, data[i]);
            }
        }

        /// <summary>
        ///     Tests that execute update with force parallel works correctly
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithForceParallel_WorksCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true
            };
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[800];

            // Act
            parallelizer.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 3;
                }
            }, true, 64);

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i * 3, data[i]);
            }
        }

        /// <summary>
        ///     Tests that execute update without force parallel works correctly
        /// </summary>
        [Fact]
        public void ExecuteUpdate_WithoutForceParallel_WorksCorrectly()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[100];

            // Act
            parallelizer.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 5;
                }
            }, false);

            // Assert
            for (int i = 0; i < data.Length; i++)
            {
                Assert.Equal(i + 5, data[i]);
            }
        }

        /// <summary>
        ///     Tests that execute component update with empty span does nothing
        /// </summary>
        [Fact]
        public void ExecuteComponentUpdate_WithEmptySpan_DoesNothing()
        {
            // Arrange
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            TestComponent[] components = new TestComponent[0];
            Span<TestComponent> span = components.AsSpan();

            int executionCount = 0;

            // Act
            parallelizer.ExecuteComponentUpdate(span, index => { executionCount++; });

            // Assert
            Assert.Equal(0, executionCount);
        }
    }
}