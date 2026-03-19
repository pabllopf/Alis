using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The breakable body test class
    /// </summary>
    public class BreakableBodyTest
    {
        /// <summary>
        /// Tests that breakable body type should be accessible
        /// </summary>
        [Fact]
        public void BreakableBody_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.BreakableBody));
        }
    }
}

