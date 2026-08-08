using System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The entity chunk action test class
    /// </summary>
    public class IEntityChunkActionTest
    {
        /// <summary>
        /// Tests that interface can be implemented
        /// </summary>
        [Fact] public void Interface_CanBeImplemented()
        {
            TestEntityChunkAction action = new TestEntityChunkAction();
            Assert.NotNull(action);
        }

        /// <summary>
        /// Tests that run chunk with empty span does not throw
        /// </summary>
        [Fact] public void RunChunk_WithEmptySpan_DoesNotThrow()
        {
            TestEntityChunkAction action = new TestEntityChunkAction();
            ReadOnlySpan<GameObject> span = [];
            action.RunChunk(span);
            Assert.Equal(0, action.Count);
        }

        /// <summary>
        /// The test entity chunk action class
        /// </summary>
        /// <seealso cref="IEntityChunkAction"/>
        internal sealed class TestEntityChunkAction : IEntityChunkAction
        {
            /// <summary>
            /// Gets or sets the value of the count
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// Runs the chunk using the specified entities
            /// </summary>
            /// <param name="entities">The entities</param>
            public void RunChunk(ReadOnlySpan<GameObject> entities)
            {
                Count = entities.Length;
            }
        }
    }
}
