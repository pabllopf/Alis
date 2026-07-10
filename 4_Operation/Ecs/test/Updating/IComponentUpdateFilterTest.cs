using System;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    public class IComponentUpdateFilterTest
    {
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var filter = new TestUpdateFilter();
            Assert.NotNull(filter);
        }

        [Fact]
        public void UpdateSubset_WithEmptySpan_DoesNotThrow()
        {
            var filter = new TestUpdateFilter();
            ReadOnlySpan<ArchetypeDeferredUpdateRecord> span = [];
            var exception = Record.Exception(() => filter.UpdateSubset(span));
            Assert.Null(exception);
        }

        [Fact]
        public void Interface_CanBeUsedAsParameter()
        {
            var filter = new TestUpdateFilter();
            UseFilter(filter);
            Assert.Equal(1, filter.CallCount);
        }

        private static void UseFilter(IComponentUpdateFilter f)
        {
            ReadOnlySpan<ArchetypeDeferredUpdateRecord> span = [];
            f.UpdateSubset(span);
        }

        private sealed class TestUpdateFilter : IComponentUpdateFilter
        {
            public int CallCount { get; private set; }
            public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
            {
                CallCount++;
            }
        }
    }
}
