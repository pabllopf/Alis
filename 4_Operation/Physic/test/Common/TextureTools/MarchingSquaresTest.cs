using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    /// The marching squares test class
    /// </summary>
    public class MarchingSquaresTest
    {
        /// <summary>
        /// Tests that marching squares type should be accessible
        /// </summary>
        [Fact]
        public void MarchingSquares_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.TextureTools.MarchingSquares));
        }
    }
}

