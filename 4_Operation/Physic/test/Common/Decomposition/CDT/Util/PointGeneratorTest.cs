using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    /// The point generator test class
    /// </summary>
    public class PointGeneratorTest
    {
        /// <summary>
        /// Tests that point generator type should be accessible
        /// </summary>
        [Fact]
        public void PointGenerator_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Util.PointGenerator));
        }
    }
}

