using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Sets
{
    /// <summary>
    /// The constrained point set test class
    /// </summary>
    public class ConstrainedPointSetTest
    {
        /// <summary>
        /// Tests that constrained point set type should be accessible
        /// </summary>
        [Fact]
        public void ConstrainedPointSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Sets.ConstrainedPointSet));
        }
    }
}

