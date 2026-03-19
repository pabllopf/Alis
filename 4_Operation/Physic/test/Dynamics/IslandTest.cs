using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class IslandTest
    {
        [Fact]
        public void Island_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Island));
        }
    }
}

