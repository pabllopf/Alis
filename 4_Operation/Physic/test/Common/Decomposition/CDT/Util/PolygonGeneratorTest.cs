using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    /// The polygon generator test class
    /// </summary>
    public class PolygonGeneratorTest
    {
        /// <summary>
        /// Tests that polygon generator type should be accessible
        /// </summary>
        [Fact]
        public void PolygonGenerator_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Util.PolygonGenerator));
        }
    }
}

