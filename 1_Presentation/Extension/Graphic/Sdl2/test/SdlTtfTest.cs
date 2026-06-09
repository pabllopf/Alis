using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        /// <summary>
        /// Tests that should have correct constant values
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectConstantValues()
        {
            Assert.Equal(0xFEFF, SdlTtf.UnicodeBomNative);
            Assert.Equal(0xFFFE, SdlTtf.UnicodeBomSwapped);
            Assert.Equal(0x00, SdlTtf.TtfStyleNormal);
            Assert.Equal(0x01, SdlTtf.TtfStyleBold);
            Assert.Equal(0x02, SdlTtf.TtfStyleItalic);
            Assert.Equal(0x04, SdlTtf.TtfStyleUnderline);
            Assert.Equal(0x08, SdlTtf.TtfStyleStrikethrough);
            Assert.Equal(0, SdlTtf.TtfHintingNormal);
            Assert.Equal(1, SdlTtf.TtfHintingLight);
            Assert.Equal(2, SdlTtf.TtfHintingMono);
            Assert.Equal(3, SdlTtf.TtfHintingNone);
            Assert.Equal(4, SdlTtf.TtfHintingLightSubpixel);
        }
    }
}
