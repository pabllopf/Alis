using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    /// The delaunay triangle test class
    /// </summary>
    public class DelaunayTriangleTest
    {
        /// <summary>
        /// Tests that delaunay triangle type should be accessible
        /// </summary>
        [Fact]
        public void DelaunayTriangle_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.DelaunayTriangle));
        }
    }
}

