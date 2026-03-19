using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    public class TerrainTest
    {
        [Fact]
        public void Terrain_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.TextureTools.Terrain));
        }
    }
}

