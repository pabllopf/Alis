using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The simple explosion test class
    /// </summary>
    public class SimpleExplosionTest
    {
        /// <summary>
        /// Tests that simple explosion type should be accessible
        /// </summary>
        [Fact]
        public void SimpleExplosion_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.SimpleExplosion));
        }
    }
}

