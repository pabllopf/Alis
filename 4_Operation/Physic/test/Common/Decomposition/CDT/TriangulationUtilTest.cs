using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation util test class
    /// </summary>
    public class TriangulationUtilTest
    {
        /// <summary>
        /// Tests that triangulation util type should be accessible
        /// </summary>
        [Fact]
        public void TriangulationUtil_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.TriangulationUtil));
        }
    }
}

