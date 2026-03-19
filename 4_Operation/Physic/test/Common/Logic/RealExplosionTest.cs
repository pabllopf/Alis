using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The real explosion test class
    /// </summary>
    public class RealExplosionTest
    {
        /// <summary>
        /// Tests that real explosion type should be accessible
        /// </summary>
        [Fact]
        public void RealExplosion_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.RealExplosion));
        }
    }
}

