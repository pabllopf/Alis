using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    /// The terrain test class
    /// </summary>
    public class TerrainTest
    {
        /// <summary>
        /// Tests that terrain type should be accessible
        /// </summary>
        [Fact]
        public void Terrain_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.TextureTools.Terrain));
        }
    }
}

