using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation context test class
    /// </summary>
    public class TriangulationContextTest
    {
        /// <summary>
        /// Tests that triangulation context type should be accessible
        /// </summary>
        [Fact]
        public void TriangulationContext_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.TriangulationContext));
        }
    }
}

