using System;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    /// The component update filter test class
    /// </summary>
    public class IComponentUpdateFilterTest
    {
        /// <summary>
        /// Tests that interface can be implemented
        /// </summary>
        [Fact] public void Interface_CanBeImplemented()
        {
            TestUpdateFilter filter = new TestUpdateFilter();
            Assert.NotNull(filter);
        }

        /// <summary>
        /// Tests that update subset with empty span does not throw
        /// </summary>
        [Fact] public void UpdateSubset_WithEmptySpan_DoesNotThrow()
        {
            TestUpdateFilter filter = new TestUpdateFilter();
            ReadOnlySpan<ArchetypeDeferredUpdateRecord> span = [];
            filter.UpdateSubset(span);
            Assert.Equal(1, filter.CallCount);
        }

        /// <summary>
        /// Tests that interface can be used as parameter
        /// </summary>
        [Fact] public void Interface_CanBeUsedAsParameter()
        {
            TestUpdateFilter filter = new TestUpdateFilter();
            UseFilter(filter);
            Assert.Equal(1, filter.CallCount);
        }

        /// <summary>
        /// Uses the filter using the specified f
        /// </summary>
        /// <param name="f">The </param>
        private static void UseFilter(IComponentUpdateFilter f)
        {
            ReadOnlySpan<ArchetypeDeferredUpdateRecord> span = [];
            f.UpdateSubset(span);
        }

        /// <summary>
        /// The test update filter class
        /// </summary>
        /// <seealso cref="IComponentUpdateFilter"/>
        internal sealed class TestUpdateFilter : IComponentUpdateFilter
        {
            /// <summary>
            /// Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }
            /// <summary>
            /// Updates the subset using the specified archetypes
            /// </summary>
            /// <param name="archetypes">The archetypes</param>
            public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
            {
                CallCount++;
            }
        }
    }
}
