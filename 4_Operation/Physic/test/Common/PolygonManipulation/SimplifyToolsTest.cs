using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The simplify tools test class
    /// </summary>
    public class SimplifyToolsTest
    {
        /// <summary>
        /// Tests that simplify tools type should be accessible
        /// </summary>
        [Fact]
        public void SimplifyTools_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.PolygonManipulation.SimplifyTools));
        }
    }
}

