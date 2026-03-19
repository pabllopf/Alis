using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    public class BreakableBodyTest
    {
        [Fact]
        public void BreakableBody_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.BreakableBody));
        }
    }
}

