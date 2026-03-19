using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The math utils test class
    /// </summary>
    public class MathUtilsTest
    {
        /// <summary>
        /// Tests that math utils type should be accessible
        /// </summary>
        [Fact]
        public void MathUtils_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.MathUtils));
        }
    }
}

