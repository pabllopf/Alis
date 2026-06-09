using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The native sdl ttf test class
    /// </summary>
    public class NativeSdlTtfTest
    {
        /// <summary>
        /// Tests that should return compiled version
        /// </summary>
        [Fact]
        public void ShouldReturnCompiledVersion()
        {
            Version version = NativeSdlTtf.InternalGetTtfVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(16, version.patch);
        }
    }
}
