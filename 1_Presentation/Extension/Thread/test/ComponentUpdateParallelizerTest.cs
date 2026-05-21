

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
    ///     The test component
    /// </summary>
    [ParallelSafe]
    public struct TestComponent
    {
        /// <summary>
        ///     The
        /// </summary>
        public float X;

        /// <summary>
        ///     The
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
            Assert.Throws<ArgumentNullException>(() => new ComponentUpdateParallelizer(null));
        }

        /// <summary>
        ///     Tests that execute component update processes all components
        /// </summary>
        [Fact]
        public void ExecuteComponentUpdate_ProcessesAllComponents()
        {
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

            parallelizer.ExecuteComponentUpdate(span, index =>
            {
                components[index].X *= 2;
                components[index].Y *= 2;
            });

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
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            Assert.Throws<ArgumentNullException>(() =>
                parallelizer.ExecuteRangeUpdate<TestComponent>(100, null));
        }

        /// <summary>
        ///     Tests that execute range update processes all ranges
        /// </summary>
        [Fact]
        public void ExecuteRangeUpdate_ProcessesAllRanges()
        {
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4
            };
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[1000];

            parallelizer.ExecuteRangeUpdate<TestComponent>(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 10;
                }
            });

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
            ParallelExecutionContext context = new ParallelExecutionContext
            {
                EnableParallelExecution = true
            };
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[800];

            parallelizer.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i * 3;
                }
            }, true, 64);

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
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            int[] data = new int[100];

            parallelizer.ExecuteUpdate(data.Length, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    data[i] = i + 5;
                }
            });

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
            ParallelExecutionContext context = new ParallelExecutionContext();
            ParallelUpdateExecutor executor = new ParallelUpdateExecutor(context, new AttributeBasedExecutionStrategy());
            ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(executor);

            TestComponent[] components = new TestComponent[0];
            Span<TestComponent> span = components.AsSpan();

            int executionCount = 0;

            parallelizer.ExecuteComponentUpdate(span, index => { executionCount++; });

            Assert.Equal(0, executionCount);
        }
    }
}