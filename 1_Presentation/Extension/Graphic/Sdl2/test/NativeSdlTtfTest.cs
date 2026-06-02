using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class NativeSdlTtfTest
    {
        [Fact]
        public void ShouldReturnCompiledVersion()
        {
            var version = NativeSdlTtf.InternalGetTtfVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(16, version.patch);
        }
    }
}
