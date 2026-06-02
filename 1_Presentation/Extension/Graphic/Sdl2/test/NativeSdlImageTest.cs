using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class NativeSdlImageTest
    {
        [Fact]
        public void ShouldHaveNativeLibName()
        {
            Assert.Equal("sdl2_image", NativeSdlImage.NativeLibName);
        }
    }
}
