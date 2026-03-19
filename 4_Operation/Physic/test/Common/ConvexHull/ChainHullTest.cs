using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    public class ChainHullTest
    {
        [Fact]
        public void ChainHull_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.ConvexHull.ChainHull));
        }
    }
}

