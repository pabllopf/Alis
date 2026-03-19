using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    /// The chain hull test class
    /// </summary>
    public class ChainHullTest
    {
        /// <summary>
        /// Tests that chain hull type should be accessible
        /// </summary>
        [Fact]
        public void ChainHull_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.ConvexHull.ChainHull));
        }
    }
}

