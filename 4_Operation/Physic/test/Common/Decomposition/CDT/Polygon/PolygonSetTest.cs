using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    /// The polygon set test class
    /// </summary>
    public class PolygonSetTest
    {
        /// <summary>
        /// Tests that polygon set type should be accessible
        /// </summary>
        [Fact]
        public void PolygonSet_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Polygon.PolygonSet));
        }
    }
}

