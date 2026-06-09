using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The native sdl image test class
    /// </summary>
    public class NativeSdlImageTest
    {
        /// <summary>
        /// Tests that should have native lib name
        /// </summary>
        [Fact]
        public void ShouldHaveNativeLibName()
        {
            Assert.Equal("sdl2_image", NativeSdlImage.NativeLibName);
        }
    }
}
