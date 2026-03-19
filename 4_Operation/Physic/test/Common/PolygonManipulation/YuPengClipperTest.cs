using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The yu peng clipper test class
    /// </summary>
    public class YuPengClipperTest
    {
        /// <summary>
        /// Tests that yu peng clipper type should be accessible
        /// </summary>
        [Fact]
        public void YuPengClipper_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.PolygonManipulation.YuPengClipper));
        }
    }
}

