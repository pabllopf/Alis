using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The triangulate test class
    /// </summary>
    public class TriangulateTest
    {
        /// <summary>
        /// Tests that triangulate type should be accessible
        /// </summary>
        [Fact]
        public void Triangulate_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.Triangulate));
        }
    }
}

