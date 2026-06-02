using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class ImgInitFlagsTest
    {
        [Fact]
        public void ShouldHaveCorrectValues()
        {
            Assert.Equal(0x00000001, (int)ImgInitFlags.ImgInitJpg);
            Assert.Equal(0x00000002, (int)ImgInitFlags.ImgInitPng);
            Assert.Equal(0x00000004, (int)ImgInitFlags.ImgInitTif);
            Assert.Equal(0x00000008, (int)ImgInitFlags.ImgInitWebp);
        }
    }
}
