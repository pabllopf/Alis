using System;
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
        /// Tests that builder drain to immutable returns values and resets builder
        /// </summary>
        [Fact]
        public void Builder_DrainToImmutable_ReturnsValuesAndResetsBuilder()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2, 3);

            FastImmutableArray<int> array = builder.DrainToImmutable();

            Assert.Equal(3, array.Length);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        /// Tests that cast and as work for covariant reference types
        /// </summary>
        [Fact]
        public void CastAndAs_WorkForCovariantReferenceTypes()
        {
            FastImmutableArray<string> strings = new FastImmutableArray<string>(new[] { "a", "b" });
            FastImmutableArray<object> objects = FastImmutableArray<object>.CastUp(strings);

            FastImmutableArray<string> backToString = objects.As<string>();

            Assert.Equal(2, objects.Length);
            Assert.Equal("a", (string)objects[0]);
            Assert.False(backToString.IsDefault);
            Assert.Equal("b", backToString[1]);
        }
    }
}

