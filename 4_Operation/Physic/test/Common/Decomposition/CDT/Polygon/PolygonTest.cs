using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    /// The polygon test class
    /// </summary>
    public class PolygonTest
    {
        /// <summary>
        /// Tests that polygon type should be accessible
        /// </summary>
        [Fact]
        public void Polygon_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Polygon.Polygon));
        }
    }
}

