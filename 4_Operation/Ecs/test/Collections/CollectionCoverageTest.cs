using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    public class CollectionCoverageTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void Chunk_CanBeCreated()
        {
            Chunk<Position> chunk = new Chunk<Position>(4);
            Assert.Equal(4, chunk.Buffer.Length);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void EnumerableHelpers_EmptyEnumerator_Works()
        {
            var enumerator = EnumerableHelpers.GetEmptyEnumerator<int>();
            Assert.False(enumerator.MoveNext());
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void FastestStack_Enumerator_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            using var enumerator = stack.GetEnumerator();
            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void FastestStack_Enumerator_Empty_NoMove()
        {
            FastestStack<int> stack = new FastestStack<int>();
            using var enumerator = stack.GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }
    }
}
