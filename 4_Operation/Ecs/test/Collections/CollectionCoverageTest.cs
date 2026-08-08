using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    /// The collection coverage test class
    /// </summary>
    public class CollectionCoverageTest
    {
        /// <summary>
        /// Tests that chunk can be created
        /// </summary>
        [Fact] public void Chunk_CanBeCreated()
        {
            Chunk<Position> chunk = new Chunk<Position>(4);
            Assert.Equal(4, chunk.Buffer.Length);
        }

        /// <summary>
        /// Tests that enumerable helpers empty enumerator works
        /// </summary>
        [Fact] public void EnumerableHelpers_EmptyEnumerator_Works()
        {
            var enumerator = EnumerableHelpers.GetEmptyEnumerator<int>();
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that fastest stack enumerator works
        /// </summary>
        [Fact] public void FastestStack_Enumerator_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            using var enumerator = stack.GetEnumerator();
            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);
        }

        /// <summary>
        /// Tests that fastest stack enumerator empty no move
        /// </summary>
        [Fact] public void FastestStack_Enumerator_Empty_NoMove()
        {
            FastestStack<int> stack = new FastestStack<int>();
            using var enumerator = stack.GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }
    }
}
