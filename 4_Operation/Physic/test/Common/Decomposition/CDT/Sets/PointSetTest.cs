using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Sets
{
    /// <summary>
    /// The point set test class
    /// </summary>
    public class PointSetTest
    {
        /// <summary>
        /// Tests that point set type should be accessible
        /// </summary>
        [Fact]
        public void PointSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Sets.PointSet));
        }
    }
}

