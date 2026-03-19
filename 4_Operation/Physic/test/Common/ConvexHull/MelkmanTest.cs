using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    public class MelkmanTest
    {
        [Fact]
        public void Melkman_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.ConvexHull.Melkman));
        }
    }
}

