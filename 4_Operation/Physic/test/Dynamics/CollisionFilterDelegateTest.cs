using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The collision filter delegate test class
    /// </summary>
    public class CollisionFilterDelegateTest
    {
        /// <summary>
        /// Tests that collision filter delegate type should be accessible
        /// </summary>
        [Fact]
        public void CollisionFilterDelegate_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.CollisionFilterDelegate));
        }
    }
}

