using System;
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     Coverage-driven tests for FastImmutableArray targeting the 6 remaining uncovered lines.
    /// </summary>
    public class FastImmutableArrayCoverageTest
    {
        [Fact]
        public void BuilderIndexerGetterOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = builder[3]);
        }

        [Fact]
        public void BuilderIndexerSetterOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => builder[3] = 99);
        }

        [Fact]
        public void NonGenericGetEnumeratorShouldWork()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {10, 20, 30});

            IEnumerable nonGeneric = array;
            IEnumerator enumerator = nonGeneric.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(10, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(20, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(30, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void BuilderItemRefOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ref readonly int ref1 = ref builder.ItemRef(3);
            });
        }

        [Fact]
        public void BuilderIndexOfWithStartIndexAndCountShouldWork()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            int result = builder.IndexOf(3, 2, 2);

            Assert.Equal(2, result);
        }

        [Fact]
        public void BuilderIndexOfWithStartIndexAndCountNotFoundShouldReturnMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            int result = builder.IndexOf(3, 0, 2);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void BuilderIndexOfWithStartIndexAndComparerShouldWork()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("a", "b", "c");

            int result = builder.IndexOf("b", 0, EqualityComparer<string>.Default);

            Assert.Equal(1, result);
        }

        [Fact]
        public void BuilderIndexOfWithStartIndexAndComparerNotFoundShouldReturnMinusOne()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("a", "b", "c");

            int result = builder.IndexOf("z", 0, EqualityComparer<string>.Default);

            Assert.Equal(-1, result);
        }
    }
}
