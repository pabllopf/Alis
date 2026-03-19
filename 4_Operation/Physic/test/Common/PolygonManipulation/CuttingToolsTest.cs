using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The cutting tools test class
    /// </summary>
    public class CuttingToolsTest
    {
        /// <summary>
        /// Tests that cutting tools type should be accessible
        /// </summary>
        [Fact]
        public void CuttingTools_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.PolygonManipulation.CuttingTools));
        }
    }
}

