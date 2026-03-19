using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The island test class
    /// </summary>
    public class IslandTest
    {
        /// <summary>
        /// Tests that island type should be accessible
        /// </summary>
        [Fact]
        public void Island_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Island));
        }
    }
}

