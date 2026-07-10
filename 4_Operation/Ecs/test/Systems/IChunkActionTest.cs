using System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    public class IChunkActionTest
    {
        [Fact]
        public void RunChunk_WithIntSpan_ExecutesAction()
        {
            var action = new TestChunkAction();
            Span<int> span = [1, 2, 3];
            action.RunChunk(span);
            Assert.Equal(6, action.Sum);
        }

        [Fact]
        public void RunChunk_WithEmptySpan_ExecutesAction()
        {
            var action = new TestChunkAction();
            Span<int> span = [];
            action.RunChunk(span);
            Assert.Equal(0, action.Sum);
        }

        private sealed class TestChunkAction : IChunkAction<int>
        {
            public int Sum { get; private set; }
            public void RunChunk(Span<int> arg)
            {
                foreach (var v in arg) Sum += v;
            }
        }
    }
}
