using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    /// The fast immutable array test class
    /// </summary>
    public class FastImmutableArrayTest
    {
        /// <summary>
        /// Tests that empty has expected state
        /// </summary>
        [Fact]
        public void Empty_HasExpectedState()
        {
            FastImmutableArray<int> empty = FastImmutableArray<int>.Empty;

            Assert.False(empty.IsDefault);
            Assert.True(empty.IsEmpty);
            Assert.True(empty.IsDefaultOrEmpty);
            Assert.Equal(0, empty.Length);
        }

        /// <summary>
        /// Tests that indexer and item ref return expected element
        /// </summary>
        [Fact]
        public void IndexerAndItemRef_ReturnExpectedElement()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 3, 5, 8 });

            ref readonly int itemRef = ref array.ItemRef(1);

            Assert.Equal(5, array[1]);
            Assert.Equal(5, itemRef);
        }

        /// <summary>
        /// Tests that equality uses underlying array reference
        /// </summary>
        [Fact]
        public void Equality_UsesUnderlyingArrayReference()
        {
            int[] backing = { 1, 2, 3 };
            FastImmutableArray<int> first = new FastImmutableArray<int>(backing);
            FastImmutableArray<int> second = new FastImmutableArray<int>(backing);
            FastImmutableArray<int> third = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            Assert.True(first == second);
            Assert.False(first != second);
            Assert.False(first == third);
            Assert.True(first != third);
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        /// <summary>
        /// Tests that copy to copies content in order
        /// </summary>
        [Fact]
        public void CopyTo_CopiesContentInOrder()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 10, 20, 30 });
            int[] destination = new int[5];

            array.CopyTo(destination, 1);

            Assert.Equal(new[] { 0, 10, 20, 30, 0 }, destination);
        }

        /// <summary>
        /// Tests that builder add insert remove updates count and order
        /// </summary>
        [Fact]
        public void Builder_AddInsertRemove_UpdatesCountAndOrder()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(3);
            builder.Insert(1, 2);
            builder.Remove(3);

            Assert.Equal(2, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.True(builder.Contains(2));
            Assert.Equal(1, builder.IndexOf(2));
        }

        /// <summary>
        /// Tests that builder move to immutable requires capacity equal count
        /// </summary>
        [Fact]
        public void Builder_MoveToImmutable_RequiresCapacityEqualCount()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.Add(1);
            builder.Add(2);

            Assert.Throws<InvalidOperationException>(() => builder.MoveToImmutable());
        }

        /// <summary>
        /// Tests that builder move to immutable with matching capacity and count succeeds and resets builder
        /// </summary>
        [Fact]
        public void Builder_MoveToImmutable_WithMatchingCapacityAndCount_SucceedsAndResetsBuilder()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(10);
            builder.Add(20);

            FastImmutableArray<int> immutable = builder.MoveToImmutable();

            Assert.Equal(2, immutable.Length);
            Assert.Equal(10, immutable[0]);
            Assert.Equal(20, immutable[1]);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        /// Tests that builder indexer out of range throws
        /// </summary>
        [Fact]
        public void Builder_Indexer_OutOfRange_Throws()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => _ = builder[1]);
            Assert.Throws<IndexOutOfRangeException>(() => builder[1] = 9);
        }

        /// <summary>
        /// Tests that builder remove range removes expected segment
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_RemovesExpectedSegment()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            builder.RemoveRange(1, 2);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(4, builder[1]);
            Assert.Equal(5, builder[2]);
        }

        /// <summary>
        /// Tests that default instance as i enumerable throws invalid operation
        /// </summary>
        [Fact]
        public void DefaultInstance_AsIEnumerable_ThrowsInvalidOperation()
        {
            FastImmutableArray<int> defaultArray = default;

            Assert.Throws<InvalidOperationException>(() => ((IEnumerable<int>)defaultArray).GetEnumerator());
        }
    }
}
