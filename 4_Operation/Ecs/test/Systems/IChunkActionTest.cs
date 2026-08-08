using System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The chunk action test class
    /// </summary>
    public class IChunkActionTest
    {
        /// <summary>
        /// Tests that run chunk with int span executes action
        /// </summary>
        [Fact] public void RunChunk_WithIntSpan_ExecutesAction()
        {
            TestChunkAction action = new TestChunkAction();
            Span<int> span = [1, 2, 3];
            action.RunChunk(span);
            Assert.Equal(6, action.Sum);
        }

        /// <summary>
        /// Tests that run chunk with empty span executes action
        /// </summary>
        [Fact] public void RunChunk_WithEmptySpan_ExecutesAction()
        {
            TestChunkAction action = new TestChunkAction();
            Span<int> span = [];
            action.RunChunk(span);
            Assert.Equal(0, action.Sum);
        }

        /// <summary>
        /// The test chunk action class
        /// </summary>
        /// <seealso cref="IChunkAction{int}"/>
        internal sealed class TestChunkAction : IChunkAction<int>
        {
            /// <summary>
            /// Gets or sets the value of the sum
            /// </summary>
            public int Sum { get; private set; }
            /// <summary>
            /// Runs the chunk using the specified arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void RunChunk(Span<int> arg)
            {
                foreach (int v in arg) Sum += v;
            }
        }
    }
}
