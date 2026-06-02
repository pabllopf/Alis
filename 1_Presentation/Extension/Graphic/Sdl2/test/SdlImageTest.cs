using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class SdlImageTest
    {
        [Fact]
        public void ShouldReturnCompiledVersion()
        {
            var version = SdlImage.Version();
            Assert.Equal(2, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(6, version.MinorRevision);
        }
    }
}
