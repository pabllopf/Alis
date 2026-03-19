using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class CollisionFilterDelegateTest
    {
        [Fact]
        public void CollisionFilterDelegate_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.CollisionFilterDelegate));
        }
    }
}

