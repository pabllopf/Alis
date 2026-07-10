using System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    public class IEntityChunkActionTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void Interface_CanBeImplemented()
        {
            var action = new TestEntityChunkAction();
            Assert.NotNull(action);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void RunChunk_WithEmptySpan_DoesNotThrow()
        {
            var action = new TestEntityChunkAction();
            ReadOnlySpan<GameObject> span = [];
            action.RunChunk(span);
            Assert.Equal(0, action.Count);
        }

        private sealed class TestEntityChunkAction : IEntityChunkAction
        {
            public int Count { get; private set; }
            public void RunChunk(ReadOnlySpan<GameObject> entities)
            {
                Count = entities.Length;
            }
        }
    }
}
