using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    /// The gift wrap test class
    /// </summary>
    public class GiftWrapTest
    {
        /// <summary>
        /// Tests that gift wrap type should be accessible
        /// </summary>
        [Fact]
        public void GiftWrap_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.ConvexHull.GiftWrap));
        }
    }
}

