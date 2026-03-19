using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    public class SimpleExplosionTest
    {
        [Fact]
        public void SimpleExplosion_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.SimpleExplosion));
        }
    }
}

